using UnityEngine;
using UnityEngine.UI;

namespace Minesweeper.Tile
{
    public class TileView : MonoBehaviour, ITileView
    {
        protected ITilePresenter Presenter;
        public Text symbol;
        public GameObject cover;
        public GameObject flag;
    
        public void SetSymbol(string symbol)
        {
            this.symbol.text = symbol;
            this.symbol.gameObject.SetActive(false);
        }

        public void Initialize(ITilePresenter presenter)
        {
            Presenter = presenter;
        }

        private void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Presenter.Flagged();
            }
        }

        private void OnMouseDown()
        {
            Presenter.Uncover();
        }

        public void SetFlag(bool flagged)
        {
            flag.SetActive(flagged);
        }

        public void Uncover()
        {
            symbol.gameObject.SetActive(true);
            cover.SetActive(false);
        }
    }
}
