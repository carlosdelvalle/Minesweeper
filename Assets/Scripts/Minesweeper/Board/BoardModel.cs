using UnityEngine;

namespace Minesweeper.Board
{
    public class BoardModel: IBoardModel 
    {
        public GameObject[,] grid;
        public int boardSize;
        public int boardMines;
        public int boardBlank;
        private int minesAmount;


        public void Setup(int size, int mines)
        {
            boardSize = size;
            boardMines = minesAmount = mines;
            boardBlank = (size * size) - mines;
            grid = new GameObject[size,size];
        }

        public void Reset()
        {
            boardBlank = (boardSize * boardSize) - boardMines;
            boardMines = minesAmount;
            grid = new GameObject[boardSize,boardSize];
        }

        public GameObject GetPosition(int x, int y)
        {
            return grid[x, y];
        }

        public void SetPosition(int x, int y, GameObject tile)
        {
            grid[x, y] = tile;
        }

        public int Mines {
            get => boardMines;
            set => boardMines = value;
        }
        public int Size => boardSize;
        public int BlankTiles
        {
            get => boardBlank;
            set => boardBlank = value;
        }
    }
}
