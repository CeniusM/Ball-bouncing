// using winform;
// using CS_MyConsole;

// namespace MyGame // Player thats runs around
// {
//     class Game : Form1
//     {
//         public Form1 myForm;
//         public Player player;
//         public Bitmap BackGround;
//         public int renderHeight;
//         public int renderWidth;
//         public int worldHeight = 10;
//         public int worldWidth = 10;
//         public List<char> playerKeyInput = new List<char>();
//         public Game(Form1 myForm)
//         {
//             this.myForm = myForm;

//             BackGround = new Bitmap(@"Game\Background\BackGround.png");

//             myForm.KeyPress += PlayerMove;

//             player = new Player(new PlayerData(5, 5, 0, 0, 100, 100, 0.05f), new Bitmap(@"Player.cs\sprites\Player.bmp"));

//             renderHeight = myForm.Height - player.playerData.pxHeight;
//             renderWidth = myForm.Width - player.playerData.pxWidth;
//         }
//         public void Setup()
//         {
//             Ticks();
//         }
//         public void MyUpdate()
//         {
//             UpdatePlayerInputs();

//             PlayerPhysics.Drag(player);
//             PlayerPhysics.UpdatePlayer(player, 10, 10);



//             Bitmap canvas = new Bitmap(BackGround, 1000, 1000);
//             Graphics g = Graphics.FromImage(canvas);
//             g.DrawImage(player.sprite, new Point((int)(player.playerData.x_pos / worldWidth * renderWidth - (player.playerData.pxHeight / 2)), (int)(player.playerData.y_pos / worldHeight * renderHeight - (player.playerData.pxWidth / 2))));
//             // g.DrawImage(player.sprite, new Point((int)(player.playerData.y_pos / worldHeight * renderHeight), 100));
//             myForm.Drawbitmap(canvas, 0, 0);

//             // Bitmap playerMap = new Bitmap(player.sprite, player.playerData.pxHeight, player.playerData.pxWidth);

//             // myForm.Drawbitmap(playerMap, (int)(player.playerData.x_pos / worldWidth * renderWidth), (int)(player.playerData.y_pos / worldHeight * renderHeight));
//         }
//         public void PlayerMove(object? sender, KeyPressEventArgs e) // shit code
//         { // dosent send in when key is lifted? KeyEventHandler? dosent have char
//             // myForm.DrawLine(new Point(10, 10), new Point(100, 100));
//             if (e.KeyChar == 'a')
//             {
//                 ChangePlayerInputList('a');
//             }
//             else if (e.KeyChar == 'd')
//             {
//                 ChangePlayerInputList('d');
//             }
//             else if (e.KeyChar == (char)32)
//             {
//                 ChangePlayerInputList((char)32);
//             }
//             // if (e.KeyChar == 'a')
//             //     RunLeft();
//             // else if (e.KeyChar == 'd')
//             //     RunRight();
//             // else if (e.KeyChar == 32)
//             //     Jump();
//         }
//         private void ChangePlayerInputList(char c) // make a class for this :D, this also makes it easy to do multiplayer
//         {
//             if (playerKeyInput.Contains(c))
//             {
//                 for (int i = 0; i < playerKeyInput.Count; i++)
//                 {
//                     if (playerKeyInput[i] == c)
//                         playerKeyInput.RemoveAt(i);
//                 }
//             }
//             else playerKeyInput.Add(c);
//         }
//         public void RunLeft()
//         {
//             if (player.playerData.x_velocity > -0.3f && player.playerData.x_velocity < 0.4f)
//                 player.playerData.x_velocity -= 0.05f;
//         }
//         public void RunRight()
//         {
//             if (player.playerData.x_velocity > -0.4f && player.playerData.x_velocity < 0.3f)
//                 player.playerData.x_velocity += 0.1f;
//         }
//         public void Jump()
//         {
//             if (player.playerData.y_velocity < 0.1f && player.playerData.y_velocity > -0.1f)
//                 player.playerData.y_velocity -= 0.5f;
//         }
//         public void Ticks()
//         {
//             while (true)
//             {
//                 MyUpdate();

//                 Thread.Sleep(0);
//             }
//         }

//         private void UpdatePlayerInputs()
//         {
//             foreach (char c in playerKeyInput)
//             {
//                 if (c == 'a')
//                     RunLeft();
//                 else if (c == 'd')
//                     RunRight();
//                 else if (c == 32)
//                     Jump();
//             }
//         }
//     }
// }