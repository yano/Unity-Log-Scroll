using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogContent : MonoBehaviour
{
	[SerializeField] private Text _text;
	[SerializeField] private float _duration = 3.0f;
	
	private void Awake()
	{
		Debug.Assert(_text!=null, "_text!=null", transform);
	}
	
	public void SetText(string logText, Color color)
	{
		_text.text = logText;
		_text.color = color;
		StartCoroutine(Routine());
	}

	private IEnumerator Routine()
	{		
		yield return new WaitForSeconds(_duration);		
		_text.CrossFadeAlpha(0.0f, 1.0f, true);
		yield return new WaitForSeconds(1.0f);
		Destroy(gameObject);		
	}
}
