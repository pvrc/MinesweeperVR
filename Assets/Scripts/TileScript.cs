using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour {
	public GameObject board;
	private GameObject[][] boardArray;
	private BoardScript boardScript;
	public bool mine = false;
	public bool open = false;
	public bool marked = false;
	public int bombCount = 0;
	public int xcor;
	public int ycor;

	private void Start() {
		boardScript = board.GetComponent<BoardScript>();
		boardArray = boardScript.boardArray;
	}

	// Run this after the bombs are placed
	public void SetBombCount() {
		bombCount = 0;

		List<GameObject> neighbours = GetNeighbours();
		
		foreach (GameObject tile in neighbours) {
			TileScript tileScript = tile.GetComponent<TileScript>();
			if (tileScript.mine) {
				bombCount += 1;
			}
		}
	}

	public void Open() {
		this.open = true;
		// TODO visual change tile

		if (bombCount == 0) {
			OpenNeighbors();
		}
	}

	private void OpenNeighbors() {
		List<GameObject> neighbours = GetNeighbours();

		foreach (GameObject tile in neighbours) {
			TileScript tileScript = tile.GetComponent<TileScript>();
			if (tileScript != null && !tileScript.open) {
				tileScript.Open();
			}
		}
	}

	private List<GameObject> GetNeighbours() {
		int[] dx = new int[] {-1, -1, 0, 1, 1, 1, 0, -1};
		int[] dy = new int[] {0, -1, -1, -1, 0, 1, 1, 1};

		List<GameObject> neighbours = new List<GameObject>();

		for (int i = 0; i < 8; i++) {
			int xx = this.xcor + dx[i];
			int yy = this.ycor + dy[i];
			if (xx >= 0 && xx < boardScript.width && yy >= 0 && yy < boardScript.height) {
				neighbours.Add(boardArray[yy][xx]);
			}
		}

		return neighbours;
	}
}
