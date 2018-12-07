using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorTask : Task {

    public string questionText = "What is 5 + 5?";
    public int correctAnswer = 10;

	public override void InitTaskWithTaskSO(TaskSO so) {
		base.InitTaskWithTaskSO(so);
	}

    public CalculatorTask(int correctAnswer, string questionText, float timeGiven) {
        this.timeGiven = timeGiven;
        this.timeRemaining = timeGiven;
        this.correctAnswer = correctAnswer;
        this.questionText = questionText;
    }

	// Use this for initialization
	void Start () {
        // TODO
	}
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
    }
}
