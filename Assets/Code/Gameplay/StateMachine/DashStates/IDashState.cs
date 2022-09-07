using Code.CommonStateMachines;
using Code.Gameplay.StateMachine.ColorStates;

namespace Code.Gameplay.StateMachine.DashStates
{
	public interface IDashState : IState
	{
		void OnDash(PlayerDashStateMachine playerDashStateMachine);
		void OnCollide(IColorState otherColorState);
	}
}