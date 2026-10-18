using System;
using System.Collections;
using System.Collections.Generic;
using URWPGSim2D.Common;

namespace URWPGSim2D.Strategy
{
	// Token: 0x02000005 RID: 5
	public class GlobalVar
	{
		// Token: 0x06000082 RID: 130 RVA: 0x00021230 File Offset: 0x0001F430
		static GlobalVar()
		{
			GlobalVar.Paishu = 0;
			GlobalVar.BaAction = new BaseAction();
		}

		// Token: 0x06000083 RID: 131 RVA: 0x000218EC File Offset: 0x0001FAEC
		public static void Init()
		{
			DebugRecord.ResetDiagnostics();

			// 初始化避障状态
			detour_stage[0] = 0;
			detour_stage[1] = 0;
			detour_target_opp[0] = -1;
			detour_target_opp[1] = -1;
			
			// 初始化挑球状态
			flick_ball_cooldown[0] = 0;
			flick_ball_cooldown[1] = 0;
			flick_ball_stage[0] = 0;
			flick_ball_stage[1] = 0;
			stalemate_timer[0] = 0;
			stalemate_timer[1] = 0;
		}

		// Token: 0x06000084 RID: 132 RVA: 0x000218F0 File Offset: 0x0001FAF0
		public static GlobalVar Instance()
		{
			bool flag = GlobalVar.instance == null;
			if (flag)
			{
				GlobalVar.instance = new GlobalVar();
			}
			return GlobalVar.instance;
		}

		// Token: 0x04000008 RID: 8
		public static int cnt1 = 0;

		// Token: 0x04000009 RID: 9
		public static int cntplus = 0;

		// Token: 0x0400000A RID: 10
		public static int cnt2 = 0;

		// Token: 0x0400000B RID: 11
		public static string MyFlashDisk = "西工大";

		// Token: 0x0400000C RID: 12
		public static int ctp = 0;

		// Token: 0x0400000D RID: 13
		public static Mission mission;

		// Token: 0x0400000E RID: 14
		public static Team<RoboFish> MyTeam = null;

		// Token: 0x0400000F RID: 15
		public static Team<RoboFish> MyTeamLast = null;

		// Token: 0x04000010 RID: 16
		public static Team<RoboFish> OppTeam = null;

		// Token: 0x04000011 RID: 17
		public static int Paishu;

		// Token: 0x04000012 RID: 18
		public static int teamId;

		// Token: 0x04000013 RID: 19
		public static int oppTeamId;

		// Token: 0x04000014 RID: 20
		public static ArrayList po = new ArrayList();

		// Token: 0x04000015 RID: 21
		public static int[] count = new int[5];

		// Token: 0x04000016 RID: 22
		public static Ball[] balls = new Ball[9];

		// Token: 0x04000017 RID: 23
		public static Decision[] decisions = null;

		// Token: 0x04000018 RID: 24
		public static double PI = 3.1415926535897931;

		// Token: 0x04000019 RID: 25
		public static int Start;

		// Token: 0x0400001A RID: 26
		public static int ScoreSum;

		// Token: 0x0400001B RID: 27
		public static int[] Delay = new int[5];

		// Token: 0x0400001C RID: 28
		public static double[,] ball_locate = new double[,]
		{
			{
				-120.0,
				-120.0
			},
			{
				-120.0,
				-0.0
			},
			{
				-120.0,
				120.0
			},
			{
				0.0,
				-120.0
			},
			{
				0.0,
				-0.0
			},
			{
				0.0,
				120.0
			},
			{
				120.0,
				-120.0
			},
			{
				120.0,
				-0.0
			},
			{
				120.0,
				120.0
			}
		};

		// Token: 0x0400001D RID: 29
		public static int Yard_halflength = 2100;

		// Token: 0x0400001E RID: 30
		public static int Yard_halfwidth = 1500;

		// Token: 0x0400001F RID: 31
		public static int Attack_Line = 500;

		// Token: 0x04000020 RID: 32
		public static int Defence_Line = -500;

