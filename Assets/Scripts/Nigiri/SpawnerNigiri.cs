using UnityEngine;
using System.Collections;

public class SpawnerNigiri : MonoBehaviour
{
    public GameObject sushiPrefab; // Prefabrykat obiektu sushi
    public GameObject ring; // Referencja do obiektu "ring"
    public float minimalnyCzasPojawiania = 10f; // Minimalny czas mi�dzy pojawieniem si� sushi
    public float maksymalnyCzasPojawiania = 15f; // Maksymalny czas mi�dzy pojawieniem si� sushi
    public float czasPojawiania = 4f; // Czas trwania pojawiania si� sushi (zwi�kszony do 4 sekund)
    public float czasZnikania = 3f; // Czas trwania znikania sushi
    public float czasZnikaniaStopniowego = 2f; // Czas trwania stopniowego znikania sushi

    void Start()
    {
        // Rozpocznij proces pojawiania si� sushi
        StartCoroutine(PojawianieSushi());
    }

    IEnumerator PojawianieSushi()
    {
        // Losowe miejsce na powierzchni obiektu "ring"
        Vector3 losowaPozycja = LosowaPozycjaNaPierwotnejPowierzchni(ring.transform.position, ring.transform.localScale);

        // Utw�rz sushi na wylosowanej pozycji z prze�roczysto�ci� 0
        GameObject noweSushi = Instantiate(sushiPrefab, losowaPozycja, Quaternion.identity);
        Renderer sushiRenderer = noweSushi.GetComponent<Renderer>();
        Color startColor = sushiRenderer.material.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f); // Docelowa prze�roczysto�� = 1 (pe�na widoczno��)

        // Stopniowo zwi�kszaj prze�roczysto�� w ci�gu 2 sekund
        float timer = 0f;
        while (timer < 2f)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(0f, 1f, timer / 2f);
            sushiRenderer.material.color = new Color(startColor.r, startColor.g, startColor.b, alpha);
            yield return null;
        }

        // Rozpocznij proces znikania sushi po czasie czasPojawiania
        StartCoroutine(ZnikanieStopniowe(noweSushi));

        // Ponownie uruchom timer dla kolejnego pojawienia si� sushi
        yield return new WaitForSeconds(Random.Range(minimalnyCzasPojawiania, maksymalnyCzasPojawiania));
        StartCoroutine(PojawianieSushi());
    }

    IEnumerator ZnikanieStopniowe(GameObject sushi)
    {
        // Poczekaj przed rozpocz�ciem stopniowego zanikania
        yield return new WaitForSeconds(czasPojawiania);

        // Stopniowo zmniejszaj przezroczysto�� sushi w czasie
        float timer = 0f;
        while (timer < czasZnikaniaStopniowego)
        {
            timer += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, timer / czasZnikaniaStopniowego);
            Renderer sushiRenderer = sushi.GetComponent<Renderer>();
            sushiRenderer.material.color = new Color(sushiRenderer.material.color.r, sushiRenderer.material.color.g, sushiRenderer.material.color.b, alpha);
            yield return null;
        }

        // Zniszcz sushi po znikni�ciu
        Destroy(sushi);
    }

    Vector3 LosowaPozycjaNaPierwotnejPowierzchni(Vector3 center, Vector3 scale)
    {
        // Generuj losow� pozycj� w obr�bie powierzchni "ring"
        Vector3 randomPoint = center + new Vector3(Random.Range(-scale.x / 2f, scale.x / 2f), 0f, Random.Range(-scale.z / 2f, scale.z / 2f));
        return randomPoint;
    }
}