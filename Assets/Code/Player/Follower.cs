using System;
using Mirror;
using UnityEngine;

namespace Code.Player
{
	public class Follower : MonoBehaviour
	{
		[SerializeField] private float _mouseSensitivity;
		[SerializeField] private float _distanceFromTarget;
		[SerializeField] private float _smoothTime;
		[SerializeField] private Vector2 _rotationXMinMax;
		[SerializeField] private Transform _target;
		[SerializeField] private NetworkBehaviour _networkBehaviour;
		
		private float _rotationY;
		private float _rotationX;
		private Vector3 _currentRotation;
		private Vector3 _smoothVelocity = Vector3.zero;

		private void Start()
		{
			gameObject.SetActive(_networkBehaviour.hasAuthority);
		}

		private void Update()
		{
			RotateCamera();
		}

		private void RotateCamera()
		{
			float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
			float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

			_rotationY += mouseX;
			_rotationX += mouseY;

			// Apply clamping for x rotation 
			_rotationX = Mathf.Clamp(_rotationX, _rotationXMinMax.x, _rotationXMinMax.y);

			var nextRotation = new Vector3(_rotationX, _rotationY);

			// Apply damping between rotation changes
			_currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
			transform.localEulerAngles = _currentRotation;

			// Substract forward vector of the GameObject to point its forward vector to the target
			transform.position = _target.position - transform.forward * _distanceFromTarget;
		}
	}
}