		// Token: 0x04000021 RID: 33
		public static int Goal_length = 400;

		// Token: 0x04000022 RID: 34
		public static int Goal_width = 150;

		// Token: 0x04000023 RID: 35
		public static int Forbidden_length = 1000;

		// Token: 0x04000024 RID: 36
		public static int Forbidden_width = 400;

		// Token: 0x04000025 RID: 37
		public static Point2D Start_point = new Point2D(0.0, 0.0);

		// Token: 0x04000026 RID: 38
		public static Point2D Penalty_point = new Point2D(1750.0, 0.0);

		// Token: 0x04000027 RID: 39
		public static Point2D OPP_Penalty_point = new Point2D(-1750.0, 0.0);

		// Token: 0x04000028 RID: 40
		public static Point2D Up_Dead_ball_point = new Point2D(1125.0, -750.0);

		// Token: 0x04000029 RID: 41
		public static Point2D Down_Dead_ball_point = new Point2D(1125.0, 750.0);

		// Token: 0x0400002A RID: 42
		public static Point2D Opp_Up_Dead_ball_point = new Point2D(-1125.0, -750.0);

		// Token: 0x0400002B RID: 43
		public static Point2D Opp_Down_Dead_ball_point = new Point2D(-1125.0, 750.0);

		// Token: 0x0400002C RID: 44
		public static int Opp_Goal_upline = -200;

		// Token: 0x0400002D RID: 45
		public static int Opp_Goal_downline = 200;

		// Token: 0x0400002E RID: 46
		public static int Opp_Goal_line = 2100;

		// Token: 0x0400002F RID: 47
		public static int Opp_Forbidden_line = 1700;

		// Token: 0x04000030 RID: 48
		public static int Opp_Forbidden_upline = -500;

		// Token: 0x04000031 RID: 49
		public static int Opp_Forbidden_downline = 500;

		// Token: 0x04000032 RID: 50
		public static int Goal_upline = -200;

		// Token: 0x04000033 RID: 51
		public static int Goal_downline = 200;

		// Token: 0x04000034 RID: 52
		public static int Goal_line = -2100;

		// Token: 0x04000035 RID: 53
		public static int Forbidden_line = -1700;

		// Token: 0x04000036 RID: 54
		public static int Forbidden_upline = -500;

		// Token: 0x04000037 RID: 55
		public static int Forbidden_downline = 500;

		// Token: 0x04000038 RID: 56
		public static int Fish_centertohead = 105;

		// Token: 0x04000039 RID: 57
		public static float Fish_length = 422.8f;

		// Token: 0x0400003A RID: 58
		public static int tail_width = 105;

		// Token: 0x0400003B RID: 59
		public static int Fins_width = 45;

		// Token: 0x0400003C RID: 60
		public static int Fishbody_width = 44;

		// Token: 0x0400003D RID: 61
		public static int Fishhead_Radius = 30;

		// Token: 0x0400003E RID: 62
		public static float tail_length = 64.8f;

		// Token: 0x0400003F RID: 63
		public static int Radius = 58;

		// Token: 0x04000040 RID: 64
		public static int PV = 1;

		// Token: 0x04000041 RID: 65
		public static double[] vTable = new double[]
		{
			0.0,
			9.02,
			31.55,
			60.4,
			88.35,
			110.66,
			132.78,
			152.16,
			172.9,
			204.65,
			268.52,
			289.33,
			295.66,
			293.99,
			303.69,
			314.51
		};

		// Token: 0x04000042 RID: 66
		public static double[] tTable = new double[]
		{
			-0.3552,
			-0.2921,
			-0.22,
			-0.1731,
			-0.1235,
			-0.0784,
			-0.0469,
			0.0,
			0.0469,
			0.0784,
			0.1235,
			0.1731,
			0.22,
			0.2921,
			0.3438,
			0.3438
		};

		// Token: 0x04000043 RID: 67
		public static double[,] abc = new double[16, 16];

		// Token: 0x04000044 RID: 68
		public static BaseAction BaAction;

