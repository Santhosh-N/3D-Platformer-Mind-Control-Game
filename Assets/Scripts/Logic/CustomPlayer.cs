using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomPlayer : MonoBehaviour
{
    [SerializeField] GameObject pickItemEffect;
    public void OnPickItem()
    {
        pickItemEffect.SetActive(true);
    }

    public void OnDropItem()
    {
        pickItemEffect.SetActive(false);
    }
}
