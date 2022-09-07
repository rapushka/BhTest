using System;
using System.Collections.Generic;
using Code.CommonStateMachines;
using Code.Gameplay.Dash;
using Code.Gameplay.PlayerStateMachines.ColorStates;
using Code.Gameplay.Score;
using Code.Input;
using UnityEngine;

namespace Code.Gameplay.PlayerStateMachines.DashStates
{
	public class PlayerDashStateMachine : BaseStateMachine<IDashState>
	{
		[SerializeField] private InputService _input;
		[SerializeField] private DashComponent _dashComponent;
		[SerializeField] private PlayerScore _playerScore;

		public void Collide(IColorState otherColorState) => CurrentState.OnCollide(otherColorState);

		protected override Dictionary<Type, IDashState> CreateStatesDictionary()
			=> new Dictionary<Type, IDashState>
			{
				[typeof(DashPassiveState)] = new DashPassiveState(_dashComponent),
				[typeof(DashActiveState)] = new DashActiveState(_dashComponent, _playerScore),
			};

		private void OnEnable() => _input.Dashing += OnDash;
		private void OnDisable() => _input.Dashing -= OnDash;

		private void Update() => CurrentState.OnUpdate(this);

		private void OnDash() => CurrentState.OnDash(this);
	}
}