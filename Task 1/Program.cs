using System.Collections.Generic;
EmployeeManagement employeeManagement = new EmployeeManagement();

employeeManagement.AddEmployee("john_doe", "password123");
employeeManagement.AddEmployee("jane_smith", "securePass!45");

Console.WriteLine("Initial Employee List:");
employeeManagement.ShowEmployees();

Console.WriteLine("\nShowing John's password:");
employeeManagement.ShowPassword("john_doe");

Console.WriteLine("\nUpdating John's login and password:");
employeeManagement.ChangeEmployee("john_doe", "john_updated", "newPassword456");
employeeManagement.ShowEmployees();
Console.WriteLine("\nRemoving Jane from the system:");
employeeManagement.RemoveEmployee("jane_smith");
employeeManagement.ShowEmployees();


public class EmployeeManagement
{
    private Dictionary<string, string> employees = new Dictionary<string, string>();
    public EmployeeManagement()
    {
        employees = new Dictionary<string, string>();
    }

    public void AddEmployee(string login, string password) => employees.Add(login, password);

    public void RemoveEmployee(string login) => employees.Remove(login);

    public void ChangeEmployee(string login, string newlogin, string newpassword)
    {
        employees.Remove(login);
        employees.Add(newlogin, newpassword);
    }

    public void ShowPassword(string login) => Console.WriteLine($"Password of {login} employee: {employees[login]}");

    public void ShowEmployees()
    {
        ICollection<string> keys = employees.Keys;

        Console.WriteLine("База данных содержит: ");
        foreach (string j in keys)
            Console.WriteLine("LOGIN -> {0}  PASSWORD -> {1}", j, employees[j]);
    }
}