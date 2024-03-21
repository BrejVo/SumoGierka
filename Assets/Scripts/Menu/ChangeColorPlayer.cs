using UnityEngine;
using UnityEngine.UI;

public class ChangeColorPlayer : MonoBehaviour
{
    // Deklaracja zmiennej przechowuj¹cej kolor gracza
    public string playerColor = "";

    // Deklaracja przycisków
    public Button blueButton;
    public Button redButton;
    public Button greenButton;
    public Button yellowButton;

    // Zmienna przechowuj¹ca wczeœniejszy wybrany przycisk
    private Button previousButton;

    void Start()
    {
        // Przypisanie metod do obs³ugi klikniêcia przycisków
        blueButton.onClick.AddListener(() => ChangeColor(blueButton, "Blue"));
        redButton.onClick.AddListener(() => ChangeColor(redButton, "Red"));
        greenButton.onClick.AddListener(() => ChangeColor(greenButton, "Green"));
        yellowButton.onClick.AddListener(() => ChangeColor(yellowButton, "Yellow"));
    }

    // Metoda do zmiany koloru gracza
    void ChangeColor(Button button, string color)
    {
        // SprawdŸ, czy wczeœniej wybrany przycisk istnieje
        if (previousButton != null)
        {
            // Odblokuj wczeœniejszy przycisk
            previousButton.interactable = true;

            // Przywróæ rozmiar wczeœniejszego przycisku do normalnego
            RectTransform previousRectTransform = previousButton.GetComponent<RectTransform>();
            previousRectTransform.localScale /= 1.1f;
        }

        // Zmiana wartoœci zmiennej playerColor na podany kolor
        playerColor = color;
        Debug.Log("Player color changed to: " + playerColor);

        // Zablokowanie i zmiana rozmiaru przycisku
        button.interactable = false;
        RectTransform rectTransform = button.GetComponent<RectTransform>();
        rectTransform.localScale *= 1.1f;

        // Przypisz aktualnie wybrany przycisk jako wczeœniej wybrany
        previousButton = button;
    }
}
