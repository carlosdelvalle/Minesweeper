using System;
using System.Collections.Generic;

namespace Minesweeper.Tile
{
    public interface ITilePresenter
    {
        void Initialize(ITileModel model,Action<int,int> OnClick = null);
        TileType GetTileType();
        void Uncover(bool neighbourClick = false);
        void Flagged();
        void SetNeighbours(List<ITilePresenter> ne);
        void Block();
    }
}