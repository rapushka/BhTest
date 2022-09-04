namespace Code.Player.StateMachine
{
	public interface IDashingState : IPlayerState
	{
		void OnDashInput(PlayerStateMachine stateMachine);
	}
}