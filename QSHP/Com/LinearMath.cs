using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QSHP.Com
{
    public static class LinearMath
    {

        public static double LinearScaleValue(double[] arrayX, double[] arrayY)
        {
            double scale = 0;
            if (arrayX.Length == arrayY.Length && arrayX.Length > 1)
            {
                double averX = arrayX.Average();
                double averY = arrayY.Average();
                double Molecular = 0;
                double Denominator = 0;
                for (int i = 0; i < arrayX.Length; i++)
                {
                    Molecular += (arrayX[i] - averX) * (arrayY[i] - averY);
                    Denominator += System.Math.Pow((arrayX[i] - averX), 2);
                }
                scale = Molecular / Denominator;
            }
            return scale;
        }

        public static double LinearScaleValue(double[] arrayY)
        {
            double scale = 0;
            double t1 = 0, t2 = 0, t3 = 0, t4 = 0;
            if (arrayY.Length > 1)
            {
                for (int i = 0; i < arrayY.Length; i++)
                {
                    t1 += i * i;
                    t2 += i;
                    t3 += i * arrayY[i];
                    t4 += arrayY[i];
                }
                scale = System.Math.Abs((t3 * arrayY.Length - t2 * t4) / (t1 * arrayY.Length - t2 * t2));
            }
            return scale;
        }

        public unsafe static double LinearScaleValue(byte* arrayY, int num)
        {
            double scale = 0;
            double t1 = 0, t2 = 0, t3 = 0, t4 = 0;
            if (num > 1)
            {
                for (int i = 0; i < num; i++)
                {
                    t1 += i * i;
                    t2 += i;
                    t3 += i * arrayY[i];
                    t4 += arrayY[i];
                }
                scale = System.Math.Abs((t3 * num - t2 * t4) / (t1 * num - t2 * t2));
            }
            return scale;
        }

        public static double LinearOffsetResult(double scale, double averX, double averY)
        {
            double offset = 0;
            offset = averY - scale * averX;
            return offset;
        }

    }

    internal class LinearSize
    {
        int min;

        public int Min
        {
            get { return min; }
            set { min = value; }
        }
        int max;

        public int Max
        {
            get { return max; }
            set { max = value; }
        }

        public int Count
        {
            get
            {
                return System.Math.Abs(max - min);
            }
        }
        public void Clear()
        {
            max = min;
        }
    }
}
