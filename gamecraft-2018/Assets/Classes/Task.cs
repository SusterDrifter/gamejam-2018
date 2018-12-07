using UnityEngine;

public abstract class Task {

	[SerializeField]
	private float timeRemaining;

	[SerializeField]
	private float timeGiven;

	public abstract void InitTaskWithTaskSO(TaskSO so);
    
	public virtual void Start() {
		
	}

	public virtual void Update() {
		timeRemaining -= Time.deltaTime;
	}

	public virtual void TaskExpire() {
		
	}

	public virtual void TaskFocused() {
		
	}

	private bool checkIfTaskExpire() {
		if (timeRemaining <= 0) {
			return false;
		}

		return true;
	}
}
