using Code.Workflow.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
	public class FullscreenToggle : MonoBehaviour
	{
		[SerializeField] private Toggle _toggle;
		[SerializeField] private Vector2Int _minimalResolutionSize = new Vector2Int(700, 394);

		private Resolution _cashedWindowResolution;
		private Resolution _minimalWindowResolution;

		private bool IsFullScreen
		{
			set => Screen.fullScreenMode = value
				? FullScreenMode.ExclusiveFullScreen
				: FullScreenMode.Windowed;
		}

		private void Start()
		{
			_toggle.isOn = Screen.fullScreen;
			_minimalWindowResolution = ResolutionExtensions.New(_minimalResolutionSize);
			_cashedWindowResolution = _minimalWindowResolution;

			_toggle.onValueChanged.AddListener(ToggleFullscreen);
		}

		private void OnDestroy()
		{
			_toggle.onValueChanged.RemoveListener(ToggleFullscreen);
		}

		private void ToggleFullscreen(bool toFullscreen)
		{
			Resolution targetResolution = GetTargetResolution(toFullscreen);

			Screen.SetResolution(targetResolution.width, targetResolution.height, toFullscreen);
		}

		private Resolution GetTargetResolution(bool toFullscreen)
			=> toFullscreen
				? ToFullscreen()
				: ToWindowed();

		private Resolution ToFullscreen()
		{
			_cashedWindowResolution = ResolutionExtensions.WindowResolution;
			return ResolutionExtensions.ScreenResolution;
		}

		private Resolution ToWindowed() => ResolutionExtensions.Max(_cashedWindowResolution, _minimalWindowResolution);
	}
}