using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperatureTask : Task {

    public bool Solved;

    public float RateOfChange = 1f;
    public float CurrentTemp = 32.5f;
    public float TargetMin = 40f;
    public float TargetMax = 45f;

	public override void InitTaskWithTaskSO(TaskSO so)
    {
		base.InitTaskWithTaskSO(so);
        RateOfChange = ((TemperatureTaskSO)so).RateOfChange;
        CurrentTemp = ((TemperatureTaskSO)so).StartingTemperature;
        TargetMin = ((TemperatureTaskSO)so).TargetMin;
        TargetMax = ((TemperatureTaskSO)so).TargetMax;
        
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
        CurrentTemp += RateOfChange * Time.deltaTime;
        if (CurrentTemp >= 50 || CurrentTemp <= 15) {
            RateOfChange *= -1;
        }
        base.Update();
	}
}
