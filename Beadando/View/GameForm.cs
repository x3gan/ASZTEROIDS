using Beadando.Model;
using System.Numerics;


namespace Beadando;

public partial class GameForm : Form
{
    private readonly List<PictureBox> _asteroids;
    private readonly MenuForm _pause = null!;
    private PictureBox _spaceShip;
    private GameModel _gM = null!;

    public GameModel GM { get { return _gM; } }

    public GameForm()
    {
        InitializeComponent();
        DoubleBuffered = true;
        _spaceShip = new PictureBox();
        _asteroids = new();
        ControlBox = false;
        _pause = new MenuForm(this, _gM);
    }

    public void StartGame()
    {
        CreateMap();

        _gM = new GameModel();
        #region Events
        _gM.AsteroidSpawnEvent += CreateAsteroid;
        _gM.PlayerCreateEvent += CreatePlayer;
        _gM.PlayerMoveEvent += MovePlayerPic;
        _gM.AsteroidMoveEvent += MoveAsteroidPic;
        _gM.CollisionCheckEvent += GameOverMenu;
        _gM.CounterTimerEvent += ChangeTimerLabel;
        #endregion

        _gM.GMStartGame();
        timeLabel.Visible = true;
        timeLabel.Text = "Time: 0s";
    }

    public void LoadGame(GameModel loadedGameModel)
    {
        CreateMap();

        _gM = loadedGameModel;
        foreach (var item in _gM.Coordinates)
        {

            PictureBox a = new()
            {
                Image = Properties.Resources.rockno_removebg_preview,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
                Tag = "asteroid",

                Size = new Size(60, 60),
                Location = new Point(item[0], item[1])
            };
            Controls.Add(a);
            _asteroids.Add(a);
        }

        #region Events
        _gM.AsteroidSpawnEvent += CreateAsteroid;
        _gM.PlayerCreateEvent += CreatePlayer;
        _gM.PlayerMoveEvent += MovePlayerPic;
        _gM.AsteroidMoveEvent += MoveAsteroidPic;
        _gM.CollisionCheckEvent += GameOverMenu;
        _gM.CounterTimerEvent += ChangeTimerLabel;
        #endregion

        _gM.GMStartGame();

        timeLabel.Visible = true;
        timeLabel.Text = "Time: " + loadedGameModel.SaveTime + "s";
        timeLabel.BringToFront();

    }

    private void ChangeTimerLabel()
    {
        timeLabel.Text = "Time: " + _gM.TimerCounter + "s";

        #region DEBUG
        //debug
        //label1.Text = _gM.Player.Location.X.ToString();
        //label2.Text = _spaceShip.Left.ToString();
        ///egyenlőek és ugyanúgy változnak
        ///debug clientwidth
        //label3.Text = this.ClientSize.Width.ToString(); //884
        //debug end
        #endregion
    }

    public void MovePlayerPic()
    {
        if (_gM.Player.GoLeft == true && _gM.Player.Location.X > 0 - 10)
            _spaceShip.Left = _gM.Player.Location.X;
        if (_gM.Player.GoRight == true && _gM.Player.Location.X < (900 - _gM.Player.Size.Width) - 10)
            _spaceShip.Left = _gM.Player.Location.X;
    }

    public void MoveAsteroidPic()
    {
        
        foreach (PictureBox ast in _asteroids)
        {
            ast.Top += 5;
        }
        
    }

    #region FormElementCreate
    private void CreateMap()
    {
        BackgroundImage = Properties.Resources.spacebg;
        BackgroundImageLayout = ImageLayout.Stretch;
        MinimumSize = new Size(900, 600);
        MaximumSize = new Size(900, 600);
        Size = new Size(900, 600);
        CenterToScreen();
        MaximizeBox = false;
    }
    private void CreatePlayer(object? sender, PlayerEventArgs pe)
    {
        _spaceShip = new()
        {
            Image = Properties.Resources.spaces_removebg_preview,
            SizeMode = PictureBoxSizeMode.StretchImage,
            BackColor = Color.Transparent,
            Size = pe.Szize,
            Left = 400,
            Top = 470,
            Tag = "player",
            Margin = new Padding(0),
            Location = pe.Lokation
        };
        Controls.Add(_spaceShip);
    }

    private void CreateAsteroid(object? sender, AsteroidEventArgs ae)
    {
        PictureBox asteroid = new()
        {
            Image = Properties.Resources.rockno_removebg_preview,
            SizeMode = PictureBoxSizeMode.StretchImage,
            Size = ae.Szize,
            BackColor = Color.Transparent,
            Tag = "asteroid",
            Margin = new Padding(0),

            Location = ae.Lokation
        };

        _asteroids.Add(asteroid);
        Controls.Add(asteroid);
    }
    #endregion

    private void GameForm_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                _gM.Player.GoLeft = true;
        if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                _gM.Player.GoRight = true;
        if (e.KeyCode == Keys.Escape)
            GamePausedMenu();
    }

    private void GameForm_KeyUp(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
            _gM.Player.GoLeft = false;
        if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
            _gM.Player.GoRight = false;
    }

    #region MENUS
    private void GamePausedMenu()
    {
        _gM.GamePause();
        _gM.SaveTime = _gM.TimerCounter;
        _pause.GamePausedScreen();
        Hide();
        _pause.Show();
    }

    private void GameOverMenu()
    {
        _gM.GamePause();
        _pause.GameOverScreen();
        Hide();
        _pause.Show();
    }
    #endregion

}