using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

namespace GameController {
	public class BaseBoard : NetworkBehaviour {
		protected GameObject localPlayer;
		protected string boardInstruction = "";

		void Awake() {}

		public virtual void InitBoard(int playersCount) {
			InitPosition();
		}

		public override void OnStartClient() {
			localPlayer = PlayerController.localPlayer;
			InitClientBoard();
			InitPosition();
			StartCoroutine(StartBoardGame());
		}

		public virtual void InitClientBoard() {
		
		}

		public virtual void SetUserBoardResult(PlayerBoardResult playerBoardResult)  {
			
		}

		public virtual string GetBoardInstructionText() {
			return boardInstruction;
		}

		protected virtual IEnumerator StartBoardGame() {
			yield break;
		}

		protected GameObject GetBoardMain() {
			return transform.Find("BoardMain").gameObject;
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

