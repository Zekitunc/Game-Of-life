using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_porject2_Game_Of_Life
{

    public class Cell
    {
        public bool IsAlive { get; set; }

        public Cell(bool isAlive)
        {
            IsAlive = isAlive;
        }
        public Cell()
        {
            IsAlive = false;
        }
    }
}
