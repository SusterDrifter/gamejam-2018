using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private static PlayerController instance;
    private PlayerController() {}
    public static PlayerController GetInstance() {
        if (instance == null) {
            instance = new PlayerController();
        }
        return instance;
    }

	public CameraController cameraController;

    public Task Target;

	private void Awake()
	{
		cameraController = Camera.main.GetComponent<CameraController>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			jumpToHotKey(1);
		} else if (Input.GetKeyDown(KeyCode.Alpha2)) 
		{
			jumpToHotKey(2);
		} else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
			jumpToHotKey(3);
		} else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
			jumpToHotKey(4);
		} else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
			jumpToHotKey(5);
		} else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
			jumpToHotKey(6);
		} else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
			jumpToHotKey(7);
		} else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
			jumpToHotKey(8);
		}
	}

	void jumpToHotKey(int number) {
		int index = number - 1;
		if (index >= TaskManager.instance.ongoingTasks.Count)
			return;
		Target = TaskManager.instance.ongoingTasks[index];
        GameManager.instance.cameraController.PlayerController = this;

        GameManager.instance.cameraController.JumpToShipPanel(Target.taskPanel);
	}

}
