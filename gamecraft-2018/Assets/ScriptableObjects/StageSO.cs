using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stage")]
public class StageSO : ScriptableObject {

	public float timeBetweenTaskAdd;

	public int numOfTasks = 10;

	public List<TaskSO> tasks;

}
