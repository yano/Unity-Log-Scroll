using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AdvancedInspector;

public class SingletonLogScroll : SingletonLogScrollBase<SingletonLogScroll>
{
    [SerializeField] private GameObject _logContentPrefab;
    [SerializeField] private RectTransform _content;

    void Awake()
    {
        Debug.Assert(_logContentPrefab != null, "_logContentPrefab != null", transform);
        Debug.Assert(_content != null, "_content != null", transform);
    }

    #region interface関数

    public void SetLogText(string logText, Color color)
    {
        GameObject logContentObj = GameObject.Instantiate(_logContentPrefab);
        logContentObj.SetActive(true);

        LogContent logContent = logContentObj.GetComponent<LogContent>();
        logContent.SetText(logText, color);
        logContent.transform.SetParent(_content, false);
    }

    #endregion

    [Inspect(100)]
    private void TestSetLogText()
    {
        string logText = "薬草を手に入れた！";
        Color color = Color.black;

        GameObject logContentObj = GameObject.Instantiate(_logContentPrefab);
        logContentObj.SetActive(true);

        LogContent logContent = logContentObj.GetComponent<LogContent>();
        logContent.SetText(logText, color);
        logContent.transform.SetParent(_content, false);
    }
}
