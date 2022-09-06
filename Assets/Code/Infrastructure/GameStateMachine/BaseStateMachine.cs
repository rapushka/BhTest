using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Code.Infrastructure.GameStateMachine
{
	public abstract class BaseStateMachine<TState> : MonoBehaviour, IStateMachine
		where TState : IState
	{
		private Dictionary<Type, TState> _states;

		public TState CurrentState { get; private set; }

		public void SwitchState<T>()
		{
			CurrentState = _states[typeof(T)];
			CurrentState.Enter(this);
		}

		private void Start()
		{
			_states = CreateStatesDictionary();
			SwitchStateToFirstInDictionary();
		}

		private void SwitchStateToFirstInDictionary()
		{
			CurrentState = _states.First().Value;
			CurrentState.Enter(this);
		}

		protected abstract Dictionary<Type, TState> CreateStatesDictionary();
	}
}