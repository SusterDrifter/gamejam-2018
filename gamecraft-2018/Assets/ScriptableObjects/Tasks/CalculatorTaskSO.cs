using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Task ScriptableObjects/Calculator")]
public class CalculatorTaskSO : TaskSO {

	public override Task Create()
	{
		return new CalculatorTask();
	}

	public override void OnTaskSuccess()
	{
		base.OnTaskSuccess();
	}

}
