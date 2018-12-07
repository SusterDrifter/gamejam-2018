using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Task ScriptableObjects/Shooting")]
public class ShootingTaskSO : TaskSO {

    public override Task Create()
    {
		return new ShootingTask();
    }

}