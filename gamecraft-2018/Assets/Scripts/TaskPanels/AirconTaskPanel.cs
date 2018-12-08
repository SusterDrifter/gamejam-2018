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

	public AudioClip tempColdButtonSound;
	public AudioClip tempHotButtonSound;

    // Use this for initialization
    public override void Start()
    {
        task = (TemperatureTask)panelController.currentTask;

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
                TempBar.color = Color.white;
            } else {
                TempBar.color = new Vector4(0.9f,0.9f,0.9f,0.9f); 
            }
        }
    }

    public override void Display()
    {

    }

    public void LeftButtonPressed()
    {
		HUDCanvasManager.instance.audioSource.PlayOneShot(tempColdButtonSound);
        if (task.RateOfChange > 0) {
            task.RateOfChange *= -1;
        }
    }
    public void RightButtonPressed()
    {
		HUDCanvasManager.instance.audioSource.PlayOneShot(tempHotButtonSound);
        if (task.RateOfChange < 0) {
            task.RateOfChange *= -1;
        }
    }
    public void StopButtonPressed()
    {
        if (task.TargetMin <= task.CurrentTemp && task.CurrentTemp <= task.TargetMax) {
            task.Solved = true;
            task.OnTaskSuccess();
        }
    }
}
