using Code.Workflow.Extensions;
using UnityEngine;

namespace Code.Infrastructure.GameStateMachine
{
	public abstract class TimeBouncedState<TNextState> : IState
		where TNextState : IState
	{
		private readonly float _duration;
		private float _beingDuration;

		protected TimeBouncedState(float duration) => _duration = duration;

		public virtual void Enter(IStateMachine<IState> stateMachine) => _beingDuration = _duration;

		public virtual void OnUpdate(IStateMachine<IState> stateMachine)
			=> stateMachine.Do(SwitchToNextState, @if: TimeIsUp);

		private void SwitchToNextState(IStateMachine<IState> stateMachine) => stateMachine.SwitchState<TNextState>();
		private bool TimeIsUp(IStateMachine<IState> _) => (_beingDuration -= Time.deltaTime) <= 0;
	}
}