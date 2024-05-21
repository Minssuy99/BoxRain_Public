using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CAnimationHandler : MonoBehaviour
{
    private Animator m_Animator;

    void Awake()
    {
        m_Animator = GetComponentInChildren<Animator>();
    }

    public void OnEnterNextScene()
    {
        Destroy(transform.parent.gameObject);
    }
}
