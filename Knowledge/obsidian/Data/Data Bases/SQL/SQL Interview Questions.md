# [Top SQL Interview Questions For Beginners](https://www.softwaretestinghelp.com/50-popular-sql-interview-questions-for-testers/)
---
**Q #1) What is SQL?**
---

**Answer:** Structured Query Language SQL is a database tool that is used to create and access databases to support software applications.

---
**Q #2) What are tables in SQL?**
---

**Answer:** A table is a collection of records and information in a single view.

---
**Q #3) What are the different types of statements supported by SQL?**
---
**Answer:**

[![statements supported by SQL](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/statements-supported-by-SQL.jpg)](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/statements-supported-by-SQL.jpg)

**There are 3 types of SQL statements:**

**a) DDL (Data Definition Language):** It is used to define the database structure such as tables. It includes three statements such as CREATE, ALTER, and DROP.

_**Also read =>> [MySQL Create Table Tutorial](https://www.softwaretestinghelp.com/mysql-create-table-tutorial/)**_

**Some of the DDL Commands are listed below:**

**CREATE**: It is used for creating the table.

|   |   |
|---|---|
|1<br><br>2<br><br>3<br><br>4|`CREATE` `TABLE` `table_name`<br><br>`column_name1 data_type(``size``),`<br><br>`column_name2 data_type(``size``),`<br><br>`column_name3 data_type(``size``),`|

**ALTER:** The ALTER table is used for modifying the existing table object in the database.

|   |   |
|---|---|
|1<br><br>2|`ALTER` `TABLE` `table_name`<br><br> `ADD` `column_name datatype`|

OR

|   |   |
|---|---|
|1<br><br>2|`ALTER` `TABLE` `table_name`<br><br>`DROP` `COLUMN` `column_name`|

**b) DML (Data Manipulation Language):** These statements are used to manipulate the data in records. Commonly used DML statements are INSERT, UPDATE, and DELETE.

The SELECT statement is used as a partial DML statement, used to select all or relevant records from a table.

**c) DCL (Data Control Language):** These statements are used to set privileges such as GRANT and REVOKE database access permission to specific users**.**

---
**Q #4) What do we use the DISTINCT statement for? What is its use?**
---

**Answer:** The DISTINCT statement is used with the SELECT statement. If the record contains duplicate values then the DISTINCT statement is used to select different values among duplicate records.

**Syntax:**

|   |   |
|---|---|
|1<br><br>2|`SELECT` `DISTINCT` `column_name(s)`<br><br> `FROM` `table_name;`|

---
**Q #5) What are the different Clauses used in SQL?**
---

**Answer:**

[![Clauses used in SQL](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/Clauses-used-in-SQL.jpg)](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/Clauses-used-in-SQL.jpg)

**WHERE Clause:** This clause is used to define the condition, and extract and display only those records which fulfill the given condition.

**Syntax:**

|   |   |
|---|---|
|1<br><br>2<br><br>3|`SELECT` `column_name(s)`<br><br> `FROM` `table_name`<br><br> `WHERE` `condition;`|

**GROUP BY Clause:** It is used with the SELECT statement to group the result of the executed query using the value specified in it. It matches the value with the column name in the tables and groups the end result accordingly.

