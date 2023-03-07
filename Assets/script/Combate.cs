using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{
    public Animator ani;
    public Transform AttackPoint;
    public LayerMask enemyLayers;
    
    public float attackRange = 0.5f;
    public int  attackDamage = 15;

   
    
    public float attackRate = 2f;
    float nextAttackTime = 0f;



    void Update(){
        if(Time.time >= nextAttackTime){


        if(Input.GetKeyDown(KeyCode.Mouse0)){
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;

        }

       
      
      }
      
      
    }

    
    
    
    
    void Attack(){
        //player an attack animation
        ani.SetTrigger("Attack");

        //detect enimies in range  of attack 
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position,  attackRange, enemyLayers);

        //Damage them

        foreach(Collider2D enemy in hitEnemies ){
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    


   
   
   
   
   
   void OnDrawGizmosSelected(){
       if(AttackPoint == null)
       return;
       Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
    }

    
        












}//fish 
