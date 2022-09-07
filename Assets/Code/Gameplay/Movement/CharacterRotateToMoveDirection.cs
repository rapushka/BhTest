using Code.Workflow.Extensions;
using UnityEngine;

namespace Code.Gameplay.Movement
{
	public class CharacterRotateToMoveDirection : MonoBehaviour
	{
		[SerializeField] private Transform _transform;
		[SerializeField] private float _rotationSpeed;
		[SerializeField] private CharacterController _characterController;
		
		private float ScaledSpeed => _rotationSpeed * Time.deltaTime;
		
		private void Update() => this.Do((_) => Rotate(), @if: IsMoving());

		private bool IsMoving() => _characterController.velocity != Vector3.zero;

		private void Rotate()
		{
			Quaternion desiredRotation = Quaternion.LookRotation(_characterController.velocity, Vector3.up);
			_transform.rotation = Quaternion.Slerp(_transform.rotation, desiredRotation, ScaledSpeed);
		}
	}
}