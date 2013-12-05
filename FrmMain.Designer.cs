namespace KSANamePlate
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.butLoadImageFile = new System.Windows.Forms.Button();
            this.butLoadDBFile = new System.Windows.Forms.Button();
            this.textLog = new System.Windows.Forms.TextBox();
            this.butExecute = new System.Windows.Forms.Button();
            this.butStop = new System.Windows.Forms.Button();
            this.executer = new System.ComponentModel.BackgroundWorker();
            this.butLoadSettingFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // butLoadImageFile
            // 
            this.butLoadImageFile.Location = new System.Drawing.Point(0, 300);
            this.butLoadImageFile.Name = "butLoadImageFile";
            this.butLoadImageFile.Size = new System.Drawing.Size(120, 40);
            this.butLoadImageFile.TabIndex = 0;
            this.butLoadImageFile.Text = "Load Image File";
            this.butLoadImageFile.UseVisualStyleBackColor = true;
            this.butLoadImageFile.Click += new System.EventHandler(this.butLoadImageFile_Click);
            // 
            // butLoadDBFile
            // 
            this.butLoadDBFile.Location = new System.Drawing.Point(252, 300);
            this.butLoadDBFile.Name = "butLoadDBFile";
            this.butLoadDBFile.Size = new System.Drawing.Size(120, 40);
            this.butLoadDBFile.TabIndex = 8;
            this.butLoadDBFile.Text = "Load DB File";
            this.butLoadDBFile.UseVisualStyleBackColor = true;
            this.butLoadDBFile.Click += new System.EventHandler(this.butLoadDBFile_Click);
            // 
            // textLog
            // 
            this.textLog.BackColor = System.Drawing.Color.Black;
            this.textLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textLog.ForeColor = System.Drawing.Color.White;
            this.textLog.Location = new System.Drawing.Point(0, 0);
            this.textLog.Multiline = true;
            this.textLog.Name = "textLog";
            this.textLog.ReadOnly = true;
            this.textLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textLog.Size = new System.Drawing.Size(584, 300);
            this.textLog.TabIndex = 13;
            this.textLog.TextChanged += new System.EventHandler(this.textLog_TextChanged);
            // 
            // butExecute
            // 
            this.butExecute.Location = new System.Drawing.Point(424, 300);
            this.butExecute.Name = "butExecute";
            this.butExecute.Size = new System.Drawing.Size(77, 40);
            this.butExecute.TabIndex = 14;
            this.butExecute.Text = "Execute";
            this.butExecute.UseVisualStyleBackColor = true;
            this.butExecute.Click += new System.EventHandler(this.butExecute_Click);
            // 
            // butStop
            // 
            this.butStop.Location = new System.Drawing.Point(507, 300);
            this.butStop.Name = "butStop";
            this.butStop.Size = new System.Drawing.Size(77, 40);
            this.butStop.TabIndex = 15;
            this.butStop.Text = "Stop";
            this.butStop.UseVisualStyleBackColor = true;
            this.butStop.Click += new System.EventHandler(this.butStop_Click);
            // 
            // executer
            // 
            this.executer.WorkerSupportsCancellation = true;
            this.executer.DoWork += new System.ComponentModel.DoWorkEventHandler(this.executer_DoWork);
            this.executer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.executer_RunWorkerCompleted);
            // 
            // butLoadSettingFile
            // 
            this.butLoadSettingFile.Location = new System.Drawing.Point(126, 300);
            this.butLoadSettingFile.Name = "butLoadSettingFile";
            this.butLoadSettingFile.Size = new System.Drawing.Size(120, 40);
            this.butLoadSettingFile.TabIndex = 16;
            this.butLoadSettingFile.Text = "Load Setting File";
            this.butLoadSettingFile.UseVisualStyleBackColor = true;
            this.butLoadSettingFile.Click += new System.EventHandler(this.butLoadSettingFile_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 340);
            this.Controls.Add(this.butLoadSettingFile);
            this.Controls.Add(this.butStop);
            this.Controls.Add(this.butExecute);
            this.Controls.Add(this.textLog);
            this.Controls.Add(this.butLoadDBFile);
            this.Controls.Add(this.butLoadImageFile);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.Text = "KSA NamePlate Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butLoadImageFile;
        private System.Windows.Forms.Button butLoadDBFile;
        private System.Windows.Forms.TextBox textLog;
        private System.Windows.Forms.Button butExecute;
        private System.Windows.Forms.Button butStop;
        private System.ComponentModel.BackgroundWorker executer;
        private System.Windows.Forms.Button butLoadSettingFile;
    }
}

