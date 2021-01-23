using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxEffect : MonoBehaviour
{
    [SerializeField] private RectTransform rt;


    [SerializeField] private float scrollSpeed = -5f;
    private float textureWidth;

    void Start()
    {
        Sprite sprite = GetComponent<Image>().sprite;
        textureWidth = sprite.texture.width;
    }

    void Update()
    {
        float newX = rt.anchoredPosition.x + scrollSpeed * Time.deltaTime;
        if (rt.anchoredPosition.x > textureWidth) newX = rt.anchoredPosition.x - textureWidth;
        if (rt.anchoredPosition.x < -textureWidth) newX = rt.anchoredPosition.x + textureWidth;
        rt.anchoredPosition = new Vector2(newX, rt.position.y);
    }
}
