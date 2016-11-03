using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour {
	[SerializeField] private Text score;
	public GameObject targetPrefab;

	protected GameObject controllerObject;
	protected Controller controller;

	void Start() {

		controllerObject = GameObject.Find ("Controller");
		controller = controllerObject.GetComponent<Controller> ();
	}
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision coll){
		GameObject collidedWith = coll.gameObject;

		if(collidedWith.tag == "Bullet"){
			string text = score.text.Substring(6);
			int intScore = int.Parse (text);
			intScore += 100;

			Destroy (this.gameObject);
		}
	}
}
