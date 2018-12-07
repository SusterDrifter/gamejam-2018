using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour {
	
#region Singleton
	static object _lock = new object();

    private static TaskManager _taskManager;

    public static TaskManager instance
    {
        get
        {
            if (_taskManager == null)
            {
                lock (_lock)
                    if (_taskManager == null)
                        _taskManager = new TaskManager();
            }
            return _taskManager;
        }
    }
	#endregion
   
	Coroutine taskAddCoroutine;

	StageSO currentStage;

	private void Awake()
    {
        if (!_taskManager)
        {
            _taskManager = FindObjectOfType<TaskManager>();
            if (_taskManager)
            {
                //DontDestroyOnLoad(gameObject);
            }
        }
        if (instance == null)
        {
            _taskManager = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(gameObject);
        }
    }
    
	public List<Task> ongoingTasks = new List<Task>();

	[SerializeField]
	private int maxTasks;
    
	[SerializeField]
	GameObject taskCellPrefab;

	public Task AddTaskWithSO(TaskSO so) {
		if (ongoingTasks.Count >= maxTasks)
			return null;
		Task task = so.Create();
        task.InitTaskWithTaskSO(so);
        ongoingTasks.Add(task);
		GameObject cell = Instantiate(taskCellPrefab, HUDCanvasManager.instance.TasksCanvasGroup.transform);
		TaskCellController controller = cell.GetComponent<TaskCellController>();
		task.cellController = controller;
		controller.taskNameText.text = so.taskName;
		controller.timerSlider.maxValue = task.TimeGiven;
		controller.timerSlider.value = task.TimeRemaining;
		//controller.hotkeyText = "";

        return task;
	}

	public void RemoveTask(Task task) {
		
		ongoingTasks.Remove(task);
		Destroy(task.cellController.gameObject);
	}
    
	IEnumerator _TaskAddCoroutine(StageSO stage)
    {
		currentStage = stage;
		float runningTime = 0;

		while (true) {
			runningTime += Time.deltaTime;

			if (runningTime >= 1/stage.timeBetweenTaskAdd) {
				AddTaskWithSO(getRandomTaskSO());
				runningTime = 0;
			}

			yield return null;
		}

    }

	public void StartStage(StageSO stage) {
		FlushTaskManager();
		StartTaskAddCoroutine(stage);
	}

	private void StartTaskAddCoroutine(StageSO stage) {
		taskAddCoroutine = StartCoroutine(_TaskAddCoroutine(stage));
	}

	public void FlushTaskManager() {
		if (taskAddCoroutine != null)
		{
			StopCoroutine(taskAddCoroutine);
		}
		taskAddCoroutine = null;
		// maybe iterate through ongoingTasks to clear them up properly.
		ongoingTasks.ForEach((Task obj) => { if (obj.cellController) { 
				Destroy(obj.cellController.gameObject); 
			} 
		});
		ongoingTasks.Clear();
	}

	private TaskSO getRandomTaskSO() {
		List<TaskSO> tasks = currentStage.tasks;

		if (tasks.Count <= 0) {
			return null;
		}

		return tasks[Random.Range(0, tasks.Count)];
	}

	private void Update()
	{
		ongoingTasks.ForEach((Task obj) => obj.Update());
	}

}
