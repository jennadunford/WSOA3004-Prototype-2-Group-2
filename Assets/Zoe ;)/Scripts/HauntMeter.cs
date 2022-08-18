using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HauntMeter : MonoBehaviour
{
    [SerializeField]
    private float duration = 3f;

    private Image hauntMeter;

    private void Start()
    {
        hauntMeter = this.gameObject.GetComponent<Image>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            StartCoroutine(CountingDown());
        }

        hauntMeter.fillAmount = 1;
    }

    IEnumerator CountingDown()
    {
        float normalizedTime = 0;

        while(normalizedTime <= 1f)
        {
            hauntMeter.fillAmount = 1 - normalizedTime;
            normalizedTime += Time.deltaTime / duration;
            
            yield return null;
        }
    }
}
