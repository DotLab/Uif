using Uif.Tasks;
using UnityEngine.UI;

namespace Uif.Settables {
	public sealed class GraphicAlphaFloatSettable : Settable<Graphic, float> {
		public GraphicAlphaFloatSettable(Graphic target) : base(target) {}

		public override void Set(float value) {
			var c = target.color;
			c.a = value;
			target.color = c;
		}

		public override float Get() {
			return target.color.a;
		}
	}

	public static partial class AnimationSequenceExtension {
		public static GraphicAlphaFloatSettable GetAlphaFloatSettable(this Graphic target) {
			return new GraphicAlphaFloatSettable(target);
		}

		public static AnimationSequence FadeFrom(this AnimationSequence seq, Graphic target, float a, float duration, int esType) {
			seq.Append(new FloatSettableTask(new GraphicAlphaFloatSettable(target), duration, esType){start = a, setEndFromTarget = true});
			return seq;
		}

		public static AnimationSequence FadeTo(this AnimationSequence seq, Graphic target, float a, float duration, int esType) {
			seq.Append(new FloatSettableTask(new GraphicAlphaFloatSettable(target), duration, esType){end = a, setStartFromTarget = true});
			return seq;
		}

		public static AnimationSequence FadeFromTo(this AnimationSequence seq, Graphic target, float a, float b, float duration, int esType) {
			seq.Append(new FloatSettableTask(new GraphicAlphaFloatSettable(target), duration, esType){start = a, end = b});
			return seq;
		}

		public static AnimationSequence FadeIn(this AnimationSequence seq, Graphic target, float duration, int esType) {
			seq.Append(new FloatSettableTask(new GraphicAlphaFloatSettable(target), duration, esType){end = 1, setStartFromTarget = true});
			return seq;
		}

		public static AnimationSequence FadeOut(this AnimationSequence seq, Graphic target, float duration, int esType) {
			seq.Append(new FloatSettableTask(new GraphicAlphaFloatSettable(target), duration, esType){end = 0, setStartFromTarget = true});
			return seq;
		}

		public static AnimationSequence FadeInFromZero(this AnimationSequence seq, Graphic target, float duration, int esType) {
			seq.Append(new FloatSettableTask(new GraphicAlphaFloatSettable(target), duration, esType){start = 0, end = 1});
			return seq;
		}

		public static AnimationSequence FadeOutFromOne(this AnimationSequence seq, Graphic target, float duration, int esType) {
			seq.Append(new FloatSettableTask(new GraphicAlphaFloatSettable(target), duration, esType){start = 1, end = 0});
			return seq;
		}
	}
}

