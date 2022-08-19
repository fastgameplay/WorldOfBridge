using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public bool Tap { get { return tap; } }
    public bool Hold { get { return hold; } }
    public bool DoubleTap { get { return doubleTap; } }
    public bool IsStatic { get { return isStatic; } }
    
    public float Horizontal { get { return horizontal; } }
    public float HorizontalNormilized { get { return horizontal / screenHalfWidth; } }

    public float Vertical { get { return vertical; } }
    public float VerticalNormilized { get { return vertical / screenHalfHight; } }


    private Vector2 startTouch, movementDelta, lastPosition;
    private float lastTap, lastChange, horizontal, vertical;
    private int screenHalfWidth, screenHalfHight;
    private bool tap,hold, doubleTap, isStatic;

    private static TouchInput instance;
    public static TouchInput Instance
    {
        get
        {
            if(instance == null){
                instance = FindObjectOfType<TouchInput>();
                if (instance == null) {
                    instance = new GameObject("Spawned TouchInput", typeof(TouchInput)).GetComponent<TouchInput>();
                }
            }
            return instance;
        }
    }

    private void Awake(){
        screenHalfHight = Screen.height / 2;
        screenHalfWidth = Screen.width / 2;
    }

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

    }
}
