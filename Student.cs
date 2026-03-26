using System;

// Class: blueprint that bundles data (fields) and behaviour (methods) together
class Student
{
    // Private fields: hidden from outside code to protect data integrity (encapsulation)
    // Only accessible through the public properties below
    private int studentId;
    private string name = string.Empty; // Initialized to avoid null reference warning
    private double score;

    // Property: provides controlled public access to the private studentId field
    public int StudentId
    {
        get { return studentId; } // Returns the current value of studentId
        set { studentId = value; } // Sets studentId to the provided value
    }

    // Property: provides controlled public access to the private name field
    public string Name
    {
        get { return name; } // Returns the current value of name
        set { name = value; } // Sets name to the provided value
    }

    // Property: provides controlled public access to the private score field
    // Includes validation logic to enforce a valid score range
    public double Score
    {
        get { return score; } // Returns the current value of score
        set
        {
            // Enforcing constraint: rejects any score outside the 0 to 100 range
            if (value < 0 || value > 100)
            {
                Console.WriteLine("Error: Score must be between 0 and 100.");
            }
            else
            {
                score = value; // Only updates score if the value is valid
            }
        }
    }

    // Method: computes and returns a letter grade based on the current score
    public string GetGrade()
    {
        // Conditional logic: evaluates score from highest to lowest threshold
        if (score >= 70) return "A";
        else if (score >= 60) return "B";
        else if (score >= 50) return "C";
        else if (score >= 45) return "D";
        else return "F"; // Any score below 45 is a failing grade
    }
}

// Test class: entry point that demonstrates the Student class functionality
class StudentTest{
    static void Main()
    {
        // Creates a new Student object using the default constructor
        Student s = new Student();

        // Sets the student's ID and name via public properties
        s.StudentId = 1;
        s.Name = "Kojo";

        // Sets a valid score of 85 — score property accepts it and updates the field
        s.Score = 85;
        Console.WriteLine(s.GetGrade()); // Calls GetGrade which returns "A"

        // Attempts to set an invalid score of 120 — score property rejects it
        // and prints an error message without updating the score field
        s.Score = 120; // invalid
    }
}

