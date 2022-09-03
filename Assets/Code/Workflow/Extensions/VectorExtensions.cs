using UnityEngine;

namespace Code.Workflow.Extensions
{
	public static class VectorExtensions
	{
		public static Vector3 ToXZ(this Vector2 @this) => new Vector3(@this.x, 0f, @this.y);
	}
}