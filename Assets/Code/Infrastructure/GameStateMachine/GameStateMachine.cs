using System;

namespace Code.Infrastructure.GameStateMachine
{
	public class GameStateMachine : IStateMachine<IGameState>
	{
		public void SwitchState<TSate>()
		{
			throw new NotImplementedException();
		}
	}
}