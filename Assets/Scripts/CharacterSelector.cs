using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelector : MonoBehaviour
{
    public GameObject[] characters;
    public GameObject[] charc2;
    private int selectedchar = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject ch in characters)
        {
            ch.SetActive(false);
        }
        characters[selectedchar].SetActive(true);
    }

    // change char
    public void ChangeCharacter(int newChar)
    {
        characters[selectedchar].SetActive(false);
        characters[newChar].SetActive(true);
        selectedchar = newChar;
    }
    public void MultipleBall()
    {
        foreach (GameObject ch in charc2)
        {
            ch.SetActive(false);
        }
        charc2[selectedchar].SetActive(true);
    }
}
