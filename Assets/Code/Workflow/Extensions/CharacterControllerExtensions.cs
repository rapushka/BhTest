using UnityEngine;

namespace Code.Workflow.Extensions
{
	public static class CharacterControllerExtensions
	{
		// For calling CharacterController.Move as Action<Vector3>
		public static void Move(this CharacterController @this, Vector3 motion) => @this.Move(motion);
	}
}