		// Token: 0x04000045 RID: 69
		public static List<MyFishRobot> myFish = new List<MyFishRobot>();

		// Token: 0x04000046 RID: 70
		private static GlobalVar instance = null;

		// Token: 0x04000047 RID: 71
		public static GlobalVar.Balls[] yBall = new GlobalVar.Balls[9];

		// Token: 0x04000048 RID: 72
		public static int[] leftScore = new int[10];

		// Token: 0x04000049 RID: 73
		public static int[] rightScore = new int[10];

		// Token: 0x0400004A RID: 74
		public static int[] grab_flag_opp = new int[2];

		// Token: 0x0400004B RID: 75
		public static int[] grab_flag = new int[2];

		// Token: 0x0400004C RID: 76
		public static int[] byPass_flag = new int[2];

		// Token: 0x0400004D RID: 77
		public static int[] lanqiuFlag = new int[2];

		// Token: 0x0400004E RID: 78
		public static int[] boundary_dribbleact = new int[2];

		// Token: 0x0400004F RID: 79
		public static int[] leftScoreCopy = new int[10];

		// Token: 0x04000050 RID: 80
		public static int[] rightScoreCopy = new int[10];

		// Token: 0x04000051 RID: 81
		public static int YStage = 0;

		// Token: 0x04000052 RID: 82
		public static int[] interfereBallStage_Down = new int[2];

		// Token: 0x04000053 RID: 83
		public static int[] interfereBallStage_Up = new int[2];

		// Token: 0x04000054 RID: 84
		public static int[] interfereBallStage = new int[2];

		// Token: 0x04000055 RID: 85
		public static int n = 0;

		// Token: 0x04000056 RID: 86
		public static int final = 0;

		// Token: 0x04000057 RID: 87
		public static int finallanqiu = 0;

		// Token: 0x04000058 RID: 88
		public static int CQstage = 0;

		// Token: 0x04000059 RID: 89
		public static int[] deadjudge = new int[2];

		// Token: 0x0400005A RID: 90
		public static int deadtime0 = 0;

		// Token: 0x0400005B RID: 91
		public static int deadtime1 = 0;

		// Token: 0x0400005C RID: 92
		public static int locktime0 = 0;

		// Token: 0x0400005D RID: 93
		public static int locktime1 = 0;

		// Token: 0x0400005E RID: 94
		public static int[] dead = new int[2];

		// Token: 0x0400005F RID: 95
		public static int[] locked = new int[2];

		// Token: 0x04000060 RID: 96
		public static int[] youlockme = new int[2];

		// Token: 0x04000061 RID: 97
		public static int[] meaningless = new int[2];

		// Token: 0x04000062 RID: 98
		public static int[] danyujinqiu = new int[2];

		// Token: 0x04000063 RID: 99
		public static int[] corner = new int[2];

		// Token: 0x04000064 RID: 100
		public static int[] corner_help = new int[2];

		// Token: 0x04000065 RID: 101
		public static int[] warrior = new int[2];

		// Token: 0x04000066 RID: 102
		public static int[] danyuchujie = new int[2];

		// Token: 0x04000067 RID: 103
		public static int flag_duqiumen = 0;

		// Token: 0x04000068 RID: 104
		public static int back = 0;

		// Token: 0x04000069 RID: 105
		public static int gotoleft = 1;

		// Token: 0x0400006A RID: 106
		public static int UnarmedStage = 0;

		// Token: 0x0400006B RID: 107
		public static double[] enemyx0 = new double[25];

		// Token: 0x0400006C RID: 108
		public static double[] enemyz0 = new double[25];

		// Token: 0x0400006D RID: 109
		public static double[] enemydirection0 = new double[25];

		// Token: 0x0400006E RID: 110
		public static double[] enemyx1 = new double[25];

		// Token: 0x0400006F RID: 111
		public static double[] enemyz1 = new double[25];

		// Token: 0x04000070 RID: 112
		public static double[] enemydirection1 = new double[25];

		// Token: 0x04000071 RID: 113
		public static int UnarmedFish = 0;

