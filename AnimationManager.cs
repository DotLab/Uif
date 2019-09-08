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

		public AnimationSequence New() {
			var sequence = new AnimationSequence();
			sequenceList.AddLast(sequence);
			return sequence;
		}

		void Update() {
			float time = Time.time;
			float deltaTime = Time.deltaTime;

			for (var it = sequenceList.First; it != null;) {
				var sequence = it.Value;

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
			}

			if (AnimationUpdate != null) AnimationUpdate(Time.time, Time.deltaTime);
		}
	}
}