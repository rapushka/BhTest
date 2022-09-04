namespace Code.Player.StateMachine.ColorStates
{
	public class ColorDefaultState : ColorState
	{
		public ColorDefaultState(ColorChangeComponent colorChangeComponent)
			: base(colorChangeComponent) { }

		public override void Enter(PlayerStateMachine stateMachine)
		{
			ColorChangeComponent.ToDefaultColor();
		}

		public override void OnUpdate(PlayerStateMachine stateMachine) { }

		public override void OnCollide(PlayerStateMachine stateMachine)
		{
			stateMachine.SwitchState<ColorChangedState>();
		}
	}
}