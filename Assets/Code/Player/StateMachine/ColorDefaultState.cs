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
	}
}