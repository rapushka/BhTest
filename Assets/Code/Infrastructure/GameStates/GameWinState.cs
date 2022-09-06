using Code.Infrastructure.StateMachines;
using UnityEngine;

namespace Code.Infrastructure.GameStates
{
	public class GameWinState : TimeBouncedState<GameplayState>, IGameState
	{
		private string _winnerName;

		public GameWinState(float duration)
			: base(duration) { }

		public override void Enter(IStateMachine stateMachine)
		{
			base.Enter(stateMachine);

			_winnerName = ((GameStateMachine)stateMachine).LastSavedPlayerName;
			
			Debug.Log($"{_winnerName} is winner!");
		}

		public override void Exit(IStateMachine stateMachine)
		{
			base.Exit(stateMachine);

			Debug.Log("Game Win State Exit");
		}

		public void OnScoreIncrease(GameStateMachine stateMachine, string playerName, int score) { }
	}
}