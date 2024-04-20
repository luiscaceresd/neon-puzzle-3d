using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    [SerializeField] private GameObject Lazer;
    [SerializeField] private Material winMaterial, absorbMaterial, defaultMaterial;
    private int lazerCount = 0;
    private Renderer r;
    [SerializeField] private GameManager gm;
    [SerializeField] private Text energyCount;

    private void Start()
    {
        r = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("LAZER"))
        {
            lazerCount++;
            gm.UpdateEnergyCount();
            Destroy(other.gameObject);

            if (lazerCount >= 30)
            {
                r.material = winMaterial;
            }
        }
    }

    //once energy reaches 0 call win scene on game manager
    private void Update()
    {
        if (int.Parse(energyCount.text) == 0)
        {
            gm.WinScene();
        }
    }

}
