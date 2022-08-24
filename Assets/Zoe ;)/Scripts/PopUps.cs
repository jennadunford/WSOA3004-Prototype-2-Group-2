using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUps : MonoBehaviour
{
    [SerializeField]
    private GameObject humanInfo;
    [SerializeField]
    private GameObject dogInfo;
    [SerializeField]
    private GameObject spiderInfo;

    public void HumanPress()
    {
        if (humanInfo.activeInHierarchy)
        {
            humanInfo.SetActive(false);
        }
        else if (!humanInfo.activeInHierarchy)
        {
            humanInfo.SetActive(true);
            dogInfo.SetActive(false);
            spiderInfo.SetActive(false);
        }
    }

    public void DogPress()
    {
        if (dogInfo.activeInHierarchy)
        {
            dogInfo.SetActive(false);
        }
        else
        {
            humanInfo.SetActive(false);
            dogInfo.SetActive(true);
            spiderInfo.SetActive(false);
        }
    }

    public void SpiderPress()
    {
        if (spiderInfo.activeInHierarchy)
        {
            spiderInfo.SetActive(false);
        }
        else
        {
            humanInfo.SetActive(false);
            dogInfo.SetActive(false);
            spiderInfo.SetActive(true);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (humanInfo.activeInHierarchy)
            {
                humanInfo.SetActive(false);
            }
            else if (dogInfo.activeInHierarchy)
            {
                dogInfo.SetActive(false);
            }
            else if (spiderInfo.activeInHierarchy)
            {
                spiderInfo.SetActive(false);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            }
        }
    }
}
