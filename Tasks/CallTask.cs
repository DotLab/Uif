namespace Uif.Tasks {
	public sealed class CallTask : InstantTask {
		public System.Action action;

		public override void Start() {
			base.Start();

			action();
		}
	}

	public static partial class AnimationSequenceExtension {
		public static AnimationSequence Call(this AnimationSequence seq, System.Action action) {
			seq.Append(new CallTask{action = action});
			return seq;
		}
	}
}

