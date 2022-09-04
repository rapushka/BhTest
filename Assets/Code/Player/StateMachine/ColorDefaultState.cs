namespace Code.Player.StateMachine
{
	public class ColorDefaultState : IColorState
	{
		private readonly ColorChangeComponent _colorChangeComponent;

		public ColorDefaultState(ColorChangeComponent colorChangeComponent)
		{
			_colorChangeComponent = colorChangeComponent;
		}

		public void Enter(PlayerStateMachine stateMachine)
		{
			_colorChangeComponent.ToDefaultColor();
		}

		public void OnUpdate(PlayerStateMachine stateMachine) { }

		public void OnCollide(PlayerStateMachine stateMachine)
		{
			stateMachine.SwitchState<ColorChangedState>();
		}
	}
}