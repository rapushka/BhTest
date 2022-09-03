using Mirror;
using UnityEngine;
using UnityEngine.Serialization;

namespace Code.Player
{
	public class Follower : MonoBehaviour
	{
		[SerializeField] private float _mouseSensitivity;
		[SerializeField] private float _distanceFromTarget;
		[FormerlySerializedAs("_smoothTime")] [SerializeField] private float _smooth;
		[SerializeField] private float _rotationXMin;
		[SerializeField] private float _rotationXMax;
		[SerializeField] private Transform _target;
		[SerializeField] private NetworkBehaviour _networkBehaviour;
		[SerializeField] private bool _invertCamera;

		private float _rotationY;
		private float _rotationX;
		private Vector3 _currentRotation;
		private Vector3 _smoothVelocity = Vector3.zero;

		private float ActualRotationX => _invertCamera
			? _rotationX
			: -_rotationX;

		private void Start() => gameObject.SetActive(_networkBehaviour.hasAuthority);

		private void Update() => RotateCamera();

		private void RotateCamera()
		{
			float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
			float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

			_rotationY += mouseX;
			_rotationX += mouseY;

			ApplyClampingByX();

			var nextRotation = new Vector3(ActualRotationX, _rotationY);

			ApplyDampingBetweenRotations(nextRotation);

			SubstractForwardToPointForwardToTarget();
		}

		private void SubstractForwardToPointForwardToTarget()
		{
			transform.position = _target.position - transform.forward * _distanceFromTarget;
		}

		private void ApplyDampingBetweenRotations(Vector3 nextRotation)
		{
			_currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smooth);
			transform.localEulerAngles = _currentRotation;
		}

		private void ApplyClampingByX()
		{
			_rotationX = _invertCamera
				? Mathf.Clamp(_rotationX, _rotationXMax, _rotationXMin)
				: Mathf.Clamp(_rotationX, -_rotationXMin, -_rotationXMax);
		}
	}
}