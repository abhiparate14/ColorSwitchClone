using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public SpriteRenderer sr;

    public string currentColor;

    public Color colorBlue;
    public Color colorYellow;
    public Color colorPurple;
    public Color colorPink;

    [SerializeField] List<string> kuchbhi;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomColor();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))

        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "ColorChanger")
        {
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }

        if (col.tag != currentColor)
        {
            Debug.Log("GAME OVER!");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Blue";
                sr.color = colorBlue;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = colorYellow;
                break;
            case 2:
                currentColor = "Purple";
                sr.color = colorPurple;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = colorPink;
                break;
        }
    }
}
