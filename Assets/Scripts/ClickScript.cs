using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Tester")){
            CursorFollow.hoveringTester = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Tester")){
            CursorFollow.hoveringTester = false;
        }
    }
    
    
}
