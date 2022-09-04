using UnityEngine;

namespace Code.Player
{
	public class ThirdPersonCameraRotator : MonoBehaviour
	{
		[Header("Mouse Settings")]
		[SerializeField] private bool _invertCamera;
		[SerializeField] private float _mouseSensitivity;
		[SerializeField] private float _distanceFromTarget;
		[SerializeField] private float _smooth;
		[SerializeField] private float _rotationXMin;
		[SerializeField] private float _rotationXMax;
		
		private Vector2 _cameraRotation;
		private Vector3 _currentRotation;
		private Vector3 _smoothVelocity = Vector3.zero;
		
		private float ActualRotationX => _invertCamera
			? _cameraRotation.x
			: -_cameraRotation.x;
		
		public void RotateCamera(Vector2 mouseRotation, Vector3 targetPosition)
		{
			Vector2 scaledMouseRotation = mouseRotation * _mouseSensitivity;

			_cameraRotation.y += scaledMouseRotation.x;
			_cameraRotation.x += scaledMouseRotation.y;

			ClampXRotation();

			var nextRotation = new Vector3(ActualRotationX, _cameraRotation.y);

			ApplyDampingBetweenRotations(nextRotation);
			SubstractForwardToPointForwardToTarget(targetPosition);
		}

		private void SubstractForwardToPointForwardToTarget(Vector3 targetPosition)
			=> transform.position = targetPosition - transform.forward * _distanceFromTarget;

		private void ApplyDampingBetweenRotations(Vector3 nextRotation)
		{
			_currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smooth);
			transform.localEulerAngles = _currentRotation;
		}

		private void ClampXRotation()
			=> _cameraRotation.x = _invertCamera
				? Mathf.Clamp(_cameraRotation.x, _rotationXMin, _rotationXMax)
				: Mathf.Clamp(_cameraRotation.x, -_rotationXMax, -_rotationXMin);
	}
}