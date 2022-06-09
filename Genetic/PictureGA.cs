using System.Collections;

namespace Genetic
{
    public class Picture
    {
        public Bitmap originBitmap;
        public int scale, widthLen, heightLen;
        public byte[][] data;
       

        public Picture(Bitmap bitmap, int scale)
        {
            this.scale = scale;
            bitmap = ToGray(bitmap);
            originBitmap = DownScaleTo(bitmap, scale);
            this.widthLen = originBitmap.Width / scale;
            this.heightLen = originBitmap.Height / scale;
            this.data = new byte[widthLen][];
            for(int i = 0; i < widthLen; i++) data[i] = new byte[heightLen];
            
            for(int x = 0; x < widthLen; x++)
            {
                for(int y = 0; y < heightLen; y++)
                {
                    data[x][y] = originBitmap.GetPixel(x * scale, y * scale).R;
                }
            }
        }

        public int CalcScore(byte[][] bytes)
        {
            int score = 0;

            for(int x = 0; x < widthLen; x++)
            {
                
                for(int y = 0; y < heightLen; y++)
                {
                    score += Math.Abs(data[x][y] - bytes[x][y]);
                }
            }

            return score;
        }

        public Bitmap MakeBitmapWithGene(ArrayList gene)
        {
            Bitmap bitmap = new Bitmap(originBitmap.Width, originBitmap.Height);
            Graphics g = Graphics.FromImage(bitmap);
            for (int i = 0; i < gene.Count; i++)
            {
                PictureUnit u = (PictureUnit)gene[i];
                g.FillRectangle(new SolidBrush(u.color), i % widthLen * scale, i / widthLen * scale, scale, scale);
            }

            return bitmap;
        }


        public byte[][] MakeByteWithGene(ArrayList gene)
        {
            byte[][] bytes = new byte[widthLen][];
            for(int i = 0; i < widthLen; i++) bytes[i] = new byte[heightLen];

            for (int i = 0; i < gene.Count; i++)
            {
                PictureUnit u = (PictureUnit)gene[i];
                bytes[i % widthLen][i / widthLen] = u.color.R;
            }

            return bytes;
        }

        static public Bitmap DownScaleTo(Bitmap bitmap, int scale)
        {
            
            int widthLen = bitmap.Width / scale, heightLen = bitmap.Height / scale;
            Bitmap res = new Bitmap(widthLen * scale, heightLen * scale);
            Graphics g = Graphics.FromImage(res);


            for (int x = 0; x < res.Width; x += scale)
            {
                for(int y = 0; y < res.Height; y += scale)
                {
                    int grayVal = Picture.GrayScaleAvg(bitmap, scale, x, y);
                    
                    g.FillRectangle(new SolidBrush(Color.FromArgb(grayVal, grayVal, grayVal)), x, y, scale, scale);
                }
            }
            return res;
        }

        static public Bitmap ToGray(Bitmap bitmap)
        {
            Bitmap grayBitmap = new Bitmap(bitmap.Width, bitmap.Height);
            for(int x = 0; x < bitmap.Width; x++)
            {
                for(int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    int avg = (color.R + color.G + color.B) / 3;
                    grayBitmap.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                }
            }
            return grayBitmap;
        }

        static public int GrayScaleAvg(Bitmap bitmap, int scale, int _x, int _y)
        {
            int total = 0;
            for (int x = _x; x < _x + scale; x++)
            {
                for (int y = _y; y < _y + scale; y++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    total += (color.R + color.G + color.B) / 3;
                }
            }
            return total / (scale * scale);
        }

    }


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
        public PictureGeneBluePrint(int length, int maskLength, int elite, int mutation, int overcross) : base(length, maskLength, elite, mutation, overcross)
        {
            
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
