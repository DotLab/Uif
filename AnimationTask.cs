namespace Uif {
	public abstract class AnimationTask {
		public float duration;
		public bool isDurationInfinite;

		public bool hasStarted;
		public bool hasFinished;
		public float startTime;

		public abstract void Start();
		public abstract void Update(float time);
		public abstract void Finish();
	}

	public abstract class AnimationTask <T> : AnimationTask {
		public readonly T target;
		public float durationRecip;
		public int esType;

		protected AnimationTask(T target, float duration, int esType) {
			this.target = target;
			this.duration = duration;
			durationRecip = 1f / duration;
			this.esType = esType;
		}

		public override void Update(float time) {
			Apply(Es.Calc(esType, time * durationRecip));

			if (time >= duration) {
				hasFinished = true;
				Finish();
			}
		}

		public abstract void Apply(float t);
	}
}
