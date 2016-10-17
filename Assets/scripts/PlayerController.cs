using UnityEngine;
using UnityEngine.Networking;

namespace GameController {
	public class PlayerController : NetworkBehaviour {
		public static GameObject localPlayer;

		public void OnBoardResult(PlayerBoardResult playerBoardResult) {
			if (playerBoardResult.playerID != Network.player.ToString())
				return;

			CmdOnBoardResult(playerBoardResult);
		}

		[Command]
		public void CmdOnBoardResult(PlayerBoardResult playerBoardResult) {
			BoardManager.GetServerBoard().GetComponent<BaseBoard>().SetUserBoardResult(playerBoardResult);
		}

		public override void OnStartLocalPlayer() {
			PlayerController.localPlayer = gameObject;
		}

		public override void OnStartServer() {
			
		}

		void Awake() {
			
		}
	}
}

