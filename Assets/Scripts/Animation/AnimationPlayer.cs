using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public GameObject animatedPlayer;

    void Start()
    {
        switch (GameManager.Instance.animationSelected)
        {
            case AnimationType.houseDancing:
                animatedPlayer.GetComponent<Animator>().Play("House Dancing");
                break;
            case AnimationType.macarenaDance:
                animatedPlayer.GetComponent<Animator>().Play("Macarena Dance");
                break;
            case AnimationType.waveHipHopDance:
                animatedPlayer.GetComponent<Animator>().Play("Wave Hip Hop Dance");
                break;
        }
    }
}
