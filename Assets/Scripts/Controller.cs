//Ben Hay (c) 2016

using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
	
	[SerializeField] private TargetScript targetPrefab;
	[SerializeField] private Text matterText;
	[SerializeField] private Text winText;
	private float matter;

	// Use this for initialization
	void Start () {
		matterText.text = "Matter: " + matter;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setMatter(float newMatter){
		matter = newMatter;
		matterText.text = "Matter: " + matter;
	}

	public void addMatter(float newMatter){
		matter += newMatter;
        float printMatter = Mathf.Round(matter);
		if(matter < 0){
			matterText.text = "Matter: " + 0;
		} else {
			matterText.text = "Matter: " + printMatter;
		}

	}

	public float getMatter(){
		return matter;
	}

	public void win(){
		winText.text = "YOU WIN";
	}
		
}
