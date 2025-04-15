using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private bool real;
    private bool fake;
    [SerializeField]
    private Animator anim;
    public static int level = 1;
    private int rng;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        AnimateTester();
    }
    void AnimateTester(){
        
        if(real){
            real = false;
            anim.SetBool("Fake",false);
            anim.SetBool("Gold",true);
            
        }
        else if(fake){
            fake = false;
            anim.SetBool("Gold",false); 
            anim.SetBool("Fake",true);
        }
        
}
    
    
    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Real")){
            rng = Random.Range(1,101);
            if(rng <=49+level){
                real = true;
                fake = false;
            }
            else{
                real = false;
                fake = true;
            }
        }
        if(collision.gameObject.CompareTag("Fake")){
            fake = true;
            real = false;
            rng = Random.Range(1,101);
            if(rng <=49+level){
                real = false;
                fake = true;
            }
            else{
                real = true;
                fake = false;
            }
        }
    }
    void OnCollisionExit2D(Collision2D collision){
        real = false;
        fake = false;
        anim.SetBool("Gold",false); 
        anim.SetBool("Fake",false);
    }
}
