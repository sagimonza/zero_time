using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace GameController {
	public class PlayerStatus : NetworkBehaviour {
		[SyncVar]
		private int score = 0;

		[SyncVar]
		private int winsStreak = 0;

		[SyncVar]
		private string facebookId = "";

		void Awake() {}

		public void InitMultiplayer(string facebookId) {
			this.facebookId = facebookId;
		}

		// todo: make async to fetch player's profile picture and name (yield...)
		public IEnumerable InitPlayerStatus() {
			yield return StartCoroutine(InitPlayerProfile());
			transform.Find("PlayerName").GetComponent<Text>().text = "Player " + Network.player.ToString(); // todo: l10n
			InitPosition();
		}

		public override void OnStartClient() {
			if (facebookId != "")
				InitPlayerStatus();
			else
				InitClientPlayerStatus();
		}

		public void InitClientPlayerStatus() {
			
		}

		private void InitPosition() {
			transform.parent = GameObject.Find("Game").transform;
			RectTransform boardRectTrans = GetComponent<RectTransform>();
			boardRectTrans.sizeDelta = Vector2.zero;
			boardRectTrans.offsetMax = Vector2.zero;
			boardRectTrans.offsetMin = Vector2.zero;
		}

		private IEnumerable InitPlayerProfile() {
			if (facebookId != "") {
				// todo: Facebook integration...
				transform.Find("PlayerName").GetComponent<Text>().text = "Player " + Network.player.ToString(); // todo: l10n
				// todo: transform.Find("PlayerPhoto")...
				yield return null;
			} else {
				transform.Find("PlayerName").GetComponent<Text>().text = "Player " + Network.player.ToString(); // todo: l10n
				yield return null;
			}
		}
	}
}

