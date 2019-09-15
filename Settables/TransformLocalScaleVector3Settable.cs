using Uif.Tasks;
using UnityEngine;

namespace Uif.Settables {
	public sealed class TransformLocalScaleVector3Settable : Settable<Transform, Vector3> {
		public TransformLocalScaleVector3Settable(Transform target) : base(target) {}

		public override void Set(Vector3 value) {
			target.localScale = value;
		}

		public override Vector3 Get() {
			return target.localScale;
		}
	}

	public static partial class AnimationSequenceExtension {
		public static TransformLocalScaleVector3Settable GetLocalScaleVector3Settable(this Transform target) {
			return new TransformLocalScaleVector3Settable(target);
		}

		public static AnimationSequence ScaleFrom(this AnimationSequence seq, Transform target, Vector3 a, float duration, int esType) {
			seq.Append(new Vector3SettableTask(new TransformLocalScaleVector3Settable(target), duration, esType){start = a, setEndFromTarget = true});
			return seq;
		}

		public static AnimationSequence ScaleTo(this AnimationSequence seq, Transform target, Vector3 a, float duration, int esType) {
			seq.Append(new Vector3SettableTask(new TransformLocalScaleVector3Settable(target), duration, esType){end = a, setStartFromTarget = true});
			return seq;
		}

		public static AnimationSequence ScaleFromTo(this AnimationSequence seq, Transform target, Vector3 a, Vector3 b, float duration, int esType) {
			seq.Append(new Vector3SettableTask(new TransformLocalScaleVector3Settable(target), duration, esType){start = a, end = b});
			return seq;
		}
	}
}

