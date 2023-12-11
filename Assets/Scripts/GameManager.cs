using UnityEditor.ShaderGraph;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool weaponOneIsTaked;
    public bool weaponTwoIsTaked;
    public bool weaponTwoIsFired;
    public bool openCloseBubble;
    public bool bubbleIsShowed;

    public AnimationType animationSelected;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(Instance);
        }
    }
}
