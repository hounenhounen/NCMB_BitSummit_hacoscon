using UnityEngine;
using System.Collections;

public class MyCameraController : MonoBehaviour {
	private GUIStyle labelStyle;
	Quaternion start_gyro;
	Quaternion gyro;
	void Start()
	{
		this.labelStyle = new GUIStyle();
		this.labelStyle.fontSize = Screen.height / 22;
		this.labelStyle.normal.textColor = Color.white;
		start_gyro = StartCameraController.ini_gyro;
		
	}
	
	
	void Update () {
		Input.gyro.enabled = true;
		if (Input.gyro.enabled)
		{
			gyro = Input.gyro.attitude;
			gyro = Quaternion.Euler(90, 0, 0) * (new Quaternion(-gyro.x,-gyro.y, gyro.z, gyro.w));
			this.transform.localRotation = new Quaternion(gyro.x,gyro.y-start_gyro.y, gyro.z, gyro.w);
		}
	}
	//ジャイロセンサの値を表示するプログラム
	void OnGUI()
	{
		if (Input.gyro.enabled)
		{
			float x = Screen.width / 10;
			float y = 0;
			float w = Screen.width * 8 / 10;
			float h = Screen.height / 20;
			
			for (int i = 0; i < 3; i++)
			{
				y = Screen.height / 10 + h * i;
				string text = string.Empty;
				
				switch (i)
				{
				case 0://X
					text = string.Format("gyro-X:{0}", gyro.x);
					break;
				case 1://Y
					text = string.Format("gyro-Y:{0}", gyro.y);
					break;
				case 2://Z
					text = string.Format("gyro-Z:{0}", gyro.z);
					break;
				default:
					throw new System.InvalidOperationException();
				}
				
				GUI.Label(new Rect(x, y, w, h), text, this.labelStyle);
			}
		}
	}
}
