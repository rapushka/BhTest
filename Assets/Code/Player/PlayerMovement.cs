using Code.Workflow.Extensions;
using UnityEngine;

namespace Code.Player
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private InputEmit _input;
		[SerializeField] private float _movementSpeed;
		[SerializeField] private CharacterController _characterController;

		private float ScaledSpeed => _movementSpeed * Time.fixedDeltaTime;

		private void FixedUpdate() => Move();

		private void Move()
			=> _input.MoveDirection
			         .ToXZ()
			         .Set((d) => d * ScaledSpeed)
			         .Do(_characterController.Move, @if: (d) => d != Vector3.zero);
	}
}