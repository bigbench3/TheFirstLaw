using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MovingEnemy : MonoBehaviour {
	[SerializeField] private Text score;

	public float speed = 12.5f;
	public float range = 3f;
	private float chanceToChangeDirection = 0.03f;
	private Vector3 maxPos;
	private Vector3 minPos;
	private bool inX;

	protected GameObject controllerObject;
	protected Controller controller;

	void Start() {

		controllerObject = GameObject.Find ("Controller");
		controller = controllerObject.GetComponent<Controller>();
		Vector3 initPos = transform.position;
		maxPos = initPos;
		minPos = initPos;

		if(transform.eulerAngles.y == 90 || transform.eulerAngles.y == 270){
			maxPos.z = initPos.z + range;
			minPos.z = initPos.z - range;
			inX = false;
		} else {
			maxPos.x = initPos.x + range;
			minPos.x = initPos.x - range;
			inX = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		if (inX) {
			pos.x += speed * (Time.deltaTime / 2);
			transform.position = pos;

			if (pos.x >= maxPos.x && speed > 0) {
				speed = -speed;
			}

			if (pos.x <= minPos.x && speed < 0) {
				speed = -speed;
			}
		} else {
			pos.z += speed * (Time.deltaTime / 2);
			transform.position = pos;

			if (pos.z >= maxPos.z && speed > 0) {
				speed = -speed;
			}

			if (pos.z <= minPos.z && speed < 0) {
				speed = -speed;
			}
		}
	}

	void FixedUpdate(){
		float rand = Random.Range (0.0f, 2.0f);
		if(rand < chanceToChangeDirection){
			speed = -speed;
		}
	}

	void OnCollisionEnter(Collision col){
		GameObject obj = col.gameObject;

		if(obj.tag == "Bullet"){
			string text = score.text.Substring(6);
			int intScore = int.Parse (text);
			intScore += 500;
			controller.setScore (intScore);
			score.text = "Score: " + intScore.ToString();

			Destroy (this.gameObject);
		}
	}
}
