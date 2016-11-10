using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
	
	[SerializeField] private TargetScript targetPrefab;
	[SerializeField] private Text matterText;
	[SerializeField] private Text winText;

	private float offsetX = 3.0f;
	private float offsetZ = 5.0f;
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
		if(matter < 0){
			matterText.text = "Matter: " + 0;
		} else {
			matterText.text = "Matter: " + matter;
		}

	}

	public float getMatter(){
		return matter;
	}

	public void win(){
		winText.text = "YOU WIN";
	}
		
}
