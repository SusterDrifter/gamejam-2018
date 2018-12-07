using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTask : Task {

    public bool Destroyed;
    public float timeToCharge;
    public float timeCharged;

	public override void InitTaskWithTaskSO(TaskSO so)
    {
		base.InitTaskWithTaskSO(so);
        ShootingTaskSO stso = (ShootingTaskSO)so;
        timeToCharge = stso.timeToCharge;
        timeCharged = 0;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
