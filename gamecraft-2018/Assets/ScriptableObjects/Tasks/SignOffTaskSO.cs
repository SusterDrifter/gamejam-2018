using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Task ScriptableObjects/Signoff")]
public class SignOffTaskSO : TaskSO {
    [SerializeField]
    public bool needApproval;
    [SerializeField]
    public float timeToApproveMin = 3f;
    [SerializeField]
    public float timeToApproveMax = 7f;

    public override Task Create()
    {
		SignOffTask task = new SignOffTask();
        task.InitTaskWithTaskSO(this);
		task.taskPanel = ShipPanel.Signature;
        return task;
    }

	public override void OnTaskSuccess(Task task)
    {
		base.OnTaskSuccess(task);
    }

}
