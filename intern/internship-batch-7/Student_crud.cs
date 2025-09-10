using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace internship_batch_7
{
   class Student_crud
    {
        private void Main(string[] args)
        {
            SqlConnection cn = new SqlConnection("Data Source=DESKTOP-OFDB3MH;Initial Catalog=amnil;Persist Security Info=True;User ID=nirajan;Password=nir@j@n17");

			try
			{
				cn.Open();

                //declare 
                int id;
                string fName;
                string lName;
                string gender;
                string roll;
                string grade;

                //list
                string list = "select * from tbl_student";
                SqlCommand cmdList = new SqlCommand(list, cn);
                SqlDataReader dr = cmdList.ExecuteReader();
                var table = new Table();

                table.AddColumn("Id");
                table.AddColumn("First Name");
                table.AddColumn("Last Name");
                table.AddColumn("Gender");
                table.AddColumn("RollNumber");
                table.AddColumn("Grade");

                while (dr.Read())
                {
                    table.AddRow(
                        dr["Id"].ToString(),
                        dr["FirstName"].ToString(),
                        dr["LastName"].ToString(),
                        dr["Gender"].ToString(),
                        dr["RollNumber"].ToString(),
                        dr["Grade"].ToString()
                    );
                }
                dr.Close();
                AnsiConsole.Write(table);

                //insert
                Console.WriteLine();
                Console.WriteLine("Add student");
                Console.WriteLine("---------------");
                Console.Write("Enter your First Name : ");
                fName = Console.ReadLine();

                Console.Write("Enter your Last Name : ");
                lName = Console.ReadLine();

                Console.Write("Enter your Gender : ");
                gender = Console.ReadLine();

                Console.Write("Enter your Roll Number : ");
                roll = Console.ReadLine();

                Console.Write("Enter your Grade : ");
                grade = Console.ReadLine();

                //sql query
                string insert = "Insert into tbl_student(firstName,lastName,gender,rollNumber,grade) Values('" + fName + "','" + lName + "','" + gender + "','" + roll + "','" + grade + "')";
                SqlCommand cmdInsert = new SqlCommand(insert, cn);
                cmdInsert.ExecuteNonQuery();
                Console.WriteLine("Insert successfully !");

                // edit
                Console.WriteLine();
                Console.WriteLine("update student");
                Console.WriteLine("---------------");

                Console.Write("Enter Id of student you want to update : ");
                id = int.Parse(Console.ReadLine());                

                //update 
                Console.Write("Enter your First Name : ");
                fName = Console.ReadLine();

                Console.Write("Enter your Last Name : ");
                lName = Console.ReadLine();

                Console.Write("Enter your Gender : " );
                gender = Console.ReadLine();

                Console.Write("Enter your Roll Number : ");
                roll = Console.ReadLine();

                Console.Write("Enter your Grade : ");
                grade = Console.ReadLine();

                string update = "update tbl_student set firstName= '" + fName + "', lastName= '" + lName + "', gender= '" + gender + "', rollNumber= '" + roll + "', grade= '" + grade + "' where id='" + id + "' ";
                SqlCommand cmdUpdate = new SqlCommand(update, cn);
                cmdUpdate.ExecuteNonQuery();
                Console.WriteLine("Update successfully");

                //delete
                Console.Write("Enter Id of student you want to Delete : ");
                id = int.Parse(Console.ReadLine());
                string delete = "delete from tbl_student where id= '" + id + "' ";
                SqlCommand cmdDelete = new SqlCommand(delete, cn);
                cmdDelete.ExecuteNonQuery();
                Console.WriteLine("Delete successfully !");

                cn.Close();
            }
			catch (Exception)
			{

				throw;
			}
        }
    }
}
