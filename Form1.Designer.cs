namespace PictureGA
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_info = new System.Windows.Forms.Label();
            this.btn_model = new System.Windows.Forms.Button();
            this.btn_evaluate = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_overrun = new System.Windows.Forms.Button();
            this.lbl_origin = new System.Windows.Forms.Label();
            this.lbl_model = new System.Windows.Forms.Label();
            this.txt_log = new System.Windows.Forms.RichTextBox();
            this.btn_open = new System.Windows.Forms.Button();
            this.btn_parameter = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // lbl_info
            // 
            this.lbl_info.AutoSize = true;
            this.lbl_info.Location = new System.Drawing.Point(15, 16);
            this.lbl_info.Name = "lbl_info";
            this.lbl_info.Size = new System.Drawing.Size(78, 15);
            this.lbl_info.TabIndex = 0;
            this.lbl_info.Text = "information";
            // 
            // btn_model
            // 
            this.btn_model.Location = new System.Drawing.Point(576, 16);
            this.btn_model.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_model.Name = "btn_model";
            this.btn_model.Size = new System.Drawing.Size(86, 29);
            this.btn_model.TabIndex = 1;
            this.btn_model.Text = "Model";
            this.btn_model.UseVisualStyleBackColor = true;
            this.btn_model.Click += new System.EventHandler(this.btn_model_Click);
            // 
            // btn_evaluate
            // 
            this.btn_evaluate.Location = new System.Drawing.Point(669, 16);
            this.btn_evaluate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_evaluate.Name = "btn_evaluate";
            this.btn_evaluate.Size = new System.Drawing.Size(86, 29);
            this.btn_evaluate.TabIndex = 2;
            this.btn_evaluate.Text = "Fit";
            this.btn_evaluate.UseVisualStyleBackColor = true;
            this.btn_evaluate.Click += new System.EventHandler(this.btn_evaluate_Click);
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(761, 16);
            this.btn_next.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(86, 29);
            this.btn_next.TabIndex = 3;
            this.btn_next.Text = "Next";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_overrun
            // 
            this.btn_overrun.Location = new System.Drawing.Point(854, 16);
            this.btn_overrun.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_overrun.Name = "btn_overrun";
            this.btn_overrun.Size = new System.Drawing.Size(86, 29);
            this.btn_overrun.TabIndex = 4;
            this.btn_overrun.Text = "Run";
            this.btn_overrun.UseVisualStyleBackColor = true;
            this.btn_overrun.Click += new System.EventHandler(this.btn_overrun_Click);
            // 
            // lbl_origin
            // 
            this.lbl_origin.Location = new System.Drawing.Point(15, 65);
            this.lbl_origin.Name = "lbl_origin";
            this.lbl_origin.Size = new System.Drawing.Size(360, 451);
            this.lbl_origin.TabIndex = 5;
            this.lbl_origin.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_origin_Paint);
            // 
            // lbl_model
            // 
            this.lbl_model.Location = new System.Drawing.Point(382, 65);
            this.lbl_model.Name = "lbl_model";
            this.lbl_model.Size = new System.Drawing.Size(360, 451);
            this.lbl_model.TabIndex = 6;
            this.lbl_model.Paint += new System.Windows.Forms.PaintEventHandler(this.lbl_model_Paint);
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(749, 65);
            this.txt_log.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(193, 434);
            this.txt_log.TabIndex = 7;
            this.txt_log.Text = "";
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(392, 16);
            this.btn_open.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(86, 29);
            this.btn_open.TabIndex = 8;
            this.btn_open.Text = "Open...";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // btn_parameter
            // 
            this.btn_parameter.Location = new System.Drawing.Point(484, 16);
            this.btn_parameter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_parameter.Name = "btn_parameter";
            this.btn_parameter.Size = new System.Drawing.Size(86, 29);
            this.btn_parameter.TabIndex = 9;
            this.btn_parameter.Text = "Parameter";
            this.btn_parameter.UseVisualStyleBackColor = true;
            this.btn_parameter.Click += new System.EventHandler(this.btn_parameter_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 539);
            this.Controls.Add(this.btn_parameter);
            this.Controls.Add(this.btn_open);
            this.Controls.Add(this.txt_log);
            this.Controls.Add(this.lbl_model);
            this.Controls.Add(this.lbl_origin);
            this.Controls.Add(this.btn_overrun);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.btn_evaluate);
            this.Controls.Add(this.btn_model);
            this.Controls.Add(this.lbl_info);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Picture Genetic Algorithm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_info;
        private System.Windows.Forms.Button btn_model;
        private System.Windows.Forms.Button btn_evaluate;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_overrun;
        private System.Windows.Forms.Label lbl_origin;
        private System.Windows.Forms.Label lbl_model;
        private System.Windows.Forms.RichTextBox txt_log;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.Button btn_parameter;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

