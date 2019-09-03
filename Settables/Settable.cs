namespace Uif.Settables {
	public abstract class Settable <TargetType, ValueType> : ISettable<ValueType> {
		protected TargetType target;

		protected Settable(TargetType target) {
			this.target = target;
		}

		public abstract void Set(ValueType value);
		public abstract ValueType Get();
	}
}

