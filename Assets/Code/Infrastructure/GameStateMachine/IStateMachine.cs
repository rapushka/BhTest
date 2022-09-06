namespace Code.Infrastructure.GameStateMachine
{
	public interface IStateMachine<out TState>
	{
		void SwitchState<T>();
	}
}