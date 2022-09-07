using Code.CommonStateMachines;

namespace Code.Infrastructure.GameStates
{
	public interface IGameState : IState
	{
		void OnScoreIncrease(GameStateMachine stateMachine, string playerName, int score);
	}
}