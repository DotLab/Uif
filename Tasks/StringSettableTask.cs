using Uif.Settables;

namespace Uif.Tasks {
	public sealed class StringSettableTask : SettableTask<string> {
		StringLerp lerp;

		public StringSettableTask(ISettable<string> target, float duration, int esType) : base(target, duration, esType) {}

		public override void Start() {
			base.Start();

			lerp = new StringLerp(start, end);
		}

		public override void Apply(float t) {
			target.Set(lerp.Lerp(t));
		}
	}
}

