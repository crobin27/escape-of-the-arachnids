using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : Enemy, IDamageable
{
    [SerializeField] private float chargeSpeed = 8f;
    [SerializeField] private float chargeDuration = 0.8f;
    [SerializeField] private float chargeCooldown = 3f;

    private bool isCharging;
    private float chargeTimer;
    protected override void Start()
    {
        base.Start();
    }

    private IEnumerator Charge()
    {
        isCharging = true;
        float originalSpeed = m_agent.speed;

        // Set the charging speed
        m_agent.speed = chargeSpeed;

        // Charge for the specified duration
        yield return new WaitForSeconds(chargeDuration);

        // Reset the speed and charge timer
        m_agent.speed = originalSpeed;
        chargeTimer = 0f;
        isCharging = false;
    }



    protected override void Update()
    {
        base.Update();

        if (!isCharging)
        {
            chargeTimer += Time.deltaTime;
            if (chargeTimer >= chargeCooldown)
            {
                StartCoroutine(Charge());
            }
        }
    }
}
