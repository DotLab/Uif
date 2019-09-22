using System;
using UnityEngine;
using Jsonf;

namespace Uif.Binding {
	public sealed class MemberBinding : MonoBehaviour {
		public GameObject target;
		public string targetMemberName;

		[Space]
		public MonoBehaviour targetComponent;
		public string targetTypeName;
		ReflectionContext.Member targetMember;

		[Header("Two-Way Binding")]
		public bool isTwoWay;
		public string selfMemberName;

		[Space]
		public MonoBehaviour selfComponent;
		public string selfTypeName;
		ReflectionContext.Member selfMember;

		void OnValidate() {
			targetComponent = null;
			targetTypeName = null;
			selfComponent = null;
			selfTypeName = null;

			var refCtx = new ReflectionContext();

			foreach (var c in target.GetComponents<MonoBehaviour>()) {
				var member = FindMember(refCtx, c, targetMemberName);
				if (member != null) {
					targetComponent = c;
					targetTypeName = member.type.FullName;
					targetMember = member;
				}
			}

			if (isTwoWay) {
				foreach (var c in GetComponents<MonoBehaviour>()) {
					var member = FindMember(refCtx, c, selfMemberName);
					if (member != null) {
						selfComponent = c;
						selfTypeName = member.type.FullName;
						selfMember = member;
					}
				}
			}
		}

		void Start() {
			var refCtx = new ReflectionContext();

			targetMember = FindMember(refCtx, targetComponent, targetMemberName);

			if (isTwoWay) {
				selfMember = FindMember(refCtx, selfComponent, selfMemberName);
				SetSelfValue(targetMember.Get(targetComponent));
				if (targetComponent is TwoWayBindable) {
					((TwoWayBindable)targetComponent).AddBinding(targetMemberName, this);
				}
			}
		}

		public void SetTargetValue(object value) {
			targetMember.Set(targetComponent, ChangeType(value, targetMember.type));
		}

		public void SetTargetInt(int value) {
			SetTargetValue(value);
		}

		public void SetSelfValue(object value) {
			selfMember.Set(selfComponent, ChangeType(value, selfMember.type));
		}

		static object ChangeType(object obj, Type targetType) {
			if (targetType.IsEnum) {
				if (obj is int || obj is uint ||
					obj is short || obj is ushort ||
					obj is long || obj is ulong ||
					obj is byte || obj is sbyte ||
					obj is decimal
				) {
					return Enum.ToObject(targetType, obj);
				}
			}
			return Convert.ChangeType(obj, targetType);
		}

		static ReflectionContext.Member FindMember(ReflectionContext refCtx, object component, string name) {
			var type = component.GetType();

			foreach (var m in refCtx.GetMembers(type)) {
				if (m.name == name) {
					return m;
				}
			}

			return null;
		}
	}
}

