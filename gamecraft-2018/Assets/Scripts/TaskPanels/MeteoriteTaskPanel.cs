using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteoriteTaskPanel : TaskPanel {


    public Image TimerImage;
    public Button button;
    public Image StatusBar;
    public Image StatusBarPartial;
    public Image MeteorImage;

    public float maxScale = 4.5f;

    public ShootingTask task;

    public TaskSO t;

    public override void Display()
    {
    }

    // Use this for initialization
    public override void Start () {
        task = (ShootingTask)PanelController.GetInstance().currentTask;
        StatusBar.fillAmount = 0f;
        StatusBarPartial.fillAmount = task.timeToCharge / task.totalChargableTime;
    }
	
	// Update is called once per frame
	void Update () {
        if (task.TimeRemaining <= 0) MeteorImage.enabled = false;

        if (!task.Solved) {
            MeteorImage.transform.localScale = Vector3.one * (1 - task.TimeRemaining / task.TimeGiven) * maxScale;

            TimerImage.fillAmount = task.TimeRemaining / task.TimeGiven;

            if (task.isCharging) {
                if (task.timeCharged >= task.timeToCharge) {
                    if (task.timeCharged > task.totalChargableTime) {
                        StatusBar.fillAmount = 1f;
                        task.isCharging = false;
                    } else {
                        StatusBar.fillAmount = task.timeCharged / task.totalChargableTime;
                    }
                    task.Charged = true;
                    StatusBar.color = Color.yellow;
                } else {
                    StatusBar.fillAmount = task.timeCharged / task.totalChargableTime;
                }
            } 

        }
        else {
            MeteorImage.enabled = false;
        }
    }

    public void PressButton() {
        if (!task.isCharging && !task.Solved) {
            task.isCharging = true;
        }
        if (task.Charged) {
            task.Solved = true;
            task.OnTaskSuccess();
            StatusBar.color = Color.green;
        }
    }
}
