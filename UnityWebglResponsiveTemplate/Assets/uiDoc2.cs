using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
public class uiDoc2 : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument = null;
    [SerializeField] private bool autoStartOnLoad = true;
    [SerializeField] private UIDocument uiDocument2 = null;
    [SerializeField] private UIDocument[] uIDocuments = new UIDocument[10];
    [HideInInspector] private VisualElement[] elemButton = new VisualElement[15];
    [SerializeField] private Canvas canvas_;
    [SerializeField] private GameObject[] images = new GameObject[15];
    private ButtonBox buttonBox;
    private void OnEnable()
    {
       
    }
    public void OnDown0()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition); // Construct a ray from the current mouse coordinates
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            buttonBox = hit.collider.GetComponent<ButtonBox>();
            if (buttonBox != null)
            {
                buttonBox.OnClickButton();
            }
            else
            {
            
            }
        }
    }
    public void NewEnable()
    {
        for (int i = 0; i < images.Length; i++)
        {
            images[i].gameObject.SetActive(false);
        }
    }
    public void EnableUI()
    {
        #region Label2
        for (int i = 0; i < images.Length; i++)
        {
            elemButton[i] = uiDocument2.rootVisualElement.Query<VisualElement>(i.ToString());
        }
        elemButton[3] = uiDocument2.rootVisualElement.Query<VisualElement>("3");
        elemButton[0].RegisterCallback<PointerUpEvent>(delegate { images[0].gameObject.SetActive(true); });
        elemButton[1].RegisterCallback<PointerUpEvent>(delegate { images[1].gameObject.SetActive(true); });
        elemButton[2].RegisterCallback<PointerUpEvent>(delegate { images[2].gameObject.SetActive(true); });
        elemButton[3].RegisterCallback<PointerUpEvent>(delegate 
        { 
            images[3].gameObject.SetActive(true); 
            images[0].gameObject.SetActive(false); 
            images[1].gameObject.SetActive(false);
            uiDocument2.enabled = false;
            
        });
        #endregion
    }

    private void OnPointerUp3(PointerUpEvent evt)
    {
        if (!uIDocuments[0].enabled) { uIDocuments[0].enabled = true; return; }
        else { uIDocuments[0].enabled = false; return; }
    }
    private void OnPointerUp4(PointerUpEvent evt)
    {
        if (!uIDocuments[1].enabled) { uIDocuments[1].enabled = true; return; }
        else { uIDocuments[1].enabled = false; return; }
    }
    // Start is called before the first frame update
    void Start()
    {
        if (autoStartOnLoad)
        {
            //StartAnimHooks();
        }
    }
    private Dictionary<int, IEnumerator> _activeCoroutines = new Dictionary<int, IEnumerator>();
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) { OnDown0(); }
    }
}
