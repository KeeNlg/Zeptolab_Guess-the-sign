using System.Collections;
using UnityEngine;

public class Confetti : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject Prefab;

    public void Spawn()
    {
        GameObject remove = Instantiate(Prefab, SpawnPoint);
        remove.GetComponent<ParticleSystem>().Play();
        StartCoroutine(DelayedDestruction(remove));
    }

    private IEnumerator DelayedDestruction(GameObject remove)
    {
        yield return new WaitForSeconds(3f);
        
        Destroy(remove);
    }
}
