using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TaskPanel : MonoBehaviour {
    [SerializeField]
    public TaskStub task;

    public abstract void Display();

}
