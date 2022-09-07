using Code.Infrastructure.GameStates;
using Packages.Mirror.Runtime;
using UnityEngine;

namespace Code.Gameplay.Score
{
	public class ScoreIncreaseAdapter : NetworkBehaviour
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