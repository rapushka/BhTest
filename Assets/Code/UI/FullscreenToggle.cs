using Code.Workflow.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
	public class FullscreenToggle : MonoBehaviour
	{
		[SerializeField] private Toggle _toggle;
		[SerializeField] private int _windowWidth = 700;
		[SerializeField] private int _windowHeight = 394;

		private static Resolution ScreenResolution => Screen.currentResolution;

		private void Start() => _toggle.isOn = Screen.fullScreen;

		private void OnEnable() => _toggle.onValueChanged.AddListener(ToggleFullscreen);

		private void OnDisable() => _toggle.onValueChanged.RemoveListener(ToggleFullscreen);

		private void ToggleFullscreen(bool isToFullscreen)
			=> this.Do
			(
				@if: isToFullscreen,
				@true: (_) => ToFullscreen(),
				@false: (_) => ToWindowed()
			);

		private static void ToFullscreen()
			=> SetResolution(ScreenResolution, FullScreenMode.FullScreenWindow);

		private void ToWindowed()
			=> Screen.SetResolution(_windowWidth, _windowHeight, FullScreenMode.Windowed);

		private static void SetResolution(Resolution resolution, FullScreenMode fullScreenMode)
			=> Screen.SetResolution(resolution.width, resolution.height, fullScreenMode);
	}
}