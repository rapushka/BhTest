using Code.Infrastructure.GameStateMachine;
using Code.Player.StateMachine.DashStates;

namespace Code.Player.StateMachine.ColorStates
{
	public interface IColorState : IState
	{
		void OnCollide(PlayerColorStateMachine colorStateMachine, IDashState otherDashState);
	}
}