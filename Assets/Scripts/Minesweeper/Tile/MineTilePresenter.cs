namespace Minesweeper.Tile
{
    public class MineTilePresenter : BaseTilePresenter
    {
        public override void Uncover(bool neighbourClick = false)
        {
            if (!neighbourClick)
            {
                base.Uncover();
            }
        }
    
    }
}
