using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance { get; private set; }

    public GameObject heartPrefab; // Assign this in the inspector
    public Sprite fullHeart; // Full heart sprite
    public Sprite emptyHeart;

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