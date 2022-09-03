using Mirror;
using UnityEngine;

namespace Code.Messages.Senders
{
	public class TransformSender : MonoBehaviour
	{
		public void Send(Transform playerTransform)
		{
			var message = new TransformMessage
			{
				transform = playerTransform
			};

			NetworkClient.connection.Send(message);
		}
	}
}