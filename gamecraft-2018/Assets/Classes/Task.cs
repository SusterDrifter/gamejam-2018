using UnityEngine;

public abstract class Task {

	[SerializeField]
	private float timeRemaining;

	[SerializeField]
	private float timeGiven;

	public abstract void InitTaskWithTaskSO(TaskSO so);

	public void Update() {
		timeRemaining += Time.deltaTime;
	}

	private bool checkIfTaskExpire() {
		if (timeRemaining <= 0) {
			return false;
		}

		return true;
	}
}
