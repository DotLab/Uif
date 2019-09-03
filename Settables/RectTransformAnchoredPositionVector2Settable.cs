using Uif.Tasks;
using UnityEngine;

namespace Uif.Settables {
	public sealed class RectTransformAnchoredPositionVector2Settable : Settable<RectTransform, Vector2> {
		public RectTransformAnchoredPositionVector2Settable(RectTransform target) : base(target) {}

		public override void Set(Vector2 value) {
			target.anchoredPosition = value;
		}

		public override Vector2 Get() {
			return target.anchoredPosition;
		}
	}

	public static partial class AnimationSequenceExtension {
		public static AnimationSequence MoveFrom(this AnimationSequence seq, RectTransform target, Vector2 a, float duration, int esType) {
			seq.Append(new Vector2SettableTask(new RectTransformAnchoredPositionVector2Settable(target), duration, esType){start = a, setEndFromTarget = true});
			return seq;
		}

		public static AnimationSequence MoveTo(this AnimationSequence seq, RectTransform target, Vector2 a, float duration, int esType) {
			seq.Append(new Vector2SettableTask(new RectTransformAnchoredPositionVector2Settable(target), duration, esType){end = a, setStartFromTarget = true});
			return seq;
		}

		public static AnimationSequence MoveToFrom(this AnimationSequence seq, RectTransform target, Vector2 a, Vector2 b, float duration, int esType) {
			seq.Append(new Vector2SettableTask(new RectTransformAnchoredPositionVector2Settable(target), duration, esType){start = a, end = b});
			return seq;
		}

		public static AnimationSequence ShiftTo(this AnimationSequence seq, RectTransform target, Vector2 a, float duration, int esType) {
			seq.Append(new Vector2SettableTask(new RectTransformAnchoredPositionVector2Settable(target), duration, esType){delta = a, isRelative = true});
			return seq;
		}
	}
}
