namespace Code.Player.StateMachine
{
	public class ColorChangedState : IColorState
	{
		private readonly ColorChangeComponent _colorChangeComponent;

		public ColorChangedState(ColorChangeComponent colorChangeComponent)
		{
			_colorChangeComponent = colorChangeComponent;
		}
		
		public void Enter(PlayerStateMachine stateMachine)
		{
			_colorChangeComponent.ToChangedColor();
		}
	}
}