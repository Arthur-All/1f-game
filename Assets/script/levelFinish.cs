using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class levelFinish : MonoBehaviour
{
    [SerializeField]
    
    private  string nextLevelName;

    [SerializeField]
    private  float timer =  2f;

    private bool  levelFinished;

    public class Tags{
        public const string PLAYER_TAG = "Player";
    }



   void LoadNewLevel(){

       SceneManager.LoadScene(nextLevelName);

   }
   

   void  OnTriggerEnter2D(Collider2D target ){
     if (target.CompareTag(Tags.PLAYER_TAG)){
         if(!levelFinished){
             levelFinished = true;
             if(!nextLevelName.Equals("")){
                 Invoke("LoadNewLevel", timer);
             }
         }
     }
   }


    
    

  
    void Update()
    {
        
    }














}//lol