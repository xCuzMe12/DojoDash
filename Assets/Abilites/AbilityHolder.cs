using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    float cooldownTime;
    float activeTime;


    enum AbilityState
    {
        ready, active, cooldown
    }

    AbilityState state = AbilityState.ready; //tko settas value enmu variablu za enum
    public KeyCode key;

    private void Update()
    {
        //ability.Activate(gameObject) - ta fja se klice na objektu na kermu je ta script prjtrjen


        //SWITCHANJE MED TREMI STATE-I  
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKeyDown(key)) {
                    ability.Activate(gameObject); // ce mamo ready pa prtisnemo, pol se activira
                    state = AbilityState.active;
                    activeTime = ability.activeTime; //kok casa traja ability, to mas v unih pol specificnih scriptih tza vsak ab
                }
                break;
            case AbilityState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.cooldown;
                    cooldownTime = ability.cooldownTime;                    
                }
                break;
            case AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;                  
                }
                break;


        }



        
    }
}
