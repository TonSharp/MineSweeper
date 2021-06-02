using MineSweeper.DataStructures;
using MineSweeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MineSweeper.ViewModels
{
    public class SessionVM : BaseVM
    {
        public Command clickCommand { get; private set; }
        public SessionModel Model { get; private set; }

        public SessionVM()
        {
            clickCommand = new Command(o => {Model.OpenCell(o, new List<Button>());} );
        }
        public void InitializeField(int Height, int Width)
        {
            Model = new SessionModel(Height, Width);
        }
    }
}
