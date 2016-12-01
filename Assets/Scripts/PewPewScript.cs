//Copyright Nathan Young & Alex Zaterka 2016
//@author azaterka
//@author nyoung

using UnityEngine;
using System.Collections;

/*
 * maeks da pew pew pew 
 * Script to make guns shoot in the correct direction from the correct starting point.
 */
public class PewPewScript : MonoBehaviour {
	[SerializeField] public GameObject bulletPrefab;
	[SerializeField] public float bulletSpeed;
	AudioSource audio;

	void Start(){
		audio = GetComponent<AudioSource>();
	}

	public void Shoot () {
		GameObject sphere = Instantiate (bulletPrefab) as GameObject;

		//World offset stuff for placement of sphere
		//based on code from http://answers.unity3d.com/questions/41726/instantiating-in-a-position-relative-to-an-object.html#
		Vector3 objectOffset = new Vector3(0,3,0);
		Vector3 worldOffset = transform.rotation * objectOffset;
		Vector3 pos = transform.position + worldOffset;
		sphere.transform.position = pos;

		//change sphere to look at gun barrel and add force to sphere away from barrel.
		//based on code from http://answers.unity3d.com/questions/175427/adding-force-toward-specific-object.html#
		sphere.transform.LookAt(this.transform);
		sphere.GetComponent<Rigidbody>().AddRelativeForce(0,0,-bulletSpeed);
		audio.Play ();
		Destroy (sphere, 10f);
	}
}
