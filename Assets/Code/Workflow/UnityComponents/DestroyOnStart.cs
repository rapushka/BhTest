using UnityEngine;

namespace Code.Workflow.UnityComponents
{
	public class DestroyOnStart : MonoBehaviour
	{
		private void Start() => Destroy(gameObject);
	}
}