using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MudBlazor;


namespace TicTacToe.Domain
{
    public class Board
    {
        public int ColumnCount => 3;
        public int RowCount = 3;

        public bool Turn_X { get; set; }
        public bool Turn_O { get; set; }

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
            var gameResult = GetGameResult(out _);
            if (gameResult == GameResult.Unknown)
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

        }

        private void SwitchGamer()
        {
            Turn_X = Turn_X == true ? false : true;
            Turn_O = Turn_O == true ? false : true;
            //CurrentPlayer = CurrentPlayer == Gamer.X ? Gamer.O : Gamer.X; 
        }

        public GameResult GetGameResult(out CellPosition[] winCells)
        {
            if (WinChecker(CellState.X, out winCells))
            {
                return GameResult.Won_X;
            }
            else if (WinChecker(CellState.O, out winCells))
            {
                return GameResult.Won_O;
            }
            else if (CheckNoWinner())
            {
                return GameResult.NoWinner;
            }
            else
                return GameResult.Unknown;
            
        }

        private bool WinChecker(CellState gamer, out CellPosition[] winCells)
        {
            CellState exceptedCellState = new();
            if (gamer == CellState.X)
                exceptedCellState = CellState.X;
            else if (gamer == CellState.O)
                exceptedCellState = CellState.O;

            winCells = new CellPosition[0];

            if (CheckingWinByRows(exceptedCellState, out winCells))
                return true;

            if (CheckingWinByColumns(exceptedCellState, out winCells))
                return true;
            
            if (CheckingWinByDiagonal(exceptedCellState, out winCells))
                return true;
            
            if (CheckingWinByDiagonal_2(exceptedCellState, out winCells))
                return true;

            return false;
        }

        private bool CheckNoWinner()
        {
            // TODO: реализовать
            foreach (var cellState in Cells)
            {
                if (cellState == CellState.Empty)
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckingWinByRows(CellState gamer, out CellPosition[] winCells)
        {
            for (int i = 0; i < RowCount; i++)
            {
                int winLine = 0;
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (Cells[i, j] == gamer)
                        winLine++;
                }
                if (winLine == 3)
                {
                    winCells = new CellPosition[]
                    {
                        new CellPosition(i, 0),
                        new CellPosition(i, 1),
                        new CellPosition(i, 2)
                    };
                    return true;
                }
            }

            winCells = new CellPosition[0];
            return false;
        }

        private bool CheckingWinByColumns(CellState gamer, out CellPosition[] winCells)
        {
            for (int i = 0; i < RowCount; i++)
            {
                int winLine = 0;
                for (int j = 0; j < ColumnCount; j++)
                {
                    if (Cells[j, i] == gamer)
                        winLine++;
                }
                if (winLine == 3)
                {
                    winCells = new CellPosition[]
                    {
                            new CellPosition(0, i),
                            new CellPosition(1, i),
                            new CellPosition(2, i)
                    };
                    return true;
                }
            }
            winCells = new CellPosition[0];
            return false;
        }

        private bool CheckingWinByDiagonal(CellState gamer, out CellPosition[] winCells)
        {
            int winLine = 0;

            for (int i = 0; i < RowCount; i++)
            {
                if (Cells[i, i] == gamer)
                    winLine++;

                if (winLine == 3)
                {
                    winCells = new CellPosition[]
                    {
                        new CellPosition(0, 0),
                        new CellPosition(1, 1),
                        new CellPosition(2, 2),
                    };
                    return true;
                }
            }
            winCells = new CellPosition[0];
            return false;
        }

        private bool CheckingWinByDiagonal_2(CellState currentGamer, out CellPosition[] winCells)
        {
            int winLine = 0;
            int j = RowCount - 1;
            for (int i = 0; i < RowCount; i++)
            {
                if (Cells[i, j] == currentGamer)
                    winLine++;
                if (winLine == 3)
                {
                    winCells = new CellPosition[]
                    {
                        new CellPosition(0, 2),
                        new CellPosition(1, 1),
                        new CellPosition(2, 0),
                    };
                    return true;
                }
                j--;
            }
            winCells = new CellPosition[0];
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
        Unknown,
        NoWinner,
        Won_X,
        Won_O
    }

    public record CellPosition(int row, int column);

}
