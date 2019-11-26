using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDistributor : MonoBehaviour {
	
	public GameObject tilePrefab;
	GameObject[] tiles;
	
	//sprite names
	private SpriteRenderer spriteR;
	private Sprite[] sprites;
	
	private static TileDistributor tileDistributor;
	
	public static TileDistributor Instance(){
		if(!tileDistributor){
			tileDistributor = FindObjectOfType(typeof(TileDistributor)) as TileDistributor;
			if(!tileDistributor){
				Debug.LogError("There needs to be one active TileDistributor script on a GameObject in your scene.");
			}
		}
		return tileDistributor;
	}
	
	// Use this for initialization
	void Awake () {
		
		Debug.Log("running");
		for(int i = 0; i < 144; i++){
			Debug.Log(i);
			Instantiate(tilePrefab, new Vector3(100, 100, 0), Quaternion.identity);
		}
		
		//load sprites
		sprites = Resources.LoadAll<Sprite>("Letters");    //not working
		Debug.Log("size of sprites: " + sprites.Length);   //returns 0
		
		//add all tiles to array
		tiles = GameObject.FindGameObjectsWithTag("Tile");
		
		Debug.Log(tiles.Length);
		
		if(tiles != null){
			//A
			for(int i = 0; i < 13; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[1];
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('A');
				}
				spriteR.sortingLayerName = "Tiles";
				spriteR.sortingOrder = 10;
			}
			//B
			for(int i = 13; i < 16; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[2];
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('B');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//C 
			for(int i = 16; i < 19; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[3];
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('C');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//D  
			for(int i = 19; i < 25; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[4];
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('D');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//E  
			for(int i = 25; i < 43; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[5];
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('E');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//F 
			for(int i = 43; i < 46; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[6];
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('F');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//G 
			for(int i = 46; i < 50; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[7];
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('G');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//H 
			for(int i = 50; i < 53; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[8];
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('H');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//I  
			for(int i = 53; i < 65; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[9];
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('I');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//J 
			for(int i = 65; i < 67; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[10];
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('J');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//K
			for(int i = 67; i < 69; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[11];
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('K');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//L  
			for(int i = 69; i < 74; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[12];
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('L');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//M  
			for(int i = 74; i < 77; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[13];
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('M');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//N 
			for(int i = 77; i < 85; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[14];
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('N');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//O 
			for(int i = 85; i < 96; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[15];
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('O');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//P 
			for(int i = 96; i < 99; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[16];
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('P');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//Q  
			for(int i = 99; i < 101; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[17];
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('Q');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//R  
			for(int i = 101; i < 110; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[18];
				Debug.Log(i);
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('R');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//S  
			for(int i = 110; i < 116; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[19];
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('S');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//T  
			for(int i = 116; i < 125; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[20];
				Debug.Log(i);
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('T');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//U  
			for(int i = 125; i < 131; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[21];
				Debug.Log(i);
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('U');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//V  
			for(int i = 131; i < 134; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[22];
				Debug.Log(i);
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('V');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//W
			for(int i = 134; i < 137; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[23];
				Debug.Log(i);
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('W');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//X
			for(int i = 137; i < 139; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[24];
				Debug.Log(i);
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('X');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//Y 
			for(int i = 139; i < 142; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[25];
				Debug.Log(i);
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('Y');
				}
				spriteR.sortingLayerName = "Tiles";
			}
			//Z 
			for(int i = 142; i < 144; i++){
				spriteR = tiles[i].GetComponent<SpriteRenderer>();
				spriteR.sprite = sprites[26];
				Debug.Log(i);
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					letter.SetLetter('Z');
				}
				spriteR.sortingLayerName = "Tiles";
			}
		}
		else{
			Debug.Log("null");
		}
		PrintBag();
		
	}
	
	void Start(){
		
	}
	
	//add a tile (GameObject) back to the bag
	//returns 0 if successful
	//returns 1 if there wasn't a space in the array (an extra tile was created)
	public int AddTile(GameObject tile){
		//find an empty spot in the array
		int spot = 0;
		for(int i = 1; i < tiles.Length; i++){
			if(tiles[i] == null){
				spot = i;
				break;
			}
			//indicate there was no spot in the array (extra tile was created)
			if(i == 143){
				return 1;
			}
		}
		tiles[spot] = tile;
		return 0;
	}
	
	//returns one tile from the bag, and removes it from the bag
	public GameObject DealTile(){
		int index = Random.Range(0, tiles.Length - 1);
		while(tiles[index] == null){
			index = Random.Range(0, tiles.Length - 1);
		}
		
		GameObject tile = tiles[index];
		tiles[index] = null;
		PrintBag();
		return tile;
	}
	
	void PrintBag(){
		string output = "";
		for(int i = 0; i < tiles.Length; i++){
			if(tiles[i] != null){
				LetterValue letter = tiles[i].GetComponent(typeof(LetterValue)) as LetterValue;
				if(letter != null){
					output += letter.GetLetter();
				}
				else{
					output += ',';
				}
			}
			else{
				output += "null";
			}
		}
		Debug.Log(output);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
