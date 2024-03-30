using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "Abilities/Invisibility")]
public class Invisibility : Ability
{
    public float SpeedBoost;
    public float Duration; //nastav na tok kokr je duration

    public override void Activate(GameObject player)
    {
        player.GetComponent<playerMovement>().speed += SpeedBoost;

        player.GetComponent<SkinChanger>().DisableSkin(Duration, SpeedBoost);

        Transform childTransform = player.transform.Find("RotatePoint/BulletTransform");

        if (childTransform != null)
        {
            GameObject childObject = childTransform.gameObject;
            SetActiveSprite setActiveSprite = childObject.GetComponent<SetActiveSprite>();
            setActiveSprite.DeactiveSprite(Duration);

        }
    }

}
