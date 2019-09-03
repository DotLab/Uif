namespace Uif.Tasks {
	public abstract class InstantTask : AnimationTask {
		public override void Start() {
			hasFinished = true;
		}

		public override void Update(float time) {}
		public override void Finish() {}
	}
}

