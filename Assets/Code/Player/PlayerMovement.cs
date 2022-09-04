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

		private void FixedUpdate() => Move();

		private void Move()
			=> _input.MoveDirection
			         .ToXZ()
			         .Set(FacingByCamera)
			         .Set(Scale)
			         .Do(_characterController.Move, @if: (d) => d != Vector3.zero);

		private Vector3 Scale(Vector3 d) => d * (_movementSpeed * Time.fixedDeltaTime);

		private Vector3 FacingByCamera(Vector3 direction) 
			=> Quaternion.Euler(0, _followCamera.eulerAngles.y, 0) * direction;
	}
}