using System.Collections.Generic;
using System.Drawing;

namespace Minesweeper.Tile
{
    public interface ITileModel
    {
        bool IsCover { get; set; }
        Point Position { get; set; }
        string Symbol { get; set; }
        TileType Type { get; set; }
        bool IsFlagged { get; set; }
        List<ITilePresenter> Neighbours { get; set; }
    }

    public enum TileType
    {
        Mine,
        Blank,
        Hint
    }
}