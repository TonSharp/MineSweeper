using MineSweeper.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MineSweeper.Models
{
    public class SessionModel
    {
        public Field Field;
        public int MinesCount;
        private bool firstClick = true;

        public SessionModel(int Height, int Width)
        {
            Field = new Field(Height, Width);
        }

        public bool IsGameFinished()
        {
            return Field.GetActiveCellsCount() == MinesCount;
        }

        public bool IsMine(object Sender)
        {
            if(Sender is Button button)
                return Field.GetCellByButton(button).IsMine;

            return false;
        }

        public void LockField()
        {
            Field.Lock();
        }

        public void OpenCell(object Sender, List<Button> Checked)
        {
            if (!(Sender is Button))
                return;

            Button sender = Sender as Button;

            if (firstClick)
            {
                InitializeMinesField(sender);
                firstClick = false;
            }

            sender.IsEnabled = false;

            Cell clickedCell = Field.GetCellByButton(sender);
            if (Field.GetCellByButton(sender).IsMine)
            {
                HandleMineClick(clickedCell);
                return;
            }

            int minesCountAround = Field.GetMinesCountAround(sender);
            if(minesCountAround == 0)
            {
                List<Cell> neighbours = Field.GetNeighbourCells(sender);

                foreach (var btn in neighbours)
                {
                    if(!Checked.Contains(btn.Button))
                    {
                        Checked.Add(btn.Button);
                        OpenCell(btn.Button, Checked);
                    }
                }
            }
            else
                sender.Content = minesCountAround;
        }
        private void HandleMineClick(Cell cell)
        {
            cell.Button.Content = "M";
            cell.Button.Style = null;
            cell.Button.Foreground = Brushes.Red;
        }
        private void InitializeMinesField(Button sender)
        {
            int usedMines = 0;
            Random random = new Random();

            for (int y = 0; y < Field.Height; y++)
            {
                for (int x = 0; x < Field.Width; x++)
                {
                    if (usedMines < MinesCount && random.Next(2) > 0 && Field.Cells[y, x].Button != sender)
                    {
                        Field.Cells[y, x].IsMine = true;
                        usedMines++;
                    }
                }
            }
        }
    }
}
