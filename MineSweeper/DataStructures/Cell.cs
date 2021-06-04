using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MineSweeper.DataStructures
{
    public class Cell
    {
        public bool IsMine { get; set; }
        public Button Button { get; private set; }

        public Cell(Button Button, bool IsMine)
        {
            this.Button = Button;
            this.IsMine = IsMine;
        }
    }
}
