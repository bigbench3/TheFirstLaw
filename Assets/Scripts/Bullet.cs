using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Remove(){
		Destroy (this.gameObject);
	}

	void OnCollisionEnter(Collision col){
		GameObject obj = col.gameObject;
			if(obj.tag == "Enemy"){
		}

		Destroy (this.gameObject);
	}
}
