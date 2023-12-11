using UnityEngine;

public enum AnimationType
{
    houseDancing, macarenaDance, waveHipHopDance
}

public class AnimationSelector : MonoBehaviour
{
    public void SelectAnimation(string animation)
    {
        switch (animation)
        {
            case "House Dancing":
                GameManager.Instance.animationSelected = AnimationType.houseDancing;
                break;
            case "Macarena Dance":
                GameManager.Instance.animationSelected = AnimationType.macarenaDance;
                break;
            case "Wave Hip Hop Dance":
                GameManager.Instance.animationSelected = AnimationType.waveHipHopDance;
                break;
        }
    }
}
