using Mirror;
using UnityEngine;

namespace Code.Player
{
	public class ThirdPersonCameraSetup : MonoBehaviour
	{
		[SerializeField] private Transform _target;
		[SerializeField] private NetworkBehaviour _playerBehaviour;
		[SerializeField] private InputEmit _inputEmit;
		[SerializeField] private ThirdPersonCameraRotator _rotator;
		
		private void Start() => gameObject.SetActive(_playerBehaviour.hasAuthority);

		private void Update() => _rotator.RotateCamera(_inputEmit.MouseRotation, _target.position);
	}
}