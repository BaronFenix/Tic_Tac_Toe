using MudBlazor;

namespace TicTacToe.Domain
{
    public class Board
    {
        public int ColumnCount => 3;
        public int RowCount = 3;

        public bool Turn_X = true;
        public bool Turn_O = false;

        public CellState[,] Cells { get; set; }
        //public Gamer CurrentPlayer { get; set; }

        public Board()
        {
            Reset();
            //CurrentPlayer = Gamer.X;
        }

        public void Reset()
        {
            Cells = new CellState[RowCount, ColumnCount];
            Turn_X = true;
            Turn_O = false;
        }

        public void NextTurn(int row, int col)
        {
            if (Cells[row, col] == CellState.Empty && Turn_X)
            {
                Cells[row, col] = CellState.X;
                SwitchGamer();
            }
            else if (Cells[row, col] == CellState.Empty && Turn_O)
            {
                Cells[row, col] = CellState.O;
                SwitchGamer();
            }
        }

        private void SwitchGamer()
        {
            Turn_X = Turn_X == true ? false : true;
            Turn_O = Turn_O == true ? false : true;
            //CurrentPlayer = CurrentPlayer == Gamer.X ? Gamer.O : Gamer.X; 
        }

        public GameResult GetGameResult()
        {
            if (WinChecker(CellState.X))
            {
                return GameResult.Won_X;
            }
            if (WinChecker(CellState.O))
            {
                return GameResult.Won_O;
            }
            else
                return GameResult.NoWinner;
            
        }

        private bool WinChecker(CellState gamer)
        {
            CellState exceptedCellState = new();
            if (gamer == CellState.X)
                exceptedCellState = CellState.X;
            else if (gamer == CellState.O)
                exceptedCellState = CellState.O;

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (CheckingWinByRow(exceptedCellState, j))
                    {
                        return true;
                    }
                    if (CheckingWinByCol(exceptedCellState, i))
                    {
                        return true;
                    }
                    if (CheckingWinByDiagonal(exceptedCellState))
                    {
                        return true;
                    }
                    if (CheckingWinByDiagonal_2(exceptedCellState))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckingWinByRow(CellState gamer, int col)
        {
            int counter = 0;

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = col; j < col+1; j++)
                {
                    if (Cells[i, j] == gamer)
                        counter++;
                }
            }
            if (counter == 3)
                return true;
            else
                return false;
        }

        private bool CheckingWinByCol(CellState gamer, int row)
        {
            int counter = 0;

            for (int i = row; i < row+1; i++)
            {
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (Cells[i, j] == gamer)
                        counter++;
                }
            }
            if (counter == 3)
                return true;
            else
                return false;
        }

        private bool CheckingWinByDiagonal(CellState gamer)
        {
            int counter = 0;

            for (int i = 0; i < RowCount; i++)
            {
                if (Cells[i, i] == gamer)
                    counter++;
            }
            if (counter == 3)
                return true;
            else
                return false;
        }

        private bool CheckingWinByDiagonal_2(CellState currentGamer)
        {
            int counter = 0;
            int j = RowCount - 1;
            for (int i = 0; i < RowCount; i++)
            {
                if (Cells[i, j] == currentGamer)
                    counter++;
                j--;
            }
            if (counter == 3)
                return true;
            else
                return false;
        }

    }



    public enum CellState
    {
        Empty,
        X,
        O
    }

    public enum Gamer
    {
        X,
        O
    }

    public enum GameResult
    {
        //NotResult,
        NoWinner,
        Won_X,
        Won_O
    }
}
