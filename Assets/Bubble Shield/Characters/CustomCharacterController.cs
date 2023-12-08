using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomCharacterController : MonoBehaviour
{
    [SerializeField] Shield _Shield;
    [SerializeField] Animator _Anim;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _Anim.SetTrigger("Cast");
        }
    }

    private void AnimationCallback_CastSpell()
    {
        _Shield.OpenCloseShield();
    }
}
