using Code.CommonStateMachines;
using Code.PlayerStateMachines.DashStates;

namespace Code.PlayerStateMachines.ColorStates
{
	public interface IColorState : IState
	{
		void OnCollide(PlayerColorStateMachine colorStateMachine, IDashState otherDashState);
	}
}