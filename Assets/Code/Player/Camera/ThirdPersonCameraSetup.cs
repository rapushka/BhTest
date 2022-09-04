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
		
		private void Start() => gameObject.SetActive(_playerBehaviour.hasAuthority);

		private void Update() => _rotator.RotateCamera(_input.MouseRotation, _target.position);
	}
}