using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance { get; private set; }

    public GameObject heartPrefab; // Assign this in the inspector
    public Sprite fullHeart; // Full heart sprite
    public Sprite emptyHeart;

    [SerializeField] private float m_regenerationTime;
    private bool m_isRegenerating;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            m_isRegenerating = false;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (!m_isRegenerating & PlayerController.Instance.Health < PlayerController.Instance.MaxHealth)
        {
            StartCoroutine(RegenerateHealth());
        }
    }

    [SerializeField] private float xPadding;

    private List<Image> hearts = new List<Image>();

    private void Start()
    {
        InitializeHealth(PlayerController.Instance.Health);
    }
    public void InitializeHealth(int initialHealth)
    {
        for (int i = 0; i < initialHealth; i++)
        {
            GameObject newHeart = Instantiate(heartPrefab, transform);
            newHeart.transform.position += new Vector3(i * xPadding, 0, 0);
            hearts.Add(newHeart.GetComponent<Image>());
        }

        UpdateHealth(initialHealth);
    }

    private IEnumerator RegenerateHealth()
    {
        m_isRegenerating = true;
        yield return new WaitForSeconds(m_regenerationTime);
        UpdateHealth(PlayerController.Instance.Health + 1);
        PlayerController.Instance.Health = PlayerController.Instance.Health + 1;
        m_isRegenerating = false;
    }

    public void UpdateHealth(int currentHealth)
    {
        for (int i = 0; i < hearts.Count; i++)
        {
            if (i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
}