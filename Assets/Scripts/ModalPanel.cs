using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ModalPanel : MonoBehaviour {

	public Text question;
	public Image iconImage;
	public Button yesButton;
	public Button noButton;
	public Button okayButton;
	public GameObject modalPanelObject;
	
	private static ModalPanel modalPanel;
	
	public static ModalPanel Instance(){
		if(!modalPanel){
			modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
			if(!modalPanel){
				Debug.LogError("There needs to be one active ModalPanel script on a GameObject in your scene.");
			}
		}
		return modalPanel;
	}
	
	public void Awake(){
		iconImage.gameObject.SetActive(false);
		yesButton.gameObject.SetActive(false);
		noButton.gameObject.SetActive(false);
		okayButton.gameObject.SetActive(false);
		modalPanelObject.SetActive(false);
	}
	
	// Yes/No/Okay: A string, A yes event, a no event, and an okay event
	public void Choice(string question, UnityAction yesEvent, UnityAction noEvent, UnityAction okayEvent){
		if(yesEvent == null){
			Debug.LogError("There must be a yes event");
		}

		//open panel
		modalPanelObject.SetActive(true);
		
		//assign listeners
		yesButton.onClick.RemoveAllListeners();
		yesButton.onClick.AddListener(yesEvent);
		yesButton.onClick.AddListener(ClosePanel);
		
		noButton.onClick.RemoveAllListeners();
		noButton.onClick.AddListener(noEvent);
		noButton.onClick.AddListener(ClosePanel);
		
		okayButton.onClick.RemoveAllListeners();
		okayButton.onClick.AddListener(okayEvent);
		okayButton.onClick.AddListener(ClosePanel);
		
		this.question.text = question;
		
		this.iconImage.gameObject.SetActive(false);
		yesButton.gameObject.SetActive(true);
		noButton.gameObject.SetActive(true);
		okayButton.gameObject.SetActive(true);
		
		Debug.Log("YNO PANEL OPENNED");
	}
	
	// Yes/No: A string, A yes event, a no event
	public void Choice(string question, UnityAction yesEvent, UnityAction noEvent){
		//open panel
		modalPanelObject.SetActive(true);
		
		//asign listeners
		yesButton.onClick.RemoveAllListeners();
		yesButton.onClick.AddListener(yesEvent);
		yesButton.onClick.AddListener(ClosePanel);
		
		noButton.onClick.RemoveAllListeners();
		noButton.onClick.AddListener(noEvent);
		noButton.onClick.AddListener(ClosePanel);
		
		okayButton.onClick.RemoveAllListeners();
		
		this.question.text = question;
		
		this.iconImage.gameObject.SetActive(false);
		yesButton.gameObject.SetActive(true);
		noButton.gameObject.SetActive(true);
		okayButton.gameObject.SetActive(false);
		
		
		Debug.Log("YN PANEL OPENNED");
	}
	
	// Okay: A string and an okay event
	public void Choice(string question, UnityAction okayEvent){
		//open panel
		modalPanelObject.SetActive(true);
		
		//asign listeners
		yesButton.onClick.RemoveAllListeners();
		
		noButton.onClick.RemoveAllListeners();
		
		okayButton.onClick.RemoveAllListeners();
		okayButton.onClick.AddListener(okayEvent);
		okayButton.onClick.AddListener(ClosePanel);
		
		this.question.text = question;
		
		this.iconImage.gameObject.SetActive(false);
		yesButton.gameObject.SetActive(false);
		noButton.gameObject.SetActive(false);
		okayButton.gameObject.SetActive(true);
	
	
		Debug.Log("O PANEL OPENNED");
	}
	
	void ClosePanel(){
		Debug.Log("Close action fired");
		modalPanelObject.SetActive(false);
	}
}
