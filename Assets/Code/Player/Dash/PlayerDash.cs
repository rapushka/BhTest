using System.Collections;
using UnityEngine;

namespace Code.Player.Dash
{
	public class PlayerDash : MonoBehaviour
	{
		[SerializeField] private float _dashDistance;
		[SerializeField] private float _dashTime;
		[SerializeField] private CharacterController _characterController;
		[SerializeField] private Transform _facingTransform;
		[SerializeField] private InputEmit _input;

		private void Start()
		{
			_input.Dashing += OnDashing;
		}

		private void OnDashing()
		{
			StartCoroutine(DashCoroutine());
		}

		private IEnumerator DashCoroutine()
		{
			float startTime = Time.time; 
			while(Time.time < startTime + _dashTime)
			{
				float speed = _dashDistance / _dashTime;
				_characterController.Move(_facingTransform.forward * (speed * Time.deltaTime));
				yield return null; 
			}
		}
	}
}