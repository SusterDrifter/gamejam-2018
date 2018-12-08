using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SigningTaskPanel : TaskPanel {

    char[] Dictionary;

    public Image TimerImage;
    public GameObject buttonParent;
    public Button[] inputButtons;
    public Button AllInOneButton;
    public Text InputText;
    public Text StatusText;
    public Text TodaysSignatureText;

    public GameObject ButtonPrefab;

    public SignOffTask task;

    public TaskSO t;


	public AudioClip signSendSound;

	public AudioClip signSymbolSound;

    public override void Display()
    {
    }

    // Use this for initialization
    public override void Start () {
        task = (SignOffTask)PanelController.GetInstance().currentTask;
        char[] arr = { 'a', 'b', 'c', 'd' };
        Dictionary = arr;

        inputButtons = new Button[5];
        for (int i = 0; i < 5; i++) {
            int j = i;
            inputButtons[i] = Instantiate(ButtonPrefab, buttonParent.transform).GetComponent<Button>();
            inputButtons[i].onClick.AddListener(() =>
            {
                ClickInputButton(j);
            });
        }
        InputText.text = "";
        TodaysSignatureText.text = TodaysSignature.GetInstance().signature;
        StatusText.text = "PLS SIGN";
    }
	
	// Update is called once per frame
	void Update () {
        if (!task.Solved)
        {
            TimerImage.fillAmount = task.TimeRemaining / task.TimeGiven;
            if (task.TimeRemaining <= 0) {
                StatusText.text = "LATE";
                return;
            }
            if (task.timeApprovedFor >= task.timeToApprove) {
                StatusText.text = "APPROVED";
            }
        }
    }

    public void ClickInputButton(int i) {
		HUDCanvasManager.instance.audioSource.PlayOneShot(signSymbolSound);
        if (!task.Signed) { // Input does nothing if it's already signed
            if (i == 4)
            {
                InputText.text = InputText.text.Substring(0, InputText.text.Length - 1);
                return;
            }
            InputText.text += Dictionary[i];
        }
    }

    public void ClickAllButton() {
        if (task.Solved) return; // Do nothing

        // Not yet signed
        if (InputText.text == task.todaysSignature && !task.Signed) {
            task.Signed = true;
            if (!task.needsApproving) {
                task.Solved = true;
                StatusText.text = "CLEARED";
				HUDCanvasManager.instance.audioSource.PlayOneShot(signSendSound);
                task.OnTaskSuccess();
            } else {
                task.isApproving = true;
                StatusText.text = "PENDING";
            }
        // Not yet approved
        } else if (task.Signed) {
            // Approved finish
            if (task.timeApprovedFor >= task.timeToApprove) {
                task.Solved = true;
                task.OnTaskSuccess();
				HUDCanvasManager.instance.audioSource.PlayOneShot(signSendSound);
                StatusText.text = "CLEARED";
            }
        }
    }
}
