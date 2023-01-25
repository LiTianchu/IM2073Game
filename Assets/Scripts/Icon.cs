using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    private bool selected;

    [SerializeField]
    private Color disabledColor;
    [SerializeField]
    private Color enabledColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (selected)
        {
            this.gameObject.GetComponent<Image>().color = enabledColor;
        }
        else {
            this.gameObject.GetComponent<Image>().color = disabledColor;
        }
    }

    public void SetEnable(bool enabled) {
        this.selected = enabled;
    }

    
}
