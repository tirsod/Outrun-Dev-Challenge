using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;

public class Swipe : MonoBehaviour
{

    public static Action OnSwipeLeft = () => { };
    public static Action OnSwipeRight = () => { };

    private void OnEnable()
    {
        LeanTouch.OnFingerSwipe += DetermineSwipeDirection;
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerSwipe -= DetermineSwipeDirection;
    }

    private void DetermineSwipeDirection(LeanFinger finger)
    {
        Vector2 dragDelta = finger.SwipeScaledDelta;
        
        if (dragDelta.x > 0.2f) OnSwipeRight.Invoke();
        if (dragDelta.x < 0.2f) OnSwipeLeft.Invoke();
    }

}
