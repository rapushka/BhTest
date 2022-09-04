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
			if (_changed == false)	
			{
				_colorChangeComponent.ToChangedColor();
				_changed = true;
			}
			else
			{
				_colorChangeComponent.ToDefaultColor();
				_changed = false;
			}
		}
	}
}