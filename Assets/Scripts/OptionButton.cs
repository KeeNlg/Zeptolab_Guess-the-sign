using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    public Texture DefaultButton;
    public Texture RedButton;
    public Texture GreenButton;

    private RawImage _rawImage;

    private void Awake()
    {
        _rawImage = GetComponent<RawImage>();
    }

    private void Start()
    {
        SetDefault();
    }

    public void SetDefault()
    {
        _rawImage.texture = DefaultButton;
    }
    
    public void SetGreen()
    {
        _rawImage.texture = GreenButton;
    }
    public void SetRed()
    {
        _rawImage.texture = RedButton;
    }
}
