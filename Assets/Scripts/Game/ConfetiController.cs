using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfetiController : MonoBehaviour
{
    ParticleSystem particle;

    private void OnEnable()
    {
        BttnController.OnShowResultTitle += Show;
    }

    private void OnDisable()
    {
        BttnController.OnShowResultTitle -= Show;
    }

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void Show(TResult _result)
    {
        if (_result == TResult.Correct)
        {
            particle.Play();
        }
    }
}
