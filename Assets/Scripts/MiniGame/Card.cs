using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public MiniGame gameField;
    
    public string ImageName;
    private Image _image;
    
    public Sprite FaceImage;
    public Sprite BackImage;
    
    private bool _isFront;
    private float _time;
    public double FlipTime = 1;


    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        FaceImage = _image.sprite;
        ImageName = _image.sprite.name;
        _image.sprite = BackImage;
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private async void OnClick()
    {
        await Flip();
        gameField.ClickOnCard(this);
    }

    public async void OnCardNotMatch()
    {
        await Flip();
    }

    public async void OnCardMatch()
    {
        await Task.Delay(300);
        var clr = _image.color;
        clr.a = 0;
        _image.color = clr;
    }

    private async Task Flip() => await Flip(() => { });

    private async Task Flip(Action callBack)
    {
        var endTime = Time.time + FlipTime;
        var startScale = transform.localScale;
        var endScale = new Vector3(-startScale.x, startScale.y, startScale.z);
        var isChanged = false;
        
        while (Time.time < endTime)
        {
            transform.localScale = Vector3.Lerp(startScale, endScale, (float)(1 - (endTime - Time.time) / FlipTime));

            if (endTime - Time.time < FlipTime / 2 && !isChanged)
            {
                isChanged = true;
                _image.sprite = _image.sprite == BackImage ? FaceImage : BackImage;
            }
            
            await Task.Yield();
        }

        callBack();
        await Task.Delay(300);
    }
}
