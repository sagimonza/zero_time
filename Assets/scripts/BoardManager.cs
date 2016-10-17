using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace GameController {
	public class BoardManager : MonoBehaviour {
		public List<GameObject> boardPrefabs;
		public GameObject instructionPrefab;
		private Transform boardHolder;

		private static GameObject serverBoard;

		public List<string> GetBoardNames() {
			List<string> boardNames = new List<string>();
			boardPrefabs.ForEach(delegate(GameObject board) {
				boardNames.Add(board.name);
			});
			return boardNames;
		}

		public void CreateBoard(string boardName) {
			GameObject boardPrefab = boardPrefabs.Find(board => board.name == boardName);
			if (!boardPrefab)
				return;
			
			BoardManager.serverBoard = (GameObject) Instantiate(boardPrefab, GameObject.Find("Game").transform);
			BoardManager.serverBoard.GetComponent<BaseBoard>().InitBoard(2);

			GameObject boardInstruction = (GameObject) Instantiate(instructionPrefab, GameObject.Find("Game").transform);
			boardInstruction.GetComponent<BoardInstruction>().InitInstruction(serverBoard.GetComponent<BaseBoard>().GetBoardInstructionText());

			NetworkServer.Spawn(boardInstruction);
			NetworkServer.Spawn(BoardManager.serverBoard);
		}

		public static GameObject GetServerBoard() {
			return BoardManager.serverBoard;
		}

		void Update () {

		}
	}
}
