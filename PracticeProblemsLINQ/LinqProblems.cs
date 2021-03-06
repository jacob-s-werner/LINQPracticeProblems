using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProblemsLINQ
{
    public static class LinqProblems
    {
        //Weighted project points: /10
        //Project points: /25
       
        #region Problem 1 
        //(5 points) Problem 1
        //Using LINQ, write a method that takes in a list of strings and returns all words that contain the substring “th” from a list.
        public static List<string> RunProblem1(List<string> words)
        {
            //code
            List<string> thStringList = words.Where(word => word.Contains("th")).Select(word => word).ToList();
             
            //return
            return thStringList;
        }
        #endregion

        #region Problem 2 
        //(5 points) Problem 2
        //Using LINQ, write a method that takes in a list of strings and returns a copy of the list without duplicates.
        public static List<string> RunProblem2(List<string> names)
        {
            //code
            List<string> noDuplicateList = names.Select(name => name).Distinct().ToList();
            
            //return
            return noDuplicateList;
        }
        #endregion

        #region Problem 3
        //(5 points) Problem 3
        //Using LINQ, write a method that takes in a list of customers and returns the lone customer who has the name of Mike. 
        public static Customer RunProblem3(List<Customer> customers)
        {
            //code
            var customerFound = customers.Where(customer => customer.FirstName == "Mike").Select(customer => customer);
            Customer loneCustomerMike = new Customer(0,null, null); // gets rid of unassigned local variable error

            foreach (Customer customer in customerFound)
            {
                loneCustomerMike = customer;
            }
            //return
            return loneCustomerMike;
        }
        #endregion

        #region Problem 4
        //(5 points) Problem 4
        //Using LINQ, write a method that takes in a list of customers and returns the customer who has an id of 3. 
        //Then, update that customer's first name and last name to completely different names and return the newly updated customer from the method.
        public static Customer RunProblem4(List<Customer> customers)
        {
            //code
            var customerFound = customers.Where(customer => customer.Id == 3).Select(customer => customer);
            Customer customerWithID3 = new Customer(0, null, null); // gets rid of unassigned local variable error

            foreach (Customer customer in customerFound)
            {
                customerWithID3 = new Customer(customer.Id, "Johnny", "TwoHands");
            }

            //return
            return customerWithID3;
        }
        #endregion

        #region Problem 5
        //(5 points) Problem 5
        //Using LINQ, write a method that calculates the class grade average after dropping the lowest grade for each student.
        //The method should take in a list of strings of grades (e.g., one string might be "90,100,82,89,55"), 
        //drops the lowest grade from each string, averages the rest of the grades from that string, then averages the averages.
        //Expected output: 86.125
        public static double RunProblem5(List<string> classGrades)
        {
            //code
            var classGradesDoublesLists = classGrades.Select(student => student.Split(',').Select(double.Parse).ToList());
            var listOfGradesRemovedMin = classGradesDoublesLists.Select(student => student.Where(grade => grade > student.Min())).ToList();
            List<double> listOfGradeAverages = listOfGradesRemovedMin.Select(student => (student.Sum() / student.Count())).ToList();
            double classGradeAverage = listOfGradeAverages.Sum() / listOfGradeAverages.Count();

            //return
            return classGradeAverage;
        }
        #endregion

        //#region Bonus Problem 1
        ////(5 points) Bonus Problem 1
        ////Write a method that takes in a string of letters(i.e. “Terrill”) 
        ////and returns an alphabetically ordered string corresponding to the letter frequency(i.e. "E1I1L2R2T1")
        //public static string RunBonusProblem1(string word)
        //{
        //    //code

        //    //return

        //}
        //#endregion
    }
}