		// Token: 0x04000072 RID: 114
		public static int[] UnarmedlastFlag = new int[2];

		// Token: 0x04000073 RID: 115
		public static int UnarmedFlag0 = 0;

		// Token: 0x04000074 RID: 116
		public static int UnarmedFlag1 = 0;

		// Token: 0x04000075 RID: 117
		public static int wy_emergency = 0;

		// Token: 0x04000076 RID: 118
		public static int wy_emergency_exe = 0;

		// Token: 0x04000077 RID: 119
		public static int escape_lanqiu = 0;

		// Token: 0x04000078 RID: 120
		public static double[,] test_to_twist_x = new double[2, 5];

		// Token: 0x04000079 RID: 121
		public static double[,] test_to_twist_z = new double[2, 5];

		// Token: 0x0400007A RID: 122
		public static double[,] test_to_twist_ballx = new double[2, 5];

		// Token: 0x0400007B RID: 123
		public static double[,] test_to_twist_ballz = new double[2, 5];

		// Token: 0x0400007C RID: 124
		public static double[,] differencial_x = new double[2, 5];

		// Token: 0x0400007D RID: 125
		public static double[,] differencial_z = new double[2, 5];

		// Token: 0x0400007E RID: 126
		public static int cnt = 0;

		// Token: 0x0400007F RID: 127
		public static double[,] recordfishz = new double[,]
		{
			{
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0
			},
			{
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0,
				500.0
			}
		};

		// Token: 0x04000080 RID: 128
		public static int GFY = 0;

		// Token: 0x04000081 RID: 129
		public static int[] zhuangtaibaochi_danyu = new int[2];

		// Token: 0x04000082 RID: 130
		public static int[] jiaoluobaiwei = new int[2];

		// Token: 0x04000083 RID: 131
		public static int[] liangqiutongchan = new int[2];

		// Token: 0x04000084 RID: 132
		public static int up_flag = 0;

		// Token: 0x04000085 RID: 133
		public static int[] chooseinterfereBallStage_Up = new int[2];

		// Token: 0x04000086 RID: 134
		public static int[] chooseinterfereBallStage = new int[2];

		// Token: 0x04000087 RID: 135
		public static int[] chooseinterfereBallStage_Down = new int[2];

		// Token: 0x04000088 RID: 136
		public static int[] enter_gate_stage = new int[2];

		// Token: 0x04000089 RID: 137
		public static double[,,] error_record = new double[9, 2, 1];

		// Token: 0x0400008A RID: 138
		public static int[,] errorflag = new int[9, 1];

		// Token: 0x0400008B RID: 139
		public static Point2D error = new Point2D(0.0, 0.0);

		// Token: 0x0400008C RID: 140
		public static int[] Bringing_BallID = new int[]
		{
			-1,
			-1
		};

		// Token: 0x0400008D RID: 141
		public static int[] willbring_ballid = new int[]
		{
			-1,
			-1
		};

		// Token: 0x0400008E RID: 142
		public static int[] SingleBringing_BallID = new int[2];

		// Token: 0x0400008F RID: 143
		public static GlobalVar.fish_mode[] prefish = new GlobalVar.fish_mode[2];

		// Token: 0x04000090 RID: 144
		public static bool[] is_ball_choosed = new bool[9];

		// Token: 0x04000091 RID: 145
		public static int[] whether_change_to_test3 = new int[2];

		// Token: 0x04000092 RID: 146
		public static int[] last2min_up_or_down = new int[]
		{
			1,
			-1
		};

		// Token: 0x04000093 RID: 147
		public static int[] last2min_is_in_200m = new int[2];

		// Token: 0x04000094 RID: 148
		public static int stage_zh = 0;

		// Token: 0x04000095 RID: 149
		public static int Stage = 0;

		// Token: 0x04000096 RID: 150
		public static int[] Circle_last2min_tag = new int[2];

		// Token: 0x04000097 RID: 151
		public static int[] Rescue_boundary_Zhuangtai = new int[2];

