﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Task ScriptableObjects/Temperature")]
public class TemperatureTaskSO : TaskSO {

    public override Task Create()
    {
		return new TemperatureTask();
    }

	public override void OnTaskSuccess(Task task)
    {
		base.OnTaskSuccess(task);
    }

}

