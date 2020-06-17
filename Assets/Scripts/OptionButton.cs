using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    public Texture DefaultButton;
    public Texture RedButton;
    public Texture GreenButton;

    private RawImage _rawImage;
    private Animator _animator;

    private bool mouseOver;

    public Action OnClick = () => {};

    private void Awake()
    {
        _rawImage = GetComponent<RawImage>();
        _animator = GetComponent<Animator>();
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

    private void OnMouseEnter()
    {
        Debug.Log("mouse");
        _animator.SetBool("mouseOver", true);
    }

    private void OnMouseExit()
    {
        _animator.SetBool("mouseOver", false);
    }

    private void OnMouseUpAsButton()
    {
        _animator.SetTrigger("Click");
        OnClick();
    }
}
