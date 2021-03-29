using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2139_Lab9.Models
{
    public class TicTacToeBoard
    {
        public List<Cell> cells { get; set; }

        public bool HasWinner { get; set; }

        public string WinningMark { get; set; }

        public bool HasAllCellsSelected { get; set; }

        public TicTacToeBoard()
        {
            string[] rows = new string[] { "Top", "Middle", "Bottom" };
            string[] cols = new string[] { "Left", "Middle", "Right" };

            cells = new List<Cell>();

            foreach(string r in rows)
            {
                foreach(string c in cols)
                {
                    Cell cell = new Cell { Id = r + c };
                    cells.Add(cell);
                }
            }
        }

        public List<Cell> GetCells() => cells;

        private bool IsWinner(string mark1, string mark2, string mark3)
        {
            return mark1 == mark2 && mark2 == mark3 && !string.IsNullOrEmpty(mark1);
        }

        public void CheckForWinner()
        {
            HasWinner = false;
            WinningMark = null;

            if (IsWinner(cells[0].Mark, cells[1].Mark, cells[2].Mark))
            {
                HasWinner = true;
                WinningMark = cells[0].Mark;
            }
            else if (IsWinner(cells[3].Mark, cells[4].Mark, cells[5].Mark))
            {
                HasWinner = true;
                WinningMark = cells[3].Mark;
            }
            else if (IsWinner(cells[6].Mark, cells[7].Mark, cells[8].Mark))
            {
                HasWinner = true;
                WinningMark = cells[6].Mark;
            }
            else if (IsWinner(cells[0].Mark, cells[3].Mark, cells[6].Mark))
            {
                HasWinner = true;
                WinningMark = cells[0].Mark;
            }
            else if (IsWinner(cells[1].Mark, cells[4].Mark, cells[7].Mark))
            {
                HasWinner = true;
                WinningMark = cells[1].Mark;
            }
            else if (IsWinner(cells[2].Mark, cells[5].Mark, cells[8].Mark))
            {
                HasWinner = true;
                WinningMark = cells[2].Mark;
            }
            else if (IsWinner(cells[0].Mark, cells[4].Mark, cells[8].Mark))
            {
                HasWinner = true;
                WinningMark = cells[0].Mark;
            }
            else if (IsWinner(cells[2].Mark, cells[4].Mark, cells[6].Mark))
            {
                HasWinner = true;
                WinningMark = cells[2].Mark;
            }

            HasAllCellsSelected = true;
            foreach(Cell cell in cells)
            {
                if (cell.IsBlank)
                {
                    HasAllCellsSelected = false;
                    return;
                }
            }
        }
    }
}
