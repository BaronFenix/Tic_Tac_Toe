namespace TicTacToe.Domain
{
    public class Board
    {
        public int ColumnCount => 3;
        public int RowCount => 3;

        public List<CellState> BoardCells = new List<CellState>()
        {
            CellState.Empty,
            CellState.Empty,
            CellState.Empty,

            CellState.Empty,
            CellState.X,
            CellState.Empty,

            CellState.O,
            CellState.Empty,
            CellState.Empty,
        };

        // Row 1
        public CellState Cell_x0_y0 { get; set; } = CellState.O;
        public CellState Cell_x1_y0 { get; set; } = CellState.X;
        public CellState Cell_x2_y0 { get; set; }
        // Row 2
        public CellState Cell_x0_y1 { get; set; }
        public CellState Cell_x1_x1 { get; set; }
        public CellState Cell_x2_y1 { get; set; }
        // Row 3
        public CellState Cell_x0_y2 { get; set; }
        public CellState Cell_x1_y2 { get; set; }
        public CellState Cell_x2_y2 { get; set; }

    }

    public enum CellState
    {
        Empty,
        X,
        O
    }
}
