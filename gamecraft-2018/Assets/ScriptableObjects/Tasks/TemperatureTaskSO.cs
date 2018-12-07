using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Task ScriptableObjects/Temperature")]
public class TemperatureTaskSO : TaskSO {

    public override Task Create()
    {
		TemperatureTask task = new TemperatureTask();
        task.InitTaskWithTaskSO(this);
        return task;
    }

	public override void OnTaskSuccess(Task task)
    {
		base.OnTaskSuccess(task);
    }

}

