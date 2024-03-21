using UnityEngine;
using UnityEngine.UI;

public class ChangeColorPlayer : MonoBehaviour
{
    // Deklaracja zmiennej przechowuj�cej kolor gracza
    public string playerColor = "";

    // Deklaracja przycisk�w
    public Button blueButton;
    public Button redButton;
    public Button greenButton;
    public Button yellowButton;

    // Zmienna przechowuj�ca wcze�niejszy wybrany przycisk
    private Button previousButton;

    void Start()
    {
        // Przypisanie metod do obs�ugi klikni�cia przycisk�w
        blueButton.onClick.AddListener(() => ChangeColor(blueButton, "Blue"));
        redButton.onClick.AddListener(() => ChangeColor(redButton, "Red"));
        greenButton.onClick.AddListener(() => ChangeColor(greenButton, "Green"));
        yellowButton.onClick.AddListener(() => ChangeColor(yellowButton, "Yellow"));
    }

    // Metoda do zmiany koloru gracza
    void ChangeColor(Button button, string color)
    {
        // Sprawd�, czy wcze�niej wybrany przycisk istnieje
        if (previousButton != null)
        {
            // Odblokuj wcze�niejszy przycisk
            previousButton.interactable = true;

            // Przywr�� rozmiar wcze�niejszego przycisku do normalnego
            RectTransform previousRectTransform = previousButton.GetComponent<RectTransform>();
            previousRectTransform.localScale /= 1.1f;
        }

        // Zmiana warto�ci zmiennej playerColor na podany kolor
        playerColor = color;
        Debug.Log("Player color changed to: " + playerColor);

        // Zablokowanie i zmiana rozmiaru przycisku
        button.interactable = false;
        RectTransform rectTransform = button.GetComponent<RectTransform>();
        rectTransform.localScale *= 1.1f;

        // Przypisz aktualnie wybrany przycisk jako wcze�niej wybrany
        previousButton = button;
    }
}
