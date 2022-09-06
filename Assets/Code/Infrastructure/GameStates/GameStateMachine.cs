using System;
using System.Collections.Generic;
using Code.Infrastructure.StateMachines;

namespace Code.Infrastructure.GameStates
{
	public class GameStateMachine : BaseStateMachine<IGameState>
	{
		protected override Dictionary<Type, IGameState> CreateStatesDictionary()
			=> new Dictionary<Type, IGameState>
			{
				[typeof(GamePreparationState)] = new GamePreparationState()
			};
	}
}