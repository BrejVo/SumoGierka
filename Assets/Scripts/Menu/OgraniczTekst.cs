

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OgraniczTekst : MonoBehaviour
{
    public TMP_InputField inputField;
    public Button okButton;
    public Button resetButton;
    public int maksymalnaDlugosc = 10;
    public GameObject obiektDoDezaktywacji;

    public string username = "";
    public bool zablokowane = false;

    private void Start()
    {
        inputField.onValueChanged.AddListener(delegate { OgraniczDlugoscTekstu(); });
        inputField.onSelect.AddListener(delegate { UkryjPlaceholder(); });
        inputField.onValueChanged.AddListener(delegate { SprawdzCzyAktywowacPrzyciskOk(); });
        okButton.onClick.AddListener(delegate { KliknietoOK(); });
        resetButton.onClick.AddListener(delegate { Resetuj(); });
        SprawdzCzyAktywowacPrzyciskOk(); // Dodaj wywo³anie na start, aby aktywowaæ przycisk "Ok" lub nie
    }

    private void OgraniczDlugoscTekstu()
    {
        if (inputField.text.Length > maksymalnaDlugosc)
        {
            inputField.text = inputField.text.Substring(0, maksymalnaDlugosc);
        }

        username = inputField.text;
    }

    private void UkryjPlaceholder()
    {
        inputField.placeholder.gameObject.SetActive(false);
    }

    private void SprawdzCzyAktywowacPrzyciskOk()
    {
        okButton.interactable = !string.IsNullOrEmpty(inputField.text);
    }

    private void KliknietoOK()
    {
        if (obiektDoDezaktywacji != null && !string.IsNullOrEmpty(inputField.text))
        {
            inputField.interactable = false;
            okButton.interactable = false;
            zablokowane = true;
            inputField.textComponent.color = Color.red;
        }
    }

    private void Resetuj()
    {
        inputField.interactable = true;
        okButton.interactable = true;
        zablokowane = false;
        inputField.textComponent.color = Color.black;
        inputField.text = "";
        inputField.placeholder.gameObject.SetActive(true);
        SprawdzCzyAktywowacPrzyciskOk(); // Dodaj wywo³anie na reset, aby aktywowaæ przycisk "Ok" lub nie
    }
}
