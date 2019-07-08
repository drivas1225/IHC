using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicMenu : MonoBehaviour
{
    public static int music;

    public void playgame()
    {
        music = int.Parse(gameObject.name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
