using Code.Message;
using Code.Workflow.Extensions;
using Mirror;
using UnityEngine;

namespace Code.Messages.Senders
{
	public class PositionSender : MonoBehaviour
	{
		[SerializeField] private Transform[] _spawnPoints;

		public void OnClientConnect()
		{
			var message = new PositionMessage
			{
				position = _spawnPoints.PickRandom().position
			};

			NetworkClient.connection.Send(message);
		}
	}
}