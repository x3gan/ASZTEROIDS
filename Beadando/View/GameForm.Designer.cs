namespace Beadando
{
    partial class GameForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            timerCounterTimer = new System.Windows.Forms.Timer(components);
            timeLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // timerCounterTimer
            // 
            timerCounterTimer.Enabled = true;
            timerCounterTimer.Interval = 1000;
            // 
            // timeLabel
            // 
            timeLabel.AutoSize = true;
            timeLabel.BackColor = Color.Transparent;
            timeLabel.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            timeLabel.ForeColor = SystemColors.ButtonHighlight;
            timeLabel.Location = new Point(12, 521);
            timeLabel.Name = "timeLabel";
            timeLabel.Size = new Size(78, 18);
            timeLabel.TabIndex = 0;
            timeLabel.Text = "Time: 0";
            timeLabel.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(78, 228);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "label1";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 275);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 2;
            label2.Text = "label2";
            label2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(485, 228);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 3;
            label3.Text = "label3";
            label3.Visible = false;
            // 
            // GameForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(882, 553);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(timeLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            Name = "GameForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ASZTEROIDS";
            KeyDown += GameForm_KeyDown;
            KeyUp += GameForm_KeyUp;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Timer timerCounterTimer;
        public Label timeLabel;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}