using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NVS_Hangar_PSSelectorSlider : MonoBehaviour {

	public void DisableShipSelectorSlideAnim(Animator anim)
    {
        anim.SetBool("BeingDisplayed", false);
    }

    public void EnableShipSelectorSlideAnim(Animator anim)
    {
        anim.SetBool("BeingDisplayed", true);
    }
}
