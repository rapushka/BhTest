using Code.CommonStateMachines;
using Code.Gameplay.PlayerStateMachines.DashStates;

namespace Code.Gameplay.PlayerStateMachines.ColorStates
{
	public interface IColorState : IState
	{
		void OnCollide(PlayerColorStateMachine colorStateMachine, IDashState otherDashState);
	}
}