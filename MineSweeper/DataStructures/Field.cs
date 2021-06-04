using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MineSweeper.DataStructures
{
    public class Field
    {
        public int Height { get; private set; }
        public int Width { get; private set; }

        public Cell[,] Cells;

        public Field(int Height, int Width)
        {
            this.Height = Height;
            this.Width = Width;

            Cells = new Cell[Height, Width];
        }

        public void Lock()
        {
            for(int y = 0; y < Height; y++)
                for(int x = 0; x < Width; x++)
                    Cells[y, x].Button.IsEnabled = false;
        }

        public int GetActiveCellsCount()
        {
            int sum = 0;

            for(int y = 0; y < Height; y++)
            {
                for(int x = 0; x < Width; x++)
                {
                    if (Cells[y, x].Button.IsEnabled)
                        sum++;
                }
            }

            return sum;
        }

        public int GetMinesCountAround(Button button)
        {
            int sum = 0;

            try
            {
                Tuple<int, int> position = GetPositionByButton(button);

                foreach (var cell in GetNeighbourCells(position.Item1, position.Item2))
                    if (cell.IsMine)
                        sum++;
            }
            catch
            {
                throw new Exception("Can't calculate neighbours");
            }

            return sum;
        }

        public Cell GetCellByButton(Button button)
        {
            try
            {
                Tuple<int, int> pos = GetPositionByButton(button);

                return Cells[pos.Item1, pos.Item2];
            }
            catch
            {
                throw new Exception("Cant't get cell");
            }
        }

        public Tuple<int, int> GetPositionByButton(Button button)
        {
            for (int y = 0; y < Height; y++)
                for (int x = 0; x < Width; x++)
                    if (button == Cells[y, x].Button)
                        return new Tuple<int, int>(y, x);
            throw new Exception("This button is not in field");
        }

        public List<Cell> GetNeighbourCells(Button button)
        {
            Tuple<int, int> pos = GetPositionByButton(button);
            List<Cell> neighbours = GetNeighbourCells(pos.Item1, pos.Item2);

            return neighbours;
        }
        public List<Cell> GetNeighbourCells(int Y, int X)
        {
            List<Cell> neighbours = new List<Cell>();

            if(Y > 0 && X > 0)
            {
                neighbours.Add(Cells[Y - 1, X - 1]);
                neighbours.Add(Cells[Y, X - 1]);
                neighbours.Add(Cells[Y - 1, X]);
            }
            else if(Y > 0)
                neighbours.Add(Cells[Y - 1, X]);
            else if(X > 0)
                neighbours.Add(Cells[Y, X - 1]);

            if(Y + 1 < Height && X + 1 < Width)
            {
                neighbours.Add(Cells[Y + 1, X + 1]);
                neighbours.Add(Cells[Y, X + 1]);
                neighbours.Add(Cells[Y + 1, X]);
            }
            else if(Y + 1 < Height)
                neighbours.Add(Cells[Y + 1, X]);
            else if(X + 1 < Width)
                neighbours.Add(Cells[Y, X + 1]);

            if (X > 0 && Y + 1 < Height)
                neighbours.Add(Cells[Y + 1, X - 1]);
            if (Y > 0 && X + 1 < Width)
                neighbours.Add(Cells[Y - 1, X + 1]);

            return neighbours;
        }
    }
}
