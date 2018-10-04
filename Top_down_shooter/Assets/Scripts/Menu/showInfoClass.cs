using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class showInfoClass : MonoBehaviour, IPointerEnterHandler
{

    public Button button;

    public Text textMisc;
    public Text textSpecial;
    public Text classType;

    private void Start()
    {
        textMisc = GameObject.FindGameObjectWithTag("DescrTxt").GetComponent<Text>();
        textSpecial = GameObject.FindGameObjectWithTag("SpecialTxt").GetComponent<Text>();
        classType = GameObject.FindGameObjectWithTag("ClassTxt").GetComponent<Text>();
        button = gameObject.GetComponent<Button>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
      
            if(button.gameObject.name == "Magus")
            {
                classType.text = "Class: Magus";
                textSpecial.text = "Special(shift): Call vortex";
                textMisc.text = "-At higher Wpower levels it can launch a missile that can pierce anything." + "\n" + "-The vortex will suck all enemy bullets";
            }

            if(button.gameObject.name == "Shaman")
            {
                classType.text = "Class: Shaman";
                textSpecial.text = "Special(shift): Runic Blessing";
            textMisc.text = "-Ken rune enable you to use kicks and punchs on the combos, its special doubles the attack speed." + "/n" + "-Isa runes can only utilize punches, but its special can be devastating as it'll instakill an enemy and spawn a protective wall" + "\n"
                + "-Jera rune utilize kicks that do less damage, but the special will heal you over time and damage enemies in the area" + "\n" + "-Once you've got a rune, no more will drop."; 
            }

            if(button.gameObject.name == "Engineer")
            {
                classType.text = "Class: Engineer";
                textSpecial.text = "Special(shift): Explosion!";
                textMisc.text = "-The engineer turret will explode anything in front of it in a large area" + "\n" + "-Engineer does have mechanisms that buff him or offer protection"
                    + "\n" + "Ctrl: Attack speed buff" + "\n" + "Right button Mouse: Damage buff" + "\n" + "E: Shield";
            }

            if(button.gameObject.name == "Priest")
            {
                classType.text = "Class: Priest";
                textSpecial.text = "Special(shift): Divine Smite";
                textMisc.text = "-The divine smite will only target lotus enemies!" + "\n" + "-The blessing will eventually drop from enemies in the form of a crystal"
                    + "\n" + "A blessing can be used to spawn a healing for the priest.";
            }

            if(button.gameObject.name == "Witch")
            {
                classType.text = "Class: Witch";
                textSpecial.text = "Special(shift): The time stop";
                textMisc.text = "-The time stop makes it very difficult to control your speed." + "\n" + "Use your stopped time to make a war cry in real life."
                    + "\n" + "- Your projectiles cause more damage if you're closer to the enemy!";
            }

            if(button.gameObject.name == "Alchemist")
            {
                classType.text = "Class: Alchemist";
                textSpecial.text = "Special(shift): Divide and conquer";
                textMisc.text = "-The main mechanic of the alchemist is to use the alchemical circles to buff himself." + "\n" + "-Alchemical circles only last 10 seconds while on the ground, take'em quick" +
                    "\n" + "-The thunder alchemical circle will one-shot any enemy." + "\n" + "-The special of the alchemist will spawn 4 more projectiles of the type being used at moment"
                    + "\n" + "-Sometimes the projectiles will fail";
            
            }

            if (button.gameObject.name == "Lunar Knight")
            {
            classType.text = "Class: Lunar Knight";
                textSpecial.text = "Special(shift): Moon Strike";
                textMisc.text = "-The lunar knight excels at dealing damage at melee range, but the right button throws his scythe at enemies" + "\n" + "-Moon strike can do a lot of damage against clump of enemies";

            }

        if (button.gameObject.name == "Solar Knight")
        {
            classType.text = "Class: Alchemist";
            textSpecial.text = "Special(shift): Solar Cruelty";
            textMisc.text = "-The solar knight does have a combo system with a powerful attack on the last hit." + "\n" + "-Solar cruelty instakill all enemies in a radius";

        }


        // Do something.
        Debug.Log("<color=red>Event:</color> Completed mouse highlight.");
    }
}
