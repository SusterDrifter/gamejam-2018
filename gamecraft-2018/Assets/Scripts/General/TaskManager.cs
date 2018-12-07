using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour {

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
	private List<Task> ongoingTasks;

	[SerializeField]
	private int maxTasks;

	public void AddTaskWithSO(TaskSO so) {
		Task task = so.Create();

		ongoingTasks.Add(task);
	}

	public void CompleteTask(Task task) {
		
	}

	private void Update()
	{
		ongoingTasks.ForEach((Task obj) => obj.Update());
	}
}
