using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private S_Vector2 moveDirection;
    [SerializeField] private PlayerData data;
    private Animator animator;
    public float speed = 44f;

    float m_v;
    public float V { get { return m_v; } }

    float m_h;
    public float H { get { return m_h; } }

    bool isTopdown = true;
    public bool IsTopdown { get { return isTopdown; } set { isTopdown = value; } }

    float health = 100f;

    public float Health { get { return health; } set { health = value; } }

    private float timeBtwShoots;
    public float startTimeBtwShoots = 0.3f;

    Rigidbody2D rb;

    public static PlayerMovement instance;

    public string areaTransitionName;

    public GameObject projectile;

    public bool isActive = true;

    public bool isCanShoot;


    private void Awake()
    {
        animator = GetComponent<Animator>();

        if(projectile == null)
        {
            isCanShoot = false;
        }
        else
        {
            isCanShoot = true;
        }

        rb = GetComponent<Rigidbody2D>();
        timeBtwShoots = startTimeBtwShoots;
    }

    private void Start() {
        if(LevelLoader.instance.GetActiveScreenName() == "NarrativeExample"){

        transform.position = data.lastPosition;
        }
     
    
    }

    private void Update()
    {
        if (isActive)
        {
            timeBtwShoots += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Space) && timeBtwShoots >= startTimeBtwShoots && isCanShoot)
            {

                Fire();
                timeBtwShoots = 0;

            }

            if (health <= 0)
            {
                Die();
            }
        }
    }
    void FixedUpdate()
    {
        if (isActive)
        {
            Movement();
        }
    }

    private void Movement()
    {
        m_v = Input.GetAxisRaw("Vertical");
        m_h = Input.GetAxisRaw("Horizontal");

        if(m_v >= 0.1f || m_h >= 0.1f )
        {
            animator.SetFloat("movement", 0.2f);
        }
        else
        {
            animator.SetFloat("movement", 0f);
        }


        if (isTopdown)
        {
            Vector2 moveDir = new Vector2(m_h, m_v);
            moveDirection.Value = moveDir;
            rb.velocity = moveDir * speed * Time.fixedDeltaTime;
        }
        else
        {
            Vector2 moveDir = new Vector2(m_h, 0);
            moveDirection.Value = moveDir;
            rb.velocity = moveDir * speed * Time.fixedDeltaTime;
        }
    }

    private void Fire()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnEnable()
    {
        EventManager.AddHandler(GameEvent.onInteractionComplete, OnInteractionComplete);
    }
    private void OnDisable()
    {

        EventManager.RemoveHandler(GameEvent.onInteractionComplete, OnInteractionComplete);
    }

    void OnInteractionComplete()
    {
        isActive = false;
        rb.velocity = new Vector2(0,0);
        data.lastPosition = transform.position;
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}
