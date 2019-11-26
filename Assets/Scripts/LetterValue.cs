using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterValue : MonoBehaviour {

	public static LetterValue Instance;
	
	private char letter;
	// Use this for initialization
	void Awake () {
		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public int SetLetter(char nletter){
		letter = nletter;
		return 0;
	}
	
	public char GetLetter(){
		return letter;
	}
}
