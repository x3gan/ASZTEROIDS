namespace Beadando

{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            resumeButton = new Button();
            saveButton = new Button();
            pauseLabel = new Label();
            label1 = new Label();
            label2 = new Label();
            restartButton = new Button();
            startButton = new Button();
            quitButton = new Button();
            title = new Label();
            loadButton = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            quitGameButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // resumeButton
            // 
            resumeButton.Font = new Font("Courier New", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            resumeButton.Location = new Point(278, 197);
            resumeButton.Margin = new Padding(3, 2, 3, 2);
            resumeButton.Name = "resumeButton";
            resumeButton.Size = new Size(320, 48);
            resumeButton.TabIndex = 0;
            resumeButton.Text = "RESUME";
            resumeButton.UseVisualStyleBackColor = true;
            resumeButton.Visible = false;
            resumeButton.Click += resumeButton_Click;
            // 
            // saveButton
            // 
            saveButton.Font = new Font("Courier New", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            saveButton.Location = new Point(278, 292);
            saveButton.Margin = new Padding(3, 2, 3, 2);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(320, 48);
            saveButton.TabIndex = 1;
            saveButton.Text = "SAVE";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Visible = false;
            saveButton.Click += saveButton_Click;
            // 
            // pauseLabel
            // 
            pauseLabel.AutoSize = true;
            pauseLabel.Font = new Font("Courier New", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            pauseLabel.ForeColor = SystemColors.ButtonHighlight;
            pauseLabel.Location = new Point(309, 76);
            pauseLabel.Name = "pauseLabel";
            pauseLabel.Size = new Size(248, 40);
            pauseLabel.TabIndex = 3;
            pauseLabel.Text = "GAME PAUSED";
            pauseLabel.Visible = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(358, 148);
            label1.Name = "label1";
            label1.Size = new Size(148, 18);
            label1.TabIndex = 4;
            label1.Text = "YOUR TIME: 0 s";
            label1.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courier New", 25.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(331, 76);
            label2.Name = "label2";
            label2.Size = new Size(206, 40);
            label2.TabIndex = 5;
            label2.Text = "GAME OVER";
            label2.Visible = false;
            // 
            // restartButton
            // 
            restartButton.BackColor = Color.Transparent;
            restartButton.Font = new Font("Courier New", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            restartButton.Location = new Point(278, 197);
            restartButton.Margin = new Padding(3, 2, 3, 2);
            restartButton.Name = "restartButton";
            restartButton.Size = new Size(320, 48);
            restartButton.TabIndex = 6;
            restartButton.Text = "RESTART";
            restartButton.UseVisualStyleBackColor = false;
            restartButton.Visible = false;
            restartButton.Click += restartButton_Click;
            // 
            // startButton
            // 
            startButton.Font = new Font("Courier New", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            startButton.Location = new Point(278, 240);
            startButton.Margin = new Padding(3, 2, 3, 2);
            startButton.Name = "startButton";
            startButton.Size = new Size(320, 48);
            startButton.TabIndex = 8;
            startButton.Text = "START";
            startButton.UseVisualStyleBackColor = true;
            startButton.Visible = false;
            startButton.Click += startButton_Click;
            // 
            // quitButton
            // 
            quitButton.BackColor = Color.Transparent;
            quitButton.Font = new Font("Courier New", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            quitButton.Location = new Point(200, 405);
            quitButton.Margin = new Padding(3, 2, 3, 2);
            quitButton.Name = "quitButton";
            quitButton.Size = new Size(472, 48);
            quitButton.TabIndex = 9;
            quitButton.Text = "QUIT TO MAIN MENU";
            quitButton.UseVisualStyleBackColor = false;
            quitButton.Visible = false;
            quitButton.Click += quitButton_Click;
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Courier New", 32.8F, FontStyle.Bold, GraphicsUnit.Point);
            title.ForeColor = SystemColors.ButtonHighlight;
            title.Location = new Point(293, 116);
            title.Name = "title";
            title.Size = new Size(282, 50);
            title.TabIndex = 11;
            title.Text = "ASZTEROIDS";
            title.Visible = false;
            // 
            // loadButton
            // 
            loadButton.Font = new Font("Courier New", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            loadButton.Location = new Point(278, 322);
            loadButton.Margin = new Padding(3, 2, 3, 2);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(320, 48);
            loadButton.TabIndex = 12;
            loadButton.Text = "LOAD SAVE";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Visible = false;
            loadButton.Click += loadButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(75, 54);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 177);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(703, 54);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(100, 177);
            pictureBox2.TabIndex = 14;
            pictureBox2.TabStop = false;
            pictureBox2.Visible = false;
            // 
            // quitGameButton
            // 
            quitGameButton.BackColor = Color.Transparent;
            quitGameButton.Font = new Font("Courier New", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point);
            quitGameButton.Location = new Point(226, 405);
            quitGameButton.Margin = new Padding(3, 2, 3, 2);
            quitGameButton.Name = "quitGameButton";
            quitGameButton.Size = new Size(418, 48);
            quitGameButton.TabIndex = 15;
            quitGameButton.Text = "QUIT GAME";
            quitGameButton.UseVisualStyleBackColor = false;
            quitGameButton.Visible = false;
            quitGameButton.Click += quitGameButton_Click;
            // 
            // MenuForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(41, 40, 60);
            ClientSize = new Size(884, 561);
            Controls.Add(quitGameButton);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(loadButton);
            Controls.Add(title);
            Controls.Add(quitButton);
            Controls.Add(startButton);
            Controls.Add(restartButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pauseLabel);
            Controls.Add(saveButton);
            Controls.Add(resumeButton);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(900, 600);
            MinimumSize = new Size(900, 600);
            Name = "MenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ASZTEROIDS";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button resumeButton;
        private Button saveButton;
        public Label pauseLabel;
        private Label label1;
        public Label label2;
        public Button restartButton;
        public Button startButton;
        public Button quitButton;
        public Label title;
        public Button loadButton;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        public Button quitGameButton;
    }
}