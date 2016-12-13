using System;

public class EnglishTexts : TextInterface
{
    public string getMainMenuPlay()
    {
        return "Play";
    }

    public string getMainMenuCredits()
    {
        return "Credits";
    }

    public string getMainMenuExit()
    {
        return "Exit";
    }

    public string getCreditsMainMenu()
    {
        return "Main menu";
    }

    public string getCreditsContent()
    {
        return "Developers:\n\n- Abraham Romero Quesada\n- Álvaro Falcón Morales\n- Eulides de la Nuez Monzón\n\nGraphic artists:\n\n- Sara Eva Valencia Santana\n- Nelson Omar Martín Jimenez\n\nSound artists:\n- Oscar Rivero Melo";
    }

    public string getIntroMessage()
    {
        return "Welcome to EscapeJam. \nYou are locked down in this room until you finish your game... if the room doesn't ends with you first.";
    }

    public string getGoodFinalMessage()
    {
        return "Congratulations!\nYou have finished your game in time. This is the game you just developed.";
    }

    public string getBadFinalMessage()
    {
        return "You have finished your game in time, but there has been a lot of troubles in the development process. This is the game you just developed.";
    }

    public string getNormal()
    {
        return "Normal";
    }

    public string getHard()
    {
        return "Hard";
    }

    public string getGameStatus()
    {
        return "Game Status";
    }
}

