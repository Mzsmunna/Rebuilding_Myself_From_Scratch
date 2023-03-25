using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    public class SqlCommands
    {
        public string createDB = "CREATE DATABASE xyz";
        public string deleteDB = "DROP DATABASE xyz";

        public string createTableExample1 = @"create table Students(
                                                id int primary key not null identity(1,1),
	                                            lastname nvarchar(50) not null,
	                                            firstname nvarchar(50) not null,
	                                            dateofbirth datetime not null,
	                                            enrollmentdate datetime 
                                            );";

        public string createTableExample2 = @"create table Courses(
                                                CourseId int identity(1,1) primary key,
	                                            Title nvarchar(50) not null,
	                                            NumberOfCredits int,
	                                            CourseCode nvarchar(5) not null
                                            )";


    }
}
