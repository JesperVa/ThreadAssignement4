namespace SwimmingPool
{
    partial class Form1
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
            this.receptionBox = new System.Windows.Forms.GroupBox();
            this.statusLbl = new System.Windows.Forms.Label();
            this.comWaitingLbl = new System.Windows.Forms.Label();
            this.advWaitingLbl = new System.Windows.Forms.Label();
            this.poolBtn = new System.Windows.Forms.Button();
            this.advPoolBox = new System.Windows.Forms.GroupBox();
            this.advVisitorsLbl = new System.Windows.Forms.Label();
            this.advLimitLbl = new System.Windows.Forms.Label();
            this.comPoolBox = new System.Windows.Forms.GroupBox();
            this.comVisitorsLbl = new System.Windows.Forms.Label();
            this.comLimitLbl = new System.Windows.Forms.Label();
            this.advExitLbl = new System.Windows.Forms.Label();
            this.comExitsLbl = new System.Windows.Forms.Label();
            this.receptionBox.SuspendLayout();
            this.advPoolBox.SuspendLayout();
            this.comPoolBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // receptionBox
            // 
            this.receptionBox.Controls.Add(this.statusLbl);
            this.receptionBox.Controls.Add(this.comWaitingLbl);
            this.receptionBox.Controls.Add(this.advWaitingLbl);
            this.receptionBox.Controls.Add(this.poolBtn);
            this.receptionBox.Location = new System.Drawing.Point(12, 12);
            this.receptionBox.Name = "receptionBox";
            this.receptionBox.Size = new System.Drawing.Size(346, 526);
            this.receptionBox.TabIndex = 0;
            this.receptionBox.TabStop = false;
            this.receptionBox.Text = "Reception";
            // 
            // statusLbl
            // 
            this.statusLbl.AutoSize = true;
            this.statusLbl.Location = new System.Drawing.Point(11, 311);
            this.statusLbl.Name = "statusLbl";
            this.statusLbl.Size = new System.Drawing.Size(148, 17);
            this.statusLbl.TabIndex = 3;
            this.statusLbl.Text = "Current status: Closed";
            // 
            // comWaitingLbl
            // 
            this.comWaitingLbl.AutoSize = true;
            this.comWaitingLbl.Location = new System.Drawing.Point(13, 382);
            this.comWaitingLbl.Name = "comWaitingLbl";
            this.comWaitingLbl.Size = new System.Drawing.Size(147, 17);
            this.comWaitingLbl.TabIndex = 2;
            this.comWaitingLbl.Text = "Waiting common pool:";
            // 
            // advWaitingLbl
            // 
            this.advWaitingLbl.AutoSize = true;
            this.advWaitingLbl.Location = new System.Drawing.Point(6, 89);
            this.advWaitingLbl.Name = "advWaitingLbl";
            this.advWaitingLbl.Size = new System.Drawing.Size(158, 17);
            this.advWaitingLbl.TabIndex = 1;
            this.advWaitingLbl.Text = "Waiting adventure pool:";
            // 
            // poolBtn
            // 
            this.poolBtn.Location = new System.Drawing.Point(55, 244);
            this.poolBtn.Name = "poolBtn";
            this.poolBtn.Size = new System.Drawing.Size(192, 33);
            this.poolBtn.TabIndex = 0;
            this.poolBtn.Text = "Open pool";
            this.poolBtn.UseVisualStyleBackColor = true;
            this.poolBtn.Click += new System.EventHandler(this.poolBtn_Click);
            // 
            // advPoolBox
            // 
            this.advPoolBox.Controls.Add(this.advVisitorsLbl);
            this.advPoolBox.Controls.Add(this.advLimitLbl);
            this.advPoolBox.Location = new System.Drawing.Point(365, 13);
            this.advPoolBox.Name = "advPoolBox";
            this.advPoolBox.Size = new System.Drawing.Size(521, 247);
            this.advPoolBox.TabIndex = 1;
            this.advPoolBox.TabStop = false;
            this.advPoolBox.Text = "Adventure Pool";
            // 
            // advVisitorsLbl
            // 
            this.advVisitorsLbl.AutoSize = true;
            this.advVisitorsLbl.Location = new System.Drawing.Point(192, 33);
            this.advVisitorsLbl.Name = "advVisitorsLbl";
            this.advVisitorsLbl.Size = new System.Drawing.Size(109, 17);
            this.advVisitorsLbl.TabIndex = 1;
            this.advVisitorsLbl.Text = "Current Visitors:";
            // 
            // advLimitLbl
            // 
            this.advLimitLbl.AutoSize = true;
            this.advLimitLbl.Location = new System.Drawing.Point(6, 34);
            this.advLimitLbl.Name = "advLimitLbl";
            this.advLimitLbl.Size = new System.Drawing.Size(41, 17);
            this.advLimitLbl.TabIndex = 0;
            this.advLimitLbl.Text = "Limit:";
            // 
            // comPoolBox
            // 
            this.comPoolBox.Controls.Add(this.comVisitorsLbl);
            this.comPoolBox.Controls.Add(this.comLimitLbl);
            this.comPoolBox.Location = new System.Drawing.Point(364, 280);
            this.comPoolBox.Name = "comPoolBox";
            this.comPoolBox.Size = new System.Drawing.Size(521, 258);
            this.comPoolBox.TabIndex = 2;
            this.comPoolBox.TabStop = false;
            this.comPoolBox.Text = "Common Pool";
            // 
            // comVisitorsLbl
            // 
            this.comVisitorsLbl.AutoSize = true;
            this.comVisitorsLbl.Location = new System.Drawing.Point(193, 31);
            this.comVisitorsLbl.Name = "comVisitorsLbl";
            this.comVisitorsLbl.Size = new System.Drawing.Size(107, 17);
            this.comVisitorsLbl.TabIndex = 1;
            this.comVisitorsLbl.Text = "Current visitors:";
            // 
            // comLimitLbl
            // 
            this.comLimitLbl.AutoSize = true;
            this.comLimitLbl.Location = new System.Drawing.Point(19, 31);
            this.comLimitLbl.Name = "comLimitLbl";
            this.comLimitLbl.Size = new System.Drawing.Size(41, 17);
            this.comLimitLbl.TabIndex = 0;
            this.comLimitLbl.Text = "Limit:";
            // 
            // advExitLbl
            // 
            this.advExitLbl.AutoSize = true;
            this.advExitLbl.Location = new System.Drawing.Point(892, 76);
            this.advExitLbl.Name = "advExitLbl";
            this.advExitLbl.Size = new System.Drawing.Size(34, 17);
            this.advExitLbl.TabIndex = 3;
            this.advExitLbl.Text = "Exit:";
            // 
            // comExitsLbl
            // 
            this.comExitsLbl.AutoSize = true;
            this.comExitsLbl.Location = new System.Drawing.Point(897, 357);
            this.comExitsLbl.Name = "comExitsLbl";
            this.comExitsLbl.Size = new System.Drawing.Size(34, 17);
            this.comExitsLbl.TabIndex = 4;
            this.comExitsLbl.Text = "Exit:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1063, 544);
            this.Controls.Add(this.comExitsLbl);
            this.Controls.Add(this.advExitLbl);
            this.Controls.Add(this.comPoolBox);
            this.Controls.Add(this.advPoolBox);
            this.Controls.Add(this.receptionBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.receptionBox.ResumeLayout(false);
            this.receptionBox.PerformLayout();
            this.advPoolBox.ResumeLayout(false);
            this.advPoolBox.PerformLayout();
            this.comPoolBox.ResumeLayout(false);
            this.comPoolBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox receptionBox;
        private System.Windows.Forms.Label comWaitingLbl;
        private System.Windows.Forms.Label advWaitingLbl;
        private System.Windows.Forms.Button poolBtn;
        private System.Windows.Forms.GroupBox advPoolBox;
        private System.Windows.Forms.GroupBox comPoolBox;
        private System.Windows.Forms.Label advVisitorsLbl;
        private System.Windows.Forms.Label advLimitLbl;
        private System.Windows.Forms.Label comVisitorsLbl;
        private System.Windows.Forms.Label comLimitLbl;
        private System.Windows.Forms.Label advExitLbl;
        private System.Windows.Forms.Label comExitsLbl;
        private System.Windows.Forms.Label statusLbl;
    }
}

