using Code.CommonStateMachines;
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

			var gameStateMachine = (GameStateMachine)stateMachine;
			gameStateMachine.derivedNetworkRoomManager.GameOver(_winnerName);
		}

		public override void Exit(IStateMachine stateMachine)
		{
			base.Exit(stateMachine);

			var gameStateMachine = (GameStateMachine)stateMachine;
			gameStateMachine.derivedNetworkRoomManager.PlayAgain();
		}

		public void OnScoreIncrease(GameStateMachine stateMachine, string playerName, int score) { }
	}
}