using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace PreparationParser
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string prepDescription = @"Preparation:
            Watch this video ""Make Architecture Matter"" with Martin Fowler: Link to Video on YouTube.

                Read the short article by Martin Fowler which is referenced in the video.
                Link: http://martinfowler.com/ieeeSoftware/whoNeedsArchitect.pdf

            We will use .NET Application Architecture Guide, 2nd Edition as an introduction, it can be downloaded from here.

                Read chapter 1, 2 and 3 (only p. 19-21) and chapter 4 of .Net Application Architecture Guide (See reading guide below).
            ";

            
            var prepParser = new PreparationTextParser();

            var matches = prepParser.ParseText(prepDescription);

            Console.WriteLine("Parse SWD prep description example:");
            Console.WriteLine("found number of matches: " + matches.Count.ToString());
            Console.WriteLine("Found the following matches:");
            foreach (var match in matches)
            {
                Console.WriteLine("-------------------------------------------------------");
                Console.WriteLine(match);
            }
            Console.WriteLine("\n\n");


            

            string DABprepText =
                "Week 4 | DML P2 (Advanced SQL statements)\r\nWeek 4 | DML P2 (Advanced SQL statements)\r\nThis week. Intro, topic, preparation :\r\nNote. In this intro links are given to Microsoft Transact-SQL. A more compact and easy to read documentation is found in Readings where the  Database eLearning (grussell.org) site is used.\r\n\r\nA RDBMS (Relational Database Management System aka Relational Database Server RDB) is designed for handling persistence of data in a structured way. That is, instead of just reading and writing chunks of bytes to the filesystem, the RDB lets us use the Structured Query Language branch SQL DML , an entity and tabel bases approach, to \r\n\r\nFind data using queries having statements like SELECT * FROM...\r\nCreate, update and delete data using queries having statement likes INSERT.. , UPDATE.. and DELETE...\r\nBut one more important thing is, that the RDB uses a schema (our logical schema) to ensure:\r\n\r\nthat data persisted in the database are in a correct format. We are talking strings, integers etc.\r\nthat data that belongs together are hold together and no necessary data are missing. We are talking entities and tabels.\r\nthat data is related/associated in a consistent to the real world way. We call this function \"ensuring referential integrity\",  which also is used to ensure less redundant data. We are talking Relationships anCASE (Transact-SQL) - SQL Server | Microsoft Docs d Normalization. Normalization and normal forms are topics in Lesson 5.\r\nAnd the RDB provides even more data handling, like being able to organise and/or sorting data sent back to the clients, in a way that the client will be able just to use data without further extensive processing. A RDB provides tones of functionality when it goes for data processing.\r\n\r\nThe price we have to pay, is a huge SQL language that we need to learn, if we want to use an RDB with all its possibilities.\r\n\r\nMicrosoft Transact-SQL Over all Link: Transact-SQL statements - SQL Server | Microsoft Docs (to be skimmed)  \r\nOf course we do not need to spent our whole life with SQL DML and DDL. Less is more, and this is what this lesson goes for. Presenting the most important topics for querying a RDB in SQL DML.\r\n\r\nMain topics SQL DML P2 with links to further description for MS Transact-SQL  (links to be skimmed):\r\nSELECT Link: SELECT (Transact-SQL) - SQL Server | Microsoft Docs \r\nORDER BY (Sorting entities) Link: ORDER BY Clause (Transact-SQL) - SQL Server | Microsoft Docs \r\nGROUP BY (Grouping entities). Link: GROUP BY (Transact-SQL) - SQL Server | Microsoft Docs \r\nCASE (switching) \r\nLink: CASE (Transact-SQL) - SQL Server | Microsoft Docs \r\nAggregates (Use of functions in result set)\r\nLink: Aggregate Functions (Transact-SQL) - SQL Server | Microsoft Docs \r\nSubqueries (Nesting queries )\r\nLink: Subqueries (SQL Server) - SQL Server | Microsoft Docs \r\nTransactions (Consistent CRUD operations) Briefly touched in this lesson.\r\nLink: Transactions (Transact-SQL) - SQL Server | Microsoft Docs \r\nJOIN (Reunite data that has been separated) Continued i Lesson 5\r\nLink: Joins (SQL Server) - SQL Server | Microsoft Docs \r\nCreate VIEW (Stored SELECT Queries on the RDB ie. Virtual Table) Topic in Lesson 5\r\nLink: CREATE VIEW (Transact-SQL) - SQL Server | Microsoft Docs \r\nComment on Relational Algebra (RA)\r\nAn important aspect to notice, when using SQL, is that the language uses operators as SQL is a \"relationally complete\" language.  Take a look in Lectures Handouts under \"SQL and Relational Algebra\"\r\n\r\nNote before reading. Using a Relational Database Management System (RDBMS) is one of the old disciplines in SW-Development. Tons of online ressources can be found about this topic. \r\n\r\nG. Russels Database eLaerning is a comprehensive but easily read source to learn SQL, RDBMS and database analysis. (Attached SQL Schema and data for setting up the example database used by Russell)  RusselExampleDBSchemaData.sql\r\n\r\n\r\n\r\nPreparation:\r\n\"Database eLearning\" Link:  Database eLearning (grussell.org)\r\n\r\n  Chapter 3. SQL  following parts\r\nSimple SELECT statements\r\nLogical Operators and Aggregation\r\nSubqueries and Schema\r\nJOINs and VIEWs (grussell.org) Continued in Lesson 5\r\nChapter 6 - Implementations. Transactions is one of the must \"Mysterious\" topics in databases, even though it is not???? Take an overview, brief , of the following two parts\r\nConcurrency using Transactions Espcially the ACID conecpt and the two Scenarios \"Lost Update\" and \"Uncommited Dependcy/Dirty Read\"\r\nConcurrency Get an idea  about  Locks and Dead Locks.\r\nSe videos\r\nSELECT with JOIN Operator\r\n\r\n\r\nWhat is a Transaction on a RDB\r\n\r\n\r\nOptional viewing: Advanced use of SQL Server Management Studio for designing SELECT with JOIN\r\n\r\n";
            var watch = new System.Diagnostics.Stopwatch();
            
            watch.Start();
            var prepItems = prepParser.ParseText(DABprepText);
            watch.Stop();
            Console.WriteLine("Parse 4 page long DAB prep description from week 4:");
            Console.WriteLine("found number of matches: " + matches.Count.ToString());
            Console.WriteLine("Found the following matches:");
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            foreach (var prepItem in prepItems)
            {
                Console.WriteLine("=======================================================");
                Console.WriteLine(prepItem);
            }
            
        }
    }
}
