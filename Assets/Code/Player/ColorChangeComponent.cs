using System;
using Mirror;
using UnityEngine;

namespace Code.Player
{
	public class ColorChangeComponent : NetworkBehaviour
	{
		[SerializeField] private Renderer _renderer;
		[SerializeField] private Color32 _default;
		[SerializeField] private Color32 _changed;

		[SyncVar(hook = nameof(ColorSync))] private Color32 _color;

		private Material _cachedMaterial;

		public void ToDefaultColor() => ChangeColor(_default);

		public void ToChangedColor() => ChangeColor(_changed);

		public override void OnStartServer()
		{
			base.OnStartServer();

			_color = _default;
		}

		private void OnDestroy() => Destroy(_cachedMaterial);

		private void ChangeColor(Color32 color)
		{
			_color = color;
			_cachedMaterial.color = color;
		}

		[Command] private void CmdApplyColor(Color32 color) => ApplyColor(color);
		[Server] private void ApplyColor(Color32 color) => _cachedMaterial.color = color;

		private void ColorSync(Color32 _, Color32 newColor)
		{
			if (_cachedMaterial == null)
			{
				_cachedMaterial = _renderer.material;
			}

			_cachedMaterial.color = newColor;
		}
	}
}