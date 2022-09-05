using Mirror;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Player.Score
{
	public class PlayerScore : NetworkBehaviour
	{
		[SerializeField] private Text _text;

		private int _scoreValue;
		private string _textPrefix;

		private void Start()
		{
			_textPrefix = _text.text;
			UpdateScore();
		}

		public void IncrementScore()
		{
			_scoreValue++;
			UpdateScore();
		}

		private void UpdateScore() => _text.text = _textPrefix + _scoreValue;
	}
}