		// Token: 0x04000098 RID: 152
		public static int[] Rescue_boundary_Zhuangtai1 = new int[2];

		// Token: 0x04000099 RID: 153
		public static int[] Rescue_boundary_zt1 = new int[2];

		// Token: 0x0400009A RID: 154
		public static int[] Rescue_boundary_zt2 = new int[2];

		// Token: 0x0400009B RID: 155
		public static int[] Rescue_boundary_tail = new int[2];

		// Token: 0x0400009C RID: 156
		public static int[] Dribble_boundaryf_zt1 = new int[]
		{
			100,
			100
		};

		// Token: 0x0400009D RID: 157
		public static int[] Dribble_boundaryf_zt2 = new int[]
		{
			100,
			100
		};

		// Token: 0x0400009E RID: 158
		public static int[] Dribbleboundary_zt1 = new int[2];

		// Token: 0x0400009F RID: 159
		public static int[] Dribbleboundary_zt2 = new int[2];

		// Token: 0x040000A0 RID: 160
		public static int[] Rescue_boundaryact_sign = new int[2];

		// Token: 0x040000A1 RID: 161
		public static bool[] is_ZKs_rescure_end = new bool[2];

		// Token: 0x040000A2 RID: 162
		public static int[] Jinqiu_Rescue = new int[2];

		// Token: 0x040000A3 RID: 163
		public static int DStage = 0;

		// Token: 0x040000A4 RID: 164
		public static int buffle_flag = 0;

		// Token: 0x040000A5 RID: 165
		public static int b0_l;

		// Token: 0x040000A6 RID: 166
		public static int b1_l;

		// Token: 0x040000A7 RID: 167
		public static int b2_l;

		// Token: 0x040000A8 RID: 168
		public static int b3_l;

		// Token: 0x040000A9 RID: 169
		public static int b4_l;

		// Token: 0x040000AA RID: 170
		public static int b5_l;

		// Token: 0x040000AB RID: 171
		public static int b6_l;

		// Token: 0x040000AC RID: 172
		public static int b7_l;

		// Token: 0x040000AD RID: 173
		public static int b8_l;

		// Token: 0x040000AE RID: 174
		public static int b0_r;

		// Token: 0x040000AF RID: 175
		public static int b1_r;

		// Token: 0x040000B0 RID: 176
		public static int b2_r;

		// Token: 0x040000B1 RID: 177
		public static int b3_r;

		// Token: 0x040000B2 RID: 178
		public static int b4_r;

		// Token: 0x040000B3 RID: 179
		public static int b5_r;

		// Token: 0x040000B4 RID: 180
		public static int b6_r;

		// Token: 0x040000B5 RID: 181
		public static int b7_r;

		// Token: 0x040000B6 RID: 182
		public static int b8_r;

		// Token: 0x040000B7 RID: 183
		public static double[,] jimiao = new double[9, 5];

		// 避障相关变量
		public static int[] detour_stage = new int[2];  // 绕行阶段：0=正常，1=绕行中
		public static int[] detour_target_opp = new int[2];  // 正在绕行的对手ID

		// 边界挑球相关变量
		public static int[] flick_ball_cooldown = new int[2];  // 挑球冷却时间（回合数）
		public static int[] flick_ball_stage = new int[2];  // 挑球阶段：0=正常，1=挑球中
		public static int[] stalemate_timer = new int[2];  // 僵持计时器（回合数）

		// Token: 0x0200000A RID: 10
		public struct Balls
		{
			// Token: 0x040000D7 RID: 215
			internal double X;

			// Token: 0x040000D8 RID: 216
			internal double Z;
		}

		// Token: 0x0200000B RID: 11
		public struct fish_mode
		{
			// Token: 0x040000D9 RID: 217
			public double prex;

			// Token: 0x040000DA RID: 218
			public double prez;

			// Token: 0x040000DB RID: 219
			public int preVcode;

			// Token: 0x040000DC RID: 220
			public int preTcode;

			// Token: 0x040000DD RID: 221
			public double predirection;
		}
	}
}
