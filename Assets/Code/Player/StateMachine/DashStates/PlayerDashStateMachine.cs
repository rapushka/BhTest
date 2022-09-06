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

		public DashState CurrentDashState { get; private set; }

		public void SwitchState<T>()
			where T : DashState
		{
			CurrentDashState = State<T>();
			CurrentDashState.Enter(this);
		}

		public void Collide(IColorState otherColorState) => CurrentDashState.OnCollide(otherColorState);

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

		private void OnDash() => CurrentDashState.OnDash(this);

		private void Update() => CurrentDashState.OnUpdate(this);

		private T State<T>()
			where T : DashState
			=> (T)_states[typeof(T)];
	}
}