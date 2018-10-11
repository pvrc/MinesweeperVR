//Creates a 2D board with bombs and hint numbers

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour {
	public int width;
	public int height;
    public int numBombs;
    private int[][] tempBoardArray;
	public GameObject[][] boardArray;
    public GameObject Bomb; //prefab
    public GameObject HintNumber; //prefab

	// Use this for initialization
	void Start () {
        //TODO: ensure first tile hit is not mine - need some way to get the first position hit

        //creates a board using ints
        int posX, posY;
		for (int i = 0; i < numBombs; i++) {
            posX = Random.Range(0, width - 1);
            posY = Random.Range(0, height - 1);
            if (tempBoardArray[posX][posY] != 0) {
                i--;
                continue;
            } else {
                tempBoardArray[posX][posY] = 10;
                IncrementNeighbours(posX, posY);
            }
        }

        //converts int board to GameObject s
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (tempBoardArray[x][y] > 10) {
                    boardArray[x][y] = Instantiate(Bomb); 
                    //TODO: transform these to the correct locations based off location in array
                    
                } else if (tempBoardArray[x][y] > 0) {
                    boardArray[x][y] = Instantiate(HintNumber);
                    boardArray[x][y].GetComponent<HintNumberScript>().number = tempBoardArray[x][y];
                    //FIXME
                } else {
                    //an empty tile - does this need a GameObject? Can just use null checks
                    boardArray[x][y] = null;
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void IncrementNeighbours(int x, int y) { //copied and edited from jarett lee's TileScript.cs
        int[] dx = new int[] { -1, -1, 0, 1, 1, 1, 0, -1 };
        int[] dy = new int[] { 0, -1, -1, -1, 0, 1, 1, 1 };

        for (int i = 0; i < 8; i++) {
            int xx = x + dx[i];
            int yy = y + dy[i];
            if (xx >= 0 && xx < this.width && yy >= 0 && yy < this.height) {
                tempBoardArray[xx][yy] += 1;
            }
        }
    }
}
