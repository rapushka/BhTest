using Code.CommonStateMachines;
using Code.Infrastructure.GameLoop;

namespace Code.Infrastructure.GameStates
{
	public class GameWinState : TimeBouncedState<GamePreparationState>, IGameState
	{
		private readonly DerivedNetworkRoomManager _roomManager;

		public GameWinState(float duration, DerivedNetworkRoomManager roomManager)
			: base(duration) => _roomManager = roomManager;

		public override void Enter(IStateMachine stateMachine)
		{
			base.Enter(stateMachine);

			var gameStateMachine = (GameStateMachine)stateMachine;
			string winnerName = gameStateMachine.LastScoredPlayerName;

			_roomManager.GameOver(winnerName);
		}

		public override void Exit(IStateMachine stateMachine)
		{
			_roomManager.PlayAgain();

			base.Exit(stateMachine);
		}

		public void OnScoreIncrease(GameStateMachine stateMachine, string playerName, int score) { }
	}
}