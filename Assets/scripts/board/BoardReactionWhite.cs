using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using GameInfra;

namespace GameController {
	public class BoardReactionWhite : BaseReactionBoard {
		private int maxTries = 50;
		private float timerOffset = 1.0F;
		private int maxTime = 5;

		private SyncListFloat timers = new SyncListFloat();
		private int currentTimerIndex;

		private SyncListPlayerBoardResult _boardResultsList = new SyncListPlayerBoardResult();
		protected override SyncListPlayerBoardResult boardResultsList {
			get {
				return _boardResultsList;
			}
		}

		public override void InitBoard(int playersCount) {
			base.InitBoard(playersCount);
			for (int x = 0; x < maxTries; ++x) {
				timers.Add((Random.value * maxTime) + timerOffset);
			}
			boardInstruction = "Tap on white"; // todo: l10n
		}

		public override void InitClientBoard() {
			_boardResultsList.Callback = OnBoardPlayerDataChanged;
		}

		// todo: separate to board logic component
		protected override IEnumerator StartBoardGame() {
			Debug.Log("StartBoardGame!!!");

			float nextTimer = timers[currentTimerIndex++];
			do {
				yield return SetNextWhite(nextTimer);
				nextTimer = currentTimerIndex < timers.Count ? timers[currentTimerIndex++] : 0;
			} while(!IsBoardHasReactTime() && nextTimer > 0);

			Debug.Log("EndBoardGame!!!" + localReactTime);
		}

		private IEnumerator SetNextWhite(float nextTimer) {
			Debug.Log("setNextWhite:" + nextTimer);
			yield return breakableWait.WaitForSecondsOrBreak(nextTimer);
			if (IsBoardHasReactTime())
				yield break;
			
			localValidReactInitTime = Time.time;
			GameObject boardMain = GetBoardMain();
			Color originalColor = boardMain.GetComponent<Image>().color;
			boardMain.GetComponent<Image>().color = new Color(255, 255, 255);
			Debug.Log("setNextWhite2:" + nextTimer);
			yield return breakableWait.WaitForSecondsOrBreak(0.5F);
			boardMain.GetComponent<Image>().color = originalColor;
			localValidReactInitTime = 0.0F;
			Debug.Log("setNextWhite3:" + nextTimer);
		}

		public void OnBoardPlayerDataChanged(SyncListPlayerBoardResult.Operation op, int index) {
			Debug.Log("OnBoardPlayerDataChanged, isServer:" + isServer + " index: " + index + " op:" + op);
		}
	}
}