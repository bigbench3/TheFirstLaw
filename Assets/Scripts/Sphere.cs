using UnityEngine;
using System.Collections;
using System;

public class Sphere : Shape {
    [SerializeField] private GameObject prefab;

    public override float FindVolume(Vector3 size) {
        float volume = (4 * Mathf.PI * Mathf.Pow(size.x/2, 3))/3;
        Debug.Log("Radius: " + size.x/2 + " Volume: " + volume);
        return volume;
    }

    public override string GetShape() {
        return "Sphere";
    }

    public override GameObject GetPrefab() {
        return prefab;
    }
}
