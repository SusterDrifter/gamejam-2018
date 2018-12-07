using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Task ScriptableObjects/Shooting")]
public class ShootingTaskSO : TaskSO {

    [SerializeField]
    public float timeToCharge = 5f;
    [SerializeField]
    public float totalPossibleCharge = 8f;

    public override Task Create()
    {
		ShootingTask task = new ShootingTask();
		task.InitTaskWithTaskSO(this);
		task.taskPanel = ShipPanel.Weapons;
		return task;
    }

	public override void OnTaskSuccess(Task task)
    {
		base.OnTaskSuccess(task);
    }
}