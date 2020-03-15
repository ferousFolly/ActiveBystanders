using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEventManager
{
    private static int doorsHasBeenOpened = -1;
    private static int flashLighHasBeenUsed = -1;

    public static void IncreaseOpeningDoorNumbers() {
        doorsHasBeenOpened += 1;
    }

    public static int GetOpeningDoorNumbers() {
        return doorsHasBeenOpened;
    }

    public static void IncreaseFlashLightUsedNumber() {
        flashLighHasBeenUsed += 1;
    }

    public static int GetFlashLightUsedNumbers() {
        return flashLighHasBeenUsed;
    }

   
}

