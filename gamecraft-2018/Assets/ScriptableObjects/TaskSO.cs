using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskSO : ScriptableObject {

	public string taskName;

	[SerializeField]
	public float maxTimeGiven = 10f;

	[SerializeField]
	protected float minTimeGiven = 3f;

	public abstract Task Create();

	public virtual void OnTaskSuccess(Task task) {
		//default stuff
	}

	public virtual void OnTaskFailure(Task task) {
		
	}

}
