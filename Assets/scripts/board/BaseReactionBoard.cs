using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using GameInfra;

namespace GameController
{
	public abstract class BaseReactionBoard : BaseBoard {
		public class SyncListPlayerBoardResult : SyncListStruct<PlayerBoardResult> {}
		protected abstract SyncListPlayerBoardResult boardResultsList {
			get;
		}

		protected BreakableWait breakableWait = new BreakableWait();

		protected float localValidReactInitTime;
		protected float localReactTime;

		public virtual void OnReaction() {
			if (IsReactionValid()) localReactTime = Time.time - localValidReactInitTime;
			else localReactTime = -1.0F;
			breakableWait.ExitWaitForSecondsOrBreak();

			localPlayer.GetComponent<PlayerController>().OnBoardResult(new PlayerBoardResult(Network.player.ToString(), localReactTime.ToString()));
		}

		// todo: make generic command (e.g. CmdSetUserBoardData)
		public override void SetUserBoardResult(PlayerBoardResult playerBoardResult) {
			bool playerDataFound = false;
			for (int x = 0; !playerDataFound && x < boardResultsList.Count; x++) {
				if (boardResultsList[x].playerID == playerBoardResult.playerID) {
					playerDataFound = true;
				}
			}

			if (!playerDataFound) {
				boardResultsList.Add(playerBoardResult);
			}
		}

		protected bool IsReactionValid() {
			return localValidReactInitTime > 0.0F;
		}

		protected bool IsBoardHasReactTime() {
			return localReactTime != 0.0F;
		}
	}
}

