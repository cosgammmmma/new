using System;

namespace URWPGSim2D.Strategy
{
	// Token: 0x02000006 RID: 6
	public class Point2D
	{
		// Token: 0x06000086 RID: 134 RVA: 0x00021920 File Offset: 0x0001FB20
		public Point2D()
		{
			this.x = 0.0;
			this.z = 0.0;
		}

		// Token: 0x06000087 RID: 135 RVA: 0x00021971 File Offset: 0x0001FB71
		public Point2D(double xx, double zz)
		{
			this.x = xx;
			this.z = zz;
		}

		// Token: 0x040000B8 RID: 184
		public double x = 0.0;

		// Token: 0x040000B9 RID: 185
		public double z = 0.0;
	}
}
