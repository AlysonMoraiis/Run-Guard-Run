using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerSwipeControl : MonoBehaviour
{
    public Text outputText;

    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    private Vector2 endTouchPosition;
    private bool stopTouch = false;

    public float swipeRange;
    public float tapRange;

    public event Action OnSwipeUp;
    public event Action OnSwipeDown;
    public event Action OnSwipeRight;
    public event Action OnSwipeLeft;


    private void Update()
    {
        Swipe();
    }


    public void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;

            if (!stopTouch)
            {
                if (Distance.x < -swipeRange)
                {
                    OnSwipeLeft?.Invoke();
                    outputText.text = "Left";
                    stopTouch = true;
                }

                else if (Distance.x > swipeRange)
                {
                    OnSwipeRight?.Invoke();
                    outputText.text = "Right";
                    stopTouch = true;
                }

                else if (Distance.y > swipeRange)
                {
                    OnSwipeUp?.Invoke();
                    outputText.text = "Up";
                    stopTouch = true;
                }

                else if (Distance.y < -swipeRange)
                {
                    OnSwipeDown?.Invoke();
                    outputText.text = "Down";
                    stopTouch = true;
                }
            }
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;

            endTouchPosition = Input.GetTouch(0).position;

            Vector2 Distance = endTouchPosition - startTouchPosition;

            if(Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                outputText.text = "Tap";
            }
        }
    }
}
