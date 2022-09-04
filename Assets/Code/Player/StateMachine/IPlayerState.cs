using UnityEngine;

namespace Code.Player.StateMachine
{
	public interface IPlayerState
	{
		void Enter(PlayerStateMachine stateMachine);
		void OnUpdate(PlayerStateMachine stateMachine);
		void OnCollide(PlayerStateMachine stateMachine, GameObject collider);
	}
}