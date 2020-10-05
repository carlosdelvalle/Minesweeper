using System.Drawing;

namespace Minesweeper.Tile
{
    public class BlankTileModel : BaseTileModel
    {
        public BlankTileModel( Point position ,string symbol = "") : base(position,string.Empty)
        {
            this.Type = TileType.Blank;
        }
    }
}
