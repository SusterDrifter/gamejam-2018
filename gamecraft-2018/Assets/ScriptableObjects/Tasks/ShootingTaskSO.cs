using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Task ScriptableObjects/Shooting")]
public class ShootingTaskSO : TaskSO {

    [SerializeField]
    public float timeToCharge = 5f;

    public override Task Create()
    {
		ShootingTask task = new ShootingTask();
		task.InitTaskWithTaskSO(this);
		return task;
    }

	public override void OnTaskSuccess(Task task)
    {
		base.OnTaskSuccess(task);
    }
}