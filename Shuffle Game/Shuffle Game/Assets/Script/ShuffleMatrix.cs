using System.Collections.Generic;
using UnityEngine;

public class ShuffleMatrix : MonoBehaviour
{

    public GameObject buttonDraw;

    private List<GameObject> lettersMatrixForShuffle;

    public List<Vector2> coordVect;
    public void shuff()
    {
        coordVect.Clear();

        lettersMatrixForShuffle = buttonDraw.GetComponent<DrawMatrix>().lettersMatrix.GetRange(0, buttonDraw.GetComponent<DrawMatrix>().lettersMatrix.Count);

        coordVect.Capacity = lettersMatrixForShuffle.Capacity;

        while (lettersMatrixForShuffle.Count > 0)
        {
            int rem = Random.Range(0, lettersMatrixForShuffle.Count);

            coordVect.Add(lettersMatrixForShuffle[rem].transform.localPosition);

            lettersMatrixForShuffle.Remove(lettersMatrixForShuffle[rem]);
        }
    }

    public void ShuffleM()
    {
        if (DrawMatrix.isLetterIsDrawn)
        {
            shuff();

            DrawMatrix.isButtonClicked = true;
        }
    }
    public void Update()
    {
        int i = 0;

        if (DrawMatrix.isButtonClicked)
        {
            foreach (GameObject gm in buttonDraw.GetComponent<DrawMatrix>().lettersMatrix)
            {
                gm.transform.localPosition = Vector2.Lerp(gm.transform.localPosition, coordVect[i], 2 * Time.deltaTime);

                i++;

            }
        }

    }


}
