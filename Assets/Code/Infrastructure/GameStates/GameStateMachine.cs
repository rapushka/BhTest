using System;
using System.Collections.Generic;
using System.Linq;
using Code.Infrastructure.StateMachines;
using Code.Player.Score;
using UnityEngine;

namespace Code.Infrastructure.GameStates
{
	public class GameStateMachine : BaseStateMachine<IGameState>
	{
		[SerializeField] private int _scoreToWin = 3;
		[SerializeField] private float _secondsOnWinScreen = 5f;

		private NetworkRoomManagerExt _cashedNetworkRoomManager;
		private List<PlayerScore> _playerScores = new List<PlayerScore>();
		
		public string LastSavedPlayerName { get; private set; }

		private NetworkRoomManagerExt NetworkRoomManager
			=> _cashedNetworkRoomManager ??= FindObjectOfType<NetworkRoomManagerExt>();

		protected override Dictionary<Type, IGameState> CreateStatesDictionary()
			=> new Dictionary<Type, IGameState>
			{
				[typeof(GamePreparationState)] = new GamePreparationState(),
				[typeof(GameplayState)] = new GameplayState(_scoreToWin),
				[typeof(GameWinState)] = new GameWinState(_secondsOnWinScreen),
			};

		private void OnEnable()
		{
			NetworkRoomManager.PlayerConnected += OnPlayerConnected;
		}

		private void OnPlayerConnected(PlayerScore playerScore)
		{
			_playerScores.Add(playerScore);
			playerScore.ScoreIncrease += OnScoreIncrease;
		}

		private void OnDisable()
		{
			NetworkRoomManager.PlayerConnected -= OnPlayerConnected;

			foreach (PlayerScore playerScore in _playerScores)
			{
				playerScore.ScoreIncrease -= OnScoreIncrease;
			}
		}

		private void OnScoreIncrease(string playerName, int score)
		{
			LastSavedPlayerName = playerName;
			CurrentState.OnScoreIncrease(this, playerName, score);
		}

		private void Update() => CurrentState.OnUpdate(this);
	}
}