using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour {

    public enum TimerType { Duration, Countdown };
    public enum TimerState { Stopped, Running, Paused, Finished }

    public TimerType timerType = TimerType.Countdown;
    [HideInInspector]
    public TimerState timerState = TimerState.Stopped;

    public UnityEngine.Events.UnityEvent onTimeOver, onTimeStopped;

    public float startTime = 120;
    public bool autoStart = false;

    public List<UnityEngine.UI.Text> timeUI;

    private float currentTime = 0;

	// Use this for initialization
	void Start () {
        Reset();

        if (autoStart)
            StartTimer();
	}
	
    public void StartTimer ()
    {
        StartCoroutine(RunTimer(startTime));
    }

    public void StartTimer(float startTime)
    {
        StartCoroutine(RunTimer(startTime));
    }

    public void StopTimer ()
    {
        if (timerState != TimerState.Stopped)
            onTimeStopped.Invoke();

        timerState = TimerState.Stopped;
    }

    public void Reset()
    {
        Reset(startTime);
    }

    public void Reset (float startTime)
    {
        timerState = TimerState.Stopped;

        currentTime = startTime;
        this.startTime = startTime;

        UpdateUI();
    }

    public void TogglePauseTimer ()
    {
        if (timerState == TimerState.Running)
            timerState = TimerState.Paused;
        else if (timerState == TimerState.Paused)
            timerState = TimerState.Running;

    }

    public float GetTime ()
    {
        return currentTime;
    }

    private IEnumerator RunTimer (float startTime)
    {
        timerState = TimerState.Running;
        currentTime = startTime;
        UpdateUI();

        while (timerState == TimerState.Running || timerState == TimerState.Paused)
        {
            yield return new WaitForEndOfFrame();
            if (timerState != TimerState.Paused)
            {
                IncrementTimer();
            }

            if (timerType == TimerType.Countdown && currentTime <= 0)
            {
                timerState = TimerState.Finished;
                onTimeOver.Invoke();
            }
            UpdateUI();
        }

    }
	
    private void IncrementTimer ()
    {
        if (timerType == TimerType.Countdown)
        {
            currentTime -= Time.deltaTime;
        }
        else if (timerType == TimerType.Duration)
        {
            currentTime += Time.deltaTime;
        }
    }

    private void UpdateUI ()
    {
        foreach (UnityEngine.UI.Text t in timeUI)
        {
            t.text = currentTime.ToString ("0.00");
        }
    }

}
