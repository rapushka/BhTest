namespace Code.Player.StateMachine
{
	public interface IColorState
	{
		void Enter(PlayerStateMachine stateMachine);

		void OnUpdate(PlayerStateMachine stateMachine);
	}
}