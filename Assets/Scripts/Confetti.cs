using System.Collections;
using UnityEngine;

public class Confetti : MonoBehaviour
{
    public Transform SpawnPoint;
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
        GameObject remove = Instantiate(PrefabCorrect, SpawnPoint.position, Quaternion.identity);
        StartCoroutine(DelayedDestruction(remove, 1.5f));
    }
    
    public void SpawnWrong()
    {
        GameObject remove = Instantiate(PrefabWrong, SpawnPoint);
        StartCoroutine(DelayedDestruction(remove, 1.5f));
    }

    private IEnumerator DelayedDestruction(GameObject remove, float time)
    {
        yield return new WaitForSeconds(time);
        
        Destroy(remove);
    }
}
