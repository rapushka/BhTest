using UnityEngine;

namespace Code.Player.StateMachine
{
	public class PlayerStateMachine : MonoBehaviour
	{
		[SerializeField] private ColorChangeComponent _colorChangeComponent;
		
		private DefaultColorState _defaultColorState;

		private void Start()
		{
			_defaultColorState = new DefaultColorState(_colorChangeComponent);
		}

		public void Collide()
		{
			_defaultColorState.Enter(this);
		}
	}
}