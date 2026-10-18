using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Xna.Framework;
using URWPGSim2D.Common;
using URWPGSim2D.StrategyLoader;
using System.Globalization;
using FrameDiagnostics;

namespace URWPGSim2D.Strategy
{
	// Token: 0x02000008 RID: 8
	public class Strategy : MarshalByRefObject, IStrategy
	{
		private static FrameLogger _diagLogger;
		private static int _diagLastRemaining = -1;
		private static readonly string[] DiagFields = new[] { "cycle", "fish_id", "paishu", "vcode", "tcode", "x", "z", "body_dir", "ball_id", "score_left" };

		// Token: 0x02000008 RID: 8
		public override object InitializeLifetimeService()
		{
			return null;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00021F7C File Offset: 0x0002017C
		~Strategy()
		{
			bool flag = GlobalVar.teamId == 0;
			string path;
			if (flag)
			{
				path = "debugtxtleft.txt";
			}
			else
			{
				path = "debugtxtrigh.txt";
			}
			StreamWriter streamWriter = new StreamWriter(path, false, Encoding.GetEncoding("gb2312"));
			for (int i = 0; i < DebugRecord.strRecord.Count; i++)
			{
				streamWriter.WriteLine(DebugRecord.strRecord[i]);
			}
			streamWriter.Flush();
			streamWriter.Close();
		}

		// Token: 0x0600008F RID: 143 RVA: 0x00022018 File Offset: 0x00020218
		public string GetTeamName()
		{
			return "GrabBall Dilemma";
		}

		// Token: 0x06000090 RID: 144 RVA: 0x00022030 File Offset: 0x00020230
		public Decision[] GetDecision(Mission mission, int teamId)
		{
			try { EnsureDiagnostics(mission, teamId); } catch { }
			bool flag = this.decisions == null;
			if (flag)
			{
				this.decisions = new Decision[mission.CommonPara.FishCntPerTeam];
			}
			GlobalVar.mission = mission;
			GlobalVar.MyTeam = mission.TeamsRef[teamId];
			GlobalVar.OppTeam = mission.TeamsRef[(teamId + 1) % 2];
			GlobalVar.balls[0] = mission.EnvRef.Balls[0];
			GlobalVar.balls[1] = mission.EnvRef.Balls[1];
			GlobalVar.balls[2] = mission.EnvRef.Balls[2];
			GlobalVar.balls[3] = mission.EnvRef.Balls[3];
			GlobalVar.balls[4] = mission.EnvRef.Balls[4];
			GlobalVar.balls[5] = mission.EnvRef.Balls[5];
			GlobalVar.balls[6] = mission.EnvRef.Balls[6];
			GlobalVar.balls[7] = mission.EnvRef.Balls[7];
			GlobalVar.balls[8] = mission.EnvRef.Balls[8];
			GlobalVar.decisions = this.decisions;
			bool flag2 = GlobalVar.Paishu == 0;
			if (flag2)
			{
				GlobalVar.Init();
			}
			GlobalVar.oppTeamId = (teamId + 1) % 2;
			GlobalVar.teamId = teamId;
			GlobalVar.Paishu++;
			bool flag3 = GlobalVar.Paishu == 1;
			if (flag3)
			{
				GlobalVar.MyTeamLast = mission.TeamsRef[teamId];
			}
			List<RoboFish> fishes = GlobalVar.MyTeam.Fishes;
			double pi = GlobalVar.PI;
			for (int i = 0; i < 2; i++)
			{
				GlobalVar.decisions[i].VCode = 0;
				GlobalVar.decisions[i].TCode = 7;
			}
			double[,] array = new double[2, 2];
			double[,] array2 = new double[2, 2];
			double[,] array3 = new double[9, 2];
			for (int j = 0; j < 2; j++)
			{
				array[j, 0] = (double)GlobalVar.MyTeam.Fishes[j].PositionMm.X;
				array[j, 1] = (double)GlobalVar.MyTeam.Fishes[j].PositionMm.Z;
				array2[j, 0] = (double)GlobalVar.MyTeam.Fishes[j].PolygonVertices[j].X;
				array2[j, 1] = (double)GlobalVar.MyTeam.Fishes[j].PolygonVertices[j].Z;
			}
			for (int k = 0; k < 9; k++)
			{
				array3[k, 0] = (double)GlobalVar.mission.EnvRef.Balls[k].PositionMm.X;
				array3[k, 1] = (double)GlobalVar.mission.EnvRef.Balls[k].PositionMm.Z;
			}
			int num = Convert.ToInt32(mission.HtMissionVariables["CompetitionPeriod"]);
			int num2 = 5999 - mission.CommonPara.RemainingCycles;
			bool flag4 = GlobalVar.Stage == 4;
			if (flag4)
			{
				GlobalVar.Stage = 0;
			}
			GlobalVar.b0_l = Convert.ToInt32(mission.HtMissionVariables["Ball_0_Left_Status"]);
			GlobalVar.b1_l = Convert.ToInt32(mission.HtMissionVariables["Ball_1_Left_Status"]);
			GlobalVar.b2_l = Convert.ToInt32(mission.HtMissionVariables["Ball_2_Left_Status"]);
			GlobalVar.b3_l = Convert.ToInt32(mission.HtMissionVariables["Ball_3_Left_Status"]);
			GlobalVar.b4_l = Convert.ToInt32(mission.HtMissionVariables["Ball_4_Left_Status"]);
			GlobalVar.b5_l = Convert.ToInt32(mission.HtMissionVariables["Ball_5_Left_Status"]);
			GlobalVar.b6_l = Convert.ToInt32(mission.HtMissionVariables["Ball_6_Left_Status"]);
			GlobalVar.b7_l = Convert.ToInt32(mission.HtMissionVariables["Ball_7_Left_Status"]);
			GlobalVar.b8_l = Convert.ToInt32(mission.HtMissionVariables["Ball_8_Left_Status"]);
			GlobalVar.b0_r = Convert.ToInt32(mission.HtMissionVariables["Ball_0_Right_Status"]);
			GlobalVar.b1_r = Convert.ToInt32(mission.HtMissionVariables["Ball_1_Right_Status"]);
			GlobalVar.b2_r = Convert.ToInt32(mission.HtMissionVariables["Ball_2_Right_Status"]);
			GlobalVar.b3_r = Convert.ToInt32(mission.HtMissionVariables["Ball_3_Right_Status"]);
			GlobalVar.b4_r = Convert.ToInt32(mission.HtMissionVariables["Ball_4_Right_Status"]);
			GlobalVar.b5_r = Convert.ToInt32(mission.HtMissionVariables["Ball_5_Right_Status"]);
			GlobalVar.b6_r = Convert.ToInt32(mission.HtMissionVariables["Ball_6_Right_Status"]);
			GlobalVar.b7_r = Convert.ToInt32(mission.HtMissionVariables["Ball_7_Right_Status"]);
			GlobalVar.b8_r = Convert.ToInt32(mission.HtMissionVariables["Ball_8_Right_Status"]);
			GlobalVar.leftScore[0] = GlobalVar.b0_l;
			GlobalVar.leftScore[1] = GlobalVar.b1_l;
			GlobalVar.leftScore[2] = GlobalVar.b2_l;
			GlobalVar.leftScore[3] = GlobalVar.b3_l;
			GlobalVar.leftScore[4] = GlobalVar.b4_l;
			GlobalVar.leftScore[5] = GlobalVar.b5_l;
			GlobalVar.leftScore[6] = GlobalVar.b6_l;
			GlobalVar.leftScore[7] = GlobalVar.b7_l;
			GlobalVar.leftScore[8] = GlobalVar.b8_l;
			GlobalVar.rightScore[0] = GlobalVar.b0_r;
			GlobalVar.rightScore[1] = GlobalVar.b1_r;
			GlobalVar.rightScore[2] = GlobalVar.b2_r;
			GlobalVar.rightScore[3] = GlobalVar.b3_r;
			GlobalVar.rightScore[4] = GlobalVar.b4_r;
			GlobalVar.rightScore[5] = GlobalVar.b5_r;
			GlobalVar.rightScore[6] = GlobalVar.b6_r;
			GlobalVar.rightScore[7] = GlobalVar.b7_r;
			GlobalVar.rightScore[8] = GlobalVar.b8_r;
			bool flag5 = num2 == 2998;
			if (flag5)
			{
				for (int l = 0; l < 9; l++)
				{
					GlobalVar.leftScoreCopy[l] = GlobalVar.rightScore[l];
					GlobalVar.rightScoreCopy[l] = GlobalVar.leftScore[l];
				}
			}
			bool flag6 = num2 == 3000;
			if (flag6)
			{
				for (int m = 0; m < 9; m++)
				{
					GlobalVar.leftScore[m] = GlobalVar.leftScoreCopy[m];
					GlobalVar.rightScore[m] = GlobalVar.rightScoreCopy[m];
				}
			}
			this.RightToLeft();
			DebugRecord.ceshi(12, "teamID", (float)GlobalVar.teamId);
			int num3 = GlobalVar.Bringing_BallID[0];
			int num4 = GlobalVar.Bringing_BallID[1];
			int num5 = GlobalVar.BaAction.num_of_ball_in_mysmall(true, true);
			int num6 = num5 + GlobalVar.MyTeam.Para.Score;
			int num7 = GlobalVar.BaAction.num_of_ball_in_mysmall(true, false);
			DebugRecord.ceshi(8, "myballnoin", (float)num7);
			int score = GlobalVar.MyTeam.Para.Score;
			DebugRecord.ceshi(8, "myscore_yide", (float)score);
			DebugRecord.ceshi(8, "myscoresmall,myscoreall", (float)num5, (float)num6);
			int num8 = num7;
			int num9 = GlobalVar.BaAction.num_of_ball_in_mybig(false, true);
			int num10 = GlobalVar.BaAction.num_of_ball_in_oppbig(true, true);
			int num11 = GlobalVar.BaAction.num_of_ball_in_oppsmall(true, true);
			int num12 = GlobalVar.BaAction.num_of_ball_in_oppbig(false, true) + num10;
			DebugRecord.ceshi(8, "oppscoreall", (float)num12);
			int num13 = GlobalVar.BaAction.num_of_ball_in_oppbig(false, true) + num11;
			double location_x = (double)GlobalVar.MyTeam.Fishes[0].PositionMm.X;
			double location_z = (double)GlobalVar.MyTeam.Fishes[0].PositionMm.Z;
			double location_x2 = (double)GlobalVar.MyTeam.Fishes[1].PositionMm.X;
			double location_z2 = (double)GlobalVar.MyTeam.Fishes[1].PositionMm.Z;
			double num14 = (double)GlobalVar.MyTeam.Fishes[0].VelocityMmPs;
			double num15 = (double)GlobalVar.MyTeam.Fishes[1].VelocityMmPs;
			double num16 = (double)GlobalVar.MyTeam.Fishes[0].AngularVelocityRadPs;
			double num17 = (double)GlobalVar.OppTeam.Fishes[0].PositionMm.X;
			double num18 = (double)GlobalVar.OppTeam.Fishes[0].PositionMm.Z;
			double num19 = (double)GlobalVar.OppTeam.Fishes[1].PositionMm.X;
			double num20 = (double)GlobalVar.OppTeam.Fishes[1].PositionMm.Z;
			int num21 = GlobalVar.BaAction.num_of_ball_in_oppmiddle(true, false);
			int num22 = GlobalVar.BaAction.num_of_ball_in_oppmiddle(false, false) + num21;
			DebugRecord.ceshi(8, "oppballnum,oppballnumall", (float)num21, (float)num22);
			double num23 = (double)GlobalVar.MyTeam.Fishes[1].AngularVelocityRadPs;
			bool flag7 = num7 < 0;
			if (flag7)
			{
				num7 = 0;
			}
			bool flag8 = teamId == 0;
			if (flag8)
			{
				bool flag9 = GlobalVar.balls[6].PositionMm.X < -1300f && Math.Abs(GlobalVar.balls[6].PositionMm.Z) > 800f;
				if (flag9)
				{
					num8++;
					num6++;
				}
				bool flag10 = GlobalVar.balls[3].PositionMm.X < -1300f && Math.Abs(GlobalVar.balls[3].PositionMm.Z) > 800f;
				if (flag10)
				{
					num8++;
					num6++;
				}
			}
			else
			{
				bool flag11 = GlobalVar.balls[4].PositionMm.X < -1300f && Math.Abs(GlobalVar.balls[4].PositionMm.Z) > 800f;
				if (flag11)
				{
					num8++;
					num6++;
				}
				bool flag12 = GlobalVar.balls[5].PositionMm.X < -1300f && Math.Abs(GlobalVar.balls[5].PositionMm.Z) > 800f;
				if (flag12)
				{
					num8++;
					num6++;
				}
			}
			int num24 = 17 - num12 - num6;
			int num25 = 17 - num13 - num6;
			DebugRecord.ceshi(0, "myscoresmall,myscoreall", (float)num5, (float)num6);
			DebugRecord.ceshi(8, "myballnoinbig", (float)num8);
			GlobalVar.flag_duqiumen = GlobalVar.BaAction.whether_duqiumen();
			DebugRecord.ceshi(0, "是否堵球门", (float)GlobalVar.flag_duqiumen);
			int num26 = 20;
			GlobalVar.enemyx0[GlobalVar.Paishu % num26] = (double)GlobalVar.OppTeam.Fishes[0].PositionMm.X;
			GlobalVar.enemyz0[GlobalVar.Paishu % num26] = (double)GlobalVar.OppTeam.Fishes[0].PositionMm.Z;
			GlobalVar.enemyx1[GlobalVar.Paishu % num26] = (double)GlobalVar.OppTeam.Fishes[1].PositionMm.X;
			GlobalVar.enemyz1[GlobalVar.Paishu % num26] = (double)GlobalVar.OppTeam.Fishes[1].PositionMm.Z;
			GlobalVar.enemydirection0[GlobalVar.Paishu % num26] = (double)GlobalVar.OppTeam.Fishes[0].BodyDirectionRad;
			GlobalVar.enemydirection1[GlobalVar.Paishu % num26] = (double)GlobalVar.OppTeam.Fishes[1].BodyDirectionRad;
			DebugRecord.ceshi(3, "0球", (float)GlobalVar.leftScore[0]);
			DebugRecord.ceshi(3, "1球", (float)GlobalVar.leftScore[1]);
			DebugRecord.ceshi(3, "2球", (float)GlobalVar.leftScore[2]);
			DebugRecord.ceshi(3, "3球", (float)GlobalVar.leftScore[3]);
			DebugRecord.ceshi(3, "4球", (float)GlobalVar.leftScore[4]);
			DebugRecord.ceshi(3, "5球", (float)GlobalVar.leftScore[5]);
			DebugRecord.ceshi(3, "6球", (float)GlobalVar.leftScore[6]);
			DebugRecord.ceshi(3, "7球", (float)GlobalVar.leftScore[7]);
			
			// 全局策略：计算己方大禁区内所有球的总分（包括已得分的球）（大禁区定义：x < -952）
			int bigAreaTotalScore = 0;
			for (int ballIdx = 0; ballIdx < 9; ballIdx++)
			{
				bool inBigArea = GlobalVar.BaAction.whether_in_myforbiddenareabig((double)GlobalVar.balls[ballIdx].PositionMm.X);
				if (inBigArea)
				{
					if (ballIdx == 0 || ballIdx == 1 || ballIdx == 2)
						bigAreaTotalScore += 3;
					else if (ballIdx == 7 || ballIdx == 8)
						bigAreaTotalScore += 2;
					else
						bigAreaTotalScore += 1;
				}
			}
			DebugRecord.ceshi(0, "大禁区内球总分", (float)bigAreaTotalScore);
			
			// 如果大禁区内球总分>8，两条鱼都回禁区将球运进框
			bool flag12_5 = bigAreaTotalScore > 8;
			if (flag12_5)
			{
				DebugRecord.ceshi(0, "大禁区球总分>8，两鱼将球运进框（高分优先）");
				
				// 按优先级排序：3分球(0,1,2) > 2分球(7,8) > 1分球(3,4,5,6)
				int[] priorityOrder = new int[] { 0, 1, 2, 7, 8, 3, 4, 5, 6 };
				int ball0 = -1;
				int ball1 = -1;
				
				// 为0号鱼选择最高分的大禁区球
				for (int i = 0; i < priorityOrder.Length; i++)
				{
					int ballIdx = priorityOrder[i];
					bool inBigArea = GlobalVar.BaAction.whether_in_myforbiddenareabig((double)GlobalVar.balls[ballIdx].PositionMm.X) && GlobalVar.leftScore[ballIdx] != 1;
					if (inBigArea)
					{
						ball0 = ballIdx;
						break;
					}
				}
				
				// 为1号鱼选择次高分的大禁区球（不能和0号鱼重复）
				for (int i = 0; i < priorityOrder.Length; i++)
				{
					int ballIdx = priorityOrder[i];
					bool inBigArea = GlobalVar.BaAction.whether_in_myforbiddenareabig((double)GlobalVar.balls[ballIdx].PositionMm.X) && GlobalVar.leftScore[ballIdx] != 1;
					if (inBigArea && ballIdx != ball0)
					{
						ball1 = ballIdx;
						break;
					}
				}
				
				num3 = ball0;
				num4 = ball1;
				
				bool flag12_6 = num3 != -1;
				if (flag12_6)
				{
					GlobalVar.BaAction.the_warrior2(0, num3);
					DebugRecord.ceshi(5, "0号鱼将大禁区球推进框");
				}
				else
				{
					GlobalVar.BaAction.chanqiuqubahaizi(0);
					DebugRecord.ceshi(5, "0号鱼大禁区无球可选");
				}
				
				bool flag12_7 = num4 != -1;
				if (flag12_7)
				{
					GlobalVar.BaAction.the_warrior2(1, num4);
					DebugRecord.ceshi(5, "1号鱼将大禁区球推进框");
				}
				else
				{
					GlobalVar.BaAction.chanqiuqubahaizi(1);
					DebugRecord.ceshi(5, "1号鱼大禁区无球可选");
				}
				
				// 执行完后直接返回，不执行后续策略
				bool flag12_8 = num16 < 0.08 && num14 < 20.0 && GlobalVar.finallanqiu == 0;
				if (flag12_8)
				{
					GlobalVar.decisions[0].VCode = 12;
				}
				bool flag12_9 = num23 < 0.08 && num15 < 20.0 && GlobalVar.finallanqiu == 0;
				if (flag12_9)
				{
					GlobalVar.decisions[1].VCode = 12;
				}
				GlobalVar.MyTeamLast = mission.TeamsRef[teamId];
DebugRecord.RecordBaseInfomation(mission, teamId, this.decisions);
				WriteDiagFrame(mission, teamId);
				return this.decisions;
			}
			
			bool flag13 = GlobalVar.flag_duqiumen == 1;
			if (flag13)
			{
				bool flag14 = num3 == -1 || (GlobalVar.Paishu < 3000 && GlobalVar.leftScore[num3] == 1) || GlobalVar.Paishu >= 3000;
				if (flag14)
				{
					num3 = GlobalVar.BaAction.ChoseBall_for_duqiumen(0);
					DebugRecord.ceshi(0, "0号鱼堵球门重新选球");
				}
				bool flag15 = num4 == -1 || (GlobalVar.Paishu < 3000 && GlobalVar.leftScore[num4] == 1) || GlobalVar.Paishu >= 3000;
				if (flag15)
				{
					num4 = GlobalVar.BaAction.ChoseBall_for_duqiumen(1);
					DebugRecord.ceshi(0, "1号鱼堵球门重新选球");
				}
			}
			// flag16: 非final阶段 或 堵球门 或 (final阶段但分数不够高)
			bool flag16 = GlobalVar.final == 0 || GlobalVar.flag_duqiumen == 1 || (GlobalVar.final == 1 && num5 <= 8 && num6 <= 10);
			if (flag16)
			{
				bool flag17 = GlobalVar.flag_duqiumen != 1;
				if (flag17)
			{
					// 3002-3080特殊期策略（5分-5分13秒）
					bool isSpecialPeriod = num2 >= 3002 && num2 <= 3080;
					if (isSpecialPeriod)
					{
						// 计算己方半场球的总分（排除已得分的球）
						int myHalfScore = 0;
						for (int ballIdx = 0; ballIdx < 9; ballIdx++)
						{
							bool inMyHalf = GlobalVar.balls[ballIdx].PositionMm.X < 0f && GlobalVar.leftScore[ballIdx] != 1;
							if (inMyHalf)
							{
								if (ballIdx == 0 || ballIdx == 1 || ballIdx == 2)
									myHalfScore += 3; // 0-2号球是3分
								else if (ballIdx == 7 || ballIdx == 8)
									myHalfScore += 2; // 7-8号球是2分
								else
									myHalfScore += 1; // 3-6号球是1分
							}
						}
						
						// 计算对方半场球的总分（排除已得分的球）
						int oppHalfScore = 0;
						for (int ballIdx = 0; ballIdx < 9; ballIdx++)
						{
							bool inOppHalf = GlobalVar.balls[ballIdx].PositionMm.X > 0f && GlobalVar.leftScore[ballIdx] != 1;
							if (inOppHalf)
							{
								if (ballIdx == 0 || ballIdx == 1 || ballIdx == 2)
									oppHalfScore += 3; // 0-2号球是3分
								else if (ballIdx == 7 || ballIdx == 8)
									oppHalfScore += 2; // 7-8号球是2分
								else
									oppHalfScore += 1; // 3-6号球是1分
							}
						}
						
						DebugRecord.ceshi(0, "特殊期：己方半场球总分", (float)myHalfScore);
						DebugRecord.ceshi(0, "特殊期：对方半场球总分", (float)oppHalfScore);
						
						// 判断策略：己方半场分数+3 < 对方半场分数
						if (myHalfScore + 3 < oppHalfScore)
						{
							// 两条鱼都选对方半场球
							num3 = GlobalVar.BaAction.ChoseBall_OppHalf(0);
							num4 = GlobalVar.BaAction.ChoseBall_OppHalf(1);
							DebugRecord.ceshi(0, "特殊期：己方+3<对方，两鱼选对方半场");
						}
						else if (myHalfScore < oppHalfScore)
						{
							// 己方分数 < 对方分数（但不满足+3条件）
							// 0号鱼选对方半场，1号鱼正常选球
							num3 = GlobalVar.BaAction.ChoseBall_OppHalf(0);
							num4 = GlobalVar.BaAction.ChoseBall20(1);
							DebugRecord.ceshi(0, "特殊期：己方<对方，0号选对方半场，1号正常");
						}
						else
						{
							// 己方分数 >= 对方分数，正常选球
							num3 = GlobalVar.BaAction.ChoseBall20(0);
							num4 = GlobalVar.BaAction.ChoseBall20(1);
							DebugRecord.ceshi(0, "特殊期：己方>=对方，正常选球");
						}
					}
					else
					{
						num3 = GlobalVar.BaAction.ChoseBall20(0);
						num4 = GlobalVar.BaAction.ChoseBall20(1);
						DebugRecord.ceshi(0, "0，1号鱼重新选球");
					}
				DebugRecord.ceshi(0, "ballId2--nof", (float)num4);
				DebugRecord.ceshi(12, "bringballId1--nof", (float)GlobalVar.Bringing_BallID[0]);
				DebugRecord.ceshi(12, "bringballId2--nof", (float)GlobalVar.Bringing_BallID[1]);
				bool flag18 = num3 != -1;
				if (flag18)
				{
					int num27 = 0;
					bool flag19 = GlobalVar.BaAction.whether_CornerChoseBall((double)GlobalVar.balls[num3].PositionMm.X, (double)GlobalVar.balls[num3].PositionMm.Z) == 1 || GlobalVar.chooseinterfereBallStage_Up[num27] == 1;
					if (flag19)
					{
						GlobalVar.BaAction.chosecornerInterfereBall(num27, 1);
						DebugRecord.ceshi(5, "chosecornerInterfereBall(0, 1)--nof");
					}
					else
					{
						bool flag20 = GlobalVar.BaAction.whether_CornerChoseBall((double)GlobalVar.balls[num3].PositionMm.X, (double)GlobalVar.balls[num3].PositionMm.Z) == 2 || GlobalVar.chooseinterfereBallStage_Down[num27] == 1;
						if (flag20)
						{
							GlobalVar.BaAction.chosecornerInterfereBall(num27, 0);
							DebugRecord.ceshi(5, "chosecornerInterfereBall(0, 0)--nof");
						}
						else
						{
							bool flag21 = num3 == 2;
							if (flag21)
							{
								double num28 = (double)GlobalVar.mission.EnvRef.Balls[2].PositionMm.X;
								double num29 = (double)GlobalVar.mission.EnvRef.Balls[2].PositionMm.Z;
								double num30 = (double)GlobalVar.MyTeam.Fishes[0].PolygonVertices[0].X;
								double z = (double)GlobalVar.MyTeam.Fishes[0].PolygonVertices[0].Z;
								bool flag22 = teamId == 1;
								int num31;
								if (flag22)
								{
									num31 = -1;
								}
								else
								{
									num31 = 1;
								}
								bool flag23 = num30 < num28 && Compute.GetDistance(num28, num29, num30, z) > 150.0 && num2 < 100;
								if (flag23)
								{
									GlobalVar.BaAction.Position(0, num28 + (double)(num31 * 100), num29 + (double)(num31 * 100), 350.0);
								}
								else
								{
									GlobalVar.BaAction.Dribblehometest1(0, num3);
									DebugRecord.ceshi(5, "Dribblehometest1(0, ballid1)--nof");
								}
							}
							else
							{
								GlobalVar.BaAction.Dribblehometest1(0, num3);
								DebugRecord.ceshi(5, "Dribblehometest1(0, ballid1)--nof2");
							}
						}
					}
				}
				else
				{
					GlobalVar.BaAction.chanqiuqubahaizi(0);
					DebugRecord.ceshi(5, "chanqiuqubahaizi(0)--nof");
				}
				bool flag24 = num4 != -1;
				if (flag24)
				{
					int num32 = 1;
					bool flag25 = GlobalVar.BaAction.whether_CornerChoseBall((double)GlobalVar.balls[num4].PositionMm.X, (double)GlobalVar.balls[num4].PositionMm.Z) == 1 || GlobalVar.chooseinterfereBallStage_Up[num32] == 1;
					if (flag25)
					{
						GlobalVar.BaAction.chosecornerInterfereBall(num32, 1);
						DebugRecord.ceshi(5, "chosecornerInterfereBall(1, 1)--nof");
					}
					else
					{
						bool flag26 = GlobalVar.BaAction.whether_CornerChoseBall((double)GlobalVar.balls[num4].PositionMm.X, (double)GlobalVar.balls[num4].PositionMm.Z) == 2 || GlobalVar.chooseinterfereBallStage_Down[num32] == 1;
						if (flag26)
						{
							GlobalVar.BaAction.chosecornerInterfereBall(num32, 0);
							DebugRecord.ceshi(5, "chosecornerInterfereBall(1, 0)--nof");
						}
						else
						{
							bool flag27 = num4 == 0;
							if (flag27)
							{
								double num33 = (double)GlobalVar.mission.EnvRef.Balls[0].PositionMm.X;
								double num34 = (double)GlobalVar.mission.EnvRef.Balls[0].PositionMm.Z;
								double num35 = (double)GlobalVar.MyTeam.Fishes[1].PolygonVertices[0].X;
								double z2 = (double)GlobalVar.MyTeam.Fishes[1].PolygonVertices[0].Z;
								bool flag28 = teamId == 1;
								int num36;
								if (flag28)
								{
									num36 = -1;
								}
								else
								{
									num36 = 1;
								}
								bool flag29 = num35 < num33 && Compute.GetDistance(num33, num34, num35, z2) > 150.0 && num2 < 100;
								if (flag29)
								{
									GlobalVar.BaAction.Position(1, num33 + (double)(num36 * 100), num34 - (double)(num36 * 100), 350.0);
								}
								else
								{
									GlobalVar.BaAction.Dribblehometest1(1, num4);
									DebugRecord.ceshi(5, "Dribblehometest1(1, ballid2)--nof");
								}
							}
							else
							{
								GlobalVar.BaAction.Dribblehometest1(1, num4);
								DebugRecord.ceshi(5, "Dribblehometest1(1, ballid2)--nof2");
							}
						}
					}
				}
				else
				{
					GlobalVar.BaAction.chanqiuqubahaizi(1);
					DebugRecord.ceshi(5, "chanqiuqubahaizi(1)--nof");
				}
				}
			}
			bool flag30 = GlobalVar.flag_duqiumen == 0;
			if (flag30)
			{
				DebugRecord.ceshi(12, "finallanqiu", (float)GlobalVar.finallanqiu);
				bool flag31 = GlobalVar.Paishu == 2999 || GlobalVar.Paishu == 3000;
				if (flag31)
				{
					GlobalVar.final = 1;
					GlobalVar.CQstage = 0;
					GlobalVar.lanqiuFlag[0] = 0;
					GlobalVar.lanqiuFlag[1] = 0;
					GlobalVar.Bringing_BallID[0] = -1;
					GlobalVar.Bringing_BallID[1] = -1;
					GlobalVar.escape_lanqiu = 0;
					DebugRecord.ceshi(9, "final=1");
				}
				bool flag32 = GlobalVar.Paishu < 2999 && GlobalVar.Paishu > 2300 && GlobalVar.finallanqiu == 0;
				if (flag32)
				{
					GlobalVar.lanqiuFlag[0] = 1;
					GlobalVar.lanqiuFlag[1] = 1;
					DebugRecord.ceshi(9, "1");
				}
				bool flag33 = GlobalVar.Paishu > 3010 && GlobalVar.finallanqiu == 0;
				if (flag33)
				{
					GlobalVar.lanqiuFlag[0] = 1;
					GlobalVar.lanqiuFlag[1] = 1;
					DebugRecord.ceshi(9, "2");
				}
				bool flag34 = score >= 9;
				if (flag34)
				{
					GlobalVar.CQstage = 1;
				}
				
				// 🆕 8分钟后（Paishu >= 4800）且己方半场球都已得分，优先抢夺对方未得分的球
				bool flag34_new = GlobalVar.Paishu >= 4800;
				if (flag34_new)
				{
					// 检查己方半场是否还有未得分的球
					int myHalfUnscoredBalls = 0;
					for (int ballIdx = 0; ballIdx < 9; ballIdx++)
					{
						bool inMyHalf = GlobalVar.balls[ballIdx].PositionMm.X < 0f && GlobalVar.leftScore[ballIdx] != 1;
						if (inMyHalf)
						{
							myHalfUnscoredBalls++;
						}
					}
					
					DebugRecord.ceshi(0, "8分钟后己方半场未得分球数", (float)myHalfUnscoredBalls);
					
					// 如果己方半场球都已得分，抢夺对方未得分的球
					bool flag34_new2 = myHalfUnscoredBalls == 0;
					if (flag34_new2)
					{
						DebugRecord.ceshi(0, "8分钟后己方半场已清空，抢夺对方球");
						
						// 按优先级排序：3分球(0,1,2) > 2分球(7,8) > 1分球(3,4,5,6)
						int[] priorityOrder = new int[] { 0, 1, 2, 7, 8, 3, 4, 5, 6 };
						int ball0 = -1;
						int ball1 = -1;
						
						// 为0号鱼选择最高分的对方未得分球
						for (int i = 0; i < priorityOrder.Length; i++)
						{
							int ballIdx = priorityOrder[i];
							// 检查球是否未得分（不限制位置）
							bool isUnscored = GlobalVar.leftScore[ballIdx] != 1;
							if (isUnscored)
							{
								ball0 = ballIdx;
								break;
							}
						}
						
						// 为1号鱼选择次高分的对方未得分球（不能和0号鱼重复）
						for (int i = 0; i < priorityOrder.Length; i++)
						{
							int ballIdx = priorityOrder[i];
							bool isUnscored = GlobalVar.leftScore[ballIdx] != 1 && ballIdx != ball0;
							if (isUnscored)
							{
								ball1 = ballIdx;
								break;
							}
						}
						
						num3 = ball0;
						num4 = ball1;
						
						bool flag34_new3 = num3 != -1;
						if (flag34_new3)
						{
							// 判断球的位置，选择合适的策略
							bool inOppBigArea = GlobalVar.BaAction.whether_in_oppforbiddenareabig((double)GlobalVar.balls[num3].PositionMm.X, (double)GlobalVar.balls[num3].PositionMm.Z);
							if (inOppBigArea)
							{
								// 球在对方禁区，直接抢夺
								GlobalVar.BaAction.Dribblehometest1(0, num3);
								DebugRecord.ceshi(5, "8分钟后0号鱼抢夺对方禁区球", (float)num3);
							}
							else
							{
								// 球不在对方禁区，运回己方
								GlobalVar.BaAction.Dribblehometest1(0, num3);
								DebugRecord.ceshi(5, "8分钟后0号鱼抢夺对方球", (float)num3);
							}
						}
						else
						{
							GlobalVar.BaAction.chanqiuqubahaizi(0);
							DebugRecord.ceshi(5, "8分钟后0号鱼无球可抢");
						}
						
						bool flag34_new4 = num4 != -1;
						if (flag34_new4)
						{
							bool inOppBigArea = GlobalVar.BaAction.whether_in_oppforbiddenareabig((double)GlobalVar.balls[num4].PositionMm.X, (double)GlobalVar.balls[num4].PositionMm.Z);
							if (inOppBigArea)
							{
								GlobalVar.BaAction.Dribblehometest1(1, num4);
								DebugRecord.ceshi(5, "8分钟后1号鱼抢夺对方禁区球", (float)num4);
							}
							else
							{
								GlobalVar.BaAction.Dribblehometest1(1, num4);
								DebugRecord.ceshi(5, "8分钟后1号鱼抢夺对方球", (float)num4);
							}
						}
						else
						{
							GlobalVar.BaAction.chanqiuqubahaizi(1);
							DebugRecord.ceshi(5, "8分钟后1号鱼无球可抢");
						}
						
						// 🔥 执行完8分钟策略后立即返回，避免被后续策略覆盖
						bool flag34_new5 = num16 < 0.08 && num14 < 20.0 && GlobalVar.finallanqiu == 0;
						if (flag34_new5)
						{
							GlobalVar.decisions[0].VCode = 12;
						}
						bool flag34_new6 = num23 < 0.08 && num15 < 20.0 && GlobalVar.finallanqiu == 0;
						if (flag34_new6)
						{
							GlobalVar.decisions[1].VCode = 12;
						}
						GlobalVar.MyTeamLast = mission.TeamsRef[teamId];
						DebugRecord.RecordBaseInfomation(mission, teamId, this.decisions);
DebugRecord.ceshi(0, "8分钟后抢夺策略执行完毕，直接返回");
					WriteDiagFrame(mission, teamId);
					return this.decisions;
					}
				}
				
				// 7分30秒后（Paishu >= 4500）优先处理己方大禁区的球（高分球优先）
				bool flag34_5 = GlobalVar.Paishu >= 4500;
				if (flag34_5)
				{
					// 计算己方大禁区内（x < -952）未得分球的数量
					int ballsInBigArea = 0;
					for (int frameIdx = 0; frameIdx < 9; frameIdx++)
					{
						bool inBigArea = GlobalVar.BaAction.whether_in_myforbiddenareabig((double)GlobalVar.balls[frameIdx].PositionMm.X) && GlobalVar.leftScore[frameIdx] != 1;
						if (inBigArea)
						{
							ballsInBigArea++;
						}
					}
					DebugRecord.ceshi(0, "7分30秒后大禁区球数", (float)ballsInBigArea);
					
					// 如果大禁区有球，优先将球运进框（高分球优先）
					bool flag34_6 = ballsInBigArea > 0;
					if (flag34_6)
					{
						DebugRecord.ceshi(0, "7分30秒后优先处理大禁区球（高分优先）");
						
						// 按优先级排序：3分球(0,1,2) > 2分球(7,8) > 1分球(3,4,5,6)
						int[] priorityOrder = new int[] { 0, 1, 2, 7, 8, 3, 4, 5, 6 };
						int ball0 = -1;
						int ball1 = -1;
						
						// 为0号鱼选择最高分的大禁区球
						for (int i = 0; i < priorityOrder.Length; i++)
						{
							int ballIdx = priorityOrder[i];
							bool inBigArea = GlobalVar.BaAction.whether_in_myforbiddenareabig((double)GlobalVar.balls[ballIdx].PositionMm.X) && GlobalVar.leftScore[ballIdx] != 1;
							if (inBigArea)
							{
								ball0 = ballIdx;
								break;
							}
						}
						
						// 为1号鱼选择次高分的大禁区球（不能和0号鱼重复）
						for (int i = 0; i < priorityOrder.Length; i++)
						{
							int ballIdx = priorityOrder[i];
							bool inBigArea = GlobalVar.BaAction.whether_in_myforbiddenareabig((double)GlobalVar.balls[ballIdx].PositionMm.X) && GlobalVar.leftScore[ballIdx] != 1;
							if (inBigArea && ballIdx != ball0)
							{
								ball1 = ballIdx;
								break;
							}
						}
						
						num3 = ball0;
						num4 = ball1;
						
						bool flag34_7 = num3 != -1;
						if (flag34_7)
						{
							int yieldingFish = this.GetLateGoalYieldFish(num3, num4);
							if (yieldingFish == 0)
							{
								this.PositionLateGoalYield(0, num4);
								DebugRecord.ceshi(5, "7分30秒后0号鱼门前让行", (float)num4);
							}
							else
							{
								GlobalVar.BaAction.the_warrior2(0, num3);
								DebugRecord.ceshi(5, "7分30秒后0号鱼推进大禁区高分球", (float)num3);
							}
						}
						else
						{
							GlobalVar.BaAction.chanqiuqubahaizi(0);
							DebugRecord.ceshi(5, "7分30秒后0号鱼大禁区无球");
						}
						
						bool flag34_8 = num4 != -1;
						if (flag34_8)
						{
							int yieldingFish = this.GetLateGoalYieldFish(num3, num4);
							if (yieldingFish == 1)
							{
								this.PositionLateGoalYield(1, num3);
								DebugRecord.ceshi(5, "7分30秒后1号鱼门前让行", (float)num3);
							}
							else
							{
								GlobalVar.BaAction.the_warrior2(1, num4);
								DebugRecord.ceshi(5, "7分30秒后1号鱼推进大禁区高分球", (float)num4);
							}
						}
						else
						{
							GlobalVar.BaAction.chanqiuqubahaizi(1);
							DebugRecord.ceshi(5, "7分30秒后1号鱼大禁区无球");
						}
						
						// 🔥 关键修复：执行完大禁区策略后立即返回，避免被后续策略覆盖
						bool flag34_9 = num16 < 0.08 && num14 < 20.0 && GlobalVar.finallanqiu == 0;
						if (flag34_9)
						{
							GlobalVar.decisions[0].VCode = 12;
						}
						bool flag34_10 = num23 < 0.08 && num15 < 20.0 && GlobalVar.finallanqiu == 0;
						if (flag34_10)
						{
							GlobalVar.decisions[1].VCode = 12;
						}
						GlobalVar.MyTeamLast = mission.TeamsRef[teamId];
						DebugRecord.RecordBaseInfomation(mission, teamId, this.decisions);
DebugRecord.ceshi(0, "7分30秒后大禁区策略执行完毕，直接返回");
					WriteDiagFrame(mission, teamId);
					return this.decisions;
					}
				}
				
				// flag35: 分数够高 或 (final阶段且分数够高)
				bool flag35 = num5 > 8 || num6 > 10 || (GlobalVar.final == 1 && (num5 > 8 || num6 > 10));
				if (flag35)
				{
					DebugRecord.ceshi(9, "3");
					GlobalVar.final = 1;
					bool flag36 = GlobalVar.lanqiuFlag[0] != 0 || GlobalVar.lanqiuFlag[1] != 0;
					if (flag36)
					{
						GlobalVar.finallanqiu = 0;
					}
					bool flag37 = num7 == 0 && GlobalVar.finallanqiu == 1 && GlobalVar.lanqiuFlag[0] == 0 && GlobalVar.lanqiuFlag[1] == 0;
					if (flag37)
					{
						GlobalVar.finallanqiu = 0;
						GlobalVar.lanqiuFlag[1] = 1;
						GlobalVar.lanqiuFlag[0] = 1;
					}
					bool flag38 = (num8 > 2 || GlobalVar.finallanqiu == 1) && GlobalVar.lanqiuFlag[0] == 0 && GlobalVar.lanqiuFlag[1] == 0 && GlobalVar.Paishu < 4500 && num6 > num12 && GlobalVar.escape_lanqiu == 0;
					if (flag38)
					{
						GlobalVar.BaAction.Dribblehometestlast2min(0);
						GlobalVar.BaAction.Dribblehometestlast2min(1);
						GlobalVar.finallanqiu = 1;
						GlobalVar.Bringing_BallID[0] = -1;
						GlobalVar.Bringing_BallID[1] = -1;
						DebugRecord.ceshi(5, "揽球");
					}
					else
					{
						// 原来的final阶段策略
						bool flag39 = num7 >= 1 && GlobalVar.CQstage == 0;
						if (flag39)
						{
							GlobalVar.escape_lanqiu = 1;
							num3 = GlobalVar.BaAction.choseball3_special(0);
							num4 = GlobalVar.BaAction.ChoseBall2(1);
							DebugRecord.ceshi(0, "ballId1--fi1", (float)num3);
							DebugRecord.ceshi(0, "ballId2--fi1", (float)num4);
							DebugRecord.ceshi(12, "bringballId1--fi1", (float)GlobalVar.Bringing_BallID[0]);
							DebugRecord.ceshi(12, "bringballId2--fi1", (float)GlobalVar.Bringing_BallID[1]);
							bool flag40 = num3 != -1;
							if (flag40)
							{
								GlobalVar.BaAction.the_warrior2(0, num3);
								DebugRecord.ceshi(5, "danyujinqiu(0, ballid1)--fi1");
							}
							else
							{
								GlobalVar.CQstage = 1;
								GlobalVar.BaAction.chanqiuqubahaizi(0);
								DebugRecord.ceshi(5, "chanqiuqubahaizi(0)--fi1，0号鱼没选到球");
							}
							bool flag41 = num4 != -1;
							if (flag41)
							{
								int whichfish = 1;
								GlobalVar.BaAction.Dribblehometest1(whichfish, num4);
								DebugRecord.ceshi(5, "Dribblehometest1(1, ballid2)--fi1");
							}
							else
							{
								GlobalVar.BaAction.chanqiuqubahaizi(1);
								DebugRecord.ceshi(5, "chanqiuqubahaizi(1)--fi1");
							}
						}
						else
						{
							GlobalVar.escape_lanqiu = 1;
							DebugRecord.ceshi(9, "4");
							GlobalVar.CQstage = 1;
							num3 = GlobalVar.BaAction.ChoseBallplus(0);
							num4 = GlobalVar.BaAction.ChoseBallplus(1);
							DebugRecord.ceshi(0, "ballId1--fi2", (float)num3);
							DebugRecord.ceshi(0, "ballId2--fi2", (float)num4);
							DebugRecord.ceshi(12, "bringballId1--fi2", (float)GlobalVar.Bringing_BallID[0]);
							DebugRecord.ceshi(12, "bringballId2--fi2", (float)GlobalVar.Bringing_BallID[1]);
							bool flag42 = num3 != -1;
							if (flag42)
							{
								bool flag43 = GlobalVar.BaAction.whether_in_myforbiddenareabig((double)GlobalVar.mission.EnvRef.Balls[num3].PositionMm.X);
								if (flag43)
								{
									GlobalVar.BaAction.the_warrior2(0, num3);
									DebugRecord.ceshi(5, "danyujinqiu(0, ballid1)--fi2");
								}
								else
								{
									GlobalVar.BaAction.Dribblehometest1(0, num3);
									DebugRecord.ceshi(5, "Dribblehometest1(0, ballid1)--fi2");
								}
							}
							else
							{
								GlobalVar.BaAction.chanqiuqubahaizi(0);
								DebugRecord.ceshi(5, "chanqiuqubahaizi(0)--fi2");
							}
							bool flag44 = num4 != -1;
							if (flag44)
							{
								bool flag45 = GlobalVar.BaAction.whether_in_myforbiddenareabig((double)GlobalVar.mission.EnvRef.Balls[num4].PositionMm.X);
								if (flag45)
								{
									GlobalVar.BaAction.the_warrior2(1, num4);
									DebugRecord.ceshi(5, "danyujinqiu(1, ballid2)--fi2");
								}
								else
								{
									GlobalVar.BaAction.Dribblehometest1(1, num4);
									DebugRecord.ceshi(5, "Dribblehometest1(1, ballid2)--fi2");
								}
							}
							else
							{
								GlobalVar.BaAction.chanqiuqubahaizi(1);
								DebugRecord.ceshi(5, "chanqiuqubahaizi(1)--fi2");
							}
						}
					}
				}
				DebugRecord.ceshi(12, "finallanqiu2", (float)GlobalVar.finallanqiu);
				DebugRecord.ceshi(12, "CQstage", (float)GlobalVar.CQstage);
				DebugRecord.ceshi(12, "escape_lanqiu", (float)GlobalVar.escape_lanqiu);
			}
			// 【已禁用】偷袭策略（Unarmed Strategy）- 检测对手空手回防时的特殊进攻策略
			// 禁用原因：放弃偷袭策略
			bool flag46 = false; // 原: GlobalVar.flag_duqiumen != 1;
			if (flag46)
			{
				for (int n = 0; n < num26; n++)
				{
					bool flag47 = GlobalVar.enemyx0[n] >= -1350.0 || ((GlobalVar.enemydirection0[n] <= GlobalVar.PI * -175.0 / 180.0 || GlobalVar.enemydirection0[n] >= GlobalVar.PI * -140.0 / 180.0) && (GlobalVar.enemydirection0[n] <= GlobalVar.PI * 140.0 / 180.0 || GlobalVar.enemydirection0[n] >= GlobalVar.PI * 175.0 / 180.0));
					if (flag47)
					{
						GlobalVar.UnarmedFlag0 = 0;
						break;
					}
					GlobalVar.UnarmedFlag0 = 1;
				}
				for (int num37 = 0; num37 < num26; num37++)
				{
					bool flag48 = GlobalVar.enemyx1[num37] >= -1350.0 || ((GlobalVar.enemydirection1[num37] <= GlobalVar.PI * -175.0 / 180.0 || GlobalVar.enemydirection1[num37] >= GlobalVar.PI * -140.0 / 180.0) && (GlobalVar.enemydirection1[num37] <= GlobalVar.PI * 140.0 / 180.0 || GlobalVar.enemydirection1[num37] >= GlobalVar.PI * 175.0 / 180.0));
					if (flag48)
					{
						GlobalVar.UnarmedFlag1 = 0;
						break;
					}
					GlobalVar.UnarmedFlag1 = 1;
				}
				bool flag49 = GlobalVar.UnarmedFlag0 == 1 && GlobalVar.BaAction.num_of_ball_in_mysmall(true, false) > 0 && !GlobalVar.BaAction.whether_in_myforbiddenarea_reduce(location_x, location_z) && !GlobalVar.BaAction.whether_in_myforbiddenarea_reduce(location_x2, location_z2) && GlobalVar.final == 0 && GlobalVar.enemydirection0[10] > GlobalVar.PI * -175.0 / 180.0 && GlobalVar.enemydirection0[10] < GlobalVar.PI * -140.0 / 180.0;
				if (flag49)
				{
					GlobalVar.UnarmedStage = 1;
				}
				bool flag50 = GlobalVar.UnarmedFlag0 == 1 && GlobalVar.BaAction.num_of_ball_in_mysmall(true, false) > 0 && !GlobalVar.BaAction.whether_in_myforbiddenarea_reduce(location_x, location_z) && !GlobalVar.BaAction.whether_in_myforbiddenarea_reduce(location_x2, location_z2) && GlobalVar.final == 0 && GlobalVar.enemydirection0[10] > GlobalVar.PI * 140.0 / 180.0 && GlobalVar.enemydirection0[10] < GlobalVar.PI * 175.0 / 180.0;
				if (flag50)
				{
					GlobalVar.UnarmedStage = 2;
				}
				bool flag51 = GlobalVar.UnarmedFlag1 == 1 && GlobalVar.BaAction.num_of_ball_in_mysmall(true, false) > 0 && !GlobalVar.BaAction.whether_in_myforbiddenarea_reduce(location_x, location_z) && !GlobalVar.BaAction.whether_in_myforbiddenarea_reduce(location_x2, location_z2) && GlobalVar.final == 0 && GlobalVar.enemydirection1[10] > GlobalVar.PI * -175.0 / 180.0 && GlobalVar.enemydirection1[10] < GlobalVar.PI * -140.0 / 180.0;
				if (flag51)
				{
					GlobalVar.UnarmedStage = 3;
				}
				bool flag52 = GlobalVar.UnarmedFlag1 == 1 && GlobalVar.BaAction.num_of_ball_in_mysmall(true, false) > 0 && !GlobalVar.BaAction.whether_in_myforbiddenarea_reduce(location_x, location_z) && !GlobalVar.BaAction.whether_in_myforbiddenarea_reduce(location_x2, location_z2) && GlobalVar.final == 0 && GlobalVar.enemydirection1[10] > GlobalVar.PI * 140.0 / 180.0 && GlobalVar.enemydirection1[10] < GlobalVar.PI * 175.0 / 180.0;
				if (flag52)
				{
					GlobalVar.UnarmedStage = 4;
				}
				bool flag53 = ((GlobalVar.UnarmedStage == 1 || GlobalVar.UnarmedStage == 2) && Math.Abs(GlobalVar.OppTeam.Fishes[0].PositionMm.Z) >= 600f) || ((GlobalVar.UnarmedStage == 3 || GlobalVar.UnarmedStage == 4) && Math.Abs(GlobalVar.OppTeam.Fishes[1].PositionMm.Z) >= 600f) || GlobalVar.final == 1;
				if (flag53)
				{
					GlobalVar.UnarmedStage = 0;
				}
				bool flag54 = GlobalVar.UnarmedStage > 0;
				if (flag54)
				{
					DebugRecord.ceshi(0, "待完成代码");
					bool flag55 = GlobalVar.UnarmedStage == 1;
					if (flag55)
					{
						DebugRecord.ceshi(4, "UnarmedStage == 1");
						int num38 = GlobalVar.BaAction.choseball3_special2(1);
						bool flag56 = num38 != -1;
						if (flag56)
						{
							GlobalVar.BaAction.the_warrior2_special(1, num38);
						}
						else
						{
							GlobalVar.UnarmedStage = 0;
						}
						DebugRecord.ceshi(0, "ballid--tbc0d", (float)num38);
						DebugRecord.ceshi(12, "bringballId0--tbc0d", (float)GlobalVar.Bringing_BallID[0]);
						DebugRecord.ceshi(12, "bringballId1--tbc0d", (float)GlobalVar.Bringing_BallID[1]);
					}
					else
					{
						bool flag57 = GlobalVar.UnarmedStage == 2;
						if (flag57)
						{
							DebugRecord.ceshi(4, "UnarmedStage == 2");
							int num39 = GlobalVar.BaAction.choseball3_special2(0);
							bool flag58 = num39 != -1;
							if (flag58)
							{
								GlobalVar.BaAction.the_warrior2_special(0, num39);
							}
							else
							{
								GlobalVar.UnarmedStage = 0;
							}
							DebugRecord.ceshi(0, "ballid--tbc0u", (float)num39);
							DebugRecord.ceshi(12, "bringballId0--tbc0u", (float)GlobalVar.Bringing_BallID[0]);
							DebugRecord.ceshi(12, "bringballId1--tbc0u", (float)GlobalVar.Bringing_BallID[1]);
						}
						else
						{
							bool flag59 = GlobalVar.UnarmedStage == 3;
							if (flag59)
							{
								DebugRecord.ceshi(4, "UnarmedStage == 3");
								int num40 = GlobalVar.BaAction.choseball3_special2(1);
								bool flag60 = num40 != -1;
								if (flag60)
								{
									GlobalVar.BaAction.the_warrior2_special(1, num40);
								}
								else
								{
									GlobalVar.UnarmedStage = 0;
								}
								DebugRecord.ceshi(0, "ballid--tbc1d", (float)num40);
								DebugRecord.ceshi(12, "bringballId0--tbc1d", (float)GlobalVar.Bringing_BallID[0]);
								DebugRecord.ceshi(12, "bringballId1--tbc1d", (float)GlobalVar.Bringing_BallID[1]);
							}
							else
							{
								bool flag61 = GlobalVar.UnarmedStage == 4;
								if (flag61)
								{
									DebugRecord.ceshi(4, "UnarmedStage == 4");
									int num41 = GlobalVar.BaAction.choseball3_special2(0);
									bool flag62 = num41 != -1;
									if (flag62)
									{
										GlobalVar.BaAction.the_warrior2_special(0, num41);
									}
									else
									{
										GlobalVar.UnarmedStage = 0;
									}
									DebugRecord.ceshi(0, "ballid--tbc1u", (float)num41);
									DebugRecord.ceshi(12, "bringballId0--tbc1u", (float)GlobalVar.Bringing_BallID[0]);
									DebugRecord.ceshi(12, "bringballId1--tbc1u", (float)GlobalVar.Bringing_BallID[1]);
								}
							}
						}
					}
				}
				DebugRecord.ceshi(12, "UnarmedStage", (float)GlobalVar.UnarmedStage);
			}
			bool flag63 = num16 < 0.08 && num14 < 20.0 && GlobalVar.finallanqiu == 0;
			if (flag63)
			{
				GlobalVar.decisions[0].VCode = 12;
			}
			bool flag64 = num23 < 0.08 && num15 < 20.0 && GlobalVar.finallanqiu == 0;
			if (flag64)
			{
				GlobalVar.decisions[1].VCode = 12;
			}
			GlobalVar.MyTeamLast = mission.TeamsRef[teamId];
DebugRecord.RecordBaseInfomation(mission, teamId, this.decisions);
			WriteDiagFrame(mission, teamId);
			return this.decisions;
		}

		private int GetLateGoalBallValue(int ballId)
		{
			if (ballId >= 0 && ballId <= 2)
			{
				return 3;
			}
			if (ballId == 7 || ballId == 8)
			{
				return 2;
			}
			return 1;
		}

		private int GetLateGoalYieldFish(int ball0, int ball1)
		{
			if (ball0 < 0 || ball1 < 0 || ball0 == ball1)
			{
				return -1;
			}
			double fish0X = (double)GlobalVar.MyTeam.Fishes[0].PositionMm.X;
			double fish0Z = (double)GlobalVar.MyTeam.Fishes[0].PositionMm.Z;
			double fish1X = (double)GlobalVar.MyTeam.Fishes[1].PositionMm.X;
			double fish1Z = (double)GlobalVar.MyTeam.Fishes[1].PositionMm.Z;
			if (fish0X > -900.0 || fish1X > -900.0)
			{
				return -1;
			}
			double teammateDistance = Compute.GetDistance(fish0X, fish0Z, fish1X, fish1Z);
			if (teammateDistance > 360.0)
			{
				return -1;
			}
			double ballZGap = Math.Abs((double)GlobalVar.balls[ball0].PositionMm.Z - (double)GlobalVar.balls[ball1].PositionMm.Z);
			double ballDistance = Compute.GetDistance((double)GlobalVar.balls[ball0].PositionMm.X, (double)GlobalVar.balls[ball0].PositionMm.Z, (double)GlobalVar.balls[ball1].PositionMm.X, (double)GlobalVar.balls[ball1].PositionMm.Z);
			if (ballZGap >= 320.0 || ballDistance >= 460.0)
			{
				return -1;
			}
			int value0 = this.GetLateGoalBallValue(ball0);
			int value1 = this.GetLateGoalBallValue(ball1);
			double fish0TargetDistance = Compute.GetDistance(fish0X, fish0Z, (double)GlobalVar.balls[ball0].PositionMm.X, (double)GlobalVar.balls[ball0].PositionMm.Z);
			double fish1TargetDistance = Compute.GetDistance(fish1X, fish1Z, (double)GlobalVar.balls[ball1].PositionMm.X, (double)GlobalVar.balls[ball1].PositionMm.Z);
			if (value0 > value1 || (value0 == value1 && fish0TargetDistance <= fish1TargetDistance + 120.0))
			{
				return 1;
			}
			return 0;
		}

		private void PositionLateGoalYield(int fishId, int activeBallId)
		{
			double activeBallZ = activeBallId >= 0 && activeBallId < 9 ? (double)GlobalVar.balls[activeBallId].PositionMm.Z : 0.0;
			double waitZ = activeBallZ >= 0.0 ? -700.0 : 700.0;
			GlobalVar.BaAction.Position(fishId, -800.0, waitZ, 180.0);
		}

		private void EnsureDiagnostics(Mission mission, int teamId)
		{
			string DirectoryPath = @"E:\progaram\URWPGSim2D\logs";
			System.IO.Directory.CreateDirectory(DirectoryPath);
			int currentRemaining = mission.CommonPara.RemainingCycles;

			bool newMatch = _diagLastRemaining != -1 && currentRemaining > _diagLastRemaining;
			if (newMatch || _diagLogger == null)
			{
				if (_diagLogger != null)
				{
					_diagLogger.Dispose();
					_diagLogger = null;
				}

				FrameLoggerOptions options = new FrameLoggerOptions();
				options.DirectoryPath = DirectoryPath;
				options.Mission = "grab-ball";
				options.TeamId = teamId.ToString(CultureInfo.InvariantCulture);
				options.FileNamePrefix = "grab_ball";

				try
				{
					_diagLogger = new FrameLogger(options);
					_diagLogger.Begin(new List<string>(DiagFields));
				}
				catch
				{
					// Diagnostics must never disrupt strategy logic.
				}

				_diagLastRemaining = currentRemaining;
			}
		}

		private void WriteDiagFrame(Mission mission, int teamId)
		{
			try
			{
				if (_diagLogger == null) return;
				int fishCnt = mission.CommonPara.FishCntPerTeam;
				List<FrameRow> rows = new List<FrameRow>(fishCnt);
				for (int i = 0; i < fishCnt; i++)
				{
					Decision d = GlobalVar.decisions[i];
					RoboFish fish = mission.TeamsRef[teamId].Fishes[i];
					int ballId = (i < GlobalVar.Bringing_BallID.Length) ? GlobalVar.Bringing_BallID[i] : -1;
					rows.Add(new FrameRow(new string[] {
						GlobalVar.Paishu.ToString(CultureInfo.InvariantCulture),
						i.ToString(CultureInfo.InvariantCulture),
						GlobalVar.Paishu.ToString(CultureInfo.InvariantCulture),
						d.VCode.ToString(CultureInfo.InvariantCulture),
						d.TCode.ToString(CultureInfo.InvariantCulture),
						fish.PositionMm.X.ToString("F4", CultureInfo.InvariantCulture),
						fish.PositionMm.Z.ToString("F4", CultureInfo.InvariantCulture),
						fish.BodyDirectionRad.ToString("F4", CultureInfo.InvariantCulture),
						ballId.ToString(CultureInfo.InvariantCulture),
						mission.TeamsRef[teamId].Para.Score.ToString(CultureInfo.InvariantCulture)
					}));
				}
				_diagLogger.WriteFrame(rows);
			}
			catch
			{
				// Diagnostics must never disrupt strategy logic.
			}
		}

		// Token: 0x06000091 RID: 145 RVA: 0x00023F2C File Offset: 0x0002212C
		public void RightToLeft()
		{
			bool flag = GlobalVar.teamId == 0;
			if (!flag)
			{
				DebugRecord.ceshi(1, "左右队变换前！");
				for (int i = 0; i < 9; i++)
				{
					GlobalVar.balls[i].PositionMm.X = -GlobalVar.balls[i].PositionMm.X;
					GlobalVar.balls[i].PositionMm.Z = -GlobalVar.balls[i].PositionMm.Z;
					GlobalVar.balls[i].VelocityDirectionRad = (float)Compute.FormatAngleRad((double)GlobalVar.balls[i].VelocityDirectionRad + GlobalVar.PI);
				}
				GlobalVar.leftScore[0] = GlobalVar.b0_r;
				GlobalVar.leftScore[1] = GlobalVar.b1_r;
				GlobalVar.leftScore[2] = GlobalVar.b2_r;
				GlobalVar.leftScore[3] = GlobalVar.b3_r;
				GlobalVar.leftScore[4] = GlobalVar.b4_r;
				GlobalVar.leftScore[5] = GlobalVar.b5_r;
				GlobalVar.leftScore[6] = GlobalVar.b6_r;
				GlobalVar.leftScore[7] = GlobalVar.b7_r;
				GlobalVar.leftScore[8] = GlobalVar.b8_r;
				GlobalVar.rightScore[0] = GlobalVar.b0_l;
				GlobalVar.rightScore[1] = GlobalVar.b1_l;
				GlobalVar.rightScore[2] = GlobalVar.b2_l;
				GlobalVar.rightScore[3] = GlobalVar.b3_l;
				GlobalVar.rightScore[4] = GlobalVar.b4_l;
				GlobalVar.rightScore[5] = GlobalVar.b5_l;
				GlobalVar.rightScore[6] = GlobalVar.b6_l;
				GlobalVar.rightScore[7] = GlobalVar.b7_l;
				GlobalVar.rightScore[8] = GlobalVar.b8_l;
				List<RoboFish> fishes = GlobalVar.MyTeam.Fishes;
				List<RoboFish> fishes2 = GlobalVar.OppTeam.Fishes;
				for (int j = 0; j < fishes.Count; j++)
				{
					fishes[j].PositionMm.X = -fishes[j].PositionMm.X;
					fishes[j].PositionMm.Z = -fishes[j].PositionMm.Z;
					Vector3 value = default(Vector3);
					value.X = -fishes[j].PolygonVertices[0].X;
					value.Z = -fishes[j].PolygonVertices[0].Z;
					fishes[j].PolygonVertices[0] = value;
					fishes[j].BodyDirectionRad = (float)Compute.FormatAngleRad((double)fishes[j].VelocityDirectionRad + GlobalVar.PI);
					fishes[j].VelocityDirectionRad = (float)Compute.FormatAngleRad((double)fishes[j].VelocityDirectionRad + GlobalVar.PI);
				}
				for (int k = 0; k < fishes2.Count; k++)
				{
					fishes2[k].PositionMm.X = -fishes2[k].PositionMm.X;
					fishes2[k].PositionMm.Z = -fishes2[k].PositionMm.Z;
					Vector3 value2 = default(Vector3);
					value2.X = -fishes2[k].PolygonVertices[0].X;
					value2.Z = -fishes2[k].PolygonVertices[0].Z;
					fishes2[k].PolygonVertices[0] = value2;
					fishes2[k].VelocityDirectionRad = (float)Compute.FormatAngleRad((double)fishes2[k].VelocityDirectionRad + GlobalVar.PI);
					fishes2[k].BodyDirectionRad = (float)Compute.FormatAngleRad((double)fishes2[k].VelocityDirectionRad + GlobalVar.PI);
				}
			}
		}

		// Token: 0x040000D1 RID: 209
		private Decision[] decisions = null;
	}
}
