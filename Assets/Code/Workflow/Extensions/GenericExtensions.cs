using System;

namespace Code.Workflow.Extensions
{
	public static class GenericExtensions
	{
		public static T Do<T>(this T @this, Action<T> @do, bool @if)
		{
			if (@if)
			{
				@do.Invoke(@this);
			}

			return @this;
		}

		public static T Do<T>(this T @this, Action<T> @do, Func<T, bool> @if)
		{
			if (@if.Invoke(@this))
			{
				@do.Invoke(@this);
			}

			return @this;
		}

		public static T Set<T>(this T @this, Func<T, T> @do)
		{
			@this = @do.Invoke(@this);
			
			return @this;
		}
	}
}