using UnityEngine;
using UnityEngine.UI;

namespace Code.UI
{
	public class FullscreenToggle : MonoBehaviour
	{
		[SerializeField] private Toggle _toggle;

		private void Start() => _toggle.onValueChanged.AddListener(ToggleFullscreen);

		private static void ToggleFullscreen(bool isFullscreen) => Screen.fullScreen = isFullscreen;
	}
}