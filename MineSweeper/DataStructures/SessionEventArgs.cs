using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeper
{
    public class SessionEventArgs
    {
        public readonly int MinesCount, FieldWidth, FieldHeight;

        public SessionEventArgs(int MinesCount, int FieldWidth, int FieldHeight)
        {
            this.MinesCount = MinesCount;
            this.FieldWidth = FieldWidth;
            this.FieldHeight = FieldHeight;
        }
    }
}
