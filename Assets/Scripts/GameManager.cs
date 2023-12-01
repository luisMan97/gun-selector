using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool weaponOneIsTaked;
    public bool weaponTwoIsTaked;

    private void Awake()
    {
        Instance = this;
    }
}
