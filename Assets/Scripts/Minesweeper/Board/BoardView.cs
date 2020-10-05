using UnityEngine;
using UnityEngine.UI;

namespace Minesweeper.Board
{
   public class BoardView: MonoBehaviour,IBoardView
   {
      [SerializeField]
      private Text resultText;
      [SerializeField]
      private GameObject retryButton;

      public void ShowWin()
      {
         resultText.text = "You Win!";
         ShowRetryButton(true);
      }
   
      public void ShowLose()
      {
         resultText.text = "You Lose!";
         ShowRetryButton(true);
      }

      public void Reset()
      {
         resultText.text = string.Empty;
         ShowRetryButton(false);
      }

      public void ShowRetryButton(bool show)
      {
         retryButton.SetActive(show);
      }
   }
}
