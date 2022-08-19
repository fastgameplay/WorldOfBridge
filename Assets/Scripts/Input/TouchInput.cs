using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public bool Tap { get { return tap; } }
    public bool Hold { get { return hold; } }
    public bool DoubleTap { get { return doubleTap; } }
    public bool IsStatic { get { return isStatic; } }

    public float Horizontal { get { return movementDelta.x; } }
    public float Vertical { get { return movementDelta.y; } }
    public Vector2 Axis { get { return movementDelta; } }

    private Vector2 startTouch, movementDelta, lastPosition;
    private float lastTap, lastChange;
    private bool tap,hold, doubleTap, isStatic;

   


    private void Update(){
        tap = doubleTap = false;

#if UNITY_EDITOR
    UpdateStandalone();
#else
    UpdateMobile();
#endif
    
    }

    private void UpdateStandalone(){
        if (Input.GetMouseButtonDown(0)){
            tap = true;
            hold = true;
            isStatic = false;

            startTouch = Input.mousePosition;
            if(Time.time < lastTap + 0.5f){
                doubleTap = true;
            }
            else{
                lastTap = lastChange = Time.time;
            }
        }
        else if (Input.GetMouseButtonUp(0)){
            hold = isStatic = false;
            startTouch = Vector2.zero;
        }

        //Movement Check
        if(startTouch != Vector2.zero && Input.GetMouseButton(0)){

            movementDelta = (Vector2)Input.mousePosition - startTouch;
            if(lastChange + 0.25f < Time.time){
                lastPosition = Input.mousePosition;
                lastChange = Time.time;
            }

            if (Vector2.Distance(lastPosition, (Vector2)Input.mousePosition) < 0.5)
                isStatic = true;
            else
                isStatic = false;

        }
    }

    private void UpdateMobile(){
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                hold = true;
                isStatic = false;

                startTouch = Input.touches[0].position;
                if (Time.time < lastTap + 0.5f)
                {
                    doubleTap = true;
                }
                else
                {
                    lastTap = lastChange = Time.time;
                }
            }

            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                hold = isStatic = false;
                startTouch = Vector2.zero;
            }



            //Movement Check
            if (startTouch != Vector2.zero)
            {

                movementDelta = (Vector2)Input.mousePosition - startTouch;
                if (lastChange + 0.25f < Time.time)
                {
                    lastPosition = Input.mousePosition;
                    lastChange = Time.time;
                }

                if (Vector2.Distance(lastPosition, (Vector2)Input.mousePosition) < 0.5)
                    isStatic = true;
                else
                    isStatic = false;

            }
        }
    }
}
