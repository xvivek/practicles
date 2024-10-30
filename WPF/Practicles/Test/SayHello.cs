using System;
using System.Windows;
using System.Windows.Input;

namespace Petzold.SayHello
{
    public class SayHello : Window
    {
        [STAThread]
        public static void Main()
        {
            SayHello win = new SayHello();
            win.Title = "Say Hello";
            win.MouseDown += Win_MouseDown;
            win.Show();

            Application app = new Application();
            app.Run();
        }

        private static void Win_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window ws = (Window)sender;
            string message = $"Window clicked with {e.ChangedButton} button and point {e.GetPosition(ws)}";
            MessageBox.Show(message, ws.Title);
        }

        protected override void OnTextInput(TextCompositionEventArgs e)
        {
            base.OnTextInput(e);

            if (e.Text == "\b" && Title.Length > 0)
                Title = Title.Substring(0, Title.Length - 1);
            else if (e.Text.Length > 0 && !Char.IsControl(e.Text[0]))
                Title += e.Text;
        }
    }
}

