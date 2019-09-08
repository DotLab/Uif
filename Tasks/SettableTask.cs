using Uif.Settables;

namespace Uif.Tasks {
	public abstract class SettableTask<T> : AnimationTask<ISettable<T>> {
		public T start;
		public T end;

		public bool setStartFromTarget;
		public bool setEndFromTarget;

		protected SettableTask(ISettable<T> target, float duration, int esType) : base(target, duration, esType) {}

		public override void Start() {
			if (setStartFromTarget) start = target.Get();
			if (setEndFromTarget) end = target.Get();
		}

		public override void Finish() {
			target.Set(end);
		}
	}
}
