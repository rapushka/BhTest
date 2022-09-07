using Code.Workflow.Extensions;
using Mirror;
using UnityEngine;

namespace Code.Player.Camera
{
	public class ThirdPersonCameraSetup : MonoBehaviour
	{
		[SerializeField] private Transform _target;
		[SerializeField] private NetworkBehaviour _playerBehaviour;
		[SerializeField] private InputEmit _input;
		[SerializeField] private ThirdPersonCameraRotator _rotator;
		[SerializeField] private CursorLocker _cursorLocker;

		private void Start() => gameObject.SetActive(_playerBehaviour.hasAuthority);

		private void Update() => this.Do(RotateCamera, @if: _cursorLocker.CursorCaptured);

			private void RotateCamera(ThirdPersonCameraSetup _)
			=> _rotator.RotateCamera(_input.MouseRotation, _target.position);
	}
}