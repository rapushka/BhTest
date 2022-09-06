namespace Code.Infrastructure.GameStateMachine
{
	public interface IStateMachine
	{
		void SwitchState<T>();
	}
}