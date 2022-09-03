using Mirror;
using UnityEngine;

namespace Code.Messages
{
	public struct TransformMessage : NetworkMessage 
	{
		public Transform transform; 
	}
}