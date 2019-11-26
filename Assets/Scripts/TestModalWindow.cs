using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TestModalWindow : MonoBehaviour {
	private ModalPanel modalPanel;
	private DisplayManager displayManager;
	
	private UnityAction myYesAction;
	private UnityAction myNoAction;
	private UnityAction myOkayAction;
	
	void Awake(){
		modalPanel = ModalPanel.Instance();
		displayManager = DisplayManager.Instance();
		
		myYesAction = new UnityAction(TestYesFunction);
		myNoAction = new UnityAction(TestNoFunction);
		myOkayAction = new UnityAction(TestOkayFunction);
	}
	
	//Send to the Modal Panel to set up the Buttons and Functions to call
	public void TestYNO(){
		Debug.Log("TEST YNO BUTTON CLICKED");
		modalPanel.Choice("Would you like some icecream?\nHow about vanilla?", myYesAction, myNoAction, myOkayAction);
	}
	
	//test YN buttons
	public void TestYN(){
		Debug.Log("TEST YN BUTTON CLICKED");
		modalPanel.Choice("Are you okay with this?", myYesAction, myNoAction);
	}
	
	//test O Buttons
	public void TestO(){
		Debug.Log("TEST O BUTTON CLICKED");
		modalPanel.Choice("Invalid word", myOkayAction);
	}
	
	//These are wrapped into UnityActions
	void TestYesFunction(){
		Debug.Log("Yes action fired");
		displayManager.DisplayMessage("Yes!");
	}
	
	void TestNoFunction(){
		Debug.Log("No Action fired");
		displayManager.DisplayMessage("No way!");
	}
	
	void TestOkayFunction(){
		Debug.Log("Okay action fired");
		displayManager.DisplayMessage("That's alright");
	}
	
}
