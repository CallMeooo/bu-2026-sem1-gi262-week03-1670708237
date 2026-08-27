using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Solution
{

    public class OOPExit : Identity
    {
        public GameObject YouWin;

        public override void Hit()
        {
            mapGenerator.player.enabled = false;
            YouWin.SetActive(true);
            Debug.Log("You win");
        }
    }
}