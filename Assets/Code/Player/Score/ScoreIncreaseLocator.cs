using Code.Infrastructure.GameStates;
using Mirror;
using UnityEngine;

namespace Code.Player.Score
{
	public class ScoreIncreaseLocator : NetworkBehaviour
	{
		[SerializeField] private PlayerScore _playerScore;

		private GameStateMachine _gameStateMachine;

		private GameStateMachine GameStateMachine 
			=> _gameStateMachine ??= FindObjectOfType<GameStateMachine>();

		private void Start() => _playerScore.ScoreIncrease += OnScoreIncrease;

		private void OnDestroy() => _playerScore.ScoreIncrease -= OnScoreIncrease;

		private void OnScoreIncrease(string playerName, int score) 
			=> GameStateMachine.OnScoreIncrease(playerName, score);
	}
}