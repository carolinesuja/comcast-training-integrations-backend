using System;
using System.Collections.Generic;

class Employee
{
    // Fields 
    private int id;
    private string name;
    private string department;
    private string designation;
    private double salary;

    // Properties
    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Department
    {
        get { return department; }
        set { department = value; }
    }

    public string Designation
    {
        get { return designation; }
        set { designation = value; }
    }

    public double Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    // Virtual method (for overriding)
    public virtual void Display()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}, Department: {Department}, Designation: {Designation}, Salary: {Salary}");
    }
}

// Child Class - Inheritence
class Manager : Employee
{
    public double Bonus { get; set; }

    // Constructor
    public Manager()
    {
        Designation = "Manager";
    }

    // Method overriding 
    public override void Display()
    {
        Console.WriteLine($"Id: {Id}, Name: {Name}, Department: {Department}, Designation: {Designation}, Salary: {Salary}, Bonus: {Bonus}");
    }
}


class EmployeeManagement
{
    private List<Employee> employees = new List<Employee>();

    // Add employee
    public void AddEmployee(Employee emp)
    {
        employees.Add(emp);
        Console.WriteLine("Employee added successfully.");
    }

    // View all employees
    public void ViewEmployees()
    {
        if (employees.Count == 0)
        {
            Console.WriteLine("No employees found.");
            return;
        }

        foreach (Employee emp in employees)
        {
            emp.Display();
        }
    }

    // View only managers
    public void ViewManagers()
    {
        bool found = false;

        foreach (Employee emp in employees)
        {
            if (emp is Manager)
            {
                emp.Display();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("No managers found.");
        }
    }

    // Update employee salary
    public void UpdateEmployee(int id, double salary)
    {
        foreach (Employee emp in employees)
        {
            if (emp.Id == id)
            {
                emp.Salary = salary;
                Console.WriteLine("Employee updated successfully.");
                return;
            }
        }
        Console.WriteLine("Employee not found.");
    }

    // Delete employee
    public void DeleteEmployee(int id)
    {
        Employee empToRemove = null;

        foreach (Employee emp in employees)
        {
            if (emp.Id == id)
            {
                empToRemove = emp;
                break;
            }
        }

        if (empToRemove != null)
        {
            employees.Remove(empToRemove);
            Console.WriteLine("Employee deleted successfully.");
        }
        else
        {
            Console.WriteLine("Employee not found.");
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        EmployeeManagement empmgmt = new EmployeeManagement();

        while (true)
        {
            Console.WriteLine("\nEmployee Management System");
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Add Manager");
            Console.WriteLine("3. View All Employees");
            Console.WriteLine("4. View Managers Only");
            Console.WriteLine("5. Update Employee Salary");
            Console.WriteLine("6. Delete Employee");
            Console.WriteLine("7. Exit");
            Console.Write("Enter your choice: ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Employee emp = new Employee();

                    Console.Write("Enter Id: ");
                    emp.Id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    emp.Name = Console.ReadLine();

                    Console.Write("Enter Department: ");
                    emp.Department = Console.ReadLine();

                    Console.Write("Enter Designation: ");
                    emp.Designation = Console.ReadLine();

                    Console.Write("Enter Salary: ");
                    emp.Salary = Convert.ToDouble(Console.ReadLine());

                    empmgmt.AddEmployee(emp);
                    break;

                case 2:
                    Manager mgr = new Manager();

                    Console.Write("Enter Id: ");
                    mgr.Id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter Name: ");
                    mgr.Name = Console.ReadLine();

                    Console.Write("Enter Department: ");
                    mgr.Department = Console.ReadLine();

                    Console.Write("Enter Salary: ");
                    mgr.Salary = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter Bonus: ");
                    mgr.Bonus = Convert.ToDouble(Console.ReadLine());

                    empmgmt.AddEmployee(mgr);
                    break;

                case 3:
                    empmgmt.ViewEmployees();
                    break;

                case 4:
                    empmgmt.ViewManagers();
                    break;

                case 5:
                    Console.Write("Enter Employee Id: ");
                    int uid = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter New Salary: ");
                    double newSalary = Convert.ToDouble(Console.ReadLine());

                    empmgmt.UpdateEmployee(uid, newSalary);
                    break;

                case 6:
                    Console.Write("Enter Employee Id to delete: ");
                    int did = Convert.ToInt32(Console.ReadLine());

                    empmgmt.DeleteEmployee(did);
                    break;

                case 7:
                    Console.WriteLine("Exiting program...");
                    return;

                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
        }
    }
}
