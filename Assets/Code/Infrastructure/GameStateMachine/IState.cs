namespace Code.Infrastructure.GameStateMachine
{
	public interface IState
	{
		void Enter(IStateMachine stateMachine);

		void OnUpdate(IStateMachine stateMachine);
	}
}