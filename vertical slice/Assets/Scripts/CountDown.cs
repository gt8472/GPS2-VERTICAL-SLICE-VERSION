using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{

    public int TotalTime = 12;
    public Text TimeText;
    CanvasGroup canvasGroup;
    private int mumite;
    private int second;

    void Start()
    {
        StartCoroutine(StartTime());
        canvasGroup = GetComponentInChildren<CanvasGroup>();
        StartCoroutine(Close());
    }

    public IEnumerator StartTime()
    {
        while (TotalTime >= 0)
        {
            yield return new WaitForSeconds(1);
            TotalTime--;
            TimeText.text = "Time:" + TotalTime;

            mumite = TotalTime / 60;

            second = TotalTime % 60;

            string length = mumite.ToString();
            if (second >= 10)
            {
                TimeText.text = "0" + mumite + ":" + second;
            }
            else
                TimeText.text = "0" + mumite + ":0" + second;
        }
    }

    public IEnumerator Close()
    {
        while (TotalTime >= 0)
        {
            yield return new WaitForSeconds(1);
            if (TotalTime <= 0)
            {
                GetComponent<CanvasGroup>().alpha = 0;
                GetComponent<CanvasGroup>().interactable = false;
                GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }
    }
}