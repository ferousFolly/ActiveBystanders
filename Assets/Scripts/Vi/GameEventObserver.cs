using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventObserver : MonoBehaviour
{
    [Header("Demon")]
    public bool enableRandomPosition;
    public Transform[] demonAppearPoints;
    private GameObject demon;
    public GameObject demonPrefab;
    public float appearTime;
    public float disAppearTime;
    bool isVanishing;

    private void Start()
    {
        demon = FindObjectOfType<AI_Demon>().gameObject;
    }

    private void Update()
    {
        if (enableRandomPosition) {
            RandomSpawn();
        }
    }

    void RandomSpawn() {
        if (!isVanishing) {
            StartCoroutine(Appear());
        }
    }

    IEnumerator Appear() {
        isVanishing = true;
        yield return new WaitForSeconds(disAppearTime);
        Transform nextSpawnPoint = demonAppearPoints[Random.Range(0, demonAppearPoints.Length)];
        Destroy(demon);
        yield return new WaitForSeconds(appearTime);
        GameObject D = Instantiate(demonPrefab);
        D.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        D.transform.position = nextSpawnPoint.position;
        yield return new WaitForSeconds(0.1f);
        D.GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = true;
        demon = D;
        isVanishing = false;
    }

}
