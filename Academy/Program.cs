Teacher _teacher = new Teacher();
_teacher.SubjectName = "Biochemistry";
Console.WriteLine($"Subject Name: {_teacher.SubjectName}");
_teacher.CheckHomeworks();
_teacher.GoodAfternoon();
_teacher.Goodbye();

Console.WriteLine();

Teacher _teacher1 = new Teacher("Programming");
Console.WriteLine($"Subject Name: {_teacher1.SubjectName}");
_teacher1.CheckHomeworks();
_teacher1.GoodAfternoon();
_teacher1.Goodbye();

Console.WriteLine();

Lecturer _lecturer = new Lecturer();
_lecturer.UniversityName = "University";
Console.WriteLine($"University Name: {_lecturer.UniversityName}");
_lecturer.CheckHomeworks();
_lecturer.ConductExercise("Demo1");
_lecturer.ConductExercise("Demo2", "Demo3");
_lecturer.ConductExercise("Demo4", "Demo5", "Demo6");
_lecturer.GoodAfternoon();

Console.WriteLine();

Lecturer _lecturer1 = new Lecturer("University1");
Console.WriteLine($"University Name: {_lecturer1.UniversityName}");
_lecturer1.CheckHomeworks();
_lecturer1.ConductExercise("Demo11");
_lecturer1.ConductExercise("Demo22", "Demo33");
_lecturer1.ConductExercise("Demo44", "Demo55", "Demo66");
_lecturer1.GoodAfternoon();

Console.WriteLine();

Professor _professor = new Professor("Grand Master", 1);
_professor.PrintTitleAndExpirience(_professor.Title, _professor.YearsOfService);
_professor.CheckHomeworks();
_professor.ConductExams();

Console.WriteLine();

Assistant _assistant = new Assistant();
_assistant.YearsOfService = -10;
Console.WriteLine($"Expirience: {_assistant.YearsOfService}");
_assistant.FirstName = "Test";
_assistant.IsDepartmentHead = true;
_assistant.PrintFullNameAndDepartment(_assistant.FirstName, _assistant.IsDepartmentHead);
_assistant.WriteScientificArticles();
_assistant.CheckHomeworks();
_assistant.CheckExams();

Console.WriteLine();

SchoolTeacher _schoolTeacher = new SchoolTeacher();
_schoolTeacher.schoolClasses[0] = "1A";
_schoolTeacher.schoolClasses[1] = "1B";
_schoolTeacher.schoolClasses[2] = "1C";
_schoolTeacher.schoolClasses[3] = "1D";
_schoolTeacher.schoolClasses[4] = "1E";
_schoolTeacher.PrintClasses(_schoolTeacher.schoolClasses);
_schoolTeacher.CheckHomeworks();
_schoolTeacher.BoostMood();

Console.WriteLine();

CollegeTeacher _collegeTeacher = new CollegeTeacher("College-University-Name");
_collegeTeacher.YearsOfService = 2;
Console.WriteLine($"Expirience: {_collegeTeacher.YearsOfService}");
_collegeTeacher.CheckHomeworks();

int _count = Person.GetCount();
Console.WriteLine($"Count of active Instances: {_count}");



public abstract class Person
{
    private int yearsOfService;

    public static int instanceCounter = 0;

    public static int GetCount() => instanceCounter;

    public string FirstName { get; set; } = string.Empty;

    public string SurnName { get; private set; } = string.Empty;

    public string UniversityName { get; set; } = string.Empty;

    public int YearsOfService
    {
        get
        {
            if(yearsOfService > 0)
            {
                return yearsOfService;
            }
            return 0;
        }
        set
        {
            yearsOfService = value;
        }

    }

    public abstract void CheckHomeworks();

    public abstract void GoodAfternoon();
}

public class Teacher : Person
{
    public Teacher(string subjectName)
    {
        SubjectName = subjectName;
        instanceCounter++;
    }

    public Teacher() { instanceCounter++; }

    public string SubjectName { get; set; } = string.Empty;

    public override void CheckHomeworks()
    {
        Console.WriteLine($"CheckHomeworks() implemented in {nameof(Person)} class. Has Overridden in {nameof(Teacher)} class.");
    }

