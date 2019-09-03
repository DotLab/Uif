using UnityEngine.UI;

namespace Uif {
	public sealed class EmptyGraphic : Graphic {
		protected override void OnPopulateMesh (VertexHelper vh) {
			vh.Clear();
		}
	}
}