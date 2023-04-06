namespace wf03_property
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gbxmain = new System.Windows.Forms.GroupBox();
            this.fontsize = new System.Windows.Forms.NumericUpDown();
            this.TxtResult = new System.Windows.Forms.TextBox();
            this.italic = new System.Windows.Forms.CheckBox();
            this.bold = new System.Windows.Forms.CheckBox();
            this.fontname = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpBar = new System.Windows.Forms.GroupBox();
            this.thDummy = new System.Windows.Forms.TrackBar();
            this.pgDummy = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnMsgBox = new System.Windows.Forms.Button();
            this.BtnModalless = new System.Windows.Forms.Button();
            this.BtnModal = new System.Windows.Forms.Button();
            this.TreeToList = new System.Windows.Forms.GroupBox();
            this.LsvDummy = new System.Windows.Forms.TreeView();
            this.TrvDummy = new System.Windows.Forms.ListView();
            this.BtnAddRoot = new System.Windows.Forms.Button();
            this.BtnAddChild = new System.Windows.Forms.Button();
            this.RdoNomal = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.PcbDummy = new System.Windows.Forms.GroupBox();
            this.btn = new System.Windows.Forms.Button();
            this.gbxmain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontsize)).BeginInit();
            this.grpBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thDummy)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.TreeToList.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxmain
            // 
            this.gbxmain.Controls.Add(this.radioButton1);
            this.gbxmain.Controls.Add(this.RdoNomal);
            this.gbxmain.Controls.Add(this.fontsize);
            this.gbxmain.Controls.Add(this.TxtResult);
            this.gbxmain.Controls.Add(this.italic);
            this.gbxmain.Controls.Add(this.bold);
            this.gbxmain.Controls.Add(this.fontname);
            this.gbxmain.Controls.Add(this.label2);
            this.gbxmain.Controls.Add(this.label1);
            this.gbxmain.Location = new System.Drawing.Point(12, 12);
            this.gbxmain.Name = "gbxmain";
            this.gbxmain.Size = new System.Drawing.Size(395, 174);
            this.gbxmain.TabIndex = 0;
            this.gbxmain.TabStop = false;
            this.gbxmain.Text = "groupBox1";
            // 
            // fontsize
            // 
            this.fontsize.Location = new System.Drawing.Point(97, 48);
            this.fontsize.Name = "fontsize";
            this.fontsize.Size = new System.Drawing.Size(121, 21);
            this.fontsize.TabIndex = 4;
            this.fontsize.ValueChanged += new System.EventHandler(this.fontsize_ValueChanged);
            // 
            // TxtResult
            // 
            this.TxtResult.Location = new System.Drawing.Point(29, 75);
            this.TxtResult.Multiline = true;
            this.TxtResult.Name = "TxtResult";
            this.TxtResult.Size = new System.Drawing.Size(337, 93);
            this.TxtResult.TabIndex = 5;
            this.TxtResult.Text = "Result";
            // 
            // italic
            // 
            this.italic.AutoSize = true;
            this.italic.Location = new System.Drawing.Point(316, 24);
            this.italic.Name = "italic";
            this.italic.Size = new System.Drawing.Size(60, 16);
            this.italic.TabIndex = 3;
            this.italic.Text = "이탤릭";
            this.italic.UseVisualStyleBackColor = true;
            this.italic.CheckedChanged += new System.EventHandler(this.italic_CheckedChanged);
            // 
            // bold
            // 
            this.bold.AutoSize = true;
            this.bold.Location = new System.Drawing.Point(242, 25);
            this.bold.Name = "bold";
            this.bold.Size = new System.Drawing.Size(48, 16);
            this.bold.TabIndex = 2;
            this.bold.Text = "볼드";
            this.bold.UseVisualStyleBackColor = true;
            this.bold.CheckedChanged += new System.EventHandler(this.bold_CheckedChanged);
            // 
            // fontname
            // 
            this.fontname.FormattingEnabled = true;
            this.fontname.Location = new System.Drawing.Point(97, 22);
            this.fontname.Name = "fontname";
            this.fontname.Size = new System.Drawing.Size(121, 20);
            this.fontname.TabIndex = 1;
            this.fontname.SelectedIndexChanged += new System.EventHandler(this.fontname_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "글자크기";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "글자체";
            // 
            // grpBar
            // 
            this.grpBar.Controls.Add(this.thDummy);
            this.grpBar.Controls.Add(this.pgDummy);
            this.grpBar.Location = new System.Drawing.Point(12, 192);
            this.grpBar.Name = "grpBar";
            this.grpBar.Size = new System.Drawing.Size(381, 100);
            this.grpBar.TabIndex = 1;
            this.grpBar.TabStop = false;
            this.grpBar.Text = "트랙바 빛 진행바";
            this.grpBar.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // thDummy
            // 
            this.thDummy.Location = new System.Drawing.Point(29, 20);
            this.thDummy.Maximum = 20;
            this.thDummy.Name = "thDummy";
            this.thDummy.Size = new System.Drawing.Size(337, 45);
            this.thDummy.TabIndex = 1;
            // 
            // pgDummy
            // 
            this.pgDummy.Location = new System.Drawing.Point(29, 69);
            this.pgDummy.Maximum = 20;
            this.pgDummy.Name = "pgDummy";
            this.pgDummy.Size = new System.Drawing.Size(337, 16);
            this.pgDummy.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnModal);
            this.groupBox2.Controls.Add(this.BtnModalless);
            this.groupBox2.Controls.Add(this.BtnMsgBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 318);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 100);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // BtnMsgBox
            // 
            this.BtnMsgBox.Location = new System.Drawing.Point(271, 62);
            this.BtnMsgBox.Name = "BtnMsgBox";
            this.BtnMsgBox.Size = new System.Drawing.Size(95, 23);
            this.BtnMsgBox.TabIndex = 10;
            this.BtnMsgBox.Text = "MessageBox";
            this.BtnMsgBox.UseVisualStyleBackColor = true;
            // 
            // BtnModalless
            // 
            this.BtnModalless.Location = new System.Drawing.Point(153, 62);
            this.BtnModalless.Name = "BtnModalless";
            this.BtnModalless.Size = new System.Drawing.Size(75, 23);
            this.BtnModalless.TabIndex = 1;
            this.BtnModalless.Text = "Modalless";
            this.BtnModalless.UseVisualStyleBackColor = true;
            // 
            // BtnModal
            // 
            this.BtnModal.AutoEllipsis = true;
            this.BtnModal.Location = new System.Drawing.Point(29, 62);
            this.BtnModal.Name = "BtnModal";
            this.BtnModal.Size = new System.Drawing.Size(75, 23);
            this.BtnModal.TabIndex = 8;
            this.BtnModal.Text = "Modal";
            this.BtnModal.UseVisualStyleBackColor = true;
            // 
            // TreeToList
            // 
            this.TreeToList.Controls.Add(this.BtnAddChild);
            this.TreeToList.Controls.Add(this.BtnAddRoot);
            this.TreeToList.Controls.Add(this.TrvDummy);
            this.TreeToList.Controls.Add(this.LsvDummy);
            this.TreeToList.Location = new System.Drawing.Point(463, 21);
            this.TreeToList.Name = "TreeToList";
            this.TreeToList.Size = new System.Drawing.Size(381, 183);
            this.TreeToList.TabIndex = 3;
            this.TreeToList.TabStop = false;
            this.TreeToList.Text = "트리뷰리스트 뷰";
            // 
            // LsvDummy
            // 
            this.LsvDummy.Location = new System.Drawing.Point(6, 16);
            this.LsvDummy.Name = "LsvDummy";
            this.LsvDummy.Size = new System.Drawing.Size(180, 121);
            this.LsvDummy.TabIndex = 0;
            // 
            // TrvDummy
            // 
            this.TrvDummy.HideSelection = false;
            this.TrvDummy.Location = new System.Drawing.Point(192, 16);
            this.TrvDummy.Name = "TrvDummy";
            this.TrvDummy.Size = new System.Drawing.Size(178, 121);
            this.TrvDummy.TabIndex = 1;
            this.TrvDummy.UseCompatibleStateImageBehavior = false;
            // 
            // BtnAddRoot
            // 
            this.BtnAddRoot.Location = new System.Drawing.Point(15, 143);
            this.BtnAddRoot.Name = "BtnAddRoot";
            this.BtnAddRoot.Size = new System.Drawing.Size(75, 34);
            this.BtnAddRoot.TabIndex = 2;
            this.BtnAddRoot.Text = "루트추가";
            this.BtnAddRoot.UseVisualStyleBackColor = true;
            // 
            // BtnAddChild
            // 
            this.BtnAddChild.Location = new System.Drawing.Point(96, 143);
            this.BtnAddChild.Name = "BtnAddChild";
            this.BtnAddChild.Size = new System.Drawing.Size(75, 34);
            this.BtnAddChild.TabIndex = 3;
            this.BtnAddChild.Text = "자식추가";
            this.BtnAddChild.UseVisualStyleBackColor = true;
            // 
            // RdoNomal
            // 
            this.RdoNomal.AutoSize = true;
            this.RdoNomal.Location = new System.Drawing.Point(242, 49);
            this.RdoNomal.Name = "RdoNomal";
            this.RdoNomal.Size = new System.Drawing.Size(47, 16);
            this.RdoNomal.TabIndex = 6;
            this.RdoNomal.TabStop = true;
            this.RdoNomal.Text = "일반";
            this.RdoNomal.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(303, 49);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(71, 16);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "들여쓰기";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // PcbDummy
            // 
            this.PcbDummy.Location = new System.Drawing.Point(432, 210);
            this.PcbDummy.Name = "PcbDummy";
            this.PcbDummy.Size = new System.Drawing.Size(365, 301);
            this.PcbDummy.TabIndex = 4;
            this.PcbDummy.TabStop = false;
            this.PcbDummy.Text = "픽처박스";
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(813, 234);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(75, 43);
            this.btn.TabIndex = 5;
            this.btn.Text = "노드";
            this.btn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 552);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.PcbDummy);
            this.Controls.Add(this.TreeToList);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpBar);
            this.Controls.Add(this.gbxmain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "속성확인";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbxmain.ResumeLayout(false);
            this.gbxmain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fontsize)).EndInit();
            this.grpBar.ResumeLayout(false);
            this.grpBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.thDummy)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.TreeToList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxmain;
        private System.Windows.Forms.CheckBox italic;
        private System.Windows.Forms.CheckBox bold;
        private System.Windows.Forms.ComboBox fontname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtResult;
        private System.Windows.Forms.NumericUpDown fontsize;
        private System.Windows.Forms.GroupBox grpBar;
        private System.Windows.Forms.TrackBar thDummy;
        private System.Windows.Forms.ProgressBar pgDummy;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnModal;
        private System.Windows.Forms.Button BtnModalless;
        private System.Windows.Forms.Button BtnMsgBox;
        private System.Windows.Forms.GroupBox TreeToList;
        private System.Windows.Forms.ListView TrvDummy;
        private System.Windows.Forms.TreeView LsvDummy;
        private System.Windows.Forms.Button BtnAddChild;
        private System.Windows.Forms.Button BtnAddRoot;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton RdoNomal;
        private System.Windows.Forms.GroupBox PcbDummy;
        private System.Windows.Forms.Button btn;
    }
}

