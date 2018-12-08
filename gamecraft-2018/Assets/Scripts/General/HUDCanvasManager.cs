using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	public Text TimeLeftText;

	public Text ScoreText;

	public EndGameScreenController endGameScreenController;

	public Text StageNumberText;

	public CanvasGroup GameplayCanvasGroup;

	public CanvasGroup MainMenuCanvasGroup;

	public AudioClip clickSound;

	public AudioSource audioSource;

	private void Awake()
    {
        if (!_hudCanvasManager)
        {
            _hudCanvasManager = FindObjectOfType<HUDCanvasManager>();
            if (_hudCanvasManager)
            {
                //DontDestroyOnLoad(gameObject);
            }
        }
        if (instance == null)
        {
            _hudCanvasManager = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (instance != this)
                Destroy(gameObject);
        }

		audioSource = GetComponent<AudioSource>();
    }

	public void PlayClick() {
		audioSource.PlayOneShot(clickSound);
	}
}
