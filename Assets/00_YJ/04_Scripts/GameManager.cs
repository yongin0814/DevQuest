using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // �̱��� + DDOL
    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            instance = this; //���ڽ��� instance�� �־�
            DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
    }

    // �ð�
    float time;
    public List<GameObject> animalList = new List<GameObject>();

    // ������ ��ġ
    public GameObject itemList;

    // Start is called before the first frame update
    void Start()
    {
        itemList.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time >= 180.0f || animalList.Count == 0) // 3�� �����ų� ��� ���ȷΰ� �������� 
        {
            GameOver(); // ���ӿ���
        }
    }

    void GameOver()
    {
            SceneManager.LoadScene("HW01_YJ_GameOver"); 
    }
}
