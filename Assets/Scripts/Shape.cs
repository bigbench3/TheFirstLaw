//Ben Hay (c) 2016

using UnityEngine;
using System.Collections;

public abstract class Shape : MonoBehaviour {
    private GameObject currentObj;
    protected GameObject controllerObject;
    protected Controller controller;
    private float matter;
    private float currentVolume;
    
    //Initializes the shape's key components 
    void Start() {
        controllerObject = GameObject.Find("Controller");
        controller = controllerObject.GetComponent<Controller>();
        matter = controller.GetMatter();
        currentVolume = 1;
    }

    //Abstract method to be implemented by subclasses that returns a string containning
    //the shape of the object
    public abstract string GetShape ();
    public abstract GameObject GetPrefab();

    //Abstract method to be implemented by subclasses that returns a float denotting the volume
    //of the shape given a Vector3
    public abstract float FindVolume(Vector3 size);

    //Scales the shape based its userinput, scaleValue (+ to grow, - to shrink), and updates
    //the amount of matter left. 
    public void Scale(Collider col, float scaleValue) {
        Debug.Log("Scale is called with a scaleValue of: " + scaleValue);
        currentObj = col.gameObject;
        Vector3 scaled = currentObj.transform.localScale + new Vector3(0.1F, 0.1f, 0.1f);
        Vector3 current = currentObj.transform.localScale;
        float newVolume = FindVolume(scaled);
        float diffMatter = newVolume - FindVolume(current);
        matter = controller.GetMatter();
        Debug.Log("Diff in matter: " + diffMatter + " and current matter is: " + matter);

        if (scaleValue > 0 && matter > diffMatter) {
            currentObj.transform.localScale += new Vector3(0.1F, 0.1f, 0.1f);
            controller.AddMatter(currentVolume - newVolume);
            matter = controller.GetMatter();
        } else if (scaleValue < 0 && currentVolume > 1) {
            currentObj.transform.localScale -= new Vector3(0.1F, 0.1f, 0.1f);
            controller.AddMatter(currentVolume - newVolume);
            matter = controller.GetMatter();
        }

        currentVolume = newVolume;
    }
}
