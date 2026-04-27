using System;
using System.Collections.Generic;
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
        private bool IsPreviewMode = false;
        private Point initialMousePosition;
        private Graphics graphics;
        private List<Column> columns;

        public MainWindow()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            glyphProvider = new GlyphProvider();
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += (s, e) => UpdateFrame();

            this.KeyDown += MainWindow_KeyDown;
            this.MouseClick += MainWindow_MouseClick;
            this.MouseMove += MainWindow_MouseMove;
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

            graphics = CreateGraphics();
            graphics.CompositingMode = CompositingMode.SourceOver;
            graphics.CompositingQuality = CompositingQuality.HighSpeed;
            graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            graphics.SmoothingMode = SmoothingMode.None;
            initialMousePosition = Cursor.Position;

            glyphProvider.Init();
            InitColumns();
            timer.Start();
        }

        private void InitColumns()
        {
            columns = new List<Column>();

            int columnCount = Screen.PrimaryScreen.Bounds.Width / Settings.CharWidth;
            for (int i = 0; i < columnCount; i++)
            {
                columns.Add(new Column(
                    i * Settings.CharWidth,
                    rand.Next(-2000, 0),
                    rand.Next(Settings.MinCharsCount, Settings.MaxCharsCount),
                    rand,
                    Screen.PrimaryScreen.Bounds.Height,
                    glyphProvider
                ));
            }
        }

        private void UpdateFrame()
        {
            foreach (var col in columns)
            {
                col.Update();
                col.DrawColumn(graphics);
            }
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
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(BackColor);
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