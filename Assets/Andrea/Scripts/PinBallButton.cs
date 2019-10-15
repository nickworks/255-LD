using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinBallButton : MonoBehaviour
{

    public GameObject flipper;
    FlipperController flipperController;

    
    // Start is called before the first frame update
    void Start()
    {
        flipperController = flipper.GetComponent<FlipperController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnMouseDown()
    {
        flipperController.flipperPosition = flipperController.pressedPosition;
    }

    void OnMouseUp()
    {
        flipperController.flipperPosition = flipperController.restPosition;
    }
}
