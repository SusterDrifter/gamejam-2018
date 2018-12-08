using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Task ScriptableObjects/Calculator")]
public class CalculatorTaskSO : TaskSO {
    public static int NO_ANSWER = -1000000;

    [SerializeField]
    public int correctAnswer = NO_ANSWER;
    [SerializeField]
    protected string questionText = "";

	public override Task Create()
    {
        CalculatorTask task = new CalculatorTask();
        task.InitTaskWithTaskSO(this);
        task.taskPanel = ShipPanel.Calculator;
        return task;
    }

    public override void OnTaskSuccess(Task task)
    {
		base.OnTaskSuccess(task);
    }


    public void GenerateQuestion(CalculatorTask task) {
        int x = (int)Random.Range(1, 10);
        int y = (int)Random.Range(1, 10);

        int rand = (int) Random.RandomRange(0, 3);
        string questionText; int correctAnswer;
        switch (rand) {
            case 0:
                correctAnswer = x + y;
                questionText = "What is\n\n" + x + " + " + y + "? ";
                break;
            case 1:
                correctAnswer = x * y;
                questionText = "What is\n\n" + x + " * " + y + "? ";
                break;
            case 2:
            default:

                if (x > y) {
                    int temp = x; x = y; y = temp;
                }
                correctAnswer = x - y;
                questionText = "What is\n\n" + x + " - " + y + "? ";
                break;
        }

        task.operand1 = x;
        task.operand2 = y;
        task.correctAnswer = correctAnswer;
        task.questionText = questionText;

    }

}
