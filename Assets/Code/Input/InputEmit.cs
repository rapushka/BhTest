using System;
using Code.Workflow.Extensions;
using UnityEngine;

namespace Code.Input
{
	public class InputEmit : InputService
	{
		private Vector2 _moveDirection;
		private Vector2 _mouseRotation;

		public override Vector2 MoveDirection => _moveDirection;
		public override Vector2 MouseRotation => _mouseRotation;

		public override event Action Dashing;
		public override event Action Unfocused;

		private void Update()
		{
			if (hasAuthority == false)
			{
				return;
			}

			SetMoveDirection();
			SetMouseRotation();
			InvokeDash();
			Unfocus();
		}

		private void SetMoveDirection()
			=> _moveDirection = new Vector2
			{
				x = UnityEngine.Input.GetAxis("Horizontal"),
				y = UnityEngine.Input.GetAxis("Vertical"),
			};

		private void SetMouseRotation()
			=> _mouseRotation = new Vector2
			{
				x = UnityEngine.Input.GetAxis("Mouse X"),
				y = UnityEngine.Input.GetAxis("Mouse Y")
			};

		private void InvokeDash() => InvokeActionByKey(Dashing, KeyCode.Mouse0);

		private void Unfocus() => InvokeActionByKey(Unfocused, KeyCode.Escape);

		private static void InvokeActionByKey(Action action, KeyCode key)
			=> action.Do((a) => a?.Invoke(), @if: UnityEngine.Input.GetKeyDown(key));
	}
}