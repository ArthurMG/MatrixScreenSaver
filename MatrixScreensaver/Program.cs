using System;
using System.Windows.Forms;

namespace MatrixScreensaver
{
    internal static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string command = string.Empty;
            if (args.Length > 0)
            {
                command = args[0].Trim().ToLower();
            }

            if (command.Length > 2)
            {
                command = command.Substring(0, 2);
            }

            switch (command)
            {
                case "":
                case "/s":
                    Application.Run(new MainWindow());
                    break;

                case "/p":

                    if (args.Length > 1)
                    {
                        if (int.TryParse(args[1].Trim(), out var parentWindowHandle))
                        {
                            var intPtr = new IntPtr(parentWindowHandle);
                            Application.Run(new MainWindow(intPtr));
                        }
                        else
                        {
                            Application.Exit();
                        }
                    }
                    else
                    {
                        Application.Exit();
                    }

                    break;

                case "/c":
                    Application.Run(new SettingsForm());
                    break;
                default:
                    Application.Exit();
                    break;
            }
        }
    }
}