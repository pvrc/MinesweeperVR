//Creates a 2D board with bombs and hint numbers

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardScript : MonoBehaviour {
    public static BoardScript bs;
	public int width, height, numBombs, dist;
	public GameObject[,] boardArray;
    public GameObject Bomb, HintNumber; //prefabs
    public int[,] numberBoardArray;

    // Use this for initialization
    void Start() {
        bs = this;
        numberBoardArray = new int[width, height];
        int posX, posY;
		for (int i = 0; i < numBombs; i++) {
            posX = Random.Range(0, width - 1);
            posY = Random.Range(0, height - 1);
            if (numberBoardArray[posX, posY] >= 0) {
                i--;
                continue;
            } else {
                numberBoardArray[posX, posY] = 10;
                IncrementNeighbours(posX, posY, numberBoardArray);
            }
        }

        //converts int board to GameObject s
        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (numberBoardArray[x, y] >= 10) {
                    //boardArray[x, y] = Instantiate(Bomb); 
                    Vector3 pos = new Vector3(x * dist, 0, y * dist);
                    GameObject.Instantiate(Bomb, pos, Quaternion.identity, transform);
                    //TODO: transform these to the correct locations based off location in array

                } else if (numberBoardArray[x, y] >= 0) {
                    boardArray[x, y] = GameObject.Instantiate(HintNumber);
                    boardArray[x, y].GetComponent<HintNumberScript>().number = numberBoardArray[x, y];
                } 
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    private void IncrementNeighbours(int x, int y, int[,] tempBoardArray) { //copied and edited from jarett lee's TileScript.cs
        int[] dx = new int[] { -1, -1, 0, 1, 1, 1, 0, -1 };
        int[] dy = new int[] { 0, -1, -1, -1, 0, 1, 1, 1 };

        for (int i = 0; i < 8; i++) {
            int xx = x + dx[i];
            int yy = y + dy[i];
            if (xx >= 0 && xx < width && yy >= 0 && yy < height) {
                tempBoardArray[xx, yy] += 1;
            }
        }
    }

    public List<GameObject> GetNeighbours(int x, int y)
    {
        int[] dx = new int[] { -1, -1, 0, 1, 1, 1, 0, -1 };
        int[] dy = new int[] { 0, -1, -1, -1, 0, 1, 1, 1 };

        List<GameObject> neighbours = new List<GameObject>();

        for (int i = 0; i < 8; i++)
        {
            int xx = x + dx[i];
            int yy = y + dy[i];
            if (xx >= 0 && xx < width && yy >= 0 && yy < height)
            {
                neighbours.Add(boardArray[yy, xx]);
            }
        }

        return neighbours;
    }

    public void OpenNeighbors(int xcor, int ycor)
    {
        List<GameObject> neighbours = GetNeighbours(xcor, ycor);

        foreach (GameObject tile in neighbours)
        {
            TileScript tileScript = tile.GetComponent<TileScript>();
            if (tileScript != null && !tileScript.open)
            {
                tileScript.Open();
            }
        }
    }
}
