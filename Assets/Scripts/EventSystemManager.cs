using UnityEngine;
using UnityEngine.EventSystems;

public class EventSystemManager : MonoBehaviour
{
    private void Awake()
    {
        // Find all EventSystem instances in the scene
        EventSystem[] eventSystems = FindObjectsOfType<EventSystem>();

        // If there is more than one EventSystem, destroy the others
        if (eventSystems.Length > 1)
        {
            for (int i = 1; i < eventSystems.Length; i++)
            {
                Destroy(eventSystems[i].gameObject);
            }
        }

        // Ensure this EventSystem persists across scenes
        DontDestroyOnLoad(gameObject);
    }
}