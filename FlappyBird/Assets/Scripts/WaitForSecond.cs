using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaitForSecond : MonoBehaviour
{
    [SerializeField] private UnityEvent OnComplete;
    public void Wait(float seconds)
    {
        StartCoroutine(IEWaitForSecond(seconds));
    }
    private IEnumerator IEWaitForSecond(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if(OnComplete != null)
        {
            OnComplete.Invoke();
        }
    }
}
