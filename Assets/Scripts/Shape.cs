using UnityEngine;
using System.Collections;

public abstract class Shape : MonoBehaviour {
	public abstract string getShape ();
	public abstract float getVolume(GameObject currentObj);
}
