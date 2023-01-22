using System;
using System.IO;

namespace Budget
{
    class Budget
    {
        double income, expenses, difference;
        bool saveData;
        string dataFile = "budget.txt";

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
            Console.Write("Enter income: ");
            this.income = double.Parse(Console.ReadLine());
            Console.Write("Enter expenses: ");
            this.expenses = double.Parse(Console.ReadLine());
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
                string save = Console.ReadLine();
                if (save == "yes")
                {
                    this.saveData = true;
                    break;
                }
                else if (save == "no")
                {
                    this.saveData = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter yes or no.");
                }
            } while (true);

            // If user wants to save data, write data to the budget.txt file
            if (this.saveData)
            {
                using (StreamWriter sw = new StreamWriter(dataFile))
                {
                    sw.WriteLine("Income: " + this.income);
                    sw.WriteLine("Expenses: " + this.expenses);
                    sw.WriteLine("Difference: " + this.difference);
                }
            }
        }
        
        static void Main(string[] args)
        {
            Budget budget = new Budget();
            budget.GetBudgetData();
            budget.CalculateBudget();
            budget.SaveData();
        }
    }
}
