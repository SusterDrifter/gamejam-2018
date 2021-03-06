﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraController : MonoBehaviour {

	Camera cameraComponent;
    public PanelController panelController;
    public PlayerController PlayerController;

    private void Awake()
	{
		cameraComponent = GetComponent<Camera>();
        panelController = GameObject.Find("PanelController").GetComponent<PanelController>();
    }

	public void MoveToPosition(Vector3 pos, float duration = 0.5f) {
		transform.DOMove(pos, duration);
	}

	public void TweenToCameraSize(float endSize, float duration = 0.5f) {
		cameraComponent.DOOrthoSize(endSize, duration);
	}

	public void JumpToShipPanel(ShipPanel panel) {
		switch (panel) {
			case ShipPanel.Default:
				MoveToPosition(new Vector3(0, 0, -10));
				TweenToCameraSize(6.78f);
                //panelController.SwitchTask(-1, null);
				break;
			case ShipPanel.Calculator:
				MoveToPosition(new Vector3(-6.52f, -3.68f, -10));
				TweenToCameraSize(2.98f);
                panelController.SwitchTask(1, PlayerController.Target);
				break;
			case ShipPanel.Thermostat:
				MoveToPosition(new Vector3(-1.7f, 5.7f, -10));
                TweenToCameraSize(1.83f);
                panelController.SwitchTask(0, PlayerController.Target);
                break;
			case ShipPanel.Weapons:
				MoveToPosition(new Vector3(-4.58f,1.86f, -10));
                TweenToCameraSize(3.98f);
                panelController.SwitchTask(2, PlayerController.Target);
                break;
			case ShipPanel.Signature:
				MoveToPosition(new Vector3(7.1f, -1.6f, -10));
                TweenToCameraSize(2.72f);
                panelController.SwitchTask(3, PlayerController.Target);
                break;
		}
	}

}
