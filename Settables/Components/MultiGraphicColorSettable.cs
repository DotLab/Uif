using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Uif.Settables.Components {
	public class MultiGraphicColorSettable : MonoBehaviour, ISettable<Color> {
		public Color color;
		public bool shouldPerserveAlpha;
		public List<Graphic> graphics = new List<Graphic>();

		void OnValidate() {
			for (int i = 0; i < graphics.Count; i++) {
				if (graphics[i] == null) {
					graphics.RemoveAt(i);
					i -= 1;
				}
			}

			Set(color);
		}

		public void Set(Color c) {
			color = c;
			if (shouldPerserveAlpha) {
				for (int i = 0; i < graphics.Count; i++) {
					var graphic = graphics[i];
					c.a = graphic.color.a;
					graphic.color = c;
				}
			} else {
				for (int i = 0; i < graphics.Count; i++) {
					graphics[i].color = c;
				}
			}
		}

		public Color Get() {
			return color;
		}
	}
}

