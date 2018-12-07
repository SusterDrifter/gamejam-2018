using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TaskCellController : MonoBehaviour {

	[SerializeField]
	public Image backgroundImage;

	[SerializeField]
	public Slider timerSlider;

	[SerializeField]
	public Text taskNameText;

	[SerializeField]
	public Text hotkeyText;

	public void SetupWithTask(Task task) {
		timerSlider.maxValue = task.TimeGiven;
		//backgroundImage.sprite = ;
		taskNameText.text = task.TaskSO.taskName;
	}

}
