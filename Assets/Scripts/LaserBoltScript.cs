using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LaserBoltScript : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter(Collision col){
		GameObject obj = col.gameObject;
		if (obj.tag == "Player") {
			SceneManager.LoadScene (Application.loadedLevelName);
		}
		if(obj.tag != "EnemyBullet"){
			Destroy (this.gameObject);
		}
	}
}
