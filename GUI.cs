// using winform;

// namespace MyGame
// {
//     class GUI
//     {
//         private static Frame Render(Game game)
//         {
//             Frame frame = new Frame(game.renderHeight, game.renderWidth);

//             float renderX = 0;
//             float renderY = 0;

//             for (int i = 0; i < game.renderHeight; i++)
//             {
//                 for (int j = 0; j < game.renderWidth; j++)
//                 {
//                     renderX = (float)i / (float)game.renderHeight;
//                     renderY = (float)j / (float)game.renderWidth;

//                     if (GameLogic.GetLenght(renderX, renderY, game.balls[0].ballData.x_pos, game.balls[0].ballData.y_pos) < 1)
//                     {
//                         frame.pixels[i, j] = Color.FromArgb(255, 200, 2, 2);
//                     }
//                 }
//             }

//             return frame;
//         }
//         private static void Print(Form1 myForm, Frame frame, int renderHeight, int renderWidth)
//         {
//             Bitmap canvas = new Bitmap(renderHeight, renderWidth);

//             for (int i = 0; i < renderHeight; i++)
//             {
//                 for (int j = 0; j < renderWidth; j++)
//                 {
//                     canvas.SetPixel(i, j, frame.pixels[i, j]);
//                 }
//             }

//             myForm.PrintBitMap(canvas);
//         }
//         public static void RenderAndPrint(Game game)
//         {
//             Print(game._Form, Render(game), game.renderHeight, game.renderWidth);

//             //TEST
//             Bitmap canvas = new Bitmap(game.renderHeight, game.renderWidth);

//             for (int i = 0; i < game.renderHeight; i++)
//             {
//                 for (int j = 0; j < game.renderWidth; j++)
//                 {
//                     canvas.SetPixel(i, j, Color.FromArgb(255, 200, 2, 2));
//                 }
//             }

//             game._Form.PrintBitMap(canvas);
//         }
//         public static void DrawBall(Form1 myForm, Ball ball)
//         {
//             int x = (int)(ball.ballData.x_pos * 40);
//             int y = (int)(ball.ballData.y_pos * 40);
//             int r = (int)(ball.ballData.radius * 40);

//             myForm.DrawBall(new Point(x, y), r, ball.color);
//         }

//         public static void Reset(Form1 myForm, Game game)
//         {
//             Bitmap canvas = new Bitmap(game.renderHeight, game.renderWidth);

//             for (int i = 0; i < game.renderHeight; i++)
//             {
//                 for (int j = 0; j < game.renderWidth; j++)
//                 {
//                     canvas.SetPixel(i, j, Color.White);
//                 }
//             }

//             myForm.PrintBitMap(canvas);
//         }
//         public static void ResetBalls(Form1 myForm, List<Ball> balls)
//         {
//             foreach (Ball i in balls) // removes the balls
//             {
//                 int x = (int)(i.ballData.x_pos * 40);
//                 int y = (int)(i.ballData.y_pos * 40);
//                 int r = (int)(i.ballData.radius * 40);
//                 myForm.DrawBall(new Point(x, y), r, Color.White);
//             }
//         }
//     }
// }