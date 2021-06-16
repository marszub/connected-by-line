using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Game_Manager
{
    public class NewGameButton : MonoBehaviour
    {
        public void NewGame()
        {
            Debug.Log("New Game");
            SceneManager.LoadScene(GameManager.instance.gameSceneName, LoadSceneMode.Single);
        }
    }
}