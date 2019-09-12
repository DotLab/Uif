using UnityEngine;
using UnityEngine.UI;

namespace Uif.Extensions {
	public static class GraphicExtension {
		public static void SetAlpha(this Graphic g, float a) {
			var c = g.color;
			c.a = a;
			g.color = c;
		}
	}
}

