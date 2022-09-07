using Code.CommonStateMachines;
using Code.Gameplay.PlayerStateMachines.ColorStates;

namespace Code.Gameplay.PlayerStateMachines.DashStates
{
	public interface IDashState : IState
	{
		void OnDash(PlayerDashStateMachine playerDashStateMachine);
		void OnCollide(IColorState otherColorState);
	}
}