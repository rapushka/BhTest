using Code.Workflow.Extensions;
using UnityEngine;

namespace Code.Player
{
	public class PlayerToMoveDirectionRotator : MonoBehaviour
	{
		[SerializeField] private InputEmit _input;
		[SerializeField] private Transform _playerTransform;

		private void Update() => Rotate();

		private void Rotate()
		{
			if (_input.MoveDirection == Vector2.zero)
			{
				return;
			}
			
			Quaternion desiredRotation = Quaternion.LookRotation(_input.MoveDirection.ToXZ(), Vector3.up);
			_playerTransform.rotation = desiredRotation;	
		}
	}
}