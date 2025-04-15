using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFollow : MonoBehaviour
{
    private Vector3 mousePos;
    [SerializeField]
    private GameObject cursor;
    [SerializeField]
    private GameObject tester;

    public static bool hoveringTester = false;
    private bool testing = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0.0f));
        cursor.transform.position = new Vector3 (mousePos.x+0.16f,mousePos.y-0.1f,0.0f);
        
        
        testingFunction();
        testForTesting();
        if(testing){
            cursor.transform.position = new Vector3 (-20,-10,cursor.transform.position.z);
        }
        
        
    }
    private void testForTesting(){
        if(Input.GetMouseButtonDown(0)&&hoveringTester){
            testing = true;
        }
    }
    private void testingFunction(){
        if(testing){
            tester.transform.position = new Vector3(mousePos.x+1,mousePos.y,0.0f);
            if(tester.transform.position.x >1 || tester.transform.position.x < -7 || tester.transform.position.y < -2 || tester.transform.position.y > 5){
                tester.transform.position = new Vector3 (0.05f,0.32f,tester.transform.position.z);
                testing = false;
            }
            if(Input.GetMouseButtonDown(1)){
                tester.transform.position = new Vector3 (0.05f,0.32f,tester.transform.position.z);
                testing = false;
            }
        }
    }
}
