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
		modalPanel.Choice("Would you like some icecream?\nHow about vanilla?", myYesAction, myNoAction, myOkayAction);
		
	}
	
	
	//These are wrapped into UnityActions
	void TestYesFunction(){
		displayManager.DisplayMessage("Yes!");
	}
	
	void TestNoFunction(){
		displayManager.DisplayMessage("No way!");
	}
	
	void TestOkayFunction(){
		displayManager.DisplayMessage("That's alright");
	}
	
}
