using JetBrains.Annotations;
using UnityEngine;

namespace Code.Player.StateMachine
{
	public static class GameObjectExtensions
	{
		[CanBeNull]
		public static IDashingState GetDashingState(this GameObject @this)
			=> @this.HasStateMachine(out PlayerStateMachine stateMachine)
				? stateMachine.CurrentDashingState
				: null;

		[CanBeNull]
		public static IColorState GetColorState(this GameObject @this)
			=> @this.HasStateMachine(out PlayerStateMachine stateMachine)
				? stateMachine.CurrentColorState
				: null;

		private static bool HasStateMachine(this GameObject @this, out PlayerStateMachine stateMachine)
		{
			stateMachine = @this != null ? @this.GetComponentInChildren<PlayerStateMachine>() : null;
			return stateMachine != null;
		}
	}
}