using System.Collections.Generic;

namespace Minesweeper.Tile
{
    public class BlankTilePresenter : BaseTilePresenter
    {
        public override void Uncover(bool neighbourClick = false)
        {
            if (neighbourClick && Model.IsFlagged)
            {
                Flagged();
            }
            base.Uncover(neighbourClick);
        }

        protected override void TileAction()
        {
            if (Model.Type == TileType.Blank)
            {
                foreach (var neighbour in Model.Neighbours)
                {
                    neighbour.Uncover(true);
                }
            }
        
            base.TileAction();
        }
    
        public override void SetNeighbours(List<ITilePresenter> ne)
        {
            base.SetNeighbours(ne);
            CalculateSymbol();
        }

        private void CalculateSymbol()
        {
            int mines = 0;
        
            foreach (var neighbour in Model.Neighbours)
            {
                if (neighbour.GetTileType() == TileType.Mine)
                {
                    mines++;
                }
            }

            Model.Type = mines > 0 ? TileType.Hint : TileType.Blank;
            Model.Symbol = mines.ToString();
            View.SetSymbol(Model.Symbol);
        }
    }
}
