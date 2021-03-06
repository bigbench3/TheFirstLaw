﻿// Ben Hay (c) 2016

using UnityEngine;
using System.Collections;
using System;

public class Cube : Shape {
    [SerializeField] private GameObject prefab;
//	private float currentVolume;

    //Given the Vector3 containning the size in the x, y, and z directions calulates 
    //the volume of the square and returns it
    public override float FindVolume(Vector3 size) {
        float volume = size.x * size.y * size.z;
        return volume;
    }

    //Returns the shape of the object, which is a square
    public override string GetShape() {
        return "Cube";
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
