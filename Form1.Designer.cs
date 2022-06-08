namespace PictureGA
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_origin = new System.Windows.Forms.Label();
            this.lbl_model = new System.Windows.Forms.Label();
            this.btn_model = new System.Windows.Forms.Button();
            this.lbl_info = new System.Windows.Forms.Label();
            this.txt_log = new System.Windows.Forms.RichTextBox();
            this.btn_evaluate = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_overrun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_origin
            // 
            this.lbl_origin.Location = new System.Drawing.Point(12, 41);
            this.lbl_origin.Name = "lbl_origin";
            this.lbl_origin.Size = new System.Drawing.Size(300, 400);
            this.lbl_origin.TabIndex = 0;
            this.lbl_origin.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_origin_Paint);
            // 
            // lbl_model
            // 
            this.lbl_model.Location = new System.Drawing.Point(321, 41);
            this.lbl_model.Name = "lbl_model";
            this.lbl_model.Size = new System.Drawing.Size(300, 400);
            this.lbl_model.TabIndex = 1;
            this.lbl_model.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_model_Paint);
            // 
            // btn_model
            // 
            this.btn_model.Location = new System.Drawing.Point(546, 12);
            this.btn_model.Name = "btn_model";
            this.btn_model.Size = new System.Drawing.Size(75, 23);
            this.btn_model.TabIndex = 2;
            this.btn_model.Text = "Model";
            this.btn_model.UseVisualStyleBackColor = true;
            this.btn_model.Click += new System.EventHandler(this.btn_model_Click);
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Location = new System.Drawing.Point(12, 9);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(28, 15);
            this.lbl_info.TabIndex = 3;
            this.lbl_info.Text = "info";
            this.lbl_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(627, 41);
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(252, 397);
            this.txt_log.TabIndex = 4;
            this.txt_log.Text = "";
            // 
            // btn_evaluate
            // 
            this.btn_evaluate.Location = new System.Drawing.Point(627, 12);
            this.btn_evaluate.Name = "btn_evaluate";
            this.btn_evaluate.Size = new System.Drawing.Size(75, 23);
            this.btn_evaluate.TabIndex = 5;
            this.btn_evaluate.Text = "Evaluate";
            this.btn_evaluate.UseVisualStyleBackColor = true;
            this.btn_evaluate.Click += new System.EventHandler(this.btn_evaluate_Click);
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(708, 12);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(75, 23);
            this.btn_next.TabIndex = 6;
            this.btn_next.Text = "Next";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_overrun
            // 
            this.btn_overrun.Location = new System.Drawing.Point(789, 12);
            this.btn_overrun.Name = "btn_overrun";
            this.btn_overrun.Size = new System.Drawing.Size(75, 23);
            this.btn_overrun.TabIndex = 7;
            this.btn_overrun.Text = "run";
            this.btn_overrun.UseVisualStyleBackColor = true;
            this.btn_overrun.Click += new System.EventHandler(this.btn_overrun_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 450);
            this.Controls.Add(this.btn_overrun);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.btn_evaluate);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.lbl_info);
            this.Controls.Add(this.btn_model);
            this.Controls.Add(this.lbl_model);
            this.Controls.Add(this.lbl_origin);
            this.Name = "Form1";
            this.Text = "PictureGA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lbl_origin;
        private Label lbl_model;
        private Button btn_model;
        private Label lbl_info;
        private RichTextBox txt_log;
        private Button btn_evaluate;
        private Button btn_next;
        private Button btn_overrun;
    }
}