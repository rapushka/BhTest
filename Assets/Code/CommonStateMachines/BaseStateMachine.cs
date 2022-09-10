using System;
using System.Collections.Generic;
using System.Linq;
using Code.Workflow.Extensions;
using UnityEngine;

namespace Code.CommonStateMachines
{
	public abstract class BaseStateMachine<TState> : MonoBehaviour, IStateMachine
		where TState : IState
	{
		private Dictionary<Type, TState> _states;

		public TState CurrentState { get; private set; }

		public void SwitchState<T>()
			=> CurrentState = CurrentState
			                  .Do((c) => c.Exit(this))
			                  .Set((c) => _states[typeof(T)])
			                  .Do((c) => c.Enter(this));

		private void Start()
		{
			_states = CreateStatesDictionary();

			SwitchStateToFirstInDictionary();
		}

		protected abstract Dictionary<Type, TState> CreateStatesDictionary();

		private void SwitchStateToFirstInDictionary()
			=> CurrentState = _states
			                  .First()
			                  .Value
			                  .Do((s) => s.Enter(this));
	}
}