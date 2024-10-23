using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ProgressionManager : MonoBehaviour
{

    public static ProgressionManager Instance { get; private set; }

    /** Progression Items **/
    public bool ProgressionGate1 = false;
    public bool ProgressionGate2 = false;
    public bool ProgressionGate3 = false;


    //Story
    public bool FriendsHat { get; set; }
    public bool Diary { get; set; }
    public bool Key { get; set; }
    

    //Diary
    public bool DiaryPage1 { get; set; }
    public bool DiaryPage2 { get; set; }
    public bool DiaryPage3 { get; set; }
    public bool DiaryPage4 { get; set; }

    //Spell Items
    public bool Herb { get; set; }
    public bool Finger { get; set; }
    public bool Oil { get; set; }
    public bool MagicWord { get; set; }
    public bool HasSpell => Herb && Finger && Oil && MagicWord;

    //Weapon Items
    public bool BaseballBat { get; set; }
    public bool Nails { get; set; }
    public bool Rag { get; set; }
    public bool Lighter { get; set; }

    public bool Weapon3 => BaseballBat && Nails && Rag && Lighter;
    public bool Weapon2 => BaseballBat && Nails;
    public bool Weapon1 => BaseballBat;

    //Utility Items
    public bool Flashlight { get; set; }

    //Base Stats
    public float BaseWeaponAccuracy = 0.2f;
    public float BaseWeaponDamage = 20f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float GetWeaponAccuracy()
    {
        return BaseWeaponAccuracy + (Weapon2 ? 0.1f : 0) + (Weapon3 ? 0.25f : 0);
    }

    public float GetWeaponDamage()
    {
        return BaseWeaponDamage + (Weapon2 ? 10f : 0) + (Weapon3 ? 10f : 0);
    }

    public void ProgressionCheck()
    {
        if(!ProgressionGate1)
        {
            if(FriendsHat && Diary)
            {
                ProgressionGate1 = true;
                FindObjectsOfType<Interactable>().ToList().FindAll(i => i is not CropCircle).ForEach(i => i.AllowInteract(true));
            }
        }

        if(!ProgressionGate2)
        {
            if(DiaryPage1 && DiaryPage2 && DiaryPage3 && DiaryPage4)
            {
                Debug.Log("Progression Gate 2");
                ProgressionGate2 = true;
                FindObjectOfType<CropCircle>().AllowInteract(true);
            }
        }

        if(!ProgressionGate3)
        {
            if(Key)
            {
                Debug.Log("Progression Gate 3");
                ProgressionGate3 = true;
                FindObjectsOfType<Scarecrow>().ToList().ForEach(i => i.DestroyInteractable());
            }
        }
    }
}
