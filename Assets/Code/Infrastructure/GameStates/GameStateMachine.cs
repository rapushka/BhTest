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
		
		private IEnumerable<PlayerScore> _cashedGetPlayerScores;

		protected override Dictionary<Type, IGameState> CreateStatesDictionary()
			=> new Dictionary<Type, IGameState>
			{
				[typeof(GamePreparationState)] = new GamePreparationState(),
				[typeof(GameplayState)] = new GameplayState(GetPlayerScores(), _scoreToWin),
				[typeof(GameWinState)] = new GameWinState(_secondsOnWinScreen, GetPlayerScores()),
			};

		private void Update() => CurrentState.OnUpdate(this);

		private IEnumerable<PlayerScore> GetPlayerScores() 
			=> _cashedGetPlayerScores ??= FindObjectOfType<NetworkRoomManagerExt>().PlayerScores;
	}
}