using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cards : MonoBehaviour
{
    int[] p1C = new int[3];
    int p1CAmmount=0;
    public GameObject Card1Select;
    public GameObject Card1NonSelect;
    public GameObject Card1;
    public GameObject Card2;
    public GameObject Card3;
    public GameObject Card4;
    public GameObject Card5;
    public GameObject Card6;
    public GameObject Card7;
    public GameObject Card8;
    public GameObject Card9;
    public GameObject Card10;

    public static bool C1Select;


    // Start is called before the first frame update

    void Start()
    {
        C1Select= false;
        Card1Select.SetActive(C1Select);
        Card1NonSelect.SetActive(!C1Select);

        for (int i = 0; i < 3; i++)
        {
            int randN = Random.Range(1, 10);
            p1C[p1CAmmount] = randN;
            Debug.Log("card#" + (p1CAmmount + 1) + " is " + p1C[p1CAmmount]);
            p1CAmmount++;


        }
        Card1.SetActive(false);
        Card2.SetActive(false);
        Card3.SetActive(false);
        Card4.SetActive(false);
        Card5.SetActive(false);
        Card6.SetActive(false);
        Card7.SetActive(false);
        Card8.SetActive(false);
        Card9.SetActive(false);
        Card10.SetActive(false);
        if (p1C[1] == 1)
        {
            Card1.SetActive(true);
        }
        else if (p1C[0] == 2)
        {
            Card2.SetActive(true);
        }
        else if (p1C[0] == 3)
        {
            Card3.SetActive(true);
        }
        else if (p1C[0] == 4)
        {
            Card4.SetActive(true);
        }
        else if (p1C[0] == 5)
        {
            Card5.SetActive(true);
        }
        else if (p1C[0] == 6)
        {
            Card6.SetActive(true);
        }
        else if (p1C[0] == 7)
        {
            Card7.SetActive(true);
        }
        else if (p1C[0] == 8)
        {
            Card8.SetActive(true);
        }
        else if (p1C[0] == 9)
        {
            Card9.SetActive(true);
        }
        else if (p1C[0] == 10)
        {
            Card10.SetActive(true);
        }
    }
    //public void drawCards()
    //{

    public void check()
    {
        C1Select = !C1Select;
       

    }
    //}

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("cards " + p1C);
        Card1Select.SetActive(C1Select);
        Card1NonSelect.SetActive(!C1Select);
    }
}
