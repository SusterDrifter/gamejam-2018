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
                DontDestroyOnLoad(gameObject);
            }
        }
        if (instance == null)
        {
            _taskManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(gameObject);
        }
    }

	[SerializeField]
	private List<Task> ongoingTasks = new List<Task>();

	[SerializeField]
	private int maxTasks;

	public void AddTaskWithSO(TaskSO so) {
		Task task = so.Create();

		ongoingTasks.Add(task);
	}

	public void CompleteTask(Task task) {
		ongoingTasks.Remove(task);
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

        yield return null;
    }

	public void StartStage(StageSO stage) {
		StartTaskAddCoroutine(stage);
	}

	private void StartTaskAddCoroutine(StageSO stage) {
		taskAddCoroutine = StartCoroutine(_TaskAddCoroutine(stage));
	}

	public void FlushTaskManager() {
		StopCoroutine(taskAddCoroutine);
		taskAddCoroutine = null;
        // maybe iterate through ongoingTasks to clear them up properly.
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
