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

	public int currentScore = 0;

	[SerializeField]
	private List<StageSO> stagesList;

	[SerializeField]
	private float _timeRemaining;

	[SerializeField]
	float _startingTime;

	[SerializeField]
	private bool isPaused = true;

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
    }

	// Use this for initialization
	void Start () {
		
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
		
	}

}
