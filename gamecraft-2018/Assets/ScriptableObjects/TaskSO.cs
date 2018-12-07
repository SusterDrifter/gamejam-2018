﻿using System.Collections;
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
		Debug.Log("On Task Failure.");
		GameManager.instance.currentScore++;
		TaskManager.instance.RemoveTask(task);
		GameManager.instance.GoToNextAvailableTask();
	}

	public virtual void OnTaskFailure(Task task) {
		Debug.Log("On Task Failure.");
		GameManager.instance.timeRemaining += task.TimeGiven;
		TaskManager.instance.RemoveTask(task);
	}

}
