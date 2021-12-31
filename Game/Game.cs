using winform;
using CS_MyConsole;

namespace MyGame
{
    class Game
    {
        public static float UpdatesASecond = 100;
        public Form1 _Form;
        public List<Ball> balls;
        public int renderHeight;
        public int renderWidth;
        public int worldHeight = 19;
        public int worldWidth = 19;
        private GUI _GUI;
        private bool is_Running;
        public Game(Form1 _Form)
        {
            this._Form = _Form;
            renderHeight = _Form.ClientSize.Height;
            renderWidth = _Form.ClientSize.Width;
            balls = new List<Ball>();
            balls.Add(new Ball(new BallData(5, 5, 0.3f, -1, 1, 0.9f), Color.Red));
            balls.Add(new Ball(new BallData(5, 5, 0.3f, -1, 1, 0.95f), Color.Blue));
            balls.Add(new Ball(new BallData(6, 3, -0.3f, 0, 0.5f, 0.01f), Color.LightBlue));
            balls.Add(new Ball(new BallData(6, 3, -0.3f, 2, 0.7f, 0.9f), Color.LightCyan));
            balls.Add(new Ball(new BallData(1, 9, 0.3f, 1, 1, 0.95f), Color.HotPink));
            balls.Add(new Ball(new BallData(1, 9, 0.3f, 1, 1, 0.1f), Color.HotPink));
            balls.Add(new Ball(new BallData(5, 3, 0.3f, -1, 1, 0.9f), Color.Red));
            balls.Add(new Ball(new BallData(5, 2, 0.3f, -1, 1, 0.95f), Color.Blue));
            balls.Add(new Ball(new BallData(1, 2, -0.3f, 1, 0.5f, 0.07f), Color.LawnGreen));
            balls.Add(new Ball(new BallData(7, 6, -0.3f, 2, 0.7f, 0.9f), Color.OrangeRed));
            balls.Add(new Ball(new BallData(3, 9, 0.3f, 1, 1, 0.95f), Color.Yellow));
            balls.Add(new Ball(new BallData(4, 4, 0.3f, 1, 1, 0.6f), Color.HotPink));
            balls.Add(new Ball(new BallData(3, 5, 0.3f, -1, 1, 0.9f), Color.Red));
            balls.Add(new Ball(new BallData(2, 5, 0.3f, -1, 1, 0.95f), Color.Yellow));
            balls.Add(new Ball(new BallData(7, 3, -0.3f, 0, 0.5f, 0.01f), Color.MediumVioletRed));
            balls.Add(new Ball(new BallData(8, 3, -0.3f, 2, 0.7f, 0.9f), Color.LightCyan));
            balls.Add(new Ball(new BallData(9, 9, 0.3f, 1, 1, 0.95f), Color.Honeydew));
            balls.Add(new Ball(new BallData(9, 8, 0.3f, 1, 2, 0.4f), Color.HotPink));
            balls.Add(new Ball(new BallData(5, 8, 0.3f, -1, 1, 0.9f), Color.Red));
            balls.Add(new Ball(new BallData(2, 9, 0.3f, -1, 1, 0.95f), Color.Blue));
            balls.Add(new Ball(new BallData(1, 2, -0.3f, 0, 0.5f, 0.01f), Color.LightBlue));
            balls.Add(new Ball(new BallData(7, 6, -0.3f, 2, 0.7f, 0.9f), Color.Khaki));
            balls.Add(new Ball(new BallData(8, 9, 0.3f, 1, 1, 0.95f), Color.PaleTurquoise));
            balls.Add(new Ball(new BallData(2, 4, 0.3f, 1, 1, 0.5f), Color.Ivory));
            _GUI = new GUI(_Form);
            is_Running = false;
        }
        public void Stop() => is_Running = false;
        public void Play()
        {
            is_Running = true;

            _Form.KeyPress += MyKeyPress;

            _Form.MouseClick += MyMouseClick;

            int count = 0;

            // GUI.Reset(_Form, this);

            while (is_Running)
            {
                count++;
                // GUI.Reset(myForm, this);

                // _GUI.ResetBalls(balls);
                string timeSpend = "ball calculations";


                timeSpend += MyStopwatch.Measure(() =>
                {
                    foreach (Ball i in balls)
                    {
                        MyGame.BallPhysics.UpdateBall(i, worldHeight, worldWidth);
                    }
                });

                timeSpend += Environment.NewLine;

                timeSpend += "ball drawings";


                timeSpend += MyStopwatch.Measure(() =>
                {
                    foreach (Ball i in balls)
                    {
                        _GUI.DrawBall(i);
                    }
                });

                timeSpend += Environment.NewLine;

                timeSpend += "Drawing to form";
                timeSpend += MyStopwatch.Measure(() =>
                {
                    _GUI.Print();
                });

                _GUI.Reset();
                timeSpend += Environment.NewLine;



                // MyConsole.WriteLine(timeSpend);

                // GUI.RenderAndPrint(this);

                //test
                // myForm.DrawLine(new Point(10, 10), new Point(100, 100));

                // Thread.Sleep(500);
                // myForm.DrawLine(new Point(10, 10), new Point(100, 100), Color.Aqua);

                // Thread.Sleep(50);
                // if (count == UpdatesASecond * 10) // so every ~10 seconds this will run
                // {
                //     count = 0;
                //     BallPhysics.gravity *= -1f;
                //     BallPhysics.wind *= -1f;
                // }
                // Thread.Sleep(10);
            }
        }

