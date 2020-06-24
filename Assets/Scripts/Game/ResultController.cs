using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[System.Serializable]
public enum TResult
{
    Correct,
    Wrong
}

public class ResultController : MonoBehaviour
{
    public delegate void GoToNextTask();
    public static GoToNextTask OnGoToNextTask;

    public TResult result;

    private void OnEnable()
    {
        BttnController.OnShowResultTitle += Show;
    }

    private void OnDisable()
    {
        BttnController.OnShowResultTitle -= Show;
    }

    private void Show(TResult _result)
    {
        if (result == _result)
        {
            transform.DOScale(Vector3.one, 0.5f).OnComplete(() =>
            {
                DOVirtual.DelayedCall(1.5f, ()=>
                {
                    transform.localScale = Vector3.zero;

                    OnGoToNextTask?.Invoke();
                });
            });
        }
    }
}
