using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSkillHandler : MonoBehaviour
{
    private Player player;
    private Transform playerPos;
    private int tempPlayerScore = 0;
    private bool multiplierOfScore = false;
    

    [Header("Debug Settings")]
    public bool isAllowSkill = true;
    public GameObject cardPanel;
    public bool isShowCardPanel = false;
    private List<int> randomIntList = new List<int>();
    [SerializeField] private int multiplierOfIntValue = 1500;

    [Header("Text UI")]
    public TextMeshProUGUI skillText1;
    public TextMeshProUGUI skillText2;
    public TextMeshProUGUI skillText3;


    [Header("Card List")]
    //public GameObject[] cards;
    public List<GameObject> cards = new List<GameObject>();


    [Header("Skill Set")]
    public GameObject damageAura;
    public bool isAllowDamageAura = false;
    public bool isUnlockedDamageAura = false;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        if (isAllowSkill)
        {
            //Damage Aura
            if (isAllowDamageAura)
            {
                DamageAura damageAuraScript = damageAura.GetComponent<DamageAura>();
                damageAuraScript.Spawn(playerPos);
                isUnlockedDamageAura = true;
            }
            
        }

        



    }


    private void Update()
    {

        if (isShowCardPanel)
        {
            cardPanel.SetActive(true);
            isShowCardPanel = true;
        }
        else
        {
            cardPanel.SetActive(false);
            isShowCardPanel = false;
        }

        tempPlayerScore = player.score;

        if (tempPlayerScore % multiplierOfIntValue == 0 && tempPlayerScore != 0 && !multiplierOfScore)
        {
            Debug.Log("Multiple of 1500 Reached");
            multiplierOfScore = true;

            //Show panel
            isShowCardPanel = true;
            int amountOfCards = cards.Count;
            int maxDisplayingCards = 3;
            for (int i = 0; i < maxDisplayingCards; i++)
            {
                int randomNumber = Random.Range(0, amountOfCards);
                randomIntList.Add(randomNumber);
                DisplaySkill(randomNumber, i);
            }
            Debug.Log(randomIntList.Count);
            

        }

        if (tempPlayerScore % multiplierOfIntValue != 0)
        {
            multiplierOfScore = false;
        }



        ////Temp code
        //if (Input.GetKeyDown(KeyCode.M))
        //{
        //    isShowCardPanel = !isShowCardPanel;

        //    if (isShowCardPanel)
        //    {
        //        int amountOfCards = cards.Count;
        //        int maxDisplayingCards = 3;
        //        for (int i = 0; i < maxDisplayingCards; i++)
        //        {
        //            int randomNumber = Random.Range(0, amountOfCards);
        //            randomIntList.Add(randomNumber);
        //            DisplaySkill(randomNumber, i);
        //        }
        //        Debug.Log(randomIntList.Count);
        //    }
        //    else
        //    {
        //        randomIntList.Clear();
        //    }
            
        //}

    }

    //foreach (Transform child in cardPanel.transform)
    //{
    //    // Destroy all child objects
    //    Destroy(child.gameObject);
    //}




    public void DisplaySkill(int whichSkill, int whichButton)
    {
        string tempText = "";
        if (whichSkill == 0)
        {
            tempText = "Damage Aura";
        }
        else if (whichSkill == 1)
        {
            tempText = "Test2";
        }
        else if (whichSkill == 2)
        {
            tempText = "Test3";
        }


        //Final
        if (whichButton == 0)
        {
            skillText1.text = tempText;
        }
        else if (whichButton == 1)
        {
            skillText2.text = tempText;
        }
        else if (whichButton == 2)
        {
            skillText3.text = tempText;
        }

        Time.timeScale = 0f; //NEED TO BE CHANGED LATER TEMP USE ONLY //NOTICE !!!
    }


    public void UnlockSkill(int whichSkill)
    {
        if (!isUnlockedDamageAura && whichSkill == 0)
        {
            isAllowDamageAura = true;
            DamageAura damageAuraScript = damageAura.GetComponent<DamageAura>();
            damageAuraScript.Spawn(playerPos);
            isUnlockedDamageAura = true;
            Debug.Log("Damage Aura Unlocked");
        }
        randomIntList.Clear();
        isShowCardPanel = false;
        Time.timeScale = 1f; //NEED TO BE CHANGED LATER TEMP USE ONLY //NOTICE !!!
    }

    public void ButtonOneClicked()
    {
        int tempInt = randomIntList[0];
        Debug.Log("Button 1 Clicked: " + tempInt);
        UnlockSkill(tempInt);
        
    }

    public void ButtonTwoClicked()
    {
        int tempInt = randomIntList[1];
        Debug.Log("Button 2 Clicked: " + tempInt);
        UnlockSkill(tempInt);
    }

    public void ButtonThreeClicked()
    {
        int tempInt = randomIntList[2];
        Debug.Log("Button 3 Clicked: " + tempInt);
        UnlockSkill(tempInt);
    }



}
