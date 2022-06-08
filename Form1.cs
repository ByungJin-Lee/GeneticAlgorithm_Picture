using Genetic;
using System.Collections;

namespace PictureGA
{
    public partial class Form1 : Form
    {
        Bitmap originBitmap, testBitmap;
        int PWIDTH, PHEIGHT;
        Model gaModel;
        bool is_model_learning = false;
        int mutation = 20;
        int elite = 1;

        public Form1()
        {
            InitializeComponent();
            //txt_log.Enabled = false;
            originBitmap = ReadBitmap("einstein.png");
            PWIDTH = originBitmap.Width;
            PHEIGHT = originBitmap.Height; 
        }

        #region Paint
        private void lbl_origin_Paint(object sender, PaintEventArgs e)
        {
            if (originBitmap != null) e.Graphics.DrawImage(originBitmap, 0, 0);
        }

        private void lbl_model_Paint(object sender, PaintEventArgs e)
        {
            if (testBitmap != null) e.Graphics.DrawImage(testBitmap, 0, 0);
        }

        private void btn_model_Click(object sender, EventArgs e)
        {
            if (is_model_learning == false)
            {
                gaModel = GenerateGAModel(30, PHEIGHT * PWIDTH, 1);
                UpdateInfo();
                btn_model.Text = "Stop Learing";
                is_model_learning = true;
            }
            else
            {
                btn_model.Text = "Learning";
                is_model_learning = false;
            }
        }

        public void UpdateTest(Bitmap bitmap, int value, bool model_display = false)
        {
            if(model_display == true)
            {
                testBitmap = bitmap;
                lbl_model.Update();
                lbl_model.Refresh();
            }
            txt_log.AppendText(value.ToString() + '\n');
            txt_log.Update();
            txt_log.Refresh();
            txt_log.ScrollToCaret();
        }

        public void UpdateInfo()
        {
            lbl_info.Text = gaModel.ToString();
            lbl_info.Update();
            lbl_info.Refresh();
        }

        private void btn_evaluate_Click(object sender, EventArgs e)
        {
            if (is_model_learning && gaModel != null)
            {
                gaModel.Fit();
                UpdateInfo();
                UpdateTest(ConverToBitmapFromGene(gaModel.elite.gene), gaModel.elite.Score, true);
            }
        }

        #endregion

        #region Non UI Method
        private Bitmap ReadBitmap(string path)
        {
            Image image = Image.FromFile(path);
            return new Bitmap(image);
        }

        private Model GenerateGAModel(int population, int geneUnitLength, int maskLength)
        {
            if (originBitmap == null) throw new Exception("There is no loaded image!");

            // 유전자 설계도 작성 (업캐스팅)
            GeneBluePrint blueprint = new PictureGeneBluePrint(geneUnitLength, maskLength, elite, mutation);
            // 유전자 설계도를 이용하여 시뮬레이션 공간을 생성
            GenePool pool = new GenePool(population, blueprint);
            // 랜덤 유전자로 공간을 채움
            pool.FillRandom();
            // 유전자 모델 생성, 유전자 평가함수 작성
            Model model = new Model(pool, EvaluateGene);
            return model;
        }

        public Bitmap ConverToBitmapFromGene(ArrayList gene)
        {
            Bitmap bitmap = new Bitmap(originBitmap.Width, originBitmap.Height);
            for(int i = 0; i < gene.Count; i++)
            {
                PictureUnit u = (PictureUnit)gene[i];
                bitmap.SetPixel(i % PWIDTH, i / PWIDTH, u.color);
            }

            return bitmap;
        }

        public int EvaluateGene(ArrayList gene)
        {
            Bitmap bitmap = ConverToBitmapFromGene(gene);
            int value = CalcDifferenceBitmap(originBitmap, bitmap);
            UpdateTest(bitmap, value, true);
            return value;
        }

        public int CalcDifferenceBitmap(Bitmap lhs, Bitmap rhs)
        {
            if (lhs.Width != rhs.Width || lhs.Height != rhs.Height) 
                throw new Exception("Bitmap Size is Difference!")
;
            int score = 0;
            for(int r = 0; r < lhs.Height; r++)
            {
                for(int c = 0; c < lhs.Width; c++)
                {
                    int value = CalcDifferenceColor(lhs.GetPixel(c, r), rhs.GetPixel(c, r));
                    score += value;
                }
            }
            return score;
        }

        private void btn_overrun_Click(object sender, EventArgs e)
        {
            while (true)
            {
                gaModel.Fit();
                UpdateInfo();
                UpdateTest(ConverToBitmapFromGene(gaModel.elite.gene), gaModel.elite.Score, true);
                gaModel.Next();
            }
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            if (gaModel != null)
            {
                gaModel.Next();
                txt_log.AppendText("next generation\n");
                txt_log.ScrollToCaret();
            }
        }


        // 삼원색 별 차이 합
        public int CalcDifferenceColor(Color lhs, Color rhs)
        {
            return Math.Abs(lhs.R - rhs.R);
        }

        #endregion

    }
}