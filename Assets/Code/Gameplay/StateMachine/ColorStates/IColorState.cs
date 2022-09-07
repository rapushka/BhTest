using Code.CommonStateMachines;
using Code.Gameplay.StateMachine.DashStates;

namespace Code.Gameplay.StateMachine.ColorStates
{
	public interface IColorState : IState
	{
		void OnCollide(PlayerColorStateMachine colorStateMachine, IDashState otherDashState);
	}
}