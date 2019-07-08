# Beat Saber

El juego Beat Saber es una aplicación de realidad virtual que consiste en un jugador que tiene que romper unas cajas que 
se aproximan hacia él con el uso de dos sables teniendo en cuanto en ángulo de y la dirección de una luz dentro de la caja para poder cortarla.

![picture alt](https://i2.wp.com/vrespawn.com/wp-content/uploads/2019/02/Beat-Saber-from-Pesky.png?fit=624%2C351&ssl=1 "Beat Saber")

Para el desarrollo del juego se utilizo 3 tecnologías diferentes:
* El kinect se encarga de detectar la posición y distancia a la que se encuentra el jugador y lo coloca sobre una plataforma virtual para que así el jugador pueda desplazarse sobre ella para que pueda alcanzar algunos obstáculos muy distantes.
* El oculus rift fue utilizado para introducir al usuario dentro del ambiente virtual de modo que el usuario solo pueda ver ese ambiente y al mover su cabeza cambia el ángulo de la cámara 
* Los joy-cons fueron utilizados para realizar el movimiento de los sables y detectar las coliciones dentro del juego.


Requisitos:
- kinect for Windows SDK 2.0 [LINK](https://www.microsoft.com/en-us/download/details.aspx?id=44561)
- Kinect v2 Examples with MS-SDK and Nuitrack SDK [LINK](https://assetstore.unity.com/packages/3d/characters/kinect-v2-examples-with-ms-sdk-and-nuitrack-sdk-18708)
- oculus driver [LINK](https://assetstore.unity.com/packages/tools/integration/oculus-integration-82022) o [LINK2](https://developer.oculus.com/downloads/package/unity-integration/)
- joycon lib [LINK](https://github.com/Looking-Glass/JoyconLib)
- ![Imgur](https://i.imgur.com/BbV6Srg.gif)

Nintendo Switch biblioteca Joy-Con para Unity. Incluye: sondeo de botones / barras, rumor de HD y procesamiento de datos del acelerómetro.

Para usar, agregue un GameObject vacío a su escena y adjunte JoyconManager.cs. Mire JoyconDemo.cs para obtener un código de muestra que lo ponga en marcha

Con agradecimientos a  [CTCaer](https://github.com/ctcaer/jc_toolkit/), [dekuNukem](https://github.com/dekuNukem/Nintendo_Switch_Reverse_Engineering), [shinyquagsire23](https://github.com/shinyquagsire23/HID-Joy-Con-Whispering), [mfosse](https://github.com/mfosse/JoyCon-Driver), y [riking](https://github.com/riking/joycon).

Usa C# glue code y [HIDAPI](https://github.com/signal11/hidapi) binarios de  [Unity-Wiimote](https://github.com/Flafla2/Unity-Wiimote)

El método GetVector (intento de implementación de fusión de sensores) aún no es confiable! Habilitar en JoyconManager bajo su propio riesgo. El código de fusión del sensor está en Joycon.ProcessIMU. Siéntase libre de enviar solicitudes de extracción; Código de fusión del sensor basado en [esta guia](starlino.com/imu_guide.html).

Debido a la cantidad de información del esqueleto del kinect, el tamaño del buffer que provee el network manager de unity no es suficiente por lo cual se tendria que dividir la información del kinect para que entre en dos buffers. Para hacer todo esto nos guiamos dle siguiente link: https://forum.unity.com/threads/synchronizing-an-entire-skeleton.355636/

En el siguiente video detallamos las características de interacción del juego:
[VIDEO](https://youtu.be/aSj_CHPQWro)
