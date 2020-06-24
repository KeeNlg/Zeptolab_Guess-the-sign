using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HandController : MonoBehaviour
{
    [Header("Аніматор контроллер")]
    Animator animator;

    Tween twn;

    private void OnEnable()
    {
        GameController.OnSetAnimation += SetAnimation;

        BttnController.OnResult += StopAnimation;
    }

    private void OnDisable()
    {
        GameController.OnSetAnimation -= SetAnimation;

        BttnController.OnResult -= StopAnimation;
    }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void SetAnimation(TAnswer answer)
    {
        animator.SetTrigger(answer.ToString());

        twn = DOVirtual.DelayedCall(7, ()=>
        {
            SetAnimation(answer);
        });
    }

    private void StopAnimation(bool isCorrect)
    {
        if (twn != null)
        {
            twn.Kill();

            twn = null;
        }
    }
}
