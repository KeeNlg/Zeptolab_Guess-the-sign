﻿using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScenarioManager : MonoBehaviour
{
    public Dummy Dummy;
    public Cursor Cursor;
    public Confetti Confetti;
    
    public OptionButton[] Buttons;
    public TextMeshProUGUI[] Labels;

    public Texture2D CursorTexture;

    private bool _buttonPressed = false;
    
    private void Start()
    {
        //UnityEngine.Cursor.SetCursor(CursorTexture, new Vector2(0, 0), CursorMode.Auto);
        //UnityEngine.Cursor.visible = false;
        //DumbScenario();
        SmartScenario();
        //ClickbaitScenario();
    }

    private void DelayedButtonPress(OptionButton button)
    {
        StartCoroutine(DelayedButtonPressCoroutine(button));
    }

    private IEnumerator DelayedButtonPressCoroutine(OptionButton button)
    {
        yield return new WaitForSeconds(.2f);
        
        button.SetGreen();
    }
    
    //====================================================================

    private void ClickbaitScenario()
    {
        StartCoroutine(ClickbaitCoroutine());
    }

    private IEnumerator ClickbaitCoroutine()
    {
        Cursor.gameObject.SetActive(false);
        Labels[0].text = "Cave";
        Labels[1].text = "Hollow";
        Labels[2].text = "Hole";
        Labels[3].text = "Love";
        Dummy.PlaySign(Sign.Love);
        yield return new WaitForSeconds(3.5f);
        
        //Cursor.gameObject.SetActive(true);
        Buttons[3].OnClick = () =>
        {
            _buttonPressed = true;
            Buttons[3].SetGreen();
            Confetti.Spawn();
            Confetti.SpawnCorrect();
            Dummy.StopCycle();
        };
        
        yield return new WaitForSeconds(3.5f);
        
        Dummy.PlaySign(Sign.Love);
        
        yield return new WaitUntil(() => _buttonPressed);
        
        yield return new WaitForSeconds(2f);
        //===
        
        _buttonPressed = false;
        //Cursor.gameObject.SetActive(false);
        Buttons[3].OnClick = () => { };
        Buttons[3].SetDefault();
        Labels[0].text = "Smooth";
        Labels[1].text = "Tight";
        Labels[2].text = "Nice";
        Labels[3].text = "Fast";
        Dummy.PlaySign(Sign.Nice);
        yield return new WaitForSeconds(3.5f);
        
        //Cursor.gameObject.SetActive(true);
        Buttons[2].OnClick = () =>
        {
            _buttonPressed = true;
            Buttons[2].SetGreen();
            Confetti.Spawn();
            Confetti.SpawnCorrect();
            Dummy.StopCycle();
        };
        
        yield return new WaitForSeconds(3.5f);
        
        Dummy.PlaySign(Sign.Nice);
        
        yield return new WaitUntil(() => _buttonPressed);
        
        yield return new WaitForSeconds(2f);
        //===
        
        _buttonPressed = false;
        //Cursor.gameObject.SetActive(false);
        Buttons[2].SetDefault();
        Buttons[2].OnClick = () => { };
    }
    
    //====================================================================

    private void SmartScenario()
    {
        StartCoroutine(SmartCoroutine());
    }
    
    private IEnumerator SmartCoroutine()
    {
        Cursor.gameObject.SetActive(false);
        Labels[0].text = "Kiss";
        Labels[1].text = "Meet";
        Labels[2].text = "Close";
        Labels[3].text = "Shrink";
        Dummy.PlaySign(Sign.Meet);
        yield return new WaitForSeconds(3.5f);

        //Cursor.gameObject.SetActive(true);
        Buttons[1].OnClick = () =>
        {
            _buttonPressed = true;
            Buttons[1].SetGreen();
            Confetti.Spawn();
            Confetti.SpawnCorrect();
            Dummy.StopCycle();
        };
        
        yield return new WaitForSeconds(3.5f);
        
        Dummy.PlaySign(Sign.Meet);
        
        yield return new WaitUntil(() => _buttonPressed);
        
        yield return new WaitForSeconds(2f);
        //===

        _buttonPressed = false;
        //Cursor.gameObject.SetActive(false);
        Buttons[1].SetDefault();
        Buttons[1].OnClick = () => { };
        Labels[0].text = "Step";
        Labels[1].text = "Barrier";
        Labels[2].text = "Bump";
        Labels[3].text = "Name";
        
        //yield return new WaitForSeconds(0.5f);
        
        Dummy.PlaySign(Sign.Name);
        yield return new WaitForSeconds(3.5f);
        
        //Cursor.gameObject.SetActive(true);
        Buttons[0].OnClick = () =>
        {
            _buttonPressed = true;
            Buttons[0].SetRed();
            Confetti.SpawnWrong();
            DelayedButtonPress(Buttons[3]);
            Dummy.StopCycle();
        };
        
        yield return new WaitForSeconds(3.5f);
        
        Dummy.PlaySign(Sign.Name);
        
        yield return new WaitUntil(() => _buttonPressed);
        
        yield return new WaitForSeconds(2f);
        //===
        
        _buttonPressed = false;
        //Cursor.gameObject.SetActive(false);
        Buttons[0].SetDefault();
        Buttons[0].OnClick = () => { };
        Buttons[3].SetDefault();
        /*Labels[0].text = "Smooth";
        Labels[1].text = "Tight";
        Labels[2].text = "Nice";
        Labels[3].text = "Fast";
        
        Dummy.PlaySign(Sign.Nice);
        yield return new WaitForSeconds(4f);
        
        //Cursor.gameObject.SetActive(true);
        Buttons[2].OnClick = () =>
        {
            _buttonPressed = true;
            Buttons[2].SetGreen();
            Confetti.Spawn();
            Confetti.SpawnCorrect();
            Dummy.StopCycle();
        };
        
        yield return new WaitForSeconds(4f);
        
        Dummy.PlaySign(Sign.Nice);
        
        yield return new WaitUntil(() => _buttonPressed);
        
        yield return new WaitForSeconds(2f);
        //===
        
        _buttonPressed = false;
        //Cursor.gameObject.SetActive(false);
        Buttons[2].SetDefault();
        Buttons[2].OnClick = () => { };*/
    }
    
    
    
    //====================================================================

    private void DumbScenario()
    {
        StartCoroutine(DumbCoroutine());
    }

    private IEnumerator DumbCoroutine()
    {
        Cursor.gameObject.SetActive(false);
        Labels[0].text = "Love";
        Labels[1].text = "Hole";
        Labels[2].text = "Hollow";
        Labels[3].text = "Cave";
        Dummy.PlaySign(Sign.Love);
        yield return new WaitForSeconds(3.5f);
        
        //Cursor.gameObject.SetActive(true);
        Buttons[1].OnClick = () =>
        {
            _buttonPressed = true;
            Buttons[1].SetRed();
            Confetti.SpawnWrong();
            Dummy.StopCycle();
            DelayedButtonPress(Buttons[0]);
        };
        
        yield return new WaitForSeconds(3.5f);
        
        Dummy.PlaySign(Sign.Love);
        
        yield return new WaitUntil(() => _buttonPressed);
        
        yield return new WaitForSeconds(2f);
        //===
        
        _buttonPressed = false;
        //Cursor.gameObject.SetActive(false);
        Buttons[1].SetDefault();
        Buttons[1].OnClick = () => { };
        Buttons[0].SetDefault();
        Labels[0].text = "Yes";
        Labels[1].text = "No";
        Labels[2].text = "Three";
        Labels[3].text = "Eat";
        Dummy.PlaySign(Sign.No);
        yield return new WaitForSeconds(3.5f);
        
        //Cursor.gameObject.SetActive(true);
        Buttons[2].OnClick = () =>
        {
            _buttonPressed = true;
            Buttons[2].SetRed();
            Confetti.SpawnWrong();
            DelayedButtonPress(Buttons[1]);
            Dummy.StopCycle();
        };
        
        yield return new WaitForSeconds(3.5f);
        
        Dummy.PlaySign(Sign.No);
        
        yield return new WaitUntil(() => _buttonPressed);
        
        yield return new WaitForSeconds(2f);
        //===
        
        _buttonPressed = false;
        //Cursor.gameObject.SetActive(false);
        Buttons[2].SetDefault();
        Buttons[2].OnClick = () => { };
        Buttons[1].SetDefault();
        /*Labels[0].text = "Roof";
        Labels[1].text = "Elevator";
        Labels[2].text = "Understand";
        Labels[3].text = "Ceiling";
        Dummy.PlaySign(Sign.Understand);
        yield return new WaitForSeconds(4f);
        
        Buttons[0].OnClick = () =>
        {
            _buttonPressed = true;
            Buttons[0].SetRed();
            Confetti.SpawnWrong();
            Dummy.StopCycle();
        };
        
        yield return new WaitForSeconds(4f);
        
        Dummy.PlaySign(Sign.Understand);
        
        yield return new WaitUntil(() => _buttonPressed);
        
        yield return new WaitForSeconds(2f);
        //===
        
        Buttons[0].SetDefault();
        Buttons[0].OnClick = () => { };*/
    }
}
