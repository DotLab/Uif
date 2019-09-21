using System.Collections.Generic;
using UnityEngine;

namespace Uif.Binding {
	public class TwoWayBindable : MonoBehaviour {
		readonly Dictionary<string, MemberBinding> bindingDict = new Dictionary<string, MemberBinding>();

		public void AddBinding(string name, MemberBinding binding) {
			bindingDict[name] = binding;
		}

		public void BackPropagateValue(string name, object value) {
			MemberBinding binding;
			if (bindingDict.TryGetValue(name, out binding)) {
				binding.SetSelfValue(value);
			}
		}
	}
}

