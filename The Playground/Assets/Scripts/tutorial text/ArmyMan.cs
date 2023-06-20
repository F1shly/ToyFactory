using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ArmyMan : MonoBehaviour
{
    public TextMeshProUGUI NPCText;
    int text_stage = 0;
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
    private void OnTriggerEnter(Collider other)
    {
        if (other == GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>())
        {
            if(!on)
            {
                gameObject.GetComponent<ArmyMan>().enabled = true;
                text_stage = 1;
                on = true;
                MainUI.SetActive(false);
                NPCUI.SetActive(true);
                pic.sprite = picSprite;
            }
        }
    }
    private void Update()
    {
        if(text_stage == 1)
        {
            NPCText.text = "HELLO SOLDIER! NICE PIECE OF WEAPONRY YOU HAVE THERE" + "\n" + "DO YOU KNOW HOW TO OPERATE THAT THING?";
        }
        if(text_stage == 2)
        {
            NPCText.text = "NO MATTER, I WILL SHOW YOU THE ROPES OF MILITARY COMBAT!";
        }
        if (text_stage == 3)
        {
            NPCText.text = "GIVE <sprite=3> OR <sprite=8> A PRESS";
        }
        if (text_stage == 4)
        {
            NPCText.text = "GOOD SHOT SIR" + "\n" + "NOW HAVE A CRACK AT THOSE PRACTICE TARGETS OVER ON THE BRIDGE!";
        }

        if (text_stage == 5)
        {
            gameObject.GetComponent<ArmyMan>().enabled = false;
            MainUI.SetActive(true);
            NPCUI.SetActive(false);
        }
        if (inputs.interacting)
        {
            text_stage += 1;
            //inputs.interacting = false;
        }
    }
}
