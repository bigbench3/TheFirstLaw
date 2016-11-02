using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour {
	
	[SerializeField] private TargetScript targetPrefab;
	[SerializeField] private Text scoreText;
	[SerializeField] private Text livesText;
	[SerializeField] private Text matterText;

	private float offsetX = 3.0f;
	private float offsetZ = 5.0f;
	private int score;
	private int lives;
	private float matter;

	// Use this for initialization
	void Start () {
		score = 0;
		lives = 3;

		Vector3 startPos = targetPrefab.transform.position;
		Vector3 pos = Vector3.zero;
		for (int i = 0; i < 6; i++) {
			TargetScript target;

			if (i == 0) {
				target = targetPrefab;
			} else {
				target = Instantiate (targetPrefab) as TargetScript;
			}

			float posZ = -(offsetX * i) + startPos.z;
			target.transform.position = new Vector3 (startPos.x, startPos.y, posZ);
		}

		scoreText.text = "Score: " + score;
		livesText.text = "Lives: " + lives;
		matterText.text = "Matter: " + matter;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void setScore(int newScore){
		score = newScore;
	}

	public void setLives(int newLives){
		lives = newLives;
	}

	public void setMatter(float newMatter){
		matter += newMatter;
		UpdateUI();
	}

	public float getMatter(){
		return matter;
	}

	public void UpdateUI(){
		matterText.text = "Matter: " + matter;
//		livesText.text = "Lives: " + lives;
//		matterText.text = "Matter: " + matter;
	}
		
}
