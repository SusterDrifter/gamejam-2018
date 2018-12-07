using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDCanvasManager : MonoBehaviour {

	#region Singleton
	static object _lock = new object();

    private static HUDCanvasManager _hudCanvasManager;

    public static HUDCanvasManager instance
    {
        get
        {
            if (_hudCanvasManager == null)
            {
                lock (_lock)
                    if (_hudCanvasManager == null)
                        _hudCanvasManager = new HUDCanvasManager();
            }
            return _hudCanvasManager;
        }
    }
	#endregion

	public CanvasGroup TasksCanvasGroup; 

	private void Awake()
    {
        if (!_hudCanvasManager)
        {
            _hudCanvasManager = FindObjectOfType<HUDCanvasManager>();
            if (_hudCanvasManager)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        if (instance == null)
        {
            _hudCanvasManager = this;
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
		
	}
}
