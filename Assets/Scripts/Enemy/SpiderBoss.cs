using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class SpiderBoss : Enemy, IDamageable
{
    public GameObject eggPrefab;
    public GameObject fastSpiderPrefab;
    public Slider m_healthBar;

    private Animator m_animator;

    private bool isLaying;
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
        m_healthBar.value -= damage;
    }
    
    protected override void Update()
    {
        if (IsVisibleInCamera(Camera.main)) { 
            if (!m_healthBar.gameObject.activeSelf)
            {
                m_healthBar.gameObject.SetActive(true);
            }
        
            base.Update();
            if (!isLaying)
            {
                StartCoroutine(LayEgg());
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

        isLaying = true;
        yield return new WaitForSeconds(5);
        GameObject newEgg = Instantiate(eggPrefab, transform.position, Quaternion.identity);
        for (int i = 0; i < Random.Range(5, 10); i++)
        {
            GameObject FastSpider = Instantiate(fastSpiderPrefab, newEgg.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
        Destroy(newEgg);
        isLaying = false;
    }

    public override void Die()
    {
        base.Die();
        SceneManager.LoadScene("WinScene");
    }
}
