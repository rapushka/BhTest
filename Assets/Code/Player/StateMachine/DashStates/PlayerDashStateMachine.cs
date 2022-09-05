using System;
using System.Collections.Generic;
using Code.Player.Dash;
using Code.Player.Score;
using Code.Player.StateMachine.ColorStates;
using UnityEngine;

namespace Code.Player.StateMachine.DashStates
{
	public class PlayerDashStateMachine : MonoBehaviour
	{
		[SerializeField] private InputEmit _input;
		[SerializeField] private DashComponent _dashComponent;
		[SerializeField] private PlayerScore _playerScore;

		private Dictionary<Type, DashState> _states;

		public DashState CurrentState { get; private set; }

		public void SwitchState<T>()
			where T : DashState
		{
			CurrentState = State<T>();
			CurrentState.Enter(this);
		}

		public void Collide(ColorState otherColorState) => CurrentState.OnCollide(otherColorState);

		private void Start()
		{
			_states = new Dictionary<Type, DashState>
			{
				[typeof(DashPassiveState)] = new DashPassiveState(_dashComponent),
				[typeof(DashActiveState)] = new DashActiveState(_dashComponent, _playerScore),
			};

			SwitchState<DashPassiveState>();
		}

		private void OnEnable() => _input.Dashing += OnDash;

		private void OnDisable() => _input.Dashing -= OnDash;

		private void OnDash() => CurrentState.OnDash(this);

		private void Update() => CurrentState.OnUpdate(this);

		private T State<T>()
			where T : DashState
			=> (T)_states[typeof(T)];
	}
}