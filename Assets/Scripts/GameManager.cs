using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool weaponOneIsTaked;
    public bool weaponTwoIsTaked;
    public bool weaponTwoIsFired;
    public bool openCloseBubble;
    public bool bubbleIsShowed;

    void Awake()
   {
        if (Instance == null)
        {
            Instance = this;
        }
        
   }
}
