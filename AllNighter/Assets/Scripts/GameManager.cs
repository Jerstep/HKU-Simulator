using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerMovement playerMovement;
    public InteractionManager interactionManager;
    public UIManager uiManager;

    private int previousScene;

    public float energy = 100;
    public float fullEnergy = 100;
    public float EnergyDepleationSpeed = 1;
    public Image coffeeMeter;

    public bool coffeeDone = false;
    public bool makinCoffee = false;
    public GameObject coffeeCup;
    float coffeeProgress;

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        interactionManager = GetComponent<InteractionManager>();
        uiManager = GetComponent<UIManager>();
    }

    private void Update()
    {
        EnergyDepleation();
        CheckEnergy();
    }

    #region EnergyManagment;
    void CheckEnergy()
    {
        if(energy > 100)
        {
            energy = 100;
        }

        if(makinCoffee)
        {
            CoffeeMachine();
        }
    }

    void EnergyDepleation()
    {
        energy -= Time.deltaTime * EnergyDepleationSpeed;
    }

    public void CoffeeMachine()
    {
        if(!coffeeDone && coffeeProgress < 1f)
        {
            coffeeProgress += 0.01f;
            coffeeMeter.fillAmount = coffeeProgress;

            //print("Making Coffee");
            //print(coffeeProgress);
            if(coffeeProgress > 1f)
            {
                coffeeDone = true;
                coffeeCup.GetComponent<CoffeeDone>().SetMaterialDone();
                //print("Coffee Done");
            }
        }
    }

    public void ResetCoffeeMachine()
    {
        makinCoffee = false;
        coffeeDone = false;
        coffeeProgress = 0;
        coffeeMeter.fillAmount = coffeeProgress;
        coffeeCup.GetComponent<CoffeeDone>().SetMaterialOriginal();
    }

    public void AddEnergy(float amountToAdd)
    {
        energy += amountToAdd;
    }

    void EnergyDepleted()
    {

    }
    #endregion

    #region PlayerMovement;
    public void BehindPc()
    {
        playerMovement.isBehindPc = true;
    }

    public void LeftPc()
    {
        playerMovement.isBehindPc = false;
    }

    public bool IsPlayerBehindPc()
    {
        return playerMovement.isBehindPc;
    }
    #endregion
}
