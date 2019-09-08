using Uif.Settables;
using UnityEngine;

namespace Uif.Tasks {
	public sealed class Vector2SettableTask : SettableTask<Vector2> {
		public Vector2 delta;
		public bool isRelative;

		public Vector2SettableTask(ISettable<Vector2> target, float duration, int esType) : base(target, duration, esType) {}

		public override void Start() {
			base.Start();

			if (isRelative) { start = target.Get(); end = start + delta; } 
			else delta = end - start;
		}

		public override void Apply(float t) {
			target.Set(start + delta * t);
		}
	}
}

