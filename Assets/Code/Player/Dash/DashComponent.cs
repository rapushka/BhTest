using System.Collections;
using UnityEngine;

namespace Code.Player.Dash
{
	public class DashComponent : MonoBehaviour
	{
		[SerializeField] private float _dashDistance;
		[SerializeField] private float _dashDuration;
		[SerializeField] private CharacterController _characterController;
		[SerializeField] private Transform _facingTransform;
		[SerializeField] private InputEmit _input;

		public float DashDuration => _dashDuration;
		
		private void Start() => _input.Dashing += OnDashing;

		private void OnDashing() => StartCoroutine(DashCoroutine());

		private IEnumerator DashCoroutine()
		{
			float startTime = Time.time; 
			
			while(Time.time < startTime + _dashDuration)
			{
				float speed = _dashDistance / _dashDuration;
				_characterController.Move(_facingTransform.forward * (speed * Time.deltaTime));
				yield return null; 
			}
		}
	}
}