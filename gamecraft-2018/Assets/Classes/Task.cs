using UnityEngine;

public abstract class Task {

	protected TaskSO taskSO;

	[SerializeField]
	protected float timeRemaining = 5.0f;

	[SerializeField]
	protected float timeGiven = 5.0f;

    public virtual void InitTaskWithTaskSO(TaskSO so) {
		taskSO = so;
	}
    
	public virtual void Start() {
		
	}

	public virtual void Update() {
		timeRemaining -= Time.deltaTime;
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

    public float TimeRemaining { get { return timeRemaining; } }
    public float TimeGiven { get { return timeGiven; } }
}
