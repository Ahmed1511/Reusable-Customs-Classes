using System;

namespace CustomException
{
    class Program
    {
        static void Main(string[] args)
        {
            NewTrainner trainner = new NewTrainner { Id = 1, Name = "ali" };
            trainner.TrainningProcess();
            Console.WriteLine(trainner);
            Console.ReadKey();
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
    }

    public class NewTrainner:Employee
    {
        public void TrainningProcess() 
        {
            try
            {
                Rolling();
                Attending();
                PassExam();
            }
            catch (ExamAbsenceException e) 
            {
                // inform the user
                // log  the exception
                Console.WriteLine($"Exam Absence : {e.Message} ,exam Date is : {e.ExamDate}");
            }
            catch (CustomStartEmployeeException e)
            {
                // inform the user
                // log  the exception
                Console.WriteLine($"New Trainner is  :{e.Message}");
            }

            catch (Exception e)
            {                
                Console.WriteLine($"invalid exception {e.Message}");
            }
            finally
            {
                Console.WriteLine("End");
            }
        }

        private void Rolling() 
        {
            Console.WriteLine("Rolling Succeded");
        }
        private void Attending() 
        {
            Console.WriteLine("Attending All Classes");
        }
        private bool PassExam() 
        {
            var AcceptedDegree = 55;
            var tokenDrgree=90;
            if (tokenDrgree >= AcceptedDegree)
            {
                //Console.WriteLine("pass the exam");
                //return true;
                
                throw new ExamAbsenceException(DateTime.Now,"exam Absence //**");
                throw new CustomStartEmployeeException("Exam Absence**");
                throw new Exception("Exam Absence occure");
               
            }
            return false;
        }

        public override string ToString()
        {
            return $"the trainner id is : \n{Id} ,\n the trainner Name : \n{Name}";
        }
    }

    public class ExamAbsenceException:Exception
    {
        public DateTime ExamDate { get; set; } = DateTime.Now;
        public ExamAbsenceException()
        {
            Console.WriteLine($" the trainner does not attent the exam at {ExamDate}");
        }
        public ExamAbsenceException(DateTime examDate, string message):base(message)
        {
            ExamDate = examDate;
        }

        public ExamAbsenceException(DateTime examDate, string message, Exception inner):base(message , inner)
        {

        }
    }
    public class CustomStartEmployeeException : Exception
{
    public CustomStartEmployeeException()
    {

    }

    // This constructor will call BaseClass.BaseClass(string message)
    public CustomStartEmployeeException(string message):base(message)
    {

    }
    // This constructor will call BaseClass.BaseClass(string message , Exception inner)
    public CustomStartEmployeeException(string message , Exception inner) : base(message , inner)
    {

    }
}

}
