namespace fw14_winforms_thread
{
    partial class FrmMain
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.Txtnumber = new System.Windows.Forms.TextBox();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.PgbCalculator = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.LblResult = new System.Windows.Forms.Label();
            this.Worker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "입력(수)";
            // 
            // Txtnumber
            // 
            this.Txtnumber.Location = new System.Drawing.Point(82, 29);
            this.Txtnumber.Name = "Txtnumber";
            this.Txtnumber.Size = new System.Drawing.Size(100, 21);
            this.Txtnumber.TabIndex = 1;
            this.Txtnumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BtnStart
            // 
            this.BtnStart.Location = new System.Drawing.Point(217, 27);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(75, 23);
            this.BtnStart.TabIndex = 2;
            this.BtnStart.Text = "시작";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Location = new System.Drawing.Point(320, 29);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "취소";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // PgbCalculator
            // 
            this.PgbCalculator.Location = new System.Drawing.Point(12, 73);
            this.PgbCalculator.Name = "PgbCalculator";
            this.PgbCalculator.Size = new System.Drawing.Size(412, 23);
            this.PgbCalculator.TabIndex = 4;
            this.PgbCalculator.Click += new System.EventHandler(this.PgbCalculator_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "결과";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // LblResult
            // 
            this.LblResult.AutoSize = true;
            this.LblResult.Location = new System.Drawing.Point(68, 109);
            this.LblResult.Name = "LblResult";
            this.LblResult.Size = new System.Drawing.Size(11, 12);
            this.LblResult.TabIndex = 6;
            this.LblResult.Text = "0";
            this.LblResult.Click += new System.EventHandler(this.LblResult_Click);
            // 
            // Worker
            // 
            this.Worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            this.Worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Worker_ProgressChanged);
            this.Worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Worker_RunWorkerCompleted);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 195);
            this.Controls.Add(this.LblResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PgbCalculator);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.Txtnumber);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BackgroundWorker 테스트";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txtnumber;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.ProgressBar PgbCalculator;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label LblResult;
        private System.ComponentModel.BackgroundWorker Worker;
    }
}

