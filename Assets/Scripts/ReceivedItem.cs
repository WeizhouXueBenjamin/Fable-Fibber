using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ReceivedItem : MonoBehaviour

{
    RectTransform rectTransform;
    public GameObject item;
    Vector2 position;
    private void Awake()
    {
        position = transform.position;
        rectTransform = GetComponent<RectTransform>();

    }
    public IEnumerator ReceiveItem(Sprite sprite)
    {
        float height = rectTransform.rect.height;
        Debug.Log(height);
        Image image = item.GetComponent<Image>();
        image.sprite = sprite;
        Vector2 tarPos = new Vector2(position.x, position.y - height) - position;

        float time = 5f;
        float timer = 0f;

        Debug.Log(height);
        float speed = 200 * Time.deltaTime;

        while (timer < time)
        {
            timer += Time.deltaTime;
            transform.position = position + tarPos*timer/time;
            yield return null;

        }
        transform.position = Vector2.MoveTowards(transform.position, position, speed);

    }
}
