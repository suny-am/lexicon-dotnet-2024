internal class PersonHandler
{

    // explicit constructor for future extensions
    public PersonHandler()
    {

    }

    public Person CreatePerson(int age, string fName, string lName)
    {
        return new Person(age, fName, lName);
    }

    public Person CreatePerson(int age, string fName, string lName, double? height, double? weight)
    {
        return new Person(age, fName, lName, height, weight);
    }

    public void SetPersonAge(Person person, int age)
    {
        person.Age = age;
    }
    public void SetPersonFirstName(Person person, string fName)
    {
        person.FName = fName;
    }
    public void SetPersonLastName(Person person, string lName)
    {
        person.LName = lName;
    }
    public void SetPersonHeight(Person person, double height)
    {
        person.Height = height;
    }
    public void SetPersonWeight(Person person, double weight)
    {
        person.Weight = weight;
    }


}