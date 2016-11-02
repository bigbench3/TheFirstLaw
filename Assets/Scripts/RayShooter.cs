using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {

    private Camera camera;
	[SerializeField] private Bullet bulletPrefab;
	protected GameObject controllerObject;
	protected Controller controller;
	[SerializeField] public GameObject selectedObject;
	private GameObject currentObj;

    void Start() {
        camera = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;

		controllerObject = GameObject.Find ("Controller");
		controller = controllerObject.GetComponent<Controller>();

    }

    void Update() {
		float scaleValue = Input.GetAxis ("Mouse ScrollWheel");

		//eat stuff
        if (Input.GetMouseButtonDown(1)) {
            Vector3 origin = new Vector3(camera.pixelWidth / 2,camera.pixelHeight / 2,0);
			Vector3 pos = transform.position;
            Ray ray = camera.ScreenPointToRay(origin);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) {
				Collider col = hit.collider;
				string tag = col.gameObject.tag;
				if(tag == "SquareMatter"){
					Vector3 size = col.bounds.size;
					controller.setMatter (size.x*size.y*size.z);
//					AddType ();
//					selectedObject = col.gameObject;
					Destroy (col.gameObject);
				}
            }
        }
		//shoot stuff
		if (Input.GetMouseButtonDown (0)) {
//			if (selectedObject != null && controller.getMatter() > 0){
				Vector3 origin = new Vector3 (camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
				Vector3 pos = transform.position;
				Ray ray = camera.ScreenPointToRay (origin);
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit)) {
					Collider col = hit.collider;
					Shoot (hit.point);

//				}
			}
		}

		//scale stuff
		if(scaleValue > 0){
			currentObj.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
		} else if (scaleValue < 0){
			currentObj.transform.localScale -= new Vector3(0.1F, 0.1f, 0.1f);
		}
    }

    private void Shoot(Vector3 position) {
		GameObject bullet = Instantiate (selectedObject);
		Debug.Log ("shoot");
        
		Collider col = bullet.GetComponent<Collider> ();
		Vector3 size = col.bounds.size;
		float sizef = size.x * size.y * size.z;
		if (controller.getMatter () > sizef) {
			controller.setMatter (-sizef);
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

