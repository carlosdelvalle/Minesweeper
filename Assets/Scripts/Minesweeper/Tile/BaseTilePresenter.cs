using System;
using System.Collections.Generic;
using UnityEngine;

namespace Minesweeper.Tile
{
    public class BaseTilePresenter : MonoBehaviour, ITilePresenter
    {
        protected ITileModel Model;
        protected ITileView View;
        protected Action<int, int> UncoverAction;
        private bool _blocked;

        public void Initialize(ITileModel model, Action<int, int> OnClick = null)
        {
            Model = model;
            UncoverAction = OnClick;
            View = GetComponent<TileView>();
            View.Initialize(this);
            View.SetSymbol(Model.Symbol);
        }

        public TileType GetTileType()
        {
            return Model.Type;
        }

        public virtual void Uncover(bool neighbourClick = false)
        {
            if (Model.IsCover && !Model.IsFlagged && !_blocked)
            {
                Model.IsCover = false;
                View.Uncover();
                TileAction();
            }
        }

        protected virtual void TileAction()
        {
            UncoverAction(Model.Position.X, Model.Position.Y);
        }

        public virtual void SetNeighbours(List<ITilePresenter> ne)
        {
            Model.Neighbours = ne;
        }

        public void Block()
        {
            _blocked = true;
            View.Uncover();
        }

        public void Flagged()
        {
            Model.IsFlagged = !Model.IsFlagged;
            View.SetFlag(Model.IsFlagged);
        }

    }
}
