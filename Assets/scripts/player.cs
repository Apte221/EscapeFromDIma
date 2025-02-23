using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;  // Øâèäê³ñòü ðóõó
    public float runSpeed = 9f; // змінна бігу;
    public float mouseSensitivity = 2f;  // ×óòëèâ³ñòü ìèø³
    public float jumpForce = 5f;  // Ñèëà ñòðèáêà
    public float gravity = -9.81f; // Ñèëà òÿæ³ííÿ

    private float xRotation = 0f;  // Ïî÷àòêîâèé êóò îáåðòàííÿ ïî îñ³ X
    private CharacterController controller;  // Êîìïîíåíò CharacterController äëÿ ô³çèêè

    private Vector3 velocity;  // Øâèäê³ñòü ãðàâöÿ äëÿ êîíòðîëþ çà ãðàâ³òàö³ºþ
    private bool isGrounded;   // Ïåðåâ³ðêà, ÷è ãðàâåöü íà çåìë³

    public Transform playerBody;  // Òðàíñôîðìàö³ÿ ò³ëà ãðàâöÿ (ùîá îáåðòàòè ïî îñ³ Y)
    public Camera playerCamera;   // Êàìåðà ãðàâöÿ (ùîá îáåðòàòè ïî îñ³ X)

    public Image StaminaBar;

    public float Stamina, MaxStamina;

    public float Runcost; //  
    public float ChargeRate;

    public Coroutine recharge; //


    void Start()
    {
        controller = GetComponent<CharacterController>();  // Îòðèìóºìî êîìïîíåíò CharacterController
        Cursor.lockState = CursorLockMode.Locked; // Áëîêóºìî êóðñîð â ñåðåäèí³ åêðàíó
        Cursor.visible = false; // Ñõîâóºìî êóðñîð
    }


    void Update()
    {
        // Ïåðåâ³ðêà, ÷è íà çåìë³
        isGrounded = controller.isGrounded;

        // Îíîâëåííÿ ãðàâ³òàö³¿
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Ñêèäàºìî øâèäê³ñòü ïî îñ³ Y, ùîá ãðàâåöü íå "ïëàâàâ" â ïîâ³òð³
        }

        // Ðóõ ãðàâöÿ
        float x = Input.GetAxis("Horizontal");  // W, A, S, D äëÿ ãîðèçîíòàëüíîãî ðóõó
        float z = Input.GetAxis("Vertical");    // Âïåðåä/Íàçàä

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        // Ñòðèáîê
       

        // Îíîâëåííÿ ãðàâ³òàö³¿
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // Îáåðòàííÿ êàìåðè çà äîïîìîãîþ ìèø³ (ïî îñ³ X)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Îáìåæåííÿ îáåðòàííÿ ïî îñ³ X (ùîá íå ïåðåâåðòàòèñü)

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX); // Îáåðòàííÿ ò³ëà ïî îñ³ Y

        if(Stamina > 20 && Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = runSpeed;
            Stamina -= Runcost * Time.deltaTime;
     
            if(Stamina < 0) Stamina = 0;
        StaminaBar.fillAmount = Stamina / MaxStamina;
           
            if(recharge != null)  StopCoroutine(recharge);
            recharge = StartCoroutine(RechargeStamina());

        }

        else if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 5f;
            
           
        }
        if (Stamina < 20 ){
            
            moveSpeed = 5f;
            if(Input.GetKey(KeyCode.LeftShift)){
                StaminaBar.fillAmount = StaminaBar.fillAmount ;
            }
        }

    }
    private IEnumerator RechargeStamina(){
        yield return new WaitForSeconds(1.5f);
        while(Stamina < MaxStamina){
            Stamina += ChargeRate / 10f;
            if (Stamina > MaxStamina) Stamina = MaxStamina;
            StaminaBar.fillAmount = Stamina / MaxStamina;
            yield return new WaitForSeconds(.1f);
        }
    }
}
