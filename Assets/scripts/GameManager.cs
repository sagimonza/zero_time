using System.Collections.Generic;
using UnityEngine;

namespace GameController {
	public class GameManager : MonoBehaviour {
		public static GameManager instance = null;
		public static int winnerMaxScore;
		public GameObject boardManagerPrefab;
		private GameObject boardManager;

		void Awake() {
			if (instance == null)
				instance = this;
			else if (instance != this)
				Destroy(gameObject);    

			DontDestroyOnLoad(gameObject);

			boardManager = Instantiate(boardManagerPrefab);

			InitGame();
		}

		void InitGame() {
			winnerMaxScore = 10; // todo: get dyanmically

			BoardManager boardManagerComp = boardManager.GetComponent<BoardManager>();
			List<string> boardNames = boardManagerComp.GetBoardNames();
			boardManagerComp.CreateBoard(boardNames[0]);
		}
	}
}
