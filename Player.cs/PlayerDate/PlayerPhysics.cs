namespace MyGame
{
    class PlayerPhysics
    {
        public static float gravity = 0.1f;
        public static void UpdatePlayer(Player player, int height, int width)
        {
            TestWall(player, height, width);
            UpdateVector(player, height, width);
            UpdateGravity(player, height, width);
        }
        public static void Drag(Player player)
        {
            player.playerData.x_velocity *= 0.5f;
            player.playerData.y_velocity *= 0.5f;
        }
        private static void UpdateVector(Player player, int height, int width)
        {
            player.playerData.x_pos += player.playerData.x_velocity;
            player.playerData.y_pos += player.playerData.y_velocity;
        }
        private static void UpdateGravity(Player player, int height, int width)
        {
            player.playerData.y_velocity += gravity = 0.02f;
        }
        private static void TestWall(Player player, int height, int width)
        {
            if (player.playerData.x_pos > width) // right wall
            {
                if (player.playerData.x_velocity > 0)
                {
                    player.playerData.x_velocity *= -1;
                    player.playerData.x_velocity *= player.playerData.bounciness;
                }
            }
            if (player.playerData.x_pos < 0) // left wall
            {
                if (player.playerData.x_velocity < 0)
                {
                    player.playerData.x_velocity *= -1;
                    player.playerData.x_velocity *= player.playerData.bounciness;
                }
            }
            if (player.playerData.y_pos > height) // floor
            {
                if (player.playerData.y_velocity > 0)
                {
                    player.playerData.y_velocity *= -1;
                    player.playerData.y_velocity *= 0;
                }
            }
            if (player.playerData.y_pos < 0) // roof
            {
                if (player.playerData.y_velocity < 0)
                {
                    player.playerData.y_velocity *= -1;
                    player.playerData.y_velocity *= player.playerData.bounciness;
                }
            }
        }
    }
}