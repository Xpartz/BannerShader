using UnityEngine;
using UnityEditor;
using Codice.CM.Common;
using UnityEngine.UI;

[CustomEditor(typeof(WindController))]
public class WindControllerEditorCustom : Editor
{
    private Color bigRectangleColor = Color.black;

    private float positionX;
    private float positionY;
    private Vector2 diskPosition;
    private float gameFieldWidth = 200;
    private float gameFieldHeight = 200;

    private bool isMoving = false; // Флаг для отслеживания движения мяча
    private Vector2 ballPosition;
    private Vector2 ballDirection;
    private float lastUpdateTime;
    private float updateInterval = 0.05f;
    private bool autoUpdateEnabled = true;
    private bool hasChangedDirection;// Флаг для автообновления

    private bool showGameOverTextLose = false;
    private bool showGameOverTextWin = false;
    private bool showGameOverText = false;


    private bool isBeat = false;
    private bool isBeat2 = false;

    private Vector2 sizeDeck = new Vector2(40, 10);

    private void OnEnable()
    {
        EditorApplication.update += EditorUpdate;
    }

    private void OnDisable()
    {
        EditorApplication.update -= EditorUpdate;
    }

    private void EditorUpdate()
    {
        if (autoUpdateEnabled)
        {
            if (isMoving)
            {
                float currentTime = (float)EditorApplication.timeSinceStartup;
                if (currentTime - lastUpdateTime >= updateInterval)
                {
                    lastUpdateTime = currentTime;
                    ballPosition = CalculateBallMovement(ballPosition);
                    Repaint();
                }
            }
        }
    }

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        WindController windController = (WindController)target;

        if (GUILayout.Button("Start Moving Ball"))
        {
            StartMovingBall();
        }

        DrawBigRectangle();

        positionX = windController.positionX;
        positionY = windController.positionY;

