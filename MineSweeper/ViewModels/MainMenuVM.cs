using MineSweeper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MineSweeper.ViewModels
{
    public class MainMenuVM : BaseVM
    {
        public int MaxMinesCount { get; } = 50;
        public int MinMinesCount { get; } = 10;

        public int MinCellCount { get; } = 10;
        public int MaxCellCount { get; } = 20;

        private int minesCount;
        public int MinesCount
        {
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

        private bool darkMode = false;

        private MainMenuModel menuModel { get; set; }

        public Command ChangeThemeCommand { get; private set; }
        public Command StartNewSessionCommand { get; private set; }

        public MainMenuVM()
        {
            menuModel = new MainMenuModel();

            ChangeThemeCommand = new Command(o => SwitchTheme());
            StartNewSessionCommand = new Command(o  => menuModel.StartNewSession(new SessionEventArgs(minesCount, xCount, yCount)));

            minesCount = MinMinesCount;
            xCount = MinCellCount;
            yCount = MinCellCount;
        }

        private void SwitchTheme()
        {
            darkMode = !darkMode;

            ResourceDictionary dictionary = LoadOppositeThemeResource();
            Application.Current.Resources.MergedDictionaries[0] = dictionary;
        }
        private ResourceDictionary LoadOppositeThemeResource()
        {
            ResourceDictionary dictionary = new ResourceDictionary();
            dictionary.Source = GetOppositeFileTheme();

            return dictionary;
        }
        private Uri GetOppositeFileTheme()
        {
            if (darkMode)
                return new Uri("../Resources/DarkTheme.xaml", UriKind.Relative);
            else
                return new Uri("../Resources/LightTheme.xaml", UriKind.Relative);

        }
    }
}
