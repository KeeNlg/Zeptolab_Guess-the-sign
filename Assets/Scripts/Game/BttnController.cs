using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public enum TBttn
{
    ABttn,
    BBttn,
    CBttn,
    DBttn,
}

[System.Serializable]
public enum TAnswer
{
    None,
    Name,
    No,
    Nice,
    Meet,
    Love,
    Understand,
    Kiss,
    Close,
    Shrink,
    Step,
    Barrier,
    Bump,
    Smooth,
    Tight,
    Fast,
    Yes,
    Three,
    Eat,
    Elevator,
    Roof,
    Ceiling,
    Hole,
    Hollow,
    Cave
}

public class BttnController : MonoBehaviour
{
    public delegate void Result(bool isCorrect);
    public static Result OnResult;

    public delegate void FindTrueResult(TAnswer answer);
    public static FindTrueResult OnFindTrueResult;

    public delegate void ShowResultTitle(TResult _result);
    public static ShowResultTitle OnShowResultTitle;

    [Header("Тип кнопки")]
    public TBttn typeBttn;

    [Header("Текстове поле")]
    public Text txt;

    public Sprite defaultSprite;

    public Sprite correctSprite;

    public Sprite wrongSprite;

    private TAnswer answer;

    private Image img;

    private Button button;

    private void OnEnable()
    {
        GameController.OnInitBttn += Init;

        BttnController.OnFindTrueResult += CheckTrueResult;
    }

    private void OnDisable()
    {
        GameController.OnInitBttn -= Init;

        BttnController.OnFindTrueResult -= CheckTrueResult;
    }

    private void Awake()
    {
        img = GetComponent<Image>();

        button = GetComponent<Button>();
    }

    /// <summary>
    /// Перевірка
    /// </summary>
    public void Check()
    {
        if (answer == GameController.trueAnswer)
        {
            OnResult?.Invoke(true);

            ShowResult(true);

            OnShowResultTitle?.Invoke(TResult.Correct);

            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score", 0) + 100);
            PlayerPrefs.Save();
        }
        else
        {
            OnResult?.Invoke(false);

            ShowResult(false);

            OnShowResultTitle?.Invoke(TResult.Wrong);

            OnFindTrueResult?.Invoke(GameController.trueAnswer);
        }
    }

    private void CheckTrueResult(TAnswer _answer)
    {
        button.interactable = false;

        DOVirtual.DelayedCall(1, () =>
        {
            if (answer == _answer)
            {
                ShowResult(true);
            }
        });

       
    }

    private void ShowResult(bool isCorrect)
    {
        img.sprite = (isCorrect) ? correctSprite : wrongSprite;

        if (isCorrect)
            Animation();
    }

    private void Animation()
    {
        transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.3f).SetLoops(2, LoopType.Yoyo);
    }

    /// <summary>
    /// Ініціалізація
    /// </summary>
    /// <param name="_typeBttn"></param>
    /// <param name="answer"></param>
    private void Init(TBttn _typeBttn, TAnswer _answer)
    {
        if (typeBttn == _typeBttn)
        {
            SetText(_answer.ToString());

            answer = _answer;

            img.sprite = defaultSprite;

            button.interactable = true;
        }
    }

    /// <summary>
    /// Встановленнятекстового поля
    /// </summary>
    /// <param name="value"></param>
    public void SetText(string value)
    {
        txt.text = value;
    }
}
