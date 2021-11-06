using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerItem : MonoBehaviour
{
    void Update()
    {
        transform.Translate(Vector2.down * 1.75f * Time.deltaTime);
    }
}
