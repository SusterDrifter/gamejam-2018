 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {

    [SerializeField]
    public List<TaskPanel> Panels;
    public Canvas canvas;

    public Task currentTask;
    private int currentTaskType = -1;

    // Use this for initialization.
    void Start () {
        for (int i = 1; i < Panels.Count; i++) {
            Panels[i].gameObject.SetActive(false);
            Panels[i].panelController = this;
        }
        Debug.Log("Everything initialzied");
	}
	
	// Update is called once per frame.
	void Update () {
	}

    // Switch the displayed task to the specified task in the next frame.
    public void SwitchTask(int newTaskType, Task task) {
        // Ignore if no change
        if (currentTask == task) return;

        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].gameObject.SetActive(false);
            Panels[i].panelController = this;
        }
        // Back to home
        if (newTaskType == -1) {
            // Other than this, there is an active panel.
            for (int i = 0; i < Panels.Count; i++)
            {
                Panels[i].gameObject.SetActive(false);
            }
			GameManager.instance.cameraController.JumpToShipPanel(ShipPanel.Default);
            return; 
        }

		currentTask = task;
        Panels[newTaskType].gameObject.SetActive(true);
        Panels[newTaskType].Start();
        currentTaskType = newTaskType;

    }
}
