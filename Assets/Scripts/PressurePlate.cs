using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {
	private OpenDoors opendoors;
	[SerializeField] protected GameObject door;

	// Use this for initialization
	void Start () {
		door = GameObject.Find("SciFiDoorsSep");
		opendoors = door.GetComponent<OpenDoors> ();
		
		
		
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider col){
		//GameObject obj = col.gameObject;
		if (col.gameObject.tag == "Player") {
			Debug.Log ("Pressure Plate hit");
			opendoors.OpenSciFiDoors ();


			
			
		}
		//opendoors.OpenSciFiDoors();

	}
}
