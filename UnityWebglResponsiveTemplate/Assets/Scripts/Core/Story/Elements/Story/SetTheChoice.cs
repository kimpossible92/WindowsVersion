using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UVNF.Core.Story;
using UVNF.Core.UI;
namespace Lean.Gui
{
    internal class SetTheChoice : MonoBehaviour
    {
        public void Set_choice(int ch1) { FindObjectOfType<NovellCanvas>().set_choice(ch1); }
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}