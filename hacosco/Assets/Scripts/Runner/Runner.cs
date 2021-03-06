﻿using UnityEngine;
using System.Collections;

public class Runner : MonoBehaviour {
	private GUIStyle labelStyle;
	Quaternion gyro;
	bool goal = false;
	public float Speed = 0.3f;
	void Update () {
		if (goal == false) {
			Input.gyro.enabled = true;
			if (Input.gyro.enabled) {
				Quaternion gyro = Input.gyro.attitude;
				Quaternion action_gyro = Quaternion.Euler (90, 0, 0) * (new Quaternion (-gyro.x, -gyro.y, gyro.z, gyro.w));
				action_gyro = Quaternion.Inverse(StartCameraController.ini_gyro) * action_gyro;
				Vector3 p = new Vector3 (-1.0f*Mathf.Sin(action_gyro.eulerAngles.z * Mathf.Deg2Rad), 0, Speed);
				Debug.Log (action_gyro.eulerAngles.z);
				transform.position += p;
			}else{
				//シュミレーター上で動かすための、キーボードの入力を受け付ける
				if(Input.GetKey ("up")){
					Vector3 up = new Vector3 (transform.position.x, transform.position.y, transform.position.z + Speed);
					transform.position = up;
				}
				
				if(Input.GetKey ("down")){
					Vector3 down = new Vector3 (transform.position.x, transform.position.y, transform.position.z - Speed);
					transform.position = down;
				}
				
				if(Input.GetKey ("right")){
					Vector3 right = new Vector3 (transform.position.x +Speed, transform.position.y, transform.position.z);
					transform.position = right;
				}
				
				if(Input.GetKey ("left")){
					Vector3 left = new Vector3 (transform.position.x - Speed, transform.position.y, transform.position.z);
					transform.position = left;
				}
				
			}
		} else {

			transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		}
	}

	void OnGoal() {
		goal = true;
	}
	
	
}