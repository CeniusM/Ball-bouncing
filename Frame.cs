namespace MyGame
{
    class Frame
    {
        public Color[,] pixels;
        int height;
        int width;
        public Frame(int height, int width)
        {
            pixels = new Color[height, width];
            this.height = height;
            this.width = width;
        }
    }
}