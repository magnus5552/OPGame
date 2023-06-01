using TMPro;
using UnityEngine;
    
public class AddImageBack: MonoBehaviour
{
    [SerializeField] 
    public GameObject ImageBack;
    
    private TMP_Text _textMesh;

    public void Start()
    {
        _textMesh = GetComponent<TMP_Text>();
    }

    public void Update()
    {
        ImageBack.SetActive(!string.IsNullOrEmpty(_textMesh.text));
    }
}
