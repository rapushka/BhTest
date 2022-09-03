using Mirror;
using UnityEngine;

namespace Code.Player
{
	public class InputEmit : NetworkBehaviour
	{
		public Vector2 MoveDirection { get; private set; }

		private void Update()
		{
			Movement();
		}

		private void Movement()
		{
			MoveDirection = new Vector2
			{
				x = Input.GetAxis("Horizontal"),
				y = Input.GetAxis("Vertical"),
			};
		}
	}
}