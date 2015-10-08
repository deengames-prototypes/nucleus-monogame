using System;
using System.Collections.Generic;

namespace Nucleus
{
	public class Entity
	{
		private Dictionary<Type, List<Component>> components = new Dictionary<Type, List<Component>>();

		public Entity ()
		{
		}

		public void Add(Component component) {
			var type = component.GetType();
			if (!this.components.ContainsKey (type)) {
				this.components[type] = new List<Component> ();
			}
			this.components[type].Add(component);
		}
	}
}

