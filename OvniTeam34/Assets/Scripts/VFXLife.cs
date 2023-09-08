using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXLife : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyParticleSystem());
    }

    private IEnumerator DestroyParticleSystem()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
