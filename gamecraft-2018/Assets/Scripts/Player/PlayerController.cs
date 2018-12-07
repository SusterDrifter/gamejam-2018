using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public CameraController cameraController;

	private void Awake()
	{
		cameraController = Camera.main.GetComponent<CameraController>();
	}

}
