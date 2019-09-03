using Uif.Tasks;
using UnityEngine;

namespace Uif.Settables {
	public sealed class CanvasGroupAlphaFloatSettable : Settable<CanvasGroup, float> {
		public CanvasGroupAlphaFloatSettable(CanvasGroup target) : base(target) {}

		public override void Set(float value) {
			target.alpha = value;
		}

		public override float Get() {
			return target.alpha;
		}
	}

	public static partial class AnimationSequenceExtension {
		public static AnimationSequence FlashFrom(this AnimationSequence seq, CanvasGroup target, float a, float duration, int esType) {
			seq.Append(new FloatSettableTask(new CanvasGroupAlphaFloatSettable(target), duration, esType){start = a, setEndFromTarget = true});
			return seq;
		}

		public static AnimationSequence FadeTo(this AnimationSequence seq, CanvasGroup target, float a, float duration, int esType) {
			seq.Append(new FloatSettableTask(new CanvasGroupAlphaFloatSettable(target), duration, esType){end = a, setStartFromTarget = true});
			return seq;
		}

		public static AnimationSequence FadeIn(this AnimationSequence seq, CanvasGroup target, float duration, int esType) {
			seq.Append(new FloatSettableTask(new CanvasGroupAlphaFloatSettable(target), duration, esType){end = 1, setStartFromTarget = true});
			return seq;
		}

		public static AnimationSequence FadeOut(this AnimationSequence seq, CanvasGroup target, float duration, int esType) {
			seq.Append(new FloatSettableTask(new CanvasGroupAlphaFloatSettable(target), duration, esType){end = 0, setStartFromTarget = true});
			return seq;
		}

		public static AnimationSequence FadeInFromZero(this AnimationSequence seq, CanvasGroup target, float duration, int esType) {
			seq.Append(new FloatSettableTask(new CanvasGroupAlphaFloatSettable(target), duration, esType){start = 0, end = 1});
			return seq;
		}

		public static AnimationSequence FadeOutFromOne(this AnimationSequence seq, CanvasGroup target, float duration, int esType) {
			seq.Append(new FloatSettableTask(new CanvasGroupAlphaFloatSettable(target), duration, esType){start = 1, end = 0});
			return seq;
		}
	}
}

