using System;
using System.Collections.Generic;
using Code.CommonStateMachines;
using Code.Infrastructure.GameLoop;
using UnityEngine;

namespace Code.Infrastructure.GameStates
{
	public class GameStateMachine : BaseStateMachine<IGameState>
	{
		[SerializeField] private int _scoreToWin = 3;
		[SerializeField] private float _secondsOnWinScreen = 5f;

		private DerivedNetworkRoomManager _networkRoomManager;
		public string LastScoredPlayerName { get; private set; }

		public void Construct(DerivedNetworkRoomManager networkRoomManager)
			=> _networkRoomManager = networkRoomManager;
		
		protected override Dictionary<Type, IGameState> CreateStatesDictionary()
			=> new Dictionary<Type, IGameState>
			{
				[typeof(GamePreparationState)] = new GamePreparationState(),
				[typeof(GameplayState)] = new GameplayState(_scoreToWin),
				[typeof(GameWinState)] = new GameWinState(_secondsOnWinScreen, _networkRoomManager),
			};

		public void OnScoreIncrease(string playerName, int score)
		{
			LastScoredPlayerName = playerName;
			CurrentState.OnScoreIncrease(this, playerName, score);
		}

		private void Update() => CurrentState.OnUpdate(this);
	}
}