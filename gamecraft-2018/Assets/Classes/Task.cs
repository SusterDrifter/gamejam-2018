using UnityEngine;

public abstract class Task {

	protected TaskSO taskSO;

	[SerializeField]
	private float timeRemaining = 5.0f;

	[SerializeField]
	private float timeGiven = 5.0f;

	public float TimeGiven {
		get { return timeGiven; }
	}

	public float TimeRemaining { get { return timeRemaining; } }
    
	public TaskSO TaskSO {
		get { return taskSO; }
	}

	protected TaskCellController cellController;


    public virtual void InitTaskWithTaskSO(TaskSO so) {
		taskSO = so;
	}
    
	public virtual void Start() {
		
	}

	public virtual void Update() {
		timeRemaining -= Time.deltaTime;
	}

	public virtual void UpdateCell() {
		if (cellController)
        {
            cellController.timerSlider.value = timeRemaining;
        }
	}

	public virtual void TaskExpire() {
		
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
