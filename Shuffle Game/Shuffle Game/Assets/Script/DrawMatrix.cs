using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawMatrix : MonoBehaviour
{
    public GameObject letterGO;

    public GameObject canvasGO;

    public GameObject testcanvasGO;

    public List<GameObject> lettersMatrix;

    public static bool isButtonClicked;

    private char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public static bool isLetterIsDrawn;

    public void GenerateMatrix()
    {
        if (Buttons.isButtonToDrawCanPressed)
        {
            ClearBoard();

            DrawLetters();
        }
    }

    private char rand(char[] mass)
    {
        int letterNum = UnityEngine.Random.Range(0, mass.Length);

        char letter = letters[letterNum];

        return letter;
    }
    private void DrawLetters()
    {
        int shagMatrix = Math.Max(Matrix.height, Matrix.width);

        RectTransform rtTestCanvas = testcanvasGO.GetComponent<RectTransform>();

        RectTransform rtCanvas = canvasGO.GetComponent<RectTransform>();

        RectTransform rtLetter = letterGO.GetComponent<RectTransform>();

        float xPosLetter;

        float yPosLetter;

        float canvasWidth = rtCanvas.rect.width / (shagMatrix + (shagMatrix - 1 ) );

        float canvasHeight = rtCanvas.rect.height / (shagMatrix + (shagMatrix - 1 ) );

        rtLetter.sizeDelta = new Vector2(canvasWidth, canvasHeight);

        rtTestCanvas.sizeDelta = new Vector2(Matrix.width * rtLetter.sizeDelta.x + Matrix.width * rtLetter.sizeDelta.x,
            Matrix.height * rtLetter.sizeDelta.y + Matrix.height  * rtLetter.sizeDelta.y);

        if (Matrix.height == Matrix.width)
        {
             xPosLetter = canvasGO.transform.position.x - rtCanvas.rect.width / 2 + rtLetter.rect.width / 2;

             yPosLetter = canvasGO.transform.position.y + rtCanvas.rect.height / 2 - rtLetter.rect.height / 2;
        }
        else
        {
             xPosLetter = testcanvasGO.transform.position.x - rtTestCanvas.rect.width / 2 + rtLetter.rect.width ;

             yPosLetter = testcanvasGO.transform.position.y + rtTestCanvas.rect.height / 2 - rtLetter.rect.height ;
        }

        for ( int i = 0; i < Matrix.height; i++)
        {
            for ( int j = 0; j < Matrix.width; j++)
            {
                letterGO.GetComponent<Text>().text = rand(letters).ToString();

                Vector2 pos = new Vector2(xPosLetter + (canvasWidth + canvasWidth ) * j, yPosLetter - (canvasHeight + canvasHeight ) * i);

                lettersMatrix.Add(Instantiate(letterGO, pos, Quaternion.identity, testcanvasGO.transform));
            }           
        }

        isLetterIsDrawn = true;

        isButtonClicked = false;
    }
    private void ClearBoard()
    {
        if (isLetterIsDrawn)
        {
            for (int i = 0; i < lettersMatrix.Count; i++)
            {
                Destroy(lettersMatrix[i]);
            }
            isLetterIsDrawn = false;
            lettersMatrix.Clear();
        }
    }
}