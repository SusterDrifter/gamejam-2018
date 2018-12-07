using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Stage")]
public class StageSO : ScriptableObject {

	public float timeBetweenTaskAdd;

	public List<TaskSO> tasks;

}
