using System;
using System.Collections.Generic;
using Code.Infrastructure.StateMachines;
using Code.Player.Score;
using UnityEngine;

namespace Code.Infrastructure.GameStates
{
	public class GameStateMachine : BaseStateMachine<IGameState>
	{
		[SerializeField] private int _scoreToWin = 3;
		[SerializeField] private float _secondsOnWinScreen = 5f;

		private PlayerScore[] _playerScores;
		
		public string LastSavedPlayerName { get; private set; }

		private IEnumerable<PlayerScore> PlayerScores
			=> _playerScores ??= FindObjectsOfType<PlayerScore>();

		protected override Dictionary<Type, IGameState> CreateStatesDictionary()
			=> new Dictionary<Type, IGameState>
			{
				[typeof(GamePreparationState)] = new GamePreparationState(),
				[typeof(GameplayState)] = new GameplayState(_scoreToWin),
				[typeof(GameWinState)] = new GameWinState(_secondsOnWinScreen),
			};

		private void OnDisable()
		{
			foreach (PlayerScore playerScore in PlayerScores)
			{
				playerScore.ScoreIncrease -= OnScoreIncrease;
			}
		}

		private void OnScoreIncrease(string playerName, int score)
		{
			Debug.Log("OnScoreIncrease");
			LastSavedPlayerName = playerName;
			CurrentState.OnScoreIncrease(this, playerName, score);
		}

		private void Update()
		{
			CurrentState.OnUpdate(this);

			if (CurrentState is GameplayState)
			{
				Registry();
			}
		}

		private void Registry()
		{
			foreach (PlayerScore playerScore in PlayerScores)
			{
				playerScore.ScoreIncrease += OnScoreIncrease;
			}
		}
	}
}