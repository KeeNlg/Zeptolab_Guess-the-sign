using System.Collections;
using UnityEngine;

public class Confetti : MonoBehaviour
{
    public Transform SpawnPoint;
    public RectTransform Canvas;
    public GameObject Prefab;
    public GameObject PrefabCorrect;
    public GameObject PrefabWrong;

    public void Spawn()
    {
        GameObject remove = Instantiate(Prefab, SpawnPoint);
        remove.GetComponent<ParticleSystem>().Play();
        StartCoroutine(DelayedDestruction(remove, 3f));
    }
    
    public void SpawnCorrect()
    {
        GameObject remove = Instantiate(PrefabCorrect, Canvas);
        remove.transform.position += new Vector3(0, .3f, 0);
        StartCoroutine(DelayedDestruction(remove, 1.5f));
    }
    
    public void SpawnWrong()
    {
        GameObject remove = Instantiate(PrefabWrong, Canvas);
        remove.transform.position += new Vector3(0, .3f, 0);
        StartCoroutine(DelayedDestruction(remove, 1.5f));
    }

    private IEnumerator DelayedDestruction(GameObject remove, float time)
    {
        yield return new WaitForSeconds(time);
        
        Destroy(remove);
    }
}
