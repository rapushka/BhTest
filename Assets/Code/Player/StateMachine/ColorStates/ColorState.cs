namespace Code.Player.StateMachine.ColorStates
{
	public abstract class ColorState
	{
		protected readonly ColorChangeComponent ColorChangeComponent;

		protected ColorState(ColorChangeComponent colorChangeComponent)
			=> ColorChangeComponent = colorChangeComponent;

		public abstract void Enter(PlayerColorStateMachine colorStateMachine);

		public abstract void OnUpdate(PlayerColorStateMachine colorStateMachine);

		public abstract void OnCollide(PlayerColorStateMachine colorStateMachine);
	}
}