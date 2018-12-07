using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculatorTask : Task {

	public string questionText = "What is \\n\\n{0} + {1}?";
    public int correctAnswer = 10;

	public int operand1;
	public int operand2;

	public string op = "";

	public override void InitTaskWithTaskSO(TaskSO so) {
		base.InitTaskWithTaskSO(so);
	}

    public CalculatorTask(int correctAnswer, string questionText, float timeGiven) {
        this.timeGiven = timeGiven;
        this.timeRemaining = timeGiven;
        this.correctAnswer = correctAnswer;
        this.questionText = questionText;
    }
	
	// Update is called once per frame
	public override void Update () {
        base.Update();
    }
}
