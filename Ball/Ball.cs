namespace MyGame
{
    class Ball
    {
        public BallData ballData { get; private set; }
        public Color color = new Color();
        public Ball(BallData anewBall, Color color)
        {
            ballData = anewBall;
            this.color = color;
        }

        public void BallTick()
        {

        }
    }
}