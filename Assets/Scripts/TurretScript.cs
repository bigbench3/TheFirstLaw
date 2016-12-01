using UnityEngine;
using System.Collections;

public class TurretScript : MonoBehaviour {

	private Transform target;
	private const float SHOOT_DELAY = 2.0f;
    [SerializeField]
    private EnemyBullet enemyBullet;

	[SerializeField] public GameObject bulletPrefab;
	[SerializeField] public float bulletSpeed;
	[SerializeField] public GameObject gunPrefab;
	private PewPewScript gunScript;
	private bool charged = false;
	private bool charging = false;

	AudioSource audio;


    // Use this for initialization
    void Start () {
		target = GameObject.Find ("Player").transform;
		gunScript = gunPrefab.GetComponent<PewPewScript> ();
		audio = GetComponent<AudioSource>();
//		InvokeRepeating ("Shoot", SHOOT_DELAY, SHOOT_DELAY);
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target);
		RaycastHit hit;
		if (Physics.Raycast (this.transform.position, target.transform.position - this.transform.position, out hit) && hit.transform.tag == "Player") {
			//yes, shannon, I know this part should follow the state pattern, pls dont hurt me
			if (charged) {
				Debug.Log ("Blam!");
				gunScript.Shoot ();
				charged = false;
			} else {
				if (!charging) {
					audio.Play ();
					StopCoroutine ("Charge");
					StartCoroutine ("Charge");
				}
			}
		} else {
			Debug.Log ("Are you still there?");
			StopCoroutine ("Charge");
			charging = false;
		}
	}

	IEnumerator Charge(){
		
		Debug.Log ("I see you!");
		charging = true;

		yield return new WaitForSeconds(SHOOT_DELAY);
		charging = false;
		charged = true;
	}

//	void Shoot(){
//        EnemyBullet eBullet = Instantiate(enemyBullet) as EnemyBullet;
//        Vector3 pos = transform.position;
//        Transform enemy = this.transform.parent;
//        //Debug.Log (enemy.eulerAngles.y);
//        if (enemy.eulerAngles.y > 89 && enemy.eulerAngles.y < 91) {
//            pos.x = pos.x + 0.7f;
//            eBullet.transform.eulerAngles = new Vector3(0, 90, 0);
//
//        } else if (enemy.eulerAngles.y > 170 && enemy.eulerAngles.y < 181) {
//            pos.z = pos.z - 0.7f;
//            eBullet.transform.eulerAngles = new Vector3(0, 180, 0);
//
//        } else if (enemy.eulerAngles.y > 269 && enemy.eulerAngles.y < 271) {
//            pos.x = pos.x - 0.7f;
//            eBullet.transform.eulerAngles = new Vector3(0, 270, 0);
//        } else {
//            pos.z = pos.z + 0.7f;
//        }
//
//        eBullet.transform.position = pos;
//    }

//	public void Shoot () {
//		GameObject sphere = Instantiate (bulletPrefab) as GameObject;
//
//		//World offset stuff for placement of sphere
//		//based on code from http://answers.unity3d.com/questions/41726/instantiating-in-a-position-relative-to-an-object.html#
//		Vector3 objectOffset = new Vector3(0,2.0f,0);
//		Vector3 worldOffset = transform.rotation * objectOffset;
//		Vector3 pos = transform.position + worldOffset;
//		sphere.transform.position = pos;
//
//		//change sphere to look at gun barrel and add force to sphere away from barrel.
//		//based on code from http://answers.unity3d.com/questions/175427/adding-force-toward-specific-object.html#
//		sphere.transform.LookAt(this.transform);
//		sphere.GetComponent<Rigidbody>().AddRelativeForce(0,0,-bulletSpeed);
//		Destroy (sphere, 10f);
//	}
}
