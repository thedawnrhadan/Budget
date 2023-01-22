using System;
using System.Collections.Generic;
using System.IO;

namespace Budget
{
    class Budget
    {
        double income, expenses, difference;
        bool saveData;
        string dataFile = "budget.txt";
        Dictionary<string, double> incomeCategories = new Dictionary<string, double>();
        Dictionary<string, double> expenseCategories = new Dictionary<string, double>();

        // A constructor that initializes variables
        public Budget()
        {
            this.income = 0;
            this.expenses = 0;
            this.difference = 0;
            this.saveData = false;
        }

        // A method to get income and expenses data from user
        public void GetBudgetData()
        {
            // Get income data
            Console.Write("Enter number of income categories: ");
            int numIncomeCategories = int.Parse(Console.ReadLine());
            for (int i = 0; i < numIncomeCategories; i++)
            {
                Console.Write("Enter name of income category {0}: ", i+1);
                string incomeCategory = Console.ReadLine();
                Console.Write("Enter amount for {0}: ", incomeCategory);
                double incomeAmount = double.Parse(Console.ReadLine());
                incomeCategories.Add(incomeCategory, incomeAmount);
                this.income += incomeAmount;
            }

            // Get expenses data
            Console.Write("Enter number of expenses categories: ");
            int numExpenseCategories = int.Parse(Console.ReadLine());
            for (int i = 0; i < numExpenseCategories; i++)
            {
                Console.Write("Enter name of expense category {0}: ", i+1);
                string expenseCategory = Console.ReadLine();
                Console.Write("Enter amount for {0}: ", expenseCategory);
                double expenseAmount = double.Parse(Console.ReadLine());
                expenseCategories.Add(expenseCategory, expenseAmount);
                this.expenses += expenseAmount;
            }
        }

        // A method to calculate the budget difference
        public void CalculateBudget()
        {
            this.difference = this.income - this.expenses;
            if (this.difference < 0)
            {
                Console.WriteLine("Expenses are greater than income. Please adjust your budget.");
            }
            else
            {
                Console.WriteLine("Income: {0}", this.income);
                Console.WriteLine("Expenses: {0}", this.expenses);
                Console.WriteLine("Difference: {0}", this.difference);
            }
        }

        // A method to save the data to a file
        public void SaveData()
        {
            // A loop to get user input for saving data
            do
            {
                Console.Write("Do you want to save the data? (yes/no): ");
                string save = Console.ReadLine().ToLower();
                if (save == "yes")
                {
                    this.saveData = true;
                    break;
                }
                else if (save == "no")
                {
                    this.saveData = false;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter yes or no.");
                }
            } while (true);

            // If user wants to save data, write data to the budget.txt file
            if (this.saveData)
            {
                if (File.Exists(dataFile))
                {
                    File.Delete(dataFile);
                }
                using (StreamWriter sw = new StreamWriter(dataFile))
                {
                    sw.WriteLine("Income Categories:");
                    foreach (var income in incomeCategories)
                    {
                        sw.WriteLine("{0}: {1}", income.Key, income.Value);
                    }
                    sw.WriteLine("Total Income: {0}", this.income);
                    sw.WriteLine("Expense Categories:");
                    foreach (var expense in expenseCategories)
                    {
                        sw.WriteLine("{0}: {1}", expense.Key, expense.Value);
                    }
                    sw.WriteLine("Total Expenses: {0}", this.expenses);
                    sw.WriteLine("Difference: {0}", this.difference);
                }
            }
        }
        
        // A method to read the data from the budget.txt file
        public void LoadData()
        {
            if (File.Exists(dataFile))
            {
                using (StreamReader sr = new StreamReader(dataFile))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }
        }
        
        // A method to display the budget data
        public void DisplayBudget()
        {
            Console.WriteLine("Income Categories:");
            foreach (var income in incomeCategories)
            {
                Console.WriteLine("{0}: {1}", income.Key, income.Value);
            }
            Console.WriteLine("Total Income: {0}", this.income);
            Console.WriteLine("Expense Categories:");
            foreach (var expense in expenseCategories)
            {
                Console.WriteLine("{0}: {1}", expense.Key, expense.Value);
            }
            Console.WriteLine("Total Expenses: {0}", this.expenses);
            CalculateBudget();
        }
        // Main Method
        static void Main(string[] args)
        {
            try
            {
                Budget budget = new Budget();
                Console.Write("Do you want to load data? (yes/no): ");
                string load = Console.ReadLine().ToLower();
                if (load == "yes")
                {
                    budget.LoadData();
                }
                else if (load == "no")
                {
                    budget.GetBudgetData();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter yes or no.");
                }
                budget.DisplayBudget();
                budget.SaveData();
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occurred: " + e.Message);
            }
        }
    }
}
