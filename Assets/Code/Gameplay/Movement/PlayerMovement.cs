using Code.Workflow.Extensions;
using UnityEngine;

namespace Code.Gameplay.Movement
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private InputEmit _input;
		[SerializeField] private float _movementSpeed;
		[SerializeField] private CharacterController _characterController;
		[SerializeField] private Transform _followCamera;

		private float ScaledDirection => _movementSpeed * Time.fixedDeltaTime;
		
		private void FixedUpdate() => Movement();

		private void Movement()
			=> _input.MoveDirection
			         .ToXZ()
			         .Set(FacingByCameraRotation)
			         .Set(Scale)
			         .Do(_characterController.Move, @if: (d) => d != Vector3.zero);

		private Vector3 FacingByCameraRotation(Vector3 direction) 
			=> Quaternion.Euler(0, _followCamera.eulerAngles.y, 0) * direction;

		private Vector3 Scale(Vector3 direction) => direction * ScaledDirection;
	}
}