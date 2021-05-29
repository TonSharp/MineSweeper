using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper.ViewModels
{
    public class MainMenuVM : BaseVM
    {
        public int MaxMinesCount { get; } = 50;
        public int MinMinesCount { get; } = 10;

        public int MinCellCount { get; } = 10;
        public int MaxCellCount { get; } = 20;

        private int minesCount;
        public int MinesCount { 
            get => minesCount;
            set
            {
                if (value < MinMinesCount)
                    minesCount = MinMinesCount;
                else if (value > MaxMinesCount)
                    minesCount = MaxMinesCount;
                else
                    minesCount = value;
                OnPropertyChanged(nameof(minesCount));
            }
        }

        private int xCount;
        public int XCount
        {
            get => xCount;
            set
            {
                if (value < MinCellCount)
                    xCount = MinCellCount;
                else if (value > MaxCellCount)
                    xCount = MaxCellCount;
                else
                    xCount = value;
                OnPropertyChanged(nameof(xCount));
            }
        }

        private int yCount;
        public int YCount
        {
            get => yCount;
            set
            {
                if (value < MinCellCount)
                    yCount = MinCellCount;
                else if (value > MaxCellCount)
                    yCount = MaxCellCount;
                else
                    yCount = value;
                OnPropertyChanged(nameof(yCount));
            }
        }

        private bool darkMode;
        public bool DarkMode
        {
            get => darkMode;
            set
            {
                darkMode = value;


            }
        }
    }
}
