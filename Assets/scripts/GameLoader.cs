using UnityEngine;
using UnityEngine.Networking;

namespace GameController {
	public class GameLoader : NetworkBehaviour {
		public GameObject gameManager;

		public override void OnStartServer() {
			if (GameManager.instance == null) {
				Instantiate(gameManager);
			}
		}
	}
}
