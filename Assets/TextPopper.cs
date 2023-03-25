using TMPro;
using UnityEngine;

public class TextPopper : MonoBehaviour
{
    public float popSize = 1.4f;
    
    public float popSpeed = 3;
    private TMP_Text text;
    private string lastText;
    
    private void Start()
    {
        text = GetComponent<TMP_Text>();
    }
    

    private void LateUpdate()
    {
        if (text.text != lastText)
        {
            Pop();
            lastText = text.text;
        }
        
        if(transform.localScale.x > 1)
            transform.localScale -= Vector3.one * Time.deltaTime * popSpeed;
    }
    
    // pop text
    void Pop()
    {
        transform.localScale = Vector3.one * popSize;
    }
}
