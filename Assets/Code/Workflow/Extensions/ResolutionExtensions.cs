using UnityEngine;

namespace Code.Workflow.Extensions
{
	public static class ResolutionExtensions
	{

		public static Resolution WindowResolution => New(Screen.width, Screen.height);
		public static Resolution ScreenResolution => Screen.currentResolution;

		public static Resolution New(Vector2Int resolution)
			=> New(resolution.x, resolution.y);

		public static Resolution New(int width, int height)
			=> new Resolution
			{
				width = width,
				height = height
			};

		public static Resolution Max(Resolution left, Resolution right)
			=> left.IsLessThan(right) ? right : left;

		public static bool IsLessThan(this Resolution @this, Resolution other)
			=> @this.width < other.width
			   || @this.height < other.height;
	}
}