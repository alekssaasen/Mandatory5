using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mid_PaintDispenser : MonoBehaviour
{
    private Mid_PaintButton paintButtonOne;
    private Mid_PaintButton paintButtonTwo;

    public GameObject goalColor;
    private bool colorOne, colorTwo, colorThree;
    public bool buttonsUnlocked;

    private Transform brushSpawnLoc;
    public GameObject brushOnePrefab, brushTwoPrefab, brushThreePrefab;
    private Color purple;
    private Color orange;


    // Start is called before the first frame update
    void Start()
    {
        paintButtonOne = GameObject.Find("ButtonOne").GetComponent<Mid_PaintButton>();
        paintButtonTwo = GameObject.Find("ButtonTwo").GetComponent<Mid_PaintButton>();

        brushSpawnLoc = GameObject.Find("BrushSpawnLoc").GetComponent<Transform>();


       
        goalColor = GameObject.Find("GoalColor");
        goalColor.GetComponent<Renderer>().material.color = Color.green;

        buttonsUnlocked = true;
        colorOne = true;
        colorTwo = false; 
        colorThree = false;

        purple = new Color32(143, 0, 254, 1);
        orange = new Color32(254, 161, 0, 1);
        

    }

    // Update is called once per frame
    void Update()
    {
        if (colorOne) //Yellow + Blue = Green
        {
           
            if (paintButtonOne.yellow & paintButtonTwo.blue || paintButtonOne.blue & paintButtonTwo.yellow)
            {
                SpawnBrushOne();
                buttonsUnlocked = false;
                colorTwo = true;
                colorOne = false;
            }
            
        }
        if (colorTwo)//Blue + Red = Purple
        {
            if (paintButtonOne.blue & paintButtonTwo.red || paintButtonOne.red & paintButtonTwo.blue)
            {
                SpawnBrushTwo();
                buttonsUnlocked = false;
                colorThree = true;
                colorTwo = false;
            }
        }
        if (colorThree)// Yellow + Red = Orange
        {
            if (paintButtonOne.yellow & paintButtonTwo.red || paintButtonOne.red & paintButtonTwo.yellow)
            {
                SpawnBrushThree();
                buttonsUnlocked = false;
                
                colorThree = false;
            }

        }
    }

    private void SpawnBrushOne()
    {
        Instantiate(brushOnePrefab, brushSpawnLoc.position, brushSpawnLoc.rotation);
        goalColor.GetComponent<Renderer>().material.color = purple;

    }
    private void SpawnBrushTwo()
    {
        Instantiate(brushTwoPrefab, brushSpawnLoc.position, brushSpawnLoc.rotation);
        goalColor.GetComponent<Renderer>().material.color = orange;



    }
    private void SpawnBrushThree()
    {
        Instantiate(brushThreePrefab, brushSpawnLoc.position, brushSpawnLoc.rotation);


    }

}
