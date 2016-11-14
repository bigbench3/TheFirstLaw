//Ben Hay, Alex Zeterga, Colin Hiriak (c) 2016

using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {

    private Camera camera;
	[SerializeField] private Bullet bulletPrefab;
	protected GameObject controllerObject;
	protected Controller controller;
	[SerializeField] public GameObject cube;
    [SerializeField] public GameObject sphere;
	private GameObject currentObj;
	private bool lastvalue = false;
	private Collider collider = null;
    private Shape shape;
    private ArrayList shapes;
    private float initVol;
    private int index;

    //Initializes the class
    void Start() {
        camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;

		controllerObject = GameObject.Find ("Controller");
		controller = controllerObject.GetComponent<Controller>();
        initVol = 1;
        shapes = new ArrayList();
        index = 0;
    }

    void Update() {
        float scaleValue = Input.GetAxis("Mouse ScrollWheel");
        float matter = controller.GetMatter();

        if (currentObj != null) {
            collider = currentObj.GetComponent<Collider>();
        }

        //causes the gameobject the user is looking at to be absorb if it is a shape or relic then adds the
        //volume of said shape to the players matter meter
        if (Input.GetMouseButtonDown(1) || Input.GetAxis("LeftTrigger") == 1) {

            Vector3 origin = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
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

                    if (!shapes.Contains(shape.GetPrefab())) {
                        shapes.Add(shape.GetPrefab());
                    }

                    Destroy(obj);
                }

                if (tag == "Relic") {
                    controller.Win();
                }
            }
        }

        //Spawns the selected shape at the location the user is looking
        if (Input.GetMouseButtonDown(0) || (Input.GetAxis("RightTrigger") == 1 && !lastvalue)) {
            Vector3 origin = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
            Vector3 pos = transform.position;
            Ray ray = camera.ScreenPointToRay(origin);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit)) {
                Collider col = hit.collider;
                Shoot(hit.point);
            }
        }

        lastvalue = (Input.GetAxis("RightTrigger") == 1);
        if (Input.GetButton("ControllerYUp")) {
            Debug.Log("y button pressed");
            scaleValue += 1;
        }

        if (Input.GetButton("ControllerBDown")) {
            Debug.Log("b button pressed");
            scaleValue -= 1;
        }

        //Scales the last placed object up or down depending on user input
        if (collider != null) {
            if (scaleValue != 0) {
                shape.Scale(collider, scaleValue);
            }
        }

//        if (Input.GetKeyDown("PreviousShape")) {
//
//        }
//
//        if (Input.GetKeyDown("NextShape")) {
//
//        }
    }

    public void Shoot(Vector3 position) {
		GameObject bullet = Instantiate ((GameObject)shapes[index]);
        
		if (controller.GetMatter () > initVol) {
			controller.AddMatter (-initVol);
			bullet.transform.position = position;
			currentObj = bullet;
		} else {
			Destroy (bullet);
		}
//        bullet.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
//        yield return new WaitForSeconds(1);
//		  bullet.Remove();
    }
}

