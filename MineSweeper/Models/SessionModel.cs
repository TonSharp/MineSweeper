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

        public void OpenCell(object Sender, List<Button> Checked)
        {
            if(firstClick)
            {
                InitializeMinesField();
                firstClick = false;
            }

            if(Sender is Button sender)
            {
                sender.IsEnabled = false;

                if (Field.GetCellByButton(sender).IsMine)
                {
                    sender.Content = "M";
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
        }
        private void InitializeMinesField()
        {
            int usedMines = 0;
            Random random = new Random();

            for (int y = 0; y < Field.Height; y++)
            {
                for (int x = 0; x < Field.Width; x++)
                {
                    if (usedMines < MinesCount && random.Next(2) > 0)
                    {
                        Field.Cells[y, x].IsMine = true;
                        usedMines++;
                    }
                }
            }
        }
    }
}
