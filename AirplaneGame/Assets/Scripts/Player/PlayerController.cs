using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IPointerDownHandler,
    IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform rect_Background;
    [SerializeField] private RectTransform rect_Joystick;

    private float radius;

    [SerializeField] private GameObject go_Player;
    [SerializeField] private float moveSpeed;

    private bool isTouch = false;
    private Vector3 movePosition;

    Animator anim;
    public Transform target;

    public void OnDrag(PointerEventData eventData)
    {
        if (go_Player == null) return;

        Vector2 value = eventData.position - (Vector2)rect_Background.position;

        value = Vector2.ClampMagnitude(value, radius);
        rect_Joystick.localPosition = value;

        float distance = Vector2.Distance(rect_Background.position, rect_Joystick.position) / radius;

        //print(distance);

        anim.SetBool("Walk", true);
        if (distance > 0.9f) anim.SetBool("Run", true);
        else anim.SetBool("Run", false);

        float rotationDegree = Mathf.Atan2(rect_Joystick.localPosition.y, rect_Joystick.localPosition.x) * Mathf.Rad2Deg;
        //print(rotationDegree);
        target.rotation = Quaternion.Euler(rotationDegree - 180, -90f,90f);
        //player.Rotate(new Vector3(-180 * (), 0, 0));

        value = value.normalized; // 방향값만 남는다.


        //print(value);
        //float heading = Mathf.Atan2(rect_Joystick.localPosition.x, rect_Joystick.localPosition.y);

        //target.rotation = Quaternion.Euler(heading * 180, -90f, 90f);
        //target.rotation = Quaternion.Euler(value);

        movePosition = new Vector3(value.x * moveSpeed * distance * Time.deltaTime, 
            value.y * moveSpeed * distance * Time.deltaTime, 0f);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (go_Player == null) return;

        anim.SetBool("Walk", false);
        anim.SetBool("Run", false);

        isTouch = false;

        //saveDistance = 0;
        rect_Joystick.localPosition = Vector3.zero;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Toon Chicken").GetComponent<Animator>();
        radius = rect_Background.rect.width * 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isTouch && go_Player != null) go_Player.transform.position += movePosition;
    }
}
