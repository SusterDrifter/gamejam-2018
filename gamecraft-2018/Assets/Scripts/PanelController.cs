 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour {

    private static PanelController singleton;

    [SerializeField]
    public List<TaskPanel> Panels;
    public Canvas canvas;

    private TaskStub currentTask;
    private int currentTaskType;

    // Use this for initialization.
    void Start () {
        for (int i = 1; i < Panels.Count; i++) {
            Panels[i].enabled = false;
        }
	}
	
	// Update is called once per frame.
	void Update () {
	}

    // Switch the displayed task to the specified task in the next frame.
    public void SwitchTask(int taskType, TaskStub task) {
        // Ignore if no change
        if (currentTaskType == taskType && currentTask == task) return;

        Panels[currentTaskType].enabled = false;
        currentTaskType = taskType;
        currentTask = task;
    }

    // Singleton pattern.
    public static PanelController GetInstance() {
        if (singleton == null) singleton = new PanelController();
        return singleton;
    }
}
