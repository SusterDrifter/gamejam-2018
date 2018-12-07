using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

#region Singleton Pattern
	static object _lock = new object();

    private static GameManager _gameManager;

    public static GameManager instance
    {
        get
        {
            if (_gameManager == null)
            {
                lock (_lock)
                    if (_gameManager == null)
                        _gameManager = new GameManager();
            }
            return _gameManager;
        }
    }
	#endregion

	private int currentStageIndex = 0;

	private int stageGap = 10;

	private int _currentScore;

	public int currentScore {
		get {
			return _currentScore;
		}
		set {
			_currentScore = value;
			if (HUDCanvasManager.instance.ScoreText) {
				HUDCanvasManager.instance.ScoreText.text = _currentScore.ToString();
			}
		}
	}

	[SerializeField]
	private List<StageSO> stagesList;

	[SerializeField]
	private float _timeRemaining;

	[SerializeField]
	public float timeRemaining {
		get {
			return _timeRemaining;
		}
		set {
			_timeRemaining = value;
			if (HUDCanvasManager.instance.TimeLeftText) {
				HUDCanvasManager.instance.TimeLeftText.text = _timeRemaining.ToString("n0");
			}
		}
	}

	[SerializeField]
	float _startingTime = 60f;

	[SerializeField]
	private bool isPaused = true;

	public CameraController cameraController;

	private void Awake()
    {
        if (!_gameManager)
        {
            _gameManager = FindObjectOfType<GameManager>();
            if (_gameManager)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        if (instance == null)
        {
            _gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(gameObject);
        }

		cameraController = Camera.main.GetComponent<CameraController>();
    }

	// Use this for initialization
	void Start () {
		_timeRemaining = _startingTime;
		HUDCanvasManager.instance.ScoreText.text = currentScore.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }

		if (isPaused)
			return;
		
		_timeRemaining -= Time.deltaTime;

		if (_timeRemaining <= 0) {
			GameOver();
		}
	}

	public List<TaskSO> GetCurrentStageTasks() {
		return new List<TaskSO>();
	}

	public void StartGame() {
		isPaused = false;
		TaskManager.instance.StartStage(stagesList[currentStageIndex]);
	}

	public void NextStage() {
		TaskManager.instance.FlushTaskManager();
		currentStageIndex++;
        // maybe start
	}

	public void GameOver() {
		Debug.Log("GameOver called.");
	}

	public void GoToNextAvailableTask() {
		List<Task> tasks = TaskManager.instance.ongoingTasks;

		float min = float.MaxValue;
		ShipPanel desired = ShipPanel.Default;
        foreach (var item in tasks)
		{
			if (item.TimeRemaining < min) {
				min = item.TimeRemaining;
				desired = item.taskPanel;
			}
		}
		cameraController.JumpToShipPanel(desired);
	}

}
