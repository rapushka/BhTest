using Mirror;
using UnityEngine;

namespace Code.Messages.Subscribers
{
	public class TransformSubscriber : MonoBehaviour
	{
		[SerializeField] private Transform _cameraTransform;

		public void OnStartServer(NetworkConnectionToClient connection, TransformMessage message)
		{
			_cameraTransform.SetParent(message.transform, worldPositionStays: false);
		}
	}
}