using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.FPS.Game;
using UnityEngine.Events;

namespace Unity.FPS.AI
{

public class Zombie : MonoBehaviour
{

	private NavMeshAgent agent = null;
	[SerializeField] private Transform target;
	

 	 void Start()
	{
		agent = GetComponent<NavMeshAgent>();	
			
	}
	

 	void MoveToTarget(){
		agent.SetDestination(target.position);
		RotateToTarget();
	}

		
		
	private void RotateToTarget(){
		//transform.LookAt(target);
		
		Vector3 direction = target.position - transform.position;
		Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
		transform.rotation = rotation;
	}


	 void Update(){
		
		MoveToTarget();
		
	}	


	
	 

}
	
}

