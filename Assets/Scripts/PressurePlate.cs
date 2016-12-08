using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PressurePlate : MonoBehaviour {
	private OpenDoors opendoors;
	[SerializeField] protected GameObject door;
	[SerializeField] private Text tutorialText;
	private string[] prompts;
	private int index;

	// Use this for initialization
	void Start () {
		//door = GameObject.Find("SciFiDoorsSep");
		opendoors = door.GetComponent<OpenDoors> ();
		index = 0;
		prompts = new string[2];
		prompts [0] = "Right click to pick up objects, left click to shoot.";
		prompts [1] = "Use the mousewheel to resize the object, get the relic to win";
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider col){
		//GameObject obj = col.gameObject;
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Pressure Plate hit");
			opendoors.OpenSciFiDoors ();
			tutorialText.text = prompts [index];
			index = 0;
		} else if (col.gameObject.tag == "Shape") {
			index = 1;
			Debug.Log ("Pressure Plate hit");
			opendoors.OpenSciFiDoors ();
			tutorialText.text = prompts [index];
			index = 0;
		}
		//opendoors.OpenSciFiDoors();

	}
}
