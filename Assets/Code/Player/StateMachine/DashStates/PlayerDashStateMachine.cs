using System;
using System.Collections.Generic;
using Code.Infrastructure.GameStateMachine;
using Code.Player.Dash;
using Code.Player.Score;
using Code.Player.StateMachine.ColorStates;
using UnityEngine;

namespace Code.Player.StateMachine.DashStates
{
	public class PlayerDashStateMachine : MonoBehaviour, IStateMachine<IDashState>
	{
		[SerializeField] private InputEmit _input;
		[SerializeField] private DashComponent _dashComponent;
		[SerializeField] private PlayerScore _playerScore;

		private Dictionary<Type, IDashState> _states;

		public IDashState CurrentState { get; private set; }

		public void SwitchState<T>()
		{
			CurrentState = _states[typeof(T)];
			CurrentState.Enter(this);
		}

		public void Collide(IColorState otherColorState) => CurrentState.OnCollide(otherColorState);

		private void Start()
		{
			_states = new Dictionary<Type, IDashState>
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
	}
}