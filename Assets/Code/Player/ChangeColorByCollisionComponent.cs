using System;
using Code.Infrastructure;
using Mirror;
using UnityEngine;

namespace Code.Player
{
	public class ChangeColorByCollisionComponent : NetworkBehaviour
	{
		[SerializeField] private ColorChangeComponent _colorChangeComponent;
		[SerializeField] private CollisionLocator _collisionLocator;

		private bool _changed;

		private void Start()
		{
			_collisionLocator.Collide += OnCollide;
		}

		private void OnCollide(GameObject other)
		{
			var otherColor = other.GetComponentInChildren<ColorChangeComponent>();

			if (_changed == false)
			{
				otherColor.ToChangedColor();
				_changed = true;
			}
			else
			{
				otherColor.ToDefaultColor();
				_changed = false;
			}
		}
	}
}