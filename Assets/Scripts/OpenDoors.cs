using UnityEngine;
using System.Collections;

public class OpenDoors : MonoBehaviour {

	// To open and close doors via Inspector
	private bool Open_Doors;
	private bool Close_Doors;

	// Once the doors has been opened they can be closed again
	private bool door_opened;


	public GameObject BottomDoors;
	public GameObject TopDoors;

	// Store original position of top and bottom doors
	Vector3 TopDoorsOriginPosition;
	Vector3 BottomDoorsOriginPosition;

	void Awake()
	{
		TopDoorsOriginPosition = TopDoors.transform.position;
		BottomDoorsOriginPosition = BottomDoors.transform.position;
	}

	// Use this for initialization
	void Start () {
		Open_Doors = false;
		Close_Doors = true;
	
	}
	
	// Update is called once per frame
	void Update () {

		if(Open_Doors)
		{
			OpenSciFiDoors();
			StartCoroutine (Hold ());
		}

		if(door_opened && Close_Doors)
		{
			StartCoroutine (Hold ());
			CloseSciFiDoors();
		}

	}


	public void OpenSciFiDoors()
	{
		TopDoors.transform.position = Vector3.Lerp (TopDoors.transform.position, 
			new Vector3(TopDoors.transform.position.x, TopDoors.transform.position.y, TopDoors.transform.position.z) + 
			new Vector3 (0, 6f,0 ), 0.45f * Time.deltaTime);
		BottomDoors.transform.position = Vector3.Lerp (BottomDoors.transform.position, 
			new Vector3(BottomDoors.transform.position.x, BottomDoors.transform.position.y, BottomDoors.transform.position.z) + 
			new Vector3 (0, -3.310805f, 0), 0.45f * Time.deltaTime);

		// We want to wait till doors reach certain position before they can be closed
		if(TopDoors.transform.position.y > 3 && BottomDoors.transform.position.y < -2.5f)
		{
			door_opened = true;
			Open_Doors = false;
			StartCoroutine (Hold ());		
		}
	
	}

	void CloseSciFiDoors()
	{
		StartCoroutine (Hold ());		
		TopDoors.transform.position = Vector3.Lerp (TopDoors.transform.position, TopDoorsOriginPosition, 0.45f * Time.deltaTime);
		BottomDoors.transform.position = Vector3.Lerp (BottomDoors.transform.position, BottomDoorsOriginPosition, 0.45f * Time.deltaTime);

	}

	IEnumerator Hold() {
		yield return new WaitForSecondsRealtime (3f);
	}

}

