namespace Uif.Tasks {
	public sealed class CallTask : InstantTask {
		readonly System.Action action;

		public CallTask(System.Action action) {
			this.action = action;
		}

		public override void Start() {
			base.Start();

			action();
		}
	}

	public static partial class AnimationSequenceExtension {
		public static AnimationSequence Call(this AnimationSequence seq, System.Action action) {
			seq.Append(new CallTask(action));
			return seq;
		}
	}
}

