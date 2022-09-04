namespace Code.Player.StateMachine.ColorStates
{
	public abstract class ColorState
	{
		protected readonly ColorChangeComponent ColorChangeComponent;

		protected ColorState(ColorChangeComponent colorChangeComponent)
			=> ColorChangeComponent = colorChangeComponent;

		public abstract void Enter(PlayerStateMachine stateMachine);

		public abstract void OnUpdate(PlayerStateMachine stateMachine);

		public abstract void OnCollide(PlayerStateMachine stateMachine);
	}
}