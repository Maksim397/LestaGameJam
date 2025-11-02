using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bowl : Holder
{
    [field: SerializeField] public IngredientType Type { get; private set; }
}
