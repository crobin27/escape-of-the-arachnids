using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour, IDamageable
{
    public static PlayerController Instance { get; private set; }

    [SerializeField] private int m_health = 5;
    [SerializeField] private float m_speed = 25f;
    [SerializeField] private float m_attackRange = 2.0f;
    [SerializeField] private int m_attackDamage = 10;


    private Animator m_animator;

    private float horizontal = 0;
    private float vertical = 0;

    [SerializeField] private Rigidbody2D m_rb;

    public VariableJoystick joystick;

    float moveLimiter = 0.7f;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        m_rb = GetComponent<Rigidbody2D>();
        m_animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (joystick.Horizontal == 0 && joystick.Vertical == 0)
        {
            m_rb.velocity = Vector2.zero;
      
            m_animator.SetFloat("LastX", horizontal);
            m_animator.SetFloat("LastY", vertical);
        }
        else
        {
            if (joystick.Horizontal != 0 && joystick.Vertical != 0)
            {
                // limit movement speed diagonally, so you move at 70% speed
                horizontal = moveLimiter * joystick.Horizontal;
                vertical = moveLimiter * joystick.Vertical;

                m_animator.SetFloat("Horizontal", horizontal);
                m_animator.SetFloat("Vertical", vertical);
            }
            Vector2 direction = new Vector2(horizontal, vertical).normalized;
             // Debug.Log("joystick vector" + direction);
            m_rb.velocity = direction * m_speed * Time.deltaTime;
            
        }

        m_animator.SetFloat("Speed", m_rb.velocity.magnitude);

    }

    public void Die()
    {
        Destroy(gameObject);

        UIManager.Instance.ShowEndGamePanel();
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
    public void TakeDamage(int damage)
    {
        m_health -= damage;
        if (m_health < 0)
        {
            // Load End Scene
            Die();
        }
    }

    


}
