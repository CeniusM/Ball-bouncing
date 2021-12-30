namespace winform;

public partial class Form1 : Form
{
    public System.Drawing.Graphics graphicsObj;
    // public event KeyPressEventHandler MyKeyPress;
    // public event KeyPressEventHandler MyKeyPress;
    // Control control;
    public Form1()
    {
        InitializeComponent();

        // control = new Label();

        //graphicsObj = this.CreateGraphics();

        graphicsObj = this.CreateGraphics();

        // Paint += Form1_Paint;

        // this.HandleCreated += OnHandleCreated;
    }

    // private void OnHandleCreated(object? sender, EventArgs e)
    // {
    //     screenThread.Start();
    // }

    // private void IsCreated(object? sender, PaintEventArgs e)
    // {
    //     created = true;
    // }
    private void Form1_Paint(object? sender, PaintEventArgs e)
    {
        // // DrawLine(new Point(10,10), new Point(100,100));
        // int renderWidth = 400;
        // int rnderHeight = 400;
        // System.Drawing.Graphics graphicsObj;
        // var canvas = new Bitmap(Height, Width);


        // Pen myPen = new Pen(System.Drawing.Color.Red, 5);

        // myPen.Width = 1;

        // for (int x = 0; x < renderWidth; x++)
        // {
        //     for (int y = 0; y < rnderHeight; y++)
        //     {
        //         canvas.SetPixel(x, y, Color.BlueViolet);
        //         //PrintPixel(graphicsObj, myPen, x , y);
        //     }
        // }
        // graphicsObj.DrawImage(canvas, 0, 0);

        // // var image = Image.FromFile(@"C:\Users\ceniu\Desktop\MyCode\Demos\MyApplication\20160507_134847klippet.jpg");
        // // graphicsObj.DrawImage(image, new Point(0, 0), );
    }

    private void PrintPixel(Pen myPen, int x, int y)
    {
        graphicsObj.FillRectangle(Brushes.Black, x, y, 1, 1);
    }
    public void PrintBitMap(Bitmap canvas)
    {
        graphicsObj.DrawImage(canvas, 0, 0);
    }
    public void DrawLine(Point one, Point two)
    {
        // control.Invoke(() =>
        // {
        Pen pen = new Pen(Color.Red, 20);

        graphicsObj.DrawLine(pen, one, two);
        // });
    }
    public void DrawLine(Point one, Point two, Color color)
    {
        // control.Invoke(() =>
        // {
        Pen pen = new Pen(color, 20);

        graphicsObj.DrawLine(pen, one, two);
        // });
    }
    public void DrawBall(Point one, int radius, Color color)
    {
        System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(color);
        graphicsObj.FillEllipse(myBrush, one.X, one.Y, radius, radius);
    }
    public void Drawbitmap(Bitmap canvas, int i, int j)
    {
        graphicsObj.DrawImage(canvas, i, j);
    }
}
