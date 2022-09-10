using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
	public class WinScreen : MonoBehaviour
	{
		[SerializeField] private GameObject _winnerWindowHolder;
		[SerializeField] private Text _winnerNameView;
		[SerializeField] private string _textPostfix;

		public void DisplayWinnerName(string winnerName)
		{
			_winnerNameView.text = winnerName + _textPostfix;
			_winnerWindowHolder.SetActive(true);
		}

		public void Hide() => _winnerWindowHolder.SetActive(false);
	}
}