using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
	public class WinScreen : MonoBehaviour
	{
		[SerializeField] private Text _winnerNameView;
		[SerializeField] private string _textPostfix;

		public void DisplayWinnerName(string winnerName)
		{
			_winnerNameView.text = winnerName + _textPostfix;
			gameObject.SetActive(true);
		}

		public void Hide() => gameObject.SetActive(false);
	}
}