using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskSO : ScriptableObject {

	[SerializeField]
	protected float maxTimeGiven = 10f;

	[SerializeField]
	protected float minTimeGiven = 3f;

	public abstract Task Create();

}
