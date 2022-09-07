using System;
using Mirror;
using UnityEngine;

namespace Code.Input
{
	public abstract class InputService : NetworkBehaviour
	{
		public abstract Vector2 MoveDirection { get; }
		public abstract Vector2 MouseRotation { get; }
		public abstract event Action Dashing;
		public abstract event Action Unfocused;
	}
}