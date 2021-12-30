namespace MyGame
{
    class BallPhysics
    {
        // public BallPhysics()
        // {

        // }
        public static float gravity = 0.02f;
        public static float wind = 0.005f;
        public static void UpdateBall(Ball ball, int height, int width)
        {
            TestWall(ball, height, width);
            UpdateVector(ball, height, width);
            UpdateGravity(ball, height, width);
            UpdateWind(ball, height, width);
        }
        private static void UpdateVector(Ball ball, int height, int width)
        {
            // ball.ballData.x_velocity *= 0.2f; // makes it not go faster when you update faseter
            // ball.ballData.y_velocity *= 0.2f;

            ball.ballData.x_pos += ball.ballData.x_velocity * (10 / Game.UpdatesASecond);
            ball.ballData.y_pos += ball.ballData.y_velocity * (10 / Game.UpdatesASecond);
        }
        private static void UpdateGravity(Ball ball, int height, int width)
        {
            if (!(ball.ballData.y_pos > height / 0.95)) // the height above the ground
                ball.ballData.y_velocity += gravity;
        }
        private static void UpdateWind(Ball ball, int height, int width)
        {
            ball.ballData.x_velocity += wind;
        }
        private static void TestWall(Ball ball, int height, int width)
        {
            if (ball.ballData.x_pos > width) // right wall
            {
                if (ball.ballData.x_velocity > 0)
                {
                    ball.ballData.x_velocity *= -1;
                    ball.ballData.x_velocity *= ball.ballData.bounciness;
                }
            }
            if (ball.ballData.x_pos < 0) // left wall
            {
                if (ball.ballData.x_velocity < 0)
                {
                    ball.ballData.x_velocity *= -1;
                    ball.ballData.x_velocity *= ball.ballData.bounciness;
                }
            }
            if (ball.ballData.y_pos > height) // floor
            {
                if (ball.ballData.y_velocity > 0)
                {
                    ball.ballData.y_velocity *= -1;
                    ball.ballData.y_velocity *= ball.ballData.bounciness;
                }
            }
            if (ball.ballData.y_pos < 0) // roof
            {
                if (ball.ballData.y_velocity < 0)
                {
                    ball.ballData.y_velocity *= -1;
                    ball.ballData.y_velocity *= ball.ballData.bounciness;
                }
            }
        }
    }
}