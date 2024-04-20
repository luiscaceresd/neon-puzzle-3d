using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InitializeGameManager();
    }

    private void InitializeGameManager() {
        GameManager existingGameManager = FindObjectOfType<GameManager>();
        if(existingGameManager == null) {
            GameObject gameManagerPreFab = Resources.Load<GameObject>("prefabs/GAME_MANAGER");
            Instantiate(gameManagerPreFab);
        }
    }
}
