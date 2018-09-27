using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour {
	public GameObject[][] boardArray;

	public int getWidth() {
		if (boardArray != null && boardArray[0] != null)
			return boardArray[0].length;
	}

	public int getHeight() {
		if (boardArray != null)
			return boardArray.length;
	}
}
