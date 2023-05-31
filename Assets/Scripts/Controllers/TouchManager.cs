using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class TouchManager : MonoBehaviour
{
    private Vector2 tapLocation;
    public Canvas cameraCanvas;
    public Vector2 TapLocation { get { return tapLocation; } }
    private bool isTapping;
    public bool IsTapping { get { return isTapping; } }
    private int joystick_id = -1;
    public RectTransform joystickRect;
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    // check if touch in rect and js not active
                    if (RectTransformUtility.RectangleContainsScreenPoint(joystickRect, touch.position, cameraCanvas.worldCamera) && joystick_id == -1)
                    {
                        Debug.Log("JS touched");
                        joystick_id = touch.fingerId;
                        continue;
                    }

                    //Debug.Log("not in rect");
                    // touch input begins
                    isTapping = true;
                    tapLocation = Camera.main.ScreenToWorldPoint(touch.position);

                }
                else if (touch.phase == TouchPhase.Moved)
                {
                    if (touch.fingerId != joystick_id)
                    {
                        tapLocation = Camera.main.ScreenToWorldPoint(touch.position);
                    }
                }

                else if (touch.phase == TouchPhase.Ended)
                {
                    if (touch.fingerId == joystick_id)
                    {
                        joystick_id = -1;

                    }
                    else
                    {
                        isTapping = false;
                    }
                }
            }
        }
    }






}
