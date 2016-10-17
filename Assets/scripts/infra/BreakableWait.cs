using System.Collections;
using UnityEngine;

namespace GameInfra {
	public class BreakableWait {
		private float __gWaitSystem;

		public void ExitWaitForSecondsOrBreak() {
			__gWaitSystem = 0.0F;
		}

		public IEnumerator WaitForSecondsOrBreak(float seconds) {
			__gWaitSystem = seconds;
			while ( __gWaitSystem > 0.0F) {
				__gWaitSystem -= Time.deltaTime;
				yield return null;
			}
		}
	}
}

