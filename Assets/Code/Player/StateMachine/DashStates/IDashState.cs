using Code.Infrastructure.StateMachines;
using Code.Player.StateMachine.ColorStates;

namespace Code.Player.StateMachine.DashStates
{
	public interface IDashState : IState
	{
		void OnDash(PlayerDashStateMachine playerDashStateMachine);
		void OnCollide(IColorState otherColorState);
	}
}