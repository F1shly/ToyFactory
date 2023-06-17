using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Text : MonoBehaviour
{
    public TextMeshProUGUI NPCText;
    int current_text_stage = 0;
    GameObject player;
    Inputs inputs;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inputs = player.GetComponent<Inputs>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other == GameObject.FindGameObjectWithTag("Player").GetComponent<Collider>())
        {
            current_text_stage = 1;
        }
    }
    private void Update()
    {
        if(current_text_stage == 1)
        {
            NPCText.text = "Welcome player" + "\n" + "To the Toy Factory";
        }
        if(current_text_stage == 2)
        {
            NPCText.text = "Use <sprite=1> or <sprite=0> to move around" + "\n" + "and use <sprite=2> or <sprite=3> to look around";
        }
        if (current_text_stage == 3)
        {
            NPCText.text = "Now run over to my firend." + "\n" + "He will teach you about combat!";
        }

        if (current_text_stage == 4)
        {
            gameObject.GetComponent<Text>().enabled = false;
            gameObject.GetComponent<Cutscenes>().cutsceneStart = 1;
        }
        if (inputs.interacting)
        {
            current_text_stage += 1;
            inputs.interacting = false;
        }
    }
}
