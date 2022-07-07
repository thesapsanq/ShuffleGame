using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public InputField inputField1;

    public InputField inputField2;

    public static bool isButtonToDrawCanPressed;


    public void putTextInFields1()
    {
        int.TryParse(inputField1.text, out Matrix.width);

        if (inputField1.text == "0")
        {
            Matrix.width = 1;
            inputField1.text = "1";

        }
        else if (Matrix.width > 9)
        {
            Matrix.width = 9;

            inputField1.text = "9";
        }

        DrawMatrix.isButtonClicked = false;

        isButtonToDrawCanPressed = true;
    } 
    public void putTextInFields2()
    {
        int.TryParse(inputField2.text, out Matrix.height);

        if (inputField2.text == "0")
        {
            Matrix.height = 1;

            inputField2.text = "1";
        }
        else if (Matrix.height > 9)
        {
            Matrix.height = 9;

            inputField2.text = "9";
        }

        DrawMatrix.isButtonClicked = false;

        isButtonToDrawCanPressed = true;
    }
}

public struct Matrix
{
    public static int width;
    public static int height;
}
