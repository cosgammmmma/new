using System;
using URWPGSim2D.Common;

namespace URWPGSim2D.Strategy
{
	// Token: 0x02000007 RID: 7
	public class MyFishRobot
	{
		// Token: 0x06000088 RID: 136 RVA: 0x000219A8 File Offset: 0x0001FBA8
		public void UpdateOne()
		{
			double num = (double)GlobalVar.MyTeam.Fishes[this.fishId].VelocityMmPs;
			double num2 = (double)GlobalVar.MyTeam.Fishes[this.fishId].AngularVelocityRadPs;
			bool flag = Math.Abs(num - (this.Last_v * 0.9 + GlobalVar.vTable[this.LastVCode] * 0.1)) > 0.0001 && Math.Abs(num - GlobalVar.vTable[this.LastVCode]) < 0.0001;
			if (flag)
			{
				this.LastStadyVCode = this.LastVCode;
			}
			bool flag2 = Math.Abs(num2 - (this.Last_w * 0.9 + GlobalVar.tTable[this.LastTCode] * 0.1)) > 0.0001 && Math.Abs(num2 - GlobalVar.tTable[this.LastTCode]) < 0.0001;
			if (flag2)
			{
				this.LastStadyTCode = this.LastTCode;
			}
		}

		// Token: 0x06000089 RID: 137 RVA: 0x00021AC8 File Offset: 0x0001FCC8
		public void UpdateTwo()
		{
			double last_v = (double)GlobalVar.MyTeam.Fishes[this.fishId].VelocityMmPs;
			int vcode = GlobalVar.decisions[this.fishId].VCode;
			double last_w = (double)GlobalVar.MyTeam.Fishes[this.fishId].AngularVelocityRadPs;
			int tcode = GlobalVar.decisions[this.fishId].TCode;
			bool flag = this.LastStadyVCode == vcode;
			if (flag)
			{
				this.LastStadyVCode = this.LastVCode;
			}
			this.LastVCode = vcode;
			this.Last_v = last_v;
			bool flag2 = this.LastStadyTCode == tcode;
			if (flag2)
			{
				this.LastStadyTCode = this.LastTCode;
			}
			this.LastTCode = tcode;
			this.Last_w = last_w;
		}

		// Token: 0x0600008A RID: 138 RVA: 0x00021B8C File Offset: 0x0001FD8C
		public void SetInit()
		{
			this.p_LastStadyVCode = this.LastStadyVCode;
			this.p_LastVCode = this.LastVCode;
			this.p_Last_v = this.Last_v;
			this.p_now_v = (double)GlobalVar.MyTeam.Fishes[this.fishId].VelocityMmPs;
			this.p_LastTCode = this.LastTCode;
			this.p_LastStadyTCode = this.LastStadyTCode;
			this.p_Last_w = this.Last_w;
			this.p_now_w = (double)GlobalVar.MyTeam.Fishes[this.fishId].AngularVelocityRadPs;
		}

		// Token: 0x0600008B RID: 139 RVA: 0x00021C24 File Offset: 0x0001FE24
		public void NextStatus(Decision decision)
		{
			int vcode = decision.VCode;
			int tcode = decision.TCode;
			bool flag = this.p_LastStadyVCode == vcode;
			if (flag)
			{
				this.p_LastStadyVCode = this.p_LastVCode;
			}
			int num = this.p_LastStadyVCode;
			double num2 = this.p_now_v * 0.9 + GlobalVar.vTable[decision.VCode] * 0.1;
			double num3 = Math.Abs(GlobalVar.vTable[num] - GlobalVar.vTable[decision.VCode]);
			bool flag2 = (num2 >= GlobalVar.vTable[decision.VCode] - 0.1 * num3 && num2 <= GlobalVar.vTable[decision.VCode]) || (num2 <= GlobalVar.vTable[decision.VCode] + 0.1 * num3 && num2 >= GlobalVar.vTable[decision.VCode]);
			if (flag2)
			{
				num2 = GlobalVar.vTable[decision.VCode];
				this.p_LastStadyVCode = decision.VCode;
			}
			this.p_Last_v = this.p_now_v;
			this.p_LastVCode = decision.VCode;
			this.p_now_v = num2;
			bool flag3 = this.p_LastStadyTCode == tcode;
			if (flag3)
			{
				this.p_LastStadyTCode = this.p_LastTCode;
			}
			int num4 = this.p_LastStadyTCode;
			double num5 = this.p_now_w * 0.9 + GlobalVar.tTable[decision.TCode] * 0.1;
			double num6 = Math.Abs(GlobalVar.tTable[num4] - GlobalVar.tTable[decision.TCode]);
			bool flag4 = (num5 >= GlobalVar.tTable[decision.TCode] - 0.1 * num6 && num5 <= GlobalVar.tTable[decision.TCode]) || (num5 <= GlobalVar.tTable[decision.TCode] + 0.1 * num6 && num5 >= GlobalVar.tTable[decision.TCode]);
			if (flag4)
			{
				num5 = GlobalVar.tTable[decision.TCode];
				this.p_LastStadyTCode = decision.TCode;
			}
			this.p_Last_w = this.p_now_w;
			this.p_LastTCode = decision.TCode;
			this.p_now_w = num5;
		}

		// Token: 0x040000BA RID: 186
		public int fishId = 0;

		// Token: 0x040000BB RID: 187
		public RoboFish rf = null;

		// Token: 0x040000BC RID: 188
		public int LastStadyVCode = 0;

		// Token: 0x040000BD RID: 189
		public int LastVCode = 0;

		// Token: 0x040000BE RID: 190
		public int LastChangeVCode = 0;

		// Token: 0x040000BF RID: 191
		public double Last_v = 0.0;

		// Token: 0x040000C0 RID: 192
		public int LastTCode = 7;

		// Token: 0x040000C1 RID: 193
		public int LastStadyTCode = 7;

		// Token: 0x040000C2 RID: 194
		public int LastChangeTCode = 7;

		// Token: 0x040000C3 RID: 195
		public double Last_w = 0.0;

		// Token: 0x040000C4 RID: 196
		public int p_LastStadyVCode = 0;

		// Token: 0x040000C5 RID: 197
		public int p_LastVCode = 0;

		// Token: 0x040000C6 RID: 198
		public double p_Last_v = 0.0;

		// Token: 0x040000C7 RID: 199
		public double p_now_v = 0.0;

		// Token: 0x040000C8 RID: 200
		public int p_LastTCode = 7;

		// Token: 0x040000C9 RID: 201
		public int p_LastStadyTCode = 7;

		// Token: 0x040000CA RID: 202
		public double p_Last_w = 0.0;

		// Token: 0x040000CB RID: 203
		public double p_now_w = 0.0;

		// Token: 0x040000CC RID: 204
		public int next_x = 0;

		// Token: 0x040000CD RID: 205
		public int next_z = 0;

		// Token: 0x040000CE RID: 206
		public int next_rad = 0;

		// Token: 0x040000CF RID: 207
		public int next_top_x = 0;

		// Token: 0x040000D0 RID: 208
		public int next_top_z = 0;
	}
}
