using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;

public class BInvoke : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        VisualElement p2 = GetComponent<UIDocument>().rootVisualElement.Query<VisualElement>("0");
        p2.RegisterCallback<PointerUpEvent>(delegate
        {
            GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        });

    }
    private void OnEnable()
    {
        //VisualElement p2 = GetComponent<UIDocument>().rootVisualElement.Query<VisualElement>("0");
        //p2.RegisterCallback<PointerUpEvent>(delegate
        //{
        //    GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
        //});

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
