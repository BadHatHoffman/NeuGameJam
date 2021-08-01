using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{
    public FPSController fpsController;
    public int damage;
    public Health health;

    public void SwapToHuman()
    {
        fpsController.isTiger = false;
    }

    public void SwapToTiger()
    {
        fpsController.isTiger = true;
    }
}
