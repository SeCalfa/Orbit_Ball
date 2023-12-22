using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField]
    private Player player;

    private Touch touch;

    private void Update()
    {
        TapDetector();
    }

    private void TapDetector()
    {
#if UNITY_ANDROID
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                player.ChangeDirection();
            }
        }
#endif

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            player.ChangeDirection();
        }
# endif
    }

}
