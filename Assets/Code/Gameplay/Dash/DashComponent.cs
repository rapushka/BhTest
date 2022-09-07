using System.Collections;
using UnityEngine;

namespace Code.Gameplay.Dash
{
	public class DashComponent : MonoBehaviour
	{
		[SerializeField] private float _dashDistance;
		[SerializeField] private float _dashDuration;
		[SerializeField] private CharacterController _characterController;
		[SerializeField] private Transform _facingTransform;

		public float DashDuration => _dashDuration;
		
		public void Dash() => StartCoroutine(DashCoroutine());

		private IEnumerator DashCoroutine()
		{
			float inDashTime = _dashDuration; 
			
			while((inDashTime -= Time.deltaTime) > 0)
			{
				float dashSpeed = _dashDistance / _dashDuration;
				float scaledSpeed = dashSpeed * Time.deltaTime;
				_characterController.Move(_facingTransform.forward * scaledSpeed);
				
				yield return null; 
			}
		}
	}
}