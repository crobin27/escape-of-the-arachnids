using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastSpider : Enemy, IDamageable
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<IDamageable>().TakeDamage(m_damage);
            Destroy(gameObject);
        }
    }
}