**Further reading => [MySQL Group By Tutorial](https://www.softwaretestinghelp.com/mysql-group-by-clause/)**

**Syntax:**

|   |   |
|---|---|
|1<br><br>2<br><br>3|`SELECT` `column_name(s)`<br><br> `FROM` `table_name`<br><br> `GROUP` `BY` `column_name;`|

**HAVING clause:** This clause is used in association with the GROUP BY clause. It is applied to each group of results or the entire result as a single group. It is very similar to the WHERE clause but the only difference is you cannot use it without the GROUP BY clause

**Syntax:**

|   |   |
|---|---|
|1<br><br>2<br><br>3<br><br>4|`SELECT` `column_name(s)`<br><br> `FROM` `table_name`<br><br> `GROUP` `BY` `column_name`<br><br> `HAVING` `condition;`|

**ORDER BY clause:** This clause is used to define the order of the query output either in ascending (ASC) or in descending (DESC). Ascending (ASC) is set as the default one but descending (DESC) is set explicitly.

**Syntax:**

|   |   |
|---|---|
|1<br><br>2<br><br>3<br><br>4|`SELECT` `column_name(s)`<br><br> `FROM` `table_name`<br><br> `WHERE` `condition`<br><br> `ORDER` `BY` `column_name` `ASC``\|``DESC``;`|

**USING clause:** USING clause comes in use while working with SQL JOIN. It is used to check equality based on columns when tables are joined. It can be used instead of the ON clause in JOIN.

**Syntax:**

|   |   |
|---|---|
|1<br><br>2<br><br>3<br><br>4|`SELECT` `column_name(s)`<br><br> `FROM` `table_name`<br><br> `JOIN` `table_name`<br><br> `USING (column_name);`|

---
**Q #6) Why do we use SQL constraints? Which constraints we can use while creating a database in SQL?**
---

**Answer:** Constraints are used to set the rules for all records in the table. If any constraints get violated then it can abort the action that caused it.

Constraints are defined while creating the database itself with the CREATE TABLE statement or even after the table is created once with the ALTER TABLE statement.

**There are 5 major constraints used in SQL, such as**

- **NOT NULL:** This indicates that the column must have some value and cannot be left NULL.
- **UNIQUE:** This constraint is used to ensure that each row and column has a unique value and no value is being repeated in any other row or column.
- **PRIMARY KEY:** This constraint is used in association with NOT NULL and UNIQUE constraints, such as on one or a combination of more than one column to identify a particular record with a unique identity.
- **FOREIGN KEY:** It is used to ensure the referential integrity of data in the table. It matches the value in one table with another using the PRIMARY KEY.
- **CHECK:** It ensures whether the value in columns fulfills the specified condition.

**Suggested Reading => [Boost Your Career with these SQL Certifications](https://www.softwaretestinghelp.com/best-sql-certifications/)**

---
**Q #7) What are different JOINS used in SQL?**
---

**Answer:**

[![SQL Joins](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/SQL-Joins.jpg)](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/SQL-Joins.jpg)

4 major types of joins are used while working on multiple tables in SQL databases:

**INNER JOIN:** It is also known as SIMPLE JOIN which returns all rows from BOTH tables when it has at least one matching column.

**Syntax:**

|   |   |
|---|---|
|1<br><br>2<br><br>3<br><br>4|`SELECT` `column_name(s)`<br><br> `FROM` `table_name1&amp;amp;amp;amp;nbsp;`<br><br> `INNER` `JOIN` `table_name2`<br><br> `ON` `column_name1=column_name2;`|

**For Example,**

In this example, we have a table **Employee** with the following data:

[![Employee table](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/Employee-table-1.jpg)](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/Employee-table-1.jpg)

The second table’s name is **Joining.**

[![joining](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/joining.jpg)](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/joining.jpg)

**Enter the following SQL statement:**

|   |   |
|---|---|
|1<br><br>2<br><br>3<br><br>4<br><br>5|`SELECT` `Employee.Emp_id, Joining.Joining_Date`<br><br>  `FROM` `Employee`<br><br>  `INNER` `JOIN` `Joining`<br><br>  `ON` `Employee.Emp_id = Joining.Emp_id`<br><br>  `ORDER` `BY` `Employee.Emp_id;`|

There will be 4 records selected. **Results are:**

[![result of innerjoin](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/result-of-innerjoin.jpg)](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/result-of-innerjoin.jpg)

**Employee** and **Orders** tables have a matching _customer_id_ value.

**LEFT JOIN (LEFT OUTER JOIN):** This join returns all rows from the LEFT table and its matched rows from a RIGHT table**.**

**Syntax:**

|   |   |
|---|---|
|1<br><br>2<br><br>3<br><br>4|`SELECT` `column_name(s)`<br><br> `FROM` `table_name1`<br><br> `LEFT` `JOIN` `table_name2`<br><br> `ON` `column_name1=column_name2;`|

**For Example,**

In this example, we have a table **Employee** with the following data:

[![Employee table](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/Employee-table-1.jpg)](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/Employee-table-1.jpg)

The second table’s name is **Joining.**

[![joining 1](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/joining-1.jpg)](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/joining-1.jpg)

**Enter the following SQL statement:**

|   |   |
|---|---|
|1<br><br>2<br><br>3<br><br>4<br><br>5|`SELECT` `Employee.Emp_id, Joining.Joining_Date`<br><br>`FROM` `Employee`<br><br>`LEFT` `OUTER` `JOIN` `Joining`<br><br>`ON` `Employee.Emp_id = Joining.Emp_id`<br><br>`ORDER` `BY` `Employee.Emp_id;`|

There will be 4 records selected. **You will see the following results:**

[![result of LEFT OUTER JOIN](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/result-of-LEFT-OUTER-JOIN.jpg)](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/result-of-LEFT-OUTER-JOIN.jpg)

**RIGHT JOIN (RIGHT OUTER JOIN):** This joins returns all rows from the RIGHT table and its matched rows from the LEFT table**.**

**Syntax:**

|   |   |
|---|---|
|1<br><br>2<br><br>3<br><br>4|`SELECT` `column_name(s)`<br><br>`FROM` `table_name1`<br><br>`RIGHT` `JOIN` `table_name2`<br><br>`ON` `column_name1=column_name2;`|

**For Example,**

In this example, we have a table **Employee** with the following data:

[![Employee table](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/Employee-table-1.jpg)](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/Employee-table-1.jpg)

The second table’s name is **Joining.**

[![joining table](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/joining-1.jpg)](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/joining-1.jpg)

**Enter the following SQL statement:**

|   |   |
|---|---|
|1<br><br>2<br><br>3<br><br>4|`SELECT` `Employee.Emp_id, Joining.Joining_Date` `FROM` `Employee`<br><br>`RIGHT` `JOIN` `Joining`<br><br>`ON` `Employee.Emp_id = Joining.Emp_id`<br><br>`ORDER` `BY` `Employee.Emp_id;`|

**Output:**

|Emp_id|Joining_Date|
|---|---|
|E0012|2016/04/18|
|E0013|2016/04/19|
|E0014|2016/05/01|

**FULL JOIN (FULL OUTER JOIN):** This joins returns all results when there is a match either in the RIGHT table or in the LEFT table**.**

**Syntax:**

|   |   |
|---|---|
|1<br><br>2<br><br>3<br><br>4|`SELECT` `column_name(s)`<br><br> `FROM` `table_name1`<br><br> `FULL` `OUTER` `JOIN` `table_name2`<br><br> `ON` `column_name1=column_name2;`|

**For Example,**

In this example, we have a table **Employee** with the following data:

[![Employee table](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/Employee-table-1.jpg)](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/Employee-table-1.jpg)

The second table’s name is **Joining.**

[![joining 1](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/joining-1.jpg)](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/joining-1.jpg)

**Enter the following SQL statement:**

|   |   |
|---|---|
|1<br><br>2<br><br>3<br><br>4<br><br>5|`SELECT` `Employee.Emp_id, Joining.Joining_Date`<br><br>`FROM` `Employee`<br><br>`FULL` `OUTER` `JOIN` `Joining`<br><br>`ON` `Employee.Emp_id = Joining.Emp_id`<br><br>`ORDER` `BY` `Employee.Emp_id;`|

There will be 8 records selected. **These are the results that you should see.**

[![result of FULL OUTER JOIN](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/result-of-FULL-OUTER-JOIN.jpg)](https://www.softwaretestinghelp.com/wp-content/qa/uploads/2016/07/result-of-FULL-OUTER-JOIN.jpg)

_**A****lso, Read => [MySQL Join Tutorial](https://www.softwaretestinghelp.com/mysql-join-tutorial/)**_

---
**Q #8) What are transactions and their controls?**
---

**Answer:** A transaction can be defined as the sequence task that is performed on databases in a logical manner to gain certain results. Operations like Creating, updating, and deleting records performed in the database come from transactions.

In simple words, we can say that a transaction means a group of SQL queries executed on database records.

**There are 4 transaction controls such as**

- **COMMIT**: It is used to save all changes made through the transaction.
- **ROLLBACK**: It is used to roll back the transaction. All changes made by the transaction are reverted back and the database remains as before.
- **SET TRANSACTION**: Set the name of the transaction.
- **SAVEPOINT:** It is used to set the point where the transaction is to be rolled back.

---
**Q #9) What are the properties of the transaction?**
---

**Answer:** **Properties of the transaction are known as ACID properties. These are:**

- **Atomicity**: Ensures the completeness of all transactions performed. Checks whether every transaction is completed successfully or not. If not, then the transaction is aborted at the failure point and the previous transaction is rolled back to its initial state as changes are undone.
- **Consistency**: Ensures that all changes made through successful transactions are reflected properly on the database.
- **Isolation**: Ensures that all transactions are performed independently and changes made by one transaction are not reflected on others.
- **Durability**: Ensures that the changes made in the database with committed transactions persist as it is even after a system failure.

---
**Q #10) How many Aggregate functions are available in SQL?**
---

**Answer:** SQL Aggregate functions determine and calculate values from multiple columns in a table and return a single value.

**There are 7 aggregate functions in SQL:**

- **AVG():** Returns the average value from the specified columns.
- **COUNT():** Returns the number of table rows.
- **MAX():** Returns the largest value among the records.
- **MIN():** Returns the smallest value among the records.
- **SUM():** Returns the sum of specified column values.
- **FIRST():** Returns the first value.
- **LAST():** Returns last value.

# SQL Intermediate to Advanced Interview Questions

---
**Q #11) What are Scalar functions in SQL?**
---

**Answer:** Scalar functions are used to return a single value based on the input values.

**Scalar Functions are as follows:**

- **UCASE():** Converts the specified field in the upper case.
- **LCASE():** Converts the specified field in lowercase.
- **MID():** Extracts and returns characters from the text field.
- **FORMAT():** Specifies the display format.
- **LEN():** Specifies the length of the text field.
- **ROUND():** Rounds up the decimal field value to a number.

---
**Q #12) What are triggers**?
---

**Answer:** Triggers in SQL is kind of stored procedures used to create a response to a specific action performed on the table such as INSERT, UPDATE or DELETE. You can invoke triggers explicitly on the table in the database.

Action and Event are two main components of SQL triggers. When certain actions are performed, the event occurs in response to that action.

**Syntax:**

|   |   |
|---|---|
|1<br><br>2<br><br>3|`CREATE` `TRIGGER` `name` `{BEFORE\|``AFTER``} (event [``OR``..]}`<br><br>`ON` `table_name [``FOR` `[EACH] {ROW\|STATEMENT}]`<br><br>`EXECUTE` `PROCEDURE` `functionname {arguments}`|

---
**Q #13) What is View in SQL?**
---

**Answer:** A View can be defined as a virtual table that contains rows and columns with fields from one or more tables.

**S****yntax:**

|   |   |
|---|---|
|1<br><br>2<br><br>3<br><br>4|`CREATE` `VIEW` `view_name` `AS`<br><br>`SELECT` `column_name(s)`<br><br>`FROM` `table_name`<br><br>`WHERE` `condition`|

---
**Q #14) How we can update the view?**
---

**Answer:** SQL CREATE and REPLACE can be used for updating the view.

Execute the below query to update the created view.

**Syntax:**

|   |   |
|---|---|
|1<br><br>2<br><br>3<br><br>4|`CREATE` `OR` `REPLACE` `VIEW` `view_name` `AS`<br><br> `SELECT` `column_name(s)`<br><br> `FROM` `table_name`<br><br> `WHERE` `condition`|

---
**Q #15) Explain the working of SQL Privileges.**
---

**Answer:** SQL GRANT and REVOKE commands are used to implement privileges in SQL multiple-user environments. The administrator of the database can grant or revoke privileges to or from users of database objects by using commands like SELECT, INSERT, UPDATE, DELETE, ALL, etc.

**GRANT Command**: This command is used to provide database access to users other than the administrator.

**Syntax:**

|   |   |
|---|---|
|1<br><br>2<br><br>3<br><br>4|`GRANT` `privilege_name`<br><br> `ON` `object_name`<br><br> `TO` `{user_name\|``PUBLIC``\|role_name}`<br><br> `[``WITH` `GRANT` `OPTION``];`|

In the above syntax, the GRANT option indicates that the user can grant access to another user too.

**REVOKE command**: This command is used to provide database deny or remove access to database objects.

**Syntax:**

|   |   |
|---|---|
|1<br><br>2<br><br>3|`REVOKE` `privilege_name`<br><br> `ON` `object_name`<br><br> `FROM` `{user_name\|``PUBLIC``\|role_name};`|

---
**Q #16) How many types of Privileges are available in SQL?**
---

**Answer:** **There are two types of privileges used in SQL, such as**

- **System privilege:** System privilege deals with the object of a particular type and provides users the right to perform one or more actions on it. These actions include performing administrative tasks, ALTER ANY INDEX, ALTER ANY CACHE GROUP creates/ALTER/DELETE TABLE, CREATE/ALTER/DELETE VIEW, etc.
- **Object privilege:** This allows us to perform actions on an object or object of another user(s) viz. table, view, indexes, etc. Some of the object privileges are EXECUTE, INSERT, UPDATE, DELETE, SELECT, FLUSH, LOAD, INDEX, REFERENCES, etc.

---
**Q #17) What is SQL Injection?**
---

**Answer:** SQL Injection is a type of database attack technique where malicious SQL statements are inserted into an entry field of the database in a way that once it is executed, the database is exposed to an attacker for the attack. This technique is usually used for attacking data-driven applications to have access to sensitive data and perform administrative tasks on databases.

**For Example,**

|   |   |
|---|---|
|1|`SELECT` `column_name(s)` `FROM` `table_name` `WHERE` `condition;`|

---
**Q #18) What is SQL Sandbox in SQL Server?**
---

**Answer:** SQL Sandbox is a safe place in the SQL server environment where untrusted scripts are executed. There are 3 types of SQL sandbox:

- **Safe Access Sandbox:** Here a user can perform SQL operations such as creating stored procedures, triggers, etc. but cannot have access to the memory as well as cannot create files.
- **External Access Sandbox:** Users can access files without having the right to manipulate the memory allocation.
- **Unsafe Access Sandbox:** This contains untrusted codes where a user can have access to memory.

---
**Q #19) What is the difference between SQL and PL/SQL?**
---

**Answer:** SQL is a Structured Query Language to create and access databases whereas PL/SQL comes with procedural concepts of programming languages.

---
**Q #20) What is the difference between SQL and MySQL?**
---

**Answer:** SQL is a Structured Query Language that is used for manipulating and accessing the relational database. On the other hand, MySQL itself is a relational database that uses SQL as the standard database language.

---
**Q #21) What is the use of the NVL function?**
---

**Answer: The** NVL function is used to convert the null value to its actual value.

---
**Q #22) What is the Cartesian product of the table?**
---

**Answer:** The output of Cross Join is called a Cartesian product. It returns rows combining each row from the first table with each row of the second table. **For Example,** if we join two tables having 15 and 20 columns the Cartesian product of two tables will be 15×20=300 rows.

---
**Q #23) What do you mean by Subquery?**
---

**Answer:** Query within another query is called as Subquery. A subquery is called an inner query which returns output that is to be used by another query.

---
**Q #24) How many row comparison operators are used while working with a subquery?**
---

**Answer:** There are 3-row comparison operators that are used in subqueries such as IN, ANY, and ALL.

---
**Q #25) What is the difference between clustered and non-clustered indexes?**
---

**Answer: The differences between the two are as follows:**

- One table can have only one clustered index but multiple non-clustered indexes.
- Clustered indexes can be read rapidly rather than non-clustered indexes.
- Clustered indexes store data physically in the table or view whereas, non-clustered indexes do not store data in the table as it has a separate structure from the data row.

---
**Q #26) What is the difference between DELETE and TRUNCATE?**
---

**Answer: The differences are:**

- The basic difference in both is DELETE command is the DML command and the TRUNCATE command is DDL.
- DELETE command is used to delete a specific row from the table whereas the TRUNCATE command is used to remove all rows from the table.
- We can use the DELETE command with the WHERE clause but cannot use the TRUNCATE command with it.

---
**Q #27) What is the difference between DROP and TRUNCATE?**
---

**Answer:** TRUNCATE removes all rows from the table which cannot be retrieved back, DROP removes the entire table from the database and it also cannot be retrieved back.

---
**Q #28) How to write a query to show the details of a student from the Students table whose name start with K?**
---

**Answer: Query:**

|   |   |
|---|---|
|1|`SELECT` `*` `FROM` `Student` `WHERE` `Student_Name` `like` `‘K%’;`|

Here ‘like’ operator is used to perform pattern matching.

---
**Q #29) What is the difference between Nested Subquery and Correlated Subquery?**
---

**Answer:** Subquery within another subquery is called Nested Subquery.  If the output of a subquery depends on column values of the parent query table then the query is called Correlated Subquery.

|   |   |
|---|---|
|1<br><br>2|`SELECT` `adminid(SELEC Firstname+``' '``+Lastname&amp;amp;amp;amp;nbsp;&amp;amp;amp;amp;nbsp;``FROM` `Employee` `WHERE`<br><br> `empid=emp. adminid)``AS` `EmpAdminId` `FROM` `Employee;`|

The result of the query is the details of an employee from the Employee table.

---
**Q #30) What is Normalization? How many Normalization forms are there?**
---

**Answer:** Normalization is used to organize the data in such a manner that data redundancy will never occur in the database and avoid insert, update and delete anomalies.

**There are 5 forms of Normalization:**

- **First Normal Form (1NF):** It removes all duplicate columns from the table. It creates a table for related data and identifies unique column values.
- **First Normal Form (2NF):** Follows 1NF and creates and places data subsets in an individual table and defines the relationship between tables using the primary key.
- **Third Normal Form (3NF):** Follows 2NF and removes those columns which are not related through the primary key.
- **Fourth Normal Form (4NF):** Follows 3NF and does not define multi-valued dependencies. 4NF is also known as BCNF.

---
**Q #31) What is a Relationship? How many types of Relationships are there?**
---

**Answer:** The relationship can be defined as the connection between more than one table in the database.

**There are 4 types of relationships:**

- One-to-One Relationship
- Many to One Relationship
- Many to Many Relationship
- One to Many Relationship

---
**Q #32) What do you mean by Stored Procedures? How do we use it?**
---

**Answer:** A stored procedure is a collection of SQL statements that can be used as a function to access the database. We can create these stored procedures earlier before using it and can execute them wherever required by applying some conditional logic to them. Stored procedures are also used to reduce network traffic and improve performance.

**Syntax:**

|   |   |
|---|---|
|1<br><br>2<br><br>3<br><br>4<br><br>5<br><br>6<br><br>7<br><br>8|`CREATE` `Procedure` `Procedure_Name`<br><br> `(`<br><br> `//Parameters`<br><br> `)`<br><br> `AS`<br><br> `BEGIN`<br><br> `SQL statements` `in` `stored procedures` `to` `update``/retrieve records`<br><br> `END`|

---
**Q #33) State some properties of Relational databases.**
---

**Answer: Properties are as follows:**

- In relational databases, each column should have a unique name.
- The sequence of rows and columns in relational databases is insignificant.
- All values are atomic and each row is unique.

---
**Q #34) What are Nested Triggers?**
---

**Answer:** Triggers may implement data modification logic by using INSERT, UPDATE, and DELETE statements. These triggers that contain data modification logic and find other triggers for data modification are called Nested Triggers.

---
**Q #35) What is a Cursor?**
---

**Answer:** A cursor is a database object which is used to manipulate data in a row-to-row manner.

**The cursor follows steps given below:**

- Declare Cursor
- Open Cursor
- Retrieve row from the Cursor
- Process the row
- Close Cursor
- Deallocate Cursor

---
**Q #36) What is Collation?**
---

**Answer:** Collation is a set of rules that check how the data is sorted by comparing it. Such as character data is stored using the correct character sequence along with case sensitivity, type, and accent.

---
**Q #37) What do we need to check in Database Testing?**
---

**Answer:** **In Database testing, the following thing is required to be tested:**

- Database connectivity
- Constraint check
- Required application field and its size
- Data Retrieval and processing with DML operations
- Stored Procedures
- Functional flow

---
**Q #38) What is Database White Box Testing?**
---

**Answer:** **Database White Box testing involves:**

- Database Consistency and ACID properties
- Database triggers and logical views
- Decision Coverage, Condition Coverage, and Statement Coverage
- Database Tables, Data Model, and Database Schema
- Referential integrity rules

---
**Q #39) What is Database Black Box Testing?**
---

**Answer:** **Database Black Box testing involves:**

- Data Mapping
- Data stored and retrieved
- Use of Black Box testing techniques such as Equivalence Partitioning and Boundary Value Analysis (BVA)

---
**Q #40) What are Indexes in SQL?**
---

**Answer:** The index can be defined as the way to retrieve data more quickly. We can define indexes using CREATE statements.

**Syntax:**

|   |   |
|---|---|
|1<br><br>2|`CREATE` `INDEX` `index_name`<br><br> `ON` `table_name (column_name)`|

Further, we can also create a Unique Index using the following syntax:

|   |   |
|---|---|
|1<br><br>2|`CREATE` `UNIQUE` `INDEX` `index_name`<br><br> `ON` `table_name (column_name)`|

# Few More SQL Basic Interview Questions

---
**Q #41) What does SQL stand for?**
---

**Answer:** SQL stands for [Structured Query Language](http://en.wikipedia.org/wiki/SQL).

---
**Q #42) How to select all records from the table?**
---
**Answer:** To select all the records from the table we need to use the following syntax:

|   |   |
|---|---|
|1|`Select` `*` `from` `table_name;`|

---
**Q #43) Define join and name different types of joins.**
---

**Answer:** Join keyword is used to fetch data from two or more related tables. It returns rows where there is at least one match in both the tables included in the join. [Read more here](http://www.w3schools.com/sql/sql_join.asp).  
**Type of joins are:**

1. Right join
2. Outer join
3. Full join
4. Cross join
5. Self join.

---
**Q #44) What is the syntax to add a record to a table?**
---

**Answer:** To add a record in a table INSERT syntax is used.

**For Example,**

|   |   |
|---|---|
|1|`INSERT` `into` `table_name` `VALUES` `(value1, value2..);`|

---
**Q #45) How do you add a column to a table?**
---

**Answer:** To add another column to the table, use the following command:

|   |   |
|---|---|
|1|`ALTER` `TABLE` `table_name` `ADD` `(column_name);`|

**Recommended reading =>> How to [add a column to a table](https://www.softwaretestinghelp.com/mysql-alter-table/) in MySQL**

---
**Q #46) Define the SQL DELETE statement.**
---

**Answer:** DELETE is used to delete a row or rows from a table based on the specified condition.  
**The basic syntax is as follows:**

|   |   |
|---|---|
|1<br><br>2|`DELETE` `FROM` `table_name`<br><br>`WHERE` `&amp;amp;amp;amp;lt;Condition&amp;amp;amp;amp;gt;`|

---
**Q #47) Define COMMIT?**
---

**Answer:** COMMIT saves all changes made by DML statements.

---
**Q #48) What is the Primary key?**
---

**Answer:** A Primary key is a column whose values uniquely identify every row in a table. Primary key values can never be reused.

---
**Q #49) What are Foreign keys?**
---

**Answer:** When a table’s primary key field is added to related tables in order to create the common field which relates the two tables, it is called a foreign key in other tables. Foreign key constraints enforce referential integrity.

---
**Q #50) What is CHECK Constraint?**
---

**Answer:** A CHECK constraint is used to limit the values or type of data that can be stored in a column. They are used to enforce domain integrity.

---
**Q #51) Is it possible for a table to have more than one foreign key?**
---

**Answer:** Yes, a table can have many foreign keys but only one primary key.

---
**Q #52) What are the possible values for the BOOLEAN data field?**
---

**Answer:** For a BOOLEAN data field, two values are possible: -1(true) and 0(false).

---
**Q #53) What is a stored procedure?**
---

**Answer:** A stored procedure is a set of SQL queries that can take input and send back output.

---
**Q #54) What is identity in SQL?**
---

**Answer:** An identity column where SQL automatically generates numeric values. We can define a start and increment value of the identity column.

---
**Q #55) What is Normalization?**
---

**Answer:** The process of table design to minimize data redundancy is called normalization. We need to divide a database into two or more tables and define the relationship between them.

---
**Q #56) What is a Trigger?**
---

**Answer:** The Trigger allows us to execute a batch of SQL code when a tabled event occurs (INSERT, UPDATE or DELETE commands are executed against a specific table).

---
**Q #57) How to select random rows from a table?**
---

**Answer:** Using a SAMPLE clause we can select random rows.

**For Example,**

|   |   |
|---|---|
|1|`SELECT` `*` `FROM` `table_name SAMPLE(10);`|

---
**Q #58) Which TCP/IP port does SQL Server run?**
---

**Answer:** By default SQL Server runs on port 1433.

---
**Q #59) Write a SQL SELECT query that only returns each name only once from a table.**
---

**Answer:** To get the result as each name only once, we need to use the DISTINCT keyword.

|   |   |
|---|---|
|1|`SELECT` `DISTINCT` `name` `FROM` `table_name;`|

---
**Q #60) Explain DML and DDL.**
---

**Answer:** DML stands for Data Manipulation Language. INSERT, UPDATE and DELETE  are DML statements.

DDL stands for Data Definition Language. CREATE, ALTER, DROP, RENAME are DDL statements.

---
**Q #61) Can we rename a column in the output of the SQL query?**
---

**Answer:** Yes, using the following syntax we can do this.

|   |   |
|---|---|
|1|`SELECT` `column_name` `AS` `new_name` `FROM` `table_name;`|

---
**Q #62) Give the order of SQL SELECT.**
---

**Answer:** The order of SQL SELECT clauses is: SELECT, FROM, WHERE, GROUP BY, HAVING, ORDER BY. Only the SELECT and FROM clauses are mandatory.

---
**Q #63) Suppose a Student column has two columns, Name and Marks. How to get names and marks of the top three students.**  
---

**Answer:** SELECT Name, Marks FROM Student s1 where 3 <= (SELECT COUNT(*) FROM Students s2 WHERE s1.marks = s2.marks)

---
**Q #64) What are SQL comments?**
---

**Answer:** SQL comments can be inserted by adding two consecutive hyphens (–).

---
**Q #65) Difference between TRUNCATE, DELETE, and DROP commands?**
---

**Answer:**

- **DELETE** removes some or all rows from a table based on the condition. It can be rolled back.
- **TRUNCATE** removes ALL rows from a table by de-allocating the memory pages. The operation cannot be rolled back
- **DROP** command removes a table from the database completely.

---
**Q #66) What are the properties of a transaction?**
---

**Answer:** Generally, these properties are referred to as ACID properties. They are:

1. Atomicity
2. Consistency
3. Isolation
4. Durability.

---
**Q #67) What do you mean by ROWID?**
---

**Answer:** It’s an 18-character long pseudo-column attached to each row of a table.

---
**Q #68) Define UNION, MINUS, UNION ALL, INTERSECT?**
---

**Answer:**

- **MINUS** – returns all distinct rows selected by the first query but not by the second.
- **UNION** – returns all distinct rows selected by either query
- **UNION ALL** – returns all rows selected by either query, including all duplicates.
- **INTERSECT** – returns all distinct rows selected by both queries.

---
**Q #69) What is a transaction?**
---

**Answer:** A transaction is a sequence of code that runs against a database. It takes the database from one consistent state to another.

---
**Q #70) What is the difference between UNIQUE and PRIMARY KEY constraints?**
---

**Answer: The differences are as follows:**

- A table can have only one PRIMARY KEY whereas there can be any number of UNIQUE keys.
- The primary key cannot contain Null values whereas the Unique key can contain Null values.

---
**Q #71) What is a composite primary key?**
---

**Answer:** The primary key created on more than one column is called the composite primary key.

---
**Q #72) What is an Index?**
---

**Answer:** An Index is a special structure associated with a table to speed up the performance of queries. The index can be created on one or more columns of a table.

---
**Q #73) What is the Subquery?**
---

**Answer:** A Subquery is a subset of select statements whose return values are used in filtering conditions of the main query.

---
**Q #74) What do you mean by query optimization?**
---

**Answer:** Query optimization is a process in which a database system compares different query strategies and selects the query with the least cost.

---
**Q #75) What is Collation?**
---

**Answer:** Set of rules that define how data is stored, how case sensitivity and Kana character can be treated etc.

---
**Q #76) What is Referential Integrity?**
---

**Answer:** Set of rules that restrict the values of one or more columns of the tables based on the values of the primary key or unique key of the referenced table.

---
**Q #77) What is the Case function?**
---

**Answer:** Case facilitates the if-then-else type of logic in SQL. It evaluates a list of conditions and returns one of the multiple possible result expressions.

---
**Q #78) Define a temp table.**
---

**Answer:** A temp table is a temporary storage structure to store the data temporarily.

---
**Q #79) How can we avoid duplicating records in a query?**
---

**Answer:** By using the DISTINCT keyword, duplication of records in a query can be avoided.

---
**Q #80) Explain the difference between Rename and Alias.**
---

**Answer:** Rename is a permanent name given to a table or column whereas Alias is a temporary name given to a table or column.

---
**Q #81) What is a View?**
---

**Answer:** A view is a virtual table that contains data from one or more tables. Views restrict data access to the table by selecting only required values and making complex queries easy.

---
**Q #82) What are the advantages of Views?**
---

**Answer: Advantages of Views are:**

- Views restrict access to the data because the view can display selective columns from the table.
- Views can be used to make simple queries to retrieve the results of complicated queries. **For Example,** views can be used to query information from multiple tables without the user knowing.

---
**Q #83) List the various privileges that a user can grant to another user.**
---

**Answer:**  SELECT, CONNECT, RESOURCES.

---
**Q #84) What is schema?**
---

**Answer:** A schema is a collection of database objects of a User.

---
**Q #85) What is a Table?**
---

**Answer:** A table is the basic unit of data storage in the database management system. Table data is stored in rows and columns.

---
**Q #86) Does View contain Data?**
---

**Answer:** No, Views are virtual structures.

---
**Q #87) Can a View be based on another View?**
---

**Answer:** Yes, A View is based on another View.

---
**Q #88) What is the difference between the HAVING clause and WHERE clause?**
---

**Answer:** Both specify a search condition but the Having clause is used only with the SELECT statement and typically used with the GROUP BY clause.  
If the GROUP BY clause is not used then Having behaved like the WHERE clause only.

---
**Q #89) What is the difference between Local and Global temporary tables?**
---

**Answer:** If defined inside a compound statement a local temporary table exists only for the duration of that statement but a global temporary table exists permanently in the DB but its rows disappear when the connection is closed.

---
**Q #90) What is CTE?**
---

**Answer:** A CTE or common table expression is an expression that contains a temporary result set which is defined in a SQL statement.