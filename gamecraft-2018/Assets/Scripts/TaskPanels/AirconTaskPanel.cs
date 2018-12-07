using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirconTaskPanel : TaskPanel
{

    public const float MIN_TEMP = 15f, MAX_TEMP = 50f;

    public Image TimerImage;
    public Button StopButton;
    public Button LeftButton;
    public Button RightButton;
    public Image TempBar;
    public Slider SliderMin;
    public Slider SliderMax;

    public TemperatureTask task;

    public TaskSO t;


    // Use this for initialization
    void Start()
    {
        GameManager.instance.StartGame();
        task = (TemperatureTask)TaskManager.instance.AddTaskWithSO(t);

        TempBar.fillAmount = (task.CurrentTemp - MIN_TEMP) / 35;
        SliderMin.value = task.TargetMin;
        SliderMax.value = task.TargetMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (!task.Solved)
        {
            TimerImage.fillAmount = task.TimeRemaining / task.TimeGiven;
            TempBar.fillAmount = (task.CurrentTemp - MIN_TEMP) / 35;
            if (task.TargetMin <= task.CurrentTemp && task.CurrentTemp <= task.TargetMax) {
                TempBar.color = Color.green;
            } else {
                TempBar.color = Color.red;
            }
        }
    }

    public override void Display()
    {

    }

    public void LeftButtonPressed()
    {
        if (task.RateOfChange > 0) {
            task.RateOfChange *= -1;
        }
    }
    public void RightButtonPressed()
    {
        if (task.RateOfChange < 0) {
            task.RateOfChange *= -1;
        }
    }
    public void StopButtonPressed()
    {
        if (task.TargetMin <= task.CurrentTemp && task.CurrentTemp <= task.TargetMax) {
            task.Solved = true;
        }
    }
}
