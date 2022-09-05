using Mirror;
using UnityEngine;

namespace Code.Player
{
	public class ColorChangeComponent : NetworkBehaviour
	{
		[SerializeField] private Renderer _renderer;
		[SerializeField] private Color _default;
		[SerializeField] private Color _changed;

		[SyncVar(hook = nameof(SyncColor))] private Color _syncColor;
		
		private Color _color;

		public void ToDefaultColor() => ChangeColor(_default);

		public void ToChangedColor() => ChangeColor(_changed);

		private void Update() => _renderer.material.color = _color;

		private void ChangeColor(Color color)
		{
			if (isServer)
			{
				ApplyColor(color);
			}
			else
			{
				CmdApplyColor(color);
			}
		}

		[Command] private void CmdApplyColor(Color color) => ApplyColor(color);

		[Server] private void ApplyColor(Color color) => _syncColor = color;

		private void SyncColor(Color _, Color newValue) => _color = _syncColor;
	}
}