namespace Uif.Settables {
	public interface ISettable<T> {
		void Set(T value);
		T Get();
	}
}

