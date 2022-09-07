using UnityEngine;

namespace Code.Gameplay.Score
{
	public class LookAtCamera : MonoBehaviour
	{
		private UnityEngine.Camera _activeCamera;

		private Vector3 TargetForward => transform.position - _activeCamera.transform.position;

		private void Start()
		{
			_activeCamera ??= UnityEngine.Camera.main;
			_activeCamera ??= UnityEngine.Camera.current;
		}

		private void Update() => transform.rotation = Quaternion.LookRotation(TargetForward);
	}
}