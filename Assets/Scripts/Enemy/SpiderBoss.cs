using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SpiderBoss : Enemy, IDamageable
{
    public GameObject webPrefab;
    public GameObject eggPrefab;
    public GameObject fastSpiderPrefab;
    public Slider m_healthBar;

    [SerializeField] private Animator m_animator;
    [SerializeField] private float m_bulletForce;
    [SerializeField] private float m_firePointPadding;
    [SerializeField] private float m_shootDelay;
    [SerializeField] private bool m_isLaying;
    [SerializeField] private bool m_isShooting;
    protected override void Start()
    {
        base.Start();
        m_healthBar.maxValue = m_health;
        m_healthBar.value = m_health;
        m_animator = GetComponent<Animator>();
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        m_healthBar.value = m_health;
    }
    
    protected override void Update()
    {
        if (IsVisibleInCamera(Camera.main)) { 
            base.Update();
            if (!m_healthBar.gameObject.activeSelf)
            {
                m_healthBar.gameObject.SetActive(true);
            }
            if (!m_isLaying)
            {
                StartCoroutine(LayEgg());
            }

            if (m_health < m_maxHealth / 2)
            {
                if (!m_isShooting)
                {
                    StartCoroutine(ShootWeb());
                }
            }

            if (Mathf.Abs(m_agent.velocity.normalized.x) > Mathf.Abs(m_agent.velocity.normalized.y))
            {
                m_animator.SetFloat("Horizontal", m_agent.velocity.normalized.x);
                m_animator.SetFloat("Vertical", 0);
            }
            else
            {
                m_animator.SetFloat("Vertical", m_agent.velocity.normalized.y);
                m_animator.SetFloat("Horizontal", 0);
            }
        }
    }

    private IEnumerator LayEgg()
    {

        m_isLaying = true;
        yield return new WaitForSeconds(5);
        GameObject newEgg = Instantiate(eggPrefab, transform.position, Quaternion.identity);
        for (int i = 0; i < Random.Range(5, 10); i++)
        {
            GameObject FastSpider = Instantiate(fastSpiderPrefab, newEgg.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
        Destroy(newEgg);
        m_isLaying = false;
    }

    public override void Die()
    {
        base.Die();
        SceneManager.LoadScene("WinScene");
    }

    private IEnumerator ShootWeb()
    {
        m_isShooting = true;
        yield return new WaitForSeconds(m_shootDelay);

        float distance = Vector2.Distance((Vector2)transform.position, (Vector2)player.position);

        Vector2 direction = -((Vector2)transform.position - (Vector2)player.position).normalized;

        Vector3 firePoint = transform.position + (Vector3)direction * m_firePointPadding;

        GameObject webInstance = Instantiate(webPrefab, firePoint, Quaternion.identity);
        webInstance.GetComponent<Rigidbody2D>().velocity = direction * m_bulletForce;

        m_isShooting = false;
    }
}
