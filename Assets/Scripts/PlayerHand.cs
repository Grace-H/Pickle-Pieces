using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlayerHand : MonoBehaviour {

	private GameObject[] hand;
	private GameObject[,] cells;
	private BoardChecker boardChecker;
	private TileDistributor tileDistributor;
	
	private int[,] xyz = new int[36, 3]{
		{-68, 40, 0},
		{-60, 40, 0},
		{-52, 40, 0},
		{-68, 32, 0},
		{-60, 32, 0},
		{-52, 32, 0},
		{-68, 24, 0},
		{-60, 24, 0},
		{-52, 24, 0},
		{-68, 16, 0},
		{-60, 16, 0},
		{-52, 16, 0},
		{-68, 8, 0},
		{-60, 8, 0},
		{-52, 8, 0},
		{-68, 0, 0},
		{-60, 0, 0},
		{-52, 0, 0},
		{-68, -8, 0},
		{-60, -8, 0},
		{-52, -8, 0},
		{-68, -16, 0},
		{-60, -16, 0},
		{-52, -16, 0},
		{-68, -24, 0},
		{-60, -24, 0},
		{-52, -24, 0},
		{-68, -27, 0},
		{-60, -27, 0},
		{-52, -27, 0},
		{-68, -30, 0},
		{-60, -30, 0},
		{-52, -30, 0},
		{-68, -33, 0},
		{-60, -33, 0},
		{-52, -33, 0},
	};
	
	//modal window
	private ModalPanel modalPanel;
	private UnityAction okayErrorAction;
	private UnityAction dealOneTileAction;
	
	void Start () {
		hand = new GameObject[21];
		tileDistributor = TileDistributor.Instance();
		
		modalPanel = ModalPanel.Instance();
		okayErrorAction = new UnityAction(ModalPanelErrorOkayAction);
		dealOneTileAction = new UnityAction(TakeOneTile);
		
		for(int i = 0; i < hand.Length; i++){
			hand[i] = tileDistributor.DealTile();
		}

		boardChecker = gameObject.GetComponent(typeof(BoardChecker)) as BoardChecker;
		PlaceHand();
		GetCells();
	}
	
	/*Loads parent cells into array "cells"
	called from Start()
	*/
	void GetCells(){
		cells = new GameObject[16,25];
		GameObject[] rows = GameObject.FindGameObjectsWithTag("Row");
		rows = SortArray(rows);
		for(int i = 0; i < rows.Length; i++){
			Debug.Log("Childcount: " + rows[i].transform.childCount);
			GameObject[] children = new GameObject[rows[i].transform.childCount];
			for(int j = 0; j < children.Length; j++){
				children[j] = rows[i].transform.GetChild(j).gameObject;
			}
			Debug.Log(children.Length);
			children = SortArray(children);
			Print1DArray(children);
			for(int j = 0; j < children.Length; j++){
				cells[15 - i,j] = children[j];
			}
		}
	}
	
	/*uses QuickSort to sort array of game objects by their order in the heirarchy
	This is a modified version of the method from Sort.java, written by Grace Hunter
	*/
	private GameObject[] SortArray(GameObject[] narray) {
		
		//if longer than one number
		if (narray.Length > 1) {
			GameObject pivot = narray[narray.Length - 1];
			int wall = 0; //where the divider is in the array
			//main loop which moves all objects with indeces greater than pivot to left and all numbers less to right
			for (int i = 0; i < narray.Length; i++) { //for each number in the string...
				if (narray[i].transform.GetSiblingIndex() <= pivot.transform.GetSiblingIndex()) { //if the gameobject index is less than or equal to the pivot,
					//swap it with the number next to the wall
					GameObject original = narray[i];
					narray[i] = narray[wall];
					narray[wall] = original;
					wall++; //move the wall over one
				}
			}
			
			//sort half before wall
			GameObject[] firstHalf = new GameObject[wall - 1];
			System.Array.Copy(narray, 0, firstHalf, 0, wall - 1);
			firstHalf = SortArray(firstHalf);
			
			//make firstHalf match the first half of numbers
			for (int i = 0; i < firstHalf.Length; i++) {
				narray[i] = firstHalf[i];
			}
			
			//sort half after wall
			GameObject[] secondHalf = new GameObject[narray.Length - wall];
			System.Array.Copy(narray, wall, secondHalf, 0, narray.Length - wall);
			secondHalf = SortArray(secondHalf);
			//make secondHalf match half after wall in numbers
			for (int i = 0; i < secondHalf.Length; i++) {
				narray[i + wall] = secondHalf[i];
			}
		}
		return narray;
	}
	
	/*used for checking 'GetCells()' function, prints o for occupied cell, i for unoccupied"
	*/
	void PrintCells(){
		string output = "";
		for(int i = 0; i < 16; i++){
			for(int j = 0; j < 25; j++){
				if(cells[i,j] != null){
					output += 'o';
				}
				else{
					output += "i";
				}
			}
			output += "\n";
		}
		Debug.Log(output);
	}
	
	/*Prints letters in player's hand to console*/
	void PrintHand(){
		string output = "PlayerHand: ";
		for(int i = 0; i < hand.Length; i++){
			LetterValue letter = hand[i].GetComponent(typeof(LetterValue)) as LetterValue;
			if(letter != null){
				output += letter.GetLetter();
			}
			else{
				output += ',';
			}
		}
		Debug.Log(output);
	}
	
	/*places tiles in locations set in coordinates array*/
	void PlaceHand(){
		for(int i = 0; i < hand.Length; i++){
			//hand[i].Scale()
			hand[i].transform.position = new Vector3(xyz[i,0], xyz[i,1], xyz[i,2]);
			Tile tile = hand[i].GetComponent(typeof(Tile)) as Tile;
			tile.SetStartPosition(new Vector2(xyz[i,0], xyz[i,1]));
		}
	}
	
	//not sure what this does
	public void LoadTileValues(){
		for(int i = 0; i < hand.Length; i++){
			Vector3 position = hand[i].transform.position;
			//Debug.Log(position);
		}
	}
	
	/*Checks board that player is using*/
	public void CheckBoard(){
		char[,] boardLetters = new char[16,25];
		int totalLetters = 0;
		
		//ask each cell if it has a child, if so get the letter
		for(int i = 0; i < 16; i++){
			for(int j = 0; j < 25; j++){
				//Debug.Log("Index: " + cells[i,j].transform.GetSiblingIndex());
				//if the cell has a child
				if(cells[i,j].transform.childCount > 0){
					GameObject child = cells[i,j].transform.GetChild(0).gameObject;
					//get letter
					LetterValue letterObj = child.GetComponent(typeof(LetterValue)) as LetterValue;
					if(letterObj != null){
						boardLetters[i,j] = letterObj.GetLetter();
						totalLetters++;
					}
					else{
						boardLetters[i,j] = ' ';
					}
				}
				else{
					boardLetters[i,j] = ' ';
				}
			}
		}
		
		//if not all letters were played
		if(totalLetters < hand.Length){
			Debug.Log("Not all tiles were played.");
			modalPanel.Choice("You must play all tiles.", okayErrorAction);
		}
		else{
			//check board
			int error = boardChecker.CheckBoard(boardLetters, 16, 25);
			Debug.Log("BoardChecker returned: " + error);
			//if board is all good
			if(error == 0){
				modalPanel.Choice("Good job! Deal each player another tile?", dealOneTileAction);
			}
			//disconnected tile
			else if(error == 1){
				modalPanel.Choice("It looks like you have a disconnected word!", okayErrorAction);
			}
			//wrong word
			else if(error == 2){
				modalPanel.Choice("Oops...you misspelled a word.", okayErrorAction);
			}
		}
		Print2DArray(boardLetters);
	}
	
	/*called when modal panel "okay" clicked for user errors on board*/
	void ModalPanelErrorOkayAction(){
		Debug.Log("Okay");
	}
	
	/*prints out 2D board to console*/
	void Print2DArray(char[,] board){
		string output = "BOARD: \n";
		Debug.Log("PlayerHand.cs: board length = " + board.Length);
		for(int i = 0; i < 16; i ++){
			for(int j = 0; j < 25; j ++){
				if( board[i, j] == ' '){
					output += " ,";
				}
				else{					
					output += board[i, j];
					output += ",";
				}
			}
			output += "\n";
		}
		Debug.Log(output);
	}
	
	//prints child indexes of long array of GameObject
	void Print1DArray(GameObject[] narray){
		string output = "Here is the array this is a long line of text: ";
		for(int i = 0; i < narray.Length; i++){
			output += narray[i].transform.GetSiblingIndex();
			output += ",";
		}
		Debug.Log(output);
	}
	
	public void TakeOneTile(){
		Debug.Log("taking one tile");
		if(hand.Length < 36){
			GameObject[] nhand = new GameObject[hand.Length + 1];
			for(int i = 0; i < hand.Length; i++){
				nhand[i] = hand[i];
			}
			nhand[nhand.Length - 1] = tileDistributor.DealTile();
			nhand[nhand.Length - 1].transform.position = new Vector3(xyz[nhand.Length - 1,0], xyz[nhand.Length - 1,1], xyz[nhand.Length - 1,2]);
			Tile tile = nhand[nhand.Length - 1].GetComponent(typeof(Tile)) as Tile;
			tile.SetStartPosition(new Vector2(xyz[nhand.Length - 1,0], xyz[nhand.Length - 1,1]));
			
			//replace previous hand with new hand
			hand = nhand;
		}
		else{
			Debug.LogError("Hand is too large. Cannot draw tile");
		}
	}
	
	public void Dump(){
		Debug.Log("Dumping");
	}
	
	// Update is called once per frame
	void Update () {
	}
}
