using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holder : MonoBehaviour
{
    [field: SerializeField] public HolderAnimator Animator { get; private set; }
}
