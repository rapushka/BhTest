using Code.CommonStateMachines;
using Code.PlayerStateMachines.ColorStates;

namespace Code.PlayerStateMachines.DashStates
{
	public interface IDashState : IState
	{
		void OnDash(PlayerDashStateMachine playerDashStateMachine);
		void OnCollide(IColorState otherColorState);
	}
}