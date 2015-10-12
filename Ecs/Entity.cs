using System;
using System.Collections.Generic;

namespace Nucleus.Ecs
{
	public class Entity
	{
		private Dictionary<Type, Component> components = new Dictionary<Type, Component>();

		public Entity ()
		{
		}

		public Entity Add(Component component)
        {
            component.Entity = this;
			var type = component.GetType();
            this.components[type] = component;
            return this; // chaining
		}

        public T Get<T>() where T : Component
        {
            var type = typeof(T);
            // If you're asking for T, you will probably add one soon.
            if (!this.components.ContainsKey (type)) {
                throw new ArgumentException("Entity doesn't have any instances of " + type.FullName);
            }
            return (T)this.components[type];
        }

        public bool Has<T>() where T : Component
        {
            return this.components.ContainsKey(typeof(T));
        }
	}
}

