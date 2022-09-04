namespace Code.Player.StateMachine
{
	public class DefaultColorState : IColorState
	{
		private readonly ColorChangeComponent _colorChangeComponent;

		public DefaultColorState(ColorChangeComponent colorChangeComponent)
		{
			_colorChangeComponent = colorChangeComponent;
		}
		
		public void Enter(PlayerStateMachine stateMachine)
		{
			_colorChangeComponent.ToChangedColor();
		}
	}
}