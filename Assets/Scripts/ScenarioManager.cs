using System;
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
    
    private void Start()
    {
        DumbScenario();
        //SmartScenario();
        //ClickbaitScenario();
    }
    
    //====================================================================

    private void ClickbaitScenario()
    {
        StartCoroutine(ClickbaitCoroutine());
    }

    private IEnumerator ClickbaitCoroutine()
    {
        Labels[0].text = "Cave";
        Labels[1].text = "Hollow";
        Labels[2].text = "Hole";
        Labels[3].text = "Love";
        Dummy.PlaySign(Sign.Love);
        yield return new WaitForSeconds(4f);
        Cursor.Move(Buttons[0].transform.position, 2f);
        yield return new WaitForSeconds(2.3f);
        Cursor.Move(Buttons[2].transform.position, 2f);
        yield return new WaitForSeconds(2.5f);
        Cursor.Move(Buttons[0].transform.position, 3f);
        yield return new WaitForSeconds(3.1f);
        Cursor.Move(Buttons[3].transform.position, 4f);
        Dummy.PlaySign(Sign.Love);
        yield return new WaitForSeconds(4.2f);
        Cursor.Move(Buttons[1].transform.position, 2f);
        yield return new WaitForSeconds(2.2f);
        Cursor.Move(Buttons[3].transform.position, 3f);
        yield return new WaitForSeconds(3.3f);
        
        Buttons[3].SetGreen();
        Confetti.Spawn();
        yield return new WaitForSeconds(2f);
        //===
        
        Buttons[3].SetDefault();
        Labels[0].text = "Smooth";
        Labels[1].text = "Tight";
        Labels[2].text = "Nice";
        Labels[3].text = "Fast";
        Dummy.PlaySign(Sign.Nice);
        yield return new WaitForSeconds(4f);
        Cursor.Move(Buttons[1].transform.position, 2f);
        yield return new WaitForSeconds(2.3f);
        Cursor.Move(Buttons[2].transform.position, 1f);
        yield return new WaitForSeconds(1.5f);
        Cursor.Move(Buttons[0].transform.position, 3f);
        Dummy.PlaySign(Sign.Nice);
        yield return new WaitForSeconds(4.5f);
        Cursor.Move(Buttons[3].transform.position, 1.8f);
        yield return new WaitForSeconds(2.6f);
        Cursor.Move(Buttons[0].transform.position, 1.5f);
        yield return new WaitForSeconds(2.2f);
        Cursor.Move(Buttons[2].transform.position, 3f);
        yield return new WaitForSeconds(3.3f);
        
        Buttons[2].SetGreen();
        Confetti.Spawn();
        yield return new WaitForSeconds(2f);
        //===
        
        Buttons[2].SetDefault();
    }
    
    //====================================================================

    private void SmartScenario()
    {
        StartCoroutine(SmartCoroutine());
    }
    
    private IEnumerator SmartCoroutine()
    {
        Labels[0].text = "Kiss";
        Labels[1].text = "Meet";
        Labels[2].text = "Close";
        Labels[3].text = "Shrink";
        Dummy.PlaySign(Sign.Meet);
        yield return new WaitForSeconds(4f);
        
        Cursor.Move(Buttons[2].transform.position, 2f);
        yield return new WaitForSeconds(2f);
        Cursor.Move(Buttons[1].transform.position, 3f);
        yield return new WaitForSeconds(3.5f);
        
        Buttons[1].SetGreen();
        Confetti.Spawn();
        yield return new WaitForSeconds(2f);
        //===
        
        Buttons[1].SetDefault();
        Labels[0].text = "Step";
        Labels[1].text = "Barrier";
        Labels[2].text = "Bump";
        Labels[3].text = "Name";
        
        Dummy.PlaySign(Sign.Name);
        yield return new WaitForSeconds(4f);
        
        Cursor.Move(Buttons[0].transform.position, 3f);
        yield return new WaitForSeconds(4f);
        
        Buttons[0].SetRed();
        yield return new WaitForSeconds(2f);
        //===
        
        Buttons[0].SetDefault();
        Labels[0].text = "Smooth";
        Labels[1].text = "Tight";
        Labels[2].text = "Nice";
        Labels[3].text = "Fast";
        
        Dummy.PlaySign(Sign.Nice);
        yield return new WaitForSeconds(4f);
        
        Cursor.Move(Buttons[1].transform.position, 1f);
        yield return new WaitForSeconds(2f);
        Cursor.Move(Buttons[2].transform.position, 3f);
        yield return new WaitForSeconds(3.5f);
        
        Buttons[2].SetGreen();
        Confetti.Spawn();
        
        yield return new WaitForSeconds(2f);
        //===
        
        Buttons[2].SetDefault();
    }
    
    //====================================================================

    private void DumbScenario()
    {
        StartCoroutine(DumbCoroutine());
    }

    private IEnumerator DumbCoroutine()
    {
        Labels[0].text = "Love";
        Labels[1].text = "Hole";
        Labels[2].text = "Hollow";
        Labels[3].text = "Cave";
        Dummy.PlaySign(Sign.Love);
        yield return new WaitForSeconds(4f);
        
        Cursor.Move(Buttons[0].transform.position, 1f);
        yield return new WaitForSeconds(1.3f);
        Cursor.Move(Buttons[3].transform.position, 2f);
        yield return new WaitForSeconds(2.5f);
        
        Buttons[3].SetRed();
        yield return new WaitForSeconds(2f);
        //===
        
        Buttons[3].SetDefault();
        Labels[0].text = "Yes";
        Labels[1].text = "No";
        Labels[2].text = "Three";
        Labels[3].text = "Eat";
        
        Dummy.PlaySign(Sign.No);
        yield return new WaitForSeconds(4f);
        
        Cursor.Move(Buttons[0].transform.position, 2.2f);
        yield return new WaitForSeconds(2.5f);
        Cursor.Move(Buttons[2].transform.position, 2.5f);
        yield return new WaitForSeconds(3f);
        
        Buttons[2].SetRed();
        yield return new WaitForSeconds(2f);
        //===
        
        Buttons[2].SetDefault();
        Labels[0].text = "Roof";
        Labels[1].text = "Elevator";
        Labels[2].text = "Understand";
        Labels[3].text = "Ceiling";
        
        Dummy.PlaySign(Sign.Understand);
        yield return new WaitForSeconds(4f);
        
        Cursor.Move(Buttons[0].transform.position, 3f);
        yield return new WaitForSeconds(3.5f);
        
        Buttons[0].SetRed();
        yield return new WaitForSeconds(2f);
        //===
        
        Buttons[0].SetDefault();
    }
}
