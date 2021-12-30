namespace MyGame
{
    class Player
    {
        public PlayerData playerData;
        public Bitmap sprite;
        public Player(PlayerData aplayerData, Bitmap sprite)
        {
            playerData = aplayerData;
            this.sprite = sprite;
        }
    }
}