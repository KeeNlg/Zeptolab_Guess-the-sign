using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[System.Serializable]
public class Answer
{
    [Header("Тип кнопки")]
    public TBttn typeBttn;

    [Header("Тип відповіді")]
    public TAnswer answer;
}

[System.Serializable]
public class Task
{
    [Header("Запитання")]
    public TAnswer trueAnswer;

    [Header("Відповіді для завдання")]
    public List<Answer> answers;
}

public class GameController : MonoBehaviour
{
    public delegate void InitBttn(TBttn _typeBttn, TAnswer answer);
    public static InitBttn OnInitBttn;

    public delegate void SetAnimation(TAnswer answer);
    public static SetAnimation OnSetAnimation;

    [Header("Всі завдання")]
    public List<Task> tasks;
    
    [Header("Індекси")]
    public List<int> indexes;

    public static TAnswer trueAnswer;

    /// <summary>
    /// Поточний індекс
    /// </summary>
    private int currentIndex;

    [Header("Кнопка плей")]
    public Button bttnPlay;

    public GameObject bttns;

    private void OnEnable()
    {
        ResultController.OnGoToNextTask += ShowNewTask;
    }

    private void OnDisable()
    {
        ResultController.OnGoToNextTask -= ShowNewTask;
    }

    private void Awake()
    {
        CreateIndexes(indexes, tasks.Count);
    }

    private void Start()
    {
       
    }

    public void Restart()
    {
        if (FinalScore.Instance)
            FinalScore.Instance.Hide();

        CreateIndexes(indexes, tasks.Count);

        ShowNewTask();
    }

    public void Play()
    {
        bttnPlay.transform.DOLocalMoveY(-400, 0.5f).OnComplete(()=>
        {
            bttns.transform.DOLocalMoveY(-200, 0.5f).OnComplete(() =>
            {
                ShowNewTask();
            });
        });
    }

    private void GameOver()
    {
        if(FinalScore.Instance)
            FinalScore.Instance.Show();
    }

    private void ShowNewTask()
    {
        if (indexes.Count != 0)
        {
            currentIndex = GetRandomIndex(indexes);

            trueAnswer = tasks[currentIndex].trueAnswer;

            OnSetAnimation?.Invoke(trueAnswer);

            InitBttns();
        }
        else
        {
            GameOver();
        }
    }

    /// <summary>
    /// Ініціалізація кнопок
    /// </summary>
    private void InitBttns()
    {
        foreach (Answer answer in tasks[currentIndex].answers)
        {
            OnInitBttn?.Invoke(answer.typeBttn, answer.answer);
        }
    }

    /// <summary>
    /// Створити список індексів
    /// </summary>
    private void CreateIndexes(List<int> _list, int _count)
    {
        for (int i = 0; i < _count; i++)
        {
            _list.Add(i);
        }
    }

    /// <summary>
    /// Отримання випадкого індекса
    /// </summary>
    /// <param name="_list"></param>
    /// <returns></returns>
    private int GetRandomIndex(List<int> _list)
    {
        int rnd = _list[Random.Range(0, _list.Count)];

        _list.Remove(rnd);

        return rnd;
    }
}
