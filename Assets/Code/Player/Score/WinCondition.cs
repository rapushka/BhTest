using Mirror;
using UnityEngine;

namespace Code.Player.Score
{
	public class WinCondition : NetworkBehaviour
	{
		[SerializeField] private PlayerScore _playerScore;

		private void Start()
		{
			_playerScore.ScoreIncrease += OnScoreIncrease;
		}

		private void OnScoreIncrease(string arg1, int arg2)
		{
			Debug.Log("ScoreIncrease Event handled by WinCondition");
		}
	}
}