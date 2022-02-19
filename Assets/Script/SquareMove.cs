using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SquareMove : MonoBehaviour
{
    public RaycastHit2D hit;
    bool _switch = false;
    bool _control = true;
    public int count = 0;

    GUIContent content;
    GUIStyle style = new GUIStyle();

    void Update()
    {
        if(Input.GetButton("Fire1") && _control == true)
        {
            hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.collider != null && hit.collider.tag == "Square")
            {
                _switch = true;
            }
            Debug.Log ("none: " + Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        else
        {
            _switch = false;
        }
        if(_switch == true)
        {
            transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        if(other.tag == "Circle")
        {
            count++;
            Debug.Log("count ");
            Destroy(other.gameObject);
        }
    }
    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width/2 - 25, 10, 200, 20), "Count = " + count);
        GUIStyle style = new GUIStyle();
        style.fontSize = 20;
        if(count >= 5)
        {
            _control = false;
            GUI.Box(new Rect(Screen.width/2 - 125, Screen.height/4 + 100, 250, 100), " ");
            if(GUI.Button(new Rect(Screen.width/2 - 50, Screen.height/2 - 50, 100, 50), "Restart"))
            {
                count = 0;
                _control = true;
                Restart();
            }
            
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(0,LoadSceneMode.Single);
    }
}
