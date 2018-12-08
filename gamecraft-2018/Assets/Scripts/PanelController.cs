 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {

    private static PanelController singleton;

    [SerializeField]
    public List<TaskPanel> Panels;
    public Canvas canvas;

    public Task currentTask;
    private int currentTaskType;

    // Use this for initialization.
    void Start () {
        for (int i = 1; i < Panels.Count; i++) {
            Panels[i].gameObject.active = false;
        }
	}
	
	// Update is called once per frame.
	void Update () {
	}

    // Switch the displayed task to the specified task in the next frame.
    public void SwitchTask(int newTaskType, Task task) {
        // Back to home
        if (newTaskType == -1) { 
            Panels[currentTaskType].gameObject.active = false; 
            return; 
        }

        // Ignore if no change
        if (currentTaskType == newTaskType && currentTask == task) return;

        Panels[currentTaskType].gameObject.active = false;
        Panels[newTaskType].gameObject.active = true;
        Panels[newTaskType].Start();
        currentTaskType = newTaskType;
        currentTask = task;
    }

    // Singleton pattern.
    public static PanelController GetInstance() {
        if (singleton == null) singleton = new PanelController();
        return singleton;
    }
}
