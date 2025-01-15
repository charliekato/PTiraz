namespace PTiraz
{

    partial class MainForm
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
            lblCurrentRace = new Label();
            lblClassGender = new Label();
            lblDistanceStyle = new Label();
            label1 = new Label();
            lblCurrentTime = new Label();
            lblRaceNo = new Label();
            SuspendLayout();
            // 
            // lblCurrentRace
            // 
            lblCurrentRace.AutoSize = true;
            lblCurrentRace.Font = new Font("ＭＳ Ｐ明朝", 28.125F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblCurrentRace.Location = new Point(621, 43);
            lblCurrentRace.Name = "lblCurrentRace";
            lblCurrentRace.Size = new Size(458, 75);
            lblCurrentRace.TabIndex = 0;
            lblCurrentRace.Text = "現在のレース";
            // 
            // lblClassGender
            // 
            lblClassGender.AutoSize = true;
            lblClassGender.Font = new Font("ＭＳ Ｐ明朝", 48F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblClassGender.Location = new Point(197, 262);
            lblClassGender.Name = "lblClassGender";
            lblClassGender.Size = new Size(679, 128);
            lblClassGender.TabIndex = 1;
            lblClassGender.Text = "クラス・性別\n";
            lblClassGender.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDistanceStyle
            // 
            lblDistanceStyle.AutoSize = true;
            lblDistanceStyle.Font = new Font("ＭＳ Ｐ明朝", 48F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblDistanceStyle.Location = new Point(216, 411);
            lblDistanceStyle.Name = "lblDistanceStyle";
            lblDistanceStyle.Size = new Size(635, 128);
            lblDistanceStyle.TabIndex = 2;
            lblDistanceStyle.Text = "距離・種目";
            lblDistanceStyle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.ForeColor = SystemColors.ButtonShadow;
            label1.Location = new Point(1496, 583);
            label1.Name = "label1";
            label1.Size = new Size(265, 30);
            label1.TabIndex = 3;
            label1.Text = "大津市水泳協会　加藤美孝";
            // 
            // lblCurrentTime
            // 
            lblCurrentTime.AutoSize = true;
            lblCurrentTime.Font = new Font("Yu Gothic UI", 20F);
            lblCurrentTime.Location = new Point(1487, 11);
            lblCurrentTime.Name = "lblCurrentTime";
            lblCurrentTime.Size = new Size(138, 72);
            lblCurrentTime.TabIndex = 4;
            lblCurrentTime.Text = "時刻";
            // 
            // lblRaceNo
            // 
            lblRaceNo.AutoSize = true;
            lblRaceNo.Font = new Font("ＭＳ Ｐ明朝", 48F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblRaceNo.Location = new Point(197, 118);
            lblRaceNo.Name = "lblRaceNo";
            lblRaceNo.Size = new Size(690, 128);
            lblRaceNo.TabIndex = 5;
            lblRaceNo.Text = "競技番号 : ";
            lblRaceNo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1764, 622);
            Controls.Add(lblRaceNo);
            Controls.Add(lblCurrentTime);
            Controls.Add(label1);
            Controls.Add(lblDistanceStyle);
            Controls.Add(lblClassGender);
            Controls.Add(lblCurrentRace);
            Name = "MainForm";
            Text = "一般社団法人　大津市水泳協会　　";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCurrentRace;
        private Label lblClassGender;
        private Label lblDistanceStyle;
        private Label label1;
        private Label lblCurrentTime;
        private Label lblRaceNo;
    }

}