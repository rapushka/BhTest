using System;
using UnityEngine;

namespace Code.Gameplay
{
	public interface IInputService
	{
		Vector2 MoveDirection { get; }
		Vector2 MouseRotation { get; }
		event Action Dashing;
		event Action Unfocused;
	}
}