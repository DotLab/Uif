using Uif.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Uif.Settables {
	public sealed class GraphicColorSettable : Settable<Graphic, Color> {
		public GraphicColorSettable(Graphic target) : base(target) {}

		public override void Set(Color value) {
			target.color = value;
		}

		public override Color Get() {
			return target.color;
		}
	}

	public static partial class AnimationSequenceExtension {
		public static GraphicColorSettable GetColorSettable(this Graphic target) {
			return new GraphicColorSettable(target);
		}

		public static AnimationSequence FadeFrom(this AnimationSequence seq, Graphic target, Color a, float duration, int esType) {
			seq.Append(new ColorSettableTask(new GraphicColorSettable(target), duration, esType){start = a, setEndFromTarget = true});
			return seq;
		}

		public static AnimationSequence FadeTo(this AnimationSequence seq, Graphic target, Color a, float duration, int esType) {
			seq.Append(new ColorSettableTask(new GraphicColorSettable(target), duration, esType){end = a, setStartFromTarget = true});
			return seq;
		}

		public static AnimationSequence FadeFromTo(this AnimationSequence seq, Graphic target, Color a, Color b, float duration, int esType) {
			seq.Append(new ColorSettableTask(new GraphicColorSettable(target), duration, esType){start = a, end = b});
			return seq;
		}
	}
}

