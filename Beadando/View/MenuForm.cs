using Beadando.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Beadando.Persistence;
using System.Diagnostics.Metrics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.DataFormats;

namespace Beadando

{
    public partial class MenuForm : Form
    {
        private readonly GameForm _form1Ref = null!;
        private readonly GameModel _gMRef = null!;

        
        public MenuForm()
        {
            InitializeComponent();
            StartMenu();
            ControlBox = false;
        }
        

        public MenuForm(GameForm form1, GameModel gameModel)
        {
            _form1Ref = form1;
            _gMRef = gameModel;

            InitializeComponent();

            MinimumSize = new Size(900, 600);
            MaximumSize = new Size(900, 600);
            Size = new Size(900, 600);
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            ControlBox = false;
        }

        private void StartMenu()
        {
            Controls.Clear();

            pictureBox1.Visible = true;
            Controls.Add(pictureBox1);

            pictureBox2.Visible = true;
            Controls.Add(pictureBox2);

            title.Visible = true;
            Controls.Add(title);

            startButton.Visible = true;
            Controls.Add(startButton);

            quitGameButton.Visible = true;
            Controls.Add(quitGameButton);

            loadButton.Visible = true;
            Controls.Add(loadButton);
        }

        public void GamePausedScreen()
        {
            Controls.Clear();

            quitButton.Visible = true;
            Controls.Add(quitButton);
            
            saveButton.Visible = true;
            Controls.Add(saveButton);
            
            resumeButton.Visible = true;
            Controls.Add(resumeButton);
        
            pauseLabel.Visible = true;
            Controls.Add(pauseLabel);

            Controls.Add(label1);
            label1.Visible = true;
            label1.Text = "YOUR TIME: " + _form1Ref.GM.SaveTime.ToString() + "s";
        
        }

        
        public void GameOverScreen()
        {
            Controls.Clear();

            label2.Visible = true;
            Controls.Add(label2);

            label1.Visible = true;
            label1.Text = "YOUR TIME: " + _form1Ref.GM.SaveTime.ToString() + "s";
            Controls.Add(label1);

            quitButton.Visible = true;
            Controls.Add(quitButton);
            quitButton.Location = new Point(200, 292);

            restartButton.Visible = true;
            Controls.Add(restartButton);
        }
        

        private void startButton_Click(object? sender, EventArgs e)
        {
            GameForm form1 = new();
            form1.StartGame();
            Hide();
            form1.ShowDialog();
        }
        private void CloseFormCucc(object? sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void ResumeGame()
        {
            _form1Ref.GM.ResumeTimers();
            _form1Ref.GM.Paused = false;
            Hide();
            _form1Ref.Show();
        }

        private async void saveButton_Click(object? sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new()
            {
                Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
            };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    await Fajl.SaveAsync(saveFileDialog.FileName, _gMRef);
                }
                catch (Exception)
                {
                    MessageBox.Show("Couldn't save game.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            StartMenu();
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            Hide();
            _form1Ref.Show();
            _form1Ref.Controls.Clear();

            _form1Ref.StartGame();

            _form1Ref.timeLabel.Visible = true;
            _form1Ref.timeLabel.Text = "Time: " + 0 + "s";
            _form1Ref.Controls.Add(_form1Ref.timeLabel);

        }

        private async void loadButton_Click(object sender, EventArgs e)
        {
            try
            {
                GameForm form1 = new();
                string path = "";
                OpenFileDialog openFileDialog = new()
                {
                    Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                }

                GameModel loadedGameModel = await Fajl.LoadAsync(openFileDialog.FileName);
                form1.LoadGame(loadedGameModel);
                Hide();
                form1.FormClosed += CloseFormCucc;
                form1.ShowDialog();
            }catch(Exception)
            {
                MessageBox.Show("Couldn't load game.", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resumeButton_Click(object? sender, EventArgs e)
        {
            ResumeGame();
        }

        private void quitGameButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
