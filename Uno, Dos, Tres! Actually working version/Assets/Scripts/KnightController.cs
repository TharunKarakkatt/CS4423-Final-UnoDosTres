using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnightController : MonoBehaviour
{

    public float walkSpeed = 3f;
    public float walkStopRate = .6f;
    Rigidbody2D rb;
    TouchingDirections touchingDirections;
    Animator animator;
    Damageable damageable;
    [SerializeField] 
    public AudioSource Cheering;

    public DetectionZone attackZone;
    
    public enum WalkableDirection { Right, Left }
    private WalkableDirection _walkDirection;
    private Vector2 walkDirectionVector = Vector2.right;
    public WalkableDirection WalkDirection{
        get{ return _walkDirection; }

        set { if(_walkDirection != value){
            gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

            if(value == WalkableDirection.Right)
            {
                walkDirectionVector = Vector2.right;
            }
            else if(value == WalkableDirection.Left)
            {
                walkDirectionVector = Vector2.left;
            }
        }
        
        _walkDirection = value; }
    }
    public bool _hasTarget = false;
    public bool HasTarget { get { return _hasTarget; }
        private set {   
            _hasTarget = value; 
            animator.SetBool(AnimationStrings.hasTarget, value);
        }
    }

    public bool CanMove{
        get { 
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        animator = GetComponent<Animator>();
        damageable = GetComponent<Damageable>();


    }

    private void FixedUpdate()
    {
        if(touchingDirections.IsGrounded && touchingDirections.IsOnWall)
        {
            // print("we flipping!");
            FlipDirection();
        }

        if(CanMove){
            // print("I can moveee");
            rb.velocity = new Vector2(walkSpeed*walkDirectionVector.x, rb.velocity.y);
        }
        else{
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, walkStopRate), rb.velocity.y);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        HasTarget = attackZone.detectedColliders.Count > 0;
        
        if(!IsAlive){
            Cheering.Play();
            StartCoroutine(LoadSceneAfterDelay(4, 3.0f));
        }
    }

    private IEnumerator LoadSceneAfterDelay(int sceneIndex, float delay)
    {
        yield return new WaitForSeconds(delay);

        // Load the scene after the specified delay
        SceneManager.LoadScene(sceneIndex);
    }

    private void FlipDirection(){
        
        if(WalkDirection == WalkableDirection.Right){
            print("Now turnign Left");
            WalkDirection = WalkableDirection.Left;
        }
        else if(WalkDirection == WalkableDirection.Left){
            print("Now turnign Right");
            WalkDirection = WalkableDirection.Right;
        }
    } 

    public void OnHit(int damage, Vector2 knockback){
        
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }

    public bool IsAlive{
        get{
            return animator.GetBool(AnimationStrings.isAlive);
        }
    }
}
