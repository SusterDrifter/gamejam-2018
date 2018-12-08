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
        currentTask = task;
        for (int i = 0; i < Panels.Count; i++)
        {
            Panels[i].gameObject.SetActive(false);
            Panels[i].panelController = this;
        }
        // Back to home
        if (newTaskType == -1) { 
            // Other than this, there is an active panel.
            if (currentTaskType != -1) 
                Panels[currentTaskType].gameObject.SetActive(false); 

            return; 
        }

        // Ignore if no change
        if (currentTaskType == newTaskType && currentTask == task) return;
        if (currentTaskType != -1) {
            Panels[currentTaskType].gameObject.SetActive(false);
        }

        Panels[newTaskType].gameObject.SetActive(true);
        Panels[newTaskType].Start();
        currentTaskType = newTaskType;

    }
}
