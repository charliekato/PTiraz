namespace PTiraz
{
    partial class CustomMessageBox
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
            btnOK = new Button();
            lblMessage = new Label();
            SuspendLayout();
            // 
            // btnOK
            // 
            btnOK.Location = new Point(854, 341);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(113, 71);
            btnOK.TabIndex = 0;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Font = new Font("Yu Gothic UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 128);
            lblMessage.ForeColor = Color.IndianRed;
            lblMessage.Location = new Point(54, 95);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(975, 170);
            lblMessage.TabIndex = 1;
            lblMessage.Text = "距離が変わります";
            // 
            // CustomMessageBox
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1722, 482);
            Controls.Add(lblMessage);
            Controls.Add(btnOK);
            Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Name = "CustomMessageBox";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOK;
        private Label lblMessage;
    }
}