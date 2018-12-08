using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskSO : ScriptableObject {

	public string taskName;

	[SerializeField]
    public int scoreReward = 2;

	[SerializeField]
	public float maxTimeGiven = 10f;

	[SerializeField]
	public float minTimeGiven = 3f;

	public abstract Task Create();

	public virtual void OnTaskSuccess(Task task) {
		Debug.Log("On Task Success.");
		GameManager.instance.timeRemaining += (task.TimeGiven / 2.69f);
		GameManager.instance.currentScore++;
		TaskManager.instance.RemoveTask(task);
        GameManager.instance.cameraController.panelController.SwitchTask(-1,null);
	}

	public virtual void OnTaskFailure(Task task) {
        Debug.Log("On Task Failure.: " + task);
       
        if (GameManager.instance.cameraController.panelController.currentTask == task)
            GameManager.instance.cameraController.panelController.SwitchTask(-1, null);

        TaskManager.instance.RemoveTask(task);
    }
}
