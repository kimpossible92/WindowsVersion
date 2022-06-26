using UnityEngine;
using TMPro;

namespace UVNF.Core.UI
{
    public class ChoiceButton : MonoBehaviour
    {
        public TextMeshProUGUI Text;

        private GameObject GetBackground;
        private GameObject GetCity;
        private NovellCanvas CanvasCallback;
        [SerializeField]private int ChoiceIndex;
        public void _setBackgroundCity(GameObject bg,GameObject city) { GetBackground = bg; GetCity = city; }
        public void Display(string choiceText, int choiceIndex, NovellCanvas callback)
        {
            CanvasCallback = callback;
            ChoiceIndex = choiceIndex;
            Text.text = choiceText;
        }

        public void Chosen()
        {
            //print("down");
            GetCity.SetActive(false);
            GetBackground.SetActive(true);
            GetBackground.GetComponent<RectTransform>().localScale = new Vector3(1.3f, 1.3f,1.3f);
            CanvasCallback.ChoiceCallback = ChoiceIndex;
            if (Text.text =="back") { print("back"); CanvasCallback.ChoiceCallback = -1; }
            //Invoke("reset_Choise", 1f);
        }
        public void reset_Choise()
        {
            CanvasCallback.ChoiceCallback = -1;
        }
        public void GetUp()
        {
            print("up");
            GetCity.SetActive(true);
            GetBackground.SetActive(false);
            GetBackground.GetComponent<RectTransform>().localScale = new Vector3(1.3f, 1.3f,1.3f); 
            //CanvasCallback.ChoiceCallback = ChoiceIndex;
        }
    }
}