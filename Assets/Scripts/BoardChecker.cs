/*Checks board for invalid words
Date: 25 October 2019
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardChecker : MonoBehaviour {

	private List<string> validWords;
	
	// Use this for initialization
	void Start () {
		ReadWords();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	void ReadWords(){
		validWords = new List<string>();
		System.IO.StreamReader fileReader = new System.IO.StreamReader("Assets\\wordlist.txt");
		string line = fileReader.ReadLine();
		while(line != null){
			validWords.Add(line);
			line = fileReader.ReadLine();
		}
		fileReader.Close();
	}
	
	/*prints out 2D board of chars, needs board height and width*/
	void Print(char[,] board, int boardHeight, int boardWidth){
		string output = "BOARD: \n";
		Debug.Log("BoardChecker.cs: board length = " + board.Length);
		for(int i = 0; i < boardWidth; i ++){
			for(int j = 0; j < boardHeight; j ++){
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
	
	/*check the board for invalid words, diconnected letters, isolated words
	returns: 0 - good; 1 - disconnected word; 2 - invalid word*/
	public int CheckBoard(char[,] board, int boardHeight, int boardWidth){
		//i is column, j is row
		for(int i = 0; i < boardWidth; i++){
			for(int j = 0; j < boardHeight; j++){
				
				//check if it is a letter
				if(board[j,i] != ' '){
					bool connected = CheckStrayWord(board, 16, 25, j, i);
					if(connected){
						Debug.Log(j + ", " + i + " is connected to a word");
				
						//ACROSS
						//first column
						//if it and square next to it are occupied, it is the start of a word going across
						if(i == 0){
							if(board[j, i + 1] != ' '){
								string word = LoadWordAcross(board, 16, 25, j, i);
								Debug.Log(word);	
								if(!CheckWord(word)){
									Debug.Log("Not a word!");
									return 2;
								}
							}
						}
						//not last column (last column can not start words across)
						//if it and square next to it are occupied but not square before, it is the start of a word going across
						else if(i != boardWidth - 1){
							if(board[j, i + 1] != ' ' && board[j, i - 1] == ' '){
								string word = LoadWordAcross(board, 16, 25, j, i);
								Debug.Log(word);					
								if(!CheckWord(word)){
									Debug.Log("Not a word!");
									return 2;
								}
							}
						}
						
						//DOWN
						//first row
						//if it and square below it are occupied, it is the start of a word going down
						if(j == 0){
							if(board[j + 1, i] != ' '){
								string word = LoadWordDown(board, 16, 25, j, i);
								Debug.Log(word);
								if(!CheckWord(word)){
									Debug.Log("Not a word!");
									return 2;
								}
							}
						}
						//not last row (last row can not start words across)
						//if it and square next to it are occupied but not square before, it is the start of a word going across
						else if(j != boardHeight - 1){
							if(board[j + 1, i] != ' ' && board[j - 1, i] == ' '){
								string word = LoadWordDown(board, 16, 25, j, i);
								Debug.Log(word);
								if(!CheckWord(word)){
									Debug.Log("Not a word!");
									return 2;
								}
							}
						}
					}
					
					else{
						Debug.Log("Disconnected letter alert! @: " + j + ", " + i);
						return 1;
					}
				}
			}
		}
		return 0;
	}
	
	/* starts at the index given and reads across, adding all letters of word to string
	returns string*/
	string LoadWordAcross(char[,] board, int boardHeight, int boardWidth, int row, int column){
		string word = "";
		//keep reading acorss until edge is reached or word is over
		bool endReached = false;
		while(!endReached){
			word += board[row,column];
			column++;
			//end of board
			if(column >= boardWidth){
				endReached = true;
			}
			//end of word
			else if(board[row, column] == ' '){
				endReached = true;
			}
		}
		return word;
	}
	
	/*starts at the index given and reads down, adding all letters of word to string
	returns string with word*/
	string LoadWordDown(char[,] board, int boardHeight, int boardWidth, int row, int column){
		string word = "";
		//keep reading down until bottom is reached or word is over
		bool endReached = false;
		while(!endReached){
			word += board[row,column];
			row++;
			//end of board
			if(row >= boardHeight){
				endReached = true;
			}
			//end of word
			else if(board[row, column] == ' '){
				endReached = true;
			}
		}
		return word;
	}
	
	/*checks if the letter (and possibly word) is connected to something else
	returns true if it is*/
	bool CheckStrayWord(char[,] board, int boardHeight, int boardWidth, int row, int column){
		bool connected = false;
		//check letter itself, only procede if still false
		connected = CheckCornerLetter(board, 16, 25, row, column);
		
		if(!connected){
			//backwards across: must be connected to something above or below
			int shift = 0;
			bool endofword = false; //if the end of the word in that direction has been reached
			while(!endofword && !connected){
				shift++;
				//evaluate end of word
				if(column - shift < 0){
					endofword = true;
					break;
				}
				if(board[row, column - shift] != ' '){
					if(CheckCornerLetter(board, 16, 25, row, column - shift)){
						connected = true;
					}
				}
				else{
					endofword = true;
				}
			}
			
			//forwards across: must be connected to something above or below
			shift = 0;
			endofword = false; //if the end of the word in that direction has been reached
			while(!endofword && !connected){
				shift++;
				//evaluate end of word
				if(column + shift >= boardWidth){
					endofword = true;
					break;
				}
				if(board[row, column + shift] != ' '){
					if(CheckCornerLetter(board, 16, 25, row, column + shift)){
						connected = true;
					}
				}
				else{
					endofword = true;
				}
			}
			
			//above vertical: must be connected to something L or R 
			shift = 0;
			endofword = false; //if the end of the word in that direction has been reached
			while(!endofword && !connected){
				shift++;
				//evaluate end of word
				if(row - shift < 0){
					endofword = true;
					break;
				}
				if(board[row - shift, column] != ' '){
					if(CheckCornerLetter(board, 16, 25, row - shift, column)){
						connected = true;
					}
				}
				else{
					endofword = true;
				}
			}
			
			//below vertical: must be connected to something L or R
			shift = 0;
			endofword = false; //if the end of the word in that direction has been reached
			while(!endofword && !connected){
				shift++;
				//evaluate end of word
				if(row + shift >= boardHeight){
					endofword = true;
					break;
				}
				if(board[row + shift, column] != ' '){
					if(CheckCornerLetter(board, 16, 25, row + shift, column)){
						connected = true;
					}
				}
				else{
					endofword = true;
				}
			}
		}
		return connected;
	}		
	
	/*returns true if the letter has a neighbor both vertically and horizontally*/
	bool CheckCornerLetter(char[,] board, int boardHeight, int boardWidth, int row, int column){
		bool connectedVer = false;
		bool connectedHor = false;
		//check left
		if(row != 0){
			if(board[row - 1, column] != ' '){
				connectedHor = true;
			}
		}
		//check right
		if(row != boardWidth - 1){
			if(board[row + 1, column] != ' '){
				connectedHor = true;
			}
		}
		//beck below
		if(column != 0){
			if(board[row, column - 1] != ' '){
				connectedVer = true;
			}
		}
		//check above
		if(column != boardHeight - 1){
			if(board[row, column + 1] != ' '){
				connectedVer = true;
			}
		}
		
		//check for both directions
		if(connectedVer && connectedHor){
			return true;
		}
		else{
			return false;
		}
	}
	
	/*checks to see if given word is in the dicionary
	returns true or false*/
	bool CheckWord(string word){
		for(int i = 0; i < validWords.Count; i++){
			if(validWords[i] == word){
				return true;
			}
		}
		return false;
	}
}