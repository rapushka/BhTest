using Mirror;
using UnityEngine;
using UnityEngine.UI;
// ReSharper disable UnusedParameter.Local

namespace Code.Player.Score
{
	public class PlayerScore : NetworkBehaviour
	{
		[SerializeField] private Text _playerNameView;
		[Header("GUI Layout")] [SerializeField] private Vector2 _position;
		[SerializeField] private Vector2 _scale;
		[SerializeField] private float _spaceBetween;

		[SyncVar(hook = nameof(SyncScore))] private int _syncScoreValue;
		[SyncVar(hook = nameof(SyncPlayerName))] private string _syncPlayerName;
		[SyncVar] private int _index;

		private int _scoreValue;

		public void Construct(string playerName, int index)
		{
			_syncPlayerName = playerName;
			_index = index;
		}

		public void IncrementScore()
		{
			if (isServer)
			{
				ApplyScore();
			}
			else
			{
				CmdApplyScore();
			}
		}
		
		private void OnGUI()
		{
			GUI.Box
			(
				new Rect
				(
					x: _position.x + _index * (_scale.x + _spaceBetween),
					y: _position.y,
					width: _scale.x,
					height: _scale.y
				),
				$"{_syncPlayerName}: {_scoreValue}"
			);
		}

		[Command] private void CmdApplyScore() => ApplyScore();
		[Server] private void ApplyScore() => _syncScoreValue++;

		private void SyncPlayerName(string _, string newValue) => _playerNameView.text = _syncPlayerName;
		private void SyncScore(int _, int newValue) => _scoreValue = _syncScoreValue;
	}
}