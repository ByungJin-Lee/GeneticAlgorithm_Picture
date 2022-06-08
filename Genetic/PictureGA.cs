using System.Collections;

namespace Genetic
{
    public class PictureUnit
    { 
        private static Random random = new Random();

        public Color color;

        public static PictureUnit GetRndUnit()
        {
            int c = random.Next(256);
            return new PictureUnit()
            {
                color = Color.FromArgb(c,c,c)
                //color = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)),
            };
        }
    }

    class PictureGeneBluePrint : GeneBluePrint
    {
        public PictureGeneBluePrint(int length, int maskLength, int elite, int mutation) : base(length, maskLength, elite, mutation)
        {
            for(int i = 0; i < maskLength; i++)
            {
                this.MaskPattern[i] = GeneBluePrint.GenerateBinaryMask(length);
                System.Diagnostics.Trace.WriteLine(this.MaskPattern[i]);
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
