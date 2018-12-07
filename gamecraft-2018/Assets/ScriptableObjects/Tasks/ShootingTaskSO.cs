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
		return new ShootingTask();
    }

	public override void OnTaskSuccess(Task task)
    {
		base.OnTaskSuccess(task);
    }
}