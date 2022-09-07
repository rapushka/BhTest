using UnityEngine;

namespace Code.Player.Camera
{
	public class CursorLocker : MonoBehaviour
	{
		[SerializeField] private InputEmit _input;

		public bool CursorCaptured
		{
			get => Cursor.visible == false; 
			
			private set
			{
				Cursor.visible = value == false;
				Cursor.lockState = value
					? CursorLockMode.Locked
					: CursorLockMode.None;
			}
		}

		private void OnEnable() => _input.Unfocused += OnUnfocusKeyPressed;
		private void OnDisable() => _input.Unfocused -= OnUnfocusKeyPressed;

		private void OnApplicationFocus(bool hasFocus) => CursorCaptured = hasFocus;
		private void OnDestroy() => CursorCaptured = false;

		private void OnUnfocusKeyPressed() => CursorCaptured = false;
	}
}