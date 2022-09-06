using System.Collections.Generic;
using Code.Infrastructure.StateMachines;
using Code.Player.Score;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Infrastructure.GameStates
{
	public class GameplayState : IGameState
	{
		private readonly IEnumerable<PlayerScore> _playerScores;
		private readonly int _scoreToWin;
		private IStateMachine _stateMachine;

		public GameplayState(IEnumerable<PlayerScore> playerScores, int scoreToWin)
		{
			_playerScores = playerScores;
			_scoreToWin = scoreToWin;
		}

		public void Enter(IStateMachine stateMachine)
		{
			Debug.Log("Enter To Gameplay State");
			_stateMachine = stateMachine;
			foreach (PlayerScore playerScore in _playerScores)
			{
				playerScore.ScoreIncrease += OnScoreIncrease;
			}
		}

		private void OnScoreIncrease(string playerName, int score)
		{
			Debug.Log($"{playerName} scored {score}!");
			if (score >= _scoreToWin)
			{
				_stateMachine.SwitchState<GameWinState>();
			}
		}

		public void OnUpdate(IStateMachine stateMachine) { }

		public void Exit(IStateMachine stateMachine)
		{
			foreach (PlayerScore playerScore in _playerScores)
			{
				playerScore.ScoreIncrease -= OnScoreIncrease;
			}
		}
	}
}