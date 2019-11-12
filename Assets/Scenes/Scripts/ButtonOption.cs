using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOption : MonoBehaviour {

	public void NewGame () {
		SceneManager.LoadScene (1);
	}
	public void Settings () {
		SceneManager.LoadScene (2);
	}
	public void Info () {
		SceneManager.LoadScene (3);
	}
	public void ConnectToPlayer () {
		SceneManager.LoadScene (4);
	}
	public void Resume() {
		SceneManager.LoadScene (4);
	}
    public void AudioVideo()
    {
        SceneManager.LoadScene(5);
    }
    public void Mainmenu()
    {
        SceneManager.LoadScene(0);
    }
    public void quit()
    {
        Application.Quit();
    }
}
