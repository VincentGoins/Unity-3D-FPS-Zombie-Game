﻿using UnityEngine;
using UnityEngine.Events;

namespace Unity.FPS.Game
{
    public class Health : MonoBehaviour
    {
        [Tooltip("Maximum amount of health")] public float MaxHealth = 10f;
	  public float ZombieMaxHealth = 10f;
	
	  public float CurrentZombieHealth{ get; set; }
	
        [Tooltip("Health ratio at which the critical health vignette starts appearing")]
        public float CriticalHealthRatio = 0.3f;

        public UnityAction<float, GameObject> OnDamaged;
        public UnityAction<float> OnHealed;
        public UnityAction OnDie;

        public float CurrentHealth { get; set; }
        public bool Invincible { get; set; }
        public bool CanPickup() => CurrentHealth < MaxHealth;

        public float GetRatio() => CurrentHealth / MaxHealth;
        public bool IsCritical() => GetRatio() <= CriticalHealthRatio;
	  public GameObject zombieDie;
	  public GameObject zombieDie2;
	  public int zombiesArray = 0;
	//  public int countZombies;
        bool m_IsDead;
	 public AudioSource attack;
		
	//  public GameObject isPlayer;
	  

        void Start()
        {
		 

            CurrentHealth = MaxHealth;
		CurrentZombieHealth = ZombieMaxHealth;

		zombiesArray = 0;
		

        }

        public void Heal(float healAmount)
        {
            float healthBefore = CurrentHealth;
            CurrentHealth += healAmount;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, MaxHealth);

            // call OnHeal action
            float trueHealAmount = CurrentHealth - healthBefore;
            if (trueHealAmount > 0f)
            {
                OnHealed?.Invoke(trueHealAmount);
            }
        }

        public void TakeDamage(float damage, GameObject damageSource)
        {
            if (Invincible)
                return;

            float healthBefore = CurrentHealth;
            CurrentHealth -= damage;
            CurrentHealth = Mathf.Clamp(CurrentHealth, 0f, MaxHealth);

		float ZombiehealthBefore = CurrentZombieHealth;
            CurrentZombieHealth -= damage;
            CurrentZombieHealth = Mathf.Clamp(CurrentZombieHealth, 0f, ZombieMaxHealth);
		
		

		

            // call OnDamage action
            float trueDamageAmount = healthBefore - CurrentHealth;
	
            if (trueDamageAmount > 0f)
            {
                OnDamaged?.Invoke(trueDamageAmount, damageSource);
            }
		


		
            HandleDeath();
        }

        public void Kill()
        {
            CurrentHealth = 0f;

            // call OnDamage action
            OnDamaged?.Invoke(MaxHealth, null);

           HandleDeath();
        }
	

	void OnCollisionStay(Collision collide){
		
		if(collide.gameObject.tag == "Zombie"){
			CurrentHealth -= .2f;
			
			
		}

	}

	void OnCollisionEnter(Collision collide){
		if(collide.gameObject.tag == "Player"){
			attack.Play();
	}
}
			

		void Update(){
			

	  if (m_IsDead)
                return;

            // call OnDie action
            if (CurrentHealth <= 0f)
            {
                m_IsDead = true;
                OnDie?.Invoke();
            }

	
		
		}
			


        void HandleDeath()
        {
            if (m_IsDead)
                return;

            // call OnDie action
            if (CurrentHealth <= 0f)
            {
                m_IsDead = true;
                OnDie?.Invoke();
            }
        }
    }
}