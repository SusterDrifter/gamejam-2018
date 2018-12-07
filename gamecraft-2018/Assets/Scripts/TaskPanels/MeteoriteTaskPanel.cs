using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteoriteTaskPanel : TaskPanel {

    public bool Charged = false;

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
    void Start () {
        GameManager.instance.StartGame();
        task = (ShootingTask)TaskManager.instance.AddTaskWithSO(t);
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
                    Charged = true;
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
        if (Charged) {
            task.Solved = true;
            StatusBar.color = Color.green;
        }
    }
}
