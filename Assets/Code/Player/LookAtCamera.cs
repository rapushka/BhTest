using UnityEngine;

namespace Code.Player
{
	public class LookAtCamera : MonoBehaviour
	{
		private void Update()
		{
			UnityEngine.Camera activeCamera = UnityEngine.Camera.current;
			Vector3 targetForward = transform.position - activeCamera.transform.position;
			transform.rotation = Quaternion.LookRotation(targetForward);
		}
	}
}