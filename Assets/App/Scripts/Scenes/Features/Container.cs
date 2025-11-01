using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    virtual public void IngridientDropped(GameObject ingridient)
    {
        Destroy(ingridient);
    }
}
