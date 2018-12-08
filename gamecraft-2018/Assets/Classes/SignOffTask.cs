using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignOffTask : Task {

    public bool Solved = false;

    public bool Signed;
    public float timeToApprove;
    public float timeApprovedFor;
    public bool isApproving;
    public bool needsApproving;
    public string todaysSignature;

    public override void InitTaskWithTaskSO(TaskSO so)
    {
		base.InitTaskWithTaskSO(so);
        needsApproving = ((SignOffTaskSO)so).needApproval;
        timeToApprove = Random.Range(((SignOffTaskSO)so).timeToApproveMin,
                                     ((SignOffTaskSO)so).timeToApproveMax);
        todaysSignature = TodaysSignature.GetInstance().signature;
        taskPanel = ShipPanel.Signature;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	public override void Update () {
        if (isApproving) {
            timeApprovedFor += Time.deltaTime;
        }
        base.Update();
	}
}
