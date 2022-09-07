using Code.Input;
using UnityEngine;

namespace Code.Gameplay.Camera
{
	public class CursorLocker : MonoBehaviour
	{
		[SerializeField] private InputService _input;

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

		private void Start() => Focus();

		private void OnEnable()
		{
			_input.Unfocused += Unfocus;
			_input.Dashing += Focus;
		}

		private void OnDisable()
		{
			_input.Unfocused -= Unfocus;
			_input.Dashing -= Focus;
		}

		private void OnApplicationFocus(bool hasFocus) => CursorCaptured = hasFocus;
		private void OnDestroy() => Unfocus();

		private void Focus() => CursorCaptured = true;
		private void Unfocus() => CursorCaptured = false;
	}
}