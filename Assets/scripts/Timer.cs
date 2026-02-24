using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
[SerializeField]
private SecondData[] secondsData;
[SerializeField]
private Image timerImage;
[SerializeField]
private string timerAnimationName;
[SerializeField]
private UnityEvent onTimerEnd;
private Animator timerAnimator;
private Coroutine timerCoroutine;
private void Awake()
    {
        timerAnimatorAnimator = timerImage.GetComponent<timerAnimator>();
    }
    public void StartTimer(int duration)
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
        }
        timerCoroutine = StartCoroutine(TimerCoroutine(duration));
    }
    private IEnumerator TimeCoroutine(int duration)
    {
        for (int i = 0; i < duration; i++)
        {
            SoundManager.instance.Play (secondsDataData[i].soundName);
            timerImage.sprite = secondsData[i].image;
            timerAnimator.Play(timeAnimationName, 0, 0f);
            yield return new WaitForSeconds(1f);
        }
        onTimerEnd?.Invoke();
    }
    public void StopTimer()
    {
        if (timerCoroutine != null)
        {
            StopCoroutine(timerCoroutine);
            timerCoroutine = null;
        }
    }
}

[System.Serializable]
public class SecondData
{
    public string soundName;
    public Sprite image;
}
