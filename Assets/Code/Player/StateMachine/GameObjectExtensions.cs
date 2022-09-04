using JetBrains.Annotations;
using UnityEngine;

namespace Code.Player.StateMachine
{
	public static class GameObjectExtensions
	{
		[CanBeNull]
		public static IDashingState GetDashingState(this Component @this)
			=> @this.HasStateMachine(out PlayerStateMachine stateMachine)
				? stateMachine.CurrentDashingState
				: null;

		[CanBeNull]
		public static IColorState GetColorState(this Component @this)
			=> @this.HasStateMachine(out PlayerStateMachine stateMachine)
				? stateMachine.CurrentColorState
				: null;

		private static bool HasStateMachine(this Component @this, out PlayerStateMachine stateMachine)
		{
			stateMachine = @this.GetComponentInChildren<PlayerStateMachine>();
			return stateMachine != null;
		}
	}
}