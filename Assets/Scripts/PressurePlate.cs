using UnityEngine;
using System.Collections;

public class PressurePlate : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision col){
		GameObject obj = col.gameObject;
		if (obj.tag == "Player") {
			
		}
	}
}
