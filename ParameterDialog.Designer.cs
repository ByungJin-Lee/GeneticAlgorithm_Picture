
namespace PictureGA
{
    partial class ParameterDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_population = new System.Windows.Forms.Label();
            this.nud_population = new System.Windows.Forms.NumericUpDown();
            this.lbl_genLimit = new System.Windows.Forms.Label();
            this.nud_genLimit = new System.Windows.Forms.NumericUpDown();
            this.nud_imgScale = new System.Windows.Forms.NumericUpDown();
            this.lbl_imgScale = new System.Windows.Forms.Label();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.lbl_imgScaleInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nud_population)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_genLimit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_imgScale)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_population
            // 
            this.lbl_population.AutoSize = true;
            this.lbl_population.Location = new System.Drawing.Point(12, 28);
            this.lbl_population.Name = "lbl_population";
            this.lbl_population.Size = new System.Drawing.Size(77, 15);
            this.lbl_population.TabIndex = 1;
            this.lbl_population.Text = "Population";
            // 
            // nud_population
            // 
            this.nud_population.Location = new System.Drawing.Point(145, 26);
            this.nud_population.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nud_population.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_population.Name = "nud_population";
            this.nud_population.Size = new System.Drawing.Size(120, 25);
            this.nud_population.TabIndex = 2;
            this.nud_population.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_population.ValueChanged += new System.EventHandler(this.nud_population_ValueChanged);
            // 
            // lbl_genLimit
            // 
            this.lbl_genLimit.AutoSize = true;
            this.lbl_genLimit.Location = new System.Drawing.Point(12, 59);
            this.lbl_genLimit.Name = "lbl_genLimit";
            this.lbl_genLimit.Size = new System.Drawing.Size(112, 15);
            this.lbl_genLimit.TabIndex = 3;
            this.lbl_genLimit.Text = "Generation Limit";
            // 
            // nud_genLimit
            // 
            this.nud_genLimit.Location = new System.Drawing.Point(145, 57);
            this.nud_genLimit.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nud_genLimit.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_genLimit.Name = "nud_genLimit";
            this.nud_genLimit.Size = new System.Drawing.Size(120, 25);
            this.nud_genLimit.TabIndex = 4;
            this.nud_genLimit.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // nud_imgScale
            // 
            this.nud_imgScale.Location = new System.Drawing.Point(145, 88);
            this.nud_imgScale.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nud_imgScale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_imgScale.Name = "nud_imgScale";
            this.nud_imgScale.Size = new System.Drawing.Size(120, 25);
            this.nud_imgScale.TabIndex = 5;
            this.nud_imgScale.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lbl_imgScale
            // 
            this.lbl_imgScale.AutoSize = true;
            this.lbl_imgScale.Location = new System.Drawing.Point(12, 90);
            this.lbl_imgScale.Name = "lbl_imgScale";
            this.lbl_imgScale.Size = new System.Drawing.Size(87, 15);
            this.lbl_imgScale.TabIndex = 6;
            this.lbl_imgScale.Text = "Image Scale";
            // 
            // btn_ok
            // 
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Location = new System.Drawing.Point(74, 127);
            this.btn_ok.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(86, 29);
            this.btn_ok.TabIndex = 9;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(244, 127);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(86, 29);
            this.btn_cancel.TabIndex = 10;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // lbl_imgScaleInfo
            // 
            this.lbl_imgScaleInfo.AutoSize = true;
            this.lbl_imgScaleInfo.Location = new System.Drawing.Point(282, 90);
            this.lbl_imgScaleInfo.Name = "lbl_imgScaleInfo";
            this.lbl_imgScaleInfo.Size = new System.Drawing.Size(104, 15);
            this.lbl_imgScaleInfo.TabIndex = 12;
            this.lbl_imgScaleInfo.Text = "(Shrink to 1:N)";
            // 
            // ParameterDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 185);
            this.Controls.Add(this.lbl_imgScaleInfo);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.lbl_imgScale);
            this.Controls.Add(this.nud_imgScale);
            this.Controls.Add(this.nud_genLimit);
            this.Controls.Add(this.lbl_genLimit);
            this.Controls.Add(this.nud_population);
            this.Controls.Add(this.lbl_population);
            this.Name = "ParameterDialog";
            this.Text = "Setting Parameters";
            this.Load += new System.EventHandler(this.ParameterDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_population)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_genLimit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_imgScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_population;
        private System.Windows.Forms.NumericUpDown nud_population;
        private System.Windows.Forms.Label lbl_genLimit;
        private System.Windows.Forms.NumericUpDown nud_genLimit;
        private System.Windows.Forms.NumericUpDown nud_imgScale;
        private System.Windows.Forms.Label lbl_imgScale;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label lbl_imgScaleInfo;
    }
}