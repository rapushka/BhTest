using UnityEngine;

namespace Code.Gameplay
{
	public class LookAtCamera : MonoBehaviour
	{
		private UnityEngine.Camera _activeCamera;

		private void Start()
		{
			_activeCamera ??= UnityEngine.Camera.main;
			_activeCamera ??= UnityEngine.Camera.current;
		}

		private void Update()
		{
			Vector3 cameraPosition = _activeCamera.transform.position;
			Vector3 targetForward = transform.position - cameraPosition;

			transform.rotation = Quaternion.LookRotation(targetForward);
		}
	}
}