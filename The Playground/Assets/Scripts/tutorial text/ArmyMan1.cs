using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ArmyMan1 : MonoBehaviour
{
    public TextMeshProUGUI NPCText;
    public int text_stage = 0;
    GameObject player;
    Inputs inputs;
    public bool on;

    public GameObject MainUI;
    public GameObject NPCUI;

    public Image pic;
    public Sprite picSprite;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inputs = player.GetComponent<Inputs>();
        on = false;
    }
    private void Update()
    {
        if(text_stage == 1)
        {
            NPCText.text = "WELL DONE SOLDIER, I THINK YOU ARE READY TO GET INTO THE THICK OF IT NOW!";
            MainUI.SetActive(false);
            NPCUI.SetActive(true);
            pic.sprite = picSprite;
        }
        if(text_stage == 2)
        {
            NPCText.text = "GO GRAB THAT WEAPON OVER ON THE OTHER SIDE OF THE BRIDGE";
        }
        if (text_stage == 3)
        {
            NPCText.text = "YOU HAVE 2 WEAPON SLOTS, SWITCH BETWEEN THEM USING  OR <sprite=9> / <sprite=10>";
        }
        if (text_stage == 4)
        {
            NPCText.text = "GET A FEEL FOR YOUR NEW FOUND WEAPONRY AND WHENEVER READY, GO DOWN THAT SLIDE";
        }

        if (text_stage == 5)
        {            
            MainUI.SetActive(true);
            NPCUI.SetActive(false);
            gameObject.GetComponent<ArmyMan>().enabled = false;

        }
        if (inputs.interacting && text_stage > 0)
        {
            text_stage += 1;
            //inputs.interacting = false;
        }
    }
}
