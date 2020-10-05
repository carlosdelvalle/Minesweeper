namespace Minesweeper.Tile
{
    public interface ITileView
    {
        void SetSymbol(string symbol);

        void Initialize(ITilePresenter presenter);

        void SetFlag(bool flagged);

        void Uncover();
    }
}
