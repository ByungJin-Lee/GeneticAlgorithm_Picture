using System.Collections;

namespace Genetic
{
    public class PictureUnit
    {
        public static int pHorizontalMax, pVerticalMax, widthMax, heightMax;
        private static Random random = new Random();

        public Point point;
        public Color color;
        public int width, height;

        public static PictureUnit GetRndUnit()
        {
            return new PictureUnit()
            {
                point = new Point(random.Next(pHorizontalMax), random.Next(pVerticalMax)),
                color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)),
                width = random.Next(widthMax),
                height = random.Next(heightMax)
            };
        }

        public static void SetLimit(int pHorizontalMax, int pVerticalMax, int widthMax, int heightMax)
        {
            PictureUnit.pHorizontalMax = pHorizontalMax;
            PictureUnit.pVerticalMax = pVerticalMax;
            PictureUnit.widthMax = widthMax;
            PictureUnit.heightMax = heightMax;
        }
    }

    class PictureGeneBluePrint : GeneBluePrint
    {
        public int Height, Width;

        public PictureGeneBluePrint(uint length, uint maskLength, uint elite, uint mutation, int Width, int Height) : base(length, maskLength, elite, mutation)
        {
            PictureUnit.SetLimit(Width, Height, Width, Height);
            this.Height = Height;
            this.Width = Width;
            for(int i = 0; i < maskLength; i++)
            {
                this.MaskPattern[i] = GeneBluePrint.GenerateBinaryMask(length);
            }
        }
        public override object GetUnit()
        {
            return PictureUnit.GetRndUnit();
        }
        //public override ArrayList Mutate(ArrayList lhs)
        //{
        //    throw new NotImplementedException();
        //}
        //public override List<ArrayList> Overcross(ArrayList lhs, ArrayList rhs)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
