using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    private Animator _animator;

    private static readonly Dictionary<Sign, string> Triggers = new Dictionary<Sign, string>
    {
        { Sign.Meet, "Meet" },
        { Sign.Name, "Name" },
        { Sign.Nice, "Nice" },
        { Sign.Clean, "Nice" },
        { Sign.No, "No" },
        { Sign.Understand, "Understand" },
        { Sign.Love, "Love" }
    };

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void PlaySign(Sign sign)
    {
        Debug.Log($"playing {Triggers[sign]}");
        _animator.SetTrigger(Triggers[sign]);
    }
}
