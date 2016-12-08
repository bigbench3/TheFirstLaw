//Ben Hay, Alex Zeterga, Colin Hiriak (c) 2016

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class RayShooter : MonoBehaviour {

    private Camera camera;
	protected GameObject controllerObject;
	protected Controller controller;
	[SerializeField] public GameObject cube;
    [SerializeField] public GameObject sphere;
	private GameObject currentObj;
	private bool lastvalue = false;
	private Collider collider = null;
    private Shape shape;
    private ArrayList shapes;
	private ArrayList typeOfShapes;
    private float initVol;
    private int index;
    private int listSize;

    //Initializes the class
    void Start() {
        camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;

		controllerObject = GameObject.Find ("Controller");
		controller = controllerObject.GetComponent<Controller>();
        initVol = 0.9f;
        shapes = new ArrayList();
		typeOfShapes = new ArrayList ();
        index = 0;
        listSize = 0;
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
					//Zeros the rotation to calculate the size properly
					obj.transform.eulerAngles = new Vector3 (0,0,0);
                    shape = obj.GetComponent<Shape>();
                    Vector3 size = col.bounds.size;
                    controller.AddMatter(shape.FindVolume(size));
					Debug.Log (shape.FindVolume (size));
					GameObject prefab = shape.GetPrefab ();
					string nameOfShape = shape.GetShape ();
					Debug.Log ("Shape picked up: " + shape.GetShape() + " With the Shape prefab: " + shape.GetPrefab());

					//If the shape isn't already in your arsenal of shapes, add the prefab for it
					if (!typeOfShapes.Contains(nameOfShape)) {
						shapes.Add(prefab);
						typeOfShapes.Add (nameOfShape);
                        listSize++;
						Debug.Log (listSize);
                    }

                    Destroy(obj);
                }

                if (tag == "Relic") {
					Scene scene = SceneManager.GetActiveScene ();
					string levelName = scene.name;
					controller.Win(levelName);
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

        if (Input.GetButton("NextObject")) {
            if(listSize != 0) {
                if (index < listSize - 1) {
                    index++;
                    GameObject obj = (GameObject)shapes[index];
                    Shape test = obj.GetComponent<Shape>();
                    Debug.Log("Index was increased, the shape is: " + test.GetShape());
                } 
//				else {
//                    index = 0;
//                    GameObject obj = (GameObject)shapes[index];
//                    Shape test = obj.GetComponent<Shape>();
//                    Debug.Log("Index couldn't be increased, looped to beginning of list and the shape is: " + test.GetShape());
//                }
            }
        }

        if (Input.GetButton("PreviousObject")) {
            Debug.Log("Previous Object");
            if (listSize != 0) {
                if (index > 0) {
                    index--;
                    GameObject obj = (GameObject)shapes[index];
                    Shape test = obj.GetComponent<Shape>();
                    Debug.Log("Index was decreased, the shape is: " + test.GetShape());
                } 
//				else {
//                    index = listSize - 1;
//                    GameObject obj = (GameObject)shapes[index];
//                    Shape test = obj.GetComponent<Shape>();
//                    Debug.Log("Index couldn't be decreased, looped to end of list and the shape is: " + test.GetShape());
//                }
            }
        }
    }

    public void Shoot(Vector3 position) {
		GameObject bullet = Instantiate ((GameObject)shapes[index]);
		Shape test = bullet.GetComponent<Shape> ();
		if (controller.GetMatter () > initVol) {
			controller.AddMatter (-initVol);
			bullet.transform.position = position;
			currentObj = bullet;
		} else {
			Destroy (bullet);
		}
    }
}

