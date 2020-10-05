using System.Collections.Generic;
using System.Drawing;

namespace Minesweeper.Tile
{
    public abstract class BaseTileModel: ITileModel
    {

        public BaseTileModel( Point position,string symbol = "")
        {
            this.Position = position;
            this.Symbol = symbol;
            IsCover = true;
            IsFlagged = false;
        }

        public bool IsCover { get; set; }
        public Point Position { get; set; }
        public string Symbol { get; set; }
        public TileType Type { get; set; }
        public bool IsFlagged { get; set; }
        public List<ITilePresenter> Neighbours { get; set; }
    }
}
