using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerManager : MonoBehaviour
{
    private static CustomerManager _instance;
    public static CustomerManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    [SerializeField] private GameObject customerPrefab;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject dialogue;
    [SerializeField] private Image BurgerImage;
    [SerializeField] private Sprite[] customersSprites;
    [SerializeField] private GameObject dialogueManager;
    //public bool NeedSpawnNewCustomer = false;
    public BurgerScriptableObjects burgerWanted;
    void Start()
    {
        SpawnCustomer();
    }

    private GameObject customer;
    public void SpawnCustomer()
    {
        customer = Instantiate(customerPrefab, canvas.transform);
        customer.transform.SetSiblingIndex(1);
        Sprite newCustomerSprite = customersSprites[Random.Range(0, customersSprites.Length)];
        customer.GetComponent<CustomerScript>().ChangeSprite(newCustomerSprite);
        burgerWanted = dialogueManager.GetComponent<Dialogue>().ChooseBurger();
        BurgerImage.sprite = burgerWanted.BurgerSprite;
        customer.GetComponent<CustomerScript>().Dialogue = dialogue;
        customer.GetComponent<Animation>().Play("CustomerSpawnAnim");
    }

    public void CustomerGoAway()
    {
        customer.GetComponent<Animation>().Play("CustomerGoAwayAnim");
    }
}
