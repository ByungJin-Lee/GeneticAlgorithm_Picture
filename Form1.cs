using Genetic;
using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace PictureGA
{
    public partial class Form1 : Form
    {
        Picture picture;
        Bitmap testBitmap;
        Model gaModel;
        bool is_model_learning = false;
        int mutation = 10, overcross = 100;
        bool view_evaluate_seq = false;
        int elite = 1;
        int masklen = 3;
        int population = 100;
        int limit_g = 2000;

        public Form1()
        {
            InitializeComponent();
            //txt_log.Enabled = false;
            Bitmap bitmap = ReadBitmap("einstein.png");
            picture = new Picture(bitmap, 5);
        }

        #region Paint
        private void lbl_origin_Paint(object sender, PaintEventArgs e)
        {
            if (picture != null) e.Graphics.DrawImage(picture.originBitmap, 0, 0);
        }

        private void lbl_model_Paint(object sender, PaintEventArgs e)
        {
            if (testBitmap != null) e.Graphics.DrawImage(testBitmap, 0, 0);
        }

        private void btn_model_Click(object sender, EventArgs e)
        {
            if (is_model_learning == false)
            {
                gaModel = GenerateGAModel(population, picture.widthLen * picture.heightLen, masklen);
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
            if (model_display == true)
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
                UpdateTest(picture.MakeBitmapWithGene(gaModel.elite.gene), gaModel.elite.Score, true);
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
            if (picture == null) throw new Exception("There is no loaded picture!");

            // 유전자 설계도 작성 (업캐스팅)
            GeneBluePrint blueprint = new PictureGeneBluePrint(geneUnitLength, maskLength, elite, mutation, overcross);
            // 유전자 설계도를 이용하여 시뮬레이션 공간을 생성
            GenePool pool = new GenePool(population, blueprint);
            // 랜덤 유전자로 공간을 채움
            pool.FillRandom();
            // 유전자 모델 생성, 유전자 평가함수 작성
            Model model = new Model(pool, EvaluateGene);
            return model;
        }

        public int EvaluateGene(ArrayList gene)
        {
            int value = picture.CalcScore(picture.MakeByteWithGene(gene));
            //UpdateTest(picture.MakeBitmapWithGene(gene), value, view_evaluate_seq);
            return value;
        }

        public int CalcDifferenceBitmap(Bitmap lhs, Bitmap rhs)
        {
            if (lhs.Width != rhs.Width || lhs.Height != rhs.Height)
                throw new Exception("Bitmap Size is Difference!")
;
            int score = 0;
            for (int r = 0; r < lhs.Height; r++)
            {
                for (int c = 0; c < lhs.Width; c++)
                {
                    int value = CalcDifferenceColor(lhs.GetPixel(c, r), rhs.GetPixel(c, r));
                    score += value;
                }
            }
            return score;
        }

        private void btn_overrun_Click(object sender, EventArgs e)
        {
            while (gaModel.pool.generation <= limit_g)
            {
                gaModel.Fit();
                UpdateInfo();
                UpdateTest(picture.MakeBitmapWithGene(gaModel.elite.gene), gaModel.elite.Score, true);
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