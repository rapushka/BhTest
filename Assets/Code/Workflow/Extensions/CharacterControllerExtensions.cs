using UnityEngine;

namespace Code.Workflow.Extensions
{
	public static class CharacterControllerExtensions
	{
		public static void Move(this CharacterController @this, Vector3 motion)
		{
			@this.Move(motion);
		}
	}
}