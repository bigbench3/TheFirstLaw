using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndGameCanvas : MonoBehaviour {




	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	public void Open(){
		gameObject.SetActive (true);
	}

	public void Close(){
		gameObject.SetActive (false);
	}

	public void restart(){
		gameObject.SetActive (false);
		SceneManager.LoadScene ("Level1");
	}
}