//Ben Hay (c) 2016

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {

	[SerializeField] private Text matterText;
	[SerializeField] private Text winText;
	private float matter;
    private ArrayList shapes;

    // Use this for initialization
    void Start () {
		matterText.text = "Matter: " + matter;
        shapes = new ArrayList();
    }

	// Update is called once per frame
	void Update () {
    }

	public void SetMatter(float newMatter){
		matter = newMatter;
		matterText.text = "Matter: " + matter;
	}

	public void AddMatter(float newMatter){
		matter += newMatter;
        float printMatter = Mathf.Round(matter);
		if(matter < 0){
			matterText.text = "Matter: " + 0;
		} else {
			matterText.text = "Matter: " + printMatter;
		}

	}

	//Returns the amount of matter the player currently has
	public float GetMatter(){
		return matter;
	}

	//Changes scene after completing a level
	public void Win(string sceneName){
		switch(sceneName){
			case "Tutorial":
				SceneManager.LoadScene ("level2");
				break;
			case "level2":
				SceneManager.LoadScene ("level3");
				break;
			case "level3":
				winText.text = "YOU WIN";
				break;

		}
	}
}
