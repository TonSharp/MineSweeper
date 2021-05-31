using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MineSweeper.Models
{
    public class MainMenuModel
    {
        private readonly int cellSize = 35;
        private List<SessionWindow> sessions = new List<SessionWindow>();

        public void StartNewSession(SessionEventArgs args)
        {
            SessionWindow currentSession = CreateSessionWindow(args);
            currentSession.Show();

            sessions.Add(currentSession);
        }
        private SessionWindow CreateSessionWindow(SessionEventArgs args)
        {
            SessionWindow window = new SessionWindow();

            SetUpWindowSize(ref window, args);
            SetUpWindowField(ref window, args);

            return window;
        }
        private void SetUpWindowSize(ref SessionWindow window, SessionEventArgs args)
        {
            window.Width = args.FieldWidth * cellSize;
            window.Height = args.FieldHeight * cellSize + 50;
        }
        private void SetUpWindowField(ref SessionWindow window, SessionEventArgs args)
        {
            window.Field.Columns = args.FieldWidth;
            window.Field.Rows = args.FieldHeight;

            CreateFieldButtons(ref window);
        }
        private void CreateFieldButtons(ref SessionWindow window)
        {
            for(int y = 0; y < window.Field.Rows; y++)
            {
                for(int x = 0; x < window.Field.Columns; x++)
                {
                    Button button = new Button();
                    button.Content = "";

                    window.Field.Children.Add(button);
                    Grid.SetColumn(button, x);
                    Grid.SetRow(button, y);
                }
            }
        }
    }
}
