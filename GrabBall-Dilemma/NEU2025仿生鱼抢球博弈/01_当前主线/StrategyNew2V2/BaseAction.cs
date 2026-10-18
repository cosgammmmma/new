using System;
using System.IO;
using URWPGSim2D.Common;

namespace URWPGSim2D.Strategy
{
	// Token: 0x02000002 RID: 2
	public class BaseAction
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public void wait(int whichfish)
		{
			GlobalVar.decisions[whichfish].TCode = 7;
			GlobalVar.decisions[whichfish].VCode = 0;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002078 File Offset: 0x00000278
		public int TransfromAngletoTCode(double tempjiaodu)
		{
			bool flag = 0.0 == tempjiaodu;
			int result;
			if (flag)
			{
				result = 7;
			}
			else
			{
				bool flag2 = tempjiaodu < 0.0;
				if (flag2)
				{
					bool flag3 = -0.0269 <= tempjiaodu && 0.0 > tempjiaodu;
					if (flag3)
					{
						bool flag4 = 0.0 - tempjiaodu >= tempjiaodu + 0.0269;
						if (flag4)
						{
							result = 6;
						}
						else
						{
							result = 7;
						}
					}
					else
					{
						bool flag5 = -0.04508 <= tempjiaodu && -0.0269 > tempjiaodu;
						if (flag5)
						{
							bool flag6 = -0.0269 - tempjiaodu >= tempjiaodu + 0.04508;
							if (flag6)
							{
								result = 5;
							}
							else
							{
								result = 6;
							}
						}
						else
						{
							bool flag7 = -0.071013 <= tempjiaodu && -0.04508 > tempjiaodu;
							if (flag7)
							{
								bool flag8 = -0.04508 - tempjiaodu >= tempjiaodu + 0.071013;
								if (flag8)
								{
									result = 4;
								}
								else
								{
									result = 5;
								}
							}
							else
							{
								bool flag9 = -0.09953 <= tempjiaodu && -0.071013 > tempjiaodu;
								if (flag9)
								{
									bool flag10 = -0.071013 - tempjiaodu >= tempjiaodu + 0.09953;
									if (flag10)
									{
										result = 3;
									}
									else
									{
										result = 4;
									}
								}
								else
								{
									bool flag11 = -0.1265 <= tempjiaodu && -0.09953 > tempjiaodu;
									if (flag11)
									{
										bool flag12 = -0.09953 - tempjiaodu >= tempjiaodu + 0.1265;
										if (flag12)
										{
											result = 2;
										}
										else
										{
											result = 3;
										}
									}
									else
									{
										bool flag13 = -0.168 <= tempjiaodu && -0.1265 > tempjiaodu;
										if (flag13)
										{
											bool flag14 = -0.1265 - tempjiaodu >= tempjiaodu + 0.168;
											if (flag14)
											{
												result = 1;
											}
											else
											{
												result = 2;
											}
										}
										else
										{
											bool flag15 = -0.20424 <= tempjiaodu && -0.168 > tempjiaodu;
											if (flag15)
											{
												bool flag16 = -0.168 - tempjiaodu >= tempjiaodu + 0.20424;
												if (flag16)
												{
													result = 0;
												}
												else
												{
													result = 1;
												}
											}
											else
											{
												result = 0;
											}
										}
									}
								}
							}
						}
					}
				}
				else
				{
					bool flag17 = 0.0269 >= tempjiaodu && 0.0 < tempjiaodu;
					if (flag17)
					{
						bool flag18 = tempjiaodu - 0.0 > 0.0269 - tempjiaodu;
						if (flag18)
						{
							result = 8;
						}
						else
						{
							result = 7;
						}
					}
					else
					{
						bool flag19 = 0.04508 >= tempjiaodu && 0.0269 < tempjiaodu;
						if (flag19)
						{
							bool flag20 = tempjiaodu - 0.0269 > 0.04508 - tempjiaodu;
							if (flag20)
							{
								result = 9;
							}
							else
							{
								result = 8;
							}
						}
						else
						{
							bool flag21 = 0.071013 >= tempjiaodu && 0.04508 < tempjiaodu;
							if (flag21)
							{
								bool flag22 = tempjiaodu - 0.04508 > 0.071013 - tempjiaodu;
								if (flag22)
								{
									result = 10;
								}
								else
								{
									result = 9;
								}
							}
							else
							{
								bool flag23 = 0.09953 >= tempjiaodu && 0.071013 < tempjiaodu;
								if (flag23)
								{
									bool flag24 = tempjiaodu - 0.071013 > 0.09953 - tempjiaodu;
									if (flag24)
									{
										result = 11;
									}
									else
									{
										result = 10;
									}
								}
								else
								{
									bool flag25 = 0.1265 >= tempjiaodu && 0.09953 < tempjiaodu;
									if (flag25)
									{
										bool flag26 = tempjiaodu - 0.09953 > 0.1265 - tempjiaodu;
										if (flag26)
										{
											result = 12;
										}
										else
										{
											result = 11;
										}
									}
									else
									{
										bool flag27 = 0.168 >= tempjiaodu && 0.1265 < tempjiaodu;
										if (flag27)
										{
											bool flag28 = tempjiaodu - 0.1265 > 0.168 - tempjiaodu;
											if (flag28)
											{
												result = 13;
											}
											else
											{
												result = 12;
											}
										}
										else
										{
											bool flag29 = 0.1977 >= tempjiaodu && 0.168 < tempjiaodu;
											if (flag29)
											{
												bool flag30 = tempjiaodu - 0.168 > 0.1977 - tempjiaodu;
												if (flag30)
												{
													result = 14;
												}
												else
												{
													result = 13;
												}
											}
											else
											{
												result = 14;
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002524 File Offset: 0x00000724
		public bool whether_in_oppforbiddenareabig(double location_x, double location_z)
		{
			return location_x > 952.0;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x0000254C File Offset: 0x0000074C
		public bool whether_in_opphome(double location_x, double location_z)
		{
			return Math.Abs(location_z) < 507.0 && location_x > 984.0 && location_x < 1090.0;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002598 File Offset: 0x00000798
		public bool whether_in_myforbiddenareasmall(double location_x, double location_z)
		{
			return Math.Abs(location_z) < 508.0 && location_x < -952.0;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000025D4 File Offset: 0x000007D4
		public bool whether_in_myforbiddenarea3(double location_x, double location_z)
		{
			return (Math.Abs(location_z) < 400.0 && location_x < -1150.0) || (Math.Abs(location_z) < 500.0 && location_x < -948.0 && location_x > -1290.0);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000263C File Offset: 0x0000083C
		public bool whether_in_myforbiddenareabig(double location_x)
		{
			return location_x < -952.0;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002664 File Offset: 0x00000864
		public bool whether_in_myforbiddenarea_reduce(double location_x, double location_z)
		{
			return (Math.Abs(location_z) < 320.0 && location_x < -952.0) || this.whether_in_myhome(location_x, location_z);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000026A8 File Offset: 0x000008A8
		public bool whether_in_myhome(double location_x, double location_z)
		{
			return Math.Abs(location_z) < 508.0 && location_x < -984.0 && location_x > -1090.0;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000026F4 File Offset: 0x000008F4
		public int num_of_ball_in_oppbig(bool whether_include_forbiddenarea, bool score_or_numofball)
		{
			double[,] array = new double[9, 2];
			for (int i = 0; i < 9; i++)
			{
				array[i, 0] = (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X;
				array[i, 1] = (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z;
			}
			int num = 0;
			int num2 = 0;
			for (int j = 0; j < 9; j++)
			{
				bool flag = this.whether_in_oppforbiddenareabig(array[j, 0], array[j, 1]) && !this.whether_in_opphome(array[j, 0], array[j, 1]);
				if (flag)
				{
					num++;
				}
				bool flag2 = this.whether_in_opphome(array[j, 0], array[j, 1]);
				if (flag2)
				{
					num2++;
				}
			}
			if (score_or_numofball)
			{
				for (int k = 0; k < 9; k++)
				{
					bool flag3 = this.whether_in_oppforbiddenareabig(array[k, 0], array[k, 1]);
					if (flag3)
					{
						bool flag4 = GlobalVar.rightScore[k] == 0;
						if (flag4)
						{
							bool flag5 = k == 0 || k == 1 || k == 2;
							if (flag5)
							{
								num += 2;
							}
							else
							{
								bool flag6 = k == 7 || k == 8;
								if (flag6)
								{
									num++;
								}
							}
						}
						bool flag7 = this.whether_in_opphome(array[k, 0], array[k, 1]) || GlobalVar.rightScore[k] == 1;
						if (flag7)
						{
							bool flag8 = this.whether_in_opphome(array[k, 0], array[k, 1]);
							if (flag8)
							{
								bool flag9 = k == 0 || k == 1 || k == 2;
								if (flag9)
								{
									num2 += 2;
								}
								else
								{
									bool flag10 = k == 7 || k == 8;
									if (flag10)
									{
										num2++;
									}
								}
							}
							else
							{
								bool flag11 = GlobalVar.rightScore[k] == 1 && !this.whether_in_opphome(array[k, 0], array[k, 1]);
								if (flag11)
								{
									bool flag12 = k == 0 || k == 1 || k == 2;
									if (flag12)
									{
										num2 += 3;
									}
									else
									{
										bool flag13 = k == 7 || k == 8;
										if (flag13)
										{
											num2 += 2;
										}
										else
										{
											num2++;
										}
									}
								}
							}
						}
					}
				}
			}
			int result;
			if (whether_include_forbiddenarea)
			{
				result = num;
			}
			else
			{
				result = num2;
			}
			return result;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002994 File Offset: 0x00000B94
		public int num_of_ball_in_mybig(bool whether_include_forbiddenarea, bool score_or_numofball)
		{
			double[,] array = new double[9, 2];
			for (int i = 0; i < 9; i++)
			{
				array[i, 0] = (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X;
				array[i, 1] = (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z;
			}
			int num = 0;
			int num2 = 0;
			for (int j = 0; j < 9; j++)
			{
				bool flag = this.whether_in_myforbiddenareabig(array[j, 0]);
				if (flag)
				{
					bool flag2 = GlobalVar.leftScore[j] == 0;
					if (flag2)
					{
						num++;
					}
					bool flag3 = this.whether_in_myhome(array[j, 0], array[j, 1]);
					if (flag3)
					{
						num2++;
					}
				}
			}
			if (score_or_numofball)
			{
				for (int k = 0; k < 9; k++)
				{
					bool flag4 = this.whether_in_myforbiddenareabig(array[k, 0]);
					if (flag4)
					{
						bool flag5 = GlobalVar.leftScore[k] == 0;
						if (flag5)
						{
							bool flag6 = k == 0 || k == 1 || k == 2;
							if (flag6)
							{
								num += 2;
							}
							else
							{
								bool flag7 = k == 7 || k == 8;
								if (flag7)
								{
									num++;
								}
							}
						}
						bool flag8 = this.whether_in_myhome(array[k, 0], array[k, 1]) || GlobalVar.leftScore[k] == 1;
						if (flag8)
						{
							bool flag9 = this.whether_in_myhome(array[k, 0], array[k, 1]);
							if (flag9)
							{
								bool flag10 = k == 0 || k == 1 || k == 2;
								if (flag10)
								{
									num2 += 2;
								}
								else
								{
									bool flag11 = k == 7 || k == 8;
									if (flag11)
									{
										num2++;
									}
								}
							}
							else
							{
								bool flag12 = GlobalVar.leftScore[k] == 1 && !this.whether_in_myhome(array[k, 0], array[k, 1]);
								if (flag12)
								{
									bool flag13 = k == 0 || k == 1 || k == 2;
									if (flag13)
									{
										num2 += 3;
									}
									else
									{
										bool flag14 = k == 7 || k == 8;
										if (flag14)
										{
											num2 += 2;
										}
										else
										{
											num2++;
										}
									}
								}
							}
						}
					}
				}
			}
			int result;
			if (whether_include_forbiddenarea)
			{
				result = num;
			}
			else
			{
				result = num2;
			}
			return result;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002C14 File Offset: 0x00000E14
		public int num_of_ball_in_mysmall(bool whether_include_forbiddenarea, bool score_or_numofball)
		{
			double[,] array = new double[9, 2];
			for (int i = 0; i < 9; i++)
			{
				array[i, 0] = (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X;
				array[i, 1] = (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z;
			}
			int num = 0;
			int num2 = 0;
			for (int j = 0; j < 9; j++)
			{
				bool flag = this.whether_in_myforbiddenareasmall(array[j, 0], array[j, 1]);
				if (flag)
				{
					bool flag2 = GlobalVar.leftScore[j] == 0;
					if (flag2)
					{
						num++;
					}
					bool flag3 = this.whether_in_myhome(array[j, 0], array[j, 1]);
					if (flag3)
					{
						num2++;
					}
				}
			}
			if (score_or_numofball)
			{
				for (int k = 0; k < 9; k++)
				{
					bool flag4 = this.whether_in_myforbiddenareasmall(array[k, 0], array[k, 1]);
					if (flag4)
					{
						bool flag5 = GlobalVar.leftScore[k] == 0;
						if (flag5)
						{
							bool flag6 = k == 0 || k == 1 || k == 2;
							if (flag6)
							{
								num += 2;
							}
							else
							{
								bool flag7 = k == 7 || k == 8;
								if (flag7)
								{
									num++;
								}
							}
						}
						bool flag8 = this.whether_in_myhome(array[k, 0], array[k, 1]) || GlobalVar.leftScore[k] == 1;
						if (flag8)
						{
							bool flag9 = this.whether_in_myhome(array[k, 0], array[k, 1]);
							if (flag9)
							{
								bool flag10 = k == 0 || k == 1 || k == 2;
								if (flag10)
								{
									num2 += 2;
								}
								else
								{
									bool flag11 = k == 7 || k == 8;
									if (flag11)
									{
										num2++;
									}
								}
							}
							else
							{
								bool flag12 = GlobalVar.leftScore[k] == 1 && !this.whether_in_myhome(array[k, 0], array[k, 1]);
								if (flag12)
								{
									bool flag13 = k == 0 || k == 1 || k == 2;
									if (flag13)
									{
										num2 += 3;
									}
									else
									{
										bool flag14 = k == 7 || k == 8;
										if (flag14)
										{
											num2 += 2;
										}
										else
										{
											num2++;
										}
									}
								}
							}
						}
					}
				}
			}
			int result;
			if (whether_include_forbiddenarea)
			{
				result = num;
			}
			else
			{
				result = num2;
			}
			return result;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002EA4 File Offset: 0x000010A4
		public int Perception_ball(int whichfish, int i)
		{
			double num = 3000.0;
			double num2 = 0.0;
			int result = -1;
			bool flag = 10 == i;
			if (flag)
			{
				double x = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
				double z = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
				for (int j = 0; j < 9; j++)
				{
					double num3 = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.X;
					double num4 = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z;
					bool flag2 = Compute.GetDistance(num3, num4, x, z) < num;
					if (flag2)
					{
						num = Compute.GetDistance(num3, num4, x, z);
						result = j;
					}
				}
			}
			else
			{
				bool flag3 = 11 == i;
				if (flag3)
				{
					double x = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
					double z = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
					for (int j = 0; j < 9; j++)
					{
						double num3 = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.X;
						double num4 = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z;
						bool flag4 = this.whether_in_myhome(num3, num4);
						if (flag4)
						{
							bool flag5 = Compute.GetDistance(num3, num4, x, z) > num2;
							if (flag5)
							{
								num2 = Compute.GetDistance(num3, num4, x, z);
								result = j;
							}
						}
					}
				}
				else
				{
					bool flag6 = 20 == i;
					if (flag6)
					{
						double x = (double)GlobalVar.OppTeam.Fishes[whichfish].PositionMm.X;
						double z = (double)GlobalVar.OppTeam.Fishes[whichfish].PositionMm.Z;
						double x2 = (double)GlobalVar.OppTeam.Fishes[whichfish].PolygonVertices[whichfish].X;
						double z2 = (double)GlobalVar.OppTeam.Fishes[whichfish].PolygonVertices[whichfish].Z;
						for (int j = 0; j < 9; j++)
						{
							double num3 = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.X;
							double num4 = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z;
							bool flag7 = Compute.GetDistance(num3, num4, x, z) < num && Compute.GetDistance(num3, num4, x2, z2) < 180.0;
							if (flag7)
							{
								num = Compute.GetDistance(num3, num4, x, z);
								result = j;
							}
						}
					}
					else
					{
						bool flag8 = 30 == i;
						if (flag8)
						{
							double num5 = -1000.0;
							for (int j = 0; j < 9; j++)
							{
								double num3 = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.X;
								double num4 = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z;
								bool flag9 = this.whether_in_myforbiddenareasmall(num3, num4);
								if (flag9)
								{
									bool flag10 = num4 > num5;
									if (flag10)
									{
										num5 = num4;
										result = j;
									}
								}
							}
						}
						else
						{
							bool flag11 = 31 == i;
							if (flag11)
							{
								double num6 = 1000.0;
								for (int j = 0; j < 9; j++)
								{
									double num3 = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.X;
									double num4 = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z;
									bool flag12 = this.whether_in_myforbiddenareasmall(num3, num4);
									if (flag12)
									{
										bool flag13 = num4 < num6;
										if (flag13)
										{
											num6 = num4;
											result = j;
										}
									}
								}
							}
							else
							{
								bool flag14 = 40 == i;
								if (flag14)
								{
									double num5 = -1000.0;
									for (int j = 0; j < 9; j++)
									{
										double num3 = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.X;
										double num4 = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z;
										bool flag15 = this.whether_in_myhome(num3, num4);
										if (flag15)
										{
											bool flag16 = num4 > num5;
											if (flag16)
											{
												num5 = num4;
												result = j;
											}
										}
									}
								}
								else
								{
									bool flag17 = 41 == i;
									if (flag17)
									{
										double num6 = 1000.0;
										for (int j = 0; j < 9; j++)
										{
											double num3 = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.X;
											double num4 = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z;
											bool flag18 = this.whether_in_myhome(num3, num4);
											if (flag18)
											{
												bool flag19 = num4 < num6;
												if (flag19)
												{
													num6 = num4;
													result = j;
												}
											}
										}
									}
									else
									{
										bool flag20 = 50 == i;
										if (flag20)
										{
											double num5 = -1000.0;
											for (int j = 0; j < 9; j++)
											{
												double num3 = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.X;
												double num4 = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z;
												bool flag21 = this.whether_in_myforbiddenareabig(num3);
												if (flag21)
												{
													bool flag22 = num4 > num5;
													if (flag22)
													{
														num5 = num4;
														result = j;
													}
												}
											}
										}
										else
										{
											bool flag23 = 51 == i;
											if (flag23)
											{
												double num6 = 1000.0;
												for (int j = 0; j < 9; j++)
												{
													double num3 = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.X;
													double num4 = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z;
													bool flag24 = this.whether_in_myforbiddenareabig(num3);
													if (flag24)
													{
														bool flag25 = num4 < num6;
														if (flag25)
														{
															num6 = num4;
															result = j;
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00003550 File Offset: 0x00001750
		public void runway(int which, double laterx, double laterz, double dv)
		{
			GlobalVar.decisions[which].VCode = 15;
			double num = (double)GlobalVar.MyTeam.Fishes[which].PolygonVertices[0].X;
			double num2 = (double)GlobalVar.MyTeam.Fishes[which].PolygonVertices[0].Z;
			double num3 = (double)GlobalVar.MyTeam.Fishes[which].BodyDirectionRad;
			double num4 = (double)GlobalVar.MyTeam.Fishes[which].VelocityMmPs;
			double num5 = (double)GlobalVar.MyTeam.Fishes[which].AngularVelocityRadPs;
			int[] array = new int[]
			{
				0,
				10,
				35,
				67,
				98,
				112,
				135,
				154,
				175,
				227,
				273,
				291,
				298,
				294,
				307,
				317
			};
			double num6 = Math.Sqrt((num2 - laterz) * (num2 - laterz) + (num - laterx) * (num - laterx));
			double num7 = Math.Atan((laterz - num2) / (laterx - num));
			bool flag = num > laterx && num2 > laterz;
			if (flag)
			{
				num7 -= GlobalVar.PI;
			}
			bool flag2 = num > laterx && num2 < laterz;
			if (flag2)
			{
				num7 += GlobalVar.PI;
			}
			bool flag3 = dv > 317.0;
			if (flag3)
			{
				dv = 317.0;
			}
			bool flag4 = dv < 0.0;
			if (flag4)
			{
				dv = 0.0;
			}
			int i;
			for (i = 15; i > 0; i--)
			{
				double num8 = num + num4 * 0.1 * Math.Cos(num7);
				double num9 = num2 + num4 * 0.1 * Math.Sin(num7);
				double num10 = num4;
				GlobalVar.n = 0;
				while (num10 > dv + 5.0 && GlobalVar.n < 25)
				{
					num10 = num10 * 0.9 + (double)array[i] * 0.1;
					num8 += num10 * 0.1 * Math.Cos(num7);
					num9 += num10 * 0.1 * Math.Sin(num7);
					GlobalVar.n++;
				}
				double num11 = Math.Sqrt((num2 - num9) * (num2 - num9) + (num - num8) * (num - num8));
				bool flag5 = num11 < num6;
				if (flag5)
				{
					break;
				}
			}
			bool flag6 = Math.Abs(num7 - num3) > 0.4;
			if (flag6)
			{
				i = 1;
			}
			GlobalVar.decisions[which].VCode = i;
			GlobalVar.BaAction.Angle(which, num7);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x0000380C File Offset: 0x00001A0C
		public int whether_CornerChoseBall(double location_x, double location_z)
		{
			bool flag = location_x > 949.0 && location_z > 670.0;
			int result;
			if (flag)
			{
				result = 2;
			}
			else
			{
				bool flag2 = location_x > 949.0 && location_z < -670.0;
				if (flag2)
				{
					result = 1;
				}
				else
				{
					result = 0;
				}
			}
			return result;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00003868 File Offset: 0x00001A68
		public void chosecornerInterfereBall(int whichfish, int upDown)
		{
			double num = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
			double num2 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
			double num3 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].X;
			double num4 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
			double num5 = (double)GlobalVar.MyTeam.Fishes[whichfish].VelocityMmPs;
			double num6 = (double)GlobalVar.MyTeam.Fishes[whichfish].VelocityDirectionRad;
			double pi = GlobalVar.PI;
			bool flag = upDown == 0;
			int num7;
			if (flag)
			{
				num7 = 1;
			}
			else
			{
				num7 = -1;
			}
			GlobalVar.corner[whichfish] = 0;
			GlobalVar.corner_help[whichfish] = 0;
			double num8 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
			double num9 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
			double num10 = (double)GlobalVar.MyTeam.Fishes[whichfish].VelocityDirectionRad;
			bool flag2 = num8 > 1250.0 && this.juli(num8, num9, 1500.0, (double)(num7 * 620)) <= 200.0;
			if (flag2)
			{
				GlobalVar.chooseinterfereBallStage[whichfish] = 1;
				bool flag3 = upDown == 0;
				if (flag3)
				{
					GlobalVar.chooseinterfereBallStage_Down[whichfish] = 1;
				}
				else
				{
					GlobalVar.chooseinterfereBallStage_Up[whichfish] = 1;
				}
			}
			bool flag4 = GlobalVar.chooseinterfereBallStage[whichfish] == 1 && num8 < 650.0;
			if (flag4)
			{
				GlobalVar.chooseinterfereBallStage[whichfish] = 0;
				bool flag5 = upDown == 0;
				if (flag5)
				{
					GlobalVar.chooseinterfereBallStage_Down[whichfish] = 0;
				}
				else
				{
					GlobalVar.chooseinterfereBallStage_Up[whichfish] = 0;
				}
			}
			bool flag6 = num9 < 500.0 && num9 > -500.0 && num8 < -980.0;
			if (flag6)
			{
				this.Position(whichfish, -1300.0, 750.0, 300.0);
			}
			else
			{
				bool flag7 = num8 < 1350.0;
				if (flag7)
				{
					bool flag8 = num8 < 1100.0;
					if (flag8)
					{
						this.Position(whichfish, 1200.0, (double)(num7 * 620), 300.0);
					}
					else
					{
						bool flag9 = num8 > 1100.0;
						if (flag9)
						{
							this.Position(whichfish, 1500.0, (double)(num7 * 620), 300.0);
						}
					}
				}
			}
			bool flag10 = GlobalVar.chooseinterfereBallStage[whichfish] == 1;
			if (flag10)
			{
				int num11 = this.TransfromAngletoTCode((double)num7 * 2.0 - num6);
				int num12 = Math.Abs(7 - num11);
				bool flag11 = Math.Abs(num6) > 1.85 && Math.Abs(num6) < 2.15;
				if (flag11)
				{
					GlobalVar.decisions[whichfish].TCode = num11;
					GlobalVar.decisions[whichfish].VCode = 11 - num12;
					bool flag12 = num7 == -1;
					if (flag12)
					{
						GlobalVar.decisions[whichfish].VCode = 11 - num12;
					}
				}
				else
				{
					bool flag13 = Math.Abs(num6) > 2.0;
					if (flag13)
					{
						GlobalVar.decisions[whichfish].TCode = num11;
						num12 = 5 - num12;
						bool flag14 = num12 < 1;
						if (flag14)
						{
							num12 = 1;
						}
						GlobalVar.decisions[whichfish].VCode = num12;
					}
					else
					{
						GlobalVar.decisions[whichfish].TCode = num11;
						bool flag15 = num12 >= 2;
						if (flag15)
						{
							num12 = 2;
						}
						GlobalVar.decisions[whichfish].VCode = 10 - num12;
					}
				}
			}
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00003C7C File Offset: 0x00001E7C
		public bool whether_area_CornerChoseBall(double location_x, double location_z)
		{
			return location_x > 949.0 && Math.Abs(location_z) <= 600.0;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00003CBC File Offset: 0x00001EBC
		public bool whether_area_CornerChoseBall2(double location_x, double location_z)
		{
			return location_x > 949.0 && Math.Abs(location_z) <= 560.0;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00003CFC File Offset: 0x00001EFC
		public void position3(int which, double dx, double dz, double dv)
		{
			double num = (double)GlobalVar.MyTeam.Fishes[which].VelocityDirectionRad;
			double num2 = (double)GlobalVar.MyTeam.Fishes[which].PositionMm.X + (double)GlobalVar.Fish_centertohead * Math.Cos(num);
			double num3 = (double)GlobalVar.MyTeam.Fishes[which].PositionMm.Z + (double)GlobalVar.Fish_centertohead * Math.Sin(num);
			double num4 = (double)GlobalVar.MyTeam.Fishes[which].VelocityMmPs;
			double num5 = (double)GlobalVar.MyTeam.Fishes[which].AngularVelocityRadPs;
			double[] vTable = GlobalVar.vTable;
			double[] tTable = GlobalVar.tTable;
			double pi = GlobalVar.PI;
			double num6 = num2 + num4 * Math.Cos(num) * 0.1;
			double num7 = num3 + num4 * Math.Sin(num) * 0.1;
			double num8 = num + num5 * 0.1;
			bool flag = dv < 0.0;
			if (flag)
			{
				dv = 0.0;
			}
			bool flag2 = dv > 314.0;
			if (flag2)
			{
				dv = 314.0;
			}
			double num9 = Math.Sqrt((dx - num2) * (dx - num2) + (dz - num3) * (dz - num3));
			double num10 = Math.Sqrt((dx - num6) * (dx - num6) + (dz - num7) * (dz - num7));
			int i;
			for (i = 15; i > 1; i--)
			{
				double num11 = num4 * 0.9 + vTable[i] * 0.1;
				double num12 = 0.0;
				int num13 = 0;
				while (num11 > dv && num13 < 23)
				{
					num13++;
					num12 += num11;
					num11 = 0.9 * num11;
				}
				bool flag3 = num12 * 0.1 <= num10;
				if (flag3)
				{
					break;
				}
			}
			GlobalVar.decisions[which].VCode = i;
			double num14 = Math.Atan2(dz - num7, dx - num6);
			double num15 = num14 - num8;
			bool flag4 = num15 > pi;
			if (flag4)
			{
				num15 -= 2.0 * pi;
			}
			bool flag5 = num15 < -pi;
			if (flag5)
			{
				num15 += 2.0 * pi;
			}
			bool flag6 = num15 > 0.0;
			if (flag6)
			{
				for (i = 14; i > 0; i--)
				{
					double num16 = num5 * 0.9 + tTable[i] * 0.1;
					bool flag7 = num5 < 0.0 && num16 < 0.0;
					if (flag7)
					{
						break;
					}
					double num17 = 0.0;
					bool flag8 = num16 > 0.0;
					if (!flag8)
					{
						break;
					}
					while (num16 > 0.0)
					{
						num17 += num16;
						num16 = 0.9 * num16 + tTable[0] * 0.1;
					}
					bool flag9 = num17 * 0.1 <= num15;
					if (flag9)
					{
						break;
					}
				}
			}
			else
			{
				for (i = 0; i < 14; i++)
				{
					double num16 = num5 * 0.9 + tTable[i] * 0.1;
					bool flag10 = num5 > 0.0 && num16 >= 0.0;
					if (flag10)
					{
						break;
					}
					double num17 = 0.0;
					bool flag11 = num16 > 0.0;
					if (flag11)
					{
						break;
					}
					while (num16 < 0.0)
					{
						num17 += num16;
						num16 = 0.9 * num16 + tTable[14] * 0.1;
					}
					bool flag12 = num17 * 0.1 >= num15;
					if (flag12)
					{
						break;
					}
				}
			}
			GlobalVar.decisions[which].TCode = i;
			bool flag13 = GlobalVar.decisions[which].VCode > 15;
			if (flag13)
			{
				GlobalVar.decisions[which].VCode = 15;
			}
			bool flag14 = GlobalVar.decisions[which].VCode < 0;
			if (flag14)
			{
				GlobalVar.decisions[which].VCode = 0;
			}
			bool flag15 = GlobalVar.decisions[which].TCode > 15;
			if (flag15)
			{
				GlobalVar.decisions[which].TCode = 15;
			}
			bool flag16 = GlobalVar.decisions[which].TCode < 0;
			if (flag16)
			{
				GlobalVar.decisions[which].TCode = 0;
			}
			num15 = Math.Abs(num15);
			num15 += 0.651;
			bool flag17 = num15 > 1.0;
			if (flag17)
			{
				GlobalVar.decisions[which].VCode = (int)((double)GlobalVar.decisions[which].VCode / (num15 * num15 + 1.0));
			}
			bool flag18 = GlobalVar.decisions[which].TCode != 7 && GlobalVar.decisions[which].VCode == 0;
			if (flag18)
			{
				GlobalVar.decisions[which].VCode = 1;
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00004308 File Offset: 0x00002508
		public void dribble4(int which, int whichball, double dx, double dz)
		{
			double num = 1.0;
			bool flag = whichball >= 0 && whichball <= 2;
			if (flag)
			{
				num = num * 62.0 / 58.0;
			}
			else
			{
				bool flag2 = whichball >= 3 && whichball <= 6;
				if (flag2)
				{
					num = num * 78.0 / 58.0;
				}
			}
			double pi = GlobalVar.PI;
			RoboFish roboFish = GlobalVar.MyTeam.Fishes[which];
			double num2 = (double)roboFish.VelocityDirectionRad;
			double num3 = (double)roboFish.PositionMm.X;
			double num4 = (double)roboFish.PositionMm.Z;
			double num5 = (double)roboFish.VelocityMmPs;
			double num6 = (double)roboFish.AngularVelocityRadPs;
			double num7 = (double)GlobalVar.mission.EnvRef.Balls[whichball].VelocityDirectionRad;
			double num8 = (double)GlobalVar.mission.EnvRef.Balls[whichball].VelocityMmPs;
			double num9 = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.X;
			double num10 = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.Z;
			num3 += num5 * Math.Cos(num2) * 0.1;
			num4 += num5 * Math.Sin(num2) * 0.1;
			num2 += num6 * 0.1;
			num9 += (double)GlobalVar.mission.EnvRef.Balls[0].VelocityMmPs * Math.Cos(num7) * 0.1;
			num10 += (double)GlobalVar.mission.EnvRef.Balls[0].VelocityMmPs * Math.Sin(num7) * 0.1;
			double num11 = num3 + (double)GlobalVar.Fish_centertohead * Math.Cos(num2);
			double num12 = num4 + (double)GlobalVar.Fish_centertohead * Math.Sin(num2);
			bool flag3 = dx > 1900.0 && Compute.GetDistance(num11, num12, dx, dz) > 300.0 && Math.Abs(num12) >= 200.0 && num11 > 1500.0 && Math.Abs(num12) < 900.0;
			if (flag3)
			{
				Point2D point2D = new Point2D();
				double angleRad = Compute.GetAngleRad(num11, num12, dx, dz);
				dx += 550.0 * Math.Cos(angleRad);
				dz += 550.0 * Math.Sin(angleRad);
			}
			else
			{
				bool flag4 = dx > 1900.0 && Compute.GetDistance(num11, num12, dx, dz) > 300.0 && num11 > 1500.0 && Math.Abs(num12) < 900.0;
				if (flag4)
				{
					dx += 1000.0;
				}
			}
			double num13 = Compute.GetAngleRad(num9, num10, dx, dz);
			double num14 = Math.Atan2(num10 - num4, num9 - num3);
			double num15 = num13 - num14;
			bool flag5 = num15 < -pi;
			if (flag5)
			{
				num15 += 2.0 * pi;
			}
			bool flag6 = num15 > pi;
			if (flag6)
			{
				num15 -= 2.0 * pi;
			}
			bool flag7 = num15 > pi / 2.0;
			if (flag7)
			{
				num13 = num14 + pi / 2.0;
				num15 = pi / 2.0;
			}
			bool flag8 = num15 < -pi / 2.0;
			if (flag8)
			{
				num13 = num14 - pi / 2.0;
				num15 = -pi / 2.0;
			}
			double num16 = 30.0 + (num15 / 1.5 + 0.2) * (num15 / 1.5 + 0.2) * 35.0;
			num16 *= num;
			double angleRad2 = Compute.GetAngleRad(num3, num4, num9, num10);
			Point2D point2D2 = new Point2D(0.0, 0.0);
			point2D2.x = num9 - num16 * Math.Cos(num13);
			point2D2.z = num10 - num16 * Math.Sin(num13);
			num16 = 30.0;
			num16 *= num;
			double angleRad3 = Compute.GetAngleRad(num3, num4, point2D2.x, point2D2.z);
			double angleRad4 = Compute.GetAngleRad(num11, num12, point2D2.x, point2D2.z);
			double num17 = Compute.FormatAngleRad(angleRad4 - num2);
			double num18 = Math.Sqrt((num11 - point2D2.x) * (num11 - point2D2.x) + (num12 - point2D2.z) * (num12 - point2D2.z));
			double num19 = num9 - 50.0 * num * Math.Cos(num13);
			double num20 = num10 - 50.0 * num * Math.Sin(num13);
			Point2D lineAcrossPoint = Compute.GetLineAcrossPoint(num3, num4, num2 / pi * 180.0, num19, num20, 90.0 + num13 / pi * 180.0);
			double num21 = Math.Sqrt((lineAcrossPoint.x - num9) * (lineAcrossPoint.x - num9) + (lineAcrossPoint.z - num10) * (lineAcrossPoint.z - num10));
			Point2D point2D3 = new Point2D();
			Point2D point2D4 = new Point2D();
			point2D3.x = num19 - 30.0 * num * Math.Cos(pi / 2.0 + num13);
			point2D3.z = num20 - 30.0 * num * Math.Sin(pi / 2.0 + num13);
			point2D4.x = num19 - 30.0 * num * Math.Cos(-pi / 2.0 + num13);
			point2D4.z = num20 - 30.0 * num * Math.Sin(-pi / 2.0 + num13);
			double angle = Compute.GetAngle(num9, num10, point2D3.x, point2D3.z);
			double angle2 = Compute.GetAngle(num9, num10, point2D4.x, point2D4.z);
			double ang = Compute.FormatAngle(num2 * 180.0 / pi + 180.0);
			Point2D point2D5 = new Point2D();
			Point2D point2D6 = new Point2D();
			double num22 = 42.0 * num;
			point2D5.x = num19 + 10.0 * num * Math.Cos(num13) - num22 * Math.Cos(pi / 2.0 + num13);
			point2D5.z = num20 + 10.0 * num * Math.Sin(num13) - num22 * Math.Sin(pi / 2.0 + num13);
			point2D6.x = num19 + 10.0 * num * Math.Cos(num13) - num22 * Math.Cos(-pi / 2.0 + num13);
			point2D6.z = num20 + 10.0 * num * Math.Sin(num13) - num22 * Math.Sin(-pi / 2.0 + num13);
			double angle3 = Compute.GetAngle(num9, num10, point2D5.x, point2D5.z);
			double angle4 = Compute.GetAngle(num9, num10, point2D6.x, point2D6.z);
			bool flag9 = (num18 < 150.0 * num && Math.Abs(num17 / pi * 180.0) > 15.0 && (num21 > 54.0 || !Compute.IsAngleDuring(angle3, angle4, ang))) || Math.Abs(num17 / pi * 180.0) > 90.0;
			if (flag9)
			{
				GlobalVar.decisions[which].VCode = 1;
				this.Angle(which, angleRad3);
				this.KeepV(which, 1.0);
			}
			else
			{
				double num23 = Compute.FormatAngleRad(2.0 * pi + num13 - angleRad2);
				double num24 = Compute.FormatAngleRad(2.0 * pi + angleRad2 - num2);
				bool flag10 = num18 < 300.0 * num && Math.Abs(num23 / pi * 180.0) > 20.0 && Math.Abs(num23 / pi * 180.0) < 110.0 && num23 * num24 > 0.0 && Math.Abs(num24 / pi * 180.0) < 30.0;
				if (flag10)
				{
					bool flag11 = Math.Abs(num23 / pi * 180.0) < 90.0;
					if (flag11)
					{
						this.Angle(which, angleRad3);
						this.KeepV(which, 150.0);
					}
					else
					{
						this.Angle(which, angleRad3);
						this.KeepV(which, 180.0);
					}
				}
				else
				{
					bool flag12 = num18 < 150.0;
					if (flag12)
					{
						this.Angle(which, angleRad3);
						this.KeepV(which, 200.0);
					}
					else
					{
						this.position3(which, point2D2.x, point2D2.z, 270.0);
					}
				}
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00004CB0 File Offset: 0x00002EB0
		public void Dribble(int which, int whichball, double dx, double dz)
		{
			// 🔥 5分钟后（Paishu >= 3000），将运球终点从小禁区外改到球门内
			bool isAfter5Min = GlobalVar.Paishu >= 3000;
			bool isTargetOutsideGoal = dx <= -1400.0;  // 目标点在小禁区外（x <= -1400）
			if (isAfter5Min && isTargetOutsideGoal)
			{
				// 将目标点改到球门内
				dx = -1037.0;  // 球门中心x坐标
				// z坐标保持方向，但限制在球门范围内（|z| < 400）
				if (dz > 400.0)
					dz = 400.0;
				else if (dz < -400.0)
					dz = -400.0;
				// 如果原来的z坐标在合理范围内，保持原值
				dz = this.ChooseOpenGoalLaneZ(whichball, dz);
			}
			
			double num = 1.0;
			double num2 = (double)GlobalVar.balls[whichball].PositionMm.X;
			double num3 = (double)GlobalVar.balls[whichball].PositionMm.Z;
			double num4 = (double)GlobalVar.MyTeam.Fishes[which].PositionMm.X;
			double num5 = (double)GlobalVar.MyTeam.Fishes[which].PositionMm.Z;
			double angleRad = Compute.GetAngleRad(num2, num3, dx, dz);
			double angleRad2 = Compute.GetAngleRad(num4, num5, num2, num3);
			Point2D point2D = new Point2D();
			Point2D point2D2 = new Point2D();
			Point2D point2D3 = new Point2D();
			double num6 = Compute.GetDistance(num2, num3, dx, dz);
			bool flag = num6 > 2000.0;
			if (flag)
			{
				num6 = 2000.0;
			}
			double num7 = num6 / 4.0 * num;
			point2D.x = dx + num7 * Math.Cos(angleRad + GlobalVar.PI / 2.0);
			point2D.z = dz + num7 * Math.Sin(angleRad + GlobalVar.PI / 2.0);
			point2D2.x = dx - num7 * Math.Cos(angleRad + GlobalVar.PI / 2.0);
			point2D2.z = dz - num7 * Math.Sin(angleRad + GlobalVar.PI / 2.0);
			Point2D lineAcrossPoint = Compute.GetLineAcrossPoint(num4, num5, angleRad2 * 180.0 / GlobalVar.PI, dx, dz, angleRad * 180.0 / GlobalVar.PI + 90.0);
			double angleRad3 = Compute.GetAngleRad(num4, num5, point2D.x, point2D.z);
			double angleRad4 = Compute.GetAngleRad(num4, num5, point2D2.x, point2D2.z);
			double num8 = Math.Abs(Compute.FormatAngleRad(angleRad2 - angleRad3));
			double num9 = Math.Abs(Compute.FormatAngleRad(angleRad2 - angleRad4));
			bool flag2 = Compute.IsAngleDuring(angleRad3 * 180.0 / GlobalVar.PI, angleRad4 * 180.0 / GlobalVar.PI, angleRad2 * 180.0 / GlobalVar.PI);
			if (flag2)
			{
				point2D3.x = lineAcrossPoint.x;
				point2D3.z = lineAcrossPoint.z;
			}
			else
			{
				bool flag3 = num8 < num9;
				if (flag3)
				{
					point2D3.x = point2D.x;
					point2D3.z = point2D.z;
				}
				else
				{
					point2D3.x = point2D2.x;
					point2D3.z = point2D2.z;
				}
			}
			this.dribble4(which, whichball, point2D3.x, point2D3.z);
		}

		private double ChooseOpenGoalLaneZ(int targetBallId, double originalTargetZ)
		{
			double[] candidateLaneZ = new double[] { -320.0, 0.0, 320.0 };
			double selectedLaneZ = originalTargetZ;
			double largestClearance = -1.0;
			bool hasBallInGoal = false;

			for (int candidateIndex = 0; candidateIndex < candidateLaneZ.Length; candidateIndex++)
			{
				double nearestBallDistanceZ = 10000.0;
				for (int ballIndex = 0; ballIndex < GlobalVar.balls.Length; ballIndex++)
				{
					if (ballIndex == targetBallId)
					{
						continue;
					}

					double ballX = (double)GlobalVar.balls[ballIndex].PositionMm.X;
					double ballZ = (double)GlobalVar.balls[ballIndex].PositionMm.Z;
					if (ballX > -1500.0 && ballX < -930.0 && Math.Abs(ballZ) < 700.0)
					{
						hasBallInGoal = true;
						double distanceZ = Math.Abs(candidateLaneZ[candidateIndex] - ballZ);
						if (distanceZ < nearestBallDistanceZ)
						{
							nearestBallDistanceZ = distanceZ;
						}
					}
				}

				if (nearestBallDistanceZ > largestClearance)
				{
					largestClearance = nearestBallDistanceZ;
					selectedLaneZ = candidateLaneZ[candidateIndex];
				}
			}

			if (!hasBallInGoal)
			{
				return originalTargetZ;
			}
			return selectedLaneZ;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00004F70 File Offset: 0x00003170
		public bool whether_in_oppcornerarea(double location_x, double location_z)
		{
			return Math.Abs(location_z) > 560.0 && location_x > 890.0;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00004FAC File Offset: 0x000031AC
		public void KeepV(int which, double dv)
		{
			double num = dv;
			double num2 = (double)GlobalVar.MyTeam.Fishes[which].PositionMm.X;
			double num3 = (double)GlobalVar.MyTeam.Fishes[which].PositionMm.Z;
			double num4 = (double)GlobalVar.MyTeam.Fishes[which].VelocityMmPs;
			double num5 = (double)GlobalVar.MyTeam.Fishes[which].AngularVelocityRadPs;
			double num6 = (double)GlobalVar.MyTeam.Fishes[which].BodyDirectionRad;
			double[] vTable = GlobalVar.vTable;
			double[] tTable = GlobalVar.tTable;
			double num7 = num2 + num4 * Math.Cos(num6) * 0.1;
			double num8 = num3 + num4 * Math.Sin(num6) * 0.1;
			double num9 = num6 + num5 * 0.1;
			bool flag = num < 0.0;
			if (flag)
			{
				num = 0.0;
			}
			bool flag2 = num > 317.0;
			if (flag2)
			{
				num = 317.0;
			}
			int vcode = 15;
			double num10 = 318.0;
			for (int i = 15; i > 0; i--)
			{
				double num11 = num4 * 0.9 + vTable[i] * 0.1;
				bool flag3 = num10 > Math.Abs(num11 - num);
				if (flag3)
				{
					num10 = Math.Abs(num11 - num);
					vcode = i;
				}
			}
			GlobalVar.decisions[which].VCode = vcode;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00005154 File Offset: 0x00003354
		public void Angle(int which, double drad)
		{
			double num = 3.1415926535897931;
			double num2 = (double)GlobalVar.MyTeam.Fishes[which].PositionMm.X;
			double num3 = (double)GlobalVar.MyTeam.Fishes[which].PositionMm.Z;
			double num4 = (double)GlobalVar.MyTeam.Fishes[which].VelocityMmPs;
			double num5 = (double)GlobalVar.MyTeam.Fishes[which].AngularVelocityRadPs;
			double num6 = (double)GlobalVar.MyTeam.Fishes[which].VelocityDirectionRad;
			double[] tTable = GlobalVar.tTable;
			double num7 = num2 + num4 * Math.Cos(num6) * 0.1;
			double num8 = num3 + num4 * Math.Sin(num6) * 0.1;
			double num9 = num6 + num5 * 0.1;
			double num10 = drad - num9;
			bool flag = num10 > num;
			if (flag)
			{
				num10 -= 2.0 * num;
			}
			bool flag2 = num10 < -num;
			if (flag2)
			{
				num10 += 2.0 * num;
			}
			bool flag3 = num10 > 0.0;
			int i;
			if (flag3)
			{
				for (i = 15; i > 0; i--)
				{
					double num11 = num5 * 0.9 + tTable[i] * 0.1;
					bool flag4 = num5 < 0.0 && num11 < 0.0;
					if (flag4)
					{
						break;
					}
					double num12 = 0.0;
					bool flag5 = num11 > 0.0;
					if (!flag5)
					{
						break;
					}
					while (num11 > 0.0)
					{
						num12 += num11;
						num11 = 0.9 * num11 + tTable[0] * 0.1;
					}
					bool flag6 = num12 * 0.1 <= num10;
					if (flag6)
					{
						break;
					}
				}
			}
			else
			{
				for (i = 0; i < 15; i++)
				{
					double num11 = num5 * 0.9 + tTable[i] * 0.1;
					bool flag7 = num5 > 0.0 && num11 >= 0.0;
					if (flag7)
					{
						break;
					}
					double num12 = 0.0;
					bool flag8 = num11 > 0.0;
					if (flag8)
					{
						break;
					}
					while (num11 < 0.0)
					{
						num12 += num11;
						num11 = 0.9 * num11 + tTable[15] * 0.1;
					}
					bool flag9 = num12 * 0.1 >= num10;
					if (flag9)
					{
						break;
					}
				}
			}
			GlobalVar.decisions[which].TCode = i;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x0000548C File Offset: 0x0000368C
		public void Position(int which, double dx, double dz, double dv)
		{
			double num = (double)GlobalVar.MyTeam.Fishes[which].VelocityDirectionRad;
			double num2 = (double)GlobalVar.MyTeam.Fishes[which].PositionMm.X + (double)GlobalVar.Fish_centertohead * Math.Cos(num);
			double num3 = (double)GlobalVar.MyTeam.Fishes[which].PositionMm.Z + (double)GlobalVar.Fish_centertohead * Math.Sin(num);
			double num4 = (double)GlobalVar.MyTeam.Fishes[which].VelocityMmPs;
			double num5 = (double)GlobalVar.MyTeam.Fishes[which].AngularVelocityRadPs;
			double[] vTable = GlobalVar.vTable;
			double[] tTable = GlobalVar.tTable;
			double pi = GlobalVar.PI;
			double num6 = num2 + num4 * Math.Cos(num) * 0.1;
			double num7 = num3 + num4 * Math.Sin(num) * 0.1;
			double num8 = num + num5 * 0.1;
			bool flag = dv < 0.0;
			if (flag)
			{
				dv = 0.0;
			}
			bool flag2 = dv > 314.0;
			if (flag2)
			{
				dv = 314.0;
			}
			double num9 = Math.Sqrt((dx - num2) * (dx - num2) + (dz - num3) * (dz - num3));
			double num10 = Math.Sqrt((dx - num6) * (dx - num6) + (dz - num7) * (dz - num7));
			int i;
			for (i = 15; i > 1; i--)
			{
				double num11 = num4 * 0.9 + vTable[i] * 0.1;
				double num12 = 0.0;
				int num13 = 0;
				while (num11 > dv && num13 < 23)
				{
					num13++;
					num12 += num11;
					num11 = 0.9 * num11;
				}
				bool flag3 = num12 * 0.1 <= num10;
				if (flag3)
				{
					break;
				}
			}
			GlobalVar.decisions[which].VCode = i;
			double num14 = Math.Atan2(dz - num7, dx - num6);
			double num15 = num14 - num8;
			bool flag4 = num15 > pi;
			if (flag4)
			{
				num15 -= 2.0 * pi;
			}
			bool flag5 = num15 < -pi;
			if (flag5)
			{
				num15 += 2.0 * pi;
			}
			bool flag6 = num15 > 0.0;
			if (flag6)
			{
				for (i = 15; i > 0; i--)
				{
					double num16 = num5 * 0.9 + tTable[i] * 0.1;
					bool flag7 = num5 < 0.0 && num16 < 0.0;
					if (flag7)
					{
						break;
					}
					double num17 = 0.0;
					bool flag8 = num16 > 0.0;
					if (!flag8)
					{
						break;
					}
					while (num16 > 0.0)
					{
						num17 += num16;
						num16 = 0.9 * num16 + tTable[0] * 0.1;
					}
					bool flag9 = num17 * 0.1 <= 1.1 * num15;
					if (flag9)
					{
						break;
					}
				}
			}
			else
			{
				for (i = 0; i < 15; i++)
				{
					double num16 = num5 * 0.9 + tTable[i] * 0.1;
					bool flag10 = num5 > 0.0 && num16 >= 0.0;
					if (flag10)
					{
						break;
					}
					double num17 = 0.0;
					bool flag11 = num16 > 0.0;
					if (flag11)
					{
						break;
					}
					while (num16 < 0.0)
					{
						num17 += num16;
						num16 = 0.9 * num16 + tTable[15] * 0.1;
					}
					bool flag12 = num17 * 0.1 >= 0.9 * num15;
					if (flag12)
					{
						break;
					}
				}
			}
			GlobalVar.decisions[which].TCode = i;
			bool flag13 = GlobalVar.decisions[which].VCode > 15;
			if (flag13)
			{
				GlobalVar.decisions[which].VCode = 15;
			}
			bool flag14 = GlobalVar.decisions[which].VCode < 0;
			if (flag14)
			{
				GlobalVar.decisions[which].VCode = 0;
			}
			bool flag15 = GlobalVar.decisions[which].TCode > 15;
			if (flag15)
			{
				GlobalVar.decisions[which].TCode = 15;
			}
			bool flag16 = GlobalVar.decisions[which].TCode < 0;
			if (flag16)
			{
				GlobalVar.decisions[which].TCode = 0;
			}
			num15 = Math.Abs(num15);
			num15 += 0.651;
			bool flag17 = num15 > 1.0;
			if (flag17)
			{
				GlobalVar.decisions[which].VCode = (int)((double)GlobalVar.decisions[which].VCode / (num15 * num15 * num15 + 1.0));
			}
			bool flag18 = GlobalVar.decisions[which].TCode != 7 && GlobalVar.decisions[which].VCode == 0;
			if (flag18)
			{
				GlobalVar.decisions[which].VCode = 1;
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00005AB0 File Offset: 0x00003CB0
		public int ChoseBall(int fishID)
		{
			int num = GlobalVar.Bringing_BallID[fishID];
			num = this.UpgradeToHigherValueBall(fishID, num);
			bool flag = -1 == num || this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[num].PositionMm.X, (double)GlobalVar.balls[num].PositionMm.Z) || GlobalVar.leftScore[num] == 1 || GlobalVar.Bringing_BallID[1 - fishID] == num || GlobalVar.willbring_ballid[1 - fishID] == num || (GlobalVar.Paishu < 3000 && fishID == 0 && GlobalVar.mission.EnvRef.Balls[num].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[num].PositionMm.Z < -508f) || (GlobalVar.Paishu < 3000 && fishID == 1 && GlobalVar.mission.EnvRef.Balls[num].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[num].PositionMm.Z > 508f);
			if (flag)
			{
				double num2 = 4000.0;
				double num3 = 4000.0;
				int num4 = -1;
				int num5 = -1;
				for (int i = 0; i < 3; i++)
				{
					bool flag2 = fishID == 0 && GlobalVar.mission.EnvRef.Balls[i].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z < -508f;
					if (!flag2)
					{
						bool flag3 = fishID == 1 && GlobalVar.mission.EnvRef.Balls[i].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z > 508f;
						if (!flag3)
						{
							bool flag4 = GlobalVar.leftScore[i] != 1 && GlobalVar.Bringing_BallID[1 - fishID] != i && !this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z) && GlobalVar.interfereBallStage[fishID] == 0;
							if (flag4)
							{
								bool flag5 = fishID == 0;
								double num6;
								if (flag5)
								{
									num6 = this.juli((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z, -1500.0, 300.0);
								}
								else
								{
									num6 = this.juli((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z, -1500.0, -300.0);
								}
								bool flag6 = GlobalVar.Bringing_BallID[1 - fishID] != i;
								if (flag6)
								{
									bool flag7 = num6 < num3 && num6 > num2;
									if (flag7)
									{
										num3 = num6;
										num5 = i;
									}
									bool flag8 = num6 < num2;
									if (flag8)
									{
										num3 = num2;
										num2 = num6;
										num5 = num4;
										num4 = i;
									}
								}
							}
						}
					}
				}
				bool flag9 = num5 == -1 && num4 != -1;
				if (flag9)
				{
					num = num4;
				}
				else
				{
					bool flag10 = num4 == -1 && num5 != -1;
					if (flag10)
					{
						num = num5;
					}
					else
					{
						bool flag11 = num4 == -1 && num5 == -1;
						if (flag11)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag12 = num != -1;
				if (flag12)
				{
					bool flag13 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag13)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
				num2 = 4000.0;
				num3 = 4000.0;
				num4 = -1;
				num5 = -1;
				for (int j = 7; j < 9; j++)
				{
					bool flag14 = fishID == 0 && GlobalVar.mission.EnvRef.Balls[j].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z < -508f;
					if (!flag14)
					{
						bool flag15 = fishID == 1 && GlobalVar.mission.EnvRef.Balls[j].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z > 508f;
						if (!flag15)
						{
							bool flag16 = GlobalVar.leftScore[j] != 1 && GlobalVar.Bringing_BallID[1 - fishID] != j && !this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z) && GlobalVar.interfereBallStage[fishID] == 0;
							if (flag16)
							{
								bool flag17 = fishID == 0;
								double num6;
								if (flag17)
								{
									num6 = this.juli((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z, -1500.0, 300.0);
								}
								else
								{
									num6 = this.juli((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z, -1500.0, -300.0);
								}
								bool flag18 = GlobalVar.Bringing_BallID[1 - fishID] != j;
								if (flag18)
								{
									bool flag19 = num6 < num3 && num6 > num2;
									if (flag19)
									{
										num3 = num6;
										num5 = j;
									}
									bool flag20 = num6 < num2;
									if (flag20)
									{
										num3 = num2;
										num2 = num6;
										num5 = num4;
										num4 = j;
									}
								}
							}
						}
					}
				}
				bool flag21 = num5 == -1 && num4 != -1;
				if (flag21)
				{
					num = num4;
				}
				else
				{
					bool flag22 = num4 == -1 && num5 != -1;
					if (flag22)
					{
						num = num5;
					}
					else
					{
						bool flag23 = num4 == -1 && num5 == -1;
						if (flag23)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag24 = num != -1;
				if (flag24)
				{
					bool flag25 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag25)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
				num2 = 4000.0;
				num3 = 4000.0;
				num4 = -1;
				num5 = -1;
				int k = 3;
				while (k < 7)
				{
					bool flag26 = GlobalVar.teamId == 0;
					if (flag26)
					{
						bool flag27 = fishID == 0 && k == 3;
						if (!flag27)
						{
							bool flag28 = fishID == 1 && k == 6;
							if (!flag28)
							{
								goto IL_74A;
							}
						}
					}
					else
					{
						bool flag29 = GlobalVar.teamId == 1;
						if (!flag29)
						{
							goto IL_74A;
						}
						bool flag30 = fishID == 0 && k == 5;
						if (!flag30)
						{
							bool flag31 = fishID == 1 && k == 4;
							if (!flag31)
							{
								goto IL_74A;
							}
						}
					}
					IL_93E:
					k++;
					continue;
					IL_74A:
					bool flag32 = fishID == 0 && GlobalVar.mission.EnvRef.Balls[k].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[k].PositionMm.Z < -508f;
					if (flag32)
					{
						goto IL_93E;
					}
					bool flag33 = fishID == 1 && GlobalVar.mission.EnvRef.Balls[k].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[k].PositionMm.Z > 508f;
					if (flag33)
					{
						goto IL_93E;
					}
					bool flag34 = GlobalVar.leftScore[k] != 1 && GlobalVar.Bringing_BallID[1 - fishID] != k && !this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z) && GlobalVar.interfereBallStage[fishID] == 0;
					if (flag34)
					{
						bool flag35 = fishID == 0;
						double num6;
						if (flag35)
						{
							num6 = this.juli((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z, -1500.0, 300.0);
						}
						else
						{
							num6 = this.juli((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z, -1500.0, -300.0);
						}
						bool flag36 = GlobalVar.Bringing_BallID[1 - fishID] != k;
						if (flag36)
						{
							bool flag37 = num6 < num3 && num6 > num2;
							if (flag37)
							{
								num3 = num6;
								num5 = k;
							}
							bool flag38 = num6 < num2;
							if (flag38)
							{
								num3 = num2;
								num2 = num6;
								num5 = num4;
								num4 = k;
							}
						}
					}
					goto IL_93E;
				}
				bool flag39 = num5 == -1 && num4 != -1;
				if (flag39)
				{
					num = num4;
				}
				else
				{
					bool flag40 = num4 == -1 && num5 != -1;
					if (flag40)
					{
						num = num5;
					}
					else
					{
						bool flag41 = num4 == -1 && num5 == -1;
						if (flag41)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag42 = num != -1;
				if (flag42)
				{
					bool flag43 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag43)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
			}
			bool flag44 = GlobalVar.Bringing_BallID[fishID] != num;
			if (flag44)
			{
				GlobalVar.whether_change_to_test3[fishID] = 0;
			}
			bool flag45 = num == -1;
			int result;
			if (flag45)
			{
				result = num;
			}
			else
			{
				bool flag46 = GlobalVar.willbring_ballid[fishID] != -1 && GlobalVar.MyTeam.Fishes[fishID].PositionMm.X < 950f && Math.Abs(GlobalVar.MyTeam.Fishes[fishID].PolygonVertices[0].Z) > 850f && GlobalVar.leftScore[GlobalVar.willbring_ballid[fishID]] != 1;
				if (flag46)
				{
					num = GlobalVar.willbring_ballid[fishID];
				}
				bool flag47 = num == GlobalVar.willbring_ballid[fishID];
				if (flag47)
				{
					GlobalVar.willbring_ballid[fishID] = -1;
				}
				GlobalVar.Bringing_BallID[fishID] = num;
				result = num;
			}
			return result;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00006578 File Offset: 0x00004778
		public int ChoseBallplus(int fishID)
		{
			DebugRecord.ceshi(0, "被调用plus选球");
			int num = GlobalVar.Bringing_BallID[fishID];
			num = this.UpgradeToHigherValueBall(fishID, num);
			// 6分钟后(3600回合后)改为只限制对方小禁区(reduce)
			bool checkOppForbidden = GlobalVar.Paishu < 3600;
			bool oppForbiddenCheck = checkOppForbidden ? this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[num].PositionMm.X, (double)GlobalVar.balls[num].PositionMm.Z) : this.whether_in_oppforbiddenarea_reduce((double)GlobalVar.balls[num].PositionMm.X, (double)GlobalVar.balls[num].PositionMm.Z);
			bool flag = -1 == num || oppForbiddenCheck || GlobalVar.leftScore[num] == 1 || GlobalVar.Bringing_BallID[1 - fishID] == num || GlobalVar.willbring_ballid[1 - fishID] == num;
			if (flag)
			{
				double num2 = 4000.0;
				double num3 = 4000.0;
				int num4 = -1;
				int num5 = -1;
				for (int i = 0; i < 3; i++)
				{
					bool oppCheck_i = checkOppForbidden ? this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z) : this.whether_in_oppforbiddenarea_reduce((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z);
				bool flag2 = GlobalVar.leftScore[i] != 1 && GlobalVar.Bringing_BallID[1 - fishID] != i && !oppCheck_i && GlobalVar.interfereBallStage[fishID] == 0;
					if (flag2)
					{
						bool flag3 = fishID == 0;
						double num6;
						if (flag3)
						{
							num6 = this.juli((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z, -1500.0, 300.0);
						}
						else
						{
							num6 = this.juli((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z, -1500.0, -300.0);
						}
						bool flag4 = GlobalVar.Bringing_BallID[1 - fishID] != i;
						if (flag4)
						{
							bool flag5 = num6 < num3 && num6 > num2;
							if (flag5)
							{
								num3 = num6;
								num5 = i;
							}
							bool flag6 = num6 < num2;
							if (flag6)
							{
								num3 = num2;
								num2 = num6;
								num5 = num4;
								num4 = i;
							}
						}
					}
				}
				bool flag7 = num5 == -1 && num4 != -1;
				if (flag7)
				{
					num = num4;
				}
				else
				{
					bool flag8 = num4 == -1 && num5 != -1;
					if (flag8)
					{
						num = num5;
					}
					else
					{
						bool flag9 = num4 == -1 && num5 == -1;
						if (flag9)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag10 = num != -1;
				if (flag10)
				{
					bool flag11 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag11)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
				num2 = 4000.0;
				num3 = 4000.0;
				num4 = -1;
				num5 = -1;
				for (int j = 7; j < 9; j++)
				{
					bool oppCheck_j = checkOppForbidden ? this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z) : this.whether_in_oppforbiddenarea_reduce((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z);
				bool flag12 = GlobalVar.leftScore[j] != 1 && GlobalVar.Bringing_BallID[1 - fishID] != j && !oppCheck_j && GlobalVar.interfereBallStage[fishID] == 0;
					if (flag12)
					{
						bool flag13 = fishID == 0;
						double num6;
						if (flag13)
						{
							num6 = this.juli((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z, -1500.0, 300.0);
						}
						else
						{
							num6 = this.juli((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z, -1500.0, -300.0);
						}
						bool flag14 = GlobalVar.Bringing_BallID[1 - fishID] != j;
						if (flag14)
						{
							bool flag15 = num6 < num3 && num6 > num2;
							if (flag15)
							{
								num3 = num6;
								num5 = j;
							}
							bool flag16 = num6 < num2;
							if (flag16)
							{
								num3 = num2;
								num2 = num6;
								num5 = num4;
								num4 = j;
							}
						}
					}
				}
				bool flag17 = num5 == -1 && num4 != -1;
				if (flag17)
				{
					num = num4;
				}
				else
				{
					bool flag18 = num4 == -1 && num5 != -1;
					if (flag18)
					{
						num = num5;
					}
					else
					{
						bool flag19 = num4 == -1 && num5 == -1;
						if (flag19)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag20 = num != -1;
				if (flag20)
				{
					bool flag21 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag21)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
				num2 = 4000.0;
				num3 = 4000.0;
				num4 = -1;
				num5 = -1;
				for (int k = 3; k < 7; k++)
				{
					bool oppCheck_k = checkOppForbidden ? this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z) : this.whether_in_oppforbiddenarea_reduce((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z);
				bool flag22 = GlobalVar.leftScore[k] != 1 && GlobalVar.Bringing_BallID[1 - fishID] != k && !oppCheck_k && GlobalVar.interfereBallStage[fishID] == 0;
					if (flag22)
					{
						bool flag23 = fishID == 0;
						double num6;
						if (flag23)
						{
							num6 = this.juli((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z, -1500.0, 300.0);
						}
						else
						{
							num6 = this.juli((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z, -1500.0, -300.0);
						}
						bool flag24 = GlobalVar.Bringing_BallID[1 - fishID] != k;
						if (flag24)
						{
							bool flag25 = num6 < num3 && num6 > num2;
							if (flag25)
							{
								num3 = num6;
								num5 = k;
							}
							bool flag26 = num6 < num2;
							if (flag26)
							{
								num3 = num2;
								num2 = num6;
								num5 = num4;
								num4 = k;
							}
						}
					}
				}
				bool flag27 = num5 == -1 && num4 != -1;
				if (flag27)
				{
					num = num4;
				}
				else
				{
					bool flag28 = num4 == -1 && num5 != -1;
					if (flag28)
					{
						num = num5;
					}
					else
					{
						bool flag29 = num4 == -1 && num5 == -1;
						if (flag29)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag30 = num != -1;
				if (flag30)
				{
					bool flag31 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag31)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
			}
			bool flag32 = GlobalVar.Bringing_BallID[fishID] != num;
			if (flag32)
			{
				GlobalVar.whether_change_to_test3[fishID] = 0;
			}
			bool flag33 = num == -1;
			int result;
			if (flag33)
			{
				GlobalVar.Bringing_BallID[fishID] = -1;
				result = num;
			}
			else
			{
				bool flag34 = GlobalVar.willbring_ballid[fishID] != -1 && GlobalVar.MyTeam.Fishes[fishID].PositionMm.X < 950f && Math.Abs(GlobalVar.MyTeam.Fishes[fishID].PolygonVertices[0].Z) > 850f && GlobalVar.leftScore[GlobalVar.willbring_ballid[fishID]] != 1;
				if (flag34)
				{
					num = GlobalVar.willbring_ballid[fishID];
				}
				bool flag35 = num == GlobalVar.willbring_ballid[fishID];
				if (flag35)
				{
					GlobalVar.willbring_ballid[fishID] = -1;
				}
				GlobalVar.Bringing_BallID[fishID] = num;
				result = num;
			}
			return result;
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00006CD0 File Offset: 0x00004ED0
		public int ChoseBallplus_1(int fishID)
		{
			DebugRecord.ceshi(0, "被调用plus选球");
			int num = GlobalVar.Bringing_BallID[fishID];
			bool flag = -1 == num || GlobalVar.leftScore[num] == 1 || GlobalVar.Bringing_BallID[1 - fishID] == num || GlobalVar.willbring_ballid[1 - fishID] == num;
			if (flag)
			{
				double num2 = 4000.0;
				double num3 = 4000.0;
				int num4 = -1;
				int num5 = -1;
				for (int i = 7; i < 9; i++)
				{
					bool flag2 = GlobalVar.leftScore[i] != 1 && GlobalVar.Bringing_BallID[1 - fishID] != i && GlobalVar.interfereBallStage[fishID] == 0;
					if (flag2)
					{
						bool flag3 = fishID == 0;
						double num6;
						if (flag3)
						{
							num6 = this.juli((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z, -1500.0, 300.0);
						}
						else
						{
							num6 = this.juli((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z, -1500.0, -300.0);
						}
						bool flag4 = GlobalVar.Bringing_BallID[1 - fishID] != i;
						if (flag4)
						{
							bool flag5 = num6 < num3 && num6 > num2;
							if (flag5)
							{
								num3 = num6;
								num5 = i;
							}
							bool flag6 = num6 < num2;
							if (flag6)
							{
								num3 = num2;
								num2 = num6;
								num5 = num4;
								num4 = i;
							}
						}
					}
				}
				bool flag7 = num5 == -1 && num4 != -1;
				if (flag7)
				{
					num = num4;
				}
				else
				{
					bool flag8 = num4 == -1 && num5 != -1;
					if (flag8)
					{
						num = num5;
					}
					else
					{
						bool flag9 = num4 == -1 && num5 == -1;
						if (flag9)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag10 = num != -1;
				if (flag10)
				{
					bool flag11 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag11)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
				num2 = 4000.0;
				num3 = 4000.0;
				num4 = -1;
				num5 = -1;
				for (int j = 3; j < 7; j++)
				{
					bool flag12 = GlobalVar.leftScore[j] != 1 && GlobalVar.Bringing_BallID[1 - fishID] != j && GlobalVar.interfereBallStage[fishID] == 0;
					if (flag12)
					{
						bool flag13 = fishID == 0;
						double num6;
						if (flag13)
						{
							num6 = this.juli((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z, -1500.0, 300.0);
						}
						else
						{
							num6 = this.juli((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z, -1500.0, -300.0);
						}
						bool flag14 = GlobalVar.Bringing_BallID[1 - fishID] != j;
						if (flag14)
						{
							bool flag15 = num6 < num3 && num6 > num2;
							if (flag15)
							{
								num3 = num6;
								num5 = j;
							}
							bool flag16 = num6 < num2;
							if (flag16)
							{
								num3 = num2;
								num2 = num6;
								num5 = num4;
								num4 = j;
							}
						}
					}
				}
				bool flag17 = num5 == -1 && num4 != -1;
				if (flag17)
				{
					num = num4;
				}
				else
				{
					bool flag18 = num4 == -1 && num5 != -1;
					if (flag18)
					{
						num = num5;
					}
					else
					{
						bool flag19 = num4 == -1 && num5 == -1;
						if (flag19)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag20 = num != -1;
				if (flag20)
				{
					bool flag21 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag21)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
				num2 = 4000.0;
				num3 = 4000.0;
				num4 = -1;
				num5 = -1;
				for (int k = 0; k < 3; k++)
				{
					bool flag22 = GlobalVar.leftScore[k] != 1 && GlobalVar.Bringing_BallID[1 - fishID] != k && GlobalVar.interfereBallStage[fishID] == 0;
					if (flag22)
					{
						bool flag23 = fishID == 0;
						double num6;
						if (flag23)
						{
							num6 = this.juli((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z, -1500.0, 300.0);
						}
						else
						{
							num6 = this.juli((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z, -1500.0, -300.0);
						}
						bool flag24 = GlobalVar.Bringing_BallID[1 - fishID] != k;
						if (flag24)
						{
							bool flag25 = num6 < num3 && num6 > num2;
							if (flag25)
							{
								num3 = num6;
								num5 = k;
							}
							bool flag26 = num6 < num2;
							if (flag26)
							{
								num3 = num2;
								num2 = num6;
								num5 = num4;
								num4 = k;
							}
						}
					}
				}
				bool flag27 = num5 == -1 && num4 != -1;
				if (flag27)
				{
					num = num4;
				}
				else
				{
					bool flag28 = num4 == -1 && num5 != -1;
					if (flag28)
					{
						num = num5;
					}
					else
					{
						bool flag29 = num4 == -1 && num5 == -1;
						if (flag29)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag30 = num != -1;
				if (flag30)
				{
					bool flag31 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag31)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
			}
			bool flag32 = GlobalVar.Bringing_BallID[fishID] != num;
			if (flag32)
			{
				GlobalVar.whether_change_to_test3[fishID] = 0;
			}
			bool flag33 = num == -1;
			int result;
			if (flag33)
			{
				GlobalVar.Bringing_BallID[fishID] = -1;
				result = num;
			}
			else
			{
				bool flag34 = GlobalVar.willbring_ballid[fishID] != -1 && GlobalVar.MyTeam.Fishes[fishID].PositionMm.X < 950f && Math.Abs(GlobalVar.MyTeam.Fishes[fishID].PolygonVertices[0].Z) > 850f && GlobalVar.leftScore[GlobalVar.willbring_ballid[fishID]] != 1;
				if (flag34)
				{
					num = GlobalVar.willbring_ballid[fishID];
				}
				bool flag35 = num == GlobalVar.willbring_ballid[fishID];
				if (flag35)
				{
					GlobalVar.willbring_ballid[fishID] = -1;
				}
				GlobalVar.Bringing_BallID[fishID] = num;
				result = num;
			}
			return result;
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00007374 File Offset: 0x00005574
		public int ChoseBall2(int fishID)
		{
			int num = GlobalVar.Bringing_BallID[fishID];
			// 6分钟后(3600回合后)改为只限制对方小禁区(reduce)
			bool checkOppForbidden = GlobalVar.Paishu < 3600;
			bool oppForbiddenCheck2 = checkOppForbidden ? this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[num].PositionMm.X, (double)GlobalVar.balls[num].PositionMm.Z) : this.whether_in_oppforbiddenarea_reduce((double)GlobalVar.balls[num].PositionMm.X, (double)GlobalVar.balls[num].PositionMm.Z);
			bool flag = -1 == num || oppForbiddenCheck2 || this.whether_in_myforbiddenarea_reduce((double)GlobalVar.mission.EnvRef.Balls[num].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[num].PositionMm.Z) || GlobalVar.leftScore[num] == 1 || GlobalVar.Bringing_BallID[1 - fishID] == num || GlobalVar.willbring_ballid[1 - fishID] == num || (GlobalVar.Paishu < 3000 && GlobalVar.final == 0 && fishID == 0 && GlobalVar.mission.EnvRef.Balls[num].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[num].PositionMm.Z < -508f && (GlobalVar.Paishu >= 1500 || GlobalVar.MyTeam.Fishes[1 - fishID].PositionMm.Z <= 200f)) || (GlobalVar.Paishu < 3000 && GlobalVar.final == 0 && fishID == 1 && GlobalVar.mission.EnvRef.Balls[num].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[num].PositionMm.Z > 508f && (GlobalVar.Paishu >= 1500 || GlobalVar.MyTeam.Fishes[1 - fishID].PositionMm.Z >= -200f));
			if (flag)
			{
				double num2 = 4000.0;
				double num3 = 4000.0;
				int num4 = -1;
				int num5 = -1;
				for (int i = 0; i < 3; i++)
				{
					bool flag2 = GlobalVar.Paishu < 3000 && GlobalVar.final == 0 && fishID == 0 && GlobalVar.mission.EnvRef.Balls[i].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z < -508f;
					if (!flag2)
					{
						bool flag3 = GlobalVar.Paishu < 3000 && GlobalVar.final == 0 && fishID == 1 && GlobalVar.mission.EnvRef.Balls[i].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z > 508f;
						if (!flag3)
						{
							bool oppCheck2_i = checkOppForbidden ? this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z) : this.whether_in_oppforbiddenarea_reduce((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z);
						bool flag4 = !this.whether_in_myforbiddenarea_reduce((double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X, (double)(Math.Abs(GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z) - 30f)) && GlobalVar.Bringing_BallID[1 - fishID] != i && !oppCheck2_i && GlobalVar.leftScore[i] != 1 && GlobalVar.interfereBallStage[fishID] == 0;
							if (flag4)
							{
								bool flag5 = fishID == 0;
								double num6;
								if (flag5)
								{
									num6 = this.juli((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z, -1500.0, 300.0);
								}
								else
								{
									num6 = this.juli((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z, -1500.0, -300.0);
								}
								bool flag6 = GlobalVar.Bringing_BallID[1 - fishID] != i;
								if (flag6)
								{
									bool flag7 = num6 < num3 && num6 > num2;
									if (flag7)
									{
										num3 = num6;
										num5 = i;
									}
									bool flag8 = num6 < num2;
									if (flag8)
									{
										num3 = num2;
										num2 = num6;
										num5 = num4;
										num4 = i;
									}
								}
							}
						}
					}
				}
				bool flag9 = num5 == -1 && num4 != -1;
				if (flag9)
				{
					num = num4;
				}
				else
				{
					bool flag10 = num4 == -1 && num5 != -1;
					if (flag10)
					{
						num = num5;
					}
					else
					{
						bool flag11 = num4 == -1 && num5 == -1;
						if (flag11)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag12 = num != -1;
				if (flag12)
				{
					bool flag13 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag13)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
				num2 = 4000.0;
				num3 = 4000.0;
				num4 = -1;
				num5 = -1;
				for (int j = 7; j < 9; j++)
				{
					bool flag14 = GlobalVar.Paishu < 3000 && GlobalVar.final == 0 && fishID == 0 && GlobalVar.mission.EnvRef.Balls[j].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z < -508f;
					if (!flag14)
					{
						bool flag15 = GlobalVar.Paishu < 3000 && GlobalVar.final == 0 && fishID == 1 && GlobalVar.mission.EnvRef.Balls[j].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z > 508f;
						if (!flag15)
						{
							bool oppCheck2_j = checkOppForbidden ? this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z) : this.whether_in_oppforbiddenarea_reduce((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z);
						bool flag16 = !this.whether_in_myforbiddenarea_reduce((double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.X, (double)(Math.Abs(GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z) - 30f)) && GlobalVar.Bringing_BallID[1 - fishID] != j && !oppCheck2_j && GlobalVar.leftScore[j] != 1 && GlobalVar.interfereBallStage[fishID] == 0;
							if (flag16)
							{
								bool flag17 = fishID == 0;
								double num6;
								if (flag17)
								{
									num6 = this.juli((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z, -1500.0, 300.0);
								}
								else
								{
									num6 = this.juli((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z, -1500.0, -300.0);
								}
								bool flag18 = GlobalVar.Bringing_BallID[1 - fishID] != j;
								if (flag18)
								{
									bool flag19 = num6 < num3 && num6 > num2;
									if (flag19)
									{
										num3 = num6;
										num5 = j;
									}
									bool flag20 = num6 < num2;
									if (flag20)
									{
										num3 = num2;
										num2 = num6;
										num5 = num4;
										num4 = j;
									}
								}
							}
						}
					}
				}
				bool flag21 = num5 == -1 && num4 != -1;
				if (flag21)
				{
					num = num4;
				}
				else
				{
					bool flag22 = num4 == -1 && num5 != -1;
					if (flag22)
					{
						num = num5;
					}
					else
					{
						bool flag23 = num4 == -1 && num5 == -1;
						if (flag23)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag24 = num != -1;
				if (flag24)
				{
					bool flag25 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag25)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
				num2 = 4000.0;
				num3 = 4000.0;
				num4 = -1;
				num5 = -1;
				int k = 3;
				while (k < 7)
				{
					bool flag26 = GlobalVar.teamId == 0 && GlobalVar.final == 0;
					if (flag26)
					{
						bool flag27 = fishID == 0 && k == 3;
						if (!flag27)
						{
							bool flag28 = fishID == 1 && k == 6;
							if (!flag28)
							{
								goto IL_92A;
							}
						}
					}
					else
					{
						bool flag29 = GlobalVar.teamId == 1 && GlobalVar.final == 0;
						if (!flag29)
						{
							goto IL_92A;
						}
						bool flag30 = fishID == 0 && k == 5;
						if (!flag30)
						{
							bool flag31 = fishID == 1 && k == 4;
							if (!flag31)
							{
								goto IL_92A;
							}
						}
					}
					IL_B99:
					k++;
					continue;
					IL_92A:
					bool flag32 = GlobalVar.Paishu < 3000 && GlobalVar.final == 0 && fishID == 0 && GlobalVar.mission.EnvRef.Balls[k].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[k].PositionMm.Z < -508f;
					if (flag32)
					{
						goto IL_B99;
					}
					bool flag33 = GlobalVar.Paishu < 3000 && GlobalVar.final == 0 && fishID == 1 && GlobalVar.mission.EnvRef.Balls[k].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[k].PositionMm.Z > 508f;
					if (flag33)
					{
						goto IL_B99;
					}
					bool oppCheck2_k = checkOppForbidden ? this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z) : this.whether_in_oppforbiddenarea_reduce((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z);
				bool flag34 = !this.whether_in_myforbiddenarea_reduce((double)GlobalVar.mission.EnvRef.Balls[k].PositionMm.X, (double)(Math.Abs(GlobalVar.mission.EnvRef.Balls[k].PositionMm.Z) - 30f)) && GlobalVar.Bringing_BallID[1 - fishID] != k && !oppCheck2_k && GlobalVar.leftScore[k] != 1 && GlobalVar.interfereBallStage[fishID] == 0;
					if (flag34)
					{
						bool flag35 = fishID == 0;
						double num6;
						if (flag35)
						{
							num6 = this.juli((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z, -1500.0, 300.0);
						}
						else
						{
							num6 = this.juli((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z, -1500.0, -300.0);
						}
						bool flag36 = GlobalVar.Bringing_BallID[1 - fishID] != k;
						if (flag36)
						{
							bool flag37 = num6 < num3 && num6 > num2;
							if (flag37)
							{
								num3 = num6;
								num5 = k;
							}
							bool flag38 = num6 < num2;
							if (flag38)
							{
								num3 = num2;
								num2 = num6;
								num5 = num4;
								num4 = k;
							}
						}
					}
					goto IL_B99;
				}
				bool flag39 = num5 == -1 && num4 != -1;
				if (flag39)
				{
					num = num4;
				}
				else
				{
					bool flag40 = num4 == -1 && num5 != -1;
					if (flag40)
					{
						num = num5;
					}
					else
					{
						bool flag41 = num4 == -1 && num5 == -1;
						if (flag41)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag42 = num != -1;
				if (flag42)
				{
					bool flag43 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag43)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
			}
			bool flag44 = GlobalVar.Bringing_BallID[fishID] != num;
			if (flag44)
			{
				GlobalVar.whether_change_to_test3[fishID] = 0;
			}
			bool flag45 = num == -1;
			int result;
			if (flag45)
			{
				GlobalVar.Bringing_BallID[fishID] = -1;
				result = num;
			}
			else
			{
				bool flag46 = GlobalVar.willbring_ballid[fishID] != -1 && GlobalVar.MyTeam.Fishes[fishID].PositionMm.X < 950f && Math.Abs(GlobalVar.MyTeam.Fishes[fishID].PolygonVertices[0].Z) > 850f && GlobalVar.leftScore[GlobalVar.willbring_ballid[fishID]] != 1;
				if (flag46)
				{
					num = GlobalVar.willbring_ballid[fishID];
				}
				bool flag47 = num == GlobalVar.willbring_ballid[fishID];
				if (flag47)
				{
					GlobalVar.willbring_ballid[fishID] = -1;
				}
				GlobalVar.Bringing_BallID[fishID] = num;
				result = num;
			}
			return result;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000809C File Offset: 0x0000629C
		public int choseball3(int whichfish)
		{
			int i = GlobalVar.Bringing_BallID[whichfish];
			bool flag = -1 == i || GlobalVar.leftScore[i] == 1 || GlobalVar.Bringing_BallID[1 - whichfish] == i;
			if (flag)
			{
				for (i = 0; i < 3; i++)
				{
					bool flag2 = GlobalVar.Bringing_BallID[1 - whichfish] == i;
					if (!flag2)
					{
						bool flag3 = GlobalVar.BaAction.whether_in_myforbiddenareasmall((double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z);
						if (flag3)
						{
							bool flag4 = GlobalVar.leftScore[i] != 1;
							if (flag4)
							{
								DebugRecord.ceshi(0, "dddd", (float)i);
								GlobalVar.Bringing_BallID[whichfish] = i;
								return i;
							}
						}
					}
				}
				for (i = 7; i < 9; i++)
				{
					bool flag5 = GlobalVar.Bringing_BallID[1 - whichfish] == i;
					if (!flag5)
					{
						bool flag6 = GlobalVar.BaAction.whether_in_myforbiddenareasmall((double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z);
						if (flag6)
						{
							bool flag7 = GlobalVar.leftScore[i] != 1;
							if (flag7)
							{
								DebugRecord.ceshi(0, "ddddd", (float)i);
								GlobalVar.Bringing_BallID[whichfish] = i;
								return i;
							}
						}
					}
				}
				for (i = 4; i < 7; i++)
				{
					bool flag8 = GlobalVar.Bringing_BallID[1 - whichfish] == i;
					if (!flag8)
					{
						bool flag9 = GlobalVar.BaAction.whether_in_myforbiddenareasmall((double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z);
						if (flag9)
						{
							bool flag10 = GlobalVar.leftScore[i] != 1;
							if (flag10)
							{
								DebugRecord.ceshi(0, "dddddd", (float)i);
								GlobalVar.Bringing_BallID[whichfish] = i;
								return i;
							}
						}
					}
				}
			}
			GlobalVar.Bringing_BallID[whichfish] = i;
			return i;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000082FC File Offset: 0x000064FC
		public int choseball3_special(int whichfish)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int i = GlobalVar.Bringing_BallID[whichfish];
			DebugRecord.ceshi(0, "i0", (float)i);
			bool flag = -1 == i || GlobalVar.leftScore[i] == 1 || GlobalVar.Bringing_BallID[1 - whichfish] == i || (i != -1 && !GlobalVar.BaAction.whether_in_myforbiddenareabig((double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X));
			if (flag)
			{
				for (i = 0; i < 3; i++)
				{
					num = 1;
					DebugRecord.ceshi(0, "i1", (float)i);
					bool flag2 = GlobalVar.Bringing_BallID[1 - whichfish] == i;
					if (!flag2)
					{
						bool flag3 = GlobalVar.BaAction.whether_in_myforbiddenareasmall((double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z);
						if (flag3)
						{
							bool flag4 = GlobalVar.leftScore[i] != 1;
							if (flag4)
							{
								DebugRecord.ceshi(0, "1", (float)i);
								GlobalVar.Bringing_BallID[whichfish] = i;
								return i;
							}
						}
					}
				}
				for (i = 7; i < 9; i++)
				{
					num2 = 1;
					DebugRecord.ceshi(0, "i2", (float)i);
					bool flag5 = GlobalVar.Bringing_BallID[1 - whichfish] == i;
					if (!flag5)
					{
						bool flag6 = GlobalVar.BaAction.whether_in_myforbiddenareasmall((double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z);
						if (flag6)
						{
							bool flag7 = GlobalVar.leftScore[i] != 1;
							if (flag7)
							{
								DebugRecord.ceshi(0, "2", (float)i);
								GlobalVar.Bringing_BallID[whichfish] = i;
								return i;
							}
						}
					}
				}
				for (i = 3; i < 7; i++)
				{
					num3 = 1;
					DebugRecord.ceshi(0, "i3", (float)i);
					bool flag8 = GlobalVar.Bringing_BallID[1 - whichfish] == i;
					if (!flag8)
					{
						bool flag9 = GlobalVar.BaAction.whether_in_myforbiddenareasmall((double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z);
						if (flag9)
						{
							bool flag10 = GlobalVar.leftScore[i] != 1;
							if (flag10)
							{
								DebugRecord.ceshi(0, "3", (float)i);
								GlobalVar.Bringing_BallID[whichfish] = i;
								return i;
							}
						}
					}
				}
				bool flag11 = num == 1 && num2 == 1 && num3 == 1;
				if (flag11)
				{
					i = -1;
					DebugRecord.ceshi(0, "i4", (float)i);
					return i;
				}
			}
			GlobalVar.Bringing_BallID[whichfish] = i;
			return i;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000860C File Offset: 0x0000680C
		public int choseball3_special2(int whichfish)
		{
			DebugRecord.ceshi(0, "用于unarmed的选球");
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int i = GlobalVar.Bringing_BallID[whichfish];
			DebugRecord.ceshi(0, "i0", (float)i);
			bool flag = -1 == i || GlobalVar.leftScore[i] == 1 || GlobalVar.Bringing_BallID[1 - whichfish] == i || (i != -1 && !GlobalVar.BaAction.whether_in_myforbiddenareasmall((double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z));
			if (flag)
			{
				for (i = 0; i < 3; i++)
				{
					num = 1;
					DebugRecord.ceshi(0, "i1", (float)i);
					bool flag2 = GlobalVar.Bringing_BallID[1 - whichfish] == i;
					if (!flag2)
					{
						bool flag3 = GlobalVar.BaAction.whether_in_myforbiddenareasmall((double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z);
						if (flag3)
						{
							bool flag4 = GlobalVar.leftScore[i] != 1;
							if (flag4)
							{
								DebugRecord.ceshi(0, "1", (float)i);
								GlobalVar.Bringing_BallID[whichfish] = i;
								return i;
							}
						}
					}
				}
				for (i = 7; i < 9; i++)
				{
					num2 = 1;
					DebugRecord.ceshi(0, "i2", (float)i);
					bool flag5 = GlobalVar.Bringing_BallID[1 - whichfish] == i;
					if (!flag5)
					{
						bool flag6 = GlobalVar.BaAction.whether_in_myforbiddenareasmall((double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z);
						if (flag6)
						{
							bool flag7 = GlobalVar.leftScore[i] != 1;
							if (flag7)
							{
								DebugRecord.ceshi(0, "2", (float)i);
								GlobalVar.Bringing_BallID[whichfish] = i;
								return i;
							}
						}
					}
				}
				for (i = 3; i < 7; i++)
				{
					num3 = 1;
					DebugRecord.ceshi(0, "i3", (float)i);
					bool flag8 = GlobalVar.Bringing_BallID[1 - whichfish] == i;
					if (!flag8)
					{
						bool flag9 = GlobalVar.BaAction.whether_in_myforbiddenareasmall((double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z);
						if (flag9)
						{
							bool flag10 = GlobalVar.leftScore[i] != 1;
							if (flag10)
							{
								DebugRecord.ceshi(0, "3", (float)i);
								GlobalVar.Bringing_BallID[whichfish] = i;
								return i;
							}
						}
					}
				}
				bool flag11 = num == 1 && num2 == 1 && num3 == 1;
				if (flag11)
				{
					i = -1;
					DebugRecord.ceshi(0, "i4", (float)i);
					return i;
				}
			}
			GlobalVar.Bringing_BallID[whichfish] = i;
			return i;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00008948 File Offset: 0x00006B48
		public int ChoseBall20(int fishID)
		{
			DebugRecord.ceshi(0, "正常情况非堵球门重新选球");
			int num = GlobalVar.Bringing_BallID[fishID];
			num = this.UpgradeToHigherValueBall(fishID, num);
			bool flag = -1 == num || this.whether_area_CornerChoseBall2((double)GlobalVar.balls[num].PositionMm.X, (double)GlobalVar.balls[num].PositionMm.Z) || this.whether_in_myforbiddenarea_reduce((double)GlobalVar.mission.EnvRef.Balls[num].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[num].PositionMm.Z) || GlobalVar.Bringing_BallID[1 - fishID] == num || GlobalVar.willbring_ballid[1 - fishID] == num || (GlobalVar.Paishu < 3000 && GlobalVar.final == 0 && fishID == 0 && GlobalVar.mission.EnvRef.Balls[num].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[num].PositionMm.Z < -508f) || (GlobalVar.Paishu < 3000 && GlobalVar.final == 0 && fishID == 1 && GlobalVar.mission.EnvRef.Balls[num].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[num].PositionMm.Z > 508f);
			if (flag)
			{
				double num2 = 4000.0;
				double num3 = 4000.0;
				int num4 = -1;
				int num5 = -1;
				for (int i = 0; i < 3; i++)
				{
					bool flag2 = fishID == 0 && GlobalVar.mission.EnvRef.Balls[i].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z < -508f;
					if (!flag2)
					{
						bool flag3 = fishID == 1 && GlobalVar.mission.EnvRef.Balls[i].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z > 508f;
						if (!flag3)
						{
							bool flag4 = !this.whether_in_myforbiddenarea_reduce((double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X, (double)(Math.Abs(GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z) - 30f)) && GlobalVar.Bringing_BallID[1 - fishID] != i && !this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z) && GlobalVar.interfereBallStage[fishID] == 0;
							if (flag4)
							{
								bool flag5 = fishID == 0;
								double num6;
								if (flag5)
								{
									num6 = this.juli((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z, -1500.0, 300.0);
								}
								else
								{
									num6 = this.juli((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z, -1500.0, -300.0);
								}
								bool flag6 = GlobalVar.Bringing_BallID[1 - fishID] != i;
								if (flag6)
								{
									bool flag7 = num6 < num3 && num6 > num2;
									if (flag7)
									{
										num3 = num6;
										num5 = i;
									}
									bool flag8 = num6 < num2;
									if (flag8)
									{
										num3 = num2;
										num2 = num6;
										num5 = num4;
										num4 = i;
									}
								}
							}
						}
					}
				}
				bool flag9 = num5 == -1 && num4 != -1;
				if (flag9)
				{
					num = num4;
				}
				else
				{
					bool flag10 = num4 == -1 && num5 != -1;
					if (flag10)
					{
						num = num5;
					}
					else
					{
						bool flag11 = num4 == -1 && num5 == -1;
						if (flag11)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag12 = num != -1;
				if (flag12)
				{
					bool flag13 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag13)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
				num2 = 4000.0;
				num3 = 4000.0;
				num4 = -1;
				num5 = -1;
				for (int j = 7; j < 9; j++)
				{
					bool flag14 = fishID == 0 && GlobalVar.mission.EnvRef.Balls[j].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z < -508f;
					if (!flag14)
					{
						bool flag15 = fishID == 1 && GlobalVar.mission.EnvRef.Balls[j].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z > 508f;
						if (!flag15)
						{
							bool flag16 = !this.whether_in_myforbiddenarea_reduce((double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.X, (double)(Math.Abs(GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z) - 30f)) && GlobalVar.Bringing_BallID[1 - fishID] != j && !this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z) && GlobalVar.interfereBallStage[fishID] == 0;
							if (flag16)
							{
								bool flag17 = fishID == 0;
								double num6;
								if (flag17)
								{
									num6 = this.juli((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z, -1500.0, 300.0);
								}
								else
								{
									num6 = this.juli((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z, -1500.0, -300.0);
								}
								bool flag18 = GlobalVar.Bringing_BallID[1 - fishID] != j;
								if (flag18)
								{
									bool flag19 = num6 < num3 && num6 > num2;
									if (flag19)
									{
										num3 = num6;
										num5 = j;
									}
									bool flag20 = num6 < num2;
									if (flag20)
									{
										num3 = num2;
										num2 = num6;
										num5 = num4;
										num4 = j;
									}
								}
							}
						}
					}
				}
				bool flag21 = num5 == -1 && num4 != -1;
				if (flag21)
				{
					num = num4;
				}
				else
				{
					bool flag22 = num4 == -1 && num5 != -1;
					if (flag22)
					{
						num = num5;
					}
					else
					{
						bool flag23 = num4 == -1 && num5 == -1;
						if (flag23)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag24 = num != -1;
				if (flag24)
				{
					bool flag25 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag25)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
				num2 = 4000.0;
				num3 = 4000.0;
				num4 = -1;
				num5 = -1;
				int k = 3;
				while (k < 7)
				{
					bool flag26 = GlobalVar.teamId == 0;
					if (flag26)
					{
						bool flag27 = fishID == 0 && k == 3;
						if (!flag27)
						{
							bool flag28 = fishID == 1 && k == 6;
							if (!flag28)
							{
								goto IL_836;
							}
						}
					}
					else
					{
						bool flag29 = GlobalVar.teamId == 1;
						if (!flag29)
						{
							goto IL_836;
						}
						bool flag30 = fishID == 0 && k == 5;
						if (!flag30)
						{
							bool flag31 = fishID == 1 && k == 4;
							if (!flag31)
							{
								goto IL_836;
							}
						}
					}
					IL_A74:
					k++;
					continue;
					IL_836:
					bool flag32 = fishID == 0 && GlobalVar.mission.EnvRef.Balls[k].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[k].PositionMm.Z < -508f;
					if (flag32)
					{
						goto IL_A74;
					}
					bool flag33 = fishID == 1 && GlobalVar.mission.EnvRef.Balls[k].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[k].PositionMm.Z > 508f;
					if (flag33)
					{
						goto IL_A74;
					}
					bool flag34 = !this.whether_in_myforbiddenarea_reduce((double)GlobalVar.mission.EnvRef.Balls[k].PositionMm.X, (double)(Math.Abs(GlobalVar.mission.EnvRef.Balls[k].PositionMm.Z) - 30f)) && GlobalVar.Bringing_BallID[1 - fishID] != k && !this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z) && GlobalVar.interfereBallStage[fishID] == 0;
					if (flag34)
					{
						bool flag35 = fishID == 0;
						double num6;
						if (flag35)
						{
							num6 = this.juli((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z, -1500.0, 300.0);
						}
						else
						{
							num6 = this.juli((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z, -1500.0, -300.0);
						}
						bool flag36 = GlobalVar.Bringing_BallID[1 - fishID] != k;
						if (flag36)
						{
							bool flag37 = num6 < num3 && num6 > num2;
							if (flag37)
							{
								num3 = num6;
								num5 = k;
							}
							bool flag38 = num6 < num2;
							if (flag38)
							{
								num3 = num2;
								num2 = num6;
								num5 = num4;
								num4 = k;
							}
						}
					}
					goto IL_A74;
				}
				bool flag39 = num5 == -1 && num4 != -1;
				if (flag39)
				{
					num = num4;
				}
				else
				{
					bool flag40 = num4 == -1 && num5 != -1;
					if (flag40)
					{
						num = num5;
					}
					else
					{
						bool flag41 = num4 == -1 && num5 == -1;
						if (flag41)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag42 = num != -1;
				if (flag42)
				{
					bool flag43 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag43)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
			}
			bool flag44 = GlobalVar.Bringing_BallID[fishID] != num;
			if (flag44)
			{
				GlobalVar.whether_change_to_test3[fishID] = 0;
			}
			bool flag45 = num == -1;
			int result;
			if (flag45)
			{
				GlobalVar.Bringing_BallID[fishID] = -1;
				result = num;
			}
			else
			{
				bool flag46 = GlobalVar.willbring_ballid[fishID] != -1 && GlobalVar.MyTeam.Fishes[fishID].PositionMm.X < 950f && Math.Abs(GlobalVar.MyTeam.Fishes[fishID].PolygonVertices[0].Z) > 850f && GlobalVar.leftScore[GlobalVar.willbring_ballid[fishID]] != 1;
				if (flag46)
				{
					num = GlobalVar.willbring_ballid[fishID];
				}
				bool flag47 = num == GlobalVar.willbring_ballid[fishID];
				if (flag47)
				{
					GlobalVar.willbring_ballid[fishID] = -1;
				}
				GlobalVar.Bringing_BallID[fishID] = num;
				result = num;
			}
			return result;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000954C File Offset: 0x0000774C
		public int ChoseBall10(int fishID)
		{
			int num = GlobalVar.Bringing_BallID[fishID];
			bool flag = -1 == num || this.whether_area_CornerChoseBall((double)GlobalVar.balls[num].PositionMm.X, (double)GlobalVar.balls[num].PositionMm.Z) || GlobalVar.leftScore[num] == 1 || GlobalVar.Bringing_BallID[1 - fishID] == num || GlobalVar.willbring_ballid[1 - fishID] == num;
			if (flag)
			{
				double num2 = 4000.0;
				double num3 = 4000.0;
				int num4 = -1;
				int num5 = -1;
				for (int i = 0; i < 3; i++)
				{
					bool flag2 = !this.whether_in_myforbiddenarea_reduce((double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z) && GlobalVar.Bringing_BallID[1 - fishID] != i && !this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z) && GlobalVar.interfereBallStage[fishID] == 0;
					if (flag2)
					{
						bool flag3 = fishID == 0;
						double num6;
						if (flag3)
						{
							num6 = this.juli((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z, -1500.0, 300.0);
						}
						else
						{
							num6 = this.juli((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z, -1500.0, -300.0);
						}
						bool flag4 = GlobalVar.Bringing_BallID[1 - fishID] != i;
						if (flag4)
						{
							bool flag5 = num6 < num3 && num6 > num2;
							if (flag5)
							{
								num3 = num6;
								num5 = i;
							}
							bool flag6 = num6 < num2;
							if (flag6)
							{
								num3 = num2;
								num2 = num6;
								num5 = num4;
								num4 = i;
							}
						}
					}
				}
				bool flag7 = num5 == -1 && num4 != -1;
				if (flag7)
				{
					num = num4;
				}
				else
				{
					bool flag8 = num4 == -1 && num5 != -1;
					if (flag8)
					{
						num = num5;
					}
					else
					{
						bool flag9 = num4 == -1 && num5 == -1;
						if (flag9)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag10 = num != -1;
				if (flag10)
				{
					bool flag11 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag11)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
				num2 = 4000.0;
				num3 = 4000.0;
				num4 = -1;
				num5 = -1;
				for (int j = 7; j < 9; j++)
				{
					bool flag12 = !this.whether_in_myforbiddenarea_reduce((double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z) && GlobalVar.Bringing_BallID[1 - fishID] != j && !this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z) && GlobalVar.interfereBallStage[fishID] == 0;
					if (flag12)
					{
						bool flag13 = fishID == 0;
						double num6;
						if (flag13)
						{
							num6 = this.juli((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z, -1500.0, 300.0);
						}
						else
						{
							num6 = this.juli((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z, -1500.0, -300.0);
						}
						bool flag14 = GlobalVar.Bringing_BallID[1 - fishID] != j;
						if (flag14)
						{
							bool flag15 = num6 < num3 && num6 > num2;
							if (flag15)
							{
								num3 = num6;
								num5 = j;
							}
							bool flag16 = num6 < num2;
							if (flag16)
							{
								num3 = num2;
								num2 = num6;
								num5 = num4;
								num4 = j;
							}
						}
					}
				}
				bool flag17 = num5 == -1 && num4 != -1;
				if (flag17)
				{
					num = num4;
				}
				else
				{
					bool flag18 = num4 == -1 && num5 != -1;
					if (flag18)
					{
						num = num5;
					}
					else
					{
						bool flag19 = num4 == -1 && num5 == -1;
						if (flag19)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag20 = num != -1;
				if (flag20)
				{
					bool flag21 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag21)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
				num2 = 4000.0;
				num3 = 4000.0;
				num4 = -1;
				num5 = -1;
				int k = 3;
				while (k < 7)
				{
					bool flag22 = GlobalVar.teamId == 0;
					if (flag22)
					{
						bool flag23 = fishID == 0 && k == 3;
						if (!flag23)
						{
							bool flag24 = fishID == 1 && k == 6;
							if (!flag24)
							{
								goto IL_581;
							}
						}
					}
					else
					{
						bool flag25 = GlobalVar.teamId == 1;
						if (!flag25)
						{
							goto IL_581;
						}
						bool flag26 = fishID == 0 && k == 5;
						if (!flag26)
						{
							bool flag27 = fishID == 1 && k == 4;
							if (!flag27)
							{
								goto IL_581;
							}
						}
					}
					IL_7B4:
					k++;
					continue;
					IL_581:
					bool flag28 = fishID == 0 && GlobalVar.mission.EnvRef.Balls[k].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[k].PositionMm.Z < -508f;
					if (flag28)
					{
						goto IL_7B4;
					}
					bool flag29 = fishID == 1 && GlobalVar.mission.EnvRef.Balls[k].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[k].PositionMm.Z > 508f;
					if (flag29)
					{
						goto IL_7B4;
					}
					bool flag30 = !this.whether_in_myforbiddenarea_reduce((double)GlobalVar.mission.EnvRef.Balls[k].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[k].PositionMm.Z) && GlobalVar.Bringing_BallID[1 - fishID] != k && !this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z) && GlobalVar.interfereBallStage[fishID] == 0;
					if (flag30)
					{
						bool flag31 = fishID == 0;
						double num6;
						if (flag31)
						{
							num6 = this.juli((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z, -1500.0, 300.0);
						}
						else
						{
							num6 = this.juli((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z, -1500.0, -300.0);
						}
						bool flag32 = GlobalVar.Bringing_BallID[1 - fishID] != k;
						if (flag32)
						{
							bool flag33 = num6 < num3 && num6 > num2;
							if (flag33)
							{
								num3 = num6;
								num5 = k;
							}
							bool flag34 = num6 < num2;
							if (flag34)
							{
								num3 = num2;
								num2 = num6;
								num5 = num4;
								num4 = k;
							}
						}
					}
					goto IL_7B4;
				}
				bool flag35 = num5 == -1 && num4 != -1;
				if (flag35)
				{
					num = num4;
				}
				else
				{
					bool flag36 = num4 == -1 && num5 != -1;
					if (flag36)
					{
						num = num5;
					}
					else
					{
						bool flag37 = num4 == -1 && num5 == -1;
						if (flag37)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag38 = num != -1;
				if (flag38)
				{
					bool flag39 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag39)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
			}
			bool flag40 = GlobalVar.Bringing_BallID[fishID] != num;
			if (flag40)
			{
				GlobalVar.whether_change_to_test3[fishID] = 0;
			}
			bool flag41 = num == -1;
			int result;
			if (flag41)
			{
				result = num;
			}
			else
			{
				bool flag42 = GlobalVar.willbring_ballid[fishID] != -1 && GlobalVar.MyTeam.Fishes[fishID].PositionMm.X < 950f && Math.Abs(GlobalVar.MyTeam.Fishes[fishID].PolygonVertices[0].Z) > 850f && GlobalVar.leftScore[GlobalVar.willbring_ballid[fishID]] != 1;
				if (flag42)
				{
					num = GlobalVar.willbring_ballid[fishID];
				}
				bool flag43 = num == GlobalVar.willbring_ballid[fishID];
				if (flag43)
				{
					GlobalVar.willbring_ballid[fishID] = -1;
				}
				GlobalVar.Bringing_BallID[fishID] = num;
				result = num;
			}
			return result;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00009E88 File Offset: 0x00008088
		public double juli(double a, double b, double x, double z)
		{
			return Math.Sqrt(Math.Pow(x - a, 2.0) + Math.Pow(z - b, 2.0));
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00009EC4 File Offset: 0x000080C4
		public void Dribblehometest1(int whichfish, int whichball)
		{
			int i = 7;
			bool flag = whichfish == 0;
			if (flag)
			{
				i = 6;
			}
			bool flag2 = whichfish == 1;
			if (flag2)
			{
				i = 10;
			}
			bool flag3 = whichball < 0 || whichball > 8;
			if (!flag3)
			{
				double num = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.X;
				double num2 = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.Z;
				double num3 = (double)GlobalVar.mission.EnvRef.Balls[whichball].RadiusMm;
				int upper_fish = this.get_upper_fish();
				double num4 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
				double num5 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
				double num6 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[whichfish].X;
				double num7 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[whichfish].Z;
				double value = (double)GlobalVar.MyTeam.Fishes[whichfish].BodyDirectionRad;
				bool flag4 = whichfish == 0;
				int num8;
				if (flag4)
				{
					num8 = 1;
				}
				else
				{
					num8 = -1;
				}
				bool flag5 = GlobalVar.Paishu > 3000 || GlobalVar.final == 1;
				if (flag5)
				{
					bool flag6 = num2 > 500.0;
					if (flag6)
					{
						num8 = 1;
					}
					else
					{
						bool flag7 = num2 < -500.0;
						if (flag7)
						{
							num8 = -1;
						}
					}
				}
				else
				{
					bool flag8 = GlobalVar.Paishu > 1500 || GlobalVar.final == 1;
					if (flag8)
					{
						bool flag9 = num2 > 700.0;
						if (flag9)
						{
							num8 = 1;
						}
						else
						{
							bool flag10 = num2 < -700.0;
							if (flag10)
							{
								num8 = -1;
							}
						}
					}
				}
				GlobalVar.corner[whichfish] = 0;
				GlobalVar.corner_help[whichfish] = 0;
				bool flag11 = GlobalVar.flag_duqiumen == 1 && this.whether_in_goal(num4, num5, -1);
				if (flag11)
				{
					GlobalVar.enter_gate_stage[whichfish] = 0;
				}
				bool flag12 = GlobalVar.flag_duqiumen == 1 && this.whether_in_goal(num4, num5, -1) && this.whether_in_goal(num, num2, whichball);
				if (flag12)
				{
					this.the_warrior2(whichfish, whichball);
				}
				else
				{
					bool flag13 = GlobalVar.flag_duqiumen == 1 && this.whether_in_goal(num4, num5, -1) && !this.whether_in_goal(num, num2, whichball);
					if (flag13)
					{
						bool flag14 = Compute.GetDistance(num4, num5, -1192.0, (double)(num8 * 532)) > 100.0;
						if (flag14)
						{
							this.position3(whichfish, -1192.0, (double)(num8 * 532), 50.0);
						}
						else
						{
							this.position3(whichfish, -1160.0, (double)(num8 * 916), 170.0);
						}
					}
					else
					{
						bool flag15 = GlobalVar.flag_duqiumen == 1 && !this.whether_in_goal(num4, num5, -1) && this.whether_in_goal(num, num2, whichball);
						if (flag15)
						{
							bool flag16 = GlobalVar.whether_change_to_test3[whichfish] == 1;
							if (flag16)
							{
								GlobalVar.whether_change_to_test3[whichfish] = 0;
							}
							bool flag17 = num4 > -970.0;
							if (flag17)
							{
								this.position3(whichfish, -932.0, (double)(num8 * 740), 80.0);
							}
							else
							{
								bool flag18 = Compute.GetDistance(num4, num5, -1180.0, (double)(num8 * 516)) < 100.0;
								if (flag18)
								{
									this.position3(whichfish, -1216.0, 0.0, 200.0);
								}
								else
								{
									this.position3(whichfish, -1180.0, (double)(num8 * 516), 80.0);
								}
							}
						}
						else
						{
							bool flag19 = this.whether_in_myforbiddenareasmall(num4, num5) && num > -949.0 && num < 949.0;
							if (flag19)
							{
								DebugRecord.ceshi(0, "意外情况");
								this.Position(whichfish, -1500.0, (double)(num8 * 1000), 200.0);
								DebugRecord.ceshi(i, "one从己方禁区跑出跑到角落，球在中间");
							}
							else
							{
								bool flag20 = this.whether_in_myforbiddenareasmall(num4, num5) && num > -1150.0 && Math.Abs(num2) > 550.0;
								if (flag20)
								{
									DebugRecord.ceshi(0, "意外情况");
									this.Position(whichfish, -1500.0, (double)(num8 * 1000), 200.0);
									DebugRecord.ceshi(i, "one从己方禁区跑出跑到角落，球在上下两个铲球区域");
								}
								else
								{
									bool flag21 = num4 < -949.0 && Math.Abs(num5) < 900.0 && num > -949.0 && num < 949.0;
									if (flag21)
									{
										DebugRecord.ceshi(0, "意外情况");
										this.Position(whichfish, -800.0, (double)(num8 * 700), 200.0);
										DebugRecord.ceshi(i, "one从己方禁区跑出跑到禁区外距离较近的一点");
									}
									else
									{
										bool flag22 = this.whether_in_oppforbiddenareabig(num4, num5) && !this.whether_in_oppforbiddenareabig(num, num2);
										if (flag22)
										{
											DebugRecord.ceshi(0, "意外情况");
											this.Position(whichfish, 1350.0, (double)(num8 * 700), 200.0);
											bool flag23 = Math.Abs(num5) > 600.0;
											if (flag23)
											{
												this.Position(whichfish, 800.0, (double)(num8 * 700), 200.0);
											}
											DebugRecord.ceshi(i, "one从对方禁区跑出准备带球");
										}
										else
										{
											bool flag24 = this.whether_in_myforbiddenareasmall(num4, num5) && this.whether_in_oppforbiddenareabig(num, num2);
											if (flag24)
											{
												DebugRecord.ceshi(0, "意外情况");
												this.Position(whichfish, -1500.0, (double)(num8 * 1000), 200.0);
												DebugRecord.ceshi(i, "one从我方禁区跑出跑到角落，此时球在对方的大禁区里面");
											}
											else
											{
												bool flag25 = num4 < -949.0 && Math.Abs(num5) < 900.0 && this.whether_in_oppforbiddenareabig(num, num2);
												if (flag25)
												{
													DebugRecord.ceshi(0, "意外情况");
													this.Position(whichfish, -800.0, (double)(num8 * 700), 200.0);
													DebugRecord.ceshi(i, "one从我方禁区跑到禁区外一点，此时球在敌方禁区");
												}
												else
												{
													bool flag26 = Math.Abs(value) > 5.0 * GlobalVar.PI / 6.0 && num6 < -1400.0 && num > -1100.0 && Math.Abs(num2) > 560.0;
													if (flag26)
													{
														DebugRecord.ceshi(0, "意外情况");
														this.Position(whichfish, -1100.0, (double)(num8 * 700), 999.0);
														DebugRecord.ceshi(i, "one防止冯勇发现的一个bug的跑位");
													}
													else
													{
														bool flag27 = num2 > 0.0;
														int num9;
														if (flag27)
														{
															num9 = 1;
														}
														else
														{
															num9 = -1;
														}
														bool flag28 = num4 > -920.0 && this.whether_in_myforbiddenareasmall((double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.Z);
														if (flag28)
														{
															DebugRecord.ceshi(0, "意外情况");
															GlobalVar.BaAction.Position(whichfish, -1100.0, (double)(num9 * 700), 200.0);
															DebugRecord.ceshi(i, "one球在己方禁区但是鱼不在就让鱼跑位");
														}
														else
														{
															// ========== 边界挑球检测（优先级最高，不受位置限制）==========
															int stalemateOppId;
															double flickDirection;
															bool isStalemate = this.IsBoundaryStalemate(whichfish, whichball, out stalemateOppId, out flickDirection);
															
															// 如果检测到边界对峙且当前不在挑球状态
														if (isStalemate && GlobalVar.flick_ball_stage[whichfish] == 0)
														{
															GlobalVar.flick_ball_stage[whichfish] = 1;
															DebugRecord.ceshi(i, "检测到边界对峙，开始挑球", (float)stalemateOppId);
														}
															
															// 如果正在挑球
														if (GlobalVar.flick_ball_stage[whichfish] == 1)
														{
															this.FlickBallAtBoundary(whichfish, whichball, flickDirection);
															}
															else
															{
																// 不在挑球状态，继续正常逻辑
															bool flag29 = whichball != 0 && whichball != 1 && whichball != 2 && num >= -1400.0 && num + num3 < -1160.0 && Math.Abs(num2) < 700.0;
															if (flag29)
															{
																GlobalVar.BaAction.position3_1(whichfish, -1800.0, num2, 50.0, 0);
																GlobalVar.decisions[whichfish].VCode = 14;
															}
															else
															{
																bool flag30 = num > -1300.0;
																if (flag30)
																{
																	// ========== 避障检测开始 ==========
																	// ========== 避障检测开始 ==========
																	int blockingOppId;
																	double detourAngle;
																	bool isBlocked = this.IsOpponentBlocking(whichfish, whichball, out blockingOppId, out detourAngle);
																	
																	// 如果检测到对手阻挡且当前不在绕行状态
																	if (isBlocked && GlobalVar.detour_stage[whichfish] == 0)
																	{
																		GlobalVar.detour_stage[whichfish] = 1;
																		GlobalVar.detour_target_opp[whichfish] = blockingOppId;
																		DebugRecord.ceshi(i, "检测到对手阻挡，开始绕行", (float)blockingOppId);
																	}
																	
																	// 如果正在绕行
																	if (GlobalVar.detour_stage[whichfish] == 1)
																	{
																		// 执行绕行动作
																		this.DetourAroundOpponent(whichfish, whichball, GlobalVar.detour_target_opp[whichfish], detourAngle);
																		
																		// 检查是否完成绕行（已经接近球）
																		double distToBall = Compute.GetDistance(num4, num5, num, num2);
																		
																		if (distToBall < 150.0)
																		{
																			// 已经接近球，结束绕行，恢复正常状态
																			GlobalVar.detour_stage[whichfish] = 0;
																			DebugRecord.ceshi(i, "绕行完成，恢复正常带球");
																		}
																	}
																	else
																	{
																		// 正常带球逻辑（原代码）
																	// ========== 避障检测结束 ==========
																	bool flag31 = whichfish == 1;
																	if (flag31)
																	{
																		bool flag32 = num > -952.0;
																		if (flag32)
																		{
																			bool flag33 = GlobalVar.flag_duqiumen != 1;
																			if (flag33)
																			{
																				this.Dribble(whichfish, whichball, -980.0, (double)num8 * 645.0);
																			}
																			else
																			{
																				this.Dribble(whichfish, whichball, -980.0, (double)num8 * 800.0);
																			}
																			DebugRecord.ceshi(i, "one球未到左边界，先把球带到我方禁区入口");
																		}
																		else
																		{
																			bool flag34 = num > -1150.0;
																			if (flag34)
																			{
																				this.Dribble(whichfish, whichball, -1230.0, (double)num8 * 500.0);
																				DebugRecord.ceshi(i, "one球未到左边界，然后把球带到我方禁区中央");
																			}
																			else
																			{
																				bool flag35 = GlobalVar.flag_duqiumen != 1;
																				if (flag35)
																				{
																					bool flag36 = Math.Abs(num2) < 300.0;
																					if (flag36)
																					{
																						this.Dribble(whichfish, whichball, -1180.0, (double)num8 * 0.0);
																					}
																					else
																					{
																						this.Dribble(whichfish, whichball, -1180.0, (double)(-(double)num8) * 300.0);
																					}
																					DebugRecord.ceshi(i, "one球未到左边界，最后把球带到我方禁区内部准备单鱼进球");
																				}
																				else
																				{
																					this.Dribble(whichfish, whichball, -1500.0, (double)num8 * 580.0);
																					DebugRecord.ceshi(i, "one堵球门，球未到左边界，把球带到敌方鱼头上方");
																				}
																			}
																		}
																		DebugRecord.ceshi(0, "正常情况1号鱼带球");
																	}
																	else
																	{
																				bool flag37 = GlobalVar.teamId == 1;
																				if (flag37)
																				{
																					bool flag38 = num > -900.0;
																			if (flag38)
																			{
																				this.Dribble(whichfish, whichball, -980.0, (double)num8 * 700.0);
																				DebugRecord.ceshi(i, "zero球未到左边界，先把球带到我方禁区入口");
																			}
																			else
																			{
																				bool flag39 = num > -1100.0;
																				if (flag39)
																				{
																					this.KeepV(whichfish, 100.0);
																					this.Dribble(whichfish, whichball, -1500.0, (double)num8 * 600.0);
																					DebugRecord.ceshi(i, "zero球未到左边界，然后把球带到我方禁区中央");
																				}
																				else
																				{
																					bool flag40 = GlobalVar.flag_duqiumen != 1;
																					if (flag40)
																					{
																						this.KeepV(whichfish, 100.0);
																						this.Dribble(whichfish, whichball, -1500.0, (double)num8 * 520.0);
																						DebugRecord.ceshi(i, "zero球未到左边界，最后把球带到我方禁区内部准备单鱼进球");
																					}
																					else
																					{
																						this.Dribble(whichfish, whichball, -1500.0, (double)num8 * 580.0);
																						DebugRecord.ceshi(i, "zero堵球门，球未到左边界，把球带到敌方鱼头上方");
																					}
																				}
																			}
																			DebugRecord.ceshi(0, "下半场0号鱼带球");
																		}
																		else
																		{
																			DebugRecord.ceshi(0, "if I am in the right");
																			bool flag41 = num > -952.0;
																			if (flag41)
																			{
																				this.Dribble(whichfish, whichball, -980.0, (double)num8 * 665.0);
																				DebugRecord.ceshi(i, "zero球未到左边界，先把球带到我方禁区入口");
																			}
																			else
																			{
																				bool flag42 = num > -1150.0;
																				if (flag42)
																				{
																					bool flag43 = GlobalVar.flag_duqiumen != 1;
																					if (flag43)
																					{
																						this.KeepV(whichfish, 100.0);
																						this.Dribble(whichfish, whichball, -1500.0, (double)num8 * 600.0);
																						DebugRecord.ceshi(i, "zero球未到左边界，然后把球带到我方禁区中央");
																					}
																					else
																					{
																						this.Dribble(whichfish, whichball, -1500.0, (double)num8 * 580.0);
																						DebugRecord.ceshi(i, "zero堵球门，球未到左边界，把球带到敌方鱼头上方");
																					}
																				}
																				else
																				{
																					this.KeepV(whichfish, 100.0);
																					this.Dribble(whichfish, whichball, -1500.0, (double)num8 * 520.0);
																					DebugRecord.ceshi(i, "zero球未到左边界，最后把球带到我方禁区内部准备单鱼进球");
																				}
																			}
																			DebugRecord.ceshi(0, "上半场0号鱼带球");
																		}
																	}
																	} // 结束避障else块
																} // 结束flag30
																else
																{
																	bool flag44 = whichfish == 0;
															if (flag44)
															{
																bool flag45 = num > -1380.0;
																if (flag45)
																{
																	this.Dribble(whichfish, whichball, -1500.0, num2 - 35.0);
																	DebugRecord.ceshi(i, "zero球进入了大禁区离左边界还算远直接调用的带球，调用带球");
																}
																else
																{
																	bool flag46 = Compute.GetDistance(num4, num5, num, num2) > 150.0;
																	if (flag46)
																	{
																		this.Position(whichfish, num, num2 + (double)(num8 * 60), 100.0);
																		DebugRecord.ceshi(i, "zero球在左边界但是鱼离球的距离较远，调用跑位");
																	}
																	else
																	{
																		bool flag47 = GlobalVar.flag_duqiumen == 0;
																		if (flag47)
																		{
																			this.Dribblehometest3(whichfish, whichball);
																			DebugRecord.ceshi(i, "zero球和鱼在左边界内调用dribble3");
																		}
																		else
																		{
																			this.Dribble_blue(whichfish, -1500.0, num2, whichball);
																			DebugRecord.ceshi(i, "zero球和鱼在左边界内调用dribble_blue");
																		}
																	}
																}
																DebugRecord.ceshi(0, "0号鱼带球到终点");
															}
															else
															{
																bool flag48 = whichfish == 1;
																if (flag48)
																{
																	bool flag49 = Compute.GetDistance(num4, num5, num, num2) > 150.0;
																	if (flag49)
																	{
																		this.Position(whichfish, num, num2 + (double)(num8 * 60), 100.0);
																		DebugRecord.ceshi(i, "one球在左边界但是鱼离球的距离较远，掉用跑位");
																	}
																	else
																	{
																		bool flag50 = GlobalVar.flag_duqiumen == 0;
																		if (flag50)
																		{
																			this.Dribblehometest3(whichfish, whichball);
																			DebugRecord.ceshi(i, "one球和鱼在左边界内调用dribble3");
																		}
																		else
																		{
																			this.Dribble_blue(whichfish, -1500.0, num2, whichball);
																			DebugRecord.ceshi(i, "one球和鱼在左边界内调用drrible_blue");
																		}
																	}
																	DebugRecord.ceshi(0, "1号鱼带球到终点");
																	DebugRecord.ceshi(5, "xfish", num4);
																}
															}
														}
																bool flag51 = Math.Abs(num2) > 750.0 || GlobalVar.whether_change_to_test3[whichfish] == 1;
																if (flag51)
																{
																	GlobalVar.whether_change_to_test3[whichfish] = 1;
																	bool flag52 = Math.Abs(num4 + 1200.0) < 100.0 && Math.Abs(num5 - 550.0) < 100.0 && num < -900.0 && num > -1000.0 && Math.Abs(num2) > 500.0 && Math.Abs(num2) < 650.0;
																	if (flag52)
																	{
																		GlobalVar.whether_change_to_test3[whichfish] = 0;
																	}
																	bool flag53 = num < -1350.0 || (num < -976.0 && Math.Abs(num2) < 600.0) || (num < -1280.0 && Math.Abs(num2) < 950.0);
																	if (flag53)
																	{
																		bool flag54 = GlobalVar.flag_duqiumen == 0;
																		if (flag54)
																		{
																			this.Dribblehometest3(whichfish, whichball);
																			bool flag55 = num < -1400.0 && (num2 > 580.0 || num2 < -580.0);
																			if (flag55)
																			{
																				this.Dribble_blue(whichfish, -1500.0, num2, whichball);
																			}
																			DebugRecord.ceshi(i, "在禁区附近则切换到test3");
																		}
																		else
																		{
																			this.Dribble_blue(whichfish, -1500.0, num2, whichball);
																			DebugRecord.ceshi(i, "在禁区附近则切换到drrible_blue");
																		}
																	}
																	else
																	{
																		bool flag56 = Math.Abs(num2) > 750.0;
																		if (flag56)
																		{
																			this.Dribble_boundaryf2(whichfish, whichball);
																			DebugRecord.ceshi(i, "调用边界带球");
																		}
																	}
																}
																bool flag57 = GlobalVar.flag_duqiumen == 0;
																if (flag57)
																{
																	int num10 = GlobalVar.Bringing_BallID[0];
																	int num11 = GlobalVar.Bringing_BallID[1];
																	bool flag58 = num10 != -1 && num11 != -1;
																	if (flag58)
																	{
																		bool flag59 = GlobalVar.teamId == 0 && whichfish == 1;
																		if (flag59)
																		{
																			bool flag60 = (whichfish == 0 && GlobalVar.Bringing_BallID[0] != 6) || (whichfish == 1 && GlobalVar.Bringing_BallID[1] != 3);
																			if (flag60)
																			{
																				bool flag61 = Math.Abs(num5) > 550.0 && Math.Abs(num4) > 1000.0 && Math.Abs(num5) > (double)(Math.Abs(GlobalVar.balls[3].PositionMm.Z) - 66f) && Math.Abs(num5) > (double)(Math.Abs(GlobalVar.balls[num11].PositionMm.Z) - 66f);
																				if (flag61)
																				{
																					DebugRecord.ceshi(0, "上半个区域");
																					double num12 = (double)GlobalVar.MyTeam.Fishes[whichfish].BodyDirectionRad;
																					double pi = GlobalVar.PI;
																					bool flag62 = GlobalVar.jiaoluobaiwei[whichfish] == 1;
																					if (flag62)
																					{
																						GlobalVar.decisions[whichfish].TCode = 14;
																						GlobalVar.decisions[whichfish].VCode = 1;
																						DebugRecord.ceshi(i, "one一号鱼把左上角的球一同带回去之角落甩尾，速1角14");
																						bool flag63 = Math.Abs(num12 + 0.5 * pi) < pi / 8.0 || Math.Abs(num5) < (double)Math.Abs(GlobalVar.balls[3].PositionMm.Z);
																						if (flag63)
																						{
																							GlobalVar.jiaoluobaiwei[whichfish] = 0;
																							GlobalVar.liangqiutongchan[1] = 1;
																						}
																						bool flag64 = Math.Abs(num5) < Math.Abs(num2) - 50.0;
																						if (flag64)
																						{
																							GlobalVar.liangqiutongchan[1] = 1;
																						}
																					}
																					bool flag65 = Math.Abs(num2) > 300.0 && (num < -1250.0 || (GlobalVar.jiaoluobaiwei[whichfish] == 1 && num < -1050.0)) && (whichfish == 1 && GlobalVar.balls[3].PositionMm.X < -1200f) && GlobalVar.balls[3].PositionMm.Z < -300f;
																					if (flag65)
																					{
																						GlobalVar.jiaoluobaiwei[whichfish] = 1;
																						double num13 = Math.Abs(num7 - 1000.0);
																						double num14 = (double)GlobalVar.Fish_length;
																						double num15 = 2.0 - 3.0 * pi / 2.0;
																						bool flag66 = num13 < num14;
																						double num16;
																						if (flag66)
																						{
																							num16 = Math.Acos(num13 / num14);
																						}
																						else
																						{
																							num16 = pi - 2.0;
																						}
																						bool flag67 = (double)num8 * num15 > (double)num8 * (-pi / 2.0 - num16);
																						if (flag67)
																						{
																							num15 = -pi / 2.0 - num16;
																						}
																						num15 += 0.3;
																						int num17 = this.TransfromAngletoTCode((double)num8 * num15 - num12);
																						int num18 = Math.Abs(9 - num17);
																						bool flag68 = (double)num8 * num12 > 0.0 || (double)num8 * num12 < -(pi - 0.1);
																						if (flag68)
																						{
																							bool flag69 = (double)num8 * num12 > 0.0;
																							if (flag69)
																							{
																								GlobalVar.decisions[whichfish].VCode = 5;
																								GlobalVar.decisions[whichfish].TCode = 7 + num8 * 4;
																								DebugRecord.ceshi(i, "one角落带球左上角之鱼体方向未达到要求，速5角7+-4");
																							}
																							else
																							{
																								GlobalVar.decisions[whichfish].VCode = 5;
																								GlobalVar.decisions[whichfish].TCode = 7 + num8 * 4;
																								DebugRecord.ceshi(i, "one角落带球左上角之鱼体方向未达到要求，速5角7+-4");
																							}
																						}
																						else
																						{
																							bool flag70 = Math.Abs(num7) > 750.0;
																							if (flag70)
																							{
																								num15 = -pi / 2.0 - num16;
																								num15 -= 0.1;
																								bool flag71 = Math.Abs(num12) > Math.Abs(num15);
																								if (flag71)
																								{
																									GlobalVar.decisions[whichfish].TCode = 7 + num8 * 2;
																									GlobalVar.decisions[whichfish].VCode = 2;
																									DebugRecord.ceshi(i, "one角落带球左上角之鱼头坐标未达到要求，速2角7+-2");
																								}
																								else
																								{
																									GlobalVar.decisions[whichfish].TCode = 7;
																									GlobalVar.decisions[whichfish].VCode = 5;
																									DebugRecord.ceshi(i, "one角落带球左上角之鱼头坐标未达到要求，速5角7");
																								}
																							}
																							else
																							{
																								bool flag72 = Math.Abs(num12) < Math.Abs(num15) + 0.15 && Math.Abs(num12) > Math.Abs(num15) - 0.15;
																								if (flag72)
																								{
																									GlobalVar.decisions[whichfish].TCode = 8;
																									GlobalVar.decisions[whichfish].VCode = 12 - num18;
																									DebugRecord.ceshi(i, "one左上角鱼头坐标达到要求，角8");
																									DebugRecord.ceshi(i, "vcode", (float)(12 - num18));
																								}
																								else
																								{
																									bool flag73 = Math.Abs(num12) < Math.Abs(num15);
																									if (flag73)
																									{
																										DebugRecord.ceshi(i, "one左上角草泥马的赋档位老子不干了");
																										bool flag74 = Math.Abs(GlobalVar.prefish[whichfish].preTcode - num17) > 1;
																										if (flag74)
																										{
																											num17 = Math.Sign(GlobalVar.prefish[whichfish].preTcode - num17) + num17;
																										}
																										GlobalVar.decisions[whichfish].TCode = num17;
																										DebugRecord.ceshi(i, "onetcode", (float)num17);
																										num18 = 3 - num18;
																										bool flag75 = num18 < 1;
																										if (flag75)
																										{
																											num18 = 1;
																										}
																										bool flag76 = Math.Abs(GlobalVar.prefish[whichfish].preVcode - num18) > 2;
																										if (flag76)
																										{
																											num18 = (num18 + GlobalVar.prefish[whichfish].preVcode) / 2;
																										}
																										GlobalVar.decisions[whichfish].VCode = num18;
																										DebugRecord.ceshi(i, "onevcode", (float)num18);
																									}
																									else
																									{
																										GlobalVar.decisions[whichfish].TCode = num17;
																										DebugRecord.ceshi(i, "one左上角草泥马的赋档位老子不干了");
																										DebugRecord.ceshi(i, "onetcode", (float)num17);
																										num18 = 9 - num18;
																										bool flag77 = num18 <= 6;
																										if (flag77)
																										{
																											num18 = 6;
																										}
																										GlobalVar.decisions[whichfish].VCode = num18;
																										DebugRecord.ceshi(i, "onevcode", (float)num18);
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																		else
																		{
																			bool flag78 = (whichfish == 0 && GlobalVar.Bringing_BallID[0] != 4) || (whichfish == 1 && GlobalVar.Bringing_BallID[1] != 5);
																			if (flag78)
																			{
																				bool flag79 = whichfish == 0 && Math.Abs(num5) > 550.0 && Math.Abs(num4) > 1000.0 && Math.Abs(num5) > (double)(Math.Abs(GlobalVar.balls[4].PositionMm.Z) - 66f) && Math.Abs(num5) > (double)(Math.Abs(GlobalVar.balls[num10].PositionMm.Z) - 66f);
																				if (flag79)
																				{
																					double num19 = (double)GlobalVar.MyTeam.Fishes[whichfish].BodyDirectionRad;
																					double pi2 = GlobalVar.PI;
																					bool flag80 = GlobalVar.jiaoluobaiwei[whichfish] == 1;
																					if (flag80)
																					{
																						DebugRecord.ceshi(i, "one角落带球之右上角角落甩尾，速1角1");
																						GlobalVar.decisions[whichfish].TCode = 1;
																						GlobalVar.decisions[whichfish].VCode = 1;
																						bool flag81 = Math.Abs(num19 - 0.5 * pi2) < pi2 / 8.0 || Math.Abs(num5) < (double)Math.Abs(GlobalVar.balls[4].PositionMm.Z) || Math.Abs(num5) < 600.0;
																						if (flag81)
																						{
																							GlobalVar.jiaoluobaiwei[whichfish] = 0;
																						}
																						bool flag82 = Math.Abs(num5) < Math.Abs(num2) - 50.0;
																						if (flag82)
																						{
																							GlobalVar.liangqiutongchan[0] = 1;
																						}
																					}
																					bool flag83 = Math.Abs(num2) > 300.0 && (num < -1250.0 || (GlobalVar.jiaoluobaiwei[whichfish] == 1 && num < -1100.0)) && (whichfish == 0 && GlobalVar.balls[4].PositionMm.X < -1200f) && GlobalVar.balls[4].PositionMm.Z > 300f;
																					if (flag83)
																					{
																						GlobalVar.jiaoluobaiwei[whichfish] = 1;
																						double num20 = Math.Abs(num7 - 1000.0);
																						double num21 = (double)GlobalVar.Fish_length;
																						double num22 = 2.0 - 3.0 * pi2 / 2.0;
																						bool flag84 = num20 < num21;
																						double num23;
																						if (flag84)
																						{
																							num23 = Math.Acos(num20 / num21);
																						}
																						else
																						{
																							num23 = pi2 - 2.0;
																						}
																						bool flag85 = (double)num8 * num22 > (double)num8 * (-pi2 / 2.0 - num23);
																						if (flag85)
																						{
																							num22 = -pi2 / 2.0 - num23;
																						}
																						num22 += 0.3;
																						int num24 = this.TransfromAngletoTCode((double)num8 * num22 - num19);
																						int num25 = Math.Abs(9 - num24);
																						bool flag86 = (double)num8 * num19 > 0.0 || (double)num8 * num19 < -(pi2 - 0.1);
																						if (flag86)
																						{
																							DebugRecord.ceshi(i, "one右上角角落带球之鱼体方向未达到要求，速6角7+-3");
																							bool flag87 = (double)num8 * num19 > 0.0;
																							if (flag87)
																							{
																								GlobalVar.decisions[whichfish].VCode = 6;
																								GlobalVar.decisions[whichfish].TCode = 7 + num8 * 3;
																							}
																							else
																							{
																								GlobalVar.decisions[whichfish].VCode = 6;
																								GlobalVar.decisions[whichfish].TCode = 7 + num8 * 3;
																							}
																						}
																						else
																						{
																							bool flag88 = Math.Abs(num7) > 750.0;
																							if (flag88)
																							{
																								num22 = -pi2 / 2.0 - num23;
																								num22 -= 0.1;
																								bool flag89 = Math.Abs(num19) > Math.Abs(num22);
																								if (flag89)
																								{
																									DebugRecord.ceshi(i, "one右上角角落带球之鱼头坐标未达到要求之速2角7+-2");
																									GlobalVar.decisions[whichfish].TCode = 7 + num8 * 2;
																									GlobalVar.decisions[whichfish].VCode = 2;
																								}
																								else
																								{
																									DebugRecord.ceshi(i, "one右上角角落带球之鱼头坐标未达到要求之角7速5");
																									GlobalVar.decisions[whichfish].TCode = 7;
																									GlobalVar.decisions[whichfish].VCode = 5;
																								}
																							}
																							else
																							{
																								bool flag90 = Math.Abs(num19) < Math.Abs(num22) + 0.15 && Math.Abs(num19) > Math.Abs(num22) - 0.15;
																								if (flag90)
																								{
																									GlobalVar.decisions[whichfish].TCode = 7;
																									GlobalVar.decisions[whichfish].VCode = 13 - num25;
																									DebugRecord.ceshi(i, "one右上角角落带球之鱼头坐标达到要求角7");
																									DebugRecord.ceshi(i, "vcode", (float)(13 - num25));
																								}
																								else
																								{
																									bool flag91 = Math.Abs(num19) < Math.Abs(num22);
																									if (flag91)
																									{
																										bool flag92 = Math.Abs(GlobalVar.prefish[whichfish].preTcode - num24) > 1;
																										if (flag92)
																										{
																											num24 = Math.Sign(GlobalVar.prefish[whichfish].preTcode - num24) + num24;
																										}
																										GlobalVar.decisions[whichfish].TCode = num24;
																										DebugRecord.ceshi(i, "one右上角草泥马的赋档位老子不干了");
																										DebugRecord.ceshi(i, "tcode", (float)num24);
																										num25 = 3 - num25;
																										bool flag93 = num25 < 1;
																										if (flag93)
																										{
																											num25 = 1;
																										}
																										bool flag94 = Math.Abs(GlobalVar.prefish[whichfish].preVcode - num25) > 2;
																										if (flag94)
																										{
																											num25 = (num25 + GlobalVar.prefish[whichfish].preVcode) / 2;
																										}
																										GlobalVar.decisions[whichfish].VCode = num25;
																										DebugRecord.ceshi(i, "vcode", (float)num25);
																									}
																									else
																									{
																										DebugRecord.ceshi(i, "one右上角带球草泥马的赋档位老子不干了");
																										GlobalVar.decisions[whichfish].TCode = num24;
																										DebugRecord.ceshi(i, "tcode", (float)num24);
																										num25 = 9 - num25;
																										bool flag95 = num25 <= 6;
																										if (flag95)
																										{
																											num25 = 6;
																										}
																										GlobalVar.decisions[whichfish].VCode = num25;
																										DebugRecord.ceshi(i, "tempvcode", (float)num25);
																									}
																								}
																							}
																						}
																					}
																				}
																				else
																				{
																					bool flag96 = Math.Abs(num5) > 550.0 && Math.Abs(num4) > 1000.0 && Math.Abs(num5) > (double)(Math.Abs(GlobalVar.balls[5].PositionMm.Z) - 66f) && Math.Abs(num5) > (double)(Math.Abs(GlobalVar.balls[num10].PositionMm.Z) - 66f);
																					if (flag96)
																					{
																						double num26 = (double)GlobalVar.MyTeam.Fishes[whichfish].BodyDirectionRad;
																						double pi3 = GlobalVar.PI;
																						bool flag97 = GlobalVar.jiaoluobaiwei[whichfish] == 1;
																						if (flag97)
																						{
																							DebugRecord.ceshi(i, "one角落带球之右下角角落甩尾，速1角14");
																							GlobalVar.decisions[whichfish].TCode = 14;
																							GlobalVar.decisions[whichfish].VCode = 1;
																							bool flag98 = Math.Abs(num26 + 0.5 * pi3) < pi3 / 8.0 || Math.Abs(num5) < (double)Math.Abs(GlobalVar.balls[5].PositionMm.Z);
																							if (flag98)
																							{
																								GlobalVar.jiaoluobaiwei[whichfish] = 0;
																								GlobalVar.liangqiutongchan[1] = 1;
																							}
																							bool flag99 = Math.Abs(num5) < Math.Abs(num2) - 50.0;
																							if (flag99)
																							{
																								GlobalVar.liangqiutongchan[1] = 1;
																							}
																						}
																						bool flag100 = Math.Abs(num2) > 300.0 && (num < -1250.0 || (GlobalVar.jiaoluobaiwei[whichfish] == 1 && num < -1100.0)) && (whichfish == 1 && GlobalVar.balls[5].PositionMm.X < -1200f) && GlobalVar.balls[5].PositionMm.Z < -300f;
																						if (flag100)
																						{
																							GlobalVar.jiaoluobaiwei[whichfish] = 1;
																							double num27 = Math.Abs(num7 - 1000.0);
																							double num28 = (double)GlobalVar.Fish_length;
																							double num29 = 2.0 - 3.0 * pi3 / 2.0;
																							bool flag101 = num27 < num28;
																							double num30;
																							if (flag101)
																							{
																								num30 = Math.Acos(num27 / num28);
																							}
																							else
																							{
																								num30 = pi3 - 2.0;
																							}
																							bool flag102 = (double)num8 * num29 > (double)num8 * (-pi3 / 2.0 - num30);
																							if (flag102)
																							{
																								num29 = -pi3 / 2.0 - num30;
																							}
																							num29 += 0.3;
																							int num31 = this.TransfromAngletoTCode((double)num8 * num29 - num26);
																							int num32 = Math.Abs(9 - num31);
																							bool flag103 = (double)num8 * num26 > 0.0 || (double)num8 * num26 < -(pi3 - 0.1);
																							if (flag103)
																							{
																								bool flag104 = (double)num8 * num26 > 0.0;
																								if (flag104)
																								{
																									DebugRecord.ceshi(i, "one角落带球之右下角鱼体方向未达到要求，速5角7+-4");
																									GlobalVar.decisions[whichfish].VCode = 5;
																									GlobalVar.decisions[whichfish].TCode = 7 + num8 * 4;
																								}
																								else
																								{
																									DebugRecord.ceshi(i, "one角落带球之右下角鱼体方向未达到要求，速5角7+-4");
																									GlobalVar.decisions[whichfish].VCode = 5;
																									GlobalVar.decisions[whichfish].TCode = 7 + num8 * 4;
																								}
																							}
																							else
																							{
																								bool flag105 = Math.Abs(num7) > 750.0;
																								if (flag105)
																								{
																									num29 = -pi3 / 2.0 - num30;
																									num29 -= 0.1;
																									bool flag106 = Math.Abs(num26) > Math.Abs(num29);
																									if (flag106)
																									{
																										DebugRecord.ceshi(i, "one角落带球之右下角鱼头坐标未达到要求，速2角7+-2");
																										GlobalVar.decisions[whichfish].TCode = 7 + num8 * 2;
																										GlobalVar.decisions[whichfish].VCode = 2;
																									}
																									else
																									{
																										DebugRecord.ceshi(i, "one角落带球之右下角鱼头坐标未达到要求，速5角7");
																										GlobalVar.decisions[whichfish].TCode = 7;
																										GlobalVar.decisions[whichfish].VCode = 5;
																									}
																								}
																								else
																								{
																									bool flag107 = Math.Abs(num26) < Math.Abs(num29) + 0.15 && Math.Abs(num26) > Math.Abs(num29) - 0.15;
																									if (flag107)
																									{
																										DebugRecord.ceshi(i, "one角落带球之右下角鱼头坐标达到要求，角8");
																										GlobalVar.decisions[whichfish].TCode = 8;
																										GlobalVar.decisions[whichfish].VCode = 12 - num32;
																										DebugRecord.ceshi(i, "vcode", (float)(12 - num32));
																									}
																									else
																									{
																										bool flag108 = Math.Abs(num26) < Math.Abs(num29);
																										if (flag108)
																										{
																											DebugRecord.ceshi(i, "one角落带球之右下角老子不干了的赋档位");
																											bool flag109 = Math.Abs(GlobalVar.prefish[whichfish].preTcode - num31) > 1;
																											if (flag109)
																											{
																												num31 = Math.Sign(GlobalVar.prefish[whichfish].preTcode - num31) + num31;
																											}
																											GlobalVar.decisions[whichfish].TCode = num31;
																											DebugRecord.ceshi(i, "tcode", (float)num31);
																											num32 = 3 - num32;
																											bool flag110 = num32 < 1;
																											if (flag110)
																											{
																												num32 = 1;
																											}
																											bool flag111 = Math.Abs(GlobalVar.prefish[whichfish].preVcode - num32) > 2;
																											if (flag111)
																											{
																												num32 = (num32 + GlobalVar.prefish[whichfish].preVcode) / 2;
																											}
																											GlobalVar.decisions[whichfish].VCode = num32;
																											DebugRecord.ceshi(i, "vcode", (float)num32);
																										}
																										else
																										{
																											DebugRecord.ceshi(i, "one角落带球之右下角老子不干了的赋档位");
																											GlobalVar.decisions[whichfish].TCode = num31;
																											DebugRecord.ceshi(i, "tcode", (float)num31);
																											num32 = 9 - num32;
																											bool flag112 = num32 <= 6;
																											if (flag112)
																											{
																												num32 = 6;
																											}
																											GlobalVar.decisions[whichfish].VCode = num32;
																											DebugRecord.ceshi(i, "vcode", (float)num32);
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
																GlobalVar.boundary_dribbleact[0] = 0;
																GlobalVar.boundary_dribbleact[1] = 0;
															}
															} // 结束挑球else块
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000025 RID: 37 RVA: 0x0000C224 File Offset: 0x0000A424
		public void Dribblehometest3(int whichfish, int whichball)
		{
			double num = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.X;
			double num2 = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.Z;
			double num3 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
			double num4 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
			double num5 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].X;
			double num6 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
			double num7 = (double)GlobalVar.MyTeam.Fishes[whichfish].VelocityMmPs;
			double num8 = (double)GlobalVar.MyTeam.Fishes[whichfish].VelocityDirectionRad;
			double pi = GlobalVar.PI;
			bool flag = whichfish == 0;
			int num9;
			if (flag)
			{
				num9 = 1;
			}
			else
			{
				num9 = -1;
			}
			bool flag2 = GlobalVar.Paishu > 3000 || GlobalVar.final == 1;
			if (flag2)
			{
				bool flag3 = num2 > 300.0;
				if (flag3)
				{
					num9 = 1;
				}
				else
				{
					bool flag4 = num2 < -300.0;
					if (flag4)
					{
						num9 = -1;
					}
				}
			}
			else
			{
				bool flag5 = GlobalVar.Paishu > 1500 || GlobalVar.final == 1;
				if (flag5)
				{
					bool flag6 = num2 > 700.0;
					if (flag6)
					{
						num9 = 1;
					}
					else
					{
						bool flag7 = num2 < -700.0;
						if (flag7)
						{
							num9 = -1;
						}
					}
				}
			}
			DebugRecord.ceshi(0, "flag", (float)num9);
			bool flag8 = num9 == 1;
			if (flag8)
			{
				bool flag9 = num > -1420.0 && (num <= -1420.0 || num >= -978.0 || Math.Abs(num2) >= 507.0) && (num <= -1420.0 || num >= -1200.0 || Math.Abs(num2) >= 740.0);
				if (flag9)
				{
					bool flag10 = Math.Abs(num2) < 800.0;
					if (flag10)
					{
						DebugRecord.ceshi(0, "buzai bian jie");
						bool flag11 = num < -978.0;
						if (flag11)
						{
							bool flag12 = 1500.0 - Math.Abs(num) < 1000.0 - Math.Abs(num2);
							if (flag12)
							{
								DebugRecord.ceshi(0, "zuobianjie");
								this.Dribble(whichfish, whichball, -1500.0, num2 - (double)(num9 * 50));
							}
							else
							{
								DebugRecord.ceshi(0, "shangbianjie");
								this.Dribble(whichfish, whichball, num - 100.0, (double)(num9 * 1000));
							}
						}
						else
						{
							this.Dribble(whichfish, whichball, num - 100.0, (double)(num9 * 1000));
							DebugRecord.ceshi(0, "daidaobianjie");
						}
					}
					else
					{
						DebugRecord.ceshi(0, "球带到了上下边界");
						bool flag13 = (num5 < num && (num8 * (double)num9 < pi / 2.0 || Math.Abs(num6) < Math.Abs(num2) || num5 - num < -10.0)) || Math.Abs(num6) < 950.0;
						if (flag13)
						{
							DebugRecord.ceshi(0, "judge 1 yutou", Math.Abs(num6));
							double distance = Compute.GetDistance(num5, num6, num, num2);
							bool flag14 = num5 < num && distance < 100.0;
							if (flag14)
							{
								GlobalVar.decisions[whichfish].VCode = 2;
								GlobalVar.decisions[whichfish].TCode = 7 - num9 * 4;
								DebugRecord.ceshi(0, "摆动带球");
							}
							else
							{
								bool flag15 = Math.Abs(num6) < 800.0;
								if (flag15)
								{
									this.Position(whichfish, num + 80.0, (double)(num9 * 910), 150.0);
								}
								else
								{
									this.Position(whichfish, num + 80.0, (double)(num9 * 1000), 150.0);
									DebugRecord.ceshi(7, "buzhengchang");
								}
							}
						}
						else
						{
							int num10 = this.TransfromAngletoTCode((double)num9 * 2.0 - num8);
							int num11 = Math.Abs(7 - num10);
							DebugRecord.ceshi(0, "鱼头在上下边界，并且不适合摆球");
							bool flag16 = Math.Abs(num2) > 800.0;
							if (flag16)
							{
								DebugRecord.ceshi(0, "judge 2-1 角加速度 线加速度", (float)num10, (float)num11);
								bool flag17 = Math.Abs(num8) > 1.85 && Math.Abs(num8) < 2.15;
								if (flag17)
								{
									GlobalVar.decisions[whichfish].TCode = num10;
									GlobalVar.decisions[whichfish].VCode = 11 - num11;
								}
								else
								{
									bool flag18 = Math.Abs(num8) > 2.0;
									if (flag18)
									{
										GlobalVar.decisions[whichfish].TCode = num10;
										num11 = 5 - num11;
										bool flag19 = num11 < 1;
										if (flag19)
										{
											num11 = 1;
										}
										GlobalVar.decisions[whichfish].VCode = num11;
									}
									else
									{
										GlobalVar.decisions[whichfish].TCode = num10;
										bool flag20 = num11 >= 2;
										if (flag20)
										{
											num11 = 2;
										}
										GlobalVar.decisions[whichfish].VCode = 10 - num11;
									}
								}
							}
						}
					}
				}
				else
				{
					DebugRecord.ceshi(0, "阴影部分或者在左边界");
					bool flag21 = Math.Abs(num2) > 200.0;
					if (flag21)
					{
						bool flag22 = Math.Abs(num2) > 780.0;
						if (flag22)
						{
							bool flag23 = (double)num9 * num8 >= 0.0;
							if (flag23)
							{
								DebugRecord.ceshi(0, "头顶着上边界转向左边界");
								int num12 = 1500 - (int)Math.Abs(num5);
								bool flag24 = num2 > -800.0;
								if (flag24)
								{
									num12 += 10;
								}
								bool flag25 = num12 > 20;
								if (flag25)
								{
									this.Position(whichfish, -1500.0, (double)(num9 * 1000), 300.0);
									DebugRecord.ceshi(0, "0号鱼测试点0");
								}
								else
								{
									GlobalVar.decisions[whichfish].VCode = 2;
									GlobalVar.decisions[whichfish].TCode = 7 + num9 * 4;
									DebugRecord.ceshi(0, "0号鱼测试点1");
								}
							}
							else
							{
								DebugRecord.ceshi(0, "不知道是啥的else");
								double num13 = 1000.0 - Math.Abs(num6);
								double num14 = (double)GlobalVar.Fish_length;
								double num15 = Math.Acos(num13 / num14);
								bool flag26 = num15 < 1.15;
								if (flag26)
								{
									num15 = 1.15;
								}
								bool flag27 = Math.Abs(num8) >= pi / 2.0 + num15;
								if (flag27)
								{
									GlobalVar.decisions[whichfish].VCode = 1;
									GlobalVar.decisions[whichfish].TCode = 7 + num9 * 5;
									DebugRecord.ceshi(0, "0号鱼测试点3");
								}
								else
								{
									GlobalVar.decisions[whichfish].VCode = 3;
									GlobalVar.decisions[whichfish].TCode = 7;
									DebugRecord.ceshi(0, "0号鱼测试点4");
								}
							}
							bool flag28 = num5 - num >= 60.0;
							if (flag28)
							{
								bool flag29 = (double)num9 * num8 < -1.047;
								if (flag29)
								{
									GlobalVar.decisions[whichfish].VCode = 1;
									GlobalVar.decisions[whichfish].TCode = 7 - num9 * 7;
									DebugRecord.ceshi(0, "0号鱼测试点5");
								}
								else
								{
									bool flag30 = Math.Abs(num8) < 1.047;
									if (flag30)
									{
										GlobalVar.decisions[whichfish].VCode = 1;
										GlobalVar.decisions[whichfish].TCode = 7 + num9 * 7;
										DebugRecord.ceshi(0, "0号鱼测试点6");
									}
									else
									{
										bool flag31 = num5 > -1000.0;
										if (flag31)
										{
											this.Position(whichfish, -1200.0, (double)(num9 * 1000), 100.0);
											DebugRecord.ceshi(0, "0号鱼测试点7");
										}
										else
										{
											bool flag32 = num5 < -1200.0;
											if (flag32)
											{
												this.Position(whichfish, -1500.0, (double)(num9 * 1000), 100.0);
												DebugRecord.ceshi(0, "0号鱼测试点8");
											}
										}
									}
								}
							}
							else
							{
								bool flag33 = Math.Abs(num2) - Math.Abs(num6) > 30.0 && num5 - num < 60.0;
								if (flag33)
								{
									GlobalVar.decisions[whichfish].VCode = 1;
									GlobalVar.decisions[whichfish].TCode = 7 - num9 * 7;
									DebugRecord.ceshi(0, "0号鱼测试点8-0");
								}
							}
						}
						else
						{
							double num16 = Math.Abs(num6 - 1000.0);
							double num17 = (double)GlobalVar.Fish_length;
							double num18 = 2.0 - 3.0 * pi / 2.0;
							bool flag34 = num16 < num17;
							double num19;
							if (flag34)
							{
								num19 = Math.Acos(num16 / num17);
							}
							else
							{
								num19 = pi - 2.0;
							}
							bool flag35 = (double)num9 * num18 > (double)num9 * (-pi / 2.0 - num19);
							if (flag35)
							{
								num18 = -pi / 2.0 - num19;
							}
							int num20 = this.TransfromAngletoTCode((double)num9 * num18 - num8);
							int num21 = Math.Abs(7 - num20);
							bool flag36 = (double)num9 * num8 > 0.0 || (double)num9 * num8 < -(pi - 0.3);
							if (flag36)
							{
								bool flag37 = (double)num9 * num8 > 0.0;
								if (flag37)
								{
									GlobalVar.decisions[whichfish].VCode = 4;
									GlobalVar.decisions[whichfish].TCode = 7 + num9 * 4;
									DebugRecord.ceshi(0, "0号鱼测试点9");
									double x = num3 + num7 * 0.1 * Math.Cos(num8);
									double z = num4 + num7 * 0.1 * Math.Sin(num8);
									double distance2 = Compute.GetDistance(num3, num4, -1500.0, -1000.0);
									double distance3 = Compute.GetDistance(x, z, -1500.0, -1000.0);
									bool flag38 = distance2 < 50.0 && distance3 < 50.0;
									if (flag38)
									{
										DebugRecord.ceshi(5, "防BUG");
										GlobalVar.decisions[whichfish].VCode = 1;
										bool flag39 = num9 == 1;
										if (flag39)
										{
											GlobalVar.decisions[whichfish].TCode = 14;
										}
										else
										{
											GlobalVar.decisions[whichfish].VCode = 0;
										}
									}
								}
								else
								{
									GlobalVar.decisions[whichfish].VCode = 4;
									GlobalVar.decisions[whichfish].TCode = 7 + num9 * 4;
									DebugRecord.ceshi(0, "0号鱼测试点10");
								}
							}
							else
							{
								bool flag40 = Math.Abs(num6) > 750.0;
								if (flag40)
								{
									num18 = -pi / 2.0 - num19;
									num18 -= 0.1;
									bool flag41 = Math.Abs(num8) > Math.Abs(num18);
									if (flag41)
									{
										GlobalVar.decisions[whichfish].TCode = 7 + num9 * 2;
										GlobalVar.decisions[whichfish].VCode = 5;
									}
									else
									{
										GlobalVar.decisions[whichfish].TCode = 7;
										GlobalVar.decisions[whichfish].VCode = 7;
									}
								}
								else
								{
									bool flag42 = Math.Abs(num8) < Math.Abs(num18) + 0.05 && Math.Abs(num8) > Math.Abs(num18) - 0.05;
									if (flag42)
									{
										GlobalVar.decisions[whichfish].TCode = 7;
										GlobalVar.decisions[whichfish].VCode = 12 - num21;
									}
									else
									{
										bool flag43 = Math.Abs(num8) < Math.Abs(num18);
										if (flag43)
										{
											bool flag44 = Math.Abs(GlobalVar.prefish[whichfish].preTcode - num20) > 1;
											if (flag44)
											{
												num20 = Math.Sign(GlobalVar.prefish[whichfish].preTcode - num20) + num20;
											}
											GlobalVar.decisions[whichfish].TCode = num20;
											num21 = 9 - num21;
											bool flag45 = num21 < 1;
											if (flag45)
											{
												num21 = 1;
											}
											bool flag46 = Math.Abs(GlobalVar.prefish[whichfish].preVcode - num21) > 2;
											if (flag46)
											{
												num21 = (num21 + GlobalVar.prefish[whichfish].preVcode) / 2;
											}
											GlobalVar.decisions[whichfish].VCode = num21;
										}
										else
										{
											GlobalVar.decisions[whichfish].TCode = num20;
											num21 = 3 - num21;
											bool flag47 = num21 <= 6;
											if (flag47)
											{
												num21 = 6;
											}
											GlobalVar.decisions[whichfish].VCode = num21;
										}
									}
								}
							}
							bool flag48 = num5 - num >= 60.0;
							if (flag48)
							{
								bool flag49 = (double)num9 * num8 < -1.047;
								if (flag49)
								{
									GlobalVar.decisions[whichfish].VCode = 1;
									GlobalVar.decisions[whichfish].TCode = 7 - num9 * 7;
								}
								else
								{
									bool flag50 = Math.Abs(num8) < 1.047;
									if (flag50)
									{
										GlobalVar.decisions[whichfish].VCode = 1;
										GlobalVar.decisions[whichfish].TCode = 7 + num9 * 7;
									}
								}
								bool flag51 = num5 > -1000.0;
								if (flag51)
								{
									this.Position(whichfish, -1200.0, num2 + (double)(num9 * 50), 200.0);
								}
								else
								{
									bool flag52 = num5 < -1200.0;
									if (flag52)
									{
										this.Position(whichfish, -1500.0, num2 + (double)(num9 * 65), 100.0);
									}
								}
							}
							else
							{
								bool flag53 = Math.Abs(num2) - Math.Abs(num6) > 30.0 && num5 - num < 60.0;
								if (flag53)
								{
									GlobalVar.decisions[whichfish].VCode = 1;
									GlobalVar.decisions[whichfish].TCode = 7 - num9 * 7;
								}
							}
						}
					}
					else
					{
						GlobalVar.whether_change_to_test3[whichfish] = 0;
					}
				}
			}
			else
			{
				bool flag54 = num9 == -1;
				if (flag54)
				{
					bool flag55 = num > -1420.0 && (num <= -1420.0 || num >= -978.0 || Math.Abs(num2) >= 507.0) && (num <= -1420.0 || num >= -1200.0 || Math.Abs(num2) >= 750.0);
					if (flag55)
					{
						bool flag56 = Math.Abs(num2) < 840.0;
						if (flag56)
						{
							DebugRecord.ceshi(0, "buzai bian jie");
							bool flag57 = num < -978.0;
							if (flag57)
							{
								bool flag58 = 1500.0 - Math.Abs(num) < 1000.0 - Math.Abs(num2);
								if (flag58)
								{
									DebugRecord.ceshi(0, "zuobianjie");
									this.Dribble(whichfish, whichball, -1500.0, num2 - (double)(num9 * 50));
								}
								else
								{
									DebugRecord.ceshi(0, "shangbianjie");
									this.Dribble(whichfish, whichball, num - 100.0, (double)(num9 * 1000));
								}
							}
							else
							{
								this.Dribble(whichfish, whichball, num - 100.0, (double)(num9 * 1000));
								DebugRecord.ceshi(0, "daidaobianjie");
							}
						}
						else
						{
							DebugRecord.ceshi(0, "球带到了上下边界");
							bool flag59 = (num5 < num && (num8 * (double)num9 < pi / 2.0 || Math.Abs(num6) < Math.Abs(num2) || num5 - num < -10.0)) || Math.Abs(num6) < 950.0;
							if (flag59)
							{
								DebugRecord.ceshi(0, "judge 1 yutou", Math.Abs(num6));
								double distance4 = Compute.GetDistance(num5, num6, num, num2);
								bool flag60 = num5 < num && distance4 < 100.0;
								if (flag60)
								{
									GlobalVar.decisions[whichfish].VCode = 2;
									GlobalVar.decisions[whichfish].TCode = 7 - num9 * 4;
									DebugRecord.ceshi(0, "摆动带球");
								}
								else
								{
									bool flag61 = Math.Abs(num6) < 840.0;
									if (flag61)
									{
										this.Position(whichfish, num + 80.0, (double)(num9 * 910), 150.0);
									}
									else
									{
										this.Position(whichfish, num + 80.0, (double)(num9 * 1000), 150.0);
										DebugRecord.ceshi(7, "buzhengchang");
									}
								}
							}
							else
							{
								int num22 = this.TransfromAngletoTCode((double)num9 * 2.0 - num8);
								int num23 = Math.Abs(7 - num22);
								DebugRecord.ceshi(0, "鱼头在上下边界，并且不适合摆球");
								bool flag62 = Math.Abs(num2) > 840.0;
								if (flag62)
								{
									DebugRecord.ceshi(0, "judge 2-1 角加速度 线加速度", (float)num22, (float)num23);
									bool flag63 = Math.Abs(num8) > 1.85 && Math.Abs(num8) < 2.15;
									if (flag63)
									{
										GlobalVar.decisions[whichfish].TCode = num22;
										GlobalVar.decisions[whichfish].VCode = 11 - num23;
									}
									else
									{
										bool flag64 = Math.Abs(num8) > 2.0;
										if (flag64)
										{
											GlobalVar.decisions[whichfish].TCode = num22;
											num23 = 5 - num23;
											bool flag65 = num23 < 1;
											if (flag65)
											{
												num23 = 1;
											}
											GlobalVar.decisions[whichfish].VCode = num23;
										}
										else
										{
											GlobalVar.decisions[whichfish].TCode = num22;
											bool flag66 = num23 >= 2;
											if (flag66)
											{
												num23 = 2;
											}
											GlobalVar.decisions[whichfish].VCode = 10 - num23;
										}
									}
								}
							}
						}
					}
					else
					{
						DebugRecord.ceshi(0, "阴影部分或者在左边界");
						bool flag67 = Math.Abs(num2) > 200.0;
						if (flag67)
						{
							bool flag68 = Math.Abs(num2) > 820.0;
							if (flag68)
							{
								bool flag69 = (double)num9 * num8 >= 0.0;
								if (flag69)
								{
									DebugRecord.ceshi(0, "头顶着上边界转向左边界");
									int num24 = 1500 - (int)Math.Abs(num5);
									bool flag70 = num2 > -800.0;
									if (flag70)
									{
										num24 += 10;
									}
									bool flag71 = num24 > 20;
									if (flag71)
									{
										this.Position(whichfish, -1500.0, (double)(num9 * 1000), 300.0);
										DebugRecord.ceshi(0, "测试点0");
									}
									else
									{
										GlobalVar.decisions[whichfish].VCode = 2;
										GlobalVar.decisions[whichfish].TCode = 7 + num9 * 4;
										DebugRecord.ceshi(0, "测试点1");
									}
								}
								else
								{
									DebugRecord.ceshi(0, "不知道是啥的else");
									double num25 = 1000.0 - Math.Abs(num6);
									double num26 = (double)GlobalVar.Fish_length;
									double num27 = Math.Acos(num25 / num26);
									bool flag72 = num27 < 1.15;
									if (flag72)
									{
										num27 = 1.15;
									}
									bool flag73 = Math.Abs(num8) >= pi / 2.0 + num27;
									if (flag73)
									{
										GlobalVar.decisions[whichfish].VCode = 1;
										GlobalVar.decisions[whichfish].TCode = 7 + num9 * 5;
										DebugRecord.ceshi(0, "测试点2");
									}
									else
									{
										GlobalVar.decisions[whichfish].VCode = 3;
										GlobalVar.decisions[whichfish].TCode = 7;
										DebugRecord.ceshi(0, "测试点3");
									}
								}
								bool flag74 = num5 - num >= 60.0;
								if (flag74)
								{
									DebugRecord.ceshi(0, "测试点4-0");
									bool flag75 = (double)num9 * num8 < -1.047;
									if (flag75)
									{
										GlobalVar.decisions[whichfish].VCode = 1;
										GlobalVar.decisions[whichfish].TCode = 7 - num9 * 7;
										DebugRecord.ceshi(0, "测试点4");
									}
									else
									{
										bool flag76 = Math.Abs(num8) < 1.047;
										if (flag76)
										{
											GlobalVar.decisions[whichfish].VCode = 1;
											GlobalVar.decisions[whichfish].TCode = 7 + num9 * 7;
											DebugRecord.ceshi(0, "测试点5");
										}
										else
										{
											bool flag77 = num5 > -1000.0;
											if (flag77)
											{
												DebugRecord.ceshi(0, "测试点6");
												this.Position(whichfish, -1200.0, (double)(num9 * 1000), 100.0);
											}
											else
											{
												bool flag78 = num5 < -1200.0;
												if (flag78)
												{
													this.Position(whichfish, -1500.0, (double)(num9 * 1000), 100.0);
												}
											}
										}
									}
								}
								else
								{
									bool flag79 = Math.Abs(num2) - Math.Abs(num6) > 30.0 && num5 - num < 60.0;
									if (flag79)
									{
										GlobalVar.decisions[whichfish].VCode = 1;
										GlobalVar.decisions[whichfish].TCode = 7 - num9 * 7;
										DebugRecord.ceshi(0, "测试点7");
									}
								}
							}
							else
							{
								double num28 = Math.Abs(num6 - 1000.0);
								double num29 = (double)GlobalVar.Fish_length;
								double num30 = 2.0 - 3.0 * pi / 2.0;
								bool flag80 = num28 < num29;
								double num31;
								if (flag80)
								{
									num31 = Math.Acos(num28 / num29);
								}
								else
								{
									num31 = pi - 2.0;
								}
								bool flag81 = (double)num9 * num30 > (double)num9 * (-pi / 2.0 - num31);
								if (flag81)
								{
									num30 = -pi / 2.0 - num31;
								}
								int num32 = this.TransfromAngletoTCode((double)num9 * num30 - num8);
								int num33 = Math.Abs(7 - num32);
								bool flag82 = (double)num9 * num8 > 0.0 || (double)num9 * num8 < -(pi - 0.3);
								if (flag82)
								{
									DebugRecord.ceshi(0, "鱼体方向还没有达到要求");
									bool flag83 = (double)num9 * num8 > 0.0;
									if (flag83)
									{
										GlobalVar.decisions[whichfish].VCode = 4;
										GlobalVar.decisions[whichfish].TCode = 7 + num9 * 4;
										DebugRecord.ceshi(0, "测试点8");
										DebugRecord.ceshi(0, "上面转体");
										double x2 = num3 + num7 * 0.1 * Math.Cos(num8);
										double z2 = num4 + num7 * 0.1 * Math.Sin(num8);
										double distance5 = Compute.GetDistance(num3, num4, -1500.0, -1000.0);
										double distance6 = Compute.GetDistance(x2, z2, -1500.0, -1000.0);
										bool flag84 = distance5 < 50.0 && distance6 < 50.0;
										if (flag84)
										{
											DebugRecord.ceshi(5, "防BUG");
											GlobalVar.decisions[whichfish].VCode = 1;
											bool flag85 = num9 == 1;
											if (flag85)
											{
												GlobalVar.decisions[whichfish].TCode = 14;
											}
											else
											{
												GlobalVar.decisions[whichfish].VCode = 0;
												DebugRecord.ceshi(0, "测试点9");
											}
										}
									}
									else
									{
										DebugRecord.ceshi(0, "下面转体");
										GlobalVar.decisions[whichfish].VCode = 4;
										GlobalVar.decisions[whichfish].TCode = 7 + num9 * 4;
										DebugRecord.ceshi(0, "测试点10");
									}
								}
								else
								{
									bool flag86 = Math.Abs(num6) > 750.0;
									if (flag86)
									{
										DebugRecord.ceshi(0, "鱼头坐标未达到要求");
										num30 = -pi / 2.0 - num31;
										num30 -= 0.1;
										bool flag87 = Math.Abs(num8) > Math.Abs(num30);
										if (flag87)
										{
											GlobalVar.decisions[whichfish].TCode = 7 + num9 * 2;
											GlobalVar.decisions[whichfish].VCode = 5;
											DebugRecord.ceshi(0, "测试点11");
										}
										else
										{
											GlobalVar.decisions[whichfish].TCode = 7;
											GlobalVar.decisions[whichfish].VCode = 7;
											DebugRecord.ceshi(0, "测试点12");
										}
									}
									else
									{
										DebugRecord.ceshi(0, "鱼头坐标达到要求");
										bool flag88 = Math.Abs(num8) < Math.Abs(num30) + 0.05 && Math.Abs(num8) > Math.Abs(num30) - 0.05;
										if (flag88)
										{
											DebugRecord.ceshi(0, "角度在平衡范围内，速度可以较大");
											GlobalVar.decisions[whichfish].TCode = 7;
											GlobalVar.decisions[whichfish].VCode = 12 - num33;
											DebugRecord.ceshi(0, "测试点13");
										}
										else
										{
											bool flag89 = Math.Abs(num8) < Math.Abs(num30);
											if (flag89)
											{
												DebugRecord.ceshi(0, "角度过小，鱼体与左边界过于扁平");
												bool flag90 = Math.Abs(GlobalVar.prefish[whichfish].preTcode - num32) > 1;
												if (flag90)
												{
													num32 = Math.Sign(GlobalVar.prefish[whichfish].preTcode - num32) + num32;
													DebugRecord.ceshi(0, "测试点14");
												}
												GlobalVar.decisions[whichfish].TCode = num32;
												num33 = 9 - num33;
												bool flag91 = num33 < 1;
												if (flag91)
												{
													num33 = 1;
													DebugRecord.ceshi(0, "测试点15");
												}
												bool flag92 = Math.Abs(GlobalVar.prefish[whichfish].preVcode - num33) > 2;
												if (flag92)
												{
													num33 = (num33 + GlobalVar.prefish[whichfish].preVcode) / 2;
													DebugRecord.ceshi(0, "测试点16");
												}
												GlobalVar.decisions[whichfish].VCode = num33;
											}
											else
											{
												DebugRecord.ceshi(0, "角度过小，鱼体与左边界夹角偏大");
												GlobalVar.decisions[whichfish].TCode = num32;
												num33 = 3 - num33;
												bool flag93 = num33 <= 6;
												if (flag93)
												{
													num33 = 6;
													DebugRecord.ceshi(0, "测试点17");
												}
												GlobalVar.decisions[whichfish].VCode = num33;
											}
										}
									}
								}
								bool flag94 = num5 - num >= 60.0;
								if (flag94)
								{
									DebugRecord.ceshi(0, "非过渡区");
									bool flag95 = (double)num9 * num8 < -1.047;
									if (flag95)
									{
										DebugRecord.ceshi(0, "小于-60度");
										GlobalVar.decisions[whichfish].VCode = 1;
										GlobalVar.decisions[whichfish].TCode = 7 - num9 * 7;
									}
									else
									{
										bool flag96 = Math.Abs(num8) < 1.047;
										if (flag96)
										{
											DebugRecord.ceshi(0, "小于60度");
											GlobalVar.decisions[whichfish].VCode = 1;
											GlobalVar.decisions[whichfish].TCode = 7 + num9 * 7;
										}
									}
									bool flag97 = num5 > -1000.0;
									if (flag97)
									{
										DebugRecord.ceshi(0, "-1000跑位");
										this.Position(whichfish, -1200.0, num2 + (double)(num9 * 50), 200.0);
									}
									else
									{
										bool flag98 = num5 < -1200.0;
										if (flag98)
										{
											DebugRecord.ceshi(0, "-1200跑位");
											this.Position(whichfish, -1500.0, num2 + (double)(num9 * 65), 100.0);
										}
									}
								}
								else
								{
									bool flag99 = Math.Abs(num2) - Math.Abs(num6) > 30.0 && num5 - num < 60.0;
									if (flag99)
									{
										GlobalVar.decisions[whichfish].VCode = 1;
										GlobalVar.decisions[whichfish].TCode = 7 - num9 * 7;
									}
								}
							}
						}
						else
						{
							GlobalVar.whether_change_to_test3[whichfish] = 0;
						}
					}
				}
			}
		}

		// Token: 0x06000026 RID: 38 RVA: 0x0000E014 File Offset: 0x0000C214
		public void boundary_dribble(int whichfish, int whichball, int num, bool dir)
		{
			double pi = GlobalVar.PI;
			RoboFish roboFish = GlobalVar.MyTeam.Fishes[whichfish];
			double num2 = (double)roboFish.VelocityDirectionRad;
			double num3 = (double)roboFish.PositionMm.X;
			double num4 = (double)roboFish.PositionMm.Z;
			double num5 = (double)roboFish.VelocityMmPs;
			double num6 = (double)roboFish.AngularVelocityRadPs;
			double num7 = (double)GlobalVar.mission.EnvRef.Balls[whichball].VelocityDirectionRad;
			double num8 = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.X;
			double num9 = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.Z;
			double num10 = (double)GlobalVar.mission.EnvRef.Balls[whichball].VelocityMmPs;
			num3 += num5 * Math.Cos(num2) * 0.1;
			num4 += num5 * Math.Sin(num2) * 0.1;
			num2 += num6 * 0.1;
			num8 += (double)GlobalVar.mission.EnvRef.Balls[whichball].VelocityMmPs * Math.Cos(num7) * 0.1;
			num9 += (double)GlobalVar.mission.EnvRef.Balls[whichball].VelocityMmPs * Math.Sin(num7) * 0.1;
			double num11 = num3 + (double)GlobalVar.Fish_centertohead * Math.Cos(num2);
			double num12 = num4 + (double)GlobalVar.Fish_centertohead * Math.Sin(num2);
			double dv = 314.0;
			double dx = 0.0;
			double dz = 0.0;
			double value = 0.0;
			int num13 = -180 + num * 90 + (dir ? 25 : -25);
			num13 = (int)Compute.FormatAngle((double)num13);
			bool flag = num == 0;
			if (flag)
			{
				if (dir)
				{
					dx = (double)(-(double)(GlobalVar.Yard_halflength + 300));
					dz = num9 - 200.0;
				}
				else
				{
					dx = (double)(-(double)(GlobalVar.Yard_halflength + 300));
					dz = num9 + 200.0;
				}
				value = (double)(-(double)(GlobalVar.Yard_halflength - 200));
			}
			bool flag2 = num == 1;
			if (flag2)
			{
				if (dir)
				{
					dx = num8 + 200.0;
					dz = (double)(-(double)(GlobalVar.Yard_halfwidth + 300));
				}
				else
				{
					dx = num8 - 200.0;
					dz = (double)(-(double)(GlobalVar.Yard_halfwidth + 300));
				}
				value = (double)(-(double)(GlobalVar.Yard_halfwidth - 200));
			}
			bool flag3 = num == 2;
			if (flag3)
			{
				if (dir)
				{
					dx = (double)(GlobalVar.Yard_halflength + 300);
					dz = num9 + 200.0;
				}
				else
				{
					dx = (double)(GlobalVar.Yard_halflength + 300);
					dz = num9 - 200.0;
				}
				value = (double)(GlobalVar.Yard_halflength - 200);
			}
			bool flag4 = num == 3;
			if (flag4)
			{
				if (dir)
				{
					dx = num8 - 200.0;
					dz = (double)(GlobalVar.Yard_halfwidth + 300);
				}
				else
				{
					dx = num8 + 200.0;
					dz = (double)(GlobalVar.Yard_halfwidth + 300);
				}
				value = (double)(GlobalVar.Yard_halfwidth - 200);
			}
			double num14 = Math.Atan2(num9 - num12, num8 - num11);
			double num15 = num14 - num2;
			num15 = Compute.FormatAngleRad(num15);
			bool flag5 = (((num == 0 || num == 2) && Math.Abs(num8) > Math.Abs(value) / 2.0) || ((num == 1 || num == 3) && Math.Abs(num9) > Math.Abs(value) / 2.0)) && ((!dir && num15 / pi * 180.0 < -5.0) || (dir && num15 / pi * 180.0 > 5.0));
			if (flag5)
			{
				bool flag6 = Math.Abs(num2 / pi * 180.0 - (double)num13) < 10.0;
				if (flag6)
				{
					this.Angle(whichfish, (double)num13 / 180.0 * pi);
					this.KeepV(whichfish, dv);
				}
				else
				{
					this.Angle(whichfish, (double)num13 / 180.0 * pi);
					this.KeepV(whichfish, 0.0);
				}
			}
			else
			{
				this.Dribble(whichfish, whichball, dx, dz);
			}
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000E4C0 File Offset: 0x0000C6C0
		public void Dribble_boundaryf2(int whichfish, int whichball)
		{
			double pi = GlobalVar.PI;
			RoboFish roboFish = GlobalVar.MyTeam.Fishes[whichfish];
			double num = (double)roboFish.VelocityDirectionRad;
			double num2 = (double)roboFish.PositionMm.X;
			double num3 = (double)roboFish.PositionMm.Z;
			double num4 = (double)roboFish.VelocityMmPs;
			double num5 = (double)roboFish.AngularVelocityRadPs;
			double num6 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].X;
			double num7 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
			double num8 = (double)GlobalVar.mission.EnvRef.Balls[whichball].VelocityDirectionRad;
			double num9 = (double)GlobalVar.mission.EnvRef.Balls[whichball].VelocityMmPs;
			double num10 = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.X;
			double num11 = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.Z;
			int num12 = 1260;
			int num13 = 850;
			bool flag = num10 > (double)num12 && Math.Abs(num11) < (double)(num13 + 50);
			if (flag)
			{
				bool flag2 = GlobalVar.Dribble_boundaryf_zt1[whichfish] == 100;
				if (flag2)
				{
					bool flag3 = num11 < 0.0;
					if (flag3)
					{
						GlobalVar.Dribble_boundaryf_zt1[whichfish] = 1;
					}
					else
					{
						GlobalVar.Dribble_boundaryf_zt1[whichfish] = 0;
					}
				}
				bool flag4 = Math.Abs(num11) > 100.0;
				if (flag4)
				{
					GlobalVar.Dribble_boundaryf_zt1[whichfish] = 100;
				}
				bool flag5 = num11 > 100.0 || GlobalVar.Dribble_boundaryf_zt1[whichfish] == 1;
				if (flag5)
				{
					this.boundary_dribble(whichfish, whichball, 2, true);
				}
				else
				{
					bool flag6 = num11 < -100.0 || GlobalVar.Dribble_boundaryf_zt1[whichfish] == 0;
					if (flag6)
					{
						this.boundary_dribble(whichfish, whichball, 2, false);
					}
				}
			}
			else
			{
				bool flag7 = num10 < (double)(-(double)num12) && Math.Abs(num11) < 700.0;
				if (flag7)
				{
					bool flag8 = GlobalVar.Dribble_boundaryf_zt2[whichfish] == 100;
					if (flag8)
					{
						bool flag9 = num11 < 0.0;
						if (flag9)
						{
							GlobalVar.Dribble_boundaryf_zt2[whichfish] = 1;
						}
						else
						{
							GlobalVar.Dribble_boundaryf_zt2[whichfish] = 0;
						}
					}
					bool flag10 = Math.Abs(num11) > 560.0;
					if (flag10)
					{
						GlobalVar.Dribble_boundaryf_zt2[whichfish] = 100;
					}
					bool flag11 = num11 < -560.0 || GlobalVar.Dribble_boundaryf_zt2[whichfish] == 1;
					if (flag11)
					{
						this.boundary_dribble(whichfish, whichball, 0, false);
					}
					bool flag12 = num11 > 560.0 || GlobalVar.Dribble_boundaryf_zt2[whichfish] == 0;
					if (flag12)
					{
						this.boundary_dribble(whichfish, whichball, 0, true);
					}
				}
				else
				{
					bool flag13 = whichfish == 0;
					int num14;
					if (flag13)
					{
						num14 = 1;
					}
					else
					{
						num14 = -1;
					}
					bool flag14 = GlobalVar.Paishu > 3000 || GlobalVar.final == 1;
					if (flag14)
					{
						bool flag15 = num11 > 300.0;
						if (flag15)
						{
							num14 = 1;
						}
						else
						{
							bool flag16 = num11 < -300.0;
							if (flag16)
							{
								num14 = -1;
							}
						}
					}
					else
					{
						bool flag17 = GlobalVar.Paishu > 1500 || GlobalVar.final == 1;
						if (flag17)
						{
							bool flag18 = num11 > 700.0;
							if (flag18)
							{
								num14 = 1;
							}
							else
							{
								bool flag19 = num11 < -700.0;
								if (flag19)
								{
									num14 = -1;
								}
							}
						}
					}
					bool flag20 = num11 * (double)num14 < 500.0;
					if (flag20)
					{
						bool flag21 = num11 * (double)num14 < -750.0;
						if (flag21)
						{
							this.Rescue_boundary(whichfish, whichball, -1000.0, 0.0);
						}
						else
						{
							this.Dribble(whichfish, whichball, num10, (double)(num14 * 1000));
						}
					}
					else
					{
						this.Dribbleboundary(whichfish, whichball);
					}
				}
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x0000E8E0 File Offset: 0x0000CAE0
		public void Rescue_boundary(int whichfish, int whichball, double dx, double dz)
		{
			double pi = GlobalVar.PI;
			RoboFish roboFish = GlobalVar.MyTeam.Fishes[whichfish];
			double num = (double)roboFish.VelocityDirectionRad;
			double num2 = (double)roboFish.PositionMm.X;
			double num3 = (double)roboFish.PositionMm.Z;
			double num4 = (double)roboFish.VelocityMmPs;
			double num5 = (double)roboFish.AngularVelocityRadPs;
			double num6 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].X;
			double num7 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
			double num8 = Math.Cos(num) * 0.9114 * num4;
			double num9 = Math.Sin(num) * 0.9114 * num4;
			int num10 = 750;
			int num11 = -50;
			int num12 = 20;
			int num13 = -50;
			int num14 = 1150;
			double num15 = (double)GlobalVar.mission.EnvRef.Balls[whichball].VelocityDirectionRad;
			double num16 = (double)GlobalVar.mission.EnvRef.Balls[whichball].VelocityMmPs;
			double num17 = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.X;
			double num18 = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.Z;
			bool flag = num < -pi;
			if (flag)
			{
				num += 2.0 * pi;
			}
			bool flag2 = num > pi;
			if (flag2)
			{
				num -= 2.0 * pi;
			}
			double num19 = Math.Abs(dz);
			double num20 = num17;
			double num21 = Math.Abs(num18);
			double num22 = Math.Sqrt((num17 - num2) * (num17 - num2) + (num18 - num3) * (num18 - num3));
			double num23 = (num19 - num21) / (dx - num20);
			double num24 = num19 - num23 * dx;
			double num25 = (1000.0 - num24) / num23;
			bool flag3 = Math.Abs(num18) > 650.0 && Math.Abs(num17) < 1150.0;
			if (flag3)
			{
				bool flag4 = num17 > 600.0 && num22 > 500.0;
				if (flag4)
				{
					GlobalVar.Rescue_boundary_zt2[whichfish] = 1;
				}
				bool flag5 = num18 > 0.0;
				if (flag5)
				{
					double num26 = (num18 + (double)num12 - num7) / (num17 - num6);
					double num27 = num7 - num26 * num6;
					bool flag6 = (GlobalVar.Rescue_boundary_Zhuangtai[whichfish] == 0 && num17 - 150.0 < num2) || (GlobalVar.Rescue_boundary_Zhuangtai[whichfish] != 0 && num17 + 150.0 < num2);
					if (flag6)
					{
						bool flag7 = Math.Abs(num18) > 800.0;
						if (flag7)
						{
							GlobalVar.Rescue_boundary_Zhuangtai[whichfish] = 0;
							bool flag8 = num17 - num6 > 90.0;
							if (flag8)
							{
								GlobalVar.Rescue_boundary_Zhuangtai[whichfish] = 1;
							}
							this.Position(whichfish, num17 - 150.0, num18 - 100.0, 300.0);
						}
						else
						{
							bool flag9 = Math.Abs(num7) - Math.Abs(num18) < 50.0 || Math.Abs(num6) - Math.Abs(num17) > 80.0;
							if (flag9)
							{
								this.Position(whichfish, num17 + 80.0, num18 + 30.0, 300.0);
							}
							else
							{
								bool flag10 = (GlobalVar.Rescue_boundary_zt1[whichfish] == 0 && num18 < (double)(num10 + 15)) || (GlobalVar.Rescue_boundary_zt1[whichfish] != 0 && num18 < (double)(num10 - 15));
								if (flag10)
								{
									this.Position(whichfish, num17 + 12.0, num18 + 35.0, 300.0);
									GlobalVar.Rescue_boundary_zt1[whichfish] = 0;
								}
								else
								{
									GlobalVar.Rescue_boundary_zt1[whichfish] = 1;
									bool flag11 = num18 > (double)num10;
									if (flag11)
									{
										bool flag12 = num < 110.0 * pi / 180.0 || num > 165.0 * pi / 180.0;
										if (flag12)
										{
											this.Angle(whichfish, 135.0 * pi / 180.0);
											this.KeepV(whichfish, 5.0);
										}
										else
										{
											this.Angle(whichfish, 135.0 * pi / 180.0);
											this.KeepV(whichfish, 300.0);
										}
									}
									bool flag13 = num18 < (double)(num10 + 100);
									if (flag13)
									{
										this.Position(whichfish, num17 - 15.0, num18 + 58.0, 314.0);
									}
								}
								bool flag14 = num17 - (num6 + num8) > (double)(-(double)num13) && num18 > (double)num10;
								if (flag14)
								{
									GlobalVar.decisions[whichfish].TCode = 12;
									GlobalVar.decisions[whichfish].VCode = 1;
								}
							}
							GlobalVar.Rescue_boundary_Zhuangtai[whichfish] = 0;
						}
					}
					else
					{
						bool flag15 = Math.Abs(num7) - Math.Abs(num18) < 50.0 || Math.Abs(num6) - Math.Abs(num17) < -80.0;
						if (flag15)
						{
							this.Position(whichfish, num17 - 80.0, num18 + 30.0, 300.0);
						}
						else
						{
							bool flag16 = (GlobalVar.Rescue_boundary_zt1[whichfish] == 0 && num18 < (double)(num10 + 15)) || (GlobalVar.Rescue_boundary_zt1[whichfish] != 0 && num18 < (double)(num10 - 15));
							if (flag16)
							{
								this.Position(whichfish, num17 - 15.0, num18 + 40.0, 300.0);
								GlobalVar.Rescue_boundary_zt1[whichfish] = 0;
							}
							else
							{
								GlobalVar.Rescue_boundary_zt1[whichfish] = 1;
								bool flag17 = num18 > (double)num10;
								if (flag17)
								{
									bool flag18 = num < 20.0 * pi / 180.0 || num > 75.0 * pi / 180.0;
									if (flag18)
									{
										this.Angle(whichfish, 45.0 * pi / 180.0);
										this.KeepV(whichfish, 5.0);
									}
									else
									{
										this.Angle(whichfish, 45.0 * pi / 180.0);
										this.KeepV(whichfish, 300.0);
									}
								}
								bool flag19 = num18 < (double)(num10 + 80);
								if (flag19)
								{
									this.Position(whichfish, num17 + 15.0, num18 + 65.0, 314.0);
								}
							}
							bool flag20 = num17 - (num6 + num8) < (double)num11 && num18 > (double)num10;
							if (flag20)
							{
								GlobalVar.decisions[whichfish].TCode = 2;
								GlobalVar.decisions[whichfish].VCode = 1;
							}
						}
						GlobalVar.Rescue_boundary_Zhuangtai[whichfish] = 1;
					}
				}
				else
				{
					double num26 = (num18 - (double)num12 - num7) / (num17 - num6);
					double num27 = num7 - num26 * num6;
					bool flag21 = (GlobalVar.Rescue_boundary_Zhuangtai[whichfish] == 0 && num17 - 150.0 < num2) || (GlobalVar.Rescue_boundary_Zhuangtai[whichfish] != 0 && num17 + 150.0 < num2);
					if (flag21)
					{
						bool flag22 = Math.Abs(num18) > 800.0;
						if (flag22)
						{
							GlobalVar.Rescue_boundary_Zhuangtai[whichfish] = 0;
							bool flag23 = num17 - num6 > 90.0;
							if (flag23)
							{
								GlobalVar.Rescue_boundary_Zhuangtai[whichfish] = 1;
							}
							this.Position(whichfish, num17 - 150.0, num18 + 100.0, 300.0);
						}
						else
						{
							bool flag24 = Math.Abs(num7) - Math.Abs(num18) < 50.0 || Math.Abs(num6) - Math.Abs(num17) > 80.0;
							if (flag24)
							{
								this.Position(whichfish, num17 + 80.0, num18 - 30.0, 300.0);
							}
							else
							{
								bool flag25 = (GlobalVar.Rescue_boundary_zt1[whichfish] == 0 && Math.Abs(num18) < (double)(num10 + 15)) || (GlobalVar.Rescue_boundary_zt1[whichfish] != 0 && Math.Abs(num18) < (double)(num10 - 15));
								if (flag25)
								{
									this.Position(whichfish, num17 + 12.0, num18 - 35.0, 300.0);
									GlobalVar.Rescue_boundary_zt1[whichfish] = 0;
								}
								else
								{
									GlobalVar.Rescue_boundary_zt1[whichfish] = 1;
									bool flag26 = Math.Abs(num18) > (double)num10;
									if (flag26)
									{
										bool flag27 = num > -110.0 * pi / 180.0 || num < -165.0 * pi / 180.0;
										if (flag27)
										{
											this.Angle(whichfish, -135.0 * pi / 180.0);
											this.KeepV(whichfish, 5.0);
										}
										else
										{
											this.Angle(whichfish, -135.0 * pi / 180.0);
											this.KeepV(whichfish, 300.0);
										}
									}
									bool flag28 = Math.Abs(num18) < (double)(num10 + 100);
									if (flag28)
									{
										this.Position(whichfish, num17 - 12.0, num18 - 58.0, 314.0);
									}
								}
								bool flag29 = num17 - (num6 + num8) > (double)(-(double)num13) && Math.Abs(num18) > (double)num10;
								if (flag29)
								{
									GlobalVar.decisions[whichfish].TCode = 2;
									GlobalVar.decisions[whichfish].VCode = 1;
								}
							}
							GlobalVar.Rescue_boundary_Zhuangtai[whichfish] = 0;
						}
					}
					else
					{
						GlobalVar.deadjudge[whichfish] = 0;
						bool flag30 = Math.Abs(num7) - Math.Abs(num18) < 50.0 || Math.Abs(num6) - Math.Abs(num17) < -80.0;
						if (flag30)
						{
							this.Position(whichfish, num17 - 80.0, num18 - 30.0, 300.0);
							GlobalVar.deadjudge[whichfish] = 1;
						}
						else
						{
							bool flag31 = (GlobalVar.Rescue_boundary_zt1[whichfish] == 0 && Math.Abs(num18) < (double)(num10 + 15)) || (GlobalVar.Rescue_boundary_zt1[whichfish] != 0 && Math.Abs(num18) < (double)(num10 - 15));
							if (flag31)
							{
								this.Position(whichfish, num17 - 15.0, num18 - 40.0, 300.0);
								GlobalVar.Rescue_boundary_zt1[whichfish] = 0;
							}
							else
							{
								GlobalVar.Rescue_boundary_zt1[whichfish] = 1;
								bool flag32 = Math.Abs(num18) > (double)num10;
								if (flag32)
								{
									bool flag33 = num > -20.0 * pi / 180.0 || num < -75.0 * pi / 180.0;
									if (flag33)
									{
										this.Angle(whichfish, -45.0 * pi / 180.0);
										this.KeepV(whichfish, 5.0);
									}
									else
									{
										this.Angle(whichfish, -45.0 * pi / 180.0);
										this.KeepV(whichfish, 300.0);
									}
								}
								bool flag34 = Math.Abs(num18) < (double)(num10 + 80);
								if (flag34)
								{
									this.Position(whichfish, num17 + 15.0, num18 - 65.0, 314.0);
								}
							}
							bool flag35 = num17 - (num6 + num8) < (double)num11 && Math.Abs(num18) > (double)num10;
							if (flag35)
							{
								GlobalVar.decisions[whichfish].TCode = 12;
								GlobalVar.decisions[whichfish].VCode = 1;
							}
						}
						GlobalVar.Rescue_boundary_Zhuangtai[whichfish] = 1;
					}
				}
				bool flag36 = GlobalVar.Rescue_boundary_zt2[whichfish] == 1 || num17 > 900.0;
				if (flag36)
				{
					GlobalVar.Rescue_boundary_zt2[whichfish] = 1;
					GlobalVar.Rescue_boundary_Zhuangtai[whichfish] = 0;
					this.Dribble_boundaryf(whichfish, whichball);
					bool flag37 = num17 < -300.0;
					if (flag37)
					{
						GlobalVar.Rescue_boundary_zt2[whichfish] = 0;
					}
				}
			}
			bool flag38 = Math.Abs(num17) > 1000.0;
			if (flag38)
			{
				bool flag39 = num17 < 0.0;
				if (flag39)
				{
					bool flag40 = ((GlobalVar.Rescue_boundary_Zhuangtai1[whichfish] == 0 && num18 - 150.0 < num3) || (GlobalVar.Rescue_boundary_Zhuangtai1[whichfish] != 0 && num18 + 150.0 < num3)) && num < -GlobalVar.PI / 15.0;
					if (flag40)
					{
						bool flag41 = Math.Abs(num6) - Math.Abs(num17) < 30.0 || num7 - num18 > 100.0;
						if (flag41)
						{
							this.Position(whichfish, num17 - 50.0, num18 + 80.0, 300.0);
						}
						else
						{
							bool flag42 = (GlobalVar.Rescue_boundary_zt1[whichfish] == 0 && num17 > (double)(-(double)num14 - 15)) || (GlobalVar.Rescue_boundary_zt1[whichfish] != 0 && num17 > (double)(-(double)num14 + 15));
							if (flag42)
							{
								this.Position(whichfish, num17 - 40.0, num18 + 15.0, 300.0);
								GlobalVar.Rescue_boundary_zt1[whichfish] = 0;
							}
							else
							{
								GlobalVar.Rescue_boundary_zt1[whichfish] = 1;
								bool flag43 = num17 < (double)(-(double)num14);
								if (flag43)
								{
									bool flag44 = num > -110.0 * pi / 180.0 || num < -150.0 * pi / 180.0;
									if (flag44)
									{
										this.Angle(whichfish, -130.0 * pi / 180.0);
										this.KeepV(whichfish, 5.0);
										bool flag45 = num > -100.0 * pi / 180.0 && num < 0.0;
										if (flag45)
										{
											bool flag46 = num > -90.0 * pi / 180.0;
											if (flag46)
											{
												GlobalVar.decisions[whichfish].TCode = 5;
											}
											GlobalVar.decisions[whichfish].TCode = 3;
										}
									}
									else
									{
										this.Angle(whichfish, -130.0 * pi / 180.0);
										this.KeepV(whichfish, 350.0);
									}
								}
								bool flag47 = num17 > (double)(-(double)num14);
								if (flag47)
								{
									this.Dribble(whichfish, whichball, num17 + 200.0, num18 - 350.0);
								}
							}
							bool flag48 = num18 - (num7 + num9) > (double)(-(double)num11 + 15) && num17 < (double)(-(double)num14);
							if (flag48)
							{
								GlobalVar.decisions[whichfish].TCode = 12;
								GlobalVar.decisions[whichfish].VCode = 1;
							}
						}
						GlobalVar.Rescue_boundary_Zhuangtai1[whichfish] = 0;
					}
					else
					{
						bool flag49 = Math.Abs(num6) - Math.Abs(num17) < 30.0 || num7 - num18 < -100.0;
						if (flag49)
						{
							this.Position(whichfish, num17 - 50.0, num18 - 80.0, 300.0);
						}
						else
						{
							bool flag50 = (GlobalVar.Rescue_boundary_zt1[whichfish] == 0 && num17 > (double)(-(double)num14 - 15)) || (GlobalVar.Rescue_boundary_zt1[whichfish] != 0 && num17 > (double)(-(double)num14 + 15));
							if (flag50)
							{
								this.Position(whichfish, num17 - 40.0, num18 - 15.0, 300.0);
								GlobalVar.Rescue_boundary_zt1[whichfish] = 0;
							}
							else
							{
								GlobalVar.Rescue_boundary_zt1[whichfish] = 1;
								bool flag51 = num17 < (double)(-(double)num14);
								if (flag51)
								{
									bool flag52 = (num < 110.0 * pi / 180.0 && num > 0.0) || num > 150.0 * pi / 180.0;
									if (flag52)
									{
										this.Angle(whichfish, 130.0 * pi / 180.0);
										this.KeepV(whichfish, 5.0);
										bool flag53 = num < 100.0 * pi / 180.0 && num > 0.0;
										if (flag53)
										{
											bool flag54 = num < 90.0 * pi / 180.0;
											if (flag54)
											{
												GlobalVar.decisions[whichfish].TCode = 9;
											}
											GlobalVar.decisions[whichfish].TCode = 11;
										}
									}
									else
									{
										this.Angle(whichfish, 130.0 * pi / 180.0);
										this.KeepV(whichfish, 350.0);
									}
								}
								bool flag55 = num17 > (double)(-(double)num14 - 80);
								if (flag55)
								{
									this.Position(whichfish, num17 - 65.0, num18 + 15.0, 314.0);
								}
							}
							bool flag56 = num18 - (num7 + num9) < (double)(num11 - 15) && num17 < (double)(-(double)num14);
							if (flag56)
							{
								GlobalVar.decisions[whichfish].TCode = 2;
								GlobalVar.decisions[whichfish].VCode = 1;
							}
						}
						GlobalVar.Rescue_boundary_Zhuangtai1[whichfish] = 1;
					}
				}
				bool flag57 = num > -10.0 * pi / 180.0 && num < 10.0 * pi / 180.0;
				if (flag57)
				{
					bool flag58 = Compute.GetDistance(num17, num18, num2, num3) < 200.0;
					if (flag58)
					{
						bool flag59 = num18 > num3;
						if (flag59)
						{
							GlobalVar.Rescue_boundary_tail[whichfish] = 2;
						}
						else
						{
							GlobalVar.Rescue_boundary_tail[whichfish] = 1;
						}
					}
				}
				bool flag60 = GlobalVar.Rescue_boundary_tail[whichfish] == 1;
				if (flag60)
				{
					GlobalVar.decisions[whichfish].VCode = 1;
					this.KeepV(whichfish, 5.0);
					this.Angle(whichfish, 145.0 * pi / 180.0);
					this.KeepV(whichfish, 0.0);
					GlobalVar.decisions[whichfish].VCode = 1;
					bool flag61 = num < 135.0 * pi / 180.0;
					if (flag61)
					{
						GlobalVar.decisions[whichfish].TCode = 14;
					}
					bool flag62 = num > 130.0 * pi / 180.0 || num17 > -1045.0 || Compute.GetDistance(num17, num18, num2, num3) > 300.0;
					if (flag62)
					{
						GlobalVar.Rescue_boundary_tail[whichfish] = 0;
						GlobalVar.Jinqiu_Rescue[whichfish] = 0;
					}
				}
				bool flag63 = GlobalVar.Rescue_boundary_tail[whichfish] == 2;
				if (flag63)
				{
					GlobalVar.decisions[whichfish].VCode = 1;
					this.KeepV(whichfish, 0.0);
					this.Angle(whichfish, -145.0 * pi / 180.0);
					bool flag64 = num < -130.0 * pi / 180.0 || num17 > -1045.0 || Compute.GetDistance(num17, num18, num2, num3) > 300.0;
					if (flag64)
					{
						GlobalVar.Rescue_boundary_tail[whichfish] = 0;
						GlobalVar.Jinqiu_Rescue[whichfish] = 0;
					}
				}
			}
		}

		// Token: 0x06000029 RID: 41 RVA: 0x0000FDB0 File Offset: 0x0000DFB0
		public void Dribble_boundaryf(int whichfish, int whichball)
		{
			double pi = GlobalVar.PI;
			RoboFish roboFish = GlobalVar.MyTeam.Fishes[whichfish];
			double num = (double)roboFish.VelocityDirectionRad;
			double num2 = (double)roboFish.PositionMm.X;
			double num3 = (double)roboFish.PositionMm.Z;
			double num4 = (double)roboFish.VelocityMmPs;
			double num5 = (double)roboFish.AngularVelocityRadPs;
			double num6 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].X;
			double num7 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
			double num8 = (double)GlobalVar.mission.EnvRef.Balls[whichball].VelocityDirectionRad;
			double num9 = (double)GlobalVar.mission.EnvRef.Balls[whichball].VelocityMmPs;
			double num10 = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.X;
			double num11 = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.Z;
			int num12 = 1260;
			int num13 = 850;
			bool flag = num10 > (double)num12 && Math.Abs(num11) < (double)(num13 + 50);
			if (flag)
			{
				bool flag2 = GlobalVar.Dribble_boundaryf_zt1[whichfish] == 100;
				if (flag2)
				{
					bool flag3 = num11 < 0.0;
					if (flag3)
					{
						GlobalVar.Dribble_boundaryf_zt1[whichfish] = 1;
					}
					else
					{
						GlobalVar.Dribble_boundaryf_zt1[whichfish] = 0;
					}
				}
				bool flag4 = Math.Abs(num11) > 100.0;
				if (flag4)
				{
					GlobalVar.Dribble_boundaryf_zt1[whichfish] = 100;
				}
				bool flag5 = num11 > 100.0 || GlobalVar.Dribble_boundaryf_zt1[whichfish] == 1;
				if (flag5)
				{
					this.boundary_dribble(whichfish, whichball, 2, true);
				}
				else
				{
					bool flag6 = num11 < -100.0 || GlobalVar.Dribble_boundaryf_zt1[whichfish] == 0;
					if (flag6)
					{
						this.boundary_dribble(whichfish, whichball, 2, false);
					}
				}
			}
			else
			{
				bool flag7 = num10 < (double)(-(double)num12) && Math.Abs(num11) < 700.0;
				if (flag7)
				{
					bool flag8 = GlobalVar.Dribble_boundaryf_zt2[whichfish] == 100;
					if (flag8)
					{
						bool flag9 = num11 < 0.0;
						if (flag9)
						{
							GlobalVar.Dribble_boundaryf_zt2[whichfish] = 1;
						}
						else
						{
							GlobalVar.Dribble_boundaryf_zt2[whichfish] = 0;
						}
					}
					bool flag10 = Math.Abs(num11) > 560.0;
					if (flag10)
					{
						GlobalVar.Dribble_boundaryf_zt2[whichfish] = 100;
					}
					bool flag11 = num11 < -560.0 || GlobalVar.Dribble_boundaryf_zt2[whichfish] == 1;
					if (flag11)
					{
						this.boundary_dribble(whichfish, whichball, 0, false);
					}
					bool flag12 = num11 > 560.0 || GlobalVar.Dribble_boundaryf_zt2[whichfish] == 0;
					if (flag12)
					{
						this.boundary_dribble(whichfish, whichball, 0, true);
					}
				}
				else
				{
					this.Dribbleboundary(whichfish, whichball);
				}
			}
		}

		// Token: 0x0600002A RID: 42 RVA: 0x000100B0 File Offset: 0x0000E2B0
		public void Dribbleboundary(int whichfish, int whichball)
		{
			int i = (whichfish == 0) ? 6 : 10;
			double pi = GlobalVar.PI;
			RoboFish roboFish = GlobalVar.MyTeam.Fishes[whichfish];
			double num = (double)roboFish.VelocityDirectionRad;
			double num2 = (double)roboFish.PositionMm.X;
			double num3 = (double)roboFish.PositionMm.Z;
			double num4 = (double)roboFish.VelocityMmPs;
			double num5 = (double)roboFish.AngularVelocityRadPs;
			double num6 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].X;
			double num7 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
			double num8 = (double)GlobalVar.mission.EnvRef.Balls[whichball].VelocityDirectionRad;
			double num9 = (double)GlobalVar.mission.EnvRef.Balls[whichball].VelocityMmPs;
			double num10 = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.X;
			double num11 = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.Z;
			bool flag = GlobalVar.Dribbleboundary_zt1[whichfish] == 0 && Math.Abs(num11) > 900.0;
			if (flag)
			{
				GlobalVar.Dribbleboundary_zt1[whichfish] = 1;
			}
			else
			{
				bool flag2 = GlobalVar.Dribbleboundary_zt1[whichfish] == 1 && (num10 - num2 > 180.0 || Math.Abs(num11) < 650.0);
				if (flag2)
				{
					GlobalVar.Dribbleboundary_zt1[whichfish] = 0;
				}
			}
			bool flag3 = num10 - num6 > 150.0;
			if (flag3)
			{
				GlobalVar.Dribbleboundary_zt2[whichfish] = 0;
			}
			bool flag4 = GlobalVar.Dribbleboundary_zt1[whichfish] == 0;
			if (flag4)
			{
				bool flag5 = num11 > 0.0;
				if (flag5)
				{
					this.Dribble(whichfish, whichball, num10, 2000.0);
				}
				else
				{
					this.Dribble(whichfish, whichball, num10, -2000.0);
				}
			}
			bool flag6 = GlobalVar.Dribbleboundary_zt1[whichfish] == 1;
			if (flag6)
			{
				bool flag7 = num11 > 0.0;
				if (flag7)
				{
					bool flag8 = ((num6 - num10 >= 200.0 || num6 - num10 <= 0.0 || num7 - num11 <= -50.0) && GlobalVar.Dribbleboundary_zt2[whichfish] == 0) || ((num6 - num10 >= 200.0 || num6 - num10 <= -200.0 || num7 - num11 <= -50.0) && GlobalVar.Dribbleboundary_zt2[whichfish] == 1);
					if (flag8)
					{
						bool flag9 = Math.Abs(num11) < 900.0;
						if (flag9)
						{
							GlobalVar.Dribbleboundary_zt1[whichfish] = 0;
						}
						GlobalVar.Dribbleboundary_zt2[whichfish] = 0;
						bool flag10 = num6 < num10 + 30.0;
						if (flag10)
						{
							this.Position(whichfish, num10 + 60.0, num11 - 80.0, 300.0);
							DebugRecord.ceshi(i, "在上方跑到球的右边");
						}
						else
						{
							this.Position(whichfish, num10 + 80.0, 1000.0, 300.0);
						}
					}
					else
					{
						GlobalVar.Dribbleboundary_zt2[whichfish] = 1;
						GlobalVar.BaAction.Angle(whichfish, 115.0 * pi / 180.0);
						bool flag11 = num < 130.0 * pi / 180.0 && num > 90.0 * pi / 180.0;
						if (flag11)
						{
							GlobalVar.decisions[whichfish].VCode = 9;
							bool flag12 = num10 > 1200.0;
							if (flag12)
							{
								GlobalVar.decisions[whichfish].TCode = 8;
							}
						}
						else
						{
							GlobalVar.decisions[whichfish].VCode = 1;
						}
						bool flag13 = num11 > 700.0 && num10 < -1400.0;
						if (flag13)
						{
							GlobalVar.decisions[whichfish].VCode = 8;
							this.Angle(whichfish, -155.0 * pi / 180.0);
							bool flag14 = num < -145.0 * pi / 180.0 || num > 170.0 * pi / 180.0;
							if (flag14)
							{
								GlobalVar.decisions[whichfish].TCode = 8;
							}
						}
					}
				}
				bool flag15 = num11 < 0.0;
				if (flag15)
				{
					bool flag16 = ((num2 - num10 >= 200.0 || num2 - num10 <= 0.0 || num7 - num11 >= 50.0) && GlobalVar.Dribbleboundary_zt2[whichfish] == 0) || ((num2 - num10 >= 200.0 || num2 - num10 <= -200.0 || num7 - num11 >= 50.0) && GlobalVar.Dribbleboundary_zt2[whichfish] == 1);
					if (flag16)
					{
						bool flag17 = Math.Abs(num11) < 900.0;
						if (flag17)
						{
							GlobalVar.Dribbleboundary_zt1[whichfish] = 0;
						}
						GlobalVar.Dribbleboundary_zt2[whichfish] = 0;
						bool flag18 = num6 < num10 + 30.0;
						if (flag18)
						{
							this.Position(whichfish, num10 + 60.0, num11 + 80.0, 300.0);
							DebugRecord.ceshi(i, "在下方跑到球的右边");
						}
						else
						{
							this.Position(whichfish, num10 + 80.0, -1000.0, 300.0);
						}
					}
					else
					{
						GlobalVar.Dribbleboundary_zt2[whichfish] = 1;
						GlobalVar.BaAction.Angle(whichfish, -105.0 * pi / 180.0);
						bool flag19 = num > -125.0 * pi / 180.0 && num < -90.0 * pi / 180.0;
						if (flag19)
						{
							GlobalVar.decisions[whichfish].VCode = 10;
							bool flag20 = num10 > 1200.0;
							if (flag20)
							{
								GlobalVar.decisions[whichfish].TCode = 8;
							}
						}
						else
						{
							GlobalVar.decisions[whichfish].VCode = 1;
						}
						bool flag21 = num11 < -700.0 && num10 < -1400.0;
						if (flag21)
						{
							GlobalVar.decisions[whichfish].VCode = 8;
							this.Angle(whichfish, 155.0 * pi / 180.0);
							bool flag22 = num < -170.0 * pi / 180.0 || num > 145.0 * pi / 180.0;
							if (flag22)
							{
								GlobalVar.decisions[whichfish].TCode = 6;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600002B RID: 43 RVA: 0x000107FC File Offset: 0x0000E9FC
		public void InterfereBallQuick(int fishID)
		{
			GlobalVar.corner[fishID] = 0;
			GlobalVar.corner_help[fishID] = 0;
			double num = (double)GlobalVar.MyTeam.Fishes[fishID].PositionMm.X;
			double num2 = (double)GlobalVar.MyTeam.Fishes[fishID].PositionMm.Z;
			double num3 = (double)GlobalVar.MyTeam.Fishes[fishID].VelocityDirectionRad;
			bool flag = GlobalVar.Stage == 0;
			if (flag)
			{
				this.InterfereBallQuickPre(fishID);
			}
			bool flag2 = 1 == GlobalVar.Stage;
			if (flag2)
			{
				this.InterfereBallQuickFromPosi(fishID);
			}
			bool flag3 = 2 == GlobalVar.Stage;
			if (flag3)
			{
				this.InterfereBallQuickFromNega(fishID);
			}
			bool flag4 = num < 980.0 || num2 < -550.0 || num2 > 550.0;
			if (flag4)
			{
				GlobalVar.Stage = 0;
			}
		}

		// Token: 0x0600002C RID: 44 RVA: 0x000108E4 File Offset: 0x0000EAE4
		public void InterfereBallQuickPre(int fishID)
		{
			double num = (double)GlobalVar.MyTeam.Fishes[fishID].PositionMm.X;
			double num2 = (double)GlobalVar.MyTeam.Fishes[fishID].PositionMm.Z;
			double num3 = (double)GlobalVar.MyTeam.Fishes[fishID].VelocityDirectionRad;
			bool flag = fishID == 0;
			int num4;
			if (flag)
			{
				num4 = 1;
			}
			else
			{
				num4 = -1;
			}
			bool flag2 = num2 < 600.0 && num2 > -600.0 && num < -980.0;
			int num5;
			if (flag2)
			{
				num5 = -1;
			}
			else
			{
				bool flag3 = num2 >= 500.0 || num2 <= -500.0 || num <= 980.0;
				if (flag3)
				{
					num5 = 0;
				}
				else
				{
					bool flag4 = num2 < 500.0 && num2 > -500.0 && num > 1150.0;
					if (flag4)
					{
						num5 = 1;
					}
					else
					{
						num5 = 2;
					}
				}
			}
			bool flag5 = -1 == num5;
			if (flag5)
			{
				this.Position(fishID, -1300.0, (double)(num4 * 750), 150.0);
			}
			else
			{
				bool flag6 = num5 == 0;
				if (flag6)
				{
					bool flag7 = num > 940.0 && num2 < -500.0;
					if (flag7)
					{
						this.Position(fishID, 0.0, 0.0, 150.0);
					}
					else
					{
						bool flag8 = num < 1150.0;
						if (flag8)
						{
							this.Position(fishID, 1200.0, 620.0, 150.0);
						}
						else
						{
							bool flag9 = num > 1150.0 && num2 > 500.0;
							if (flag9)
							{
								this.Position(fishID, 1250.0, 460.0, 150.0);
							}
						}
					}
				}
				else
				{
					bool flag10 = 1 == num5;
					if (flag10)
					{
						bool flag11 = num3 >= -3.0 || num3 <= -3.14;
						if (flag11)
						{
							GlobalVar.decisions[fishID].VCode = 2;
							GlobalVar.decisions[fishID].TCode = 2;
						}
					}
					else
					{
						bool flag12 = 2 == num5;
						if (flag12)
						{
							GlobalVar.Stage = 1;
						}
					}
				}
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00010B6C File Offset: 0x0000ED6C
		public void InterfereBallQuickFromPosi(int fishID)
		{
			double num = (double)GlobalVar.MyTeam.Fishes[fishID].PositionMm.X;
			double num2 = (double)GlobalVar.MyTeam.Fishes[fishID].PositionMm.Z;
			double num3 = (double)GlobalVar.MyTeam.Fishes[fishID].VelocityDirectionRad;
			double num4 = num2 + 105.0 * Math.Sin(num3);
			bool flag = num > 1152.0;
			if (flag)
			{
				this.Position(fishID, 1100.0, -400.0, 100.0);
			}
			else
			{
				bool flag2 = num3 > 0.0;
				if (flag2)
				{
					GlobalVar.decisions[fishID].VCode = 2;
					GlobalVar.decisions[fishID].TCode = 14;
				}
				else
				{
					bool flag3 = num3 < -2.7 && num3 > -3.14;
					if (flag3)
					{
						GlobalVar.decisions[fishID].VCode = 12;
						GlobalVar.decisions[fishID].TCode = 10;
					}
					else
					{
						bool flag4 = num3 < -2.5 && num3 > -2.7;
						if (flag4)
						{
							GlobalVar.decisions[fishID].VCode = 12;
							GlobalVar.decisions[fishID].TCode = 9;
						}
						else
						{
							bool flag5 = num3 < -2.3 && num3 > -2.5;
							if (flag5)
							{
								GlobalVar.decisions[fishID].VCode = 10;
								GlobalVar.decisions[fishID].TCode = 6;
							}
							else
							{
								GlobalVar.decisions[fishID].VCode = 9;
								GlobalVar.decisions[fishID].TCode = 6;
							}
						}
					}
				}
				bool flag6 = num4 < -497.0;
				if (flag6)
				{
					GlobalVar.Stage = 2;
				}
			}
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00010D74 File Offset: 0x0000EF74
		public void InterfereBallQuickFromNega(int fishID)
		{
			double num = (double)GlobalVar.MyTeam.Fishes[fishID].PositionMm.X;
			double num2 = (double)GlobalVar.MyTeam.Fishes[fishID].PositionMm.Z;
			double num3 = (double)GlobalVar.MyTeam.Fishes[fishID].VelocityDirectionRad;
			double num4 = num2 + 105.0 * Math.Sin(num3);
			bool flag = num > 1152.0;
			if (flag)
			{
				this.Position(fishID, 1100.0, 400.0, 100.0);
			}
			else
			{
				bool flag2 = num3 < 0.0;
				if (flag2)
				{
					DebugRecord.ceshi(12, "stage 21");
					GlobalVar.decisions[fishID].VCode = 1;
					GlobalVar.decisions[fishID].TCode = 0;
				}
				else
				{
					bool flag3 = num3 > 2.7 && num3 < 3.14;
					if (flag3)
					{
						DebugRecord.ceshi(12, "stage 22");
						GlobalVar.decisions[fishID].VCode = 14;
						GlobalVar.decisions[fishID].TCode = 0;
					}
					else
					{
						bool flag4 = num3 > 2.5 && num3 < 2.7;
						if (flag4)
						{
							DebugRecord.ceshi(12, "stage 23");
							GlobalVar.decisions[fishID].VCode = 14;
							GlobalVar.decisions[fishID].TCode = 1;
						}
						else
						{
							bool flag5 = num3 > 2.2 && num3 < 2.5;
							if (flag5)
							{
								DebugRecord.ceshi(12, "stage 24");
								GlobalVar.decisions[fishID].VCode = 12;
								GlobalVar.decisions[fishID].TCode = 5;
							}
							else
							{
								bool flag6 = num3 > 2.0 && num3 < 2.2;
								if (flag6)
								{
									DebugRecord.ceshi(12, "stage 25");
									GlobalVar.decisions[fishID].VCode = 11;
									GlobalVar.decisions[fishID].TCode = 5;
								}
								else
								{
									DebugRecord.ceshi(12, "stage 26");
									GlobalVar.decisions[fishID].VCode = 9;
									GlobalVar.decisions[fishID].TCode = 8;
								}
							}
						}
					}
				}
				bool flag7 = num4 > 460.0;
				if (flag7)
				{
					GlobalVar.Stage = 1;
				}
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00011014 File Offset: 0x0000F214
		public void Dribblehometestlast2min(int whichfish)
		{
			GlobalVar.corner[whichfish] = 0;
			GlobalVar.corner_help[whichfish] = 0;
			double num = (double)GlobalVar.MyTeam.Fishes[whichfish].VelocityDirectionRad;
			double pi = GlobalVar.PI;
			double num2 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
			double num3 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
			double num4 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].X;
			double num5 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
			bool flag = whichfish == 0;
			int num6;
			if (flag)
			{
				num6 = 1;
			}
			else
			{
				num6 = -1;
			}
			bool flag2 = GlobalVar.teamId == 1 && GlobalVar.Paishu > 3000;
			if (flag2)
			{
				num6 = -num6;
			}
			double dx = -1500.0;
			bool flag3 = this.lanqiu_Z() >= 1000.0;
			double dz;
			if (flag3)
			{
				dz = (this.lanqiu_Z() + 300.0) * (double)num6;
			}
			else
			{
				dz = this.lanqiu_Z() * (double)num6;
			}
			bool flag4 = num2 > -1152.0 && (num2 >= -978.0 || Math.Abs(num3) >= 600.0);
			if (flag4)
			{
				GlobalVar.last2min_is_in_200m[whichfish] = 0;
				bool flag5 = this.whether_in_oppforbiddenareabig(num2, num3);
				if (flag5)
				{
					bool flag6 = Math.Abs(num5) < 520.0;
					if (flag6)
					{
						this.Position(whichfish, 1500.0, (double)(num6 * 1000), 200.0);
					}
					else
					{
						this.Position(whichfish, 800.0, (double)(num6 * 700), 200.0);
					}
				}
				else
				{
					this.Position(whichfish, dx, dz, 200.0);
				}
			}
			else
			{
				bool flag7 = (Math.Abs(num3) <= 120.0 && num2 < -1300.0 && num4 < -1450.0) || GlobalVar.last2min_is_in_200m[whichfish] == 1;
				if (flag7)
				{
					GlobalVar.last2min_is_in_200m[whichfish] = 1;
					double num7 = (double)GlobalVar.MyTeam.Fishes[1 - whichfish].PositionMm.X;
					double value = (double)GlobalVar.MyTeam.Fishes[1 - whichfish].PositionMm.Z;
					double num8 = (double)GlobalVar.MyTeam.Fishes[1].PositionMm.Z;
					double num9 = (double)GlobalVar.MyTeam.Fishes[0].PositionMm.Z;
					bool flag8 = Math.Abs(value) >= 120.0 && GlobalVar.last2min_is_in_200m[1 - whichfish] == 0;
					if (flag8)
					{
						this.wait(whichfish);
						bool flag9 = GlobalVar.teamId == 0 && GlobalVar.Paishu < 3000 && num8 > num9 + 200.0;
						if (flag9)
						{
							GlobalVar.lanqiuFlag[1] = 1;
							GlobalVar.lanqiuFlag[0] = 1;
						}
						bool flag10 = GlobalVar.teamId == 1 && GlobalVar.Paishu < 3000 && num8 > num9 + 200.0;
						if (flag10)
						{
							GlobalVar.lanqiuFlag[1] = 1;
							GlobalVar.lanqiuFlag[0] = 1;
						}
						bool flag11 = GlobalVar.teamId == 0 && GlobalVar.Paishu > 3000 && num8 > num9 + 200.0;
						if (flag11)
						{
							GlobalVar.lanqiuFlag[1] = 1;
							GlobalVar.lanqiuFlag[0] = 1;
						}
						bool flag12 = GlobalVar.teamId == 1 && GlobalVar.Paishu > 3000 && num8 < num9 - 200.0;
						if (flag12)
						{
							GlobalVar.lanqiuFlag[1] = 1;
							GlobalVar.lanqiuFlag[0] = 1;
						}
					}
					else
					{
						this.Circle_last2min(whichfish);
					}
					GlobalVar.BaAction.shutdownlanqiu();
				}
				else
				{
					double num10 = Math.Abs(num5 - 1000.0);
					double num11 = (double)GlobalVar.Fish_length;
					double num12 = 2.0 - 3.0 * pi / 2.0;
					bool flag13 = num10 < num11;
					double num13;
					if (flag13)
					{
						num13 = Math.Acos(num10 / num11);
					}
					else
					{
						num13 = pi - 2.0;
					}
					bool flag14 = (double)num6 * num12 > (double)num6 * (-pi / 2.0 - num13);
					if (flag14)
					{
						num12 = -pi / 2.0 - num13;
					}
					num12 += 0.3;
					int num14 = this.TransfromAngletoTCode((double)num6 * num12 - num);
					int num15 = Math.Abs(7 - num14);
					bool flag15 = (double)num6 * num > 0.0 || (double)num6 * num < -(pi - 0.3);
					if (flag15)
					{
						bool flag16 = (double)num6 * num > 0.0;
						if (flag16)
						{
							GlobalVar.decisions[whichfish].VCode = 4;
							GlobalVar.decisions[whichfish].TCode = 7 + num6 * 4;
						}
						else
						{
							GlobalVar.decisions[whichfish].VCode = 4;
							GlobalVar.decisions[whichfish].TCode = 7 + num6 * 4;
						}
					}
					else
					{
						bool flag17 = Math.Abs(num5) > 750.0;
						if (flag17)
						{
							num12 = -pi / 2.0 - num13;
							num12 -= 0.1;
							bool flag18 = Math.Abs(num) > Math.Abs(num12);
							if (flag18)
							{
								GlobalVar.decisions[whichfish].TCode = 7 + num6 * 2;
								GlobalVar.decisions[whichfish].VCode = 2;
							}
							else
							{
								GlobalVar.decisions[whichfish].TCode = 7;
								GlobalVar.decisions[whichfish].VCode = 5;
							}
						}
						else
						{
							bool flag19 = Math.Abs(num) < Math.Abs(num12) + 0.15 && Math.Abs(num) > Math.Abs(num12) - 0.15;
							if (flag19)
							{
								GlobalVar.decisions[whichfish].TCode = 7;
								GlobalVar.decisions[whichfish].VCode = 12 - num15;
							}
							else
							{
								bool flag20 = Math.Abs(num) < Math.Abs(num12);
								if (flag20)
								{
									bool flag21 = Math.Abs(GlobalVar.prefish[whichfish].preTcode - num14) > 1;
									if (flag21)
									{
										num14 = Math.Sign(GlobalVar.prefish[whichfish].preTcode - num14) + num14;
									}
									GlobalVar.decisions[whichfish].TCode = num14;
									num15 = 3 - num15;
									bool flag22 = num15 < 1;
									if (flag22)
									{
										num15 = 1;
									}
									bool flag23 = Math.Abs(GlobalVar.prefish[whichfish].preVcode - num15) > 2;
									if (flag23)
									{
										num15 = (num15 + GlobalVar.prefish[whichfish].preVcode) / 2;
									}
									GlobalVar.decisions[whichfish].VCode = num15;
								}
								else
								{
									GlobalVar.decisions[whichfish].TCode = num14;
									num15 = 9 - num15;
									bool flag24 = num15 <= 6;
									if (flag24)
									{
										num15 = 6;
									}
									GlobalVar.decisions[whichfish].VCode = num15;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x000117C4 File Offset: 0x0000F9C4
		public void Circle_last2min(int whichfish)
		{
			bool flag = whichfish == 0;
			int num;
			if (flag)
			{
				num = 1;
			}
			else
			{
				num = -1;
			}
			double pi = GlobalVar.PI;
			double num2 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].X;
			double num3 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
			double num4 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].X;
			double num5 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
			double num6 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
			double value = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
			double num7 = (double)GlobalVar.MyTeam.Fishes[1].PositionMm.Z;
			double num8 = (double)GlobalVar.MyTeam.Fishes[0].PositionMm.Z;
			double value2 = (double)GlobalVar.MyTeam.Fishes[whichfish].VelocityDirectionRad;
			bool flag2 = Math.Abs(value2) > 5.0 * pi / 6.0 && GlobalVar.Circle_last2min_tag[whichfish] == 0;
			if (flag2)
			{
				GlobalVar.Circle_last2min_tag[whichfish] = 1;
				DebugRecord.ceshi(9, "1状态");
			}
			bool flag3 = num2 > -1152.0 && GlobalVar.Circle_last2min_tag[whichfish] == 1;
			if (flag3)
			{
				GlobalVar.Circle_last2min_tag[whichfish] = 2;
				DebugRecord.ceshi(9, "2状态");
			}
			bool flag4 = GlobalVar.Circle_last2min_tag[whichfish] == 2 && num2 < -1250.0;
			if (flag4)
			{
				GlobalVar.Circle_last2min_tag[whichfish] = 3;
				DebugRecord.ceshi(9, "3状态");
			}
			bool flag5 = GlobalVar.Circle_last2min_tag[whichfish] == 3 && Math.Abs(value) > 700.0;
			if (flag5)
			{
				GlobalVar.Circle_last2min_tag[whichfish] = 0;
				DebugRecord.ceshi(9, "0状态");
			}
			bool flag6 = GlobalVar.teamId == 1 && GlobalVar.Paishu > 3000;
			if (flag6)
			{
				num = -num;
			}
			bool flag7 = GlobalVar.Circle_last2min_tag[whichfish] == 0;
			if (flag7)
			{
				GlobalVar.decisions[whichfish].TCode = 7 - num * 3;
				GlobalVar.decisions[whichfish].VCode = 5;
			}
			bool flag8 = GlobalVar.Circle_last2min_tag[whichfish] == 1;
			if (flag8)
			{
				bool flag9 = GlobalVar.Circle_last2min_tag[1 - whichfish] == 0;
				if (flag9)
				{
					this.wait(whichfish);
				}
				else
				{
					bool flag10 = num2 > num4 + 6.0 && GlobalVar.Circle_last2min_tag[whichfish] == GlobalVar.Circle_last2min_tag[1 - whichfish];
					if (flag10)
					{
						this.wait(whichfish);
					}
					else
					{
						GlobalVar.decisions[whichfish].TCode = 7 + num * 4;
						this.KeepV(whichfish, 18.0);
					}
				}
			}
			bool flag11 = GlobalVar.Circle_last2min_tag[whichfish] == 2;
			if (flag11)
			{
				bool flag12 = GlobalVar.Circle_last2min_tag[1 - whichfish] == 1;
				if (flag12)
				{
					this.wait(whichfish);
				}
				else
				{
					bool flag13 = num2 < num4 - 6.0 && GlobalVar.Circle_last2min_tag[whichfish] == GlobalVar.Circle_last2min_tag[1 - whichfish];
					if (flag13)
					{
						this.wait(whichfish);
					}
					else
					{
						GlobalVar.decisions[whichfish].TCode = 7 - num * 4;
						this.KeepV(whichfish, 18.0);
					}
				}
			}
			bool flag14 = GlobalVar.Circle_last2min_tag[whichfish] == 3;
			if (flag14)
			{
				GlobalVar.lanqiuFlag[whichfish] = 1;
			}
		}

		// Token: 0x06000031 RID: 49 RVA: 0x00011B8C File Offset: 0x0000FD8C
		public void boundary_dribbleact(int whichfish)
		{
			GlobalVar.corner[whichfish] = 0;
			GlobalVar.corner_help[whichfish] = 0;
			double pi = GlobalVar.PI;
			RoboFish roboFish = GlobalVar.MyTeam.Fishes[whichfish];
			double num = (double)roboFish.VelocityDirectionRad;
			double num2 = (double)roboFish.PositionMm.X;
			double num3 = (double)roboFish.PositionMm.Z;
			double num4 = (double)roboFish.VelocityMmPs;
			double num5 = (double)roboFish.AngularVelocityRadPs;
			double num6 = 1250.0;
			bool flag = whichfish == 0;
			int num7;
			if (flag)
			{
				num7 = 1;
			}
			else
			{
				num7 = -1;
			}
			num2 += num4 * Math.Cos(num) * 0.1;
			num3 += num4 * Math.Sin(num) * 0.1;
			num += num5 * 0.1;
			double num8 = num2 + (double)GlobalVar.Fish_centertohead * Math.Cos(num);
			double num9 = num3 + (double)GlobalVar.Fish_centertohead * Math.Sin(num);
			int num10 = this.boundary_dribbleact_constdir;
			double dv = 220.0;
			bool flag2 = num8 > 1400.0 && Math.Abs(num9) < 980.0;
			if (flag2)
			{
				bool flag3 = Math.Abs(num / pi * 180.0 - (double)num10) < 10.0;
				if (flag3)
				{
					this.Angle(whichfish, (double)num10 / 180.0 * pi);
					this.KeepV(whichfish, dv);
				}
				else
				{
					this.Angle(whichfish, (double)num10 / 180.0 * pi);
					this.KeepV(whichfish, 0.0);
				}
			}
			else
			{
				bool flag4 = num9 < -900.0 && num8 > 400.0;
				if (flag4)
				{
					bool flag5 = num8 > num6;
					if (flag5)
					{
						GlobalVar.decisions[whichfish].VCode = 6;
						this.Angle(whichfish, (double)(-90 - Math.Abs(num10)) * pi / 180.0);
						bool flag6 = num < -80.0 * pi / 180.0 && num > -125.0 * pi / 180.0;
						if (flag6)
						{
							GlobalVar.decisions[whichfish].TCode = 6;
						}
					}
					else
					{
						bool flag7 = Math.Abs(num / pi * 180.0 + 115.0) < 10.0;
						if (flag7)
						{
							this.Angle(whichfish, (double)(-90 - Math.Abs(num10)) / 180.0 * pi);
							this.KeepV(whichfish, dv);
						}
						else
						{
							this.Angle(whichfish, (double)(-90 - Math.Abs(num10)) / 180.0 * pi);
							this.KeepV(whichfish, 0.0);
						}
					}
					bool flag8 = num8 < 650.0;
					if (flag8)
					{
						GlobalVar.BaAction.Position(whichfish, 0.0, 0.0, 999.0);
					}
					bool flag9 = num2 < 900.0 && this.dribbleactsup(whichfish) == 0;
					if (flag9)
					{
						GlobalVar.BaAction.Position(whichfish, 0.0, 0.0, 999.0);
						GlobalVar.boundary_dribbleact[whichfish] = 0;
					}
				}
				else
				{
					bool flag10 = num9 > 900.0 && num8 > 400.0;
					if (flag10)
					{
						bool flag11 = num8 > num6;
						if (flag11)
						{
							GlobalVar.decisions[whichfish].VCode = 6;
							this.Angle(whichfish, (double)(90 + Math.Abs(num10)) * pi / 180.0);
							bool flag12 = num > 80.0 * pi / 180.0 && num < 125.0 * pi / 180.0;
							if (flag12)
							{
								GlobalVar.decisions[whichfish].TCode = 8;
							}
						}
						else
						{
							bool flag13 = Math.Abs(num / pi * 180.0 - 115.0) < 10.0;
							if (flag13)
							{
								this.Angle(whichfish, (double)(90 + Math.Abs(num10)) / 180.0 * pi);
								this.KeepV(whichfish, dv);
							}
							else
							{
								this.Angle(whichfish, (double)(90 + Math.Abs(num10)) / 180.0 * pi);
								this.KeepV(whichfish, 0.0);
							}
						}
						bool flag14 = num8 < 650.0;
						if (flag14)
						{
							GlobalVar.BaAction.Position(whichfish, 0.0, 0.0, 999.0);
						}
						bool flag15 = num2 < 900.0 && this.dribbleactsup(whichfish) == 0;
						if (flag15)
						{
							GlobalVar.BaAction.Position(whichfish, 0.0, 0.0, 999.0);
							GlobalVar.boundary_dribbleact[whichfish] = 0;
						}
					}
					else
					{
						bool flag16 = num3 < -200.0 || (num3 < 200.0 && num < 0.0);
						if (flag16)
						{
							this.boundary_dribbleact_constdir = 25;
							this.Position(whichfish, 1500.0, -700.0, 300.0);
						}
						else
						{
							this.boundary_dribbleact_constdir = -25;
							this.Position(whichfish, 1500.0, 700.0, 300.0);
						}
						bool flag17 = num2 < -900.0 && Math.Abs(num3) < 700.0;
						if (flag17)
						{
							this.Position(whichfish, -1300.0, (double)(num7 * 800), 300.0);
						}
					}
				}
			}
			bool flag18 = num2 < 650.0;
			if (flag18)
			{
				GlobalVar.boundary_dribbleact[whichfish] = 0;
			}
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000121DC File Offset: 0x000103DC
		public double lanqiu_Z()
		{
			double num = 0.0;
			int num2 = -1;
			for (int i = 0; i < 9; i++)
			{
				bool flag = this.whether_in_lanqiu((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z);
				if (flag)
				{
					bool flag2 = (double)Math.Abs(GlobalVar.balls[i].PositionMm.Z) > num;
					if (flag2)
					{
						num = (double)Math.Abs(GlobalVar.balls[i].PositionMm.Z);
						num2 = i;
					}
				}
			}
			int num3 = num2;
			bool flag3 = num3 != -1;
			double result;
			if (flag3)
			{
				double num4 = (double)(Math.Abs(GlobalVar.balls[num3].PositionMm.Z) + 100f);
				result = num4;
			}
			else
			{
				result = 720.0;
			}
			return result;
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000122C8 File Offset: 0x000104C8
		public bool whether_in_lanqiu(double location_x, double location_z)
		{
			return Math.Abs(location_z) >= 600.0 && location_x <= -1120.0;
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00012308 File Offset: 0x00010508
		public void fightAgainst(int whichfish, int oppID)
		{
			double[,] array = new double[2, 2];
			double[,] array2 = new double[2, 2];
			for (int i = 0; i < 2; i++)
			{
				array[i, 0] = (double)GlobalVar.OppTeam.Fishes[i].PositionMm.X;
				array[i, 1] = (double)GlobalVar.OppTeam.Fishes[i].PositionMm.Z;
				array2[i, 0] = (double)GlobalVar.OppTeam.Fishes[i].PolygonVertices[0].X;
				array2[i, 1] = (double)GlobalVar.OppTeam.Fishes[i].PolygonVertices[0].Z;
				double num = (double)GlobalVar.OppTeam.Fishes[i].VelocityMmPs;
				double num2 = (double)GlobalVar.OppTeam.Fishes[i].AngularVelocityRadPs;
				double num3 = (double)GlobalVar.OppTeam.Fishes[i].BodyDirectionRad;
			}
			this.Position(whichfish, array2[oppID, 0], array2[oppID, 1], 300.0);
			double num4 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
			double num5 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
			bool flag = whichfish == 0;
			int num6;
			if (flag)
			{
				num6 = 1;
			}
			else
			{
				num6 = -1;
			}
			bool flag2 = this.whether_in_myforbiddenareasmall(num4, num5) && array[oppID, 0] > -949.0 && array[oppID, 0] < 949.0;
			if (flag2)
			{
				this.Position(whichfish, -1500.0, (double)(num6 * 1000), 200.0);
			}
			else
			{
				bool flag3 = num4 < -949.0 && Math.Abs(num5) < 900.0 && array[oppID, 0] > -949.0 && array[oppID, 0] < 949.0;
				if (flag3)
				{
					this.Position(whichfish, -800.0, (double)(num6 * 700), 200.0);
				}
				else
				{
					bool flag4 = this.whether_in_oppforbiddenareabig(num4, num5);
					if (flag4)
					{
						this.Position(whichfish, 1500.0, (double)(num6 * 1000), 200.0);
						bool flag5 = Math.Abs(num5) > 800.0;
						if (flag5)
						{
							this.Position(whichfish, 800.0, (double)(num6 * 700), 200.0);
						}
					}
				}
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x000125EC File Offset: 0x000107EC
		public void danyujinqiu(int whichfish, int whichball)
		{
			double num = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
			double num2 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
			double num3 = (double)GlobalVar.MyTeam.Fishes[whichfish].VelocityMmPs;
			double num4 = (double)GlobalVar.MyTeam.Fishes[whichfish].AngularVelocityRadPs;
			double num5 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].X;
			double num6 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
			double num7 = (double)GlobalVar.balls[whichball].PositionMm.X;
			double num8 = (double)GlobalVar.balls[whichball].PositionMm.Z;
			double num9 = (double)GlobalVar.MyTeam.Fishes[whichfish].BodyDirectionRad;
			double num10 = Math.Atan((num8 - num6) / (num7 - num5));
			double num11 = Math.Atan((num8 - num2) / (num7 - num6));
			double num12 = Math.Sqrt((num8 - num6) * (num8 - num6) + (num7 - num5) * (num7 - num5));
			double num13 = num5 - 444.0 * Math.Cos(num9);
			double pi = GlobalVar.PI;
			bool flag = whichfish == 0;
			int num14;
			if (flag)
			{
				num14 = 1;
			}
			else
			{
				num14 = -1;
			}
			bool flag2 = num8 > 300.0;
			if (flag2)
			{
				num14 = 1;
			}
			else
			{
				bool flag3 = num8 < -300.0;
				if (flag3)
				{
					num14 = -1;
				}
			}
			bool flag4 = num12 > 300.0;
			if (flag4)
			{
				GlobalVar.danyujinqiu[whichfish] = 0;
				GlobalVar.BaAction.runway(whichfish, num7 - 80.0, num8, 200.0);
			}
			else
			{
				bool flag5 = num7 < -1300.0;
				if (flag5)
				{
					bool flag6 = num9 > 0.0;
					if (flag6)
					{
						GlobalVar.BaAction.Position(whichfish, num7 - 80.0, num8 + 20.0, 50.0);
					}
					else
					{
						GlobalVar.BaAction.Position(whichfish, num7 - 80.0, num8 - 20.0, 50.0);
					}
					bool flag7 = num9 > 0.0 && num6 - num8 > 70.0 && num < num7 && Math.Abs(num9 - pi / 2.0) < pi / 3.0;
					if (flag7)
					{
						GlobalVar.BaAction.KeepV(whichfish, 0.0);
						GlobalVar.decisions[whichfish].TCode = 4;
						bool flag8 = num5 > num7 + 30.0;
						if (flag8)
						{
							DebugRecord.ceshi(0, "加这一段是为了什么");
							GlobalVar.decisions[whichfish].TCode = 11;
						}
					}
					else
					{
						bool flag9 = num9 < 0.0 && num8 - num6 > 70.0 && num < num7 && Math.Abs(num9 + pi / 2.0) < pi / 3.0;
						if (flag9)
						{
							GlobalVar.BaAction.KeepV(whichfish, 0.0);
							GlobalVar.decisions[whichfish].TCode = 11;
							bool flag10 = num5 > num7 + 30.0;
							if (flag10)
							{
								GlobalVar.decisions[whichfish].TCode = 1;
							}
						}
					}
				}
				else
				{
					bool flag11 = num9 > 0.0 && ((num5 > num7 - 100.0 && num6 - 65.0 > num8) || (num5 > num7 - 20.0 && num6 > num8 + 40.0)) && num12 < 400.0;
					if (flag11)
					{
						GlobalVar.BaAction.KeepV(whichfish, 10.0);
						GlobalVar.decisions[whichfish].TCode = 4;
						bool flag12 = num5 > num7 + 13.0;
						if (flag12)
						{
							DebugRecord.ceshi(0, "反向转部分");
							GlobalVar.danyujinqiu[whichfish] = 1;
							GlobalVar.decisions[whichfish].TCode = 11;
						}
					}
					else
					{
						bool flag13 = num9 < 0.0 && ((num5 > num7 - 100.0 && num6 + 65.0 < num8) || (num5 > num7 - 20.0 && num6 < num8 - 40.0)) && num12 < 400.0;
						if (flag13)
						{
							GlobalVar.BaAction.KeepV(whichfish, 10.0);
							GlobalVar.decisions[whichfish].TCode = 11;
							bool flag14 = num5 > num7 + 13.0;
							if (flag14)
							{
								GlobalVar.danyujinqiu[whichfish] = -1;
								GlobalVar.decisions[whichfish].TCode = 4;
							}
						}
						else
						{
							bool flag15 = num7 < -1050.0;
							if (flag15)
							{
								bool flag16 = num9 < 0.0;
								if (flag16)
								{
									GlobalVar.BaAction.Position(whichfish, num7 - 60.0, num8 - 50.0, 100.0);
								}
								else
								{
									GlobalVar.BaAction.Position(whichfish, num7 - 60.0, num8 + 50.0, 100.0);
								}
							}
							else
							{
								bool flag17 = num9 < 0.0;
								if (flag17)
								{
									GlobalVar.BaAction.Position(whichfish, num7 - 50.0, num8 - 50.0, 100.0);
								}
								else
								{
									GlobalVar.BaAction.Position(whichfish, num7 - 50.0, num8 + 50.0, 100.0);
								}
							}
						}
					}
				}
			}
			bool flag18 = GlobalVar.danyujinqiu[whichfish] == -1;
			if (flag18)
			{
				GlobalVar.decisions[whichfish].TCode = 1;
				GlobalVar.BaAction.KeepV(whichfish, 0.0);
				bool flag19 = num9 >= -pi / 10.0 || num9 <= -3.0 * pi / 4.0;
				if (flag19)
				{
					GlobalVar.danyujinqiu[whichfish] = 0;
				}
				bool flag20 = GlobalVar.teamId == 1;
				if (flag20)
				{
					bool flag21 = num9 <= -9.0 * pi / 10.0 || num9 >= -pi / 4.0;
					if (flag21)
					{
						GlobalVar.danyujinqiu[whichfish] = 0;
					}
				}
			}
			else
			{
				bool flag22 = GlobalVar.danyujinqiu[whichfish] == 1;
				if (flag22)
				{
					GlobalVar.decisions[whichfish].TCode = 15;
					GlobalVar.BaAction.KeepV(whichfish, 0.0);
					bool flag23 = num9 <= pi / 10.0 || num9 >= 3.0 * pi / 4.0;
					if (flag23)
					{
						GlobalVar.danyujinqiu[whichfish] = 0;
					}
					bool flag24 = GlobalVar.teamId == 1;
					if (flag24)
					{
						bool flag25 = num9 >= 9.0 * pi / 10.0 || num9 <= pi / 4.0;
						if (flag25)
						{
							GlobalVar.danyujinqiu[whichfish] = 0;
						}
					}
				}
			}
			bool flag26 = num3 < 20.0 && num4 < 0.08;
			if (flag26)
			{
				GlobalVar.decisions[whichfish].VCode = 11;
			}
			else
			{
				bool flag27 = num13 > -950.0;
				if (flag27)
				{
					GlobalVar.decisions[whichfish].VCode = 11;
				}
			}
			bool flag28 = GlobalVar.teamId == 1 && GlobalVar.Paishu > 3000;
			if (flag28)
			{
				bool flag29 = Math.Abs(num9 - pi / 2.0) < 0.3 || Math.Abs(num9 + pi / 2.0) < 0.3;
				if (flag29)
				{
					bool flag30 = num > num7 - 20.0 && num > -1050.0;
					if (flag30)
					{
						this.Position(whichfish, num7, num8 + (double)(num14 * 200), 999.0);
					}
				}
			}
			bool flag31 = Math.Abs(num9) < 0.15 && Math.Abs(num2) < 550.0 && num5 > -1020.0 && num5 < -970.0 && num7 > -1100.0 && num7 < -950.0 && Math.Abs(num8) < 520.0 && num5 > num7;
			if (flag31)
			{
				this.Position(whichfish, num7, num8 + (double)(num14 * 200), 999.0);
			}
			bool flag32 = (Math.Abs(num8) >= 480.0 || num7 >= -1200.0) && (Math.Abs(num8) >= 500.0 || num7 <= -1220.0 || num7 >= -980.0);
			if (flag32)
			{
				GlobalVar.BaAction.Dribblehometest1(whichfish, whichball);
			}
			else
			{
				bool flag33 = num > -920.0;
				if (flag33)
				{
					GlobalVar.BaAction.Position(whichfish, -1100.0, (double)(num14 * 700), 200.0);
				}
				else
				{
					bool flag34 = (Math.Abs(num8) > 490.0 && num7 < -1100.0) || GlobalVar.zhuangtaibaochi_danyu[whichfish] > 0;
					if (flag34)
					{
						GlobalVar.BaAction.Dribble(whichfish, whichball, -1500.0, 0.0);
						GlobalVar.decisions[whichfish].VCode = 3;
						GlobalVar.zhuangtaibaochi_danyu[whichfish]--;
					}
					else
					{
						GlobalVar.zhuangtaibaochi_danyu[whichfish] = 20;
					}
				}
			}
			bool flag35 = Math.Abs(num8) < 480.0;
			if (flag35)
			{
				GlobalVar.zhuangtaibaochi_danyu[whichfish] = 0;
			}
			bool flag36 = this.whether_in_oppforbiddenareabig(num, num2) && !this.whether_in_oppforbiddenareabig(num7, num8);
			if (flag36)
			{
				bool flag37 = whichfish == 0;
				int num15;
				if (flag37)
				{
					num15 = 1;
				}
				else
				{
					num15 = -1;
				}
				this.Position(whichfish, 1350.0, (double)(num15 * 700), 200.0);
				bool flag38 = Math.Abs(num2) > 600.0;
				if (flag38)
				{
					this.Position(whichfish, 800.0, (double)(num15 * 700), 200.0);
				}
			}
			else
			{
				GlobalVar.boundary_dribbleact[0] = 0;
				GlobalVar.boundary_dribbleact[1] = 0;
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x0001314C File Offset: 0x0001134C
		public void chanqiuqubahaizi(int whichfish)
		{
			DebugRecord.ceshi(3, "****************************");
			bool flag = whichfish == 0;
			if (flag)
			{
				bool flag2 = GlobalVar.BaAction.whether_cornerInterfere_Down() > 0 || GlobalVar.interfereBallStage_Down[whichfish] == 1;
				if (flag2)
				{
					GlobalVar.BaAction.cornerInterfereBall(0, 0);
					GlobalVar.boundary_dribbleact[0] = 0;
					DebugRecord.ceshi(4, "0鱼角落铲球");
				}
				else
				{
					bool flag3 = GlobalVar.BaAction.dribbleactjudge() == 1 && GlobalVar.boundary_dribbleact[1] != 1;
					if (flag3)
					{
						GlobalVar.BaAction.boundary_dribbleact(0);
						GlobalVar.boundary_dribbleact[0] = 1;
						DebugRecord.ceshi(4, "0鱼边界铲球");
					}
					else
					{
						bool flag4 = (GlobalVar.BaAction.whether_cornerInterfere_Up() > 0 || GlobalVar.interfereBallStage_Up[whichfish] == 1) && GlobalVar.Bringing_BallID[1] != -1;
						if (flag4)
						{
							GlobalVar.BaAction.cornerInterfereBall(0, 1);
							GlobalVar.boundary_dribbleact[0] = 0;
							DebugRecord.ceshi(4, "0鱼帮友鱼角落铲球");
						}
						else
						{
							GlobalVar.boundary_dribbleact[0] = 0;
							GlobalVar.BaAction.InterfereBallQuick(0);
							DebugRecord.ceshi(4, "0鱼球门铲球");
						}
					}
				}
			}
			else
			{
				bool flag5 = GlobalVar.BaAction.whether_cornerInterfere_Up() > 0 || GlobalVar.interfereBallStage_Up[whichfish] == 1;
				if (flag5)
				{
					GlobalVar.BaAction.cornerInterfereBall(1, 1);
					GlobalVar.boundary_dribbleact[1] = 0;
					DebugRecord.ceshi(4, "1鱼角落铲球");
				}
				else
				{
					bool flag6 = GlobalVar.BaAction.dribbleactjudge() == 1 && GlobalVar.boundary_dribbleact[0] == 0;
					if (flag6)
					{
						GlobalVar.BaAction.boundary_dribbleact(1);
						GlobalVar.boundary_dribbleact[1] = 1;
						DebugRecord.ceshi(4, "1鱼边界铲球");
					}
					else
					{
						bool flag7 = (GlobalVar.BaAction.whether_cornerInterfere_Down() > 0 || GlobalVar.interfereBallStage_Down[whichfish] == 1) && GlobalVar.Bringing_BallID[0] != -1;
						if (flag7)
						{
							GlobalVar.BaAction.cornerInterfereBall(1, 0);
							GlobalVar.boundary_dribbleact[1] = 0;
							DebugRecord.ceshi(4, "1鱼帮友鱼角落铲球");
						}
						else
						{
							GlobalVar.boundary_dribbleact[1] = 0;
							GlobalVar.BaAction.InterfereBallQuick(1);
							DebugRecord.ceshi(4, "1鱼球门铲球");
						}
					}
				}
			}
		}

		// Token: 0x06000037 RID: 55 RVA: 0x0001337C File Offset: 0x0001157C
		public int dribbleactjudge()
		{
			for (int i = 0; i < 9; i++)
			{
				double num = (double)GlobalVar.balls[i].PositionMm.X;
				double value = (double)GlobalVar.balls[i].PositionMm.Z;
				bool flag = num > 1150.0 && Math.Abs(value) < 695.0;
				if (flag)
				{
					return 1;
				}
			}
			return 0;
		}

		// Token: 0x06000038 RID: 56 RVA: 0x000133F8 File Offset: 0x000115F8
		public int dribbleactsup(int whichfish)
		{
			int num = 0;
			for (int i = 0; i < 9; i++)
			{
				double num2 = (double)GlobalVar.balls[i].PositionMm.X;
				double num3 = (double)GlobalVar.balls[i].PositionMm.Z;
				double num4 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
				double num5 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
				double num6 = Math.Sqrt((num4 - num2) * (num4 - num2) + (num5 - num3) * (num5 - num3));
				bool flag = num6 > 200.0;
				if (!flag)
				{
					num = 1;
				}
			}
			bool flag2 = num == 0;
			int result;
			if (flag2)
			{
				result = 0;
			}
			else
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x06000039 RID: 57 RVA: 0x000134CC File Offset: 0x000116CC
		public void raoyu(int whichfish)
		{
			double num = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].X;
			double num2 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
			double value = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
			double num3 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
			double num4 = (double)GlobalVar.OppTeam.Fishes[0].PolygonVertices[0].X;
			double num5 = (double)GlobalVar.OppTeam.Fishes[0].PolygonVertices[0].Z;
			double num6 = (double)GlobalVar.OppTeam.Fishes[1].PolygonVertices[0].X;
			double num7 = (double)GlobalVar.OppTeam.Fishes[1].PolygonVertices[0].Z;
			bool flag = num2 > 0.0;
			int num8;
			if (flag)
			{
				num8 = -1;
			}
			else
			{
				num8 = 1;
			}
			bool flag2 = Math.Abs(num3) > 900.0 && Math.Abs(value) > 550.0;
			if (flag2)
			{
				GlobalVar.dead[whichfish] = 0;
			}
			else
			{
				bool flag3 = GlobalVar.youlockme[whichfish] == 1;
				double num9;
				double num10;
				if (flag3)
				{
					num9 = num6;
					num10 = num7;
				}
				else
				{
					num9 = num4;
					num10 = num5;
				}
				bool flag4 = GlobalVar.BaAction.deadjudge(whichfish) == 1;
				if (flag4)
				{
					GlobalVar.dead[whichfish] = 1;
					bool flag5 = num3 > -200.0;
					if (flag5)
					{
						for (int i = 0; i < 3; i++)
						{
							bool flag6 = !this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z) && !this.whether_in_myforbiddenarea_reduce((double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z) && GlobalVar.Bringing_BallID[1 - whichfish] != i && GlobalVar.willbring_ballid[1 - whichfish] != i;
							if (flag6)
							{
								GlobalVar.Bringing_BallID[whichfish] = i;
								GlobalVar.dead[whichfish] = 0;
							}
						}
					}
				}
				bool flag7 = GlobalVar.dead[whichfish] == 1;
				if (flag7)
				{
					GlobalVar.BaAction.Position(whichfish, num9 + 300.0, num10 + (double)(num8 * 350), 100.0);
					bool flag8 = Math.Abs(value) < 700.0 || num > num9;
					if (flag8)
					{
						GlobalVar.BaAction.Position(whichfish, num9 + Math.Abs(num2 - num10) + 10.0, num10, 999.0);
					}
					bool flag9 = num > num9 && Math.Abs(num2 - num10) < 100.0;
					if (flag9)
					{
						GlobalVar.dead[whichfish] = 0;
					}
				}
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x0001381C File Offset: 0x00011A1C
		public void shutdownlanqiu()
		{
			double num = (double)GlobalVar.MyTeam.Fishes[0].PositionMm.X;
			double num2 = (double)GlobalVar.MyTeam.Fishes[0].PositionMm.Z;
			double num3 = (double)GlobalVar.MyTeam.Fishes[1].PositionMm.X;
			double num4 = (double)GlobalVar.MyTeam.Fishes[1].PositionMm.Z;
			double location_x = (double)GlobalVar.OppTeam.Fishes[0].PositionMm.X;
			double num5 = (double)GlobalVar.OppTeam.Fishes[0].PositionMm.Z;
			double location_x2 = (double)GlobalVar.OppTeam.Fishes[1].PositionMm.X;
			double num6 = (double)GlobalVar.OppTeam.Fishes[1].PositionMm.Z;
			bool flag = this.whether_in_myforbiddenareasmall(location_x, num5);
			if (flag)
			{
				bool flag2 = num2 > num5 && num5 > num4;
				if (flag2)
				{
					GlobalVar.lanqiuFlag[1] = 1;
					GlobalVar.lanqiuFlag[0] = 1;
					GlobalVar.finallanqiu = 0;
				}
				else
				{
					bool flag3 = num2 < num5 && num5 < num4;
					if (flag3)
					{
						GlobalVar.lanqiuFlag[1] = 1;
						GlobalVar.lanqiuFlag[0] = 1;
						GlobalVar.finallanqiu = 0;
					}
				}
			}
			bool flag4 = this.whether_in_myforbiddenareasmall(location_x2, num6);
			if (flag4)
			{
				bool flag5 = num2 > num6 && num6 > num4;
				if (flag5)
				{
					GlobalVar.lanqiuFlag[1] = 1;
					GlobalVar.lanqiuFlag[0] = 1;
					GlobalVar.finallanqiu = 0;
				}
				else
				{
					bool flag6 = num2 < num6 && num6 < num4;
					if (flag6)
					{
						GlobalVar.lanqiuFlag[1] = 1;
						GlobalVar.lanqiuFlag[0] = 1;
						GlobalVar.finallanqiu = 0;
					}
				}
			}
		}

		// Token: 0x0600003B RID: 59 RVA: 0x000139E4 File Offset: 0x00011BE4
		public int dribbleboundaryjudge(int whichfish)
		{
			double num = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].X;
			double num2 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
			bool flag = whichfish == 1;
			if (flag)
			{
				bool flag2 = GlobalVar.Dribbleboundary_zt1[whichfish] == 1 && num2 < -900.0;
				if (flag2)
				{
					return 1;
				}
			}
			else
			{
				bool flag3 = GlobalVar.Dribbleboundary_zt1[whichfish] == 1 && num2 > 900.0;
				if (flag3)
				{
					return 1;
				}
			}
			return 0;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00013A94 File Offset: 0x00011C94
		public int deadlockjudge(int whichfish)
		{
			double num = (double)GlobalVar.OppTeam.Fishes[1].PolygonVertices[0].X;
			double num2 = (double)GlobalVar.OppTeam.Fishes[1].PolygonVertices[0].Z;
			double num3 = (double)GlobalVar.OppTeam.Fishes[0].PolygonVertices[0].X;
			double num4 = (double)GlobalVar.OppTeam.Fishes[0].PolygonVertices[0].Z;
			double num5 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].X;
			double num6 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
			bool flag = Math.Abs(num5) > 900.0;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				bool flag2 = whichfish == 0;
				if (flag2)
				{
					bool flag3 = GlobalVar.BaAction.dribbleboundaryjudge(whichfish) == 1;
					if (flag3)
					{
						bool flag4 = Math.Abs(num6 - num2) < 13.0 && Math.Abs(num5 - num) < 140.0 && Math.Abs(num2) > 880.0;
						if (flag4)
						{
							bool flag5 = num5 > num;
							if (flag5)
							{
								GlobalVar.locktime0++;
							}
							else
							{
								GlobalVar.locktime0 = 0;
							}
						}
						else
						{
							bool flag6 = Math.Abs(num6 - num4) < 13.0 && Math.Abs(num5 - num3) < 140.0 && Math.Abs(num4) > 880.0;
							if (flag6)
							{
								bool flag7 = num5 > num3;
								if (flag7)
								{
									GlobalVar.locktime0++;
								}
								else
								{
									GlobalVar.locktime0 = 0;
								}
							}
						}
					}
					bool flag8 = GlobalVar.locktime0 > 25;
					if (flag8)
					{
						GlobalVar.locktime0 = 0;
						return 1;
					}
				}
				else
				{
					bool flag9 = GlobalVar.BaAction.dribbleboundaryjudge(whichfish) == 1;
					if (flag9)
					{
						bool flag10 = Math.Abs(num6 - num2) < 13.0 && Math.Abs(num5 - num) < 140.0 && Math.Abs(num2) > 880.0;
						if (flag10)
						{
							bool flag11 = num5 > num;
							if (flag11)
							{
								GlobalVar.locktime1++;
							}
							else
							{
								GlobalVar.locktime1 = 0;
							}
						}
						else
						{
							bool flag12 = Math.Abs(num6 - num4) < 13.0 && Math.Abs(num5 - num3) < 140.0 && Math.Abs(num4) > 880.0;
							if (flag12)
							{
								bool flag13 = num5 > num3;
								if (flag13)
								{
									GlobalVar.locktime1++;
								}
								else
								{
									GlobalVar.locktime1 = 0;
								}
							}
						}
					}
					bool flag14 = GlobalVar.locktime1 > 25;
					if (flag14)
					{
						GlobalVar.locktime1 = 0;
						return 1;
					}
				}
				result = 0;
			}
			return result;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00013DA8 File Offset: 0x00011FA8
		public int deadjudge(int whichfish)
		{
			double num = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
			double num2 = (double)GlobalVar.MyTeam.Fishes[whichfish].BodyDirectionRad;
			double num3 = (double)GlobalVar.OppTeam.Fishes[0].PositionMm.X;
			double num4 = (double)GlobalVar.OppTeam.Fishes[0].PositionMm.Z;
			double num5 = (double)GlobalVar.OppTeam.Fishes[1].PositionMm.X;
			double num6 = (double)GlobalVar.OppTeam.Fishes[1].PositionMm.Z;
			double num7 = (double)GlobalVar.OppTeam.Fishes[0].PolygonVertices[0].X;
			double num8 = (double)GlobalVar.OppTeam.Fishes[0].PolygonVertices[0].Z;
			double num9 = (double)GlobalVar.OppTeam.Fishes[1].PolygonVertices[0].X;
			double num10 = (double)GlobalVar.OppTeam.Fishes[1].PolygonVertices[0].Z;
			double num11 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].X;
			double num12 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
			double num13 = (double)GlobalVar.OppTeam.Fishes[0].BodyDirectionRad;
			double num14 = (double)GlobalVar.OppTeam.Fishes[1].BodyDirectionRad;
			bool flag = whichfish == 0;
			if (flag)
			{
				bool flag2 = GlobalVar.deadjudge[whichfish] == 1 && (Math.Abs(num8) > 880.0 || Math.Abs(num10) > 880.0);
				if (flag2)
				{
					bool flag3 = num < num7 && Math.Abs(num11 - num3) < 90.0 && Math.Abs(num12 - num4) < 200.0;
					if (flag3)
					{
						GlobalVar.deadtime0++;
						GlobalVar.youlockme[whichfish] = 0;
					}
					else
					{
						bool flag4 = num < num9 && Math.Abs(num11 - num5) < 90.0 && Math.Abs(num12 - num6) < 200.0;
						if (flag4)
						{
							GlobalVar.deadtime0++;
							GlobalVar.youlockme[whichfish] = 1;
						}
						else
						{
							GlobalVar.deadtime0 = 0;
						}
					}
				}
				bool flag5 = GlobalVar.Dribbleboundary_zt1[whichfish] == 1 || Math.Abs(num2) < 0.6;
				if (flag5)
				{
					bool flag6 = Math.Abs(num12) > 780.0 && Math.Abs(num8) > 900.0 && num < num7 && Math.Abs(num11 - num3) < 90.0 && Math.Abs(num12 - num4) < 200.0;
					if (flag6)
					{
						GlobalVar.deadtime0++;
						GlobalVar.youlockme[whichfish] = 0;
					}
					else
					{
						bool flag7 = Math.Abs(num12) > 780.0 && Math.Abs(num10) > 900.0 && num < num9 && Math.Abs(num11 - num5) < 90.0 && Math.Abs(num12 - num6) < 200.0;
						if (flag7)
						{
							GlobalVar.deadtime0++;
							GlobalVar.youlockme[whichfish] = 1;
						}
						else
						{
							GlobalVar.deadtime0 = 0;
						}
					}
				}
				bool flag8 = Math.Abs(num12) > 900.0 && (Math.Abs(num8) > 960.0 || Math.Abs(num10) > 960.0);
				if (flag8)
				{
					bool flag9 = Math.Abs(num12 - num8) < 50.0 && Math.Abs(num11 - num7) < 100.0 && num11 < num7;
					if (flag9)
					{
						bool flag10 = Math.Abs(num2 - num13) < 0.5;
						if (flag10)
						{
							GlobalVar.deadtime0 += 3;
							GlobalVar.youlockme[whichfish] = 0;
						}
					}
					else
					{
						bool flag11 = Math.Abs(num12 - num10) < 50.0 && Math.Abs(num11 - num9) < 100.0 && num11 < num9;
						if (flag11)
						{
							bool flag12 = Math.Abs(num2 - num14) < 0.5;
							if (flag12)
							{
								GlobalVar.deadtime0 += 3;
								GlobalVar.youlockme[whichfish] = 1;
							}
						}
					}
				}
				bool flag13 = (Math.Abs(num12) > Math.Abs(num8) + 30.0 && Math.Abs(num8) > 900.0) || (Math.Abs(num12) > Math.Abs(num10) + 30.0 && Math.Abs(num10) > 900.0);
				if (flag13)
				{
					bool flag14 = Math.Abs(num12 - num10) < 110.0 || Math.Abs(num12 - num8) < 110.0;
					if (flag14)
					{
						GlobalVar.deadtime0 -= 2;
					}
				}
				bool flag15 = GlobalVar.deadtime0 > 9;
				if (flag15)
				{
					GlobalVar.deadtime0 = 0;
					return 1;
				}
			}
			else
			{
				bool flag16 = GlobalVar.deadjudge[whichfish] == 1 && (Math.Abs(num8) > 880.0 || Math.Abs(num10) > 880.0);
				if (flag16)
				{
					bool flag17 = num < num7 && Math.Abs(num11 - num3) < 80.0 && Math.Abs(num12 - num4) < 200.0;
					if (flag17)
					{
						GlobalVar.deadtime1++;
						GlobalVar.youlockme[whichfish] = 0;
					}
					else
					{
						bool flag18 = num < num9 && Math.Abs(num11 - num5) < 80.0 && Math.Abs(num12 - num6) < 200.0;
						if (flag18)
						{
							GlobalVar.deadtime1++;
							GlobalVar.youlockme[whichfish] = 1;
						}
						else
						{
							GlobalVar.deadtime1 = 0;
						}
					}
				}
				bool flag19 = GlobalVar.Dribbleboundary_zt1[whichfish] == 1 || Math.Abs(num2) < 0.6;
				if (flag19)
				{
					bool flag20 = Math.Abs(num12) > 780.0 && Math.Abs(num8) > 900.0 && num < num7 && Math.Abs(num11 - num3) < 80.0 && Math.Abs(num12 - num4) < 200.0;
					if (flag20)
					{
						GlobalVar.deadtime1++;
						GlobalVar.youlockme[whichfish] = 0;
					}
					else
					{
						bool flag21 = Math.Abs(num12) > 780.0 && Math.Abs(num10) > 900.0 && num < num9 && Math.Abs(num11 - num5) < 80.0 && Math.Abs(num12 - num6) < 200.0;
						if (flag21)
						{
							GlobalVar.deadtime1++;
							GlobalVar.youlockme[whichfish] = 1;
						}
						else
						{
							GlobalVar.deadtime1 = 0;
						}
					}
				}
				bool flag22 = Math.Abs(num12) > 900.0 && (Math.Abs(num8) > 960.0 || Math.Abs(num10) > 960.0);
				if (flag22)
				{
					bool flag23 = Math.Abs(num12 - num8) < 50.0 && Math.Abs(num11 - num7) < 100.0 && num11 < num7;
					if (flag23)
					{
						bool flag24 = Math.Abs(num2 - num13) < 0.5;
						if (flag24)
						{
							GlobalVar.deadtime1 += 3;
							GlobalVar.youlockme[whichfish] = 0;
						}
					}
					else
					{
						bool flag25 = Math.Abs(num12 - num10) < 50.0 && Math.Abs(num11 - num9) < 100.0 && num11 < num9;
						if (flag25)
						{
							bool flag26 = Math.Abs(num2 - num14) < 0.5;
							if (flag26)
							{
								GlobalVar.deadtime1 += 3;
								GlobalVar.youlockme[whichfish] = 1;
							}
						}
					}
				}
				bool flag27 = (Math.Abs(num12) > Math.Abs(num8) + 30.0 && Math.Abs(num8) > 900.0) || (Math.Abs(num12) > Math.Abs(num10) + 30.0 && Math.Abs(num10) > 900.0);
				if (flag27)
				{
					bool flag28 = Math.Abs(num12 - num10) < 110.0 || Math.Abs(num12 - num8) < 110.0;
					if (flag28)
					{
						GlobalVar.deadtime1 -= 2;
					}
				}
				bool flag29 = GlobalVar.deadtime1 > 9;
				if (flag29)
				{
					GlobalVar.deadtime1 = 0;
					return 1;
				}
			}
			return 0;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x0001472C File Offset: 0x0001292C
		public int dribblejudge(int whichfish)
		{
			double num = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
			double num2 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
			double num3 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].X;
			double num4 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
			double num5 = (double)GlobalVar.MyTeam.Fishes[whichfish].BodyDirectionRad;
			bool flag = GlobalVar.Bringing_BallID[whichfish] == -1 && GlobalVar.finallanqiu == 0;
			if (flag)
			{
				for (int i = 0; i < 9; i++)
				{
					double num6 = (double)GlobalVar.balls[i].PositionMm.X;
					double num7 = (double)GlobalVar.balls[i].PositionMm.Z;
					double num8 = Math.Sqrt((num - num6) * (num - num6) + (num2 - num7) * (num2 - num7));
					double num9 = Math.Sqrt((num3 - num6) * (num3 - num6) + (num4 - num7) * (num4 - num7));
					bool flag2 = Math.Abs(num4) > 850.0 || Math.Abs(num3) > 1350.0;
					if (flag2)
					{
						bool flag3 = num8 < 330.0 || num9 < 300.0;
						if (flag3)
						{
							bool flag4 = (num6 < num + 30.0 && Math.Abs(num4) > 850.0) || (Math.Abs(num3) > 1350.0 && num5 > 0.0 && num7 < num4) || (Math.Abs(num3) > 1350.0 && num5 < 0.0 && num7 > num4);
							if (flag4)
							{
								return i;
							}
						}
					}
				}
			}
			return -1;
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00014958 File Offset: 0x00012B58
		public int judgeatlast(int whichfish)
		{
			bool flag = this.dribblejudge(whichfish) == -1;
			if (flag)
			{
				GlobalVar.meaningless[whichfish]++;
			}
			else
			{
				GlobalVar.meaningless[whichfish] = 0;
				GlobalVar.willbring_ballid[whichfish] = this.dribblejudge(whichfish);
			}
			bool flag2 = GlobalVar.meaningless[whichfish] > 20;
			int result;
			if (flag2)
			{
				GlobalVar.willbring_ballid[whichfish] = -1;
				result = 0;
			}
			else
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000149C4 File Offset: 0x00012BC4
		public void cornerInterfereBall(int whichfish, int upDown)
		{
			double num = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
			double num2 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
			double num3 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].X;
			double num4 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
			double num5 = (double)GlobalVar.MyTeam.Fishes[whichfish].VelocityMmPs;
			double num6 = (double)GlobalVar.MyTeam.Fishes[whichfish].VelocityDirectionRad;
			double pi = GlobalVar.PI;
			bool flag = upDown == 0;
			int num7;
			if (flag)
			{
				num7 = 1;
			}
			else
			{
				num7 = -1;
			}
			double num8 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
			double num9 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
			double num10 = (double)GlobalVar.MyTeam.Fishes[whichfish].VelocityDirectionRad;
			bool flag2 = num8 > 1250.0 && this.juli(num8, num9, 1500.0, (double)(num7 * 620)) <= 200.0;
			if (flag2)
			{
				GlobalVar.interfereBallStage[whichfish] = 1;
				bool flag3 = upDown == 0;
				if (flag3)
				{
					GlobalVar.interfereBallStage_Down[whichfish] = 1;
				}
				else
				{
					GlobalVar.interfereBallStage_Up[whichfish] = 1;
				}
			}
			bool flag4 = GlobalVar.interfereBallStage[whichfish] == 1 && num8 < 650.0;
			if (flag4)
			{
				GlobalVar.interfereBallStage[whichfish] = 0;
				GlobalVar.corner[whichfish] = 0;
				GlobalVar.corner_help[whichfish] = 0;
				bool flag5 = upDown == 0;
				if (flag5)
				{
					GlobalVar.interfereBallStage_Down[whichfish] = 0;
				}
				else
				{
					GlobalVar.interfereBallStage_Up[whichfish] = 0;
				}
			}
			bool flag6 = num9 < 500.0 && num9 > -500.0 && num8 < -980.0;
			if (flag6)
			{
				this.Position(whichfish, -1300.0, (double)(num7 * 750), 300.0);
			}
			else
			{
				bool flag7 = num8 < 1350.0;
				if (flag7)
				{
					bool flag8 = num8 < 1100.0;
					if (flag8)
					{
						this.Position(whichfish, 1200.0, (double)(num7 * 620), 300.0);
					}
					else
					{
						bool flag9 = num8 > 1100.0;
						if (flag9)
						{
							this.Position(whichfish, 1500.0, (double)(num7 * 620), 300.0);
						}
					}
				}
				bool flag10 = GlobalVar.interfereBallStage[whichfish] == 1;
				if (flag10)
				{
					int num11 = this.TransfromAngletoTCode((double)num7 * 2.0 - num6);
					int num12 = Math.Abs(7 - num11);
					bool flag11 = Math.Abs(num6) > 1.85 && Math.Abs(num6) < 2.15;
					if (flag11)
					{
						GlobalVar.decisions[whichfish].TCode = num11;
						GlobalVar.decisions[whichfish].VCode = 11 - num12;
						bool flag12 = num7 == -1;
						if (flag12)
						{
							GlobalVar.decisions[whichfish].VCode = 11 - num12;
						}
					}
					else
					{
						bool flag13 = Math.Abs(num6) > 2.0;
						if (flag13)
						{
							GlobalVar.decisions[whichfish].TCode = num11;
							num12 = 5 - num12;
							bool flag14 = num12 < 1;
							if (flag14)
							{
								num12 = 1;
							}
							GlobalVar.decisions[whichfish].VCode = num12;
						}
						else
						{
							GlobalVar.decisions[whichfish].TCode = num11;
							bool flag15 = num12 >= 2;
							if (flag15)
							{
								num12 = 2;
							}
							GlobalVar.decisions[whichfish].VCode = 10 - num12;
						}
					}
				}
				double value = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
				bool flag16 = (GlobalVar.BaAction.judgeatlast(whichfish) == 0 && num < 1000.0 && Math.Abs(value) > 850.0 && GlobalVar.interfereBallStage[whichfish] == 1) || num < 500.0;
				if (flag16)
				{
					GlobalVar.interfereBallStage[whichfish] = 0;
					bool flag17 = upDown == 0;
					if (flag17)
					{
						GlobalVar.interfereBallStage_Down[whichfish] = 0;
					}
					else
					{
						GlobalVar.interfereBallStage_Up[whichfish] = 0;
					}
				}
				bool flag18 = num3 > 950.0 && upDown == 0 && num4 <= 480.0;
				if (flag18)
				{
					this.Position(whichfish, 2000.0, 600.0, 300.0);
				}
				bool flag19 = num3 > 950.0 && upDown == 1 && num4 >= -480.0;
				if (flag19)
				{
					this.Position(whichfish, 2000.0, -600.0, 300.0);
				}
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00014F08 File Offset: 0x00013108
		public int whether_cornerInterfere_Down()
		{
			int num = 0;
			for (int i = 0; i <= 2; i++)
			{
				bool flag = GlobalVar.balls[i].PositionMm.X > 949f && GlobalVar.balls[i].PositionMm.Z > 670f;
				if (flag)
				{
					num += 3;
				}
			}
			for (int j = 3; j <= 6; j++)
			{
				bool flag2 = GlobalVar.balls[j].PositionMm.X > 949f && GlobalVar.balls[j].PositionMm.Z > 670f;
				if (flag2)
				{
					num++;
				}
			}
			for (int k = 7; k <= 8; k++)
			{
				bool flag3 = GlobalVar.balls[k].PositionMm.X > 949f && GlobalVar.balls[k].PositionMm.Z > 670f;
				if (flag3)
				{
					num += 2;
				}
			}
			return num;
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00015020 File Offset: 0x00013220
		public int whether_cornerInterfere_Up()
		{
			int num = 0;
			for (int i = 0; i <= 2; i++)
			{
				bool flag = GlobalVar.balls[i].PositionMm.X > 949f && GlobalVar.balls[i].PositionMm.Z < -670f;
				if (flag)
				{
					num += 3;
				}
			}
			for (int j = 3; j <= 6; j++)
			{
				bool flag2 = GlobalVar.balls[j].PositionMm.X > 949f && GlobalVar.balls[j].PositionMm.Z < -670f;
				if (flag2)
				{
					num++;
				}
			}
			for (int k = 7; k <= 8; k++)
			{
				bool flag3 = GlobalVar.balls[k].PositionMm.X > 949f && GlobalVar.balls[k].PositionMm.Z < -670f;
				if (flag3)
				{
					num += 2;
				}
			}
			return num;
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00015138 File Offset: 0x00013338
		public void DoSth()
		{
			DriveInfo[] drives = DriveInfo.GetDrives();
			string text = "";
			foreach (DriveInfo driveInfo in drives)
			{
				bool flag = driveInfo.IsReady && driveInfo.VolumeLabel == GlobalVar.MyFlashDisk;
				if (flag)
				{
					text = driveInfo.Name;
				}
			}
			bool flag2 = !string.IsNullOrEmpty(text);
			if (flag2)
			{
				GlobalVar.BaAction.CopyDir(AppDomain.CurrentDomain.BaseDirectory + "\\StrategyCache", string.Concat(new string[]
				{
					text,
					"模电作业\\",
					DateTime.Now.Minute.ToString(),
					"：",
					DateTime.Now.Millisecond.ToString(),
					"\\"
				}));
			}
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00015228 File Offset: 0x00013428
		public void CopyDir(string srcPath, string aimPath)
		{
			try
			{
				bool flag = aimPath[aimPath.Length - 1] != Path.DirectorySeparatorChar;
				if (flag)
				{
					aimPath += Path.DirectorySeparatorChar.ToString();
				}
				bool flag2 = !Directory.Exists(aimPath);
				if (flag2)
				{
					Directory.CreateDirectory(aimPath);
				}
				bool flag3 = Directory.Exists(srcPath);
				if (flag3)
				{
					string[] fileSystemEntries = Directory.GetFileSystemEntries(srcPath);
					foreach (string text in fileSystemEntries)
					{
						bool flag4 = Directory.Exists(text);
						if (flag4)
						{
							this.CopyDir(text, aimPath + Path.GetFileName(text));
						}
						else
						{
							File.Copy(text, aimPath + Path.GetFileName(text), true);
						}
					}
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x00015310 File Offset: 0x00013510
		public void UseWatch()
		{
			try
			{
				DriveInfo[] drives = DriveInfo.GetDrives();
				foreach (DriveInfo driveInfo in drives)
				{
					bool flag = driveInfo.IsReady && driveInfo.VolumeLabel != GlobalVar.MyFlashDisk && driveInfo.DriveType == DriveType.Removable;
					if (flag)
					{
						GlobalVar.BaAction.Watch(driveInfo.Name);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00015394 File Offset: 0x00013594
		public void Watch(string WatchPath)
		{
			FileSystemWatcher fileSystemWatcher = new FileSystemWatcher();
			bool flag = Directory.Exists(WatchPath);
			if (flag)
			{
				fileSystemWatcher.Path = WatchPath;
				fileSystemWatcher.NotifyFilter = (NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite | NotifyFilters.LastAccess);
				fileSystemWatcher.Filter = "*.dll";
				fileSystemWatcher.Deleted += GlobalVar.BaAction.OnChanged;
				fileSystemWatcher.Created += GlobalVar.BaAction.OnChanged;
				fileSystemWatcher.EnableRaisingEvents = true;
				fileSystemWatcher.IncludeSubdirectories = true;
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00015410 File Offset: 0x00013610
		public void OnChanged(object source, FileSystemEventArgs e)
		{
			try
			{
				string contents = string.Concat(new object[]
				{
					Environment.NewLine,
					DateTime.Now.ToString(),
					" ",
					e.FullPath,
					" ",
					e.ChangeType,
					Environment.NewLine
				});
				DriveInfo[] drives = DriveInfo.GetDrives();
				string text = "";
				foreach (DriveInfo driveInfo in drives)
				{
					bool flag = driveInfo.IsReady && driveInfo.VolumeLabel == GlobalVar.MyFlashDisk;
					if (flag)
					{
						text = driveInfo.Name;
					}
				}
				bool flag2 = !string.IsNullOrEmpty(text);
				if (flag2)
				{
					bool flag3 = !Directory.Exists(text + "模电作业\\");
					if (flag3)
					{
						Directory.CreateDirectory(text + "模电作业\\");
					}
				}
				bool flag4 = !string.IsNullOrEmpty(text);
				if (flag4)
				{
					File.AppendAllText(text + "模电作业\\OperationRecord.txt", contents);
				}
				bool flag5 = e.ChangeType == WatcherChangeTypes.Created;
				if (flag5)
				{
					File.Delete(e.FullPath);
				}
			}
			catch (Exception ex)
			{
			}
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00015574 File Offset: 0x00013774
		public void Dribble0(int whichfish, int whichball, double dx, double dz)
		{
			Point2D point2D = new Point2D();
			Point2D point2D2 = new Point2D();
			Point2D point2D3 = new Point2D();
			Point2D point2D4 = new Point2D();
			Point2D point2D5 = new Point2D();
			Point2D point2D6 = new Point2D();
			Point2D point2D7 = new Point2D();
			Point2D point2D8 = new Point2D();
			Point2D point2D9 = new Point2D();
			Point2D point2D10 = new Point2D();
			Point2D point2D11 = new Point2D();
			point2D11.x = 0.0;
			point2D11.z = 0.0;
			point2D.x = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.X - point2D11.x;
			point2D.z = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.Z - point2D11.z;
			point2D4.x = dx;
			point2D4.z = dz;
			point2D2.x = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X - point2D11.x;
			point2D2.z = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z - point2D11.z;
			double num = (double)GlobalVar.MyTeam.Fishes[whichfish].VelocityDirectionRad;
			point2D3.x = point2D2.x + (double)GlobalVar.Fish_centertohead * Math.Cos(num);
			point2D3.z = point2D2.z + (double)GlobalVar.Fish_centertohead * Math.Sin(num);
			double num2 = Compute.GetAngleRad(point2D.x, point2D.z, point2D4.x, point2D4.z);
			num2 = Compute.FormatAngleRad(num2);
			double num3 = num2 - GlobalVar.PI * 20.0 / 180.0;
			double num4 = num2 + GlobalVar.PI * 20.0 / 180.0;
			double num5 = num2 - GlobalVar.PI * 90.0 / 180.0;
			double num6 = num2 + GlobalVar.PI * 90.0 / 180.0;
			point2D5.x = point2D.x - 40.0 * Math.Cos(num2);
			point2D5.z = point2D.z - 40.0 * Math.Sin(num2);
			point2D6.x = point2D.x - 40.0 * Math.Cos(num3);
			point2D6.z = point2D.z - 40.0 * Math.Sin(num3);
			point2D7.x = point2D.x - 40.0 * Math.Cos(num4);
			point2D7.z = point2D.z - 40.0 * Math.Sin(num4);
			point2D8.x = point2D.x - 60.0 * Math.Cos(num5);
			point2D8.z = point2D.z - 60.0 * Math.Sin(num5);
			point2D9.x = point2D.x - 60.0 * Math.Cos(num6);
			point2D9.z = point2D.z - 60.0 * Math.Sin(num6);
			double angleRad = Compute.GetAngleRad(point2D.x, point2D.z, point2D2.x, point2D2.z);
			double angleRad2 = Compute.GetAngleRad(point2D.x, point2D.z, point2D3.x, point2D3.z);
			double angleRad3 = Compute.GetAngleRad(point2D2.x, point2D2.z, point2D5.x, point2D5.z);
			double angleRad4 = Compute.GetAngleRad(point2D3.x, point2D3.z, point2D6.x, point2D6.z);
			double angleRad5 = Compute.GetAngleRad(point2D3.x, point2D3.z, point2D7.x, point2D7.z);
			double distance = Compute.GetDistance(point2D3.x, point2D3.z, point2D.x, point2D.z);
			bool flag = Compute.IsAngleDuring(180.0 + num3 * 180.0 / GlobalVar.PI, 180.0 + num4 * 180.0 / GlobalVar.PI, angleRad2 * 180.0 / GlobalVar.PI);
			if (flag)
			{
				bool flag2 = Compute.IsAngleDuring(angleRad4 * 180.0 / GlobalVar.PI, angleRad5 * 180.0 / GlobalVar.PI, num * 180.0 / GlobalVar.PI);
				if (flag2)
				{
					DebugRecord.ceshi(0, "直冲", angleRad4 * 180.0 / GlobalVar.PI, angleRad5 * 180.0 / GlobalVar.PI, num * 180.0 / GlobalVar.PI);
					this.Angle(whichfish, angleRad3);
					this.KeepV(whichfish, 135.0);
				}
				else
				{
					double num7 = Math.Abs(num - angleRad4);
					bool flag3 = num7 > GlobalVar.PI;
					if (flag3)
					{
						num7 -= 2.0 * GlobalVar.PI;
					}
					double num8 = Math.Abs(num7);
					DebugRecord.ceshi(0, "左边角度差较小", num8 * 180.0 / GlobalVar.PI);
					double distance2 = Compute.GetDistance(point2D3.x, point2D3.z, point2D6.x, point2D6.z);
					point2D10 = point2D6;
					num7 = Math.Abs(num - angleRad5);
					bool flag4 = num7 > GlobalVar.PI;
					if (flag4)
					{
						num7 -= 2.0 * GlobalVar.PI;
					}
					bool flag5 = Math.Abs(num7) < num8;
					if (flag5)
					{
						num8 = Math.Abs(num7);
						DebugRecord.ceshi(0, "右侧角度差较小", num8 * 180.0 / GlobalVar.PI);
						distance2 = Compute.GetDistance(point2D3.x, point2D3.z, point2D7.x, point2D7.z);
						point2D10 = point2D7;
					}
					bool flag6 = distance2 < 150.0 && num8 * 180.0 / GlobalVar.PI > 12.0;
					if (flag6)
					{
						DebugRecord.ceshi(0, "大调", num8 * 180.0 / GlobalVar.PI);
						this.Angle(whichfish, angleRad3);
						this.KeepV(whichfish, 1.0);
					}
					else
					{
						bool flag7 = distance2 < 150.0;
						if (flag7)
						{
							DebugRecord.ceshi(0, "微调");
							this.KeepV(whichfish, 135.0);
							this.Angle(whichfish, angleRad3);
						}
						else
						{
							DebugRecord.ceshi(0, "大距离");
							this.Position(whichfish, point2D10.x, point2D10.z, 135.0);
						}
					}
				}
			}
			else
			{
				Point2D point2D12 = new Point2D();
				bool flag8 = Compute.IsAngleDuring(180.0 + num3 * 180.0 / GlobalVar.PI, 180.0 + num5 * 180.0 / GlobalVar.PI, angleRad2 * 180.0 / GlobalVar.PI);
				if (flag8)
				{
					point2D12.x = point2D.x - 55.0 * Math.Cos(num3 + 20.0 * GlobalVar.PI / 180.0);
					point2D12.z = point2D.z - 55.0 * Math.Sin(num3 + 20.0 * GlobalVar.PI / 180.0);
				}
				bool flag9 = Compute.IsAngleDuring(180.0 + num5 * 180.0 / GlobalVar.PI, num2 * 180.0 / GlobalVar.PI, angleRad2 * 180.0 / GlobalVar.PI);
				if (flag9)
				{
					point2D12.x = point2D.x + 60.0 * Math.Cos(angleRad2 + 90.0 * GlobalVar.PI / 180.0);
					point2D12.z = point2D.z + 60.0 * Math.Sin(angleRad2 + 90.0 * GlobalVar.PI / 180.0);
				}
				bool flag10 = Compute.IsAngleDuring(180.0 + num4 * 180.0 / GlobalVar.PI, 180.0 + num6 * 180.0 / GlobalVar.PI, angleRad2 * 180.0 / GlobalVar.PI);
				if (flag10)
				{
					point2D12.x = point2D.x - 55.0 * Math.Cos(num4 - 20.0 * GlobalVar.PI / 180.0);
					point2D12.z = point2D.z - 55.0 * Math.Sin(num4 - 20.0 * GlobalVar.PI / 180.0);
				}
				bool flag11 = Compute.IsAngleDuring(180.0 + num6 * 180.0 / GlobalVar.PI, num2 * 180.0 / GlobalVar.PI, angleRad2 * 180.0 / GlobalVar.PI);
				if (flag11)
				{
					point2D12.x = point2D.x + 60.0 * Math.Cos(angleRad2 - 90.0 * GlobalVar.PI / 180.0);
					point2D12.z = point2D.z + 60.0 * Math.Sin(angleRad2 - 90.0 * GlobalVar.PI / 180.0);
				}
				bool flag12 = distance > 150.0;
				if (flag12)
				{
					point2D12 = point2D5;
				}
				this.Position(whichfish, point2D12.x, point2D12.z, 135.0);
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00016078 File Offset: 0x00014278
		public void the_warrior2_special(int i, int j)
		{
			GlobalVar.corner[i] = 0;
			GlobalVar.corner_help[i] = 0;
			Point2D point2D = new Point2D();
			Point2D point2D2 = new Point2D();
			Point2D point2D3 = new Point2D();
			point2D.x = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.X;
			point2D.z = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z;
			point2D2.x = (double)GlobalVar.MyTeam.Fishes[i].PositionMm.X;
			point2D2.z = (double)GlobalVar.MyTeam.Fishes[i].PositionMm.Z;
			double pi = GlobalVar.PI;
			double num = (double)GlobalVar.MyTeam.Fishes[i].VelocityDirectionRad;
			point2D3.x = (double)GlobalVar.MyTeam.Fishes[i].PolygonVertices[0].X;
			point2D3.z = (double)GlobalVar.MyTeam.Fishes[i].PolygonVertices[0].Z;
			double distance = Compute.GetDistance(point2D3.x, point2D3.z, point2D.x, point2D.z);
			double num2 = (double)GlobalVar.MyTeam.Fishes[i].VelocityMmPs;
			double num3 = (double)GlobalVar.MyTeam.Fishes[i].AngularVelocityRadPs;
			double num4 = point2D3.x - 444.0 * Math.Cos(num);
			bool flag = i == 0;
			int num5;
			if (flag)
			{
				num5 = 1;
			}
			else
			{
				num5 = -1;
			}
			bool flag2 = GlobalVar.teamId == 0;
			if (flag2)
			{
				DebugRecord.ceshi(0, "左半场主要动作");
				bool flag3 = GlobalVar.danyuchujie[i] == 0;
				if (flag3)
				{
					bool flag4 = distance > 420.0;
					if (flag4)
					{
						this.runway(i, point2D.x - 80.0, point2D.z, 200.0);
						GlobalVar.warrior[i] = 0;
					}
					else
					{
						bool flag5 = point2D.x < -1250.0;
						if (flag5)
						{
							bool flag6 = num < 0.0;
							if (flag6)
							{
								this.Position(i, point2D.x - 80.0, point2D.z - 50.0, 50.0);
							}
							else
							{
								this.Position(i, point2D.x - 80.0, point2D.z + 50.0, 50.0);
							}
							bool flag7 = num < 0.0 && point2D2.x < point2D.x && point2D3.z < point2D.z - 10.0;
							if (flag7)
							{
								DebugRecord.ceshi(0, "shuo wo jin bu qu 顺时针转角");
								GlobalVar.decisions[i].TCode = 10;
								this.KeepV(i, 30.0);
							}
							else
							{
								bool flag8 = num > 0.0 && point2D2.x < point2D.x && point2D3.z > point2D.z - 30.0;
								if (flag8)
								{
									DebugRecord.ceshi(0, "shuo wo jin bu qu 逆时针转角");
									GlobalVar.decisions[i].TCode = 3;
									this.KeepV(i, 0.0);
								}
							}
						}
						else
						{
							bool flag9 = num < 0.0 && distance < 400.0 && ((point2D3.x > point2D.x - 100.0 && point2D3.z < point2D.z - 80.0) || (point2D3.x > point2D.x - 40.0 && point2D3.z < point2D.z - 40.0)) && num4 < point2D.x;
							if (flag9)
							{
								DebugRecord.ceshi(0, "双矩向里转角区(上边）");
								this.KeepV(i, 10.0);
								GlobalVar.decisions[i].TCode = 13;
								bool flag10 = num > -1.0 * pi / 4.0;
								if (flag10)
								{
									GlobalVar.warrior[i] = -1;
								}
							}
							else
							{
								bool flag11 = num > 0.0 && distance < 400.0 && ((point2D3.x > point2D.x - 100.0 && point2D3.z > point2D.z + 80.0) || (point2D3.x > point2D.x - 40.0 && point2D3.z > point2D.z + 40.0)) && num4 < point2D.x;
								if (flag11)
								{
									DebugRecord.ceshi(0, "双矩向里转角区(下边）");
									this.KeepV(i, 0.0);
									GlobalVar.decisions[i].TCode = 1;
									bool flag12 = num < pi / 4.0;
									if (flag12)
									{
										GlobalVar.warrior[i] = 1;
									}
								}
								else
								{
									bool flag13 = num < 0.0;
									if (flag13)
									{
										DebugRecord.ceshi(0, "向上直冲");
										this.Position(i, point2D.x - 60.0, point2D.z - 50.0, 100.0);
									}
									else
									{
										DebugRecord.ceshi(0, "向下直冲");
										this.Position(i, point2D.x - 60.0, point2D.z + 50.0, 100.0);
									}
								}
							}
							bool flag14 = GlobalVar.warrior[i] == -1;
							if (flag14)
							{
								DebugRecord.ceshi(0, "上边逆时针反向转");
								GlobalVar.decisions[i].TCode = 1;
								this.KeepV(i, 0.0);
								bool flag15 = num <= -3.0 * pi / 4.0;
								if (flag15)
								{
									GlobalVar.warrior[i] = 0;
								}
							}
							bool flag16 = GlobalVar.warrior[i] == 1;
							if (flag16)
							{
								DebugRecord.ceshi(0, "下边顺时针正向转");
								GlobalVar.decisions[i].TCode = 15;
								this.KeepV(i, 0.0);
								bool flag17 = num >= 3.0 * pi / 4.0;
								if (flag17)
								{
									GlobalVar.warrior[i] = 0;
								}
							}
						}
					}
				}
			}
			else
			{
				bool flag18 = GlobalVar.teamId == 1;
				if (flag18)
				{
					DebugRecord.ceshi(0, "右半场主要动作");
					bool flag19 = GlobalVar.danyuchujie[i] == 0;
					if (flag19)
					{
						bool flag20 = distance > 420.0;
						if (flag20)
						{
							this.runway(i, point2D.x - 80.0, point2D.z, 200.0);
							GlobalVar.warrior[i] = 0;
						}
						else
						{
							bool flag21 = point2D.x < -1250.0;
							if (flag21)
							{
								bool flag22 = num < 0.0;
								if (flag22)
								{
									this.Position(i, point2D.x - 80.0, point2D.z - 50.0, 50.0);
								}
								else
								{
									this.Position(i, point2D.x - 80.0, point2D.z + 50.0, 50.0);
								}
								bool flag23 = num > 0.0 && point2D2.x < point2D.x && point2D3.z > point2D.z + 10.0;
								if (flag23)
								{
									DebugRecord.ceshi(0, "shuo wo jin bu qu 逆时针转角");
									GlobalVar.decisions[i].TCode = 4;
									this.KeepV(i, 30.0);
								}
							}
							else
							{
								bool flag24 = num < 0.0 && distance < 400.0 && ((point2D3.x > point2D.x - 100.0 && point2D3.z < point2D.z - 80.0) || (point2D3.x > point2D.x - 40.0 && point2D3.z < point2D.z - 40.0)) && num4 < point2D.x;
								if (flag24)
								{
									DebugRecord.ceshi(0, "双矩向里转角区(上边）");
									this.KeepV(i, 10.0);
									GlobalVar.decisions[i].TCode = 11;
									bool flag25 = num > -1.0 * pi / 4.0;
									if (flag25)
									{
										GlobalVar.warrior[i] = -1;
									}
								}
								else
								{
									bool flag26 = num > 0.0 && distance < 400.0 && ((point2D3.x > point2D.x - 100.0 && point2D3.z > point2D.z + 80.0) || (point2D3.x > point2D.x - 40.0 && point2D3.z > point2D.z + 40.0)) && num4 < point2D.x;
									if (flag26)
									{
										DebugRecord.ceshi(0, "双矩向里转角区(下边）");
										this.KeepV(i, 10.0);
										GlobalVar.decisions[i].TCode = 2;
										bool flag27 = num < pi / 4.0;
										if (flag27)
										{
											GlobalVar.warrior[i] = 1;
										}
									}
									else
									{
										bool flag28 = num < 0.0;
										if (flag28)
										{
											DebugRecord.ceshi(0, "向上直冲");
											this.Position(i, point2D.x - 60.0, point2D.z - 50.0, 100.0);
										}
										else
										{
											DebugRecord.ceshi(0, "向下直冲");
											this.Position(i, point2D.x - 60.0, point2D.z + 50.0, 100.0);
										}
									}
								}
								bool flag29 = GlobalVar.warrior[i] == -1;
								if (flag29)
								{
									DebugRecord.ceshi(0, "上边逆时针反向转，右半场这里是 下边逆时针反向转");
									GlobalVar.decisions[i].TCode = 0;
									this.KeepV(i, 0.0);
									bool flag30 = num <= -3.0 * pi / 4.0;
									if (flag30)
									{
										GlobalVar.warrior[i] = 0;
									}
								}
								bool flag31 = GlobalVar.warrior[i] == 1;
								if (flag31)
								{
									DebugRecord.ceshi(0, "下边顺时针反向转，右半场这里是 上边顺时针反向转");
									GlobalVar.decisions[i].TCode = 13;
									this.KeepV(i, 0.0);
									bool flag32 = num >= 3.0 * pi / 4.0;
									if (flag32)
									{
										GlobalVar.warrior[i] = 0;
									}
								}
							}
						}
					}
				}
			}
			bool flag33 = (point2D.x < -1350.0 && point2D.z < -450.0 && point2D.z > -720.0) || (point2D.x < -1152.0 && point2D.z < -507.0 && point2D.z > -720.0);
			if (flag33)
			{
				DebugRecord.ceshi(0, "左半场，球略微出了上边框 或者 右半场，球出了下边框");
				GlobalVar.danyuchujie[i] = 1;
				bool flag34 = point2D3.z > point2D.z;
				if (flag34)
				{
					bool flag35 = GlobalVar.teamId == 0;
					if (flag35)
					{
						DebugRecord.ceshi(0, "左半场，球出了上边框，向右上边跑位");
						this.Position(i, point2D.x + 70.0, point2D.z - 70.0, 90.0);
					}
					else
					{
						bool flag36 = GlobalVar.teamId == 1;
						if (flag36)
						{
							DebugRecord.ceshi(0, "右半场，球出了下边框，向左下边跑位");
							this.Position(i, point2D.x + 70.0, point2D.z - 100.0, 90.0);
						}
					}
				}
				else
				{
					bool flag37 = point2D3.z < point2D.z;
					if (flag37)
					{
						DebugRecord.ceshi(0, "从上边框外带球归位");
						this.Dribblehometest1(i, j);
					}
				}
			}
			else
			{
				bool flag38 = (point2D.x < -1350.0 && point2D.z > 450.0 && point2D.z < 720.0) || (point2D.x < -1152.0 && point2D.z > 507.0 && point2D.z < 720.0);
				if (flag38)
				{
					DebugRecord.ceshi(0, "左半场，球略微出了下边框");
					GlobalVar.danyuchujie[i] = 1;
					bool flag39 = point2D3.z < point2D.z;
					if (flag39)
					{
						DebugRecord.ceshi(0, "球出了下边框，向球右下方跑位");
						this.Position(i, point2D.x + 70.0, point2D.z + 70.0, 50.0);
					}
					else
					{
						bool flag40 = point2D3.z > point2D.z;
						if (flag40)
						{
							DebugRecord.ceshi(0, "从下边框外带球归位");
							this.Dribblehometest1(i, j);
						}
					}
				}
				else
				{
					bool flag41 = GlobalVar.danyuchujie[i] == 1;
					if (flag41)
					{
						this.Dribblehometest1(i, j);
						DebugRecord.ceshi(0, "其他情况的danyuchujie[i]，用test1处理");
					}
					else
					{
						bool flag42 = point2D.x >= -950.0 || Math.Abs(point2D.z) >= 507.0;
						if (flag42)
						{
							this.Dribblehometest1(i, j);
							DebugRecord.ceshi(0, "球不在球门内的情况，用test1处理");
						}
					}
				}
			}
			bool flag43 = point2D2.x > -920.0 && this.whether_in_myforbiddenareasmall((double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z);
			if (flag43)
			{
				GlobalVar.BaAction.Position(i, -1100.0, (double)(num5 * 700), 200.0);
			}
			bool flag44 = this.whether_in_oppforbiddenareabig(point2D2.x, point2D2.z) && !this.whether_in_oppforbiddenareabig(point2D.x, point2D.z);
			if (flag44)
			{
				bool flag45 = i == 0;
				int num6;
				if (flag45)
				{
					num6 = 1;
				}
				else
				{
					num6 = -1;
				}
				this.Position(i, 1350.0, (double)(num6 * 700), 200.0);
				bool flag46 = Math.Abs(point2D2.z) > 600.0;
				if (flag46)
				{
					this.Position(i, 800.0, (double)(num6 * 700), 200.0);
				}
			}
			else
			{
				bool flag47 = Math.Abs(point2D.z) < 360.0;
				if (flag47)
				{
					GlobalVar.danyuchujie[i] = 0;
				}
			}
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00017050 File Offset: 0x00015250
		public void the_warrior2(int i, int j)
		{
			DebugRecord.ceshi(0, "辣鸡进球");
			GlobalVar.corner[i] = 0;
			GlobalVar.corner_help[i] = 0;
			Point2D point2D = new Point2D();
			Point2D point2D2 = new Point2D();
			Point2D point2D3 = new Point2D();
			Point2D point2D4 = new Point2D();
			double num = 1.0;
			bool flag = j >= 0 && j <= 2;
			if (flag)
			{
				num = num * 38.0 / 58.0;
			}
			else
			{
				bool flag2 = j >= 3 && j <= 6;
				if (flag2)
				{
					num = num * 78.0 / 58.0;
				}
			}
			point2D.x = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.X;
			point2D.z = (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z;
			point2D2.x = (double)GlobalVar.MyTeam.Fishes[i].PositionMm.X;
			point2D2.z = (double)GlobalVar.MyTeam.Fishes[i].PositionMm.Z;
			point2D4.x = (double)((GlobalVar.MyTeam.Fishes[i].PolygonVertices[3].X + GlobalVar.MyTeam.Fishes[i].PolygonVertices[4].X) / 2f);
			point2D4.z = (double)((GlobalVar.MyTeam.Fishes[i].PolygonVertices[3].Z + GlobalVar.MyTeam.Fishes[i].PolygonVertices[4].Z) / 2f);
			double pi = GlobalVar.PI;
			double num2 = (double)GlobalVar.MyTeam.Fishes[i].VelocityDirectionRad;
			double[] array = new double[]
			{
				360.0,
				360.0
			};
			point2D3.x = (double)GlobalVar.MyTeam.Fishes[i].PolygonVertices[0].X;
			point2D3.z = (double)GlobalVar.MyTeam.Fishes[i].PolygonVertices[0].Z;
			double distance = Compute.GetDistance(point2D3.x, point2D3.z, point2D.x, point2D.z);
			double distance2 = Compute.GetDistance(point2D2.x, point2D2.z, point2D.x, point2D.z);
			GlobalVar.test_to_twist_x[i, GlobalVar.cnt] = point2D3.x;
			GlobalVar.test_to_twist_ballx[i, GlobalVar.cnt] = point2D.x;
			GlobalVar.differencial_x[i, GlobalVar.cnt] = Math.Abs(point2D3.x - point2D.x);
			GlobalVar.test_to_twist_z[i, GlobalVar.cnt] = point2D3.z;
			GlobalVar.test_to_twist_ballz[i, GlobalVar.cnt] = point2D.z;
			GlobalVar.differencial_z[i, GlobalVar.cnt] = Math.Abs(point2D3.z - point2D.z);
			GlobalVar.recordfishz[i, GlobalVar.GFY] = Math.Abs(point2D2.z);
			GlobalVar.GFY++;
			GlobalVar.cnt++;
			bool flag3 = GlobalVar.cnt >= 5;
			if (flag3)
			{
				GlobalVar.cnt = 0;
			}
			bool flag4 = GlobalVar.GFY >= 20;
			if (flag4)
			{
				GlobalVar.GFY = 0;
			}
			DebugRecord.ceshi(5, "differencialz", Math.Abs(point2D3.z - point2D.z));
			DebugRecord.ceshi(5, "differencialx", Math.Abs(point2D3.x - point2D.x));
			double num3 = (double)GlobalVar.MyTeam.Fishes[i].VelocityMmPs;
			double num4 = (double)GlobalVar.MyTeam.Fishes[i].AngularVelocityRadPs;
			double num5 = point2D3.x - 444.0 * Math.Cos(num2);
			double num6 = point2D3.z - 444.0 * Math.Sin(num2);
			bool flag5 = point2D.z > 0.0;
			int num7;
			if (flag5)
			{
				num7 = 1;
			}
			else
			{
				num7 = -1;
			}
			bool flag6 = GlobalVar.teamId == 0;
			if (flag6)
			{
				DebugRecord.ceshi(4, "左半场");
				bool flag7 = GlobalVar.danyuchujie[i] == 0;
				if (flag7)
				{
					bool flag8 = distance > 420.0;
					if (flag8)
					{
						this.runway(i, point2D.x - 80.0, point2D.z, 200.0);
						GlobalVar.warrior[i] = 0;
						DebugRecord.ceshi(4, "距离大于420,跑位");
					}
					else
					{
						bool flag9 = point2D.x < -1250.0;
						if (flag9)
						{
							bool flag10 = num2 < 0.0;
							if (flag10)
							{
								this.Position(i, point2D.x - 80.0, point2D.z - 50.0, 50.0);
								this.KeepV(i, 50.0);
								DebugRecord.ceshi(4, "球未进入球门，跑位带球");
							}
							else
							{
								this.Position(i, point2D.x - 80.0, point2D.z + 50.0, 50.0);
								this.KeepV(i, 50.0);
								DebugRecord.ceshi(4, "球未进入球门，跑位带球");
							}
							bool flag11 = GlobalVar.decisions[i].TCode > 10;
							if (flag11)
							{
								GlobalVar.decisions[i].TCode = 10;
							}
							bool flag12 = GlobalVar.decisions[i].TCode < 4;
							if (flag12)
							{
								GlobalVar.decisions[i].TCode = 4;
							}
							bool flag13 = num2 < 0.0 && point2D2.x < point2D.x && point2D3.z < point2D.z - 10.0 && num6 > point2D.z + 58.0 * num;
							if (flag13)
							{
								DebugRecord.ceshi(4, "球在球门外强制顺时针转角");
								GlobalVar.decisions[i].TCode = 10;
								bool flag14 = distance2 > 95.0;
								if (flag14)
								{
									this.KeepV(i, 25.0);
									DebugRecord.ceshi(4, "远距离时强制低速转角");
								}
								else
								{
									this.KeepV(i, 50.0);
									DebugRecord.ceshi(4, "近距离时强制高速转角");
								}
							}
							else
							{
								bool flag15 = num2 > 0.0 && point2D2.x < point2D.x && point2D3.z > point2D.z && num6 < point2D.z - 58.0 * num;
								if (flag15)
								{
									DebugRecord.ceshi(4, "球在球门外强制逆时针转角");
									GlobalVar.decisions[i].TCode = 3;
									this.KeepV(i, 1.0);
								}
							}
						}
						else
						{
							bool flag16 = num2 < 0.0 && distance < 400.0 && ((point2D3.x > point2D.x - 100.0 && point2D3.z < point2D.z - 80.0) || (point2D3.x > point2D.x - 40.0 && point2D3.z < point2D.z - 40.0)) && num5 < point2D.x;
							if (flag16)
							{
								DebugRecord.ceshi(4, "角落处强制顺时针转角");
								this.KeepV(i, 10.0);
								GlobalVar.decisions[i].TCode = 10;
								bool flag17 = num2 > -1.0 * pi / 4.0;
								if (flag17)
								{
									GlobalVar.warrior[i] = -1;
								}
							}
							else
							{
								bool flag18 = num2 > 0.0 && distance < 400.0 && ((point2D3.x > point2D.x - 100.0 && point2D3.z > point2D.z + 80.0) || (point2D3.x > point2D.x - 40.0 && point2D3.z > point2D.z + 40.0)) && num5 < point2D.x;
								if (flag18)
								{
									DebugRecord.ceshi(4, "角落处强制逆时针转角");
									this.KeepV(i, 0.0);
									GlobalVar.decisions[i].TCode = 4;
									bool flag19 = num2 < pi / 4.0;
									if (flag19)
									{
										GlobalVar.warrior[i] = 1;
									}
								}
								else
								{
									bool flag20 = num2 < 0.0;
									if (flag20)
									{
										DebugRecord.ceshi(4, "角落处跑位");
										this.Position(i, point2D.x - 60.0, point2D.z - 50.0, 100.0);
									}
									else
									{
										DebugRecord.ceshi(4, "角落处跑位");
										this.Position(i, point2D.x - 60.0, point2D.z + 50.0, 100.0);
									}
								}
							}
							bool flag21 = GlobalVar.warrior[i] == -1;
							if (flag21)
							{
								DebugRecord.ceshi(4, "角落处顺转逆");
								GlobalVar.decisions[i].TCode = 1;
								this.KeepV(i, 1.0);
								bool flag22 = num2 <= -3.0 * pi / 4.0;
								if (flag22)
								{
									GlobalVar.warrior[i] = 0;
								}
							}
							bool flag23 = GlobalVar.warrior[i] == 1;
							if (flag23)
							{
								DebugRecord.ceshi(4, "角落处逆转顺");
								GlobalVar.decisions[i].TCode = 15;
								this.KeepV(i, 1.0);
								bool flag24 = num2 >= 3.0 * pi / 4.0;
								if (flag24)
								{
									GlobalVar.warrior[i] = 0;
								}
							}
						}
					}
				}
			}
			else
			{
				bool flag25 = GlobalVar.teamId == 1;
				if (flag25)
				{
					DebugRecord.ceshi(4, "右半场");
					bool flag26 = GlobalVar.danyuchujie[i] == 0 || GlobalVar.flag_duqiumen == 1;
					if (flag26)
					{
						bool flag27 = distance > 420.0;
						if (flag27)
						{
							this.runway(i, point2D.x - 80.0, point2D.z, 200.0);
							GlobalVar.warrior[i] = 0;
							DebugRecord.ceshi(4, "距离大于420,跑位");
						}
						else
						{
							bool flag28 = point2D.x < -1250.0;
							if (flag28)
							{
								bool flag29 = num2 < 0.0;
								if (flag29)
								{
									this.Position(i, point2D.x - 80.0, point2D.z - 50.0, 50.0);
								}
								else
								{
									this.Position(i, point2D.x - 80.0, point2D.z + 50.0, 50.0);
								}
								DebugRecord.ceshi(4, "球未进入球门，跑位带球");
								bool flag30 = num2 > 0.0 && point2D2.x < point2D.x && point2D3.z > point2D.z + 10.0 && num6 < point2D.z - 58.0 * num;
								if (flag30)
								{
									DebugRecord.ceshi(4, "球在球门外强制逆时针转角");
									GlobalVar.decisions[i].TCode = 4;
									bool flag31 = distance2 > 95.0;
									if (flag31)
									{
										this.KeepV(i, 25.0);
										DebugRecord.ceshi(4, "远距离时强制低速转角");
									}
									else
									{
										this.KeepV(i, 50.0);
										DebugRecord.ceshi(4, "近距离时强制高速转角");
									}
								}
							}
							else
							{
								bool flag32 = num2 < 0.0 && distance < 400.0 && ((point2D3.x > point2D.x - 100.0 && point2D3.z < point2D.z - 80.0) || (point2D3.x > point2D.x - 40.0 && point2D3.z < point2D.z - 40.0)) && num5 < point2D.x;
								if (flag32)
								{
									DebugRecord.ceshi(4, "角落处强制顺时针转角");
									this.KeepV(i, 10.0);
									GlobalVar.decisions[i].TCode = 11;
									bool flag33 = num2 > -1.0 * pi / 4.0;
									if (flag33)
									{
										GlobalVar.warrior[i] = -1;
									}
								}
								else
								{
									bool flag34 = num2 > 0.0 && distance < 400.0 && point2D3.x > point2D.x - 100.0 && point2D3.z > point2D.z && num5 < point2D.x;
									if (flag34)
									{
										DebugRecord.ceshi(4, "角落处强制逆时针转角");
										this.KeepV(i, 25.0);
										GlobalVar.decisions[i].TCode = 3;
										bool flag35 = num2 < pi / 4.0;
										if (flag35)
										{
											GlobalVar.warrior[i] = 1;
										}
									}
									else
									{
										bool flag36 = num2 < 0.0;
										if (flag36)
										{
											DebugRecord.ceshi(4, "角落处跑位");
											this.Position(i, point2D.x - 60.0, point2D.z - 50.0, 100.0);
										}
										else
										{
											DebugRecord.ceshi(4, "角落处跑位");
											this.Position(i, point2D.x - 60.0, point2D.z + 50.0, 100.0);
										}
									}
								}
								bool flag37 = GlobalVar.warrior[i] == -1;
								if (flag37)
								{
									DebugRecord.ceshi(4, "角落处顺转逆");
									GlobalVar.decisions[i].TCode = 0;
									this.KeepV(i, 0.0);
									bool flag38 = num2 <= -3.0 * pi / 4.0;
									if (flag38)
									{
										GlobalVar.warrior[i] = 0;
									}
								}
								bool flag39 = GlobalVar.warrior[i] == 1;
								if (flag39)
								{
									DebugRecord.ceshi(4, "角落处逆转顺");
									GlobalVar.decisions[i].TCode = 15;
									this.KeepV(i, 0.0);
									bool flag40 = num2 >= 3.0 * pi / 4.0;
									if (flag40)
									{
										GlobalVar.warrior[i] = 0;
									}
								}
							}
						}
					}
				}
			}
			bool flag41 = GlobalVar.flag_duqiumen != 1;
			if (flag41)
			{
				bool flag42 = (point2D.x < -1350.0 && point2D.z < -450.0 && point2D.z > -720.0) || (point2D.x < -1152.0 && point2D.z < -507.0 && point2D.z > -720.0);
				if (flag42)
				{
					DebugRecord.ceshi(4, "球略微出了上边框");
					GlobalVar.danyuchujie[i] = 1;
					bool flag43 = point2D2.z > point2D.z && point2D4.z > point2D.z;
					if (flag43)
					{
						bool flag44 = GlobalVar.teamId == 0;
						if (flag44)
						{
							DebugRecord.ceshi(4, "左半场球出了上边框向右上边跑位");
							this.Position(i, point2D.x + 70.0 * num, point2D.z - 70.0, 90.0);
						}
						else
						{
							bool flag45 = GlobalVar.teamId == 1;
							if (flag45)
							{
								DebugRecord.ceshi(4, "右半场球出了下边框向左下边跑位");
								this.Position(i, point2D.x + 70.0, point2D.z - 100.0, 90.0);
							}
						}
					}
					else
					{
						DebugRecord.ceshi(4, "球出了上边框调用test1");
						this.Dribblehometest1(i, j);
					}
				}
				else
				{
					bool flag46 = point2D.x < -1152.0 && point2D.z > 507.0 && point2D.z < 720.0;
					if (flag46)
					{
						DebugRecord.ceshi(4, "球略微出了下边框");
						GlobalVar.danyuchujie[i] = 1;
						bool flag47 = point2D2.z < point2D.z && point2D4.z < point2D.z;
						if (flag47)
						{
							DebugRecord.ceshi(4, "球出了下边框向球右下方跑位");
							this.Position(i, point2D.x + 70.0, point2D.z + 70.0, 50.0);
						}
						else
						{
							DebugRecord.ceshi(4, "球出了下边框调用test1");
							this.Dribblehometest1(i, j);
						}
					}
					else
					{
						bool flag48 = GlobalVar.danyuchujie[i] == 1;
						if (flag48)
						{
							this.Dribblehometest1(i, j);
							DebugRecord.ceshi(4, "其他情况的球出界用test1处理");
						}
						else
						{
							bool flag49 = point2D.x >= -950.0 || Math.Abs(point2D.z) >= 507.0;
							if (flag49)
							{
								this.Dribblehometest1(i, j);
								DebugRecord.ceshi(4, "球不在球门内的情况用test1处理");
							}
						}
					}
				}
				bool flag50 = point2D2.x > -920.0 && this.whether_in_myforbiddenareasmall((double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z);
				if (flag50)
				{
					GlobalVar.BaAction.Position(i, -1100.0, (double)(num7 * 700), 200.0);
					DebugRecord.ceshi(0, "球在禁区但是鱼不在禁区就让鱼跑位");
				}
				bool flag51 = this.whether_in_oppforbiddenareabig(point2D2.x, point2D2.z) && !this.whether_in_oppforbiddenareabig(point2D.x, point2D.z);
				if (flag51)
				{
					bool flag52 = i == 0;
					int num8;
					if (flag52)
					{
						num8 = 1;
					}
					else
					{
						num8 = -1;
					}
					this.Position(i, 1350.0, (double)(num8 * 700), 200.0);
					bool flag53 = Math.Abs(point2D2.z) > 600.0;
					if (flag53)
					{
						this.Position(i, 800.0, (double)(num8 * 700), 200.0);
					}
				}
				else
				{
					int k;
					for (k = 0; k <= 19; k++)
					{
						bool flag54 = GlobalVar.recordfishz[i, k] < 360.0;
						if (flag54)
						{
							break;
						}
					}
					bool flag55 = k == 20;
					if (flag55)
					{
						array[i] = 360.0;
					}
					else
					{
						array[i] = 450.0;
					}
					DebugRecord.ceshi(0, "border", array[i]);
					bool flag56 = Math.Abs(point2D.z) < array[i];
					if (flag56)
					{
						GlobalVar.danyuchujie[i] = 0;
					}
					for (k = 0; k <= 4; k++)
					{
						bool flag57 = GlobalVar.differencial_x[i, k] > 40.0 || GlobalVar.differencial_z[i, k] > 65.0;
						if (flag57)
						{
							break;
						}
					}
					bool flag58 = k == 5;
					if (flag58)
					{
						this.KeepV(i, 10.0);
						bool flag59 = num2 <= 0.0;
						if (flag59)
						{
							GlobalVar.decisions[i].TCode = 0;
						}
						else
						{
							GlobalVar.decisions[i].TCode = 7;
						}
						DebugRecord.ceshi(0, "避免一直顶着球顶出界");
					}
				}
			}
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00018548 File Offset: 0x00016748
		public bool whether_in_oppforbiddenarea_reduce(double location_x, double location_z)
		{
			return location_x > 952.0 && Math.Abs(location_z) < 507.0;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x00018584 File Offset: 0x00016784
		public int num_of_ball_in_oppmiddle(bool whether_include_forbiddenarea, bool score_or_numofball)
		{
			double[,] array = new double[9, 2];
			for (int i = 0; i < 9; i++)
			{
				array[i, 0] = (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X;
				array[i, 1] = (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z;
			}
			int num = 0;
			int num2 = 0;
			for (int j = 0; j < 9; j++)
			{
				bool flag = this.whether_in_oppforbiddenarea_reducemiddle(array[j, 0], array[j, 1]) && !this.whether_in_opphome(array[j, 0], array[j, 1]);
				if (flag)
				{
					num++;
				}
				bool flag2 = this.whether_in_opphome(array[j, 0], array[j, 1]);
				if (flag2)
				{
					num2++;
				}
			}
			if (score_or_numofball)
			{
				for (int k = 0; k < 9; k++)
				{
					bool flag3 = this.whether_in_oppforbiddenarea_reducemiddle(array[k, 0], array[k, 1]);
					if (flag3)
					{
						bool flag4 = GlobalVar.rightScore[k] == 0;
						if (flag4)
						{
							bool flag5 = k == 0 || k == 1 || k == 2;
							if (flag5)
							{
								num += 2;
							}
							else
							{
								bool flag6 = k == 7 || k == 8;
								if (flag6)
								{
									num++;
								}
							}
						}
						bool flag7 = this.whether_in_opphome(array[k, 0], array[k, 1]) || GlobalVar.rightScore[k] == 1;
						if (flag7)
						{
							bool flag8 = this.whether_in_opphome(array[k, 0], array[k, 1]);
							if (flag8)
							{
								bool flag9 = k == 0 || k == 1 || k == 2;
								if (flag9)
								{
									num2 += 2;
								}
								else
								{
									bool flag10 = k == 7 || k == 8;
									if (flag10)
									{
										num2++;
									}
								}
							}
							else
							{
								bool flag11 = GlobalVar.rightScore[k] == 1 && !this.whether_in_opphome(array[k, 0], array[k, 1]);
								if (flag11)
								{
									bool flag12 = k == 0 || k == 1 || k == 2;
									if (flag12)
									{
										num2 += 3;
									}
									else
									{
										bool flag13 = k == 7 || k == 8;
										if (flag13)
										{
											num2 += 2;
										}
										else
										{
											num2++;
										}
									}
								}
							}
						}
					}
				}
			}
			int result;
			if (whether_include_forbiddenarea)
			{
				result = num;
			}
			else
			{
				result = num2;
			}
			return result;
		}

		// Token: 0x0600004D RID: 77 RVA: 0x00018824 File Offset: 0x00016A24
		public bool whether_in_oppforbiddenarea_reducemiddle(double location_x, double location_z)
		{
			return location_x > 952.0 && Math.Abs(location_z) < 700.0;
		}

		// Token: 0x0600004E RID: 78 RVA: 0x00018860 File Offset: 0x00016A60
		public int num_of_ball_in_oppsmall(bool whether_include_forbiddenarea, bool score_or_numofball)
		{
			double[,] array = new double[9, 2];
			for (int i = 0; i < 9; i++)
			{
				array[i, 0] = (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.X;
				array[i, 1] = (double)GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z;
			}
			int num = 0;
			int num2 = 0;
			for (int j = 0; j < 9; j++)
			{
				bool flag = this.whether_in_oppforbiddenarea_reduce(array[j, 0], array[j, 1]) && !this.whether_in_opphome(array[j, 0], array[j, 1]);
				if (flag)
				{
					num++;
				}
				bool flag2 = this.whether_in_opphome(array[j, 0], array[j, 1]);
				if (flag2)
				{
					num2++;
				}
			}
			if (score_or_numofball)
			{
				for (int k = 0; k < 9; k++)
				{
					bool flag3 = this.whether_in_oppforbiddenarea_reduce(array[k, 0], array[k, 1]);
					if (flag3)
					{
						bool flag4 = GlobalVar.rightScore[k] == 0;
						if (flag4)
						{
							bool flag5 = k == 0 || k == 1 || k == 2;
							if (flag5)
							{
								num += 2;
							}
							else
							{
								bool flag6 = k == 7 || k == 8;
								if (flag6)
								{
									num++;
								}
							}
						}
						bool flag7 = this.whether_in_opphome(array[k, 0], array[k, 1]) || GlobalVar.rightScore[k] == 1;
						if (flag7)
						{
							bool flag8 = this.whether_in_opphome(array[k, 0], array[k, 1]);
							if (flag8)
							{
								bool flag9 = k == 0 || k == 1 || k == 2;
								if (flag9)
								{
									num2 += 2;
								}
								else
								{
									bool flag10 = k == 7 || k == 8;
									if (flag10)
									{
										num2++;
									}
								}
							}
							else
							{
								bool flag11 = GlobalVar.rightScore[k] == 1 && !this.whether_in_opphome(array[k, 0], array[k, 1]);
								if (flag11)
								{
									bool flag12 = k == 0 || k == 1 || k == 2;
									if (flag12)
									{
										num2 += 3;
									}
									else
									{
										bool flag13 = k == 7 || k == 8;
										if (flag13)
										{
											num2 += 2;
										}
										else
										{
											num2++;
										}
									}
								}
							}
						}
					}
				}
			}
			int result;
			if (whether_include_forbiddenarea)
			{
				result = num;
			}
			else
			{
				result = num2;
			}
			return result;
		}

		// Token: 0x0600004F RID: 79 RVA: 0x00018B00 File Offset: 0x00016D00
		public void FantasticBatter(int fish, int ball)
		{
			double num = (double)GlobalVar.MyTeam.Fishes[fish].BodyLength;
			double num2 = (double)GlobalVar.MyTeam.Fishes[fish].BodyDirectionRad;
			double num3 = (double)GlobalVar.MyTeam.Fishes[fish].PositionMm.X;
			double num4 = (double)GlobalVar.MyTeam.Fishes[fish].PositionMm.Z;
			double num5 = (double)GlobalVar.MyTeam.Fishes[fish].PolygonVertices[0].X;
			double num6 = (double)GlobalVar.MyTeam.Fishes[fish].PolygonVertices[0].Z;
			double num7 = (double)GlobalVar.mission.EnvRef.Balls[ball].PositionMm.X;
			double num8 = (double)GlobalVar.mission.EnvRef.Balls[ball].PositionMm.Z;
			double point1_x = (double)((GlobalVar.MyTeam.Fishes[fish].PolygonVertices[3].X + GlobalVar.MyTeam.Fishes[fish].PolygonVertices[4].X) / 2f);
			double num9 = (double)((GlobalVar.MyTeam.Fishes[fish].PolygonVertices[3].Z + GlobalVar.MyTeam.Fishes[fish].PolygonVertices[4].X) / 2f);
			double x = num5 + num * Math.Cos(Compute.FormatAngleRad(num2 + GlobalVar.PI));
			double num10 = num6 + num * Math.Sin(Compute.FormatAngleRad(num2 + GlobalVar.PI));
			double num11 = num4 + num2 / Math.Abs(num2) * 80.0;
			double num12 = num4 - num2 / Math.Abs(num2) * 342.0;
			double num13 = num4 - num2 / Math.Abs(num2) * 80.0;
			double angleRad = Compute.GetAngleRad(num5, num6, num7, num8);
			double angleRad2 = Compute.GetAngleRad(num3, num4, num7, num8);
			double num14 = Math.Abs(-978.0 - num7);
			double dx = -879.0;
			double dz = -507.0;
			double dx2 = -879.0;
			double dz2 = 507.0;
			double distance = Compute.GetDistance(num3, num4, num7, num8);
			double num15 = Compute.FormatAngleRad(Compute.GetAngleRad(point1_x, num9, num7, num8));
			double num16 = Compute.FormatAngleRad(Compute.GetAngleRad(num5, num6, num7, num8));
			double num17 = Compute.FormatAngleRad(num16 - num2);
			double num18 = Math.Tan(num2);
			double num19 = num4 - num18 * num3;
			bool flag = num8 > num4;
			double num20;
			if (flag)
			{
				num20 = 75.0;
			}
			else
			{
				num20 = 100.0;
			}
			bool flag2 = num8 > num4;
			double num21;
			if (flag2)
			{
				num21 = num8 + num20;
			}
			else
			{
				num21 = num8 - num20;
			}
			double dx3 = num7 - 80.0;
			bool flag3 = Compute.GetDistance(num5, num6, num7, num8) > 100.0;
			double dx4;
			double dz3;
			if (flag3)
			{
				dx4 = num7 - 88.0;
				dz3 = num8 + Math.Abs(num4 - num8) / (num4 - num8) * 58.0;
			}
			else
			{
				dx4 = num7 - 60.0;
				dz3 = num8 - Math.Abs(num4 - num8) / (num4 - num8) * 58.0;
			}
			bool flag4 = num7 > -1200.0;
			if (flag4)
			{
				bool flag5 = num3 > num7;
				if (flag5)
				{
					bool flag6 = (num9 - num8 > 0.0 && num6 - num8 < 0.0 && num8 - num18 * num7 - num19 > 0.0 && num2 < 0.0) || (num9 - num8 < 0.0 && num6 - num8 > 0.0 && num8 - num18 * num7 - num19 < 0.0 && num2 > 0.0);
					if (flag6)
					{
						this.KeepV(fish, 10.0);
						bool flag7 = num2 > 0.0;
						if (flag7)
						{
							GlobalVar.decisions[fish].TCode = 11;
						}
						else
						{
							GlobalVar.decisions[fish].TCode = 3;
						}
						DebugRecord.ceshi(0, "球前甩尾1");
						DebugRecord.ceshi(0, "cnt1", (float)GlobalVar.cnt1);
					}
					else
					{
						this.position3(fish, dx3, num21, 20.0);
						DebugRecord.ceshi(0, "跑位");
					}
				}
				else
				{
					bool flag8 = (num11 - num8) * (num12 - num8) > 0.0;
					if (flag8)
					{
						this.position3(fish, dx3, num21, 10.0);
						DebugRecord.ceshi(0, "跑到正左边");
					}
					else
					{
						bool flag9 = (num11 - num8) * (num13 - num8) < 0.0;
						if (flag9)
						{
							this.KeepV(fish, 10.0);
							DebugRecord.ceshi(0, "猛转头之保持角度");
							DebugRecord.ceshi(0, "bodyrad", num2);
							DebugRecord.ceshi(0, "判断条件", Math.Abs(Math.Abs(num2) - GlobalVar.PI / 4.0));
							bool flag10 = num2 > 0.0;
							if (flag10)
							{
								GlobalVar.decisions[fish].TCode = 2;
							}
							else
							{
								GlobalVar.decisions[fish].TCode = 12;
							}
							DebugRecord.ceshi(0, "猛转头之强制赋速度档位");
							DebugRecord.ceshi(0, "猛转头");
						}
						else
						{
							bool flag11 = Math.Abs(num11 - num8) < 150.0;
							if (flag11)
							{
								double num22 = num8 + num2 / Math.Abs(num2) * 125.0;
								this.position3(fish, dx3, num22, 0.0);
								DebugRecord.ceshi(0, "跑到前面甩甩尾");
								DebugRecord.ceshi(0, "zball", num8);
								DebugRecord.ceshi(0, "ztwist", num22);
							}
							else
							{
								this.KeepV(fish, 10.0);
								bool flag12 = num2 > 0.0;
								if (flag12)
								{
									GlobalVar.decisions[fish].TCode = 11;
								}
								else
								{
									GlobalVar.decisions[fish].TCode = 3;
								}
								DebugRecord.ceshi(0, "强制赋角速度转角");
								DebugRecord.ceshi(0, "执行甩尾动作");
							}
						}
					}
				}
			}
			else
			{
				bool flag13 = num7 > -1420.0 && num7 < -1200.0;
				if (flag13)
				{
					bool flag14 = num3 > num7;
					if (flag14)
					{
						bool flag15 = (num9 - num8 > 0.0 && num6 - num8 < 0.0 && num8 - num18 * num7 - num19 > 0.0 && num2 < 0.0) || (num9 - num8 < 0.0 && num6 - num8 > 0.0 && num8 - num18 * num7 - num19 < 0.0 && num2 > 0.0);
						if (flag15)
						{
							this.KeepV(fish, 10.0);
							bool flag16 = num2 > 0.0;
							if (flag16)
							{
								GlobalVar.decisions[fish].TCode = 12;
							}
							else
							{
								GlobalVar.decisions[fish].TCode = 2;
							}
							DebugRecord.ceshi(0, "球前甩尾2");
							DebugRecord.ceshi(0, "cnt2", (float)GlobalVar.cnt2);
						}
						else
						{
							bool flag17 = num6 > num8;
							if (flag17)
							{
								this.Dribble(fish, ball, dx, dz);
							}
							else
							{
								this.Dribble(fish, ball, dx2, dz2);
							}
							DebugRecord.ceshi(0, "跑到左方");
							DebugRecord.ceshi(0, "△tailandball", num9 - num8);
							DebugRecord.ceshi(0, "△headandball", num6 - num8);
							DebugRecord.ceshi(0, "△tailtoballand body", num15 - num2);
						}
					}
					else
					{
						bool flag18 = (num11 - num8) * (num12 - num8) > 0.0;
						if (flag18)
						{
							this.position3(fish, dx3, num21, 20.0);
							bool flag19 = GlobalVar.decisions[fish].TCode > 10;
							if (flag19)
							{
								GlobalVar.decisions[fish].TCode = 10;
							}
							bool flag20 = GlobalVar.decisions[fish].TCode < 4;
							if (flag20)
							{
								GlobalVar.decisions[fish].TCode = 4;
							}
							DebugRecord.ceshi(0, "跑到正左方2");
							DebugRecord.ceshi(0, "xmiddle", x);
							DebugRecord.ceshi(0, "zvh", num11);
							DebugRecord.ceshi(0, "zvt", num12);
							DebugRecord.ceshi(0, "zvm", num13);
							DebugRecord.ceshi(0, "zRun", num21);
						}
						else
						{
							bool flag21 = Math.Abs(num2) - GlobalVar.PI / 3.0 > GlobalVar.PI / 18.0;
							if (flag21)
							{
								bool flag22 = num2 > 0.0;
								if (flag22)
								{
									this.KeepV(fish, 10.0);
									this.Angle(fish, GlobalVar.PI / 4.0);
									bool flag23 = GlobalVar.decisions[fish].TCode > 10;
									if (flag23)
									{
										GlobalVar.decisions[fish].TCode = 10;
									}
									bool flag24 = GlobalVar.decisions[fish].TCode < 4;
									if (flag24)
									{
										GlobalVar.decisions[fish].TCode = 4;
									}
								}
								else
								{
									this.KeepV(fish, 10.0);
									this.Angle(fish, -GlobalVar.PI / 4.0);
									bool flag25 = GlobalVar.decisions[fish].TCode > 10;
									if (flag25)
									{
										GlobalVar.decisions[fish].TCode = 10;
									}
									bool flag26 = GlobalVar.decisions[fish].TCode < 4;
									if (flag26)
									{
										GlobalVar.decisions[fish].TCode = 4;
									}
								}
								DebugRecord.ceshi(0, "往右转");
							}
							else
							{
								bool flag27 = Math.Abs(num2) - GlobalVar.PI / 3.0 < -GlobalVar.PI / 18.0;
								if (flag27)
								{
									bool flag28 = num2 > 0.0;
									if (flag28)
									{
										this.KeepV(fish, 10.0);
										this.Angle(fish, GlobalVar.PI / 2.0);
										bool flag29 = GlobalVar.decisions[fish].TCode > 11;
										if (flag29)
										{
											GlobalVar.decisions[fish].TCode = 11;
										}
										bool flag30 = GlobalVar.decisions[fish].TCode < 3;
										if (flag30)
										{
											GlobalVar.decisions[fish].TCode = 3;
										}
									}
									else
									{
										this.KeepV(fish, 10.0);
										this.Angle(fish, -GlobalVar.PI / 2.0);
										bool flag31 = GlobalVar.decisions[fish].TCode > 11;
										if (flag31)
										{
											GlobalVar.decisions[fish].TCode = 11;
										}
										bool flag32 = GlobalVar.decisions[fish].TCode < 3;
										if (flag32)
										{
											GlobalVar.decisions[fish].TCode = 3;
										}
									}
									DebugRecord.ceshi(0, "转回去等着往右转");
								}
								else
								{
									bool flag33 = num2 > 0.0;
									if (flag33)
									{
										GlobalVar.decisions[fish].TCode = 3;
									}
									else
									{
										GlobalVar.decisions[fish].TCode = 11;
									}
								}
							}
						}
					}
				}
				else
				{
					this.position3(fish, dx4, dz3, 0.0);
					DebugRecord.ceshi(0, "走到边界");
					bool flag34 = Math.Abs(num5 - num7) < 30.0;
					if (flag34)
					{
						GlobalVar.decisions[fish].VCode = 1;
						bool flag35 = num2 > 0.0;
						if (flag35)
						{
							GlobalVar.decisions[fish].TCode = 12;
						}
						else
						{
							GlobalVar.decisions[fish].TCode = 2;
						}
					}
				}
			}
			bool flag36 = GlobalVar.decisions[fish].TCode != 7 && GlobalVar.decisions[fish].VCode == 0;
			if (flag36)
			{
				GlobalVar.decisions[fish].VCode = 1;
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x000197EC File Offset: 0x000179EC
		public void jinqiu(int whichfish, int whichball)
		{
			double num = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
			double num2 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
			double num3 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].X;
			double num4 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
			double num5 = (double)GlobalVar.MyTeam.Fishes[whichfish].VelocityDirectionRad;
			double num6 = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.X;
			double num7 = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.Z;
			double num8 = (double)GlobalVar.mission.EnvRef.Balls[whichball].RadiusMm;
			double distance = Compute.GetDistance(num, num2, num6, num7);
			double distance2 = Compute.GetDistance(num3, num4, num6, num7);
			double num9 = num3 - 444.0 * Math.Cos(num5);
			double num10 = num4 - 444.0 * Math.Sin(num5);
			bool flag = num6 + 1152.0 > -98.0;
			if (flag)
			{
				bool flag2 = num5 < 0.0 && distance2 < 400.0 && ((num3 > num6 - 100.0 && num4 < num7 - 80.0) || (num3 > num6 - 40.0 && num4 < num7 - 40.0)) && num9 < num6;
				if (flag2)
				{
					this.KeepV(whichfish, 10.0);
					GlobalVar.decisions[whichfish].TCode = 12;
					bool flag3 = num5 > -0.78539816339744828;
					if (flag3)
					{
						GlobalVar.warrior[whichfish] = -1;
					}
				}
				else
				{
					bool flag4 = num5 > 0.0 && distance2 < 400.0 && ((num3 > num6 - 100.0 && num4 > num7 + 80.0) || (num3 > num6 - 40.0 && num4 > num7 + 40.0)) && num9 < num6;
					if (flag4)
					{
						this.KeepV(whichfish, 0.0);
						GlobalVar.decisions[whichfish].TCode = 1;
						bool flag5 = num5 < 0.78539816339744828;
						if (flag5)
						{
							GlobalVar.warrior[whichfish] = 1;
						}
					}
					else
					{
						bool flag6 = num5 < 0.0;
						if (flag6)
						{
							this.Position(whichfish, num6 - 60.0, num7 - 50.0, 100.0);
						}
						else
						{
							this.Position(whichfish, num6 - 60.0, num7 + 50.0, 100.0);
						}
					}
				}
				bool flag7 = GlobalVar.warrior[whichfish] == -1;
				if (flag7)
				{
					GlobalVar.decisions[whichfish].TCode = 1;
					this.KeepV(whichfish, 0.0);
					bool flag8 = num5 <= -2.3561944901923448;
					if (flag8)
					{
						GlobalVar.warrior[whichfish] = 0;
					}
				}
				bool flag9 = GlobalVar.warrior[whichfish] == 1;
				if (flag9)
				{
					GlobalVar.decisions[whichfish].TCode = 15;
					this.KeepV(whichfish, 0.0);
					bool flag10 = num5 >= 2.3561944901923448;
					if (flag10)
					{
						GlobalVar.warrior[whichfish] = 0;
					}
				}
			}
			else
			{
				double angleRad = Compute.GetAngleRad(num, num2, num6, num7);
				this.position3(whichfish, num6 - 60.0, num7, 200.0);
				bool flag11 = num2 < num7;
				if (flag11)
				{
					this.position3(whichfish, num6 + 100.0, num7 + 100.0, 200.0);
				}
				DebugRecord.ceshi(1, "d", Compute.GetDistance(num, num2, num6, num7));
				bool flag12 = Compute.GetDistance(num, num2, num6, num7) < 150.0;
				if (flag12)
				{
					bool flag13 = num > num6;
					if (flag13)
					{
						this.position3(whichfish, num6 - num8, num7, 100.0);
					}
					else
					{
						bool flag14 = num5 < 0.0;
						if (flag14)
						{
							this.position3(whichfish, num6, num7 - 150.0, 110.0);
							this.Angle(whichfish, -1.5707963267948966);
						}
						bool flag15 = num5 > 0.0;
						if (flag15)
						{
							this.position3(whichfish, num6, num7 + 150.0, 50.0);
							this.Angle(whichfish, 1.5707963267948966);
						}
						bool flag16 = Math.Abs(num5 + 1.5707963267948966) < 0.5;
						if (flag16)
						{
							DebugRecord.ceshi(1, "vdirect", num5);
							this.position3(whichfish, num6, num7 - 80.0, 90.0);
							this.Angle(whichfish, num5 + 0.78539816339744828);
							bool flag17 = GlobalVar.decisions[whichfish].TCode >= 10;
							if (flag17)
							{
								GlobalVar.decisions[whichfish].TCode = 8;
							}
						}
						bool flag18 = Math.Abs(num5 - 1.5707963267948966) < 0.5;
						if (flag18)
						{
							DebugRecord.ceshi(1, "转角");
							this.position3(whichfish, num6, num7 + 10.0, 30.0);
							this.Angle(whichfish, num5 - 0.78539816339744828);
							bool flag19 = GlobalVar.decisions[whichfish].TCode <= 4;
							if (flag19)
							{
								GlobalVar.decisions[whichfish].TCode = 6;
							}
						}
						DebugRecord.ceshi(1, "tcode", (float)GlobalVar.decisions[whichfish].TCode);
					}
				}
			}
		}

		// Token: 0x06000051 RID: 81 RVA: 0x00019E54 File Offset: 0x00018054
		public void Take_Ball_Back(int whichfish, int whichball)
		{
			double num = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.X;
			double num2 = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.Z;
			double x = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
			double z = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
			double num3 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[whichfish].X;
			double num4 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[whichfish].Z;
			double num5 = (double)GlobalVar.MyTeam.Fishes[whichfish].BodyDirectionRad;
			bool flag = whichfish == 0;
			int num6;
			if (flag)
			{
				num6 = 1;
			}
			else
			{
				num6 = -1;
			}
			bool flag2 = GlobalVar.Paishu > 3000 || GlobalVar.final == 1;
			if (flag2)
			{
				bool flag3 = num2 > 500.0;
				if (flag3)
				{
					num6 = 1;
				}
				else
				{
					bool flag4 = num2 < -500.0;
					if (flag4)
					{
						num6 = -1;
					}
				}
			}
			else
			{
				bool flag5 = GlobalVar.Paishu > 1500 || GlobalVar.final == 1;
				if (flag5)
				{
					bool flag6 = num2 > 700.0;
					if (flag6)
					{
						num6 = 1;
					}
					else
					{
						bool flag7 = num2 < -700.0;
						if (flag7)
						{
							num6 = -1;
						}
					}
				}
			}
			bool flag8 = num > -1300.0;
			if (flag8)
			{
				bool flag9 = whichfish == 1;
				if (flag9)
				{
					bool flag10 = num > -952.0;
					if (flag10)
					{
						this.Dribble(whichfish, whichball, -980.0, (double)num6 * 645.0);
					}
					else
					{
						bool flag11 = num > -1150.0;
						if (flag11)
						{
							this.Dribble(whichfish, whichball, -1230.0, (double)num6 * 500.0);
						}
						else
						{
							bool flag12 = Math.Abs(num2) < 300.0;
							if (flag12)
							{
								this.Dribble(whichfish, whichball, -1180.0, (double)num6 * 0.0);
							}
							else
							{
								this.Dribble(whichfish, whichball, -1180.0, (double)(-(double)num6) * 300.0);
							}
						}
					}
				}
				else
				{
					bool flag13 = GlobalVar.teamId == 1;
					if (flag13)
					{
						bool flag14 = num > -900.0;
						if (flag14)
						{
							this.Dribble(whichfish, whichball, -980.0, (double)num6 * 700.0);
						}
						else
						{
							bool flag15 = num > -1100.0;
							if (flag15)
							{
								this.Dribble(whichfish, whichball, -1500.0, (double)num6 * 600.0);
								this.KeepV(whichfish, 100.0);
							}
							else
							{
								this.Dribble(whichfish, whichball, -1500.0, (double)num6 * 520.0);
								this.KeepV(whichfish, 100.0);
							}
						}
					}
					else
					{
						bool flag16 = num > -952.0;
						if (flag16)
						{
							this.Dribble(whichfish, whichball, -980.0, (double)num6 * 665.0);
						}
						else
						{
							bool flag17 = num > -1150.0;
							if (flag17)
							{
								this.Dribble(whichfish, whichball, -1500.0, (double)num6 * 600.0);
								this.KeepV(whichfish, 100.0);
							}
							else
							{
								this.Dribble(whichfish, whichball, -1500.0, (double)num6 * 520.0);
								this.KeepV(whichfish, 100.0);
							}
						}
					}
				}
			}
			else
			{
				bool flag18 = whichfish == 0;
				if (flag18)
				{
					bool flag19 = num > -1380.0;
					if (flag19)
					{
						this.Dribble(whichfish, whichball, -1500.0, num2 - 35.0);
					}
					else
					{
						bool flag20 = Compute.GetDistance(x, z, num, num2) > 150.0;
						if (flag20)
						{
							this.Position(whichfish, num, num2 + (double)(num6 * 60), 100.0);
						}
						else
						{
							this.Dribblehometest3(whichfish, whichball);
						}
					}
				}
				else
				{
					bool flag21 = whichfish == 1;
					if (flag21)
					{
						bool flag22 = num > -1380.0;
						if (flag22)
						{
							this.Dribble(whichfish, whichball, -1500.0, num2 + 35.0);
						}
						else
						{
							bool flag23 = Compute.GetDistance(x, z, num, num2) > 150.0;
							if (flag23)
							{
								this.Position(whichfish, num, num2 + (double)(num6 * 60), 100.0);
							}
							else
							{
								this.Dribblehometest3(whichfish, whichball);
							}
						}
					}
				}
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0001A358 File Offset: 0x00018558
		public void BackAgain(int whichfish, int whichball)
		{
			int i = 6;
			bool flag = whichfish == 0;
			if (flag)
			{
				i = 6;
			}
			bool flag2 = whichfish == 1;
			if (flag2)
			{
				i = 10;
			}
			double num = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.X;
			double num2 = (double)GlobalVar.mission.EnvRef.Balls[whichball].PositionMm.Z;
			double num3 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.X;
			double num4 = (double)GlobalVar.MyTeam.Fishes[whichfish].PositionMm.Z;
			double num5 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].X;
			double num6 = (double)GlobalVar.MyTeam.Fishes[whichfish].PolygonVertices[0].Z;
			double num7 = (double)GlobalVar.MyTeam.Fishes[whichfish].VelocityMmPs;
			double num8 = (double)GlobalVar.MyTeam.Fishes[whichfish].VelocityDirectionRad;
			double pi = GlobalVar.PI;
			bool flag3 = whichfish == 0;
			int num9;
			if (flag3)
			{
				num9 = 1;
			}
			else
			{
				num9 = -1;
			}
			bool flag4 = GlobalVar.Paishu > 3000 || GlobalVar.final == 1;
			if (flag4)
			{
				bool flag5 = num2 > 300.0;
				if (flag5)
				{
					num9 = 1;
				}
				else
				{
					bool flag6 = num2 < -300.0;
					if (flag6)
					{
						num9 = -1;
					}
				}
			}
			else
			{
				bool flag7 = GlobalVar.Paishu > 1500 || GlobalVar.final == 1;
				if (flag7)
				{
					bool flag8 = num2 > 700.0;
					if (flag8)
					{
						num9 = 1;
					}
					else
					{
						bool flag9 = num2 < -700.0;
						if (flag9)
						{
							num9 = -1;
						}
					}
				}
			}
			double num10 = Math.Abs(num6 - 1000.0);
			double num11 = (double)GlobalVar.Fish_length;
			double num12 = 2.0 - 3.0 * pi / 2.0;
			bool flag10 = num + 1500.0 > 80.0;
			if (flag10)
			{
				this.Dribble(whichfish, whichball, -1500.0, num2 - (double)(num9 * 50));
			}
			else
			{
				bool flag11 = num10 < num11;
				double num13;
				if (flag11)
				{
					num13 = Math.Acos(num10 / num11);
				}
				else
				{
					num13 = pi - 2.0;
				}
				bool flag12 = (double)num9 * num12 > (double)num9 * (-pi / 2.0 - num13);
				if (flag12)
				{
					num12 = -pi / 2.0 - num13;
				}
				int num14 = this.TransfromAngletoTCode((double)num9 * num12 - num8);
				int num15 = Math.Abs(7 - num14);
				bool flag13 = (double)num9 * num8 > 0.0 || (double)num9 * num8 < -(pi - 0.3);
				if (flag13)
				{
					bool flag14 = (double)num9 * num8 > 0.0;
					if (flag14)
					{
						GlobalVar.decisions[whichfish].VCode = 4;
						GlobalVar.decisions[whichfish].TCode = 7 + num9 * 4;
					}
					else
					{
						GlobalVar.decisions[whichfish].VCode = 4;
						GlobalVar.decisions[whichfish].TCode = 7 + num9 * 4;
					}
					DebugRecord.ceshi(i, "在左边界的时候鱼体方向尚未达到要求，线速度为4，角速度为7加减4");
				}
				else
				{
					bool flag15 = Math.Abs(num6) > 750.0;
					if (flag15)
					{
						num12 = -pi / 2.0 - num13;
						num12 -= 0.1;
						bool flag16 = Math.Abs(num8) > Math.Abs(num12);
						if (flag16)
						{
							GlobalVar.decisions[whichfish].TCode = 7 + num9 * 2;
							GlobalVar.decisions[whichfish].VCode = 5;
							DebugRecord.ceshi(i, "左边界鱼体方向达到要求，鱼头坐标未达到要求的转角");
						}
						else
						{
							GlobalVar.decisions[whichfish].TCode = 7;
							GlobalVar.decisions[whichfish].VCode = 7;
							DebugRecord.ceshi(i, "左边界鱼体方向达到要求，鱼头坐标未达到要求的跑位");
						}
					}
					else
					{
						bool flag17 = Math.Abs(num8) < Math.Abs(num12) + 0.05 && Math.Abs(num8) > Math.Abs(num12) - 0.05;
						if (flag17)
						{
							GlobalVar.decisions[whichfish].TCode = 7;
							GlobalVar.decisions[whichfish].VCode = 12 - num15;
							DebugRecord.ceshi(i, "左边界的平衡位置甩头动作");
							DebugRecord.ceshi(i, "Tcode=7");
							DebugRecord.ceshi(i, "vcode", (float)(12 - num15));
						}
						else
						{
							bool flag18 = Math.Abs(num8) < Math.Abs(num12);
							if (flag18)
							{
								bool flag19 = Math.Abs(GlobalVar.prefish[whichfish].preTcode - num14) > 1;
								if (flag19)
								{
									num14 = Math.Sign(GlobalVar.prefish[whichfish].preTcode - num14) + num14;
								}
								GlobalVar.decisions[whichfish].TCode = num14;
								num15 = 9 - num15;
								bool flag20 = num15 < 1;
								if (flag20)
								{
									num15 = 1;
								}
								bool flag21 = Math.Abs(GlobalVar.prefish[whichfish].preVcode - num15) > 2;
								if (flag21)
								{
									num15 = (num15 + GlobalVar.prefish[whichfish].preVcode) / 2;
								}
								GlobalVar.decisions[whichfish].VCode = num15;
								DebugRecord.ceshi(i, "与左边界过于扁平的甩头动作");
								DebugRecord.ceshi(i, "Tcode", (float)num14);
								DebugRecord.ceshi(i, "vcode", (float)num15);
							}
							else
							{
								GlobalVar.decisions[whichfish].TCode = num14;
								num15 = 3 - num15;
								bool flag22 = num15 <= 6;
								if (flag22)
								{
									num15 = 6;
								}
								GlobalVar.decisions[whichfish].VCode = num15;
								DebugRecord.ceshi(i, "与左边界夹角过大的甩头动作");
								DebugRecord.ceshi(i, "Tcode", (float)num14);
								DebugRecord.ceshi(i, "vcode", (float)num15);
							}
						}
					}
				}
			}
			bool flag23 = num5 - num >= 60.0;
			if (flag23)
			{
				bool flag24 = (double)num9 * num8 < -1.047;
				if (flag24)
				{
					GlobalVar.decisions[whichfish].VCode = 1;
					GlobalVar.decisions[whichfish].TCode = 7 - num9 * 7;
					DebugRecord.ceshi(i, "左边界的意外情况，丢了球转角");
				}
				else
				{
					bool flag25 = Math.Abs(num8) < 1.047;
					if (flag25)
					{
						GlobalVar.decisions[whichfish].VCode = 1;
						GlobalVar.decisions[whichfish].TCode = 7 + num9 * 7;
						DebugRecord.ceshi(i, "左边界的意外情况，丢了球转角");
					}
				}
				bool flag26 = num5 > -1000.0;
				if (flag26)
				{
					this.Position(whichfish, -1200.0, num2 + (double)(num9 * 50), 200.0);
					DebugRecord.ceshi(i, "左边界的意外情况，丢了球跑位");
				}
				else
				{
					bool flag27 = num5 < -1200.0;
					if (flag27)
					{
						this.Position(whichfish, -1500.0, num2 + (double)(num9 * 65), 100.0);
						DebugRecord.ceshi(i, "左边界的意外情况，丢了球跑位");
					}
				}
			}
			else
			{
				bool flag28 = Math.Abs(num2) - Math.Abs(num6) > 30.0 && num5 - num < 60.0;
				if (flag28)
				{
					this.Position(whichfish, -1500.0, num2 + (double)(num9 * 65), 100.0);
					DebugRecord.ceshi(i, "左边界的意外情况，球在鱼的下面");
				}
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0001AB18 File Offset: 0x00018D18
		public int whether_duqiumen()
		{
			bool flag = Math.Abs(GlobalVar.OppTeam.Fishes[1].PositionMm.Z) < 800f && Math.Abs(GlobalVar.OppTeam.Fishes[1].PositionMm.Z) > 150f && GlobalVar.OppTeam.Fishes[1].PositionMm.X < -1000f && GlobalVar.OppTeam.Fishes[1].PositionMm.X > -1500f;
			int result;
			if (flag)
			{
				bool flag2 = Math.Abs(GlobalVar.OppTeam.Fishes[0].PositionMm.Z) < 800f && Math.Abs(GlobalVar.OppTeam.Fishes[0].PositionMm.Z) > 150f && GlobalVar.OppTeam.Fishes[0].PositionMm.X < -1000f && GlobalVar.OppTeam.Fishes[0].PositionMm.X > -1500f;
				if (flag2)
				{
					result = 1;
				}
				else
				{
					result = 0;
				}
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0001AC64 File Offset: 0x00018E64
		public int get_upper_fish()
		{
			bool flag = GlobalVar.OppTeam.Fishes[0].PositionMm.Z < GlobalVar.OppTeam.Fishes[1].PositionMm.Z;
			int result;
			if (flag)
			{
				result = 0;
			}
			else
			{
				result = 1;
			}
			return result;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0001ACB8 File Offset: 0x00018EB8
		public int ChoseBall_for_duqiumen(int fishID)
		{
			DebugRecord.ceshi(0, "被调用堵球门选球");
			int num = GlobalVar.Bringing_BallID[fishID];
			for (int i = 0; i < 9; i++)
			{
				bool flag = Math.Abs(GlobalVar.mission.EnvRef.Balls[i].PositionMm.Z) < 508f && GlobalVar.mission.EnvRef.Balls[i].PositionMm.X < -984f && GlobalVar.mission.EnvRef.Balls[i].PositionMm.X > -1500f && GlobalVar.leftScore[i] != 1 && GlobalVar.Bringing_BallID[1 - fishID] != i;
				if (flag)
				{
					GlobalVar.Bringing_BallID[fishID] = i;
					return i;
				}
			}
			bool flag2 = -1 == num || this.whether_area_CornerChoseBall2((double)GlobalVar.balls[num].PositionMm.X, (double)GlobalVar.balls[num].PositionMm.Z) || this.whether_in_myforbiddenarea_reduce((double)GlobalVar.mission.EnvRef.Balls[num].PositionMm.X, (double)GlobalVar.mission.EnvRef.Balls[num].PositionMm.Z) || GlobalVar.Bringing_BallID[1 - fishID] == num || GlobalVar.willbring_ballid[1 - fishID] == num || (GlobalVar.Paishu < 3000 && GlobalVar.final == 0 && fishID == 0 && GlobalVar.mission.EnvRef.Balls[num].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[num].PositionMm.Z < -508f) || (GlobalVar.Paishu < 3000 && GlobalVar.final == 0 && fishID == 1 && GlobalVar.mission.EnvRef.Balls[num].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[num].PositionMm.Z > 508f);
			if (flag2)
			{
				double num2 = 4000.0;
				double num3 = 4000.0;
				int num4 = -1;
				int num5 = -1;
				for (int j = 0; j < 3; j++)
				{
					bool flag3 = fishID == 0 && GlobalVar.mission.EnvRef.Balls[j].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z < -508f;
					if (!flag3)
					{
						bool flag4 = fishID == 1 && GlobalVar.mission.EnvRef.Balls[j].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z > 508f;
						if (!flag4)
						{
							bool flag5 = !this.whether_in_myforbiddenarea_reduce((double)GlobalVar.mission.EnvRef.Balls[j].PositionMm.X, (double)(Math.Abs(GlobalVar.mission.EnvRef.Balls[j].PositionMm.Z) - 30f)) && GlobalVar.Bringing_BallID[1 - fishID] != j && !this.whether_in_oppforbiddenarea((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z) && GlobalVar.interfereBallStage[fishID] == 0;
							if (flag5)
							{
								bool flag6 = fishID == 0;
								double num6;
								if (flag6)
								{
									num6 = this.juli((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z, -1500.0, 300.0);
								}
								else
								{
									num6 = this.juli((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z, -1500.0, -300.0);
								}
								bool flag7 = GlobalVar.Bringing_BallID[1 - fishID] != j;
								if (flag7)
								{
									bool flag8 = num6 < num3 && num6 > num2;
									if (flag8)
									{
										num3 = num6;
										num5 = j;
									}
									bool flag9 = num6 < num2;
									if (flag9)
									{
										num3 = num2;
										num2 = num6;
										num5 = num4;
										num4 = j;
									}
								}
							}
						}
					}
				}
				bool flag10 = num5 == -1 && num4 != -1;
				if (flag10)
				{
					num = num4;
				}
				else
				{
					bool flag11 = num4 == -1 && num5 != -1;
					if (flag11)
					{
						num = num5;
					}
					else
					{
						bool flag12 = num4 == -1 && num5 == -1;
						if (flag12)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag13 = num != -1;
				if (flag13)
				{
					bool flag14 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag14)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
				num2 = 4000.0;
				num3 = 4000.0;
				num4 = -1;
				num5 = -1;
				for (int k = 7; k < 9; k++)
				{
					bool flag15 = fishID == 0 && GlobalVar.mission.EnvRef.Balls[k].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[k].PositionMm.Z < -508f;
					if (!flag15)
					{
						bool flag16 = fishID == 1 && GlobalVar.mission.EnvRef.Balls[k].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[k].PositionMm.Z > 508f;
						if (!flag16)
						{
							bool flag17 = !this.whether_in_myforbiddenarea_reduce((double)GlobalVar.mission.EnvRef.Balls[k].PositionMm.X, (double)(Math.Abs(GlobalVar.mission.EnvRef.Balls[k].PositionMm.Z) - 30f)) && GlobalVar.Bringing_BallID[1 - fishID] != k && !this.whether_in_oppforbiddenarea((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z) && GlobalVar.interfereBallStage[fishID] == 0;
							if (flag17)
							{
								bool flag18 = fishID == 0;
								double num6;
								if (flag18)
								{
									num6 = this.juli((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z, -1500.0, 300.0);
								}
								else
								{
									num6 = this.juli((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z, -1500.0, -300.0);
								}
								bool flag19 = GlobalVar.Bringing_BallID[1 - fishID] != k;
								if (flag19)
								{
									bool flag20 = num6 < num3 && num6 > num2;
									if (flag20)
									{
										num3 = num6;
										num5 = k;
									}
									bool flag21 = num6 < num2;
									if (flag21)
									{
										num3 = num2;
										num2 = num6;
										num5 = num4;
										num4 = k;
									}
								}
							}
						}
					}
				}
				bool flag22 = num5 == -1 && num4 != -1;
				if (flag22)
				{
					num = num4;
				}
				else
				{
					bool flag23 = num4 == -1 && num5 != -1;
					if (flag23)
					{
						num = num5;
					}
					else
					{
						bool flag24 = num4 == -1 && num5 == -1;
						if (flag24)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag25 = num != -1;
				if (flag25)
				{
					bool flag26 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag26)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
				num2 = 4000.0;
				num3 = 4000.0;
				num4 = -1;
				num5 = -1;
				int l = 3;
				while (l < 7)
				{
					bool flag27 = GlobalVar.teamId == 0;
					if (flag27)
					{
						bool flag28 = fishID == 0 && l == 3;
						if (!flag28)
						{
							bool flag29 = fishID == 1 && l == 6;
							if (!flag29)
							{
								goto IL_906;
							}
						}
					}
					else
					{
						bool flag30 = GlobalVar.teamId == 1;
						if (!flag30)
						{
							goto IL_906;
						}
						bool flag31 = fishID == 0 && l == 5;
						if (!flag31)
						{
							bool flag32 = fishID == 1 && l == 4;
							if (!flag32)
							{
								goto IL_906;
							}
						}
					}
					IL_B1A:
					l++;
					continue;
					IL_906:
					bool flag33 = fishID == 0 && GlobalVar.mission.EnvRef.Balls[l].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[l].PositionMm.Z < -508f;
					if (flag33)
					{
						goto IL_B1A;
					}
					bool flag34 = fishID == 1 && GlobalVar.mission.EnvRef.Balls[l].PositionMm.X < -952f && GlobalVar.mission.EnvRef.Balls[l].PositionMm.Z > 508f;
					if (flag34)
					{
						goto IL_B1A;
					}
					bool flag35 = !this.whether_in_myforbiddenarea_reduce((double)GlobalVar.mission.EnvRef.Balls[l].PositionMm.X, (double)(Math.Abs(GlobalVar.mission.EnvRef.Balls[l].PositionMm.Z) - 30f)) && GlobalVar.Bringing_BallID[1 - fishID] != l && GlobalVar.interfereBallStage[fishID] == 0;
					if (flag35)
					{
						bool flag36 = fishID == 0;
						double num6;
						if (flag36)
						{
							num6 = this.juli((double)GlobalVar.balls[l].PositionMm.X, (double)GlobalVar.balls[l].PositionMm.Z, -1500.0, 300.0);
						}
						else
						{
							num6 = this.juli((double)GlobalVar.balls[l].PositionMm.X, (double)GlobalVar.balls[l].PositionMm.Z, -1500.0, -300.0);
						}
						bool flag37 = GlobalVar.Bringing_BallID[1 - fishID] != l;
						if (flag37)
						{
							bool flag38 = num6 < num3 && num6 > num2;
							if (flag38)
							{
								num3 = num6;
								num5 = l;
							}
							bool flag39 = num6 < num2;
							if (flag39)
							{
								num3 = num2;
								num2 = num6;
								num5 = num4;
								num4 = l;
							}
						}
					}
					goto IL_B1A;
				}
				bool flag40 = num5 == -1 && num4 != -1;
				if (flag40)
				{
					num = num4;
				}
				else
				{
					bool flag41 = num4 == -1 && num5 != -1;
					if (flag41)
					{
						num = num5;
					}
					else
					{
						bool flag42 = num4 == -1 && num5 == -1;
						if (flag42)
						{
							num = -1;
						}
						else
						{
							num = num4;
						}
					}
				}
				bool flag43 = num != -1;
				if (flag43)
				{
					bool flag44 = GlobalVar.Bringing_BallID[fishID] != num;
					if (flag44)
					{
						GlobalVar.whether_change_to_test3[fishID] = 0;
					}
					GlobalVar.Bringing_BallID[fishID] = num;
					return num;
				}
			}
			bool flag45 = GlobalVar.Bringing_BallID[fishID] != num;
			if (flag45)
			{
				GlobalVar.whether_change_to_test3[fishID] = 0;
			}
			bool flag46 = num == -1;
			if (flag46)
			{
				GlobalVar.Bringing_BallID[fishID] = -1;
				return num;
			}
			bool flag47 = GlobalVar.willbring_ballid[fishID] != -1 && GlobalVar.MyTeam.Fishes[fishID].PositionMm.X < 950f && Math.Abs(GlobalVar.MyTeam.Fishes[fishID].PolygonVertices[0].Z) > 850f && GlobalVar.leftScore[GlobalVar.willbring_ballid[fishID]] != 1;
			if (flag47)
			{
				num = GlobalVar.willbring_ballid[fishID];
			}
			bool flag48 = num == GlobalVar.willbring_ballid[fishID];
			if (flag48)
			{
				GlobalVar.willbring_ballid[fishID] = -1;
			}
			GlobalVar.Bringing_BallID[fishID] = num;
			return num;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0001B964 File Offset: 0x00019B64
		public bool whether_in_oppforbiddenarea(double location_x, double location_z)
		{
			return location_x > 952.0;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0001B98C File Offset: 0x00019B8C
		public bool whether_in_goal(double x, double z, int num)
		{
			int upper_fish = this.get_upper_fish();
			return z > (double)GlobalVar.OppTeam.Fishes[upper_fish].PositionMm.Z && z < (double)GlobalVar.OppTeam.Fishes[1 - upper_fish].PositionMm.Z && x < -930.0 && x > -1500.0;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0001BA08 File Offset: 0x00019C08
		public void Dribble_blue(int which, double dx, double dz, int num)
		{
			double num2 = 1.0;
			bool flag = num >= 0 && num <= 2;
			if (!flag)
			{
				bool flag2 = num >= 3 && num <= 6;
				if (flag2)
				{
					num2 = num2 * 78.0 / 38.0;
				}
				else
				{
					num2 = num2 * 58.0 / 38.0;
				}
			}
			int i = (which == 0) ? 13 : 14;
			double num3 = (double)GlobalVar.balls[num].PositionMm.X;
			double num4 = (double)GlobalVar.balls[num].PositionMm.Z;
			double num5 = (double)GlobalVar.MyTeam.Fishes[which].PolygonVertices[0].X;
			double num6 = (double)GlobalVar.MyTeam.Fishes[which].PolygonVertices[0].Z;
			double num7 = (double)GlobalVar.MyTeam.Fishes[which].PositionMm.X;
			double num8 = (double)GlobalVar.MyTeam.Fishes[which].PositionMm.Z;
			double num9 = (double)GlobalVar.MyTeam.Fishes[which].BodyDirectionRad;
			double num10 = (double)GlobalVar.MyTeam.Fishes[which].VelocityMmPs;
			double distance = Compute.GetDistance(num5, num6, num3, num4);
			double distance2 = Compute.GetDistance(num3, num4, num7, num8);
			double distance3 = Compute.GetDistance(num7, num8, dx, dz);
			double distance4 = Compute.GetDistance(num3, num4, dx, dz);
			double angleRad = Compute.GetAngleRad(num3, num4, num7, num8);
			double angleRad2 = Compute.GetAngleRad(num3, num4, num5, num6);
			double angleRad3 = Compute.GetAngleRad(num5, num6, num3, num4);
			double angleRad4 = Compute.GetAngleRad(num7, num8, num3, num4);
			double angleRad5 = Compute.GetAngleRad(num3, num4, dx, dz);
			double angleRad6 = Compute.GetAngleRad(dx, dz, num3, num4);
			double angleRad7 = Compute.GetAngleRad(num7, num8, dx, dz);
			double num11 = Compute.FormatAngleRad(angleRad6 + GlobalVar.PI);
			double x = 0.0;
			double pi = GlobalVar.PI;
			double num12 = Compute.FormatAngleRad(angleRad2 - angleRad6);
			double num13 = distance * Math.Cos(num12);
			double num14 = distance * Math.Sin(num12);
			double num15 = Compute.FormatAngleRad(angleRad - angleRad6);
			double num16 = distance2 * Math.Cos(num15);
			double num17 = distance2 * Math.Sin(num15);
			double num18 = 0.0;
			double num19 = 0.0;
			double num20 = Compute.FormatAngleRad(num11 - num9);
			double num21 = (double)GlobalVar.balls[num].RadiusMm / 38.0;
			DebugRecord.ceshi(1, "fishdir", num9);
			DebugRecord.ceshi(1, "dir", angleRad6);
			DebugRecord.ceshi(1, "theta", num11);
			DebugRecord.ceshi(1, "relative_head_angle", num12);
			DebugRecord.ceshi(1, "relative_body_angle", num15);
			DebugRecord.ceshi(1, "relative_head_x", num13);
			DebugRecord.ceshi(1, "relative_head_z", num14);
			DebugRecord.ceshi(1, "relative_body_x", num16);
			DebugRecord.ceshi(1, "relative_body_z", num17);
			DebugRecord.ceshi(4, "dis_ball_head", distance);
			DebugRecord.ceshi(8, "dir_head_ball", angleRad2);
			bool flag3 = num13 < 0.0;
			if (flag3)
			{
				bool flag4 = num14 < 0.0;
				if (flag4)
				{
					DebugRecord.ceshi(i, "鱼头在1区");
				}
				else
				{
					DebugRecord.ceshi(i, "鱼头在2区");
				}
			}
			else
			{
				bool flag5 = num12 > pi / 4.0 && num12 < pi / 2.0;
				if (flag5)
				{
					DebugRecord.ceshi(i, "鱼头在3区");
				}
				else
				{
					bool flag6 = num12 < -pi / 4.0 && num12 > -pi / 2.0;
					if (flag6)
					{
						DebugRecord.ceshi(i, "鱼头在5区");
					}
					else
					{
						bool flag7 = num12 > -pi / 4.0 && num12 < pi / 4.0;
						if (flag7)
						{
							DebugRecord.ceshi(i, "鱼头在4区");
						}
					}
				}
			}
			bool flag8 = num4 < -880.0 || num3 < -1400.0 || num4 > 880.0 || num3 > 1400.0;
			if (flag8)
			{
				bool flag9 = num3 < -1400.0 && num4 < -900.0;
				if (flag9)
				{
					this.position3_1(which, num3, -1000.0, 50.0, 0);
					this.keepv(which, 170.0);
					DebugRecord.ceshi(i, "上角落");
				}
				else
				{
					bool flag10 = num3 < -1400.0 && num4 > 900.0;
					if (flag10)
					{
						this.position3_1(which, num3, 1000.0, 50.0, 0);
						this.keepv(which, 170.0);
						DebugRecord.ceshi(i, "下角落");
					}
					else
					{
						bool flag11 = num3 > 1400.0 && num4 < -900.0;
						if (flag11)
						{
							bool flag12 = num5 > 1420.0 && num6 > -900.0;
							if (flag12)
							{
								this.position3_1(which, 1500.0, num4, 50.0, 0);
								this.keepv(which, 170.0);
							}
							else
							{
								this.position3_1(which, 1484.0, -800.0, 50.0, 0);
							}
						}
						else
						{
							bool flag13 = num3 > 1400.0 && num4 > 900.0;
							if (flag13)
							{
								bool flag14 = num5 > 1420.0 && num6 < 900.0;
								if (flag14)
								{
									this.position3_1(which, 1500.0, num4, 50.0, 0);
									this.keepv(which, 170.0);
								}
								else
								{
									this.position3_1(which, 1484.0, 800.0, 50.0, 0);
								}
							}
							else
							{
								bool flag15 = (num >= 0 && num <= 2 && num3 < -1400.0) || (num >= 3 && num <= 8 && num3 <= -1160.0);
								if (flag15)
								{
									bool flag16 = num4 < 160.0;
									if (flag16)
									{
										bool flag17 = angleRad2 > -pi / 6.0 && num5 > -1420.0;
										if (flag17)
										{
											this.position3_1(which, num3 + num21 * 200.0 * Math.Cos(pi / 4.0), num4 - num21 * 200.0 * Math.Sin(pi / 4.0), 50.0, 0);
											DebugRecord.ceshi(i, "左墙范围外跑位零");
										}
										else
										{
											bool flag18 = angleRad2 > -pi * 8.0 / 18.0 && num5 > -1420.0;
											if (flag18)
											{
												this.position3_1(which, num3 - num21 * 50.0, num4 - num21 * 100.0, 50.0, 0);
												DebugRecord.ceshi(i, "左墙墙范围外跑位一");
											}
											else
											{
												bool flag19 = num8 > num4;
												if (flag19)
												{
													this.position3_1(which, num3 + num21 * 100.0, num4, 50.0, 0);
													DebugRecord.ceshi(i, "左墙范围外跑位二");
												}
												else
												{
													bool flag20 = num == 0 || num == 1 || num == 2;
													if (flag20)
													{
														this.position3_1(which, -1500.0 - Math.Cos(pi / 12.0) * 800.0, num4 - 38.0 * num21 + Math.Sin(pi / 12.0) * 800.0, 50.0, 0);
													}
													else
													{
														bool flag21 = num == 7 || num == 8;
														if (flag21)
														{
															this.position3_1(which, -1500.0 - Math.Cos(pi / 12.0) * 800.0, num4 - 38.0 * num21 + Math.Sin(pi / 12.0) * 800.0, 50.0, 0);
															GlobalVar.decisions[which].VCode = 14;
															DebugRecord.ceshi(15, "pre跑到敌方鱼中点处");
															bool flag22 = num3 > -1350.0 && 2.0 * GlobalVar.PI - Math.Abs(num9 - (double)GlobalVar.OppTeam.Fishes[this.get_upper_fish()].BodyDirectionRad) >= GlobalVar.PI / 4.0;
															if (flag22)
															{
																this.position3_1(which, (double)GlobalVar.OppTeam.Fishes[this.get_upper_fish()].PositionMm.X, (double)GlobalVar.OppTeam.Fishes[this.get_upper_fish()].PositionMm.Z, 100.0, 0);
																DebugRecord.ceshi(15, "跑到敌方鱼中点处");
															}
														}
														else
														{
															GlobalVar.BaAction.position3_1(which, -1800.0, num4, 50.0, 0);
															GlobalVar.decisions[which].VCode = 14;
															DebugRecord.ceshi(15, "pre跑到敌方鱼中点处");
															bool flag23 = num3 > -1350.0 && 2.0 * GlobalVar.PI - Math.Abs(num9 - (double)GlobalVar.OppTeam.Fishes[this.get_upper_fish()].BodyDirectionRad) >= GlobalVar.PI / 4.0;
															if (flag23)
															{
																this.position3_1(which, (double)GlobalVar.OppTeam.Fishes[this.get_upper_fish()].PositionMm.X, (double)GlobalVar.OppTeam.Fishes[this.get_upper_fish()].PositionMm.Z, 100.0, 0);
																DebugRecord.ceshi(15, "跑到敌方鱼中点处");
															}
														}
													}
													DebugRecord.ceshi(i, "previous_w", (float)this.previous_w);
													DebugRecord.ceshi(i, "current_w", (float)this.current_w);
													bool flag24 = num4 < -660.0 && num6 > -960.0 && Compute.GetDistance(num7, num8, num3, num4) < 130.0;
													if (flag24)
													{
														DebugRecord.ceshi(i, "进入限制档位的区域");
														bool flag25 = this.current_w - this.previous_w >= 5;
														if (flag25)
														{
															this.current_w = this.previous_w + 1;
															DebugRecord.ceshi(i, "挡位加一");
														}
														else
														{
															bool flag26 = this.current_w - this.previous_w <= -5;
															if (flag26)
															{
																this.current_w = this.previous_w - 1;
																DebugRecord.ceshi(i, "挡位减一");
															}
															else
															{
																DebugRecord.ceshi(i, "挡位不变");
															}
														}
														bool flag27 = this.current_w > 9;
														if (flag27)
														{
															this.current_w = 9;
															DebugRecord.ceshi(i, "挡位为9");
														}
														else
														{
															bool flag28 = this.current_w < 5;
															if (flag28)
															{
																this.current_w = 5;
																DebugRecord.ceshi(i, "挡位为5");
															}
														}
														GlobalVar.decisions[which].TCode = this.current_w;
													}
													DebugRecord.ceshi(8, "左墙跑位");
												}
											}
										}
									}
									else
									{
										bool flag29 = angleRad2 < pi / 6.0 && num5 > -1420.0;
										if (flag29)
										{
											this.position3_1(which, num3 + num21 * 50.0 * Math.Cos(pi / 4.0), num4 + num21 * 50.0 * Math.Sin(pi / 4.0), 50.0, 0);
											DebugRecord.ceshi(i, "左墙范围外跑位零");
										}
										else
										{
											bool flag30 = angleRad2 < pi * 8.0 / 18.0 && num5 > -1420.0;
											if (flag30)
											{
												this.position3_1(which, num3 - num21 * 50.0, num4 + num21 * 100.0, 50.0, 0);
												DebugRecord.ceshi(i, "左墙墙范围外跑位一");
											}
											else
											{
												bool flag31 = num8 < num4;
												if (flag31)
												{
													this.position3_1(which, num3 + num21 * 100.0, num4, 50.0, 0);
													DebugRecord.ceshi(i, "左墙范围外跑位二");
												}
												else
												{
													bool flag32 = num == 0 || num == 1 || num == 2;
													if (flag32)
													{
														this.position3_1(which, -1500.0 - Math.Cos(pi / 12.0) * 800.0, num4 + 38.0 * num21 - Math.Sin(pi / 12.0) * 800.0, 50.0, 0);
													}
													else
													{
														bool flag33 = num == 7 || num == 8;
														if (flag33)
														{
															this.position3_1(which, -1500.0 - Math.Cos(pi / 12.0) * 800.0, num4 + 38.0 * num21 - Math.Sin(pi / 12.0) * 800.0, 50.0, 0);
															GlobalVar.decisions[which].VCode = 14;
															bool flag34 = num3 > -1350.0 && 2.0 * GlobalVar.PI - Math.Abs(num9 - (double)GlobalVar.OppTeam.Fishes[1 - this.get_upper_fish()].BodyDirectionRad) >= GlobalVar.PI / 4.0;
															if (flag34)
															{
																this.position3_1(which, (double)GlobalVar.OppTeam.Fishes[1 - this.get_upper_fish()].PositionMm.X, (double)GlobalVar.OppTeam.Fishes[1 - this.get_upper_fish()].PositionMm.Z, 100.0, 0);
															}
														}
														else
														{
															GlobalVar.BaAction.position3_1(which, -1800.0, num4, 50.0, 0);
															GlobalVar.decisions[which].VCode = 14;
															bool flag35 = num3 > -1350.0 && 2.0 * GlobalVar.PI - Math.Abs(num9 - (double)GlobalVar.OppTeam.Fishes[1 - this.get_upper_fish()].BodyDirectionRad) >= GlobalVar.PI / 4.0;
															if (flag35)
															{
																this.position3_1(which, (double)GlobalVar.OppTeam.Fishes[1 - this.get_upper_fish()].PositionMm.X, (double)GlobalVar.OppTeam.Fishes[1 - this.get_upper_fish()].PositionMm.Z, 100.0, 0);
															}
														}
													}
													DebugRecord.ceshi(i, "previous_w", (float)this.previous_w);
													DebugRecord.ceshi(i, "current_w", (float)this.current_w);
													bool flag36 = num4 > 720.0 && num6 < 960.0 && Compute.GetDistance(num7, num8, num3, num4) < 130.0;
													if (flag36)
													{
														DebugRecord.ceshi(i, "进入限制档位的区域");
														bool flag37 = this.current_w - this.previous_w >= 5;
														if (flag37)
														{
															this.current_w = this.previous_w + 1;
															DebugRecord.ceshi(i, "挡位加一");
														}
														else
														{
															bool flag38 = this.current_w - this.previous_w <= -5;
															if (flag38)
															{
																this.current_w = this.previous_w - 1;
																DebugRecord.ceshi(i, "挡位减一");
															}
															else
															{
																DebugRecord.ceshi(i, "挡位不变");
															}
														}
														bool flag39 = this.current_w > 8;
														if (flag39)
														{
															this.current_w = 8;
															DebugRecord.ceshi(i, "挡位为8");
														}
														else
														{
															bool flag40 = this.current_w < 6;
															if (flag40)
															{
																this.current_w = 6;
																DebugRecord.ceshi(i, "挡位为6");
															}
														}
														GlobalVar.decisions[which].TCode = this.current_w;
														bool flag41 = num10 > 120.0;
														if (flag41)
														{
															this.keepv(which, 80.0);
															DebugRecord.ceshi(i, "限制速度");
														}
													}
													DebugRecord.ceshi(i, "左墙跑位");
													DebugRecord.ceshi(i, "fishhead_z", num6);
												}
											}
										}
									}
								}
								else
								{
									bool flag42 = num4 > 880.0;
									if (flag42)
									{
										bool flag43 = angleRad2 < -pi / 3.0 && num6 < 920.0;
										if (flag43)
										{
											this.position3_1(which, num3 + num21 * Math.Cos(-pi / 4.0) * 200.0, num4 + num21 * Math.Sin(-pi / 4.0) * 200.0, 50.0, 0);
											DebugRecord.ceshi(i, "下墙范围外跑位零");
										}
										else
										{
											bool flag44 = angleRad2 < -pi / 18.0 && num6 < 920.0;
											if (flag44)
											{
												this.position3_1(which, num3 + num21 * 100.0, num4 + num21 * 50.0, 50.0, 0);
												DebugRecord.ceshi(i, "下墙范围外跑位一");
											}
											else
											{
												bool flag45 = num7 < num3;
												if (flag45)
												{
													this.position3_1(which, num3 + num21 * Math.Cos(pi * 70.0 / 180.0) * 100.0, num4 - num21 * Math.Sin(pi * 70.0 / 180.0) * 100.0, 50.0, 1);
													DebugRecord.ceshi(i, "下墙范围外跑位二");
												}
												else
												{
													this.position3_1(which, num3 + num21 * 38.0 - 800.0 * Math.Sin(pi / 12.0), 1000.0 + 800.0 * Math.Cos(pi / 12.0), 50.0, 0);
													bool flag46 = num9 < pi * 8.0 / 18.0 && num6 > 950.0;
													if (flag46)
													{
														this.keep_angle(which, pi / 2.0, 0);
														bool flag47 = num10 > 70.0;
														if (flag47)
														{
															this.keepv(which, 1.0);
														}
														DebugRecord.ceshi(i, "下墙范围内左调角");
													}
													bool flag48 = num9 > 2.0 && num6 > 950.0;
													if (flag48)
													{
														this.keep_angle(which, pi / 2.0, 0);
														bool flag49 = num10 > 200.0;
														if (flag49)
														{
															this.keepv(which, 1.0);
														}
														DebugRecord.ceshi(i, "下墙范围内右调角");
													}
													bool flag50 = Compute.GetDistance(num7, num8, num3, num4) > 100.0;
													if (flag50)
													{
														this.position3_1(which, num3, num4 + num21 * 120.0, 50.0, 1);
														DebugRecord.ceshi(i, "下墙范围内跑位");
													}
													DebugRecord.ceshi(i, "下墙范围内边界带球");
												}
											}
										}
									}
									else
									{
										bool flag51 = angleRad2 > pi / 3.0 && num6 > -920.0;
										if (flag51)
										{
											this.position3_1(which, num3 + num21 * Math.Cos(pi / 4.0) * 200.0, num4 + num21 * Math.Sin(pi / 4.0) * 200.0, 50.0, 0);
											DebugRecord.ceshi(i, "上墙范围外跑位零");
										}
										else
										{
											bool flag52 = angleRad2 > pi / 18.0 && num6 > -920.0;
											if (flag52)
											{
												this.position3_1(which, num3 + num21 * 100.0, num4 - num21 * 50.0, 50.0, 0);
												DebugRecord.ceshi(i, "上墙范围外跑位一");
											}
											else
											{
												bool flag53 = num7 < num3;
												if (flag53)
												{
													this.position3_1(which, num3 + num21 * Math.Cos(pi * 7.0 / 18.0) * 300.0, num4 + num21 * Math.Sin(pi * 7.0 / 18.0) * 300.0, 50.0, 1);
													DebugRecord.ceshi(i, "上墙范围外跑位二");
												}
												else
												{
													this.position3_1(which, num3 + num21 * 38.0 - 800.0 * Math.Sin(pi / 12.0), -1000.0 - 800.0 * Math.Cos(pi / 12.0), 50.0, 0);
													bool flag54 = num9 > -pi * 8.0 / 18.0 && num6 < -950.0;
													if (flag54)
													{
														this.keep_angle(which, -pi / 2.0, 0);
														bool flag55 = num10 > 70.0;
														if (flag55)
														{
															this.keepv(which, 1.0);
														}
														DebugRecord.ceshi(i, "上墙范围内左调角");
													}
													bool flag56 = num9 < -2.0 && num6 < -950.0;
													if (flag56)
													{
														this.keep_angle(which, -pi / 2.0, 0);
														DebugRecord.ceshi(i, "上墙范围内右调角");
														bool flag57 = num10 > 200.0;
														if (flag57)
														{
															this.keepv(which, 1.0);
														}
													}
													bool flag58 = Compute.GetDistance(num7, num8, num3, num4) > 100.0;
													if (flag58)
													{
														this.position3_1(which, num3, num4 - num21 * 120.0, 50.0, 1);
														DebugRecord.ceshi(i, "上墙范围内跑位");
													}
													DebugRecord.ceshi(i, "上墙范围内边界带球");
													DebugRecord.ceshi(12, "target_x", num3 - 130.0);
													DebugRecord.ceshi(12, "target_z", (num4 - 10.0 * Math.Cos(pi * 8.0 / 18.0)) * 10.0);
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			else
			{
				bool flag59 = num3 < -820.0 && num3 > -940.0 && num4 > -580.0 && num4 < 580.0;
				if (flag59)
				{
					bool flag60 = num4 > -580.0 && num4 < -450.0;
					if (flag60)
					{
						this.position3_1(which, num3 + num21 * 38.0 * Math.Cos(pi * 2.0 / 3.0), num4 + num21 * 38.0 * Math.Sin(pi * 2.0 / 3.0), 100.0, 0);
					}
					else
					{
						bool flag61 = num4 < 160.0;
						if (flag61)
						{
							bool flag62 = angleRad2 < pi / 6.0 && num5 > -860.0;
							if (flag62)
							{
								this.position3_1(which, num3 + num21 * 50.0 * Math.Cos(pi / 4.0), num4 + num21 * 50.0 * Math.Sin(pi / 4.0), 50.0, 0);
								DebugRecord.ceshi(i, "往上带球一，范围外");
							}
							else
							{
								bool flag63 = angleRad2 < pi * 8.0 / 18.0 && num5 > -860.0;
								if (flag63)
								{
									this.position3_1(which, num3 - num21 * 50.0, num4 + num21 * 100.0, 50.0, 0);
									DebugRecord.ceshi(i, "往上带球二，范围外");
								}
								else
								{
									bool flag64 = num8 < num4;
									if (flag64)
									{
										this.position3_1(which, num3 + num21 * 100.0, num4, 50.0, 0);
										DebugRecord.ceshi(i, "往上带球三，范围外");
									}
									else
									{
										this.position3_1(which, -940.0 - Math.Cos(pi / 12.0) * 800.0, num4 + num21 * 38.0 - Math.Sin(pi / 12.0) * 800.0, 50.0, 0);
										DebugRecord.ceshi(i, "往上带球，范围内");
									}
								}
							}
						}
						else
						{
							bool flag65 = num4 < 580.0 && num4 > 560.0;
							if (flag65)
							{
								bool flag66 = Math.Abs(num9 - pi / 2.0) > pi / 9.0;
								if (flag66)
								{
									this.keep_angle(which, pi / 2.0, 1);
								}
								else
								{
									this.position3_1(which, num3, num4, 100.0, 0);
								}
							}
							else
							{
								bool flag67 = angleRad2 > -pi / 6.0 && num5 > -880.0;
								if (flag67)
								{
									this.position3_1(which, num3 + num21 * 200.0 * Math.Cos(pi / 4.0), num4 - num21 * 200.0 * Math.Sin(pi / 4.0), 50.0, 0);
									DebugRecord.ceshi(i, "往下带球一，范围外");
								}
								else
								{
									bool flag68 = angleRad2 > -pi * 8.0 / 18.0 && num5 > -880.0;
									if (flag68)
									{
										this.position3_1(which, num3 - num21 * 50.0, num4 - num21 * 100.0, 50.0, 0);
										DebugRecord.ceshi(i, "往下带球二，范围外");
									}
									else
									{
										bool flag69 = num8 > num4;
										if (flag69)
										{
											this.position3_1(which, num3 + num21 * 100.0, num4, 50.0, 0);
											DebugRecord.ceshi(i, "往下带球三，范围外");
										}
										else
										{
											this.position3_1(which, -940.0 - Math.Cos(pi / 12.0) * 800.0, num4 - num21 * 38.0 + Math.Sin(pi / 12.0) * 800.0, 50.0, 0);
											DebugRecord.ceshi(i, "往下带球，范围内");
										}
									}
								}
							}
						}
					}
				}
				else
				{
					bool flag70 = num16 < 0.0;
					if (flag70)
					{
						bool flag71 = num17 < 0.0;
						if (flag71)
						{
							num18 = num3 + num21 * 100.0 * Math.Cos(Compute.FormatAngleRad(angleRad6 - pi / 3.0));
							num19 = num4 + num21 * 100.0 * Math.Sin(Compute.FormatAngleRad(angleRad6 - pi / 3.0));
							this.position3_1(which, num18, num19, 100.0, 1);
							DebugRecord.ceshi(i, "鱼身在1区");
							x = 2.0;
						}
						else
						{
							num18 = num3 + num21 * 100.0 * Math.Cos(Compute.FormatAngleRad(angleRad6 + pi / 3.0));
							num19 = num4 + num21 * 100.0 * Math.Sin(Compute.FormatAngleRad(angleRad6 + pi / 3.0));
							this.position3_1(which, num18, num19, 100.0, 1);
							DebugRecord.ceshi(i, "鱼身在2区");
							x = 3.0;
						}
					}
					else
					{
						bool flag72 = num15 > pi / 4.0 && num15 < pi / 2.0;
						if (flag72)
						{
							DebugRecord.ceshi(i, "鱼身在3区");
							bool flag73 = Math.Abs(Compute.FormatAngleRad(angleRad3 - num9)) <= pi / 18.0;
							if (flag73)
							{
								this.keepv(which, 170.0);
								DebugRecord.ceshi(4, "加速");
							}
							else
							{
								bool flag74 = Math.Abs(num9 - angleRad6) < pi / 2.0 && Math.Abs(num12) < Math.Abs(num15);
								if (flag74)
								{
									num18 = num3 + num21 * Math.Cos(angleRad6) * 100.0;
									num19 = num4 + num21 * Math.Sin(angleRad6) * 100.0;
									this.position3_1(which, num18, num19, 80.0, 1);
									x = 0.1;
								}
								else
								{
									num18 = num3 + num21 * 150.0 * Math.Cos(angleRad6);
									num19 = num4 + num21 * 150.0 * Math.Sin(angleRad6);
									this.position3_1(which, num18, num19, 120.0, 0);
									x = 6.02;
								}
							}
						}
						else
						{
							bool flag75 = num15 < -pi / 4.0 && num15 > -pi / 2.0;
							if (flag75)
							{
								DebugRecord.ceshi(i, "鱼身在5区");
								bool flag76 = Math.Abs(Compute.FormatAngleRad(angleRad3 - num9)) <= pi / 18.0;
								if (flag76)
								{
									this.keepv(which, 170.0);
									DebugRecord.ceshi(4, "加速");
								}
								else
								{
									bool flag77 = Math.Abs(num9 - angleRad6) < pi / 2.0 && Math.Abs(num12) < Math.Abs(num15);
									if (flag77)
									{
										num18 = num3 + num21 * Math.Cos(angleRad6) * 100.0;
										num19 = num4 + num21 * Math.Sin(angleRad6) * 100.0;
										this.position3_1(which, num18, num19, 80.0, 1);
										x = -0.1;
									}
									else
									{
										num18 = num3 + num21 * 150.0 * Math.Cos(angleRad6);
										num19 = num4 + num21 * 150.0 * Math.Sin(angleRad6);
										this.position3_1(which, num18, num19, 120.0, 0);
										x = -6.02;
									}
								}
							}
							else
							{
								bool flag78 = num15 > -pi / 4.0 && num15 < pi / 4.0;
								if (flag78)
								{
									DebugRecord.ceshi(i, "鱼身在4区");
									bool flag79 = distance > 70.0;
									if (flag79)
									{
										this.position3_1(which, num3 + num21 * 50.0 * Math.Cos(angleRad6), num4 + num21 * 50.0 * Math.Sin(angleRad6), 70.0, 0);
										x = 10.0;
									}
									else
									{
										bool flag80 = Math.Abs(Compute.FormatAngleRad(angleRad3 - num9)) <= pi / 18.0;
										if (flag80)
										{
											this.keepv(which, 170.0);
											x = 4.0;
										}
										else
										{
											this.keep_angle(which, angleRad4, 1);
											DebugRecord.ceshi(4, "调角1");
											x = 11.0;
										}
									}
								}
							}
						}
					}
					DebugRecord.ceshi(4, "flag", x);
					DebugRecord.ceshi(4, "goal_x", num18);
					DebugRecord.ceshi(4, "goal_z", num19);
					DebugRecord.ceshi(4, "dir_ball_head", angleRad3);
				}
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0001DC84 File Offset: 0x0001BE84
		public void position3_1(int which, double target_x, double target_z, double target_v, int tag)
		{
			double num = (double)GlobalVar.MyTeam.Fishes[which].VelocityDirectionRad;
			double num2 = (double)GlobalVar.MyTeam.Fishes[which].PositionMm.X;
			double num3 = (double)GlobalVar.MyTeam.Fishes[which].PositionMm.Z;
			bool flag = tag == 0;
			if (flag)
			{
				num2 = (double)GlobalVar.MyTeam.Fishes[which].PolygonVertices[0].X;
				num3 = (double)GlobalVar.MyTeam.Fishes[which].PolygonVertices[0].Z;
			}
			double num4 = (double)GlobalVar.MyTeam.Fishes[which].VelocityMmPs;
			double num5 = (double)GlobalVar.MyTeam.Fishes[which].AngularVelocityRadPs;
			double pi = GlobalVar.PI;
			double num6 = num2 + num4 * Math.Cos(num) * 0.1;
			double num7 = num3 + num4 * Math.Sin(num) * 0.1;
			double distance = Compute.GetDistance(num2, num3, target_x, target_z);
			double distance2 = Compute.GetDistance(num6, num7, target_x, target_z);
			double num8 = num + num5 * 0.1;
			double num9 = Math.Atan2(target_z - num7, target_x - num6);
			double num10 = num9 - num8;
			num10 = Compute.FormatAngleRad(num10);
			int i;
			for (i = 15; i > 1; i--)
			{
				double num11 = num4 * 0.9 + GlobalVar.vTable[i] * 0.1;
				double num12 = 0.0;
				int num13 = 0;
				while (num11 > target_v && num13 < 18)
				{
					num13++;
					num12 += num11 * 0.1;
					num11 = 0.9 * num11 + GlobalVar.vTable[i] * 0.1;
				}
				bool flag2 = num12 <= distance2;
				if (flag2)
				{
					break;
				}
			}
			bool flag3 = i > 15;
			if (flag3)
			{
				i = 15;
			}
			bool flag4 = i < 0;
			if (flag4)
			{
				i = 0;
			}
			GlobalVar.decisions[which].VCode = i;
			bool flag5 = num10 > 0.0;
			int j;
			if (flag5)
			{
				for (j = 14; j > 0; j--)
				{
					double num14 = num5 * 0.9 + GlobalVar.tTable[j] * 0.1;
					bool flag6 = num5 < 0.0 && num14 < 0.0;
					if (flag6)
					{
						break;
					}
					double num15 = 0.0;
					bool flag7 = num14 > 0.0;
					if (!flag7)
					{
						break;
					}
					while (num14 > 0.0)
					{
						num15 += num14 * 0.1;
						num14 = 0.9 * num14 + GlobalVar.tTable[0] * 0.1;
					}
					bool flag8 = num15 <= num10;
					if (flag8)
					{
						break;
					}
				}
			}
			else
			{
				for (j = 0; j < 14; j++)
				{
					double num14 = num5 * 0.9 + GlobalVar.tTable[j] * 0.1;
					bool flag9 = num5 > 0.0 && num14 >= 0.0;
					if (flag9)
					{
						break;
					}
					double num16 = 0.0;
					bool flag10 = num14 > 0.0;
					if (flag10)
					{
						break;
					}
					while (num14 < 0.0)
					{
						num16 += num14 * 0.1;
						num14 = 0.9 * num14 + GlobalVar.tTable[14] * 0.1;
					}
					bool flag11 = num16 >= num10;
					if (flag11)
					{
						break;
					}
				}
			}
			bool flag12 = j > 15;
			if (flag12)
			{
				j = 15;
			}
			bool flag13 = j < 0;
			if (flag13)
			{
				j = 0;
			}
			GlobalVar.decisions[which].TCode = j;
			this.previous_w = this.current_w;
			this.current_w = j;
			num10 = Math.Abs(num10);
			num10 += 0.651;
			bool flag14 = num10 > 1.0;
			if (flag14)
			{
				GlobalVar.decisions[which].VCode = (int)((double)GlobalVar.decisions[which].VCode / (num10 * num10 + 1.0));
			}
			bool flag15 = GlobalVar.decisions[which].TCode != 7 && GlobalVar.decisions[which].VCode == 0;
			if (flag15)
			{
				GlobalVar.decisions[which].VCode = 1;
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0001E1C0 File Offset: 0x0001C3C0
		public void keepv(int which, double dv)
		{
			double num = (double)GlobalVar.MyTeam.Fishes[which].VelocityMmPs;
			double num2 = 400.0;
			int vcode = 0;
			for (int i = 15; i >= 0; i--)
			{
				double num3 = 0.9 * num + 0.1 * GlobalVar.vTable[i];
				bool flag = Math.Abs(num3 - dv) < num2;
				if (flag)
				{
					num2 = Math.Abs(num3 - dv);
					vcode = i;
				}
			}
			GlobalVar.decisions[which].VCode = vcode;
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0001E25C File Offset: 0x0001C45C
		public void keep_angle(int which, double drad, int dv)
		{
			int i = 0;
			double num = (double)GlobalVar.MyTeam.Fishes[which].VelocityDirectionRad;
			double num2 = (double)GlobalVar.MyTeam.Fishes[which].AngularVelocityRadPs;
			double num3 = Compute.FormatAngleRad(drad - num);
			double num4 = num2;
			double num5 = num;
			double num6 = num3;
			bool flag = num6 >= 0.0;
			if (flag)
			{
				for (i = 7; i < 15; i++)
				{
					num2 = num4 * 0.9 + GlobalVar.tTable[i];
					num = num5 + num2 * 0.1;
					num3 = Compute.FormatAngleRad(drad - num);
					bool flag2 = num3 < 0.0;
					if (flag2)
					{
						break;
					}
				}
				double num7 = num4 * 0.9 + GlobalVar.tTable[i];
				double num8 = num5 + num2 * 0.1;
				double value = Compute.FormatAngleRad(drad - num);
				double num9 = num4 * 0.9 + GlobalVar.tTable[i];
				double num10 = num5 + num2 * 0.1;
				double value2 = Compute.FormatAngleRad(drad - num);
				bool flag3 = Math.Abs(value2) < Math.Abs(value);
				if (flag3)
				{
					i--;
				}
			}
			bool flag4 = num6 < 0.0;
			if (flag4)
			{
				for (i = 7; i > 0; i--)
				{
					num2 = num4 * 0.9 + GlobalVar.tTable[i];
					num = num5 + num2 * 0.1;
					num3 = Compute.FormatAngleRad(drad - num);
					bool flag5 = num3 > 0.0;
					if (flag5)
					{
						break;
					}
				}
				double num7 = num4 * 0.9 + GlobalVar.tTable[i];
				double num8 = num5 + num2 * 0.1;
				double value = Compute.FormatAngleRad(drad - num);
				double num9 = num4 * 0.9 + GlobalVar.tTable[i];
				double num10 = num5 + num2 * 0.1;
				double value2 = Compute.FormatAngleRad(drad - num);
				bool flag6 = Math.Abs(value2) < Math.Abs(value);
				if (flag6)
				{
					i++;
				}
			}
			GlobalVar.decisions[which].TCode = i;
			bool flag7 = dv != 0;
			if (flag7)
			{
				GlobalVar.decisions[which].VCode = dv;
			}
			DebugRecord.ceshi(4, "角速度挡位", (float)i);
		}

		// 检测对手是否在我方鱼和球之间
		public bool IsOpponentBlocking(int myFishId, int ballId, out int blockingOppId, out double detourAngle)
		{
			blockingOppId = -1;
			detourAngle = 0.0;
			
			double myFishX = (double)GlobalVar.MyTeam.Fishes[myFishId].PositionMm.X;
			double myFishZ = (double)GlobalVar.MyTeam.Fishes[myFishId].PositionMm.Z;
			double ballX = (double)GlobalVar.balls[ballId].PositionMm.X;
			double ballZ = (double)GlobalVar.balls[ballId].PositionMm.Z;
			
			// 计算我方球门位置（根据实际球门位置判断，不依赖teamId）
			double myGoalX = (GlobalVar.teamId == 0) ? -1500.0 : 1500.0;
			double oppGoalX = (GlobalVar.teamId == 0) ? 1500.0 : -1500.0;
			
			// 计算我方鱼到球的距离
			double distFishToBall = Compute.GetDistance(myFishX, myFishZ, ballX, ballZ);
			
			// 判断位置关系：根据我方球门位置判断是否需要绕行
			// 如果鱼在球和我方球门之间，需要绕到球后方
			bool needDetour = false;
			
			// 计算鱼到我方球门的距离 和 球到我方球门的距离
			double distFishToMyGoal = Math.Abs(myFishX - myGoalX);
			double distBallToMyGoal = Math.Abs(ballX - myGoalX);
			
			// 如果鱼距离我方球门更近，说明鱼在球和我方球门之间，需要绕行
			if (distFishToMyGoal < distBallToMyGoal)
			{
				needDetour = true;
			}
			
			// 情况1：我方鱼 > 对方鱼 > 球 > 我方禁区（对手帮我们推球，继续推进）
			// 如果不需要绕行（球在我方鱼和对方球门之间），直接返回false，让正常逻辑继续推进
			if (!needDetour)
			{
				DebugRecord.ceshi(0, "球在前方，继续推进");
				return false;
			}
			
			// 情况2：我方禁区 > 我方鱼 > 对方鱼 > 球（需要绕行避开对手）
			
			// 计算我方鱼到球的方向
			double angleFishToBall = Compute.GetAngleRad(myFishX, myFishZ, ballX, ballZ);
			
			// 检查两条对手鱼
			for (int oppId = 0; oppId < 2; oppId++)
			{
				double oppX = (double)GlobalVar.OppTeam.Fishes[oppId].PositionMm.X;
				double oppZ = (double)GlobalVar.OppTeam.Fishes[oppId].PositionMm.Z;
				
				// 计算对手到我方鱼的距离
				double distFishToOpp = Compute.GetDistance(myFishX, myFishZ, oppX, oppZ);
				
				// 计算对手到球的距离
				double distOppToBall = Compute.GetDistance(oppX, oppZ, ballX, ballZ);
				
				// 对手必须在我方鱼和球之间
				if (distFishToOpp >= distFishToBall || distOppToBall >= distFishToBall)
				{
					continue;
				}
				
				// 计算我方鱼到对手的方向
				double angleFishToOpp = Compute.GetAngleRad(myFishX, myFishZ, oppX, oppZ);
				
				// 计算角度差
				double angleDiff = Math.Abs(Compute.FormatAngleRad(angleFishToBall - angleFishToOpp));
				
				// 如果对手在路径上（角度差小于30度）且距离较近（小于500mm）
				if (angleDiff < GlobalVar.PI / 6.0 && distFishToOpp < 500.0)
				{
					blockingOppId = oppId;
					
					// 计算绕行方向：选择远离对手的一侧
					// 判断对手在路径的上方还是下方
					double crossProduct = (oppX - myFishX) * (ballZ - myFishZ) - (oppZ - myFishZ) * (ballX - myFishX);
					
					// 计算从对手指向球的方向
					double angleOppToBall = Compute.GetAngleRad(oppX, oppZ, ballX, ballZ);
					
					if (crossProduct > 0)
					{
						// 对手在路径上方，从下方绕行（对手右侧）
						detourAngle = angleOppToBall - GlobalVar.PI / 2.0;
					}
					else
					{
						// 对手在路径下方，从上方绕行（对手左侧）
						detourAngle = angleOppToBall + GlobalVar.PI / 2.0;
					}
					
					detourAngle = Compute.FormatAngleRad(detourAngle);
					return true;
				}
			}
			
			return false;
		}
		
		// 检测是否需要在边界挑球
		public bool IsBoundaryStalemate(int myFishId, int ballId, out int oppId, out double flickDirection)
		{
			oppId = -1;
			flickDirection = 0.0;
			
			// 检查冷却时间
			if (GlobalVar.flick_ball_cooldown[myFishId] > 0)
			{
				GlobalVar.flick_ball_cooldown[myFishId]--;
				GlobalVar.stalemate_timer[myFishId] = 0;  // 冷却期间重置计时器
				return false;
			}
			
			double myFishX = (double)GlobalVar.MyTeam.Fishes[myFishId].PositionMm.X;
			double myFishZ = (double)GlobalVar.MyTeam.Fishes[myFishId].PositionMm.Z;
			double ballX = (double)GlobalVar.balls[ballId].PositionMm.X;
			double ballZ = (double)GlobalVar.balls[ballId].PositionMm.Z;
			
			// 判断我方鱼是否在球附近（<350mm）- 放宽距离判断
			double distMyFishToBall = Compute.GetDistance(myFishX, myFishZ, ballX, ballZ);
			if (distMyFishToBall > 350.0)
			{
				// 不在球附近，重置计时器
				GlobalVar.stalemate_timer[myFishId] = 0;
				return false;
			}
			
			// 检查对手鱼
			bool foundStalemate = false;
			for (int i = 0; i < 2; i++)
			{
				double oppX = (double)GlobalVar.OppTeam.Fishes[i].PositionMm.X;
				double oppZ = (double)GlobalVar.OppTeam.Fishes[i].PositionMm.Z;
				
				// 对手也在球附近（<350mm）- 放宽距离判断
				double distOppToBall = Compute.GetDistance(oppX, oppZ, ballX, ballZ);
				if (distOppToBall > 350.0)
				{
					continue;
				}
				
				// 判断是否在边界对峙（Z方向）- 放宽到700mm，更容易触发
				bool isZBoundary = Math.Abs(ballZ) > 700.0;
				double myFishRelativeZ = myFishZ - ballZ;
				double oppRelativeZ = oppZ - ballZ;
				bool isZStalemate = (myFishRelativeZ * oppRelativeZ < 0);
				
				// 判断是否在X方向对峙（双方在球的左右两侧推球）
				double myFishRelativeX = myFishX - ballX;
				double oppRelativeX = oppX - ballX;
				bool isXStalemate = (myFishRelativeX * oppRelativeX < 0);
				
				// 如果在边界对峙（Z方向）或X方向对峙
				if ((isZBoundary && isZStalemate) || isXStalemate)
				{
					foundStalemate = true;
					// 检测到对峙，增加计时器
					GlobalVar.stalemate_timer[myFishId]++;
					
					// 僵持时间达到20秒（假设100回合/秒，即2000回合）
					if (GlobalVar.stalemate_timer[myFishId] >= 2000)
					{
						oppId = i;
						
						// 计算挑球方向
						if (isZBoundary && isZStalemate)
						{
							// Z边界对峙：往场地中央挑（远离边界）
							if (ballZ > 0)
							{
								flickDirection = -GlobalVar.PI / 2.0;
							}
							else
							{
								flickDirection = GlobalVar.PI / 2.0;
							}
						}
						else if (isXStalemate)
						{
							if (Math.Abs(oppZ - ballZ) > 50.0)
							{
								if (oppZ > ballZ)
								{
									flickDirection = -GlobalVar.PI / 2.0;
								}
								else
								{
									flickDirection = GlobalVar.PI / 2.0;
								}
							}
							else
							{
								flickDirection = (myFishZ > 0) ? -GlobalVar.PI / 2.0 : GlobalVar.PI / 2.0;
							}
						}
						
						DebugRecord.ceshi(0, "僵持时间达到20秒，触发挑球", (float)GlobalVar.stalemate_timer[myFishId]);
						return true;
					}
					
					// 僵持中但未达到20秒，不触发挑球
					break;  // 找到一个对峙的对手就够了，退出循环
				}
			}
			
			// 如果找到了对峙，保持计时器；否则重置
			if (!foundStalemate)
			{
				// 没有检测到对峙，重置计时器
				GlobalVar.stalemate_timer[myFishId] = 0;
			}
			
			return false;
		}
		
		// 执行边界挑球动作
		public void FlickBallAtBoundary(int myFishId, int ballId, double flickDirection)
		{
			double myFishX = (double)GlobalVar.MyTeam.Fishes[myFishId].PositionMm.X;
			double myFishZ = (double)GlobalVar.MyTeam.Fishes[myFishId].PositionMm.Z;
			double ballX = (double)GlobalVar.balls[ballId].PositionMm.X;
			double ballZ = (double)GlobalVar.balls[ballId].PositionMm.Z;
			
			// 计算我方鱼到球的距离
			double distToBall = Compute.GetDistance(myFishX, myFishZ, ballX, ballZ);
			
			// 计算挑球目标点：从球的位置沿挑球方向延伸700mm（更大力度！）
			double flickTargetX = ballX + 700.0 * Math.Cos(flickDirection);
			double flickTargetZ = ballZ + 700.0 * Math.Sin(flickDirection);
			
			// 如果已经推过球（距离球>400mm，说明球被推开了）
			if (distToBall > 400.0)
			{
				// 已经完成挑球，恢复正常状态
				GlobalVar.flick_ball_stage[myFishId] = 0;
				GlobalVar.flick_ball_cooldown[myFishId] = 3000;  // 30秒冷却（假设100回合/秒）
				GlobalVar.stalemate_timer[myFishId] = 0;  // 重置僵持计时器
				DebugRecord.ceshi(0, "挑球完成，进入冷却");
			}
			else
			{
				// 直接冲向球，穿过球到达目标点（高速冲刺）
				this.Position(myFishId, flickTargetX, flickTargetZ, 314.0);
				DebugRecord.ceshi(0, "正在挑球冲刺，目标方向", (float)(flickDirection * 180.0 / GlobalVar.PI));
			}
		}
		
		// 绕过对手到达球后方
		public void DetourAroundOpponent(int myFishId, int ballId, int blockingOppId, double detourAngle)
		{
			double myFishX = (double)GlobalVar.MyTeam.Fishes[myFishId].PositionMm.X;
			double myFishZ = (double)GlobalVar.MyTeam.Fishes[myFishId].PositionMm.Z;
			double ballX = (double)GlobalVar.balls[ballId].PositionMm.X;
			double ballZ = (double)GlobalVar.balls[ballId].PositionMm.Z;
			double oppX = (double)GlobalVar.OppTeam.Fishes[blockingOppId].PositionMm.X;
			double oppZ = (double)GlobalVar.OppTeam.Fishes[blockingOppId].PositionMm.Z;
			
			// 计算绕行距离：对手半径 + 安全距离（基于鱼长220mm）
			double detourDistance = 200.0;
			
			// 计算绕行中间点
			double detourX = oppX + detourDistance * Math.Cos(detourAngle);
			double detourZ = oppZ + detourDistance * Math.Sin(detourAngle);
			
			// 计算我方鱼到绕行点的距离
			double distToDetour = Compute.GetDistance(myFishX, myFishZ, detourX, detourZ);
			
			// 计算绕行点到球的距离
			double distDetourToBall = Compute.GetDistance(detourX, detourZ, ballX, ballZ);
			
			// 如果已经过了绕行点，直接去球
			if (distToDetour < 100.0 || distDetourToBall > Compute.GetDistance(myFishX, myFishZ, ballX, ballZ))
			{
				// 已经绕过对手，直接去球后方（高速冲刺）
				// 计算我方球门位置（根据teamId判断）
				double myGoalX = (GlobalVar.teamId == 0) ? -1500.0 : 1500.0;
				double oppGoalX = (GlobalVar.teamId == 0) ? 1500.0 : -1500.0;
				
				// 计算从球指向对方球门的方向（推球方向）
				double angleBallToOppGoal = Compute.GetAngleRad(ballX, ballZ, oppGoalX, 0.0);
				
				// 球后方推球点：在球的后方（远离我方球门一侧），距离球80mm
				double pushPointX = ballX - 80.0 * Math.Cos(angleBallToOppGoal);
				double pushPointZ = ballZ - 80.0 * Math.Sin(angleBallToOppGoal);
				
				this.Position(myFishId, pushPointX, pushPointZ, 314.0);
				DebugRecord.ceshi(0, "绕行完成，前往球后方");
			}
			else
			{
				// 前往绕行点（高速绕行）
				this.Position(myFishId, detourX, detourZ, 314.0);
				DebugRecord.ceshi(0, "正在绕行对手", (float)blockingOppId);
			}
		}

		// 3002-3048回合特殊选球策略：选择对方半场非小禁区的球
		public int ChoseBall_OppHalf(int fishID)
		{
			DebugRecord.ceshi(0, "被调用对方半场选球");
			int num = GlobalVar.Bringing_BallID[fishID];
			bool flag = -1 == num || GlobalVar.balls[num].PositionMm.X <= 0f || this.whether_in_oppforbiddenarea_reduce((double)GlobalVar.balls[num].PositionMm.X, (double)GlobalVar.balls[num].PositionMm.Z) || GlobalVar.leftScore[num] == 1 || GlobalVar.Bringing_BallID[1 - fishID] == num;
			if (flag)
			{
				double num2 = 4000.0;
				int num3 = -1;
				// 优先选择3分球（0-2号）
				for (int i = 0; i < 3; i++)
				{
					bool flag2 = GlobalVar.balls[i].PositionMm.X > 0f && !this.whether_in_oppforbiddenarea_reduce((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z) && GlobalVar.leftScore[i] != 1 && GlobalVar.Bringing_BallID[1 - fishID] != i;
					if (flag2)
					{
						double num4 = this.juli((double)GlobalVar.balls[i].PositionMm.X, (double)GlobalVar.balls[i].PositionMm.Z, (double)GlobalVar.MyTeam.Fishes[fishID].PositionMm.X, (double)GlobalVar.MyTeam.Fishes[fishID].PositionMm.Z);
						if (num4 < num2)
						{
							num2 = num4;
							num3 = i;
						}
					}
				}
				if (num3 != -1)
				{
					GlobalVar.Bringing_BallID[fishID] = num3;
					return num3;
				}
				// 其次选择2分球（7-8号）
				num2 = 4000.0;
				for (int j = 7; j < 9; j++)
				{
					bool flag3 = GlobalVar.balls[j].PositionMm.X > 0f && !this.whether_in_oppforbiddenarea_reduce((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z) && GlobalVar.leftScore[j] != 1 && GlobalVar.Bringing_BallID[1 - fishID] != j;
					if (flag3)
					{
						double num4 = this.juli((double)GlobalVar.balls[j].PositionMm.X, (double)GlobalVar.balls[j].PositionMm.Z, (double)GlobalVar.MyTeam.Fishes[fishID].PositionMm.X, (double)GlobalVar.MyTeam.Fishes[fishID].PositionMm.Z);
						if (num4 < num2)
						{
							num2 = num4;
							num3 = j;
						}
					}
				}
				if (num3 != -1)
				{
					GlobalVar.Bringing_BallID[fishID] = num3;
					return num3;
				}
				// 最后选择1分球（3-6号）
				num2 = 4000.0;
				for (int k = 3; k < 7; k++)
				{
					bool flag4 = GlobalVar.balls[k].PositionMm.X > 0f && !this.whether_in_oppforbiddenarea_reduce((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z) && GlobalVar.leftScore[k] != 1 && GlobalVar.Bringing_BallID[1 - fishID] != k;
					if (flag4)
					{
						double num4 = this.juli((double)GlobalVar.balls[k].PositionMm.X, (double)GlobalVar.balls[k].PositionMm.Z, (double)GlobalVar.MyTeam.Fishes[fishID].PositionMm.X, (double)GlobalVar.MyTeam.Fishes[fishID].PositionMm.Z);
						if (num4 < num2)
						{
							num2 = num4;
							num3 = k;
						}
					}
				}
				if (num3 != -1)
				{
					GlobalVar.Bringing_BallID[fishID] = num3;
					return num3;
				}
				// 如果对方半场没有合适的球，返回-1
				GlobalVar.Bringing_BallID[fishID] = -1;
				return -1;
			}
			return num;
		}

		private int UpgradeToHigherValueBall(int fishID, int currentBallId)
		{
			if (currentBallId < 0 || currentBallId >= GlobalVar.balls.Length)
			{
				return currentBallId;
			}
			if (GlobalVar.leftScore[currentBallId] == 1 || GlobalVar.Bringing_BallID[1 - fishID] == currentBallId)
			{
				return currentBallId;
			}
			if (this.whether_in_myforbiddenareabig((double)GlobalVar.balls[currentBallId].PositionMm.X))
			{
				return currentBallId;
			}

			int currentValue = this.GetBallValue(currentBallId);
			double currentDistance = this.juli((double)GlobalVar.balls[currentBallId].PositionMm.X, (double)GlobalVar.balls[currentBallId].PositionMm.Z, (double)GlobalVar.MyTeam.Fishes[fishID].PositionMm.X, (double)GlobalVar.MyTeam.Fishes[fishID].PositionMm.Z);
			int bestBallId = currentBallId;
			int bestValue = currentValue;
			double bestDistance = 4000.0;
			for (int ballId = 0; ballId < GlobalVar.balls.Length; ballId++)
			{
				if (this.GetBallValue(ballId) <= currentValue || GlobalVar.leftScore[ballId] == 1 || GlobalVar.Bringing_BallID[1 - fishID] == ballId)
				{
					continue;
				}
				if (this.whether_in_myforbiddenarea_reduce((double)GlobalVar.balls[ballId].PositionMm.X, (double)(Math.Abs(GlobalVar.balls[ballId].PositionMm.Z) - 30f)) || this.whether_in_oppforbiddenareabig((double)GlobalVar.balls[ballId].PositionMm.X, (double)GlobalVar.balls[ballId].PositionMm.Z))
				{
					continue;
				}
				double candidateDistance = this.juli((double)GlobalVar.balls[ballId].PositionMm.X, (double)GlobalVar.balls[ballId].PositionMm.Z, (double)GlobalVar.MyTeam.Fishes[fishID].PositionMm.X, (double)GlobalVar.MyTeam.Fishes[fishID].PositionMm.Z);
				int candidateValue = this.GetBallValue(ballId);
				if (candidateDistance <= currentDistance + 420.0 && (candidateValue > bestValue || (candidateValue == bestValue && candidateDistance < bestDistance)))
				{
					bestBallId = ballId;
					bestValue = candidateValue;
					bestDistance = candidateDistance;
				}
			}
			if (bestBallId != currentBallId)
			{
				GlobalVar.whether_change_to_test3[fishID] = 0;
				GlobalVar.Bringing_BallID[fishID] = bestBallId;
				DebugRecord.ceshi(5, "higher-value target upgrade", (float)bestBallId);
			}
			return bestBallId;
		}

		private int GetBallValue(int ballId)
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

		// 计算己方半场球的总分
		public int GetMyHalfBallScore()
		{
			int score = 0;
			for (int i = 0; i < 9; i++)
			{
				// 球在己方半场（X<0）且未被得分
				if (GlobalVar.balls[i].PositionMm.X < 0f && GlobalVar.leftScore[i] != 1)
				{
					if (i == 0 || i == 1 || i == 2)
					{
						score += 3; // 3分球
					}
					else if (i == 7 || i == 8)
					{
						score += 2; // 2分球
					}
					else
					{
						score += 1; // 1分球
					}
				}
			}
			return score;
		}

		// Token: 0x04000001 RID: 1
		private int previous_w = 7;

		// Token: 0x04000002 RID: 2
		private int current_w = 7;

		// Token: 0x04000003 RID: 3
		private int boundary_dribbleact_constdir = 0;
	}
}
