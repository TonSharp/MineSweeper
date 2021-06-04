using MineSweeper.DataStructures;
using MineSweeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MineSweeper.ViewModels
{
    public class SessionVM : BaseVM
    {
        public Command clickCommand { get; private set; }
        public SessionModel Model { get; private set; }

        private string statusText;
        public string StatusText
        {
            get => statusText;
            set
            {
                statusText = value;
                OnPropertyChanged(nameof(statusText));
            }
        }

        private SolidColorBrush statusBrush;
        public SolidColorBrush StatusBrush
        {
            get => statusBrush;
            set
            {
                statusBrush = value;
                OnPropertyChanged(nameof(StatusBrush));
            }
        }

        public SessionVM()
        {
            clickCommand = new Command(o => {
                if (Model.IsMine(o))
                {
                    StatusText = "Потрачено";
                    StatusBrush = Brushes.Red;
                }

                Model.OpenCell(o, new List<Button>());
            } );
        }
        public void InitializeField(int Height, int Width)
        {
            Model = new SessionModel(Height, Width);
        }
    }
}
