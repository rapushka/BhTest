using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
	public class FullscreenToggle : MonoBehaviour
	{
		[SerializeField] private Toggle _toggle;

		private static Resolution _cashedWindowResolution;

		private bool IsFullScreen
		{
			set => Screen.fullScreenMode = value
				? FullScreenMode.ExclusiveFullScreen
				: FullScreenMode.Windowed;
		}

		private static Resolution WindowResolution => new Resolution
		{
			height = Screen.height,
			width = Screen.width
		};

		private static Resolution ScreenResolution => Screen.currentResolution;

		private void Start()
		{
			_toggle.isOn = Screen.fullScreen;
			_toggle.onValueChanged.AddListener(ToggleFullscreen);
		}

		private void ToggleFullscreen(bool toFullscreen)
		{
			Resolution targetResolution = GetTargetResolution(toFullscreen);

			Screen.SetResolution(targetResolution.width, targetResolution.height, toFullscreen);
		}

		private static Resolution GetTargetResolution(bool toFullscreen) 
			=> toFullscreen 
				? CashWindowResolution() 
				: _cashedWindowResolution;

		private static Resolution CashWindowResolution()
		{
			_cashedWindowResolution = WindowResolution;
			return ScreenResolution;
		}
	}
}