        private void MyMouseClick(object? sender, MouseEventArgs e) // winform board = 800 x 800
        {
            // _GUI.ResetBalls(balls);

            float x = (float)e.X / (float)_Form.Width;
            float y = (float)e.Y / (float)_Form.Width;
            x *= worldWidth;
            y *= worldHeight;
            foreach (Ball ball in balls)
            {
                ball.ballData.x_pos = x;
                ball.ballData.y_pos = y;
            }
        }

        private void MyKeyPress(object? sender, KeyPressEventArgs e)
        {
            Random rnd = new Random();
            if (e.KeyChar == 'w')
            {
                foreach (Ball ball in balls)
                {
                    ball.ballData.y_velocity -= 1;
                }
            }
            if (e.KeyChar == 's')
            {
                foreach (Ball ball in balls)
                {
                    ball.ballData.y_velocity += 1;
                }
            }
            if (e.KeyChar == 'a')
            {
                foreach (Ball ball in balls)
                {
                    ball.ballData.x_velocity -= 1;
                }
            }
            if (e.KeyChar == 'd')
            {
                foreach (Ball ball in balls)
                {
                    ball.ballData.x_velocity += 1;
                }
            }
            if (e.KeyChar == (char)32)
            {
                BallPhysics.gravity *= -1f;
                BallPhysics.wind *= -1f;
            }
            if (e.KeyChar == 'e')
            {
                foreach (Ball ball in balls)
                {
                    ball.ballData.radius += 0.1f;
                }
            }
            if (e.KeyChar == 'q')
            {
                foreach (Ball ball in balls)
                {
                    ball.ballData.radius -= 0.1f;
                }
            }
            if (e.KeyChar == 'z')
            {
                foreach (Ball ball in balls)
                {
                    ball.ballData.bounciness += 0.1f;
                }
            }
            if (e.KeyChar == 'x')
            {
                foreach (Ball ball in balls)
                {
                    ball.ballData.bounciness -= 0.1f;
                }
            }
            if (e.KeyChar == 't')
            {
                BallPhysics.gravity += 0.01f;
            }
            if (e.KeyChar == 'g')
            {
                BallPhysics.gravity -= 0.01f;
            }
            if (e.KeyChar == 'y')
            {
                BallPhysics.wind += 0.01f;
            }
            if (e.KeyChar == 'h')
            {
                BallPhysics.wind -= 0.01f;
            }
            if (e.KeyChar == 'p')
            {
                foreach (Ball ball in balls)
                {
                    ball.ballData.x_velocity = 0;
                    ball.ballData.y_velocity = 0;
                }                
            }
            if (e.KeyChar == 'o')
            {
                foreach (Ball ball in balls)
                {
                    ball.ballData.x_velocity = (float)(rnd.NextDouble() - 0.5) * 5;
                    ball.ballData.y_velocity = (float)(rnd.NextDouble() - 0.5) * 5;
                }                
            }
        }
    }
}