using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }
}
