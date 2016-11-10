using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	private Transform target;
	private const float SHOOT_DELAY = 2.0f;
    [SerializeField] private EnemyBullet enemyBullet;

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
        EnemyBullet eBullet = Instantiate(enemyBullet) as EnemyBullet;
        Vector3 pos = transform.position;
        Transform enemy = this.transform.parent;
        //Debug.Log (enemy.eulerAngles.y);
        if (enemy.eulerAngles.y > 89 && enemy.eulerAngles.y < 91) {
            pos.x = pos.x + 0.7f;
            eBullet.transform.eulerAngles = new Vector3(0, 90, 0);

        } else if (enemy.eulerAngles.y > 170 && enemy.eulerAngles.y < 181) {
            pos.z = pos.z - 0.7f;
            eBullet.transform.eulerAngles = new Vector3(0, 180, 0);

        } else if (enemy.eulerAngles.y > 269 && enemy.eulerAngles.y < 271) {
            pos.x = pos.x - 0.7f;
            eBullet.transform.eulerAngles = new Vector3(0, 270, 0);
        } else {
            pos.z = pos.z + 0.7f;
        }

        eBullet.transform.position = pos;
    }
}
