using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	private Transform target;
	private const float SHOOT_DELAY = 2.0f;

	// Use this for initialization
	void Start () {
		target = GameObject.Find ("Player").transform;

	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target);
		RaycastHit hit;
		if (Physics.Raycast (this.transform.position, target.transform.position - this.transform.position, out hit) && hit.transform.tag == "Player"){
			InvokeRepeating ("Shoot", SHOOT_DELAY, SHOOT_DELAY);
		}
	}

	void Shoot(){
		Debug.Log ("Pew-pew!");
	}
}
