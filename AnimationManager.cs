using System.Collections.Generic;
using UnityEngine;

namespace Uif {
	public sealed class AnimationManager : MonoBehaviour {
		public static AnimationManager instance;

		public event System.Action<float, float> AnimationUpdate;

		readonly LinkedList<AnimationSequence> sequenceList = new LinkedList<AnimationSequence>();

		void Awake() {
			if (instance == null) {
				instance = this;
				DontDestroyOnLoad(gameObject);
			} else {
				Destroy(gameObject);
			}
		}

		public int GetSequenceCount() {
			return sequenceList.Count;
		}

		public AnimationSequence New(object handle = null) {
			if (handle != null) {
				for (var it = sequenceList.First; it != null;) {
					if (it.Value.handle == handle) {
						var next = it.Next;
						sequenceList.Remove(it);
						it = next;
					} else {
						it = it.Next;
					}
				}
			}
			var sequence = new AnimationSequence(handle);
			sequenceList.AddLast(sequence);
			return sequence;
		}

		void Update() {
			float time = Time.time;
			float deltaTime = Time.deltaTime;

			for (var it = sequenceList.First; it != null;) {
				var sequence = it.Value;

				try {
					if (!sequence.hasStarted) {
						sequence.hasStarted = true;
						sequence.startTime = time;
						sequence.Start();
					}

					sequence.Update(time - sequence.startTime);

					if (sequence.hasFinished) {
						var next = it.Next;
						sequenceList.Remove(it);
						it = next;
					} else {
						it = it.Next;
					}
				} catch(System.Exception e) {
					Debug.LogError("Animation Sequence throws\n" + e);

					var next = it.Next;
					sequenceList.Remove(it);
					it = next;
				}
			}

			if (AnimationUpdate != null) AnimationUpdate(Time.time, Time.deltaTime);
		}
	}
}