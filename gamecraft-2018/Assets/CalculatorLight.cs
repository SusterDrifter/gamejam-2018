using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CalculatorLight : MonoBehaviour {

	[SerializeField]
	SpriteRenderer renderer;
    
	private void Awake()
	{
		renderer = GetComponent<SpriteRenderer>();
	}
    
	private void Start()
	{
		fadeOut();
	}

	void fadeIn() {
		renderer.DOFade(0.2f, 1.0f).OnComplete(() => fadeOut());
	}

	void fadeOut() {
		renderer.DOFade(0.0f, 1.0f).OnComplete(() => fadeIn());
	}

}
