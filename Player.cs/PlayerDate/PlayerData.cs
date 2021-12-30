namespace MyGame
{
    class PlayerData
    {
        public float bounciness = 0f; // 0 - 1, 1 being the most bounci
        // public float rotation = 0f;
        // public float rotation_velocity = 0f;
        public float x_pos = 0f;
        public float y_pos = 0f;
        public float x_velocity = 0f;
        public float y_velocity = 0f;
        public int pxHeight = 0;
        public int pxWidth = 0;
        public PlayerData(float x_pos, float y_pos, float x_velocity, float y_velocity, int pxHeight, int pxWidth, float bounciness)
        {
            this.x_pos = x_pos;
            this.y_pos = y_pos;
            this.x_velocity = x_velocity;
            this.y_velocity = y_velocity;
            this.pxHeight = pxHeight;
            this.pxWidth = pxWidth;
            this.bounciness = bounciness;
        }
    }
}