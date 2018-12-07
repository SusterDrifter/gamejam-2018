using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskSO : ScriptableObject {

	public string taskName;

	[SerializeField]
	private float maxTimeGiven = 10f;

	[SerializeField]
	private float minTimeGiven = 3f;

	public abstract Task Create();

	public virtual void OnTaskSuccess() {
		//default stuff
	}

}
