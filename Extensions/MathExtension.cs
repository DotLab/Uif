using UnityEngine;

namespace Uif.Extensions {
	public static class MathExtension {
		public static Vector2 Vec2(this Vector3 a) {
			return new Vector2(a.x, a.y);
		}

		public static Vector2 Div(this Vector2 a, Vector2 b) {
			return new Vector2(a.x / b.x, a.y / b.y);
		}

		public static Vector2 Mult(this Vector2 a, Vector2 b) {
			return new Vector2(a.x * b.x, a.y * b.y);
		}
	}
}

