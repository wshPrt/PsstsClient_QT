namespace PsstsClient.Bll
{
    public class ScreenInfo
    {
        /// <summary>
        /// 屏幕宽度
        /// </summary>
        public static int ScreenWidth { get; set; }

        /// <summary>
        /// 屏幕高度
        /// </summary>
        public static int ScreenHeight { get; set; }
        /// <summary>
        /// 原宽度
        /// </summary>
        private static int oWidth = 1024;
        /// <summary>
        /// 原高度
        /// </summary>
        private static int oHeight = 768;

        /// <summary>
        /// 宽度比率
        /// </summary>
        public static double OverrideWidth { get; set; }

        /// <summary>
        /// 高度比率
        /// </summary>
        public static double OverrideHeight { get; set; }

        public static int getXSize(int oldsize)
        {
            double oveSize = (double)ScreenWidth / oWidth;
            int newSize = (int)(oldsize * oveSize);
            return newSize;
        }

        public static int getYSize(int oldsize)
        {
            double oveSize = (double)ScreenHeight / oHeight;
            int newSize = (int)(oldsize * oveSize);
            return newSize;
        }
    }
}