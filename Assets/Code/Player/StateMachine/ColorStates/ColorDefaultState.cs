using Code.Infrastructure.GameStateMachine;
using Code.Player.StateMachine.DashStates;

namespace Code.Player.StateMachine.ColorStates
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

		public void OnCollide(PlayerColorStateMachine colorStateMachine, IDashState otherDashState)
		{
			if (otherDashState is DashActiveState)
			{
				colorStateMachine.SwitchState<ColorChangedState>();
			}
		}
	}
}