using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using URWPGSim2D.Common;

namespace URWPGSim2D.Strategy
{
	// Token: 0x02000004 RID: 4
	internal class DebugRecord
	{
		// Token: 0x06000072 RID: 114 RVA: 0x0001FD1C File Offset: 0x0001DF1C
		public static DebugRecord Instance()
		{
			bool flag = DebugRecord.instance == null;
			if (flag)
			{
				DebugRecord.instance = new DebugRecord();
			}
			return DebugRecord.instance;
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0001FD4C File Offset: 0x0001DF4C
		static DebugRecord()
		{
			for (int i = 0; i < 16; i++)
			{
				DebugRecord.strList.Add("");
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0001FDA4 File Offset: 0x0001DFA4
		public static void ceshi(int i, string txt)
		{
			List<string> list = DebugRecord.strList;
			list[i] += "-->";
			list = DebugRecord.strList;
			list[i] += txt;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0001FDF0 File Offset: 0x0001DFF0
		public static void ceshi(int i, string txt, float x)
		{
			List<string> list = DebugRecord.strList;
			list[i] += "-->";
			list = DebugRecord.strList;
			list[i] += txt;
			list = DebugRecord.strList;
			list[i] += "(";
			list = DebugRecord.strList;
			list[i] += x.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += ")";
		}

		// Token: 0x06000076 RID: 118 RVA: 0x0001FEA8 File Offset: 0x0001E0A8
		public static void ceshi(int i, string txt, double x)
		{
			List<string> list = DebugRecord.strList;
			list[i] += "-->";
			list = DebugRecord.strList;
			list[i] += txt;
			list = DebugRecord.strList;
			list[i] += "(";
			list = DebugRecord.strList;
			list[i] += x.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += ")";
		}

		// Token: 0x06000077 RID: 119 RVA: 0x0001FF60 File Offset: 0x0001E160
		public static void ceshi(int i, string txt, float x, float y)
		{
			List<string> list = DebugRecord.strList;
			list[i] += "-->";
			list = DebugRecord.strList;
			list[i] += txt;
			list = DebugRecord.strList;
			list[i] += "(";
			list = DebugRecord.strList;
			list[i] += x.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += y.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += ")";
		}

		// Token: 0x06000078 RID: 120 RVA: 0x00020060 File Offset: 0x0001E260
		public static void ceshi(int i, string txt, double x, double y)
		{
			List<string> list = DebugRecord.strList;
			list[i] += "-->";
			list = DebugRecord.strList;
			list[i] += txt;
			list = DebugRecord.strList;
			list[i] += "(";
			list = DebugRecord.strList;
			list[i] += x.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += y.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += ")";
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00020160 File Offset: 0x0001E360
		public static void ceshi(int i, string txt, float x, float y, float z)
		{
			List<string> list = DebugRecord.strList;
			list[i] += "-->";
			list = DebugRecord.strList;
			list[i] += txt;
			list = DebugRecord.strList;
			list[i] += "(";
			list = DebugRecord.strList;
			list[i] += x.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += y.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += z.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += ")";
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000202A8 File Offset: 0x0001E4A8
		public static void ceshi(int i, string txt, double x, double y, double z)
		{
			List<string> list = DebugRecord.strList;
			list[i] += "-->";
			list = DebugRecord.strList;
			list[i] += txt;
			list = DebugRecord.strList;
			list[i] += "(";
			list = DebugRecord.strList;
			list[i] += x.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += y.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += z.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += ")";
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000203F0 File Offset: 0x0001E5F0
		public static void ceshi(int i, string txt, float x, float y, float z, float p)
		{
			List<string> list = DebugRecord.strList;
			list[i] += "-->";
			list = DebugRecord.strList;
			list[i] += txt;
			list = DebugRecord.strList;
			list[i] += "(";
			list = DebugRecord.strList;
			list[i] += x.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += y.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += z.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += p.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += ")";
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00020584 File Offset: 0x0001E784
		public static void ceshi(int i, string txt, double x, double y, double z, double p)
		{
			List<string> list = DebugRecord.strList;
			list[i] += "-->";
			list = DebugRecord.strList;
			list[i] += txt;
			list = DebugRecord.strList;
			list[i] += "(";
			list = DebugRecord.strList;
			list[i] += x.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += y.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += z.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += p.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += ")";
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00020718 File Offset: 0x0001E918
		public static void ceshi(int i, string txt, float x, float y, float z, float p, float q)
		{
			List<string> list = DebugRecord.strList;
			list[i] += "-->";
			list = DebugRecord.strList;
			list[i] += txt;
			list = DebugRecord.strList;
			list[i] += "(";
			list = DebugRecord.strList;
			list[i] += x.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += y.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += z.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += p.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += q.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += ")";
		}

		// Token: 0x0600007E RID: 126 RVA: 0x000208F4 File Offset: 0x0001EAF4
		public static void ceshi(int i, string txt, double x, double y, double z, double p, double q)
		{
			List<string> list = DebugRecord.strList;
			list[i] += "-->";
			list = DebugRecord.strList;
			list[i] += txt;
			list = DebugRecord.strList;
			list[i] += "(";
			list = DebugRecord.strList;
			list[i] += x.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += y.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += z.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += p.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += q.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += ")";
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00020AD0 File Offset: 0x0001ECD0
		public static void ceshi(int i, string txt, int i0, int i1, int i2, int i3, int i4, int i5, int i6, int i7, int i8)
		{
			List<string> list = DebugRecord.strList;
			list[i] += "-->";
			list = DebugRecord.strList;
			list[i] += txt;
			list = DebugRecord.strList;
			list[i] += "(";
			list = DebugRecord.strList;
			list[i] += i0.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += i1.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += i2.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += i3.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += i4.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += i5.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += i6.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += " , ";
			list = DebugRecord.strList;
			list[i] += i7.ToString(DebugRecord.f);
			list = DebugRecord.strList;
			list[i] += ")";
		}

		// Token: 0x06000080 RID: 128 RVA: 0x00020D88 File Offset: 0x0001EF88
		public static void RecordBaseInfomation(Mission mission, int teamId, Decision[] decisions)
		{
			DebugRecord.ObserveDiagnostics(teamId, decisions);
			bool flag = GlobalVar.PV == 1;
			if (flag)
			{
				GlobalVar.PV = 0;
				string text = GlobalVar.Paishu.ToString() + "\t";
				text = text + mission.CommonPara.MsPerCycle.ToString() + "\t";
				text = text + mission.CommonPara.RemainingCycles.ToString() + "\t";
				text = text + mission.CommonPara.TotalSeconds.ToString() + "\t";
				text = text + mission.CommonPara.TeamCount.ToString() + "\t";
				text = text + mission.CommonPara.FishCntPerTeam.ToString() + "\t";
				text += GlobalVar.teamId.ToString();
				DebugRecord.strRecord.Add(text);
				teamId = GlobalVar.teamId;
				for (int i = 0; i < mission.CommonPara.TeamCount; i++)
				{
					for (int j = 0; j < mission.CommonPara.FishCntPerTeam; j++)
					{
						text = "";
						text = text + mission.TeamsRef[teamId].Fishes[j].PositionMm.X.ToString() + "\t";
						text = text + mission.TeamsRef[teamId].Fishes[j].PositionMm.Z.ToString() + "\t";
						text = text + mission.TeamsRef[teamId].Fishes[j].BodyDirectionRad.ToString() + "\t";
						text = text + mission.TeamsRef[teamId].Fishes[j].VelocityMmPs.ToString() + "\t";
						text = text + mission.TeamsRef[teamId].Fishes[j].VelocityDirectionRad.ToString() + "\t";
						text = text + mission.TeamsRef[teamId].Fishes[j].AngularVelocityRadPs.ToString() + "\t";
						text = text + mission.TeamsRef[teamId].Fishes[j].TargetTactic.VCode.ToString() + "\t";
						text = text + mission.TeamsRef[teamId].Fishes[j].TargetTactic.TCode.ToString() + "\t";
						text = text + decisions[j].VCode.ToString() + "\t";
						text += decisions[j].TCode.ToString();
						DebugRecord.strRecord.Add(text);
					}
					teamId = (teamId + 1) % 2;
				}
				text = "";
				text += mission.EnvRef.Balls.Count.ToString();
				DebugRecord.strRecord.Add(text);
				for (int j = 0; j < mission.EnvRef.Balls.Count; j++)
				{
					text = "";
					text = text + mission.EnvRef.Balls[j].PositionMm.X.ToString() + "\t";
					text = text + mission.EnvRef.Balls[j].PositionMm.Z.ToString() + "\t";
					text = text + mission.EnvRef.Balls[j].RadiusMm.ToString() + "\t";
					text = text + mission.EnvRef.Balls[j].VelocityMmPs.ToString() + "\t";
					text += mission.EnvRef.Balls[j].VelocityDirectionRad.ToString();
					DebugRecord.strRecord.Add(text);
				}
				text = "";
				text += DebugRecord.strList.Count.ToString();
				DebugRecord.strRecord.Add(text);
				for (int j = 0; j < DebugRecord.strList.Count; j++)
				{
					DebugRecord.strRecord.Add(DebugRecord.strList[j]);
					DebugRecord.strList[j] = "";
				}
				GlobalVar.PV = 1;
			}
		}

		public static void ResetDiagnostics()
		{
			DebugRecord.diagnosticInitialized = false;
			DebugRecord.lastDiagnosticCycle = 0;
			DebugRecord.sameTargetActive = false;
			DebugRecord.teammateStallActive = false;
			for (int fishId = 0; fishId < 2; fishId++)
			{
				DebugRecord.lastFishX[fishId] = 0.0;
				DebugRecord.lastFishZ[fishId] = 0.0;
				DebugRecord.lowMovementSamples[fishId] = 0;
				DebugRecord.stallActive[fishId] = false;
			}
		}

		private static void ObserveDiagnostics(int teamId, Decision[] decisions)
		{
			try
			{
				if (!DebugRecord.diagnosticInitialized)
				{
					DebugRecord.diagnosticPath = Path.Combine(Path.GetTempPath(), "strategy_diagnostics_team" + teamId.ToString(CultureInfo.InvariantCulture) + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss", CultureInfo.InvariantCulture) + ".tsv");
					File.WriteAllText(DebugRecord.diagnosticPath, "cycle\tevent\tstate\tteamId\tfishId\ttargetBall\tx\tz\tvelocity\tvCode\ttCode\tcontext\r\n", Encoding.UTF8);
					for (int fishId = 0; fishId < 2; fishId++)
					{
						DebugRecord.lastFishX[fishId] = (double)GlobalVar.MyTeam.Fishes[fishId].PositionMm.X;
						DebugRecord.lastFishZ[fishId] = (double)GlobalVar.MyTeam.Fishes[fishId].PositionMm.Z;
					}
					DebugRecord.diagnosticInitialized = true;
					DebugRecord.WriteDiagnostic("DIAGNOSTIC", "START", teamId, -1, -1, decisions, "normalized_left_view");
				}

				int firstTarget = GlobalVar.Bringing_BallID[0];
				int secondTarget = GlobalVar.Bringing_BallID[1];
				bool sameTarget = firstTarget >= 0 && firstTarget < GlobalVar.balls.Length && firstTarget == secondTarget;
				if (sameTarget != DebugRecord.sameTargetActive)
				{
					DebugRecord.WriteDiagnostic("TARGET_CONFLICT", sameTarget ? "ENTER" : "EXIT", teamId, -1, sameTarget ? firstTarget : -1, decisions, "both_fish");
					DebugRecord.sameTargetActive = sameTarget;
				}

				if (GlobalVar.Paishu - DebugRecord.lastDiagnosticCycle < 50)
				{
					return;
				}

				bool[] lowMovement = new bool[2];
				for (int fishId = 0; fishId < 2; fishId++)
				{
					double fishX = (double)GlobalVar.MyTeam.Fishes[fishId].PositionMm.X;
					double fishZ = (double)GlobalVar.MyTeam.Fishes[fishId].PositionMm.Z;
					double displacement = Compute.GetDistance(fishX, fishZ, DebugRecord.lastFishX[fishId], DebugRecord.lastFishZ[fishId]);
					bool highCommand = decisions[fishId].VCode >= 8;
					lowMovement[fishId] = highCommand && displacement < 80.0;
					DebugRecord.lowMovementSamples[fishId] = lowMovement[fishId] ? DebugRecord.lowMovementSamples[fishId] + 1 : 0;

					bool stalled = DebugRecord.lowMovementSamples[fishId] >= 3;
					if (stalled != DebugRecord.stallActive[fishId])
					{
						string context = DebugRecord.DescribeStallContext(fishId, fishX, fishZ);
						DebugRecord.WriteDiagnostic("FISH_STALL", stalled ? "ENTER" : "EXIT", teamId, fishId, GlobalVar.Bringing_BallID[fishId], decisions, context);
						DebugRecord.stallActive[fishId] = stalled;
					}

					DebugRecord.lastFishX[fishId] = fishX;
					DebugRecord.lastFishZ[fishId] = fishZ;
				}

				double teammateDistance = Compute.GetDistance((double)GlobalVar.MyTeam.Fishes[0].PositionMm.X, (double)GlobalVar.MyTeam.Fishes[0].PositionMm.Z, (double)GlobalVar.MyTeam.Fishes[1].PositionMm.X, (double)GlobalVar.MyTeam.Fishes[1].PositionMm.Z);
				bool teammateStall = teammateDistance < 240.0 && lowMovement[0] && lowMovement[1] && decisions[0].VCode >= 8 && decisions[1].VCode >= 8;
				if (teammateStall != DebugRecord.teammateStallActive)
				{
					DebugRecord.WriteDiagnostic("TEAMMATE_STALL", teammateStall ? "ENTER" : "EXIT", teamId, -1, -1, decisions, "distance=" + teammateDistance.ToString("F1", CultureInfo.InvariantCulture));
					DebugRecord.teammateStallActive = teammateStall;
				}

				DebugRecord.lastDiagnosticCycle = GlobalVar.Paishu;
			}
			catch
			{
			}
		}

		private static string DescribeStallContext(int fishId, double fishX, double fishZ)
		{
			double teammateDistance = Compute.GetDistance(fishX, fishZ, (double)GlobalVar.MyTeam.Fishes[1 - fishId].PositionMm.X, (double)GlobalVar.MyTeam.Fishes[1 - fishId].PositionMm.Z);
			double firstOpponentDistance = Compute.GetDistance(fishX, fishZ, (double)GlobalVar.OppTeam.Fishes[0].PositionMm.X, (double)GlobalVar.OppTeam.Fishes[0].PositionMm.Z);
			double secondOpponentDistance = Compute.GetDistance(fishX, fishZ, (double)GlobalVar.OppTeam.Fishes[1].PositionMm.X, (double)GlobalVar.OppTeam.Fishes[1].PositionMm.Z);
			double nearestOpponentDistance = Math.Min(firstOpponentDistance, secondOpponentDistance);
			int targetBall = GlobalVar.Bringing_BallID[fishId];
			string targetContext = "target_x=NA,target_z=NA";
			if (targetBall >= 0 && targetBall < GlobalVar.balls.Length)
			{
				targetContext = "target_x=" + GlobalVar.balls[targetBall].PositionMm.X.ToString("F1", CultureInfo.InvariantCulture) + ",target_z=" + GlobalVar.balls[targetBall].PositionMm.Z.ToString("F1", CultureInfo.InvariantCulture);
			}
			string distanceContext = targetContext + ",opponent_distance=" + nearestOpponentDistance.ToString("F1", CultureInfo.InvariantCulture);
			if (teammateDistance < 260.0)
			{
				return "teammate_distance=" + teammateDistance.ToString("F1", CultureInfo.InvariantCulture) + "," + distanceContext;
			}
			if (fishX < -850.0 && Math.Abs(fishZ) > 400.0 && Math.Abs(fishZ) < 700.0)
			{
				return "goal_frame," + distanceContext;
			}
			if (fishX < -1400.0 || Math.Abs(fishZ) > 850.0)
			{
				return "field_boundary," + distanceContext;
			}
			return "open_water_or_ball_contact," + distanceContext;
		}

		private static void WriteDiagnostic(string eventName, string state, int teamId, int fishId, int targetBall, Decision[] decisions, string context)
		{
			double fishX = fishId >= 0 ? (double)GlobalVar.MyTeam.Fishes[fishId].PositionMm.X : 0.0;
			double fishZ = fishId >= 0 ? (double)GlobalVar.MyTeam.Fishes[fishId].PositionMm.Z : 0.0;
			double velocity = fishId >= 0 ? (double)GlobalVar.MyTeam.Fishes[fishId].VelocityMmPs : 0.0;
			int vCode = fishId >= 0 ? decisions[fishId].VCode : -1;
			int tCode = fishId >= 0 ? decisions[fishId].TCode : -1;
			string line = GlobalVar.Paishu.ToString(CultureInfo.InvariantCulture) + "\t" + eventName + "\t" + state + "\t" + teamId.ToString(CultureInfo.InvariantCulture) + "\t" + fishId.ToString(CultureInfo.InvariantCulture) + "\t" + targetBall.ToString(CultureInfo.InvariantCulture) + "\t" + fishX.ToString("F1", CultureInfo.InvariantCulture) + "\t" + fishZ.ToString("F1", CultureInfo.InvariantCulture) + "\t" + velocity.ToString("F1", CultureInfo.InvariantCulture) + "\t" + vCode.ToString(CultureInfo.InvariantCulture) + "\t" + tCode.ToString(CultureInfo.InvariantCulture) + "\t" + context + "\r\n";
			File.AppendAllText(DebugRecord.diagnosticPath, line, Encoding.UTF8);
		}

		// Token: 0x04000004 RID: 4
		public static List<string> strList = new List<string>();

		// Token: 0x04000005 RID: 5
		public static List<string> strRecord = new List<string>();

		// Token: 0x04000006 RID: 6
		private static DebugRecord instance = null;

		// Token: 0x04000007 RID: 7
		private static string f = "f4";

		private static bool diagnosticInitialized = false;

		private static int lastDiagnosticCycle = 0;

		private static double[] lastFishX = new double[2];

		private static double[] lastFishZ = new double[2];

		private static int[] lowMovementSamples = new int[2];

		private static bool[] stallActive = new bool[2];

		private static bool sameTargetActive = false;

		private static bool teammateStallActive = false;

		private static string diagnosticPath = "";
	}
}
