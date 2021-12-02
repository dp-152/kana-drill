namespace kanaDrill
{
    class levelEngine
    {
        
        public static ushort[]  levelPoints = { 1500, 3000, 4500, 6000, 7500, 9000, 10500, 12000 };
        public static ushort    currPoints  = 0;
        public static byte      levelIndex  = 0;
        public static int[]     levelTimer  = { 55, 50, 45, 40, 35, 30, 25, 20 };


        static public void levelChange(ref byte levelIndex)
        {
            if (levelIndex < (levelPoints.Length - 1) && currPoints >= levelPoints[levelIndex])
                levelIndex = (byte)(levelIndex + 1);

            if (levelIndex > 0 && currPoints < levelPoints[levelIndex - 1])
                levelIndex = (byte)(levelIndex - 1);
        }
        static public void addLevel(ref byte levelIndex, ref ushort currPoints)
        {
            if (levelIndex < (levelPoints.Length - 1))
            {
                levelIndex = (byte)(levelIndex + 1);
                currPoints = levelPoints[levelIndex - 1];
            }
        }
        static public void subtLevel(ref byte levelIndex, ref ushort currPoints)
        {
            if (levelIndex > 0)
            {
                levelIndex = (byte)(levelIndex - 1);
                if (levelIndex == 0)
                    currPoints = 0;

                else
                    currPoints = (levelPoints[levelIndex - 1]);
            }
        }
        static public void clearLevel(ref byte levelIndex, ref ushort currPoints)
        {
            levelIndex = 0;
            currPoints = 0;
        }
        static byte add = 100;
        static byte dw = 200;
        static short dt = 300;
        static public void deductWrong(ref ushort currPoints)
        {
            if ((currPoints - dw) >= 0)
                currPoints = (ushort)(currPoints - dw);

            else
                currPoints = 0;
        }
        static public void deductTimeout(ref ushort currPoints)
        {
            if ((currPoints - dt) >= 0)
                currPoints = (ushort)(currPoints - dt);

            else
                currPoints = 0;
        }
        static public void add100(ref ushort currPoints)
        {
            if (currPoints < 65500)
                currPoints = (ushort)(currPoints + add);
        }
    }
}
