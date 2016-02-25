﻿namespace Trilobyte
{
	public class Entity : IUpdatable
	{
		public char Display { get; set; }

		public IScene ParentScene { get; set; }

		public Vector Position;

		public delegate void OnUpdateEventHandler(UpdateEventArgs e);
		public event OnUpdateEventHandler OnUpdate;

		public delegate void CollidedWithEventHandler(object sender, CollisionEventArgs e);
		public event CollidedWithEventHandler OnCollidedWith;

		public delegate void EntityAppearedEventHandler(object sender, CollisionEventArgs e);
		public event EntityAppearedEventHandler OnEntityAppeared;

		public bool CollideWith(CollisionEventArgs e)
		{
			if (OnCollidedWith == null) return false;

			OnCollidedWith(this, e);
			return e.Cancel;
		}

		public bool AppearEntity(CollisionEventArgs e)
		{
			if (OnEntityAppeared == null) return false;

			OnEntityAppeared(this, e);
			return e.Cancel;
		}

		public void Update(UpdateEventArgs e)
		{
			if (OnUpdate == null) return;
			OnUpdate(e);
		}
	}
}
