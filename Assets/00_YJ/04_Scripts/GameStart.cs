using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void PressStart()
    {
        SceneManager.LoadScene("HW01_YJ");
    }

}