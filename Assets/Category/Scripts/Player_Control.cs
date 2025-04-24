using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player_Control : MonoBehaviour
{
    public Sprite[] Ignition_List;
    public GameObject Bomb;
    public GameObject Bullet;
    float Player_Speed = 3.5f;
    float Player_Direction_X;
    float Player_Direction_Y;
    float Player_Bomb_Cool;
    float Player_Attack_Cool;
    const float BombCool = 90.0f;
    float Bomb_Cool;
    const float TypeCool = 1.0f;
    float Type_Cool;
    const float PlayerMuzzle = 15;
    float Player_Muzzle = 100;
    int Ignition_Number;
    int Player_Attack_Type = 1;
    Vector2 Player_Direction;
    public Transform JoyStick;
    private Vector3 JoyStick_Center;
    private Vector3 JoyStick_Direction;
    private float JoyStick_Radius;
    float JoyStick_Radius_Background;
    bool Player_Skill_Shoot_Whether = false;
    bool Player_Skill_Type_Whether = false;
    bool Player_Skill_Bomb_Whether = false;
    void Start()
    {
        Ignition_Number = 0;
        StartCoroutine(Ignition_Animation());
        if (SystemInfo.deviceType.ToString() == "Desktop")
        {
            StartCoroutine(Move_Ship());
            StartCoroutine(Skill_Bomb());
            StartCoroutine(Skill_Type());
            StartCoroutine(Skill_Shoot());
        }
        else if (SystemInfo.deviceType.ToString() == "Handheld")
        {
            GameObject.Find("Etc_Canvas_UserInterface").transform.Find("Android_Controller").gameObject.SetActive(true);
            JoyStick_Radius = GameObject.Find("JoyStick_Pad_Move_Behind").GetComponent<RectTransform>().sizeDelta.y * 0.5f;
            JoyStick_Center = JoyStick.transform.position;
            JoyStick_Radius_Background = GameObject.Find("JoyStick_Pad_Move_Behind").GetComponent<RectTransform>().localScale.x;
            JoyStick_Radius = JoyStick_Radius * JoyStick_Radius_Background;
            StartCoroutine(Android_Move_Ship_Drag_Call());
            StartCoroutine(Android_Skill_Shoot_PointerDown_Call());
            StartCoroutine(Android_Skill_Type_PointerClick_Call());
            StartCoroutine(Android_Skill_Bomb_PointerClick_Call());
        }
    }
    void Update()
    {
        if (Bomb_Cool > 0)
        {
            Bomb_Cool -= Time.deltaTime / BombCool;
        }
        if (Type_Cool > 0)
        {
            Type_Cool -= Time.deltaTime / TypeCool;
        }
        PlayerPrefs.SetFloat("Gauge", Player_Muzzle / 100.0f);
        PlayerPrefs.SetFloat("Type_Cool", Type_Cool);
        PlayerPrefs.SetFloat("Bomb_Cool", Bomb_Cool);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    IEnumerator Ignition_Animation()
    {
        while (true)
        {
            Ignition_Number += 1;
            if (Ignition_Number == 1)
            {
                this.transform.GetChild(1).transform.Translate(new Vector2(1f, 0.13f));
                this.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = Ignition_List[0];
                this.transform.GetChild(1).transform.Translate(new Vector2(-1f, -0.13f));
                this.transform.GetChild(1).transform.localScale = new Vector2(0.05f, 0.04f);
                yield return new WaitForSeconds(0.05f);
            }
            if (Ignition_Number == 2)
            {
                this.transform.GetChild(1).transform.Translate(new Vector2(1f, 0.13f));
                this.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = Ignition_List[1];
                this.transform.GetChild(1).transform.Translate(new Vector2(-1f, -0.13f));
                this.transform.GetChild(1).transform.localScale = new Vector2(0.03f, 0.03f);
                Ignition_Number = 0;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
    IEnumerator Move_Ship()
    {
        while (true)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                Player_Direction_X = -1;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                Player_Direction_X = 1;
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Player_Direction_Y = 1;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                Player_Direction_Y = -1;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                Player_Direction_X = 0;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                Player_Direction_X = 0;
            }
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                Player_Direction_Y = 0;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow))
            {
                Player_Direction_Y = 0;
            }
            Player_Direction = new Vector2(Player_Direction_X, Player_Direction_Y);
            if (this.transform.position.x > -8 && this.transform.position.x < 5 && this.transform.position.y > -4.5 && this.transform.position.y < 4.5)
            {
                this.transform.Translate(Player_Direction * Player_Speed * Time.deltaTime);
            }
            if (this.transform.position.x > -8 && this.transform.position.x < 5 && this.transform.position.y <= -4.5)
            {
                if (Player_Direction_Y < 0)
                {
                    this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                }
                else
                {
                    this.transform.Translate(Player_Direction * Player_Speed * Time.deltaTime);
                }
            }
            if (this.transform.position.x > -8 && this.transform.position.x < 5 && this.transform.position.y > 4.5)
            {
                if (Player_Direction_Y > 0)
                {
                    this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                }
                else
                {
                    this.transform.Translate(Player_Direction * Player_Speed * Time.deltaTime);
                }
            }
            if (this.transform.position.x < -8 && this.transform.position.y > -4.5 && this.transform.position.y < 4.5)
            {
                if (Player_Direction_X < 0)
                {
                    this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                }
                else
                {
                    this.transform.Translate(Player_Direction * Player_Speed * Time.deltaTime);
                }
            }
            if (this.transform.position.x < -8 && this.transform.position.y < -4.5)
            {
                if (Player_Direction_X < 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(0, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X > 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X == 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
            }
            if (this.transform.position.x < -8 && this.transform.position.y > 4.5)
            {
                if (Player_Direction_X < 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(0, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X > 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X == 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
            }
            if (this.transform.position.x > 5 && this.transform.position.y > -4.5 && this.transform.position.y < 4.5)
            {
                if (Player_Direction_X > 0)
                {
                    this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                }
                else
                {
                    this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                }
            }
            if (this.transform.position.x > 5 && this.transform.position.y < -4.5)
            {
                if (Player_Direction_X < 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X > 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(0, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X == 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
            }
            if (this.transform.position.x > 5 && this.transform.position.y > 4.5)
            {
                if (Player_Direction_X < 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X > 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(0, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X == 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
            }
            yield return new WaitForSeconds(1 / 60);
        }
    }
    IEnumerator Skill_Bomb()
    {
        this.transform.GetChild(3).gameObject.SetActive(false);
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Bomb_Cool = 1;
                this.transform.GetChild(3).gameObject.SetActive(true);
                Instantiate(Bomb, transform.position + new Vector3(1.8f, -0.2f, 0), transform.rotation);
                yield return new WaitForSeconds(0.03f);
                this.transform.GetChild(3).gameObject.SetActive(false);
                yield return new WaitForSeconds(BombCool);
                Bomb_Cool = 0;
            }
            yield return new WaitForSeconds(1 / 60);
        }
    }
    IEnumerator Skill_Type()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                Type_Cool = 1;
                if (Player_Attack_Type == 1)
                {
                    Player_Attack_Type = 2;
                }
                else
                {
                    Player_Attack_Type = 1;
                }
                yield return new WaitForSeconds(TypeCool);
                Type_Cool = 0;
            }
            yield return new WaitForSeconds(1 / 60);
        }
    }
    IEnumerator Skill_Shoot()
    {
        this.transform.GetChild(2).gameObject.SetActive(false);
        while (true)
        {
            if (Player_Muzzle < 100)
            {
                Player_Muzzle += Time.deltaTime * PlayerMuzzle;
            }
            if (Input.GetKey(KeyCode.C))
            {
                if (Player_Attack_Type == 1)
                {
                    if (Player_Muzzle > 0)
                    {
                        this.transform.GetChild(2).gameObject.SetActive(true);
                        Instantiate(Bullet, transform.position + new Vector3(1.3f, -0.1f, 0), transform.rotation);
                        yield return new WaitForSeconds(0.03f);
                        this.transform.GetChild(2).gameObject.SetActive(false);
                        Player_Muzzle -= 1;
                    }
                }
                if (Player_Attack_Type == 2)
                {
                    if (Player_Muzzle > 0)
                    {
                        this.transform.GetChild(2).gameObject.SetActive(true);
                        Instantiate(Bullet, transform.position + new Vector3(1.3f, -0.2f, 0), Quaternion.Euler(0, 0, 15));
                        Instantiate(Bullet, transform.position + new Vector3(1.3f, -0.1f, 0), Quaternion.Euler(0, 0, 0));
                        Instantiate(Bullet, transform.position + new Vector3(1.3f, -0.0f, 0), Quaternion.Euler(0, 0, -15));
                        yield return new WaitForSeconds(0.03f);
                        this.transform.GetChild(2).gameObject.SetActive(false);
                        Player_Muzzle -= 3;
                        yield return new WaitForSeconds(0.03f);
                    }
                }
            }
            yield return new WaitForSeconds(1 / 60);
        }
    }
    public void Android_Move_Ship_Drag(BaseEventData _Data)
    {
        PointerEventData Data = _Data as PointerEventData;
        Vector3 JoyStick_Position = Data.position;
        float JoyStick_Distance = Vector3.Distance(JoyStick_Position, JoyStick_Center);
        float JoyStick_InsideLine_X_P;
        float JoyStick_InsideLine_X_M;
        float JoyStick_InsideLine_Y_P;
        float JoyStick_InsideLine_Y_M;
        JoyStick_Direction = (JoyStick_Position - JoyStick_Center).normalized;
        if (JoyStick_Distance < JoyStick_Radius)
        {
            JoyStick.position = JoyStick_Center + JoyStick_Direction * JoyStick_Distance;
        }
        else
        {
            JoyStick.position = JoyStick_Center + JoyStick_Direction * JoyStick_Radius;
        }
        JoyStick_InsideLine_X_P = (JoyStick_Center.x * 3 + JoyStick_Center.x + JoyStick_Radius * 1) / 4;
        JoyStick_InsideLine_X_M = (JoyStick_Center.x * 3 + JoyStick_Center.x - JoyStick_Radius * 1) / 4;
        JoyStick_InsideLine_Y_P = (JoyStick_Center.y * 3 + JoyStick_Center.y + JoyStick_Radius * 1) / 4;
        JoyStick_InsideLine_Y_M = (JoyStick_Center.y * 3 + JoyStick_Center.y - JoyStick_Radius * 1) / 4;
        if (JoyStick.position.x >= JoyStick_InsideLine_X_M && JoyStick.position.x <= JoyStick_InsideLine_X_P)
        {
            Player_Direction_X = 0;
        }
        if (JoyStick.position.x < JoyStick_InsideLine_X_M)
        {
            Player_Direction_X = -1;
        }
        if (JoyStick.position.x > JoyStick_InsideLine_X_P)
        {
            Player_Direction_X = 1;
        }
        if (JoyStick.position.y >= JoyStick_InsideLine_Y_M && JoyStick.position.y <= JoyStick_InsideLine_Y_P)
        {
            Player_Direction_Y = 0;
        }
        if (JoyStick.position.y > JoyStick_InsideLine_Y_P)
        {
            Player_Direction_Y = 1;
        }
        if (JoyStick.position.y < JoyStick_InsideLine_Y_M)
        {
            Player_Direction_Y = -1;
        }
        Player_Direction = new Vector2(Player_Direction_X, Player_Direction_Y);
    }
    public void Android_Move_Ship_EndDrag()
    {
        JoyStick.position = JoyStick_Center;
        JoyStick_Direction = new Vector3(0, 0, 0);
        Player_Direction_X = 0;
        Player_Direction_Y = 0;
        Player_Direction = new Vector2(Player_Direction_X, Player_Direction_Y);
    }
    IEnumerator Android_Move_Ship_Drag_Call()
    {
        while (true)
        {
            if (this.transform.position.x > -8 && this.transform.position.x < 5 && this.transform.position.y > -4.5 && this.transform.position.y < 4.5)
            {
                this.transform.Translate(Player_Direction * Player_Speed * Time.deltaTime);
            }
            if (this.transform.position.x > -8 && this.transform.position.x < 5 && this.transform.position.y <= -4.5)
            {
                if (Player_Direction_Y < 0)
                {
                    this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                }
                else
                {
                    this.transform.Translate(Player_Direction * Player_Speed * Time.deltaTime);
                }
            }
            if (this.transform.position.x > -8 && this.transform.position.x < 5 && this.transform.position.y > 4.5)
            {
                if (Player_Direction_Y > 0)
                {
                    this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                }
                else
                {
                    this.transform.Translate(Player_Direction * Player_Speed * Time.deltaTime);
                }
            }
            if (this.transform.position.x < -8 && this.transform.position.y > -4.5 && this.transform.position.y < 4.5)
            {
                if (Player_Direction_X < 0)
                {
                    this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                }
                else
                {
                    this.transform.Translate(Player_Direction * Player_Speed * Time.deltaTime);
                }
            }
            if (this.transform.position.x < -8 && this.transform.position.y < -4.5)
            {
                if (Player_Direction_X < 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(0, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X > 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X == 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
            }
            if (this.transform.position.x < -8 && this.transform.position.y > 4.5)
            {
                if (Player_Direction_X < 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(0, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X > 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X == 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
            }
            if (this.transform.position.x > 5 && this.transform.position.y > -4.5 && this.transform.position.y < 4.5)
            {
                if (Player_Direction_X > 0)
                {
                    this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                }
                else
                {
                    this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                }
            }
            if (this.transform.position.x > 5 && this.transform.position.y < -4.5)
            {
                if (Player_Direction_X < 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X > 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(0, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X == 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
            }
            if (this.transform.position.x > 5 && this.transform.position.y > 4.5)
            {
                if (Player_Direction_X < 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X > 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(0, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(0, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
                if (Player_Direction_X == 0)
                {
                    if (Player_Direction_Y < 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y > 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, 0) * Player_Speed * Time.deltaTime);
                    }
                    if (Player_Direction_Y == 0)
                    {
                        this.transform.Translate(new Vector2(Player_Direction_X, Player_Direction_Y) * Player_Speed * Time.deltaTime);
                    }
                }
            }
            yield return new WaitForSeconds(1 / 60);
        }
    }
    public void Android_Skill_Shoot_PointerDown()
    {
        Player_Skill_Shoot_Whether = true;
    }
    IEnumerator Android_Skill_Shoot_PointerDown_Call()
    {
        while (true)
        {
            if (Player_Muzzle < 100)
            {
                Player_Muzzle += Time.deltaTime * PlayerMuzzle;
            }
            if (Player_Skill_Shoot_Whether)
            {
                if (Player_Attack_Type == 1)
                {
                    if (Player_Muzzle > 0)
                    {
                        this.transform.GetChild(2).gameObject.SetActive(true);
                        Instantiate(Bullet, transform.position + new Vector3(1.3f, -0.1f, 0), transform.rotation);
                        yield return new WaitForSeconds(0.03f);
                        this.transform.GetChild(2).gameObject.SetActive(false);
                        Player_Muzzle -= 1;
                    }
                }
                if (Player_Attack_Type == 2)
                {
                    if (Player_Muzzle > 0)
                    {
                        this.transform.GetChild(2).gameObject.SetActive(true);
                        Instantiate(Bullet, transform.position + new Vector3(1.3f, -0.2f, 0), Quaternion.Euler(0, 0, 15));
                        Instantiate(Bullet, transform.position + new Vector3(1.3f, -0.1f, 0), Quaternion.Euler(0, 0, 0));
                        Instantiate(Bullet, transform.position + new Vector3(1.3f, -0.0f, 0), Quaternion.Euler(0, 0, -15));
                        yield return new WaitForSeconds(0.03f);
                        this.transform.GetChild(2).gameObject.SetActive(false);
                        Player_Muzzle -= 3;
                        yield return new WaitForSeconds(0.03f);
                    }
                }
            }
            yield return new WaitForSeconds(1 / 60);
        }
    }
    public void Android_Skill_Shoot_PointerUp()
    {
        Player_Skill_Shoot_Whether = false;
    }
    public void Android_Skill_Type_PointerClick()
    {
        if (Type_Cool == 0)
        {
            Player_Skill_Type_Whether = true;
        }
    }
    IEnumerator Android_Skill_Type_PointerClick_Call()
    {
        while (true)
        {
            if (Player_Skill_Type_Whether)
            {
                Player_Skill_Type_Whether = false;
                Type_Cool = 1;
                if (Player_Attack_Type == 1)
                {
                    Player_Attack_Type = 2;
                }
                else
                {
                    Player_Attack_Type = 1;
                }
                yield return new WaitForSeconds(TypeCool);
                Type_Cool = 0;
            }
            yield return new WaitForSeconds(1 / 60);
        }
    }
    public void Android_Skill_Bomb_PointerClick()
    {
        if (Bomb_Cool == 0)
        {
            Player_Skill_Bomb_Whether = true;
        }
    }
    IEnumerator Android_Skill_Bomb_PointerClick_Call()
    {
        while (true)
        {
            if (Player_Skill_Bomb_Whether)
            {
                Player_Skill_Bomb_Whether = false;
                Bomb_Cool = 1;
                this.transform.GetChild(3).gameObject.SetActive(true);
                Instantiate(Bomb, transform.position + new Vector3(1.8f, -0.2f, 0), transform.rotation);
                yield return new WaitForSeconds(0.03f);
                this.transform.GetChild(3).gameObject.SetActive(false);
                yield return new WaitForSeconds(BombCool);
                Bomb_Cool = 0;
            }
            yield return new WaitForSeconds(1 / 60);
        }
    }
}
