using System.Collections.Generic;
using UnityEngine;

namespace GameController {
	public struct PlayerBoardResult {
		public string playerID;
		public string result;

		public PlayerBoardResult(string playerID, string result) {
			this.playerID = playerID;
			this.result = result;
		}
	}
}

