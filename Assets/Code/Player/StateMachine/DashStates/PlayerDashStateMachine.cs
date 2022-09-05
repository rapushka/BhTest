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

		private void Start()
		{
			_states = new Dictionary<Type, DashState>
			{
				[typeof(DashPassiveState)] = new DashPassiveState(_dashComponent),
				[typeof(DashActiveState)] = new DashActiveState(_dashComponent),
			};

			SwitchState<DashPassiveState>();
			SubscribeEvents();
		}

		private void SubscribeEvents()
		{
			_input.Dashing += OnDash;
			State<DashActiveState>().Hit += OnHit;
		}

		private void OnDestroy()
		{
			_input.Dashing -= OnDash;
			State<DashActiveState>().Hit -= OnHit;
		}

		private void OnHit()
		{
			_playerScore.IncrementScore();
		}

		private void OnDash()
		{
			CurrentState.OnDash(this);
		}

		public void SwitchState<T>()
			where T : DashState
		{
			CurrentState = State<T>();
			CurrentState.Enter(this);
		}

		private void Update()
		{
			CurrentState.OnUpdate(this);
		}

		public void Collide(ColorState otherColorState)
		{
			CurrentState.OnCollide(otherColorState);
		}

		private T State<T>()
			where T : DashState
			=> (T)_states[typeof(T)];
	}
}