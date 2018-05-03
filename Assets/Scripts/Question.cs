using UnityEngine;

public class Question
{
    public string qText;
    public string aText;
    public string bText;
    public string cText;
    public string dText;
    private string selected;
    private string correct;
    private bool found;
    public Question(string qText, string aText, string bText, string cText, string dText, string correct)
    {
        selected = null;
        this.qText = qText;
        this.aText = aText;
        this.bText = bText;
        this.cText = cText;
        this.dText = dText;
        this.correct = correct;
        found = false;
    }
    public string currSelected()
    {
        return selected;
    }
    public void setSelected(string choice)
    {
        if (choice != selected)
        {
            selected = choice;
        }
        else
        {
            selected = null;
        }
        //Debug.Log(currSelected());
    }
    public bool selectedIsCorrect()
    {
        if (selected == correct)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool selectedIsWrong()
    {
        if(isAnswered() && !selectedIsCorrect())
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool isAnswered()
    {
        if (selected != null)
        {
            return true;
        }
        return false;
    }
    public void foundIt()
    {
        found = true;
    }
    public bool foundBool()
    {
        return found;
    }

}