namespace Code.Infrastructure.StateMachines
{
	public interface IStateMachine
	{
		void SwitchState<T>();
	}
}