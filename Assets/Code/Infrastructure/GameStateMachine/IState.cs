namespace Code.Infrastructure.GameStateMachine
{
	public interface IState
	{
		void Enter(IStateMachine<IState> stateMachine);

		void OnUpdate(IStateMachine<IState> stateMachine);
	}
}