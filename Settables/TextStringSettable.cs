using Uif.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Uif.Settables {
	public sealed class TextStringSettable : Settable<Text, string> {
		public TextStringSettable(Text target) : base(target) {}

		public override void Set(string value) {
			target.text = value;
		}

		public override string Get() {
			return target.text;
		}
	}

	public static partial class AnimationSequenceExtension {
		public static TextStringSettable GetStringSettable(this Text target) {
			return new TextStringSettable(target);
		}

		public static AnimationSequence EditTo(this AnimationSequence seq, Text target, string a, float duration, int esType) {
			seq.Append(new StringSettableTask(new TextStringSettable(target), duration, esType){end = a, setStartFromTarget = true});
			return seq;
		}
	}
}

