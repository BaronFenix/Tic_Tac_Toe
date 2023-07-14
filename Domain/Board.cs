namespace TicTacToe.Domain
{
    public class Board
    {
        public int ColumnCount => 3;
        public int RowCount => 3;

        public bool Move_X = true;
        public bool Move_O = false;

        public List<CellState> BoardCells = new List<CellState>()
        {
            CellState.Empty,
            CellState.Empty,
            CellState.Empty,

            CellState.Empty,
            CellState.Empty,
            CellState.Empty,

            CellState.Empty,
            CellState.Empty,
            CellState.Empty,
        };

        public Dictionary<string, CellState> Cells = new()
        {
            { "Cell_x0_y0", CellState.Empty },
            { "Cell_x1_y0", CellState.Empty },
            { "Cell_x2_y0", CellState.Empty },

            { "Cell_x0_y1", CellState.Empty },
            { "Cell_x1_y1", CellState.Empty },
            { "Cell_x2_y1", CellState.Empty },

            { "Cell_x0_y2", CellState.Empty },
            { "Cell_x1_y2", CellState.Empty },
            { "Cell_x2_y2", CellState.Empty },
        };

        // Row 1
        public CellState Cell_x0_y0 { get; set; }
        public CellState Cell_x1_y0 { get; set; }
        public CellState Cell_x2_y0 { get; set; }
        // Row 2
        public CellState Cell_x0_y1 { get; set; }
        public CellState Cell_x1_x1 { get; set; }
        public CellState Cell_x2_y1 { get; set; }
        // Row 3
        public CellState Cell_x0_y2 { get; set; }
        public CellState Cell_x1_y2 { get; set; }
        public CellState Cell_x2_y2 { get; set; }



        public void CellClick(int index)
        {
            if (BoardCells[index] == CellState.Empty && Move_X)
            {
                BoardCells[index] = CellState.X;
                Move_X = false;
                Move_O = true;
            }
            else if (BoardCells[index] == CellState.Empty && Move_O)
            {
                BoardCells[index] = CellState.O;
                Move_X = true;
                Move_O = false;
            }
        }

        public void WinChecker()
        {
        
        }

    }

    public enum CellState
    {
        Empty,
        X,
        O
    }
}
