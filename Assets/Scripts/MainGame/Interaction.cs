using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public GameObject InteractionText;
    public GameObject OtherObject;

    public GameObject ChoiceWindow;
    public Button YesButton;
    public Button NoButton;
    public Text ChoiceText;

    // Start is called before the first frame update
    private void Start()
    {
        if (YesButton == null)
        {
            YesButton = GameObject.Find("YesButton").GetComponent<Button>();
            YesButton.onClick.AddListener(YesButtonClicked);
        }
        if (NoButton == null)
        {
            NoButton = GameObject.Find("NoButton").GetComponent<Button>();
            NoButton.onClick.AddListener(NoButtonClicked);
        }
        if (ChoiceWindow == null)
        {
            ChoiceWindow = GameObject.Find("ChoiceWindow");
            ChoiceWindow.SetActive(false);
        }
       
        if (InteractionText == null)
        {
            InteractionText = GameObject.Find("TextInteract");
            InteractionText.SetActive(false);
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (OtherObject != null)
        {
            Debug.Log(Variables.MissionList.Find(Mission => Mission.Id == Variables.CurrentMissionID).ObjetName);
            if (Variables.MissionList.Find(Mission => Mission.Id == Variables.CurrentMissionID).ObjetName == OtherObject.name)
            {
                Debug.Log("I am a door");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Showpopup();
                    
                    //TODO:  make material glow
                }
            }

            if (OtherObject.name == "Computeur")
            {
                Debug.Log("I am a Computeur");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Door");
                }
            }

            if (OtherObject.name == "Toilet")
            {
                Debug.Log("I am a Toilet");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Door");
                }
            }

            if (OtherObject.name == "Balance")
            {
                Debug.Log("I am a Balance");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Door");
                }
            }

            if (OtherObject.name == "Pharmacie")
            {
                Debug.Log("I am a Pharmacie");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Door");
                }
            }

            if (OtherObject.name == "Fridge")
            {
                Debug.Log("I am a Fridge");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Door");
                }
            }
            if (OtherObject.name == "Bed")
            {
                Debug.Log("I am a Bed");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Door");
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        OtherObject = other.gameObject;
        if (other.tag == "Interactable")
        {
            InteractionText.SetActive(true);
            Debug.Log("you can interact whit me");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Interactable")
        {
            Debug.Log("you can interact whit me");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        OtherObject = null;
        InteractionText.SetActive(false);
    }

    private void YesButtonClicked()
    {
        Variables.CurrentMissionID++;
        ChoiceWindow.SetActive(false);
        //TODO: implemete bonus et malus
    }

    private void NoButtonClicked()
    {
        Variables.CurrentMissionID++;
        ChoiceWindow.SetActive(false);
        //TODO: implemente bonusx et malus
    }

    private void Showpopup()
    {
        ChoiceWindow.SetActive(true);
        ChoiceText.text = Variables.MissionList.Find(Mission => Mission.Id == Variables.CurrentMissionID).Text;
    }
}