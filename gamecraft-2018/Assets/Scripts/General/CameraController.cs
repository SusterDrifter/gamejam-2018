using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour {

	Camera cameraComponent;

	private void Awake()
	{
		cameraComponent = GetComponent<Camera>();
	}

	public void MoveToPosition(Vector3 pos, float duration = 0.5f) {
		transform.DOMove(pos, duration);
	}

	public void TweenToCameraSize(float endSize, float duration = 0.5f) {
		cameraComponent.DOOrthoSize(endSize, duration);
	}

}
