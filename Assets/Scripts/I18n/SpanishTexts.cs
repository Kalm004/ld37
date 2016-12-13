using System;

public class SpanishTexts : TextInterface
{
    public string getMainMenuPlay()
    {
        return "Jugar";
    }

    public string getMainMenuCredits()
    {
        return "Créditos";
    }

    public string getMainMenuExit()
    {
        return "Salir";
    }

    public string getCreditsMainMenu()
    {
        return "Menú principal";
    }

    public string getCreditsContent()
    {
        return "Programadores:\n\n- Abraham Romero Quesada\n\nAprendices de programador:\n\n- Álvaro Falcón Morales\n- Eulides de la Nuez Monzón\n\nArtistas gráficos:\n\n- Sara Eva Valencia Santana\n- Nelson Omar Martín Jimenez\n\nArtistas de sonido:\n- Oscar Rivero Melo";
    }

    public string getIntroMessage()
    {
        return "Bienvenidos a EscapeJam. \nEstáis encerrados en esta habitación hasta que terminéis vuestro juego... si la habitación no termina primero con vosotros.";
    }

    public string getGoodFinalMessage()
    {
        return "¡Felicidades!\nHabéis logrado completar vuestro juego a tiempo. Aquí está el juego que habéis desarrollado.";
    }

    public string getBadFinalMessage()
    {
        return "Habéis conseguido completar el juego a tiempo, pero han habido demasiados problemas durante el desarrollo. Este es el juego que habéis desarrollado.";
    }

    public string getNormal()
    {
        return "Normal";
    }

    public string getHard()
    {
        return "Difícil";
    }

    public string getGameStatus()
    {
        return "Estado del juego";
    }
}