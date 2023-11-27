using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beadando.Model
{
    public class GameModel : IDisposable
    {
        private System.Windows.Forms.Timer _asteroidSpawnTimer; 
        private System.Windows.Forms.Timer _mainMainTimer; 
        private System.Windows.Forms.Timer _counter; 
        private Player _p = null!;  
        private int _saveTime;  
        private int _timerCounter;  
        private bool _paused;
        private bool _gameOver;
        private readonly List<Asteroid> _asteroidList;  
        private readonly List<int[]> _coordinates;
        private readonly Random _rnd;

        #region EventsCreate
        public event EventHandler<AsteroidEventArgs> AsteroidSpawnEvent = null!;  
        public event EventHandler<PlayerEventArgs> PlayerCreateEvent = null!;  
        public event Action CollisionCheckEvent = null!;  
        public event Action AsteroidMoveEvent = null!; 
        public event Action PlayerMoveEvent = null!;  
        public event Action CounterTimerEvent = null!;
        #endregion

        public bool Paused { get { return _paused; }  set { _paused = value;  } }  
        public bool GameOver { get { return _gameOver;  } set { _gameOver = value;  } }  
        public int TimerCounter { get { return _timerCounter; } }  
        public int SaveTime { get { return _saveTime; } set { _saveTime = value; } }
        public List<int[]> Coordinates { get { return _coordinates; } }
        public List<Asteroid> AsteroidList { get { return _asteroidList; } }
        public Player Player { get { return _p; } }

        public void Dispose()
        {
            _asteroidSpawnTimer.Dispose();
            _counter.Dispose();
            _mainMainTimer.Dispose();
        }

        public GameModel()  
        {
            _timerCounter = 0;
            _saveTime = 0;
            _coordinates = new();

            _asteroidSpawnTimer = new();
            _mainMainTimer = new();
            _counter = new();
            _asteroidList = new();
            _rnd = new();

        }

        public GameModel(List<int[]> loadedCoordinates, int loadedSaveTime)  
        {
            _timerCounter = loadedSaveTime;
            _saveTime = loadedSaveTime;
            _coordinates = loadedCoordinates;

            _asteroidSpawnTimer = new();
            _mainMainTimer = new();
            _counter = new();
            _asteroidList = new();
            _rnd = new();

            AsteroidLoad(_coordinates);
            
        }

        private void AsteroidLoad(List<int[]> coordinates)  
        {
            foreach (var item in coordinates)
            {
                Asteroid aaa = new(new Point(item[0], item[1]), new Size(60, 60));
                _asteroidList.Add(aaa);
            }
        }

        public void GMStartGame()
        {
            GameOver = false;
            _paused = false;
            
            AsteroidSpawner();
            MainMainTimer();
            Counter();
            CreatePlayer(this, EventArgs.Empty);
        }

        public void CreatePlayer(object? sender, EventArgs e)  
        {
            _p = new Player(new Point(390, 475), new Size(45, 70));
            OnPlayerCreated(_p.Location, _p.Size);
        }


        private void Counter()  
        {
            _counter = new System.Windows.Forms.Timer();
            _counter.Tick += Counter_Tick;
            _counter.Interval = 1000;
            _counter.Start();
        }

        public void Counter_Tick(object? sender, EventArgs e)  
        {
            _timerCounter++;
            OnCounterTick();
        }


        private void MainMainTimer()  
        {
            _mainMainTimer = new System.Windows.Forms.Timer();
            _mainMainTimer.Tick += MainMainTimer_Tick;
            _mainMainTimer.Interval = 100;
            _mainMainTimer.Start();
        }

        private void MainMainTimer_Tick(object? sender, EventArgs e)
        {
            _p.PlayerControls();
            OnPlayerMove();

            for (int i = _asteroidList.Count - 1; i >= 0; i--)
            {
                Asteroid x = _asteroidList[i];
                x.MoveOneAsteroid();

                if (x.Location.Y > 800)
                {
                    _asteroidList.RemoveAt(i);
                    continue;
                }
                CheckCollision();
            }

            OnAsteroidMove();

            if (CheckCollision())
            {
                StopTimers();
                _saveTime = TimerCounter;
                GameOver = true;
                OnCollided();
            }
        }

        private void AsteroidSpawner()  
        {
            _asteroidSpawnTimer = new System.Windows.Forms.Timer();
            _asteroidSpawnTimer.Tick += AsteroidSpawnTimer_Tick;
            _asteroidSpawnTimer.Interval = 2001;

            _asteroidSpawnTimer.Start();
        }

        private void AsteroidSpawnTimer_Tick(object? sender, EventArgs e)
        {
            bool found;
            Point p;

            do
            {
                p = new Point(_rnd.Next(0, 900 - 60), 0);
                found = false; 

                foreach (Asteroid a in _asteroidList)
                {
                    int aX = a.Location.X;
                    int aY = a.Location.Y;
                    int aW = a.Size.Width;
                    int aH = a.Size.Height;

                    if (p.X < aX + aW && p.X + aW > aX && p.Y < aY + aH && p.Y + aH > aY)
                    {
                        found = true;
                        break; 
                    }
                }

            } while (found);

            Asteroid aaa = new(p, new Size(60, 60));
            _asteroidList.Add(aaa);

            OnAsteroidSpawned(aaa.Location, aaa.Size);

            if (_asteroidSpawnTimer.Interval != 1)
            {
                _asteroidSpawnTimer.Interval -= 10;
            }
        }


        public void GamePause()
        {
            _coordinates.Clear();
            _paused = true;
            StopTimers();

            int[] tempList;
            foreach (Asteroid x in _asteroidList)
            {
                tempList = new int[] { x.Location.X, x.Location.Y };
                _coordinates.Add(tempList);
                tempList = null!;
            }
        }

        public void StopTimers()
        {
            _asteroidSpawnTimer.Stop();
            _mainMainTimer.Stop();
            _counter.Stop();
        }

        public void ResumeTimers()  
        {
            _asteroidSpawnTimer.Start();
            _mainMainTimer.Start();
            _counter.Start();
            _paused = false;
        }

        //ütközések ellenőrzése
        public bool CheckCollision()
        {
            int pX = _p.Location.X;
            int pY = _p.Location.Y;
            int pW = _p.Size.Width;
            int pH = _p.Size.Height;

            for (int i = 0; i < _asteroidList.Count; i++)
            {
                Asteroid x = _asteroidList[i];
                
                    int aX = x.Location.X;
                    int aY = x.Location.Y;
                    int aW = x.Size.Width;
                    int aH = x.Size.Height;

                    if (pX < aX + aW && pX + pW > aX && pY < aY + aH && pY + pH > aY)
                    {
                       _gameOver = true;
                    }
            }
            
            return _gameOver;
        }

        #region INVOKES
        private void OnPlayerCreated(Point location, Size size)  
        {
            PlayerCreateEvent?.Invoke(this, new PlayerEventArgs(location, size));
        }
        public void OnCounterTick()  
        {
            CounterTimerEvent?.Invoke();
        }
        public void OnAsteroidSpawned(Point location, Size size)
        {
            AsteroidSpawnEvent?.Invoke(this, new AsteroidEventArgs(location, size));
        }
        private void OnAsteroidMove()  
        {
            AsteroidMoveEvent?.Invoke();
        }
        private void OnPlayerMove()  
        {
            PlayerMoveEvent?.Invoke();
        }
        private void OnCollided()
        {
            CollisionCheckEvent?.Invoke();
        }

        #endregion
    }
}
