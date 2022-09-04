using UnityEngine;

namespace Code.Player
{
	public class CharacterRotateToMoveDirection : MonoBehaviour
	{
		[SerializeField] private Transform _transform;
		[SerializeField] private float _rotationSpeed;
		[SerializeField] private CharacterController _characterController;
		
		private float ScaledSpeed => _rotationSpeed * Time.deltaTime;
		
		private void Update() => Rotate();

		private void Rotate()
		{
			if (_characterController.velocity == Vector3.zero)
			{
				return;
			}

			Quaternion desiredRotation = Quaternion.LookRotation(_characterController.velocity, Vector3.up);
			_transform.rotation = Quaternion.Slerp(_transform.rotation, desiredRotation, ScaledSpeed);
		}
	}
}