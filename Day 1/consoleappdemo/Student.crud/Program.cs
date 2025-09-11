using Microsoft.Data.SqlClient;

namespace Student.crud;

internal class Program
{
    static void Main(string[] args)
    {
        SqlConnection sqlConnection;
        string connectionString = @"Data Source=.;Initial Catalog=StudentCRUD;Integrated Security=True;Trust Server Certificate=True";
        sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();
        try
        {

            Console.WriteLine("connection established sucesfull");
            string answer;

            do
            {
                Console.WriteLine("==========================================");
                Console.WriteLine("        STUDENT CRUD MANAGEMENT");
                Console.WriteLine("==========================================");
                Console.WriteLine("Select from the options to perform the operation:" +
                    "\n1.Add Student Data." +
                    "\n2.Retrive Student Data." +
                    "\n3.Update Student Name." +
                    "\n4.Update Student age." +
                    "\n5.Delete Student Record");
                int choice = int.Parse(Console.ReadLine());


                switch (choice)
                {
                    case 1:

                        //insert data

                        Console.WriteLine("\nEnter your name ");
                        string name = Console.ReadLine();
                        Console.WriteLine("\nEnter your age ");
                        int age = int.Parse(Console.ReadLine());
                        string insertQuery = "INSERT INTO Student (Name, Age) VALUES ('" + name + "'," + age + ")";


                        SqlCommand insertcommand = new SqlCommand(insertQuery, sqlConnection);
                        insertcommand.ExecuteNonQuery();
                        Console.WriteLine("\nData is sucessfully inserted");
                        break;


                    case 2:

                        //retrive data

                        string displayQuery = "Select * from student";
                        SqlCommand displaycommand = new SqlCommand(displayQuery, sqlConnection);
                        SqlDataReader datareader = displaycommand.ExecuteReader();
                        Console.WriteLine("==========================================");
                        while (datareader.Read())
                        {

                            Console.WriteLine("Id: " + datareader.GetValue(0).ToString());
                            Console.WriteLine("Name: " + datareader.GetValue(1));
                            Console.WriteLine("Age: " + datareader.GetValue(2).ToString());

                            Console.WriteLine("\n");
                        }
                        Console.WriteLine("==========================================");
                        datareader.Close();
                        break;


                    case 3:

                        //update name data

                        int student_id_update_name;
                        bool idverify = false;
                        while (!idverify)
                        {
                            Console.WriteLine("\nEnter user id to update ");
                            int student_id_name_update = int.Parse(Console.ReadLine());
                            string CheckStudentCount = "SELECT COUNT(*) FROM student WHERE studentid = " + student_id_name_update;
                            SqlCommand checkID = new SqlCommand(CheckStudentCount, sqlConnection);
                            int count = (int)checkID.ExecuteScalar();

                            if (count > 0)
                            {
                                Console.WriteLine("\nEnter updated user name ");
                                string username = Console.ReadLine();
                                string UpdateNameQuery = "Update student set name = " + "'" + username + "'" + " where studentid =" + student_id_name_update;
                                SqlCommand UpdateNamecommand = new SqlCommand(UpdateNameQuery, sqlConnection);
                                UpdateNamecommand.ExecuteNonQuery();
                                Console.WriteLine("\nData updated sucessfullt name ");
                                idverify = true;
                            }
                            else
                            {
                                Console.WriteLine("Id not found");
                            }
                        }


                        break;


                    case 4:

                        //update age data

                        int student_id_update;
                        bool idcheck = false;

                        while (!idcheck)
                        {
                            Console.WriteLine("\nEnter user id to update ");
                            student_id_update = int.Parse(Console.ReadLine());
                            string CheckStudentCount = "SELECT COUNT(*) FROM student WHERE studentid = " + student_id_update;
                            SqlCommand checkID = new SqlCommand(CheckStudentCount, sqlConnection);
                            int count = (int)checkID.ExecuteScalar();

                            if (count > 0)
                            {
                                Console.WriteLine("\nEnter updated user age ");
                                int userage = int.Parse(Console.ReadLine());
                                string UpdateAgeQuery = "Update student set age =" + userage + " where studentid =" + student_id_update;
                                SqlCommand UpdateAgecommand = new SqlCommand(UpdateAgeQuery, sqlConnection);
                                UpdateAgecommand.ExecuteNonQuery();
                                Console.WriteLine("\nData updated sucessfullt age ");
                                idcheck = true;
                            }
                            else
                            {
                                Console.WriteLine("Id not found");
                            }
                        }
                        break;


                    case 5:
                        //delete data

                        int student_id_delete;
                        bool idExists = false;

                        while (!idExists)
                        {
                            Console.WriteLine("\nEnter the id to be deleted ");
                            student_id_delete = int.Parse(Console.ReadLine());
                            string CheckStudentCount = "SELECT COUNT(*) FROM student WHERE studentid = " + student_id_delete;
                            SqlCommand checkID = new SqlCommand(CheckStudentCount, sqlConnection);
                            int count = (int)checkID.ExecuteScalar(); ;


                            if (count > 0) {

                                string DeleteQuery = "Delete From student where studentid =" + student_id_delete;
                                SqlCommand deletecommand = new SqlCommand(DeleteQuery, sqlConnection);
                                deletecommand.ExecuteNonQuery();
                                Console.WriteLine("\nDeleted sucessfully");
                                idExists = true;
                            }
                            else
                            {
                                Console.WriteLine("Id not found");
                            }


                        }

                        break;

                    default:
                        Console.WriteLine("Invalid input");
                        break;

                }

                Console.WriteLine("Do you want to continue ");
                answer = Console.ReadLine();

            } while (answer.ToLower() != "no");


        }

        catch (Exception ex) {
            Console.WriteLine(ex.Message);

        }
        finally
        {
            sqlConnection.Close();
        }
    }

   
}
   
    





