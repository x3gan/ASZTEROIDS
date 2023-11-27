using Beadando;
using Beadando.Model;
using System.Drawing;
using System.Windows.Forms;

namespace TestAgain
{
    [TestClass]
    public class TesztElek
    {
        
        [TestMethod]
        public void GameOverTest()
        {
            GameModel gM = new();
            gM.CreatePlayer(gM, EventArgs.Empty);
            Asteroid a = new(new Point(390, 475), new Size(60, 60));
            gM.AsteroidList.Add(a);
            
            gM.GMStartGame();
            gM.CheckCollision();
            Assert.IsTrue(gM.GameOver);

        }
        
        [TestMethod]
        public void GameInitalizeTest()
        {
            GameForm _view = new GameForm();
            _view.StartGame();
            Assert.AreEqual(0, _view.GM.TimerCounter);
            Assert.IsFalse(_view.GM.GameOver);
            Assert.IsFalse(_view.GM.Paused);
            Assert.AreEqual(0, _view.GM.SaveTime);
        }

        [TestMethod]
        public void GamePauseTest()
        {
            GameForm _view = new GameForm();
            _view.StartGame();
            _view.GM.GamePause();
            Assert.IsTrue(_view.GM.Paused);
        }

        [TestMethod]
        public void GameResumeTest()
        {
            GameForm _view = new GameForm();
            _view.StartGame();
            _view.GM.GamePause();
            _view.GM.ResumeTimers();
            Assert.IsFalse(_view.GM.Paused);
        }

        [TestMethod]
        public void CharacterCreationTest()
        {
            GameForm _view = new GameForm();
            _view.StartGame();
            Assert.IsNotNull(_view.GM.Player);
        }

        [TestMethod]
        public void PlayerTest()
        {
            Player p = new(new Point(370, 455), new Size(45, 70))
            {
                GoRight = true
            };
            p.PlayerControls();
            Assert.AreEqual(380, p.Location.X);
            Assert.AreEqual(455, p.Location.Y);
            p.GoRight = false;
            p.GoLeft = true;
            p.PlayerControls();
            p.PlayerControls();
            Assert.AreEqual(360, p.Location.X);
            Assert.AreEqual(455, p.Location.Y);
        }

        [TestMethod]
        public void AsteroidTest()
        {
            Asteroid a = new(new Point(370, 455), new Size(45, 70));
            a.MoveOneAsteroid();
            Assert.AreEqual(460, a.Location.Y);
            Assert.AreEqual(370, a.Location.X);

            a.MoveOneAsteroid();
            a.MoveOneAsteroid();
            a.MoveOneAsteroid();
            a.MoveOneAsteroid();
            Assert.AreEqual(480, a.Location.Y);
            Assert.AreEqual(370, a.Location.X);
        }
    }
}