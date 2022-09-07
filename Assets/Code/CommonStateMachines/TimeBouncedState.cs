using Code.Workflow.Extensions;
using UnityEngine;

namespace Code.CommonStateMachines
{
	public abstract class TimeBouncedState<TNextState> : IState
		where TNextState : IState
	{
		private readonly float _duration;
		private float _beingDuration;

		protected TimeBouncedState(float duration) => _duration = duration;

		public virtual void Enter(IStateMachine stateMachine) => _beingDuration = _duration;

		public virtual void OnUpdate(IStateMachine stateMachine)
			=> stateMachine.Do(SwitchToNextState, @if: TimeIsUp);

		public virtual void Exit(IStateMachine stateMachine) { }

		private void SwitchToNextState(IStateMachine stateMachine) => stateMachine.SwitchState<TNextState>();
		private bool TimeIsUp(IStateMachine _) => (_beingDuration -= Time.deltaTime) <= 0;
	}
}