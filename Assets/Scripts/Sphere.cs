//Ben Hay (c) 2016

using UnityEngine;
using System.Collections;
using System;

public class Sphere : Shape {
    [SerializeField] private GameObject prefab;
//	private float currentVolume;

    public override float FindVolume(Vector3 size) {
        float volume = (4 * Mathf.PI * Mathf.Pow(size.x/2, 3))/3;
        return volume;
    }

    public override string GetShape() {
        return "Sphere";
    }

    public override GameObject GetPrefab() {
        return prefab;
    }

//	public override void SetCurrentVolume(float currentVolume){
//		this.currentVolume = currentVolume;
//	}
//
//	public override float GetCurrentVolume (){
//		return currentVolume;
//	}
}
