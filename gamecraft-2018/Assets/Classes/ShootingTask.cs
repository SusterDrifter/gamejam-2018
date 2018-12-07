using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTask : Task {

    public bool Destroyed;
    public float timeToCharge;
    public float timeCharged;
    public float totalChargableTime;
    public bool isCharging;

	public override void InitTaskWithTaskSO(TaskSO so)
    {
		base.InitTaskWithTaskSO(so);
        ShootingTaskSO stso = (ShootingTaskSO)so;
        timeToCharge = stso.timeToCharge;
        totalChargableTime = stso.totalPossibleCharge;
        timeCharged = 0f;
        timeGiven = stso.maxTimeGiven;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
        if (isCharging) {
            timeCharged += Time.deltaTime;
        }

        base.Update();
	}

}
