using System;
using URWPGSim2D.Common;

namespace URWPGSim2D.Strategy
{
	// Token: 0x02000003 RID: 3
	internal class Compute
	{
		// Token: 0x0600005D RID: 93 RVA: 0x0001E4E8 File Offset: 0x0001C6E8
		public static bool IsRadDuring(double rad11, double rad22, double rad33)
		{
			double ang = rad11 * 180.0 / GlobalVar.PI;
			double ang2 = rad22 * 180.0 / GlobalVar.PI;
			double ang3 = rad33 * 180.0 / GlobalVar.PI;
			double num = Compute.FormatAngle(ang);
			double num2 = Compute.FormatAngle(ang2);
			double num3 = Compute.FormatAngle(ang3);
			bool flag = Math.Abs(num) + Math.Abs(num2) < 180.0 || (num > 0.0 && num2 > 0.0) || (num < 0.0 && num2 < 0.0);
			bool result;
			if (flag)
			{
				bool flag2 = (num > num3 && num2 < num3) || (num < num3 && num2 > num3);
				result = flag2;
			}
			else
			{
				bool flag3 = (num3 > num && num3 > num2) || (num3 < num && num3 < num2);
				result = flag3;
			}
			return result;
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0001E5F8 File Offset: 0x0001C7F8
		public static double differ(double rad1, double rad2)
		{
			rad1 = Compute.FormatAngleRad(rad1);
			rad2 = Compute.FormatAngleRad(rad2);
			double pi = GlobalVar.PI;
			bool flag = Compute.IsAngleDuring(-180.0, rad1 * 180.0 / pi, rad2 * 180.0 / pi);
			double result;
			if (flag)
			{
				bool flag2 = rad1 > 0.0;
				if (flag2)
				{
					result = rad1 - 2.0 * pi - rad2;
				}
				else
				{
					result = rad2 - rad1 + 2.0 * pi;
				}
			}
			else
			{
				result = rad1 - rad2;
			}
			return result;
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0001E688 File Offset: 0x0001C888
		public static bool equals(double a1, double a2)
		{
			return Math.Abs(a1 - a2) < 1E-05;
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0001E6B8 File Offset: 0x0001C8B8
		public static int MinPos(double a1, double a2, double a3)
		{
			bool flag = a1 < a2;
			double num;
			int result;
			if (flag)
			{
				num = a1;
				result = 1;
			}
			else
			{
				num = a2;
				result = 2;
			}
			bool flag2 = num > a3;
			if (flag2)
			{
				result = 3;
			}
			return result;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0001E6F4 File Offset: 0x0001C8F4
		public static Point2D GetLineAcrossPoint(double x1, double y1, double ang1, double x2, double y2, double ang2)
		{
			Point2D point2D = new Point2D();
			double pi = GlobalVar.PI;
			bool flag = x1 > 2200.0 || x1 < -2200.0 || y1 > 1600.0 || y1 < -1600.0 || x2 > 2200.0 || x2 < -2200.0 || y2 > 1600.0 || y2 < -1600.0;
			Point2D result;
			if (flag)
			{
				point2D.x = 10000.0;
				point2D.z = 10000.0;
				result = point2D;
			}
			else
			{
				bool flag2 = Compute.equals(x1, x2) && Compute.equals(y1, y2);
				if (flag2)
				{
					point2D.x = 0.0;
					point2D.z = 0.0;
					result = point2D;
				}
				else
				{
					while (ang1 < -180.0)
					{
						ang1 += 360.0;
					}
					while (ang1 > 180.0)
					{
						ang1 -= 360.0;
					}
					while (ang2 < -180.0)
					{
						ang2 += 360.0;
					}
					while (ang2 > 180.0)
					{
						ang2 -= 360.0;
					}
					bool flag3 = ang1 < 0.0;
					if (flag3)
					{
						ang1 += 180.0;
					}
					bool flag4 = ang2 < 0.0;
					if (flag4)
					{
						ang2 += 180.0;
					}
					bool flag5 = Compute.equals(ang2, ang1);
					if (flag5)
					{
						bool flag6 = Compute.equals(x1, x2);
						if (flag6)
						{
							bool flag7 = Compute.equals(ang1, 90.0);
							if (flag7)
							{
								point2D.x = 0.0;
								point2D.z = 0.0;
							}
							else
							{
								point2D.x = 10000.0;
								point2D.z = 10000.0;
							}
						}
						else
						{
							bool flag8 = Compute.equals(Math.Tan(ang1 * pi / 180.0), (y2 - y1) / (x2 - x1));
							if (flag8)
							{
								point2D.x = 0.0;
								point2D.z = 0.0;
							}
							else
							{
								point2D.x = 10000.0;
								point2D.z = 10000.0;
							}
						}
					}
					else
					{
						bool flag9 = Compute.equals(90.0, ang1);
						if (flag9)
						{
							point2D.x = x1;
							double num = Math.Tan(ang2 * pi / 180.0);
							point2D.z = num * x1 + (y2 - num * x2);
						}
						else
						{
							bool flag10 = Compute.equals(90.0, ang2);
							if (flag10)
							{
								point2D.x = x2;
								double num2 = Math.Tan(ang1 * pi / 180.0);
								point2D.z = num2 * x1 + (y1 - num2 * x2);
							}
							else
							{
								double num3 = Math.Tan(ang1 * pi / 180.0);
								double num4 = Math.Tan(ang2 * pi / 180.0);
								point2D.x = (y1 - num3 * x1 - (y2 - num4 * x2)) / (num4 - num3);
								point2D.z = num3 * point2D.x + (y1 - num3 * x1);
							}
						}
					}
					result = point2D;
				}
			}
			return result;
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0001EA7C File Offset: 0x0001CC7C
		public static Point2D GetLineAcrossCircle(double x1, double z1, double rad, double x2, double z2, double r)
		{
			Point2D point2D = new Point2D();
			double num = Math.Tan(rad);
			double num2 = num * num + 1.0;
			double num3 = -2.0 * (x2 + num * num * x1 - num * z1 + num * z2);
			double num4 = x2 * x2 + (num * x1 - z1 + z2) * (num * x1 - z1 + z2) - r * r;
			bool flag = num3 * num3 - 4.0 * num2 * num4 <= 0.0;
			if (flag)
			{
				point2D.x = 10000.0;
				point2D.z = 10000.0;
			}
			else
			{
				Point2D point2D2 = new Point2D();
				Point2D point2D3 = new Point2D();
				point2D2.x = (-num3 + Math.Sqrt(Math.Pow(num3, 2.0) - 4.0 * num2 * num4)) / (2.0 * num2);
				point2D3.x = (-num3 - Math.Sqrt(Math.Pow(num3, 2.0) - 4.0 * num2 * num4)) / (2.0 * num2);
				point2D2.z = num * (point2D2.x - x1) + z1;
				point2D3.z = num * (point2D3.x - x1) + z1;
				double angleRad = Compute.GetAngleRad(x1, z1, point2D2.x, point2D2.z);
				bool flag2 = angleRad * rad < 0.0;
				if (flag2)
				{
					point2D.x = 10000.0;
					point2D.z = 10000.0;
				}
				else
				{
					point2D.x = point2D2.x;
					point2D.z = point2D2.z;
					bool flag3 = Compute.GetDistance(x1, z1, point2D.x, point2D.z) > Compute.GetDistance(x1, z1, point2D3.x, point2D3.z);
					if (flag3)
					{
						point2D.x = point2D3.x;
						point2D.z = point2D3.z;
					}
				}
			}
			return point2D;
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0001ECA4 File Offset: 0x0001CEA4
		public static bool IsAngleDuring(double ang11, double ang22, double ang33)
		{
			double num = Compute.FormatAngle(ang11);
			double num2 = Compute.FormatAngle(ang22);
			double num3 = Compute.FormatAngle(ang33);
			bool flag = Math.Abs(num) + Math.Abs(num2) < 180.0 || (num > 0.0 && num2 > 0.0) || (num < 0.0 && num2 < 0.0);
			bool result;
			if (flag)
			{
				bool flag2 = (num > num3 && num2 < num3) || (num < num3 && num2 > num3);
				result = flag2;
			}
			else
			{
				bool flag3 = (num3 > num && num3 > num2) || (num3 < num && num3 < num2);
				result = flag3;
			}
			return result;
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0001ED6C File Offset: 0x0001CF6C
		public static double GetAngle(double point1_x, double point1_z, double point2_x, double point2_z)
		{
			return Math.Atan2(point2_z - point1_z, point2_x - point1_x) / GlobalVar.PI * 180.0;
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0001ED9C File Offset: 0x0001CF9C
		public static double GetAngleRad(double point1_x, double point1_z, double point2_x, double point2_z)
		{
			return Math.Atan2(point2_z - point1_z, point2_x - point1_x);
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0001EDBC File Offset: 0x0001CFBC
		public static double FormatAngle(double ang)
		{
			bool flag = ang > 180.0;
			double result;
			if (flag)
			{
				result = ang - 360.0;
			}
			else
			{
				bool flag2 = ang <= -180.0;
				if (flag2)
				{
					result = ang + 360.0;
				}
				else
				{
					result = ang;
				}
			}
			return result;
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0001EE10 File Offset: 0x0001D010
		public static bool IsLineAcrossCircle(double x1, double z1, double rad, double x2, double z2, double r)
		{
			Point2D point2D = new Point2D();
			double num = Math.Tan(rad);
			double num2 = num * num + 1.0;
			double num3 = -2.0 * (x2 + num * num * x1 - num * z1 + num * z2);
			double num4 = x2 * x2 + (num * x1 - z1 + z2) * (num * x1 - z1 + z2) - r * r;
			bool flag = num3 * num3 - 4.0 * num2 * num4 <= 0.0;
			if (flag)
			{
				point2D.x = 10000.0;
				point2D.z = 10000.0;
			}
			else
			{
				Point2D point2D2 = new Point2D();
				Point2D point2D3 = new Point2D();
				point2D2.x = (-num3 + Math.Sqrt(Math.Pow(num3, 2.0) - 4.0 * num2 * num4)) / (2.0 * num2);
				point2D3.x = (-num3 - Math.Sqrt(Math.Pow(num3, 2.0) - 4.0 * num2 * num4)) / (2.0 * num2);
				point2D2.z = num * (point2D2.x - x1) + z1;
				point2D3.z = num * (point2D3.x - x1) + z1;
				double angleRad = Compute.GetAngleRad(x1, z1, point2D2.x, point2D2.z);
				bool flag2 = angleRad * rad < 0.0;
				if (flag2)
				{
					point2D.x = 10000.0;
					point2D.z = 10000.0;
				}
				else
				{
					point2D.x = point2D2.x;
					point2D.z = point2D2.z;
					bool flag3 = Compute.GetDistance(x1, z1, point2D.x, point2D.z) > Compute.GetDistance(x1, z1, point2D3.x, point2D3.z);
					if (flag3)
					{
						point2D.x = point2D3.x;
						point2D.z = point2D3.z;
					}
				}
			}
			bool flag4 = point2D.x == 10000.0;
			return !flag4;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0001F054 File Offset: 0x0001D254
		public static double FormatAngleRad(double ang)
		{
			bool flag = ang > GlobalVar.PI;
			double result;
			if (flag)
			{
				result = ang - 2.0 * GlobalVar.PI;
			}
			else
			{
				bool flag2 = ang <= -GlobalVar.PI;
				if (flag2)
				{
					result = ang + 2.0 * GlobalVar.PI;
				}
				else
				{
					result = ang;
				}
			}
			return result;
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0001F0AC File Offset: 0x0001D2AC
		public static double GetDistance(double x1, double z1, double x2, double z2)
		{
			return Math.Sqrt((x1 - x2) * (x1 - x2) + (z1 - z2) * (z1 - z2));
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0001F0D4 File Offset: 0x0001D2D4
		public static int TimeForcast(int which, int aim_x, int aim_z, double dv)
		{
			RoboFish roboFish = GlobalVar.MyTeam.Fishes[which];
			float x = roboFish.PositionMm.X;
			float z = roboFish.PositionMm.Z;
			double num = (double)roboFish.VelocityDirectionRad;
			double num2 = (double)roboFish.AngularVelocityRadPs;
			double num3 = Math.Atan2((double)((float)aim_z - z), (double)((float)aim_x - x));
			double num4 = Compute.FormatAngleRad(num3 - num);
			double[] vTable = GlobalVar.vTable;
			double[] tTable = GlobalVar.tTable;
			double num5 = 0.0;
			double num6 = 0.0;
			int num7 = 0;
			int num8 = 0;
			bool flag = num4 > 0.0 * GlobalVar.PI;
			int i;
			if (flag)
			{
				for (i = 0; i < 43; i++)
				{
					num5 += num2 * 0.1;
					num2 = num2 * 0.9 + tTable[15] * 0.1;
					double num9 = 0.0;
					double num10 = num2;
					int num11 = 0;
					while (num10 > 0.0 && num11 < 23)
					{
						num9 += num10;
						num10 = 0.9 * num10 + tTable[0] * 0.1;
						num11++;
					}
					bool flag2 = num9 * 0.1 >= num4 - num5;
					if (flag2)
					{
						break;
					}
				}
				double num12 = num2;
				num8 += i;
				i = 0;
				while (num2 > 0.0 && i < 23)
				{
					num6 += num2 * 0.1;
					num2 = num2 * 0.9 + tTable[0] * 0.1;
					i++;
				}
				num8 += i;
				bool flag3 = num4 > num5 + num6;
				if (flag3)
				{
					double num13 = num4 - num5 - num6;
					i = (int)(num13 / (num12 * 0.1));
					num8 += i;
				}
			}
			bool flag4 = num4 < 0.0 * GlobalVar.PI;
			if (flag4)
			{
				for (i = 0; i < 43; i++)
				{
					num5 += num2 * 0.1;
					num2 = num2 * 0.9 + tTable[0] * 0.1;
					double num9 = 0.0;
					double num14 = num2;
					int num11 = 0;
					while (num14 < 0.0 && num11 < 23)
					{
						num9 += num14;
						num14 = 0.9 * num14 + tTable[15] * 0.1;
						num11++;
					}
					bool flag5 = Math.Abs(num9 * 0.1) >= Math.Abs(num4 - num5);
					if (flag5)
					{
						break;
					}
				}
				double num12 = num2;
				num8 += i;
				i = 0;
				while (num2 < 0.0 && i < 23)
				{
					num6 += num2 * 0.1;
					num2 = num2 * 0.9 + tTable[15] * 0.1;
					i++;
				}
				num8 += i;
				bool flag6 = Math.Abs(num4) > Math.Abs(num5 + num6);
				if (flag6)
				{
					double num13 = num4 - num5 - num6;
					i = (int)(num13 / (num12 * 0.1));
					num8 += i;
				}
			}
			double num15 = Math.Sqrt((double)((x - (float)aim_x) * (x - (float)aim_x) + (z - (float)aim_z) * (z - (float)aim_z)));
			double num16 = (double)roboFish.VelocityMmPs;
			double num17 = 0.0;
			double num18 = 0.0;
			for (i = 0; i < 23; i++)
			{
				num17 += num16 * 0.1;
				num16 = num16 * 0.9 + vTable[15] * 0.1;
				double num19 = num16;
				double num20 = 0.0;
				int num11 = 0;
				while (num19 > dv && num11 < 23)
				{
					num20 += num19 * 0.1;
					num19 *= 0.9;
					num11++;
				}
				bool flag7 = num20 > num15 - num17;
				if (flag7)
				{
					break;
				}
			}
			double num21 = num16;
			num7 += i;
			i = 0;
			while (num16 > dv && i < 23)
			{
				num18 += num16 * 0.1;
				num16 *= 0.9;
				i++;
			}
			num7 += i;
			double num22 = num15 - num17 - num18;
			bool flag8 = num22 > 0.0;
			if (flag8)
			{
				i = (int)(num22 / (num21 * 0.1));
				num7 += i;
			}
			return (int)((double)num7 * 0.9) + (int)((double)num8 * 0.9);
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0001F648 File Offset: 0x0001D848
		public static bool IsDoubleBetween(double x, double limit1, double limit2)
		{
			bool flag = (x - limit1) * (x - limit2) > 0.0;
			return !flag;
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0001F678 File Offset: 0x0001D878
		public static double Angleaver(double angle1, double angle2)
		{
			bool flag = angle1 < 0.0;
			if (flag)
			{
				angle1 += 360.0;
			}
			bool flag2 = angle2 < 0.0;
			if (flag2)
			{
				angle2 += 360.0;
			}
			angle1 = Compute.FormatAngle(0.5 * (angle1 + angle2));
			return angle1;
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0001F6DC File Offset: 0x0001D8DC
		public static double AngleaverRad(double angle1, double angle2)
		{
			bool flag = angle1 < 0.0;
			if (flag)
			{
				angle1 += 2.0 * GlobalVar.PI;
			}
			bool flag2 = angle2 < 0.0;
			if (flag2)
			{
				angle2 += 2.0 * GlobalVar.PI;
			}
			angle1 = Compute.FormatAngle(0.5 * (angle1 + angle2));
			return angle1;
		}

		// Token: 0x0600006E RID: 110 RVA: 0x0001F74C File Offset: 0x0001D94C
		public static Point2D GetRealPosition(int which)
		{
			Point2D point2D = new Point2D();
			Point2D point2D2 = new Point2D();
			Point2D point2D3 = new Point2D();
			Point2D point2D4 = new Point2D();
			Point2D point2D5 = new Point2D();
			Point2D point2D6 = new Point2D();
			Point2D point2D7 = new Point2D();
			point2D7.x = (double)(GlobalVar.MyTeamLast.Fishes[0].PositionMm.X + 1770f);
			point2D7.z = (double)GlobalVar.MyTeamLast.Fishes[0].PositionMm.Z;
			point2D.x = (double)GlobalVar.MyTeam.Fishes[which].PolygonVertices[0].X;
			point2D.z = (double)GlobalVar.MyTeam.Fishes[which].PolygonVertices[0].Z;
			point2D2.x = (double)GlobalVar.MyTeamLast.Fishes[which].PolygonVertices[0].X;
			point2D2.z = (double)GlobalVar.MyTeamLast.Fishes[which].PolygonVertices[0].Z;
			point2D6.x = (double)GlobalVar.MyTeamLast.Fishes[which].PositionMm.X - point2D7.x;
			point2D6.z = (double)GlobalVar.MyTeamLast.Fishes[which].PositionMm.Z - point2D7.z;
			double distance = Compute.GetDistance(point2D.x, point2D.z, point2D2.x, point2D2.z);
			double num = (double)GlobalVar.MyTeamLast.Fishes[which].VelocityMmPs / 10.0;
			double num2 = 110.0;
			double num3 = (double)GlobalVar.MyTeam.Fishes[which].VelocityDirectionRad;
			double num4 = (double)GlobalVar.MyTeamLast.Fishes[which].VelocityDirectionRad;
			bool flag = Math.Abs(distance - num) / distance < 0.15 || distance / num < 0.1;
			if (flag)
			{
				num2 = 110.0 - num;
			}
			else
			{
				point2D3.x = point2D.x - num2 * Math.Cos(num3);
				point2D3.z = point2D.z - num2 * Math.Sin(num3);
				double distance2 = Compute.GetDistance(point2D3.x, point2D3.z, point2D6.x, point2D6.z);
				bool flag2 = distance2 < 5.0;
				if (flag2)
				{
					num2 = 110.0 - num;
				}
			}
			point2D3.x = point2D.x - num2 * Math.Cos(num3);
			point2D3.z = point2D.z - num2 * Math.Sin(num3);
			point2D4.x = point2D.x - num2 * Math.Cos(num4);
			point2D4.z = point2D.z - num2 * Math.Sin(num4);
			point2D5.x = point2D.x - num2 * Math.Cos((double)GlobalVar.MyTeam.Fishes[which].BodyDirectionRad);
			point2D5.z = point2D.z - num2 * Math.Sin((double)GlobalVar.MyTeam.Fishes[which].BodyDirectionRad);
			Point2D point2D8 = new Point2D();
			point2D8.x = (double)(GlobalVar.MyTeam.Fishes[0].PositionMm.X + 1770f);
			point2D8.z = (double)GlobalVar.MyTeam.Fishes[0].PositionMm.Z;
			Point2D point2D9 = new Point2D();
			point2D9.x = (double)GlobalVar.MyTeam.Fishes[which].PositionMm.X - point2D8.x;
			point2D9.z = (double)GlobalVar.MyTeam.Fishes[which].PositionMm.Z - point2D8.z;
			double distance3 = Compute.GetDistance(point2D3.x, point2D3.z, point2D9.x, point2D9.z);
			bool flag3 = distance3 > 5.0;
			if (flag3)
			{
			}
			return point2D3;
		}

		// Token: 0x0600006F RID: 111 RVA: 0x0001FBB0 File Offset: 0x0001DDB0
		public static bool IsAttackInOpening()
		{
			return Math.Abs(GlobalVar.MyTeam.Fishes[4].PositionMm.Z - GlobalVar.MyTeam.Fishes[3].PositionMm.Z) > Math.Abs(GlobalVar.OppTeam.Fishes[4].PositionMm.Z - GlobalVar.OppTeam.Fishes[3].PositionMm.Z);
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0001FC44 File Offset: 0x0001DE44
		public static int IsInBoundary(int which)
		{
			bool flag = GlobalVar.MyTeam.Fishes[which].PositionMm.X >= 1900f;
			int result;
			if (flag)
			{
				result = 2;
			}
			else
			{
				bool flag2 = GlobalVar.MyTeam.Fishes[which].PositionMm.X <= -1900f;
				if (flag2)
				{
					result = 0;
				}
				else
				{
					bool flag3 = GlobalVar.MyTeam.Fishes[which].PositionMm.Z >= 1300f;
					if (flag3)
					{
						result = 3;
					}
					else
					{
						bool flag4 = GlobalVar.MyTeam.Fishes[which].PositionMm.Z <= -1300f;
						if (flag4)
						{
							result = 1;
						}
						else
						{
							result = -1;
						}
					}
				}
			}
			return result;
		}
	}
}
