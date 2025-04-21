using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace RiraCrud
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            #region First
            Console.WriteLine("RIRA CRUD:");

            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "DESKTOP-686S5E7\\SQLTEST",
                UserID = "sa",
                Password = "sqltest111",
                InitialCatalog = "TEST"
            };

            var connectionString = builder.ConnectionString;

            await using var fconnection = new SqlConnection(connectionString);
            await fconnection.OpenAsync();
            var fsql = "SELECT * FROM RiraCrud";
            await using var fcommand = new SqlCommand(fsql, fconnection);
            await using var reader = await fcommand.ExecuteReaderAsync();
            Console.WriteLine("\n SELECT * FROM RiraCrud");
            Console.WriteLine("=========================================");
            while (await reader.ReadAsync())
            {
                //Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                Console.WriteLine("{0} {1} {2} {3} {4}",
                    reader.GetInt16(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetString(4)
                    );
            }
            await fconnection.CloseAsync();
            #endregion


            try
            {
                await using var connection = new SqlConnection(connectionString);
                Console.WriteLine("=========================================\n");

                await connection.OpenAsync();


                //var sql = "SELECT name, collation_name FROM sys.databases";
                var sql = "SELECT * FROM RiraCrud";
                await using var command = new SqlCommand(sql, connection);
                


                {
                    string operation;

                    Console.WriteLine("Type -> 1 for Create" +
                                      "\nType -> 2 for Read" +
                                      "\nType -> 3 for Update" +
                                      "\nType -> 4 for Delete"
                        );
                    operation =Console.ReadKey(true).KeyChar.ToString();
                    Console.WriteLine($"operation= {operation}");



                        #region Insert 
                    if (operation == "1")
                    {
                        var insertName = "NULL";
                        var insertLastName = "NULL";
                        var insertCode = "NULL";
                        var insertBirthDate = "NULL";

                        Console.Write($"\nType \"Name\" to Insert: ");
                        insertName = Console.ReadLine().ToString();
                        Console.Write($"\nType \"LastName\" to Insert: ");
                        insertLastName = Console.ReadLine().ToString();
                        Console.Write($"\nType \"Code\" to Insert: ");
                        insertCode = Console.ReadLine().ToString();
                        Console.Write($"\nType \"BirthDate\" to Insert: ");
                        insertBirthDate = Console.ReadLine().ToString();
                        Console.WriteLine($"\nName: {insertName}, LastName: {insertLastName}, Code: {insertCode}, BirthDate: {insertBirthDate}  ");

                        var sqlInsert = "INSERT INTO RiraCrud " +
                                        $"(Name, LastName, Code, BirthDate) VALUES('{insertName}', '{insertLastName}', '{insertCode}', '{insertBirthDate}')";
                        await using var insert = new SqlCommand(sqlInsert, connection);
                        var recordsAffectedInsert = insert.ExecuteNonQuery();
                    }
                        #endregion

                        #region Read
                    if(operation == "2")
                    {
                        int idToRead;
                        Console.WriteLine("Type ID to Read: ");
                        idToRead = Int32.Parse(Console.ReadLine());
                        var sqlRead = $"SELECT * FROM RiraCrud WHERE ID={idToRead}";
                        await using var commandToRead = new SqlCommand(sqlRead, connection);
                        await using var readerRead = await commandToRead.ExecuteReaderAsync();
                        Console.Clear();
                        while (await readerRead.ReadAsync())
                        {
                            Console.Write($"\n ID {idToRead}: ");
                            Console.Write(
                                "{0} {1} {2} {3} {4}",
                                readerRead.GetInt16(0),
                                readerRead.GetString(1),
                                readerRead.GetString(2),
                                readerRead.GetString(3),
                                readerRead.GetString(4)
                                );
                        }
                    }
                        #endregion

                        #region Update
                    if (operation == "3")
                    {

                        string updateOperation;
                        Console.WriteLine("Type -> 1 for Name" +
                                      "\nType -> 2 for LastName" +
                                      "\nType -> 3 for Code" +
                                      "\nType -> 4 for BirthDate"
                        );
                        updateOperation = Console.ReadKey(true).KeyChar.ToString();
                        if (updateOperation == "1")
                        {
                            string nameSelected;
                            string nameToChange;
                            Console.Write("Type the Name you Want to change: ");
                            nameSelected=Console.ReadLine().ToString();
                            Console.Write("Type Your replacement: ");
                            nameToChange = Console.ReadLine().ToString();
                            var sqlUpdateName = "UPDATE RiraCrud " +
                                $"SET Name='{nameToChange}'" +
                                $"WHERE Name='{nameSelected}'";
                            await using var commandUpdateName = new SqlCommand(sqlUpdateName, connection);
                            var recordsAffectedInsert = commandUpdateName.ExecuteNonQuery();
                        }
                        if (updateOperation == "2")
                        {
                            string lastNameSelected;
                            string lastNameToChange;
                            Console.Write("Type the LastName you Want to change: ");
                            lastNameSelected = Console.ReadLine().ToString();
                            Console.Write("Type Your replacement: ");
                            lastNameToChange = Console.ReadLine().ToString();
                            var sqlUpdateLastName = "UPDATE RiraCrud " +
                                $"SET LastName='{lastNameToChange}'" +
                                $"WHERE LastName='{lastNameSelected}'";
                            await using var commandUpdateLastName = new SqlCommand(sqlUpdateLastName, connection);
                            var recordsAffectedInsert = commandUpdateLastName.ExecuteNonQuery();
                        }
                        if (updateOperation == "3")
                        {
                            string codeSelected;
                            string codeToChange;
                            Console.Write("Type the Name you Want to change: ");
                            codeSelected = Console.ReadLine().ToString();
                            Console.Write("Type Your replacement: ");
                            codeToChange = Console.ReadLine().ToString();
                            var sqlUpdateCode = "UPDATE RiraCrud " +
                                $"SET Code='{codeToChange}'" +
                                $"WHERE Code='{codeSelected}'";
                            await using var commandUpdateCode = new SqlCommand(sqlUpdateCode, connection);
                            var recordsAffectedInsert = commandUpdateCode.ExecuteNonQuery();
                        }
                        if (updateOperation == "4")
                        {
                            string birthDateSelected;
                            string birthDateToChange;
                            Console.Write("Type the Name you Want to change: ");
                            birthDateSelected = Console.ReadLine().ToString();
                            Console.Write("Type Your replacement: ");
                            birthDateToChange = Console.ReadLine().ToString();
                            var sqlUpdateBirthDate = "UPDATE RiraCrud " +
                                $"SET BirthDate='{birthDateToChange}'" +
                                $"WHERE BirthDate='{birthDateSelected}'";
                            await using var commandUpdateBirthDate = new SqlCommand(sqlUpdateBirthDate, connection);
                            var recordsAffectedInsert = commandUpdateBirthDate.ExecuteNonQuery();
                        }
                    }
                        #endregion

                        #region Delete
                    if(operation== "4")
                    {
                        int idToDelete;
                        Console.Write("Type the ID you Want to Delete: ");
                        idToDelete = Int32.Parse(Console.ReadLine());
                        var sqlDelete = $"DELETE FROM RiraCrud WHERE ID={idToDelete}";
                        await using var commandToDelete = new SqlCommand(sqlDelete, connection);
                        var recordsAffectedInsert = commandToDelete.ExecuteNonQuery();
                        Console.WriteLine("---->DELETE COMPLETED<----");

                    }
                        #endregion

                }

                await using var reader2 = await command.ExecuteReaderAsync();
                Console.WriteLine("\n\n======================FINAL=====================\n");
                while (await reader2.ReadAsync())
                {
                    //Console.WriteLine("{0} {1}", reader.GetString(0), reader.GetString(1));
                    Console.WriteLine("{0} {1} {2} {3} {4}",
                        reader2.GetInt16(0),
                        reader2.GetString(1),
                        reader2.GetString(2),
                        reader2.GetString(3),
                        reader2.GetString(4)
                        );
                }
            }
            catch (SqlException e) when (e.Number == 1)
            {
                Console.WriteLine($"SQL Error: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nDone. Press enter.");


            





            Console.ReadKey();
        }
    }
}
