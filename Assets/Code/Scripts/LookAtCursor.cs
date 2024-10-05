using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    [SerializeField] private float gun_offset;
    void Update()
    {
        Vector3 mouse_pos_2d = Input.mousePosition;
        Vector3 camera_global_pos = Camera.main.ScreenToWorldPoint(new Vector3(mouse_pos_2d.x, mouse_pos_2d.y, -16));

        Vector3 gun_dif = camera_global_pos - new Vector3(-6, 3, -16);
        float gun_z_rotation = Mathf.Atan2(gun_dif.y, gun_dif.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, gun_z_rotation + gun_offset);
        transform.GetChild(0).transform.rotation = Quaternion.Euler(Vector3.zero);
    }
}
