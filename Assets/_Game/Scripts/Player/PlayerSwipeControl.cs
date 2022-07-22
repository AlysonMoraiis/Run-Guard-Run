using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerSwipeControl : MonoBehaviour
{
    [SerializeField] private GameData _gameData;

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
        if (_gameData.ControlType)
        {
            Swipe();
        }
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
                    //left
                    OnSwipeLeft?.Invoke();
                    stopTouch = true;
                }

                else if (Distance.x > swipeRange)
                {
                    //right
                    OnSwipeRight?.Invoke();
                    stopTouch = true;
                }

                else if (Distance.y > swipeRange)
                {
                    //up
                    OnSwipeUp?.Invoke();
                    stopTouch = true;
                }

                else if (Distance.y < -swipeRange)
                {
                    //down
                    OnSwipeDown?.Invoke();
                    stopTouch = true;
                }
            }
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            stopTouch = false;

            endTouchPosition = Input.GetTouch(0).position;

            Vector2 Distance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(Distance.x) < tapRange && Mathf.Abs(Distance.y) < tapRange)
            {
                //tap
            }
        }
    }
}
