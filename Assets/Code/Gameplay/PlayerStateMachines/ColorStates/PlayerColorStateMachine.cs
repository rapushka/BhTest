using System;
using System.Collections.Generic;
using Code.CommonStateMachines;
using Code.Gameplay.PlayerStateMachines.DashStates;
using UnityEngine;

namespace Code.Gameplay.PlayerStateMachines.ColorStates
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