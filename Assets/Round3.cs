using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace Unity.FPS.Game
{
public class Round3 : MonoBehaviour
{

	 public Health zombieshealth1;
	   public Health zombieshealth2;
	  public Health zombieshealth3;
	 public Health zombieshealth4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(zombieshealth1.CurrentZombieHealth <=0 && zombieshealth2.CurrentZombieHealth <=0 
		&& zombieshealth3.CurrentZombieHealth <=0 && zombieshealth4.CurrentZombieHealth <=0){
		SceneManager.LoadScene("Round3");
		
		}
    }
}
}