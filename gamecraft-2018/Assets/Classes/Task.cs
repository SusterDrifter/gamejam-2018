﻿using UnityEngine;

[System.Serializable]
public class Task {

	public ShipPanel taskPanel;

	protected TaskSO taskSO;

	[SerializeField]
	protected float timeRemaining = 5.0f;

	[SerializeField]
    protected float timeGiven = 5.0f;

	[SerializeField]
	public int scoreReward = 1;

    public float TimeGiven {
		get { return timeGiven; }
	}

	public float TimeRemaining { get { return timeRemaining; } }
    
	public TaskSO TaskSO {
		get { return taskSO; }
	}

	public TaskCellController cellController;

    public virtual void InitTaskWithTaskSO(TaskSO so) {
		taskSO = so;
		scoreReward = so.scoreReward;
		this.timeGiven = Random.Range(so.minTimeGiven, so.maxTimeGiven);
		timeRemaining = TimeGiven;
	}
    
	public virtual void Start() {
		
	}

	public virtual void Update() {
		timeRemaining -= Time.deltaTime;
		if (timeRemaining <= 0) {
			OnTaskExpire();
		}
		UpdateCell();
	}

	public virtual void UpdateCell() {
		if (cellController)
        {
            cellController.timerSlider.value = timeRemaining;
        }
	}

	public virtual void OnTaskSuccess() {
		if (taskSO)
		    taskSO.OnTaskSuccess(this);
	}

	public virtual void OnTaskExpire() {
		if (taskSO)
		    taskSO.OnTaskFailure(this);
	}

	public virtual void OnTaskFocused() {
		
	}

	public virtual void OnTaskUnfocused() {
		
	}

	private bool checkIfTaskExpire() {
		if (timeRemaining <= 0) {
			return false;
		}

		return true;
	}

    
}
