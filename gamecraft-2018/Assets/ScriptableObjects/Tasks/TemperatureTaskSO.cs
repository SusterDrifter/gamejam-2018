using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Task ScriptableObjects/Temperature")]
public class TemperatureTaskSO : TaskSO {
    [SerializeField]
    public float RateOfChange = 1f;
    [SerializeField]
    public float StartingTemperature = 32.5f;
    public float TargetMin = 40f;
    public float TargetMax = 45f;

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

