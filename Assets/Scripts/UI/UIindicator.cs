using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIindicator : MonoBehaviour
{
    [SerializeField] private HealthModules healthmodule;
    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private GameObject deathScreen;

    // Start is called before the first frame update
    void Start()
    {
        healthmodule.OnHealthChaged.AddListener(Updatehealthtext);
        healthmodule.OnDie.AddListener(deathPannel);
        GameManager.Singleton.OnRespawn.AddListener(disableDeathPannel);
        //healthmodule.OnCsharpHealthChanged += Updatehealthtext;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Updatehealthtext(int healthValue)
    {
        healthText.text = healthValue.ToString();
    }

    private void deathPannel()
    {
        deathScreen.SetActive(true);
    }

    private void disableDeathPannel()
    {
        deathScreen.SetActive(false);
    }
}
