using Code.CommonStateMachines;

namespace Code.Infrastructure.GameStates
{
	public class GameWinState : TimeBouncedState<GameplayState>, IGameState
	{
		public GameWinState(float duration)
			: base(duration) { }

		public override void Enter(IStateMachine stateMachine)
		{
			base.Enter(stateMachine);

			var gameStateMachine = (GameStateMachine)stateMachine;

			string winnerName = gameStateMachine.LastSavedPlayerName;
			gameStateMachine.derivedNetworkRoomManager.GameOver(winnerName);
		}

		public override void Exit(IStateMachine stateMachine)
		{
			var gameStateMachine = (GameStateMachine)stateMachine;
			gameStateMachine.derivedNetworkRoomManager.PlayAgain();

			base.Exit(stateMachine);
		}

		public void OnScoreIncrease(GameStateMachine stateMachine, string playerName, int score) { }
	}
}