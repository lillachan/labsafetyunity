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
<<<<<<< HEAD
=======
    private bool found;
>>>>>>> dupe-of-dupe
    public Question(string qText, string aText, string bText, string cText, string dText, string correct)
    {
        selected = null;
        this.qText = qText;
        this.aText = aText;
        this.bText = bText;
        this.cText = cText;
        this.dText = dText;
        this.correct = correct;
<<<<<<< HEAD
=======
        found = false;
>>>>>>> dupe-of-dupe
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
<<<<<<< HEAD
        Debug.Log(currSelected());
=======
        //Debug.Log(currSelected());
>>>>>>> dupe-of-dupe
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
<<<<<<< HEAD
=======
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
>>>>>>> dupe-of-dupe
    public bool isAnswered()
    {
        if (selected != null)
        {
            return true;
        }
        return false;
    }
<<<<<<< HEAD
=======
    public void foundIt()
    {
        found = true;
    }
    public bool foundBool()
    {
        return found;
    }
>>>>>>> dupe-of-dupe

}