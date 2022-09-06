using Code.Infrastructure.GameStateMachine;
using Code.Player.StateMachine.DashStates;

namespace Code.Player.StateMachine.ColorStates
{
	public class ColorChangedState : TimeBouncedState<ColorDefaultState>, IColorState
	{
		private readonly ColorChangeComponent _colorChangeComponent;

		public ColorChangedState(ColorChangeComponent colorChangeComponent, float durationChangedColorState)
			: base(durationChangedColorState)
			=> _colorChangeComponent = colorChangeComponent;

		public override void Enter(IStateMachine<IState> stateMachine)
		{
			base.Enter(stateMachine);

			_colorChangeComponent.ToChangedColor();
		}

		public void OnCollide(PlayerColorStateMachine colorStateMachine, DashState otherDashState) { }
	}
}