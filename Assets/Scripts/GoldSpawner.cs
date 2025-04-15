using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject gold0Fake;
    [SerializeField]
    private GameObject gold1Fake;
    [SerializeField]
    private GameObject gold2Fake;
    [SerializeField]
    private GameObject gold0Real;
    [SerializeField]
    private GameObject gold1Real;
    [SerializeField]
    private GameObject gold2Real;

    private GameObject spawnedGold;
    public static int rng;
    public static bool destroyGold;
    public static bool discardedGold;
    public static float goldTimer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnGold());
    }

    // Update is called once per frame
    void Update()
    {
        if(discardedGold){
            destroyGold = true;
            spawnedGold = null;
        }
    }
    IEnumerator SpawnGold(){
        while(true){
            if(spawnedGold == null){ 
                rng = Random.Range(1,7);
                if(rng == 1){
                    spawnedGold = gold0Fake;
                }
                if(rng == 2){
                    spawnedGold = gold1Fake;
                }
                if(rng == 3){
                    spawnedGold = gold2Fake;
                }
                if(rng== 4){
                    spawnedGold = gold0Real;
                }
                if(rng == 5){
                    spawnedGold = gold1Real;
                }
                if(rng == 6){
                    spawnedGold = gold2Real;
                }
                
                Instantiate(spawnedGold);
                if(rng == 1 || rng == 4){
                    spawnedGold.transform.position = new Vector3(-4.556085f,0.5765082f,spawnedGold.transform.position.z);
                }
                if(rng == 2 || rng ==5){
                    spawnedGold.transform.position = new Vector3(-4.687939f,0.6382785f,spawnedGold.transform.position.z);
                }
                if(rng==3 || rng == 6){
                    spawnedGold.transform.position = new Vector3(-4.85f,0.72f,spawnedGold.transform.position.z);
                }
                goldTimer = 3;
                
            }
            yield return new WaitForSeconds(0.01f);
        }

    }
}
