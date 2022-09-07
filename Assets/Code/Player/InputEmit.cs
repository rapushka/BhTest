using System;
using Code.Workflow.Extensions;
using Mirror;
using UnityEngine;

namespace Code.Player
{
	public class InputEmit : NetworkBehaviour, IInputService
	{
		public Vector2 MoveDirection { get; private set; }
		public Vector2 MouseRotation { get; private set; }
		
		public event Action Dashing;
		public event Action Unfocused;

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
		{
			MoveDirection = new Vector2
			{
				x = Input.GetAxis("Horizontal"),
				y = Input.GetAxis("Vertical"),
			};
		}

		private void SetMouseRotation()
		{
			MouseRotation = new Vector2
			{
				x = Input.GetAxis("Mouse X"),
				y = Input.GetAxis("Mouse Y")
			};
		}

		private void InvokeDash() => InvokeActionByKey(Dashing, KeyCode.Mouse0);

		private void Unfocus() => InvokeActionByKey(Unfocused, KeyCode.Escape);

		private static void InvokeActionByKey(Action action, KeyCode key) 
			=> action.Do((a) => a?.Invoke(), @if: Input.GetKeyDown(key));
	}
}