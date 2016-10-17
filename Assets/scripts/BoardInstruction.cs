using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace GameController {
	public class BoardInstruction : NetworkBehaviour {
		[SyncVar]
		private string msg;

		void Awake() {}

		public void InitInstruction(string msg) {
			this.msg = msg;
			InitPosition();
		}

		private void InitInstructionText() {
			transform.Find("BoardInstructionText").gameObject.GetComponent<Text>().text = msg;
		}

		public override void OnStartClient() {
			InitInstructionText();
			InitPosition();
		}

		private void InitPosition() {
			transform.parent = GameObject.Find("Game").transform;
			RectTransform boardRectTrans = GetComponent<RectTransform>();
			boardRectTrans.sizeDelta = Vector2.zero;
			boardRectTrans.offsetMax = Vector2.zero;
			boardRectTrans.offsetMin = Vector2.zero;
		}
	}
}

