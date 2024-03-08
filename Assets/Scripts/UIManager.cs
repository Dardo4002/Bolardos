using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject powerbar;
    // Start is called before the first frame update
    RectTransform rect_transform;
    BallControler ballControler;
    void Start()
    {
        rect_transform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        PowerBar();
    }

    void PowerBar()
    {
        rect_transform.localScale = new Vector3(1, ballControler.fuerza, 1);
    }
}
