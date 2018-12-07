using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculatorTaskPanel : TaskPanel {
    public const int ERASE = 10;
    public const int MAX_LENGTH = 4;


    public Image TimerImage;
    public Button[] Buttons;
    public Text QuestionText;
    public Text AnswerText;

    public CalculatorTask task;

	// Use this for initialization
	void Start () {
        GameManager.instance.StartGame();
        for (int i = 0; i < Buttons.Length; i++) {
            int j = i;
            Button b = Buttons[i];
            b.onClick.AddListener(() => this.PressButton(j));
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void Display() {

    }

    public void PressButton(int i) {
        if (i == ERASE) {
            if (AnswerText.text.Length == 0) return;
            AnswerText.text = AnswerText.text.Substring(0, AnswerText.text.Length - 1);
            return;
        }

        if (AnswerText.text.Length == MAX_LENGTH) return;

        AnswerText.text += i;
    }
}
