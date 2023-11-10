using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deer : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    public RuntimeAnimatorController[] controller;
    void Start()
    {
        animator.runtimeAnimatorController = controller[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
