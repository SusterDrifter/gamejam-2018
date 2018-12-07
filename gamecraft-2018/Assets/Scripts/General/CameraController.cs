using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour {
 
	public void MoveToPosition(Vector3 pos, float duration = 0.5f) {
		transform.DOMove(pos, duration);
	}

}
