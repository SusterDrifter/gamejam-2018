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

	public Image colourCodeImage;

	public void SetupWithTask(Task task) {
		timerSlider.maxValue = task.TimeGiven;
		//backgroundImage.sprite = ;
		taskNameText.text = task.TaskSO.taskName;
		switch (task.taskPanel) {
			case ShipPanel.Calculator:
				colourCodeImage.color = Color.green;
				break;
			case ShipPanel.Signature:
				colourCodeImage.color = Color.magenta;
				break;
			case ShipPanel.Weapons:
				colourCodeImage.color = Color.red;
				break;
			case ShipPanel.Thermostat:
				colourCodeImage.color = Color.blue;
				break;
			case ShipPanel.Default:
				colourCodeImage.color = Color.white;
				break;
		}
	}

}
