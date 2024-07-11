using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    bool isSwitchedCharacter = false;

    [SerializeField] GameObject effect;

    private void OnTriggerEnter(Collider other)
    {

        if (!isSwitchedCharacter && other.gameObject.tag == "Player")
        {
            isSwitchedCharacter = true;
            MindControlHandler.Instance.SwitchCharacter();
            StartCoroutine(Effect(false));
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (isSwitchedCharacter && other.gameObject.tag == "Player")
        {
            isSwitchedCharacter = false;
            StartCoroutine(Effect(true));
        }
    }

    IEnumerator Effect(bool value)
    {
        yield return new WaitForSeconds(1f);
        effect.SetActive(value);
    }
}
