//Ben Hay, Alex Zeterga, Colin Hiriak (c) 2016

using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {

    private Camera camera;
	[SerializeField] private Bullet bulletPrefab;
	protected GameObject controllerObject;
	protected Controller controller;
	[SerializeField] public GameObject selectedObject;
	private GameObject currentObj;
	private bool lastvalue = false;
	private Collider collider = null;
    private Shape shape;

    //Initializes the class
    void Start() {
        camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;

		controllerObject = GameObject.Find ("Controller");
		controller = controllerObject.GetComponent<Controller>();
    }

    //Checks for user input that would shoot, absorb or scale an object
    void Update() {
		float scaleValue = Input.GetAxis ("Mouse ScrollWheel");
		float matter = controller.GetMatter ();

		if(currentObj != null) {
			collider = currentObj.GetComponent<Collider> ();
		}

		//Causes the gameObject the user is looking at to be absorb if it is a shape or relic then adds the
        //volume of said shape to the players matter meter
		if (Input.GetMouseButtonDown(1)|| Input.GetAxis("LeftTrigger") == 1) {
			
            Vector3 origin = new Vector3(camera.pixelWidth / 2,camera.pixelHeight / 2,0);
			Vector3 pos = transform.position;
            Ray ray = camera.ScreenPointToRay(origin);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
				Collider col = hit.collider;
				string tag = col.gameObject.tag;

                if (tag == "Shape") {
                    GameObject obj = col.gameObject;
                    shape = obj.GetComponent<Shape>();
                    Vector3 size = col.bounds.size;
                    controller.AddMatter(shape.FindVolume(size));
                    controller.AddType(shape.GetShape());
                    Destroy (obj);
                }

				if (tag == "Relic") {
					controller.Win ();
				}
            }

        }

		//Spawns the selected shape at the location the user is looking
		if (Input.GetMouseButtonDown (0) || (Input.GetAxis("RightTrigger") == 1 && !lastvalue)) {
			Vector3 origin = new Vector3 (camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
			Vector3 pos = transform.position;
			Ray ray = camera.ScreenPointToRay (origin);
			RaycastHit hit;

            if (Physics.Raycast (ray, out hit)) {
				Collider col = hit.collider;
				Shoot (hit.point);
			}

		}

		lastvalue = (Input.GetAxis("RightTrigger") == 1);
		if(Input.GetButton("ControllerYUp")) {
			Debug.Log("y button pressed");
			scaleValue += 1;
		}

		if(Input.GetButton("ControllerBDown")) {
			Debug.Log("b button pressed");
			scaleValue -= 1;
		}

		//Scales the last placed object up or down depending on user input
        if (collider != null) {
            if(scaleValue != 0) {
                shape.Scale(collider, scaleValue);
            }
        }

    }

    private void Shoot(Vector3 position) {
		GameObject bullet = Instantiate (selectedObject);
        
		Collider col = bullet.GetComponent<Collider> ();
		Vector3 size = col.bounds.size;
		float sizef = size.x * size.y * size.z;
		if (controller.GetMatter () > sizef) {
			controller.AddMatter (-sizef);
			bullet.transform.position = position;
			currentObj = bullet;
		} else {
			Destroy (bullet);
		}
//        bullet.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
//        yield return new WaitForSeconds(1);
//		bullet.Remove();
    }

}