    public override void GoodAfternoon()
    {
        Console.WriteLine($"GoodAfternoon() implemented in {nameof(Person)} class. Has Overridden in {nameof(Teacher)} class.");
    }

    public void Goodbye()
    {
        Console.WriteLine($"Goodbye() implemented in {nameof(Teacher)} class.");
    }
}

public class Lecturer : Person
{
    public const byte LECTURESPERWEEK = 10;

    public Lecturer(string universityName) { UniversityName = universityName; instanceCounter++; }

    public Lecturer() { instanceCounter++; }

    public override void CheckHomeworks()
    {
        Console.WriteLine($"CheckHomeworks() implemented in {nameof(Person)} class. Has Overridden in {nameof(Lecturer)} class.");
    }

    public void ConductExercise(string exerciseA) { Console.WriteLine($"ConductExercise({exerciseA})"); }

    public void ConductExercise(string exerciseA, string exerciseB) { Console.WriteLine($"ConductExercise({exerciseA} ,{exerciseB})"); }

    public void ConductExercise(string exerciseA, string exerciseB, string exerciseC) { Console.WriteLine($"ConductExercise({exerciseA}, {exerciseB}, {exerciseC})"); }

    public override void GoodAfternoon()
    {
        Console.WriteLine($"GoodAfternoon() implemented in {nameof(Person)} class. Has Overridden in {nameof(Lecturer)} class.");
    }

}

public class Professor : Lecturer
{
    public Professor(string title, int experience)
    {
        Title = title;
        YearsOfService = experience;
        instanceCounter++;
    }

    private Professor()
    {

    }

    public string Title = string.Empty;

    public void PrintTitleAndExpirience(string title, int experience) { Console.WriteLine($"Title: {Title} \nExpirience: {YearsOfService}"); }

    public override void CheckHomeworks()
    {
        Console.WriteLine($"CheckHomeworks() implemented in {nameof(Person)} class. Has Overridden in {nameof(Professor)} class.");
    }

    public void ConductExams()
    {
        Console.WriteLine($"ConductExams() implemented in {nameof(Professor)} class.");
    }

}

public class Assistant : Lecturer
{
    public Assistant() { instanceCounter++; }

    public bool IsDepartmentHead;

    public void PrintFullNameAndDepartment(string firstName, bool isDepartmentHead) { Console.WriteLine($"Name: {FirstName} \nHead Assistant: {IsDepartmentHead}"); }

    public void WriteScientificArticles()
    {
        Console.WriteLine($"WriteScientificArticles() implemented in {nameof(Assistant)} class.");
    }

    public override void CheckHomeworks()
    {
        Console.WriteLine($"CheckHomeworks() implemented in {nameof(Person)} class. Has Overridden in {nameof(Assistant)} class.");
    }

    public void CheckExams()
    {
        Console.WriteLine($"CheckExams() implemented in {nameof(Assistant)} class.");
    }
}

public class SchoolTeacher : Teacher
{
    public SchoolTeacher() { instanceCounter++; }

    public string[] schoolClasses = new string[5];

    public void PrintClasses(string[] classes) 
    {
        for (int i = 0; i < classes.Length; i++)
        {
            Console.WriteLine($"Class: {classes[i]}");
        }
    }

    public override void CheckHomeworks()
    {
        base.CheckHomeworks();
        Console.WriteLine($"CheckHomeworks() implemented in {nameof(Person)} class. But optionally overridden in {nameof(SchoolTeacher)} class.");
    }

    public void BoostMood()
    {
        Console.WriteLine($"BoostMood() implemented in {nameof(SchoolTeacher)} class.");
    }

}

public class CollegeTeacher : Teacher
{
    public CollegeTeacher(string universityName) { UniversityName = universityName; instanceCounter++; }

    private CollegeTeacher()
    {

    }

    public override void CheckHomeworks()
    {
        base.CheckHomeworks();
        Console.WriteLine($"CheckHomeworks() implemented in {nameof(Person)} class. But optionally overridden in {nameof(CollegeTeacher)} class.");
    }

}