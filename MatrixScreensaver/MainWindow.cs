using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MatrixScreensaver
{
    public partial class MainWindow : Form
    {
        private readonly Timer timer;
        private readonly Random rand = new Random();
        private readonly GlyphProvider glyphProvider;
        private readonly IntPtr previewWindowHandle = IntPtr.Zero;
        private readonly bool IsPreviewMode = false;
        private readonly int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
        private readonly int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
        private readonly BufferedGraphics grafx;
        private Point initialMousePosition;
        private Column[] columns;

        public MainWindow()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.Opaque,
                true);
            this.UpdateStyles();
            BufferedGraphicsContext context = BufferedGraphicsManager.Current;
            context.MaximumBuffer = new Size(ScreenWidth + 1, ScreenHeight + 1);
            grafx = context.Allocate(CreateGraphics(), new Rectangle(0, 0, ScreenWidth, ScreenHeight));
            grafx.Graphics.CompositingQuality = CompositingQuality.HighSpeed;
            grafx.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            grafx.Graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            grafx.Graphics.SmoothingMode = SmoothingMode.None;

            glyphProvider = new GlyphProvider();
            timer = new Timer
            {
                Interval = 40
            };

            timer.Tick += Timer_Tick;
            this.MouseClick += MainWindow_MouseClick;

#if !DEBUG
            this.TopMost = true;
            this.MouseMove += MainWindow_MouseMove;
            this.KeyDown += MainWindow_KeyDown;
#endif
        }

        public MainWindow(IntPtr previewWindowHandle) : this()
        {
            this.previewWindowHandle = previewWindowHandle;
            Settings.CharWidth /= 2;
            Settings.CharHeight /= 2;

            IsPreviewMode = true;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (IsPreviewMode)
            {
                SetParent(this.Handle, previewWindowHandle);
                SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

                RECT rect;
                GetClientRect(previewWindowHandle, out rect);

                this.Size = new Size(rect.Right, rect.Bottom);
                this.Location = new Point(0, 0);
            }
            else
            {
                Cursor.Hide();
            }


            initialMousePosition = Cursor.Position;

            glyphProvider.Init(rand);
            InitColumns();
            timer.Start();
        }

        private void InitColumns()
        {
            int columnCount = ScreenWidth / Settings.CharWidth;
            columns = new Column[columnCount];

            for (int i = 0; i < columns.Length; i++)
            {
                columns[i] = new Column(
                    i * Settings.CharWidth,
                    rand.Next(-1400, -300),
                    rand.Next(Settings.MinCharsCount, Settings.MaxCharsCount),
                    rand,
                    ScreenHeight,
                    glyphProvider
                );
            }
        }

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {
            grafx.Graphics.Clear(Color.Black);
            for (int i = 0; i < columns.Length; i++)
            {
                columns[i].DrawColumn(grafx.Graphics, 0, ScreenHeight);
            }
            grafx.Render();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < columns.Length; i++)
            {
                columns[i].Update();
            }

            Invalidate(false);
        }

        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        private static extern bool GetClientRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        private struct RECT
        {
            public int Left, Top, Right, Bottom;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            timer.Stop();
            timer.Dispose();
            grafx.Dispose();

            for (int i = 0; i < columns.Length; i++)
            {
                columns[i].Dispose();
            }
        }

        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsPreviewMode)
                return;

            Point current = Cursor.Position;

            if (Math.Abs(current.X - initialMousePosition.X) > 10 ||
                Math.Abs(current.Y - initialMousePosition.Y) > 10)
            {
                ExitScreensaver();
            }
        }

        private void MainWindow_MouseClick(object sender, MouseEventArgs e)
        {
            if (!IsPreviewMode)
                ExitScreensaver();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (!IsPreviewMode)
                ExitScreensaver();
        }

        private void ExitScreensaver()
        {
            Cursor.Show();
            Application.Exit();
        }
    }
}