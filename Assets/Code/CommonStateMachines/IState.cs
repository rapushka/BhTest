namespace Code.CommonStateMachines
{
	public interface IState
	{
		void Enter(IStateMachine stateMachine);

		void OnUpdate(IStateMachine stateMachine);

		void Exit(IStateMachine stateMachine);
	}
}