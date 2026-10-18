using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using URWPGSim2D.Common;
using URWPGSim2D.Match;
using URWPGSim2D.StrategyLoader;
using Microsoft.Xna.Framework;

internal static class Harness
{
    private delegate bool EnumProc(IntPtr window, IntPtr param);
    [DllImport("kernel32.dll")] private static extern uint GetCurrentThreadId();
    [DllImport("imm32.dll")] private static extern bool ImmDisableIME(uint id);
    [DllImport("user32.dll")] private static extern bool EnumThreadWindows(uint id, EnumProc callback, IntPtr param);
    [DllImport("user32.dll", CharSet = CharSet.Unicode)] private static extern int GetClassName(IntPtr window, StringBuilder name, int size);
    [DllImport("user32.dll")] private static extern bool PostMessage(IntPtr window, uint message, IntPtr wparam, IntPtr lparam);
    private static readonly Vector3[] Goals = {
        new Vector3(0,0,0), new Vector3(-240,0,-160), new Vector3(-240,0,160),
        new Vector3(-480,0,-320), new Vector3(-480,0,0), new Vector3(-480,0,320)
    };

    [STAThread]
    private static int Main(string[] args)
    {
        try
        {
            ImmDisableIME(0xffffffff);
            uint mainThread = GetCurrentThreadId();
            // Only dismiss this harness thread's scoring dialogs, never the user's server.
            using (Timer timer = new Timer(delegate(object state) {
                EnumThreadWindows(mainThread, delegate(IntPtr window, IntPtr unused) {
                    StringBuilder name = new StringBuilder(64);
                    GetClassName(window, name, name.Capacity);
                    if (name.ToString() == "#32770")
                    {
                        PostMessage(window, 0x111, new IntPtr(1), IntPtr.Zero);
                        PostMessage(window, 0x10, IntPtr.Zero, IntPtr.Zero);
                    }
                    return true;
                }, IntPtr.Zero);
            }, null, 50, 50))
            {
                Mission m = Match1V1Moving.Instance();
                MyMission mm = MyMission.Instance();
                mm.MissionRef = m; mm.IMissionRef = m; mm.ParasRef = m.CommonPara; mm.TeamsRef = m.TeamsRef;
                m.SetMission();
                m.CommonPara.TotalSeconds = 600;
                m.CommonPara.RemainingCycles = 6000;
                m.CommonPara.IsRunning = true;
                m.CommonPara.IsPaused = false;
                Console.WriteLine("Platform: " + m.GetType().Assembly.Location);
                Console.WriteLine("Field: {0} x {1}; ball radius: {2}",
                    m.EnvRef.FieldInfo.FieldLengthXMm, m.EnvRef.FieldInfo.FieldLengthZMm, m.EnvRef.Balls[0].RadiusMm);
                string dll = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "StrategyWaterTransport.dll");
                IStrategy strategy = new StrategyInterfaceFactory().Create(dll, "URWPGSim2D.Strategy.Strategy", null);
                Console.WriteLine("Loaded: " + strategy.GetTeamName());
                Type table = Assembly.LoadFrom(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "URWPGSim2D.Core.dll"))
                    .GetType("URWPGSim2D.Core.DataBasedOnExperiment");
                foreach (string name in new string[] { "VCodeAndVelocityTable", "TCodeAndAngularVelocityTable" })
                {
                    Console.Write(name + ": ");
                    foreach (object value in (Array)table.GetField(name).GetValue(null)) Console.Write(value + " ");
                    Console.WriteLine();
                }
                CheckScoreBoundary(m);
                CheckContracts(m, strategy);
                m.SetMission();
                m.CommonPara.RemainingCycles = 6000;
                m.CommonPara.IsRunning = true;
                for (int i = 0; i < 6; i++) Console.WriteLine("ball{0} initial={1} goal={2}", i, m.EnvRef.Balls[i].PositionMm, Goals[i]);
                int score = 0, lastCycle = 0;
                int reloadCycle = args.Length > 0 ? int.Parse(args[0]) : -1;
                for (int cycle = 1; cycle <= 6000; cycle++)
                {
                    if (cycle == reloadCycle)
                    {
                        strategy = new StrategyInterfaceFactory().Create(dll, "URWPGSim2D.Strategy.Strategy", null);
                        Console.WriteLine("RELOAD cycle=" + cycle);
                    }
                    Decision[] d = strategy.GetDecision(m, 0);
                    Require(d.Length == 2, "Decision length");
                    for (int i = 0; i < 2; i++)
                    {
                        Require(d[i].VCode >= 0 && d[i].VCode <= 14 && d[i].TCode >= 0 && d[i].TCode <= 14, "Decision bounds");
                        m.DecisionRef[0, i] = d[i];
                    }
                    m.SetDecisionsToFishes();
                    m.ProcessFishLocomotion();
                    m.ProcessBallLocomotion();
                    m.ProcessCollision();
                    m.CommonPara.RemainingCycles = 6000 - cycle;
                    m.ProcessControlRules();
                    m.CommonPara.IsPauseNeeded = false;
                    m.CommonPara.IsPaused = false;
                    if (score != m.TeamsRef[0].Para.Score)
                    {
                        score = m.TeamsRef[0].Para.Score; lastCycle = cycle;
                        Console.WriteLine("SCORE {0}/6 at {1:0.0}s flags={2}", score, cycle * 0.1, Flags(m));
                    }
                    if (cycle % 100 == 0)
                    {
                        Console.Write("c{0} ", cycle);
                        for (int i = 0; i < 6; i++)
                            Console.Write("b{0}=({1:0},{2:0})/{3:0} ", i, m.EnvRef.Balls[i].PositionMm.X,
                                m.EnvRef.Balls[i].PositionMm.Z, Vector3.Distance(m.EnvRef.Balls[i].PositionMm, Goals[i]));
                        for (int i = 0; i < 2; i++)
                            Console.Write(" f{0}=({1:0},{2:0}) a={3:0.00} v={4} t={5} vel={6:0.0} w={7:0.00}", i,
                                m.TeamsRef[0].Fishes[i].PositionMm.X, m.TeamsRef[0].Fishes[i].PositionMm.Z,
                                m.TeamsRef[0].Fishes[i].BodyDirectionRad, d[i].VCode, d[i].TCode,
                                m.TeamsRef[0].Fishes[i].VelocityMmPs, m.TeamsRef[0].Fishes[i].AngularVelocityRadPs);
                        Console.WriteLine();
                    }
                    if (score == 6) break;
                }
                Console.WriteLine("RESULT official score={0}/6 lastGoal={1:0.0}s", score, lastCycle * 0.1);
                return score == 6 ? 0 : 2;
            }
        }
        catch (Exception ex) { Console.Error.WriteLine(ex); return 1; }
    }

    private static string Flags(Mission m)
    {
        string flags = "";
        for (int i = 0; i < 6; i++) flags += Convert.ToString(m.HtMissionVariables["Ball" + i + "InHole"]);
        return flags;
    }

    private static void CheckScoreBoundary(Mission m)
    {
        MethodInfo predicate = m.GetType().GetMethod("IsBallInHole", BindingFlags.NonPublic | BindingFlags.Instance);
        Require(predicate != null, "Platform score predicate available");
        for (int i = 0; i < 6; i++)
        {
            Vector3 original = m.EnvRef.Balls[i].PositionMm;
            m.EnvRef.Balls[i].PositionMm = Goals[i] + new Vector3(22, 0, 0);
            Require(!(bool)predicate.Invoke(m, new object[] { i }), "22mm boundary must not score");
            m.EnvRef.Balls[i].PositionMm = Goals[i] + new Vector3(21.9f, 0, 0);
            Require((bool)predicate.Invoke(m, new object[] { i }), "21.9mm must score");
            m.EnvRef.Balls[i].PositionMm = Goals[(i + 1) % 6];
            Require(!(bool)predicate.Invoke(m, new object[] { i }), "Wrong numbered landmark must not score");
            m.EnvRef.Balls[i].PositionMm = original;
        }
        Console.WriteLine("PASS official target mapping and strict 22mm boundary");
    }

    private static void CheckContracts(Mission m, IStrategy s)
    {
        foreach (Decision d in s.GetDecision(m, -1)) Require(d.VCode == 0 && d.TCode == 7, "Invalid team neutral");
        for (int i = 0; i < 6; i++) m.HtMissionVariables["Ball" + i + "InHole"] = "1";
        foreach (Decision d in s.GetDecision(m, 0)) Require(d.VCode == 0 && d.TCode == 7, "Scored balls not targeted");
        m.CommonPara.RemainingCycles = 0;
        foreach (Decision d in s.GetDecision(m, 0)) Require(d.VCode == 0 && d.TCode == 7, "Match over neutral");
        Console.WriteLine("PASS invalid team, completed balls, match end");
    }

    private static void Require(bool test, string message)
    {
        if (!test) throw new InvalidOperationException(message);
    }
}
