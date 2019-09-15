using System.Collections.Generic;

namespace Uif {
	public sealed class AnimationSequence : AnimationTask {
		readonly List<AnimationTask> taskList = new List<AnimationTask>();

		public int repeatCount;
		public float repeatDuration;

		public float nextTaskStartTime;

		int index;
		int repeatIndex;
		float repeatTimeOffset;

		public readonly object handle;

		public AnimationSequence(object handle) {
			this.handle = handle;
		}

		public override void Start() {
			index = 0;
			repeatIndex = 0;
			repeatTimeOffset = 0;
		}

		public override void Update(float time) {
			time -= repeatTimeOffset;

			for (int i = index, end = taskList.Count; i < end; i++) {
				var task = taskList[i];
				if (task.startTime > time) break;

				if (!task.hasStarted) {
					task.hasStarted = true;
					task.Start();
				}

				task.Update(time - task.startTime);

				if (task.hasFinished) index += 1;
			}

			if (repeatCount != 0 && time >= repeatDuration && (repeatIndex < repeatCount || repeatCount < 0)) {
				repeatIndex += 1;
				index = 0;
				repeatTimeOffset += time;
				for (int i = 0, end = taskList.Count; i < end; i++) {
					var task = taskList[i];
					task.hasStarted = false;
					task.hasFinished = false;
				}
			} else if (!isDurationInfinite && time >= duration) {
				hasFinished = true;
				Finish();
			}
		}

		public override void Finish() {
			for (int i = index, end = taskList.Count; i < end; i++) {
				taskList[i].Finish();
				index += 1;
			}
		}

		public AnimationSequence Append(AnimationTask task) {
			taskList.Add(task);
			task.startTime = nextTaskStartTime;
			if (task.isDurationInfinite) isDurationInfinite = true;
			else {
				float taskFinishTime = nextTaskStartTime + task.duration;
				if (duration < taskFinishTime) duration = taskFinishTime;
			}
			return this;
		}

		public AnimationSequence Append(System.Func<AnimationSequence, AnimationSequence> gen) {
			return gen(this);
		}

		public AnimationSequence Then() {
			nextTaskStartTime = duration;
			return this;
		}

		public AnimationSequence Wait(float time) {
			nextTaskStartTime += time;
			if (nextTaskStartTime > duration) duration = nextTaskStartTime;
			return this;
		}

		public AnimationSequence Repeat(int count = -1) {
			repeatCount = count;
			repeatDuration = duration;
			if (repeatCount > 0) duration *= count;
			else isDurationInfinite = true;
			return this;
		}
	}
}
