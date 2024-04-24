using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject deadZone;
    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ballPrefab, spawnPoint.gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RespawnBall(){
        Instantiate(ballPrefab, spawnPoint.gameObject.transform);
    }
}
