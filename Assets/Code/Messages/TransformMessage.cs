using Mirror;
using UnityEngine;

namespace Code.Message
{
	public struct TransformMessage : NetworkMessage 
	{
		public Transform transform; 
	}
}