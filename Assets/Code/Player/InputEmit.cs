using System;
using Code.Workflow.Extensions;
using Mirror;
using UnityEngine;

namespace Code.Player
{
	public class InputEmit : NetworkBehaviour
	{
		public Vector2 MoveDirection { get; private set; }
		public Vector2 MouseRotation { get; private set; }
		
		public event Action Dashing;

		private void Update()
		{
			if (hasAuthority == false)
			{
				return;
			}

			SetMoveDirection();
			SetMouseRotation();
			InvokeDash();
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

		private void InvokeDash() => Dashing.Do((d) => d?.Invoke(), @if: Input.GetKeyDown(KeyCode.Mouse0));
	}
}