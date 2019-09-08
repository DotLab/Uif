using Uif.Settables;
using UnityEngine;

namespace Uif.Tasks {
	public sealed class Vector3SettableTask : SettableTask<Vector3> {
		public Vector3 delta;
		public bool isRelative;

		public Vector3SettableTask(ISettable<Vector3> target, float duration, int esType) : base(target, duration, esType) {}

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

