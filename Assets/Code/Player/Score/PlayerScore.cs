using Mirror;
using UnityEngine;

namespace Code.Player.Score
{
	public class PlayerScore : NetworkBehaviour
	{
		[Header("GUI Layout")] [SerializeField] private Vector2 _position;
		[SerializeField] private Vector2 _scale;
		[SerializeField] private float _spaceBetween;

		[SyncVar(hook = nameof(SyncScore))] private int _syncScoreValue;
		[SyncVar] private int _index;
		[SyncVar] private string _playerName;

		private int _scoreValue;

		public void Construct(string playerName, int index)
		{
			_playerName = playerName;
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
				$"{_playerName}: {_scoreValue}"
			);
		}

		[Command] private void CmdApplyScore() => ApplyScore();

		[Server] private void ApplyScore() => _syncScoreValue++;

		private void SyncScore(int _, int newValue) => _scoreValue = _syncScoreValue;
	}
}