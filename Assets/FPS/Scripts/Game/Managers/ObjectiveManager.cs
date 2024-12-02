using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace Unity.FPS.Game
{
    public class ObjectiveManager : MonoBehaviour
    {
        List<Objective> m_Objectives = new List<Objective>();
        bool m_ObjectivesCompleted = false;
        public Health zombieshealth1;
	   public Health zombieshealth2;
	  public Health zombieshealth3;
 	  public Health zombieshealth4;
	  public Health zombieshealth5;
	  public int zombiesNumber;
	  public List<Health> zombiesList;
	  public int i = 0;
	  

        void Awake()
        {
            Objective.OnObjectiveCreated += RegisterObjective;
        }

        void RegisterObjective(Objective objective) => m_Objectives.Add(objective);

	 void Start(){
		zombiesNumber = 1;
		zombiesList = new List<Health>(){zombieshealth1, zombieshealth2, zombieshealth3, zombieshealth4, zombieshealth5};
	
	
	} 

        void Update()
        {
            if (m_Objectives.Count == 0 || m_ObjectivesCompleted)
                return;

		
		if(zombieshealth1.CurrentZombieHealth <= 0 && zombieshealth2.CurrentZombieHealth <= 0 
		&& zombieshealth3.CurrentZombieHealth <= 0 && zombieshealth4.CurrentZombieHealth <= 0 && zombieshealth5.CurrentZombieHealth <= 0
			){
			zombiesNumber = 0;
			
		}

        	if(zombiesNumber == 0){
            m_ObjectivesCompleted = true;
            EventManager.Broadcast(Events.AllObjectivesCompletedEvent);
		}
		
        }

        void OnDestroy()
        {
            Objective.OnObjectiveCreated -= RegisterObjective;
        }
    }
}