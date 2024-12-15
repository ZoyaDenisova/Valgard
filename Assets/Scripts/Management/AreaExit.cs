using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // �������� ��� ������ � UI

public class AreaExit : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private string sceneTransitionName;
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private GameObject warningText; // ��������������� �����

    private float waitToLoadTime = 1f;
    private bool allEnemiesDead = false;

    private void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        allEnemiesDead = false;
        warningText.SetActive(false); // �������� ����� �� ���������
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            if (allEnemiesDead)
            {
                SceneManagement.Instance.SetTransitionName(sceneTransitionName);
                UIFade.Instance.FadeToBlack();
                StartCoroutine(LoadSceneRoutine());
            }
            else
            {
                // ���������� ��������������
                warningText.SetActive(true);
            }
        }
    }

    private void Update()
    {
        allEnemiesDead = true;
        foreach (GameObject enemy in enemies)
        {
            if (enemy != null)
            {
                allEnemiesDead = false;
                break;
            }
        }

        // �������� ��������������, ���� ��� ����� ������
        if (allEnemiesDead)
        {
            warningText.SetActive(false);
        }
    }

    private IEnumerator LoadSceneRoutine()
    {
        while (waitToLoadTime >= 0)
        {
            waitToLoadTime -= Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(sceneToLoad);
    }
}
