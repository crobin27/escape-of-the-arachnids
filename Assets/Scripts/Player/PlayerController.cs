using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerController : MonoBehaviour, IDamageable
    {
        public static PlayerController Instance { get; private set; }
        [SerializeField] private int m_health = 5;
        [SerializeField] private int m_maxHealth = 5;
        [SerializeField] private float m_speed = 10f;
        [SerializeField] private float m_normalSpeed = 10f;
        [SerializeField] private float m_attackRange = 2.0f;
        [SerializeField] private int m_attackDamage = 10;
        private Animator m_animator;
        [SerializeField] private Rigidbody2D m_rb;
        public VariableJoystick joystick;
        private const float moveLimiter = 0.7f;
        private float horizontal = 0;
        private float vertical = 0;

        public int Health
        {
            get { return m_health; }
            set { m_health = value; }
        }
        public int MaxHealth
        {
            get { return m_maxHealth; }
        }
        public float Speed
        {
            get { return m_speed; }
            set { m_speed = value; }
        }
        public float NormalSpeed
        {
            get { return m_normalSpeed; }
            set { m_normalSpeed = value; }
        }

        // establish the singleton pattern
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
            // stop moving if the joystick is not being touched
            if (joystick.Horizontal == 0 && joystick.Vertical == 0)
            {
                m_rb.velocity = Vector2.zero;
                // set the last direction the player was moving in to animator
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
                m_rb.velocity = direction * m_speed * Time.deltaTime;
            }

            m_animator.SetFloat("Speed", m_rb.velocity.magnitude);

        }

        public void Die()
        {
            SceneManager.LoadScene("DeathScene");
        }

        public void TakeDamage(int damage)
        {
            m_health -= damage;
            HealthBar.Instance.UpdateHealth(m_health);
            if (m_health <= 0)
            {
                Die();
            }
        }
    }
}