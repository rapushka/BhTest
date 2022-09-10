using Code.CommonStateMachines;
using Code.Workflow.Extensions;

namespace Code.Infrastructure.GameStates
{
	public class GameplayState : IGameState
	{
		private readonly int _scoreToWin;

		public GameplayState(int scoreToWin) => _scoreToWin = scoreToWin;

		public void Enter(IStateMachine stateMachine) { }

		public void OnUpdate(IStateMachine stateMachine) { }

		public void Exit(IStateMachine stateMachine) { }

		public void OnScoreIncrease(GameStateMachine stateMachine, string playerName, int score) 
			=> stateMachine.Do((sm) => sm.SwitchState<GameWinState>(), @if: score == _scoreToWin);
	}
}