using System.Collections;
using UnityEngine;
//using UnityEngine.InputSystem;

public class LeanButton2 : MonoBehaviour
{
    public GameObject GetBackground;
    public GameObject GetCity;
    [SerializeField]private UnityEngine.UI.Button Choice_button;
    public void SetChoice(UnityEngine.UI.Button _button) { Choice_button = _button; }
    public float xb, yb, zb, xs, ys, zs;//transform & scale
    void Start()
    {
        //GetBackground.GetComponent<UnityEngine.UI.Image>().enabled = false;
    }
    public void GetDown()
    {
        //print("down");
        GetCity.SetActive(false);
        GetBackground.SetActive(true);
        
        Choice_button.onClick.Invoke();
    }
    public void bgVisible() { GetBackground.GetComponent<RectTransform>().localScale = new Vector3(1.3f, 1.3f, 1.3f); }
    public void bgNotVisible(){ GetBackground.GetComponent<RectTransform>().localScale = new Vector3(0.01f, 0.01f, 0.01f);}
    public void GetUp()
    {
        print("up");
        GetCity.SetActive(true);
        GetBackground.SetActive(true);
        //GetBackground.GetComponent<RectTransform>().localScale = new Vector3(0.01f, 0.01f,0.01f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        if (OnMouseOverOitemEventHandler != null)
        {
            OnMouseOverOitemEventHandler(this);
        }
    }
    public delegate void OnMouseOverOitem(LeanButton2 o);
    public static event OnMouseOverOitem OnMouseOverOitemEventHandler;

}