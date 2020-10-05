using System.Drawing;

namespace Minesweeper.Tile
{
    public class MineTileModel : BaseTileModel
    {
        public MineTileModel(Point position , string symbol = "M"): base(position,symbol)
        {
            this.Type = TileType.Mine;
        }
    }
}
