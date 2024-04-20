using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private static Text energyCount;
    [SerializeField] private Text instructions;

    // static makes attribute a class attribute, there is only 1
    public static GameManager gmInstance;

    private void Awake()
    {
        if (gmInstance == null)
        {
            gmInstance = this; //this instance of the script
            DontDestroyOnLoad(gameObject); // gameObject is the object this script is attached to
        }
        else
        {
            Destroy(gameObject);
        }

        // hide the energy label after 10 seconds
        Invoke("HideInstructions", 10);
    }

    private void OnEnable()
    {
        // Find the Text component in the new scene
        energyCount = GameObject.Find("energyCount").GetComponent<Text>();
    }

    public void UpdateEnergyCount()
    {
        if (energyCount != null && int.Parse(energyCount.text)>0)
        {
            //convert killCount to an int, add 1, convert back to string
            energyCount.text = (int.Parse(energyCount.text) - 1).ToString();
        }
    }

    // get the GameEnergyLabel and hide it after 10 seconds
    public void HideInstructions()
    {
        instructions.gameObject.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //ONCE ENERGY REACHES 0 call winscene
    public void WinScene()
    {
        SceneManager.LoadScene("WinScene");
    }
}
