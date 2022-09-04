using Code.Workflow.Extensions;
using UnityEngine;

namespace Code.Player
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private InputEmit _input;
		[SerializeField] private float _movementSpeed;
		[SerializeField] private CharacterController _characterController;
		[SerializeField] private Transform _followCamera;

		private float ScaledSpeed => _movementSpeed * Time.fixedDeltaTime;

		private void FixedUpdate() => Move();

		private void Move()
			=> _input.MoveDirection
			         .ToXZ()
			         .Set((d) => Quaternion.Euler(0, _followCamera.eulerAngles.y, 0) * d)
			         .Set((d) => d * ScaledSpeed)
			         .Do(_characterController.Move, @if: (d) => d != Vector3.zero);
	}
}