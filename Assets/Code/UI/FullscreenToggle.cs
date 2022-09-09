using Code.Workflow.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
	public class FullscreenToggle : MonoBehaviour
	{
		private const FullScreenMode PreferredFullScreenMode = FullScreenMode.ExclusiveFullScreen;
		
		[SerializeField] private Toggle _toggle;
		[SerializeField] private int _windowedResolutionWidth = 700;
		[SerializeField] private int _windowedResolutionHeight = 394;
		
		private static Resolution CurrentResolution => Screen.currentResolution;

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
		{
			Screen.fullScreenMode = PreferredFullScreenMode;
			Screen.SetResolution(CurrentResolution.width, CurrentResolution.height, PreferredFullScreenMode);
		}

		private void ToWindowed()
			=> Screen.SetResolution(_windowedResolutionWidth, _windowedResolutionHeight, FullScreenMode.Windowed);
	}
}