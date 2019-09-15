using Uif.Settables;
using UnityEngine;

namespace Uif.Tasks {
	public sealed class ColorSettableTask : SettableTask<Color> {
		public ColorSettableTask(ISettable<Color> target, float duration, int esType) : base(target, duration, esType) {}

		public override void Apply(float t) {
			target.Set(Color.Lerp(start, end, t));
		}
	}
}

