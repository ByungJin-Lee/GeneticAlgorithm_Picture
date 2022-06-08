using System.Collections;

namespace Genetic
{
    class PictureUnit
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
    }

    class PictureGeneBluePrint : GeneBluePrint
    {
        public PictureGeneBluePrint(uint length) : base(length)
        {

        }
        protected override object GetUnit()
        {
            return PictureUnit.GetRndUnit();
        }
        protected override ArrayList Mutate(ArrayList lhs)
        {
            throw new NotImplementedException();
        }
        protected override ArrayList Overcross(ArrayList lhs, ArrayList rhs)
        {
            throw new NotImplementedException();
        }
    }
}
