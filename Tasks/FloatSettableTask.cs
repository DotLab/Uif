using Uif.Settables;

namespace Uif.Tasks {
	public sealed class FloatSettableTask : SettableTask<float> {
		public float delta;
		public bool isRelative;

		public FloatSettableTask(ISettable<float> target, float duration, int esType) : base(target, duration, esType) {}

		public override void Start() {
			base.Start();

			if (isRelative) {
				start = target.Get();
				end = start + delta;
			} else {
				delta = end - start;
			}
		}

		public override void Apply(float t) {
			target.Set(start + delta * t);
		}

		public override void Finish() {
			target.Set(end);
		}
	}
}

