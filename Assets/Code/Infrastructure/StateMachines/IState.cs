namespace Code.Infrastructure.StateMachines
{
	public interface IState
	{
		void Enter(IStateMachine stateMachine);

		void OnUpdate(IStateMachine stateMachine);

		void Exit(IStateMachine stateMachine);
	}
}