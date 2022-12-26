using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    static int kills = 0;

    public static int GetKills() { return kills; }
    public static void AddKill(){ kills++; }
    public static void Clear() { kills = 0;}
}
