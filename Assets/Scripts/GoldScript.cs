using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GoldSpawner.destroyGold){
            Destroy(gameObject);
            GoldSpawner.destroyGold = false;
            GoldSpawner.discardedGold = false;
        }
    }
}
