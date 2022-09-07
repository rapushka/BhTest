using Code.CommonStateMachines;
using Code.Gameplay.StateMachine.DashStates;

namespace Code.Gameplay.StateMachine.ColorStates
{
	public class ColorDefaultState : IColorState
	{
		private readonly ColorChangeComponent _colorChangeComponent;

		public ColorDefaultState(ColorChangeComponent colorChangeComponent)
		{
			_colorChangeComponent = colorChangeComponent;
		}

		public void Enter(IStateMachine stateMachine) => _colorChangeComponent.ToDefaultColor();

		public void OnUpdate(IStateMachine stateMachine) { }
		public void Exit(IStateMachine stateMachine) { }

		public void OnCollide(PlayerColorStateMachine colorStateMachine, IDashState otherDashState)
		{
			if (otherDashState is DashActiveState)
			{
				colorStateMachine.SwitchState<ColorChangedState>();
			}
		}
	}
}