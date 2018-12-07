using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Task ScriptableObjects/Signoff")]
public class SignOffTaskSO : TaskSO {

    public override Task Create()
    {
		SignOffTask task = new SignOffTask();
        task.InitTaskWithTaskSO(this);
        return task;
    }

	public override void OnTaskSuccess(Task task)
    {
		base.OnTaskSuccess(task);
    }

}
