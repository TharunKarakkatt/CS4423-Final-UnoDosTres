using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{

    public UnityEvent<int, Vector2> damageableHit;

    [SerializeField]
    private int _maxHealth = 100;

    Animator animator;

    public int MaxHealth{
        get{
            return _maxHealth;
        }
        set{
            _maxHealth = value;
        }
    }

    [SerializeField]
    private int _health = 100;
    public int Health{
        get{
            return _health;
        }
        set{
            _health = value;

            if(_health < 1){
            
                IsAlive = false;
            }
        }
    }

    [SerializeField]
    private bool _isAlive;
    public bool IsAlive{
        get{
            return _isAlive;
        }
        set{
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            // Debug.Log("he's dedd");

            // if(value == false){
            //     damageableDeath.Invoke();
            // }
        
        }
    }

    public bool IsHit{
        get{
            return animator.GetBool(AnimationStrings.isHit);
        }
        private set{
            animator.SetBool(AnimationStrings.isHit, value);
        }
    }

    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();         
        Health = 100;
        IsAlive = true;  
    }

    // Update is called once per frame
    void Start()
    {
        // Health = 100;
        // IsAlive = true;
    }

    void Update(){
        // Hit(10);
    }

    public void Hit(int damage, Vector2 knockback){

        if(IsAlive){
            Health -= damage;
            IsHit = true;
            damageableHit?.Invoke(damage, knockback);
            IsHit = false;
        }
    }
}
