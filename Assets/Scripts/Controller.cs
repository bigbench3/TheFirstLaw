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

	public float GetMatter(){
		return matter;
	}

	public void Win(){
		winText.text = "YOU WIN";
	}
}
