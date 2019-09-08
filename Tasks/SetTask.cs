using Uif.Settables;

namespace Uif.Tasks {
	public sealed class SetTask<T> : InstantTask {
		public ISettable<T> settable;
		public T value;

		public override void Start() {
			base.Start();

			settable.Set(value);
		}
	}

	public static partial class AnimationSequenceExtension {
		public static AnimationSequence Set<T>(this AnimationSequence seq, ISettable<T> settable, T value) {
			seq.Append(new SetTask<T>{settable = settable, value = value});
			return seq;
		}
	}
}

