using System;
using System.Collections.Generic;
using Code.Player.Dash;
using Code.Player.StateMachine.ColorStates;
using UnityEngine;

namespace Code.Player.StateMachine.DashStates
{
	public class PlayerDashStateMachine : MonoBehaviour
	{
		[SerializeField] private InputEmit _input;
		[SerializeField] private DashComponent _dashComponent;

		private Dictionary<Type, DashState> _states;
		private DashState _currentDashState;

		private void Start()
		{
			_states = new Dictionary<Type, DashState>
			{
				[typeof(DashPassiveState)] = new DashPassiveState(_dashComponent),
			};

			SwitchState<DashPassiveState>();
			_input.Dashing += OnDash;
		}

		private void OnDash()
		{
			_currentDashState.OnDash(this);
		}

		public void SwitchState<T>()
		{
			_currentDashState = State<T>();
			_currentDashState.Enter(this);
		}
		
		private DashState State<T>() => _states[typeof(T)];
	}
}