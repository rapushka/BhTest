using UnityEngine;

namespace Code.Player.StateMachine
{
	public class PlayerStateMachine : MonoBehaviour
	{
		[SerializeField] private ColorChangeComponent _colorChangeComponent;
		
		public void HandleCollide()
		{
			_colorChangeComponent.ToChangedColor();
		}
	}
}