        // Добавляем чекбокс для управления автообновлением
        autoUpdateEnabled = EditorGUILayout.Toggle("Auto Update", autoUpdateEnabled);
    }

    private void StartMovingBall()
    {
        ballPosition = new Vector2(gameFieldWidth/2, gameFieldHeight/2);
        ballDirection = new Vector2(0, 1); // Например, мяч двигается вверх
        isMoving = true;
       
        showGameOverText = false;
        lastUpdateTime = (float)EditorApplication.timeSinceStartup;
        int randomY = Random.Range(0, 2) == 0 ? -1 : 1;
        if (randomY < 0) {
            hasChangedDirection = true;
        } else { hasChangedDirection = false; }
        currentDirection = new Vector2(0, randomY);
        showGameOverTextLose = false;
        showGameOverTextWin = false;
        isBeat = false;
        isBeat2 = false;
        Debug.Log("Start Moving");
    }

    Vector2 newPosition = new Vector2(0, 0);
    Vector2 currentDirection = new Vector2(0, 1);
    private Vector2 CalculateBallMovement(Vector2 currentPosition)
    {


       
            if (currentPosition.x + 5 >= mouseXOverBigRect && currentPosition.x - 5 <= mouseXOverBigRect)
            {
                if (currentPosition.y + 5 >= 190 && currentPosition.y - 5 <= 190) {
                    if (!isBeat)
                    {
                        Debug.Log("Beat");
                        // Мяч столкнулся с зеленым квадратом
                        // Измените направление движения мяча, например, инвертируйте компоненту X скорости
                        currentDirection.y *= -1;
                        isBeat = true;
                        isBeat2 = false;

                    }
            }
                
            
            }

        if (currentPosition.x + 5 >= mouseXOverBigRect &&  currentPosition.x - 5 <= mouseXOverBigRect)
        {
            if (currentPosition.y + 5 >= 5 && currentPosition.y - 5 <= 5 )
            {
                if (!isBeat2)
                {
                    Debug.Log("Beat2");
                    // Мяч столкнулся с зеленым квадратом
                    // Измените направление движения мяча, например, инвертируйте компоненту X скорости
                    currentDirection.y *= -1;
                    isBeat = false;
                    isBeat2 = true;

                }
            }


        }




        if (currentPosition.y >= gameFieldHeight)
        {
            currentDirection.y *= 0;
            
            showGameOverText = true; // Установите флаг для отображения текста "Game Over"
            showGameOverTextLose = true; // Установите флаг для отображения текста "Game Over"
        }
        else if (currentPosition.y <= 0)
        {
            currentDirection.y *= 0;
            
            
            showGameOverText = true; // Установите флаг для отображения текста "Game Over"
            showGameOverTextWin = true; // Установите флаг для отображения текста "Game Over"
        }
        else
        {
           
        }

        newPosition = currentPosition + currentDirection * 80 * updateInterval;

        return newPosition;
    }


    float mouseXOverBigRect = 0;
    private void DrawBigRectangle()
    {
        GUILayout.BeginArea(new Rect(200, 200, gameFieldWidth, gameFieldHeight));
        Color originalColor = GUI.color;
        GUI.color = bigRectangleColor;
        GUI.Box(new Rect(0, 0, gameFieldWidth, gameFieldHeight), GUIContent.none, EditorStyles.helpBox);
        GUI.color = originalColor;

        Event currentEvent = Event.current;
        Vector2 mousePosition = currentEvent.mousePosition;

        DrawGameOverText();

        if (mousePosition.x >= 0 && mousePosition.x <= gameFieldWidth && mousePosition.y >= 0 && mousePosition.y <= gameFieldHeight + 50)
        {
            mouseXOverBigRect = mousePosition.x;
        }
        mouseXOverBigRect = Mathf.Clamp(mouseXOverBigRect, 0f + sizeDeck.x/2, gameFieldWidth- sizeDeck.x / 2);

        DrawSmallRectangle(mouseXOverBigRect, positionY,sizeDeck);

        DrawSmallRectangle(200 - mouseXOverBigRect, 0,sizeDeck);
        DrawBall(ballPosition.x, ballPosition.y);
        GUILayout.EndArea();
    }

    private void DrawSmallRectangle(float posX, float posY, Vector2 sizeDeck)
    {
        Rect smallRect = new Rect(posX-sizeDeck.x/2, posY, sizeDeck.x, sizeDeck.y);
        GUI.color = Color.green;
        GUI.Box(smallRect, GUIContent.none, EditorStyles.helpBox);
        
    }

    private void DrawBall(float posX, float posY)
    {
        Handles.color = Color.red;
        Vector2 position = new Vector2(posX, posY);
        Handles.DrawSolidDisc(position, Vector3.forward, 5f);
    }

    private void DrawGameOverText()
    {
        string text = string.Empty;
        Color textColor = Color.white;
        if (showGameOverText)
        {
             if (showGameOverTextWin)
            {

                text = "Win";
                textColor = Color.green;
            }
            if (showGameOverTextLose){
                text = "Lose";
                textColor = Color.red;
            }
            // Размер текста
            Vector2 textSize = new Vector2(100, 30);

            // Ширина и высота окна
            float windowWidth = gameFieldWidth; // Замените это на ширину вашей области
            float windowHeight = gameFieldHeight; // Замените это на высоту вашей области

            // Позиция текста "Game Over" по X для центрирования
            float textX = (windowWidth - textSize.x/2)/2;

            // Позиция текста "Game Over" по Y для центрирования
            float textY = (windowHeight - textSize.y/2)/2;

            Vector2 textPosition = new Vector2(textX, textY);

            // Стиль текста
            GUIStyle style = new GUIStyle();
            style.fontSize = 24;
            style.normal.textColor = textColor;

            // Отрисовка текста "Game Over"
            GUI.Label(new Rect(textPosition.x, textPosition.y, textSize.x, textSize.y), text, style);
        }
    }

}
