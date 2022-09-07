using System;
using System.Collections.Generic;
using Code.Infrastructure.StateMachines;
using Code.Player.StateMachine.ColorStates;
using Code.Player.StateMachine.DashStates;
using UnityEngine;

namespace Code.Player.StateMachine
{
	public class PlayerColorStateMachine : BaseStateMachine<IColorState>
	{
		[SerializeField] private ColorChangeComponent _colorChange;
		[SerializeField] private float _durationChangedColorState = 3;

		public void Collide(IDashState otherDashState) => CurrentState.OnCollide(this, otherDashState);

		protected override Dictionary<Type, IColorState> CreateStatesDictionary()
			=> new Dictionary<Type, IColorState>
			{
				[typeof(ColorDefaultState)] = new ColorDefaultState(_colorChange),
				[typeof(ColorChangedState)] = new ColorChangedState(_colorChange, _durationChangedColorState)
			};

		private void Update() => CurrentState.OnUpdate(this);
	}
}