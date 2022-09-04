using Code.Player.StateMachine.DashStates;

namespace Code.Player.StateMachine.ColorStates
{
	public class ColorDefaultState : ColorState
	{
		public ColorDefaultState(ColorChangeComponent colorChangeComponent)
			: base(colorChangeComponent) { }

		public override void Enter(PlayerColorStateMachine colorStateMachine)
		{
			ColorChangeComponent.ToDefaultColor();
		}

		public override void OnUpdate(PlayerColorStateMachine colorStateMachine) { }
		public override void OnCollide(PlayerColorStateMachine colorStateMachine, DashState otherDashState)
		{
			if (otherDashState is DashActiveState)
			{
				colorStateMachine.SwitchState<ColorChangedState>();
			}
		}
	}
}