using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;

namespace PreparationParser
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //string prepDescription = @"Preparation:
            //Watch this video ""Make Architecture Matter"" with Martin Fowler: Link to Video on YouTube.

            //    Read the short article by Martin Fowler which is referenced in the video.
            //    Link: http://martinfowler.com/ieeeSoftware/whoNeedsArchitect.pdf

            //We will use .NET Application Architecture Guide, 2nd Edition as an introduction, it can be downloaded from here.

            //    Read chapter 1, 2 and 3 (only p. 19-21) and chapter 4 of .Net Application Architecture Guide (See reading guide below).
            //";

            
            //var prepParser = new PreparationTextParser();

            //var matches = prepParser.ParseText(prepDescription);

            //Console.WriteLine("Parse SWD prep description example:");
            //Console.WriteLine("found number of matches: " + matches.Count.ToString());
            //Console.WriteLine("Found the following matches:");
            //foreach (var match in matches)
            //{
            //    Console.WriteLine("-------------------------------------------------------");
            //    Console.WriteLine(match);
            //}
            //Console.WriteLine("\n\n");


            

            //string DABprepText =
            //    "Week 4 | DML P2 (Advanced SQL statements)\r\nWeek 4 | DML P2 (Advanced SQL statements)\r\nThis week. Intro, topic, preparation :\r\nNote. In this intro links are given to Microsoft Transact-SQL. A more compact and easy to read documentation is found in Readings where the  Database eLearning (grussell.org) site is used.\r\n\r\nA RDBMS (Relational Database Management System aka Relational Database Server RDB) is designed for handling persistence of data in a structured way. That is, instead of just reading and writing chunks of bytes to the filesystem, the RDB lets us use the Structured Query Language branch SQL DML , an entity and tabel bases approach, to \r\n\r\nFind data using queries having statements like SELECT * FROM...\r\nCreate, update and delete data using queries having statement likes INSERT.. , UPDATE.. and DELETE...\r\nBut one more important thing is, that the RDB uses a schema (our logical schema) to ensure:\r\n\r\nthat data persisted in the database are in a correct format. We are talking strings, integers etc.\r\nthat data that belongs together are hold together and no necessary data are missing. We are talking entities and tabels.\r\nthat data is related/associated in a consistent to the real world way. We call this function \"ensuring referential integrity\",  which also is used to ensure less redundant data. We are talking Relationships anCASE (Transact-SQL) - SQL Server | Microsoft Docs d Normalization. Normalization and normal forms are topics in Lesson 5.\r\nAnd the RDB provides even more data handling, like being able to organise and/or sorting data sent back to the clients, in a way that the client will be able just to use data without further extensive processing. A RDB provides tones of functionality when it goes for data processing.\r\n\r\nThe price we have to pay, is a huge SQL language that we need to learn, if we want to use an RDB with all its possibilities.\r\n\r\nMicrosoft Transact-SQL Over all Link: Transact-SQL statements - SQL Server | Microsoft Docs (to be skimmed)  \r\nOf course we do not need to spent our whole life with SQL DML and DDL. Less is more, and this is what this lesson goes for. Presenting the most important topics for querying a RDB in SQL DML.\r\n\r\nMain topics SQL DML P2 with links to further description for MS Transact-SQL  (links to be skimmed):\r\nSELECT Link: SELECT (Transact-SQL) - SQL Server | Microsoft Docs \r\nORDER BY (Sorting entities) Link: ORDER BY Clause (Transact-SQL) - SQL Server | Microsoft Docs \r\nGROUP BY (Grouping entities). Link: GROUP BY (Transact-SQL) - SQL Server | Microsoft Docs \r\nCASE (switching) \r\nLink: CASE (Transact-SQL) - SQL Server | Microsoft Docs \r\nAggregates (Use of functions in result set)\r\nLink: Aggregate Functions (Transact-SQL) - SQL Server | Microsoft Docs \r\nSubqueries (Nesting queries )\r\nLink: Subqueries (SQL Server) - SQL Server | Microsoft Docs \r\nTransactions (Consistent CRUD operations) Briefly touched in this lesson.\r\nLink: Transactions (Transact-SQL) - SQL Server | Microsoft Docs \r\nJOIN (Reunite data that has been separated) Continued i Lesson 5\r\nLink: Joins (SQL Server) - SQL Server | Microsoft Docs \r\nCreate VIEW (Stored SELECT Queries on the RDB ie. Virtual Table) Topic in Lesson 5\r\nLink: CREATE VIEW (Transact-SQL) - SQL Server | Microsoft Docs \r\nComment on Relational Algebra (RA)\r\nAn important aspect to notice, when using SQL, is that the language uses operators as SQL is a \"relationally complete\" language.  Take a look in Lectures Handouts under \"SQL and Relational Algebra\"\r\n\r\nNote before reading. Using a Relational Database Management System (RDBMS) is one of the old disciplines in SW-Development. Tons of online ressources can be found about this topic. \r\n\r\nG. Russels Database eLaerning is a comprehensive but easily read source to learn SQL, RDBMS and database analysis. (Attached SQL Schema and data for setting up the example database used by Russell)  RusselExampleDBSchemaData.sql\r\n\r\n\r\n\r\nPreparation:\r\n\"Database eLearning\" Link:  Database eLearning (grussell.org)\r\n\r\n  Chapter 3. SQL  following parts\r\nSimple SELECT statements\r\nLogical Operators and Aggregation\r\nSubqueries and Schema\r\nJOINs and VIEWs (grussell.org) Continued in Lesson 5\r\nChapter 6 - Implementations. Transactions is one of the must \"Mysterious\" topics in databases, even though it is not???? Take an overview, brief , of the following two parts\r\nConcurrency using Transactions Espcially the ACID conecpt and the two Scenarios \"Lost Update\" and \"Uncommited Dependcy/Dirty Read\"\r\nConcurrency Get an idea  about  Locks and Dead Locks.\r\nSe videos\r\nSELECT with JOIN Operator\r\n\r\n\r\nWhat is a Transaction on a RDB\r\n\r\n\r\nOptional viewing: Advanced use of SQL Server Management Studio for designing SELECT with JOIN\r\n\r\n";
            //var watch = new System.Diagnostics.Stopwatch();
            
            //watch.Start();
            //var prepItems = prepParser.ParseText(DABprepText);
            //watch.Stop();
            //Console.WriteLine("Parse 4 page long DAB prep description from week 4:");
            //Console.WriteLine("found number of matches: " + matches.Count.ToString());
            //Console.WriteLine("Found the following matches:");
            //Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            //foreach (var prepItem in prepItems)
            //{
            //    Console.WriteLine("=======================================================");
            //    Console.WriteLine(prepItem);
            //}

            string RawToC =
                @"""{\""Modules\"":[{\""ModuleId\"":19712,\""Title\"":\""Apiuser test\"",\""Modules\"":[],\""Topics\"":[],\""LastModifiedDate\"":\""2021-11-11T11:15:53.570Z\"",\""Description\"":{\""Text\"":\""Preparation:\\nWatch this video \\\""Make Architecture Matter\\\"" with Martin Fowler: Link to Video on YouTube.\\n \\nRead the short article by Martin Fowler which is referenced in the video.\\nLink: http://martinfowler.com/ieeeSoftware/whoNeedsArchitect.pdf\\n \\nWe will use .NET Application Architecture Guide, 2nd Edition as an introduction, it can be downloaded from here.\\n \\nRead chapter 1, 2 and 3 (only p. 19-21) and chapter 4 of .Net Application Architecture Guide (See reading guide below).\\n \"",\""Html\"":\""<p dir=\\\""ltr\\\"">Preparation:</p>\\n<p dir=\\\""ltr\\\"">Watch this video &quot;Make Architecture Matter&quot; with Martin Fowler: <a rel=\\\""noopener\\\"" href=\\\""https://youtu.be/DngAZyWMGR0\\\"">Link to Video on YouTube.</a></p>\\n<p><strong>&#160;</strong></p>\\n<p dir=\\\""ltr\\\"">Read the short article by Martin Fowler which is referenced in the video.</p>\\n<p dir=\\\""ltr\\\"">Link: <a rel=\\\""noopener\\\"" href=\\\""http://martinfowler.com/ieeeSoftware/whoNeedsArchitect.pdf\\\"">http://martinfowler.com/ieeeSoftware/whoNeedsArchitect.pdf</a></p>\\n<p><strong>&#160;</strong></p>\\n<p dir=\\\""ltr\\\"">We will use .NET Application Architecture Guide, 2nd Edition as an introduction, it can be downloaded from here.</p>\\n<p><strong>&#160;</strong></p>\\n<p dir=\\\""ltr\\\"">Read chapter 1, 2 and 3 (only p. 19-21) and chapter 4 of .Net Application Architecture Guide (See reading guide below).</p>\\n<p><strong>&#160;</strong></p>\""}},{\""ModuleId\"":19714,\""Title\"":\""Module2\"",\""Modules\"":[],\""Topics\"":[],\""LastModifiedDate\"":\""2021-11-17T12:18:25.333Z\"",\""Description\"":{\""Text\"":\""Preparation\\nRead the rest of chapter 3 of the Microsoft Application Architecture Guide, p. 21-35.\\nFinish the exercise from last time, and prepare/execute the next steps in VideoFlix exercise, as described at the last lecture.\\nOptional background material about Architecting\\nOptional: Watch this video presentation by Simon Brown: The Frustrated Architect (tip: you can select the video in 1.5x speed above the embedded view if you want to, it is quite long!) The slides are attached here:\\nSimonBrown-TheFrustratedArchitect-slides.pdf\"",\""Html\"":\""<h3>Preparation</h3>\\n<p>Read the rest of chapter 3 of the Microsoft Application Architecture Guide, p. 21-35.</p>\\n<p>Finish the exercise from last time, and prepare/execute the next steps in VideoFlix exercise, as described at the last lecture.</p>\\n<h3>Optional background material about Architecting</h3>\\n<p>Optional: Watch this video presentation by Simon Brown:&#160;<a rel=\\\""noopener\\\"" href=\\\""https://www.infoq.com/presentations/The-Frustrated-Architect\\\"" target=\\\""_blank\\\"">The Frustrated Architect</a>&#160;(tip: you can select the video in 1.5x speed above the embedded view if you want to, it is quite long!) The slides are attached here:</p>\\n<p><a rel=\\\""noopener\\\"" href=\\\""https://brightspace.au.dk//content/enforced/27083-LR2597/csfiles/home_dir/SimonBrown-TheFrustratedArchitect-slides.pdf?_&amp;d2lSessionVal=9JuJiCQdrrwKs25jQ5zPcfidC&amp;ou=27083\\\"" target=\\\""_blank\\\"">SimonBrown-TheFrustratedArchitect-slides.pdf</a></p>\""}}]}""";

            var parser = new PreparationTextParser();


            string rawtoc2 =
                @"{""Modules"":[{""ModuleId"":19712,""Title"":""Week 4.1 | Software architecture - Getting Started"",""Modules"":[],""Topics"":[],""LastModifiedDate"":""2021-11-17T14:45:45.783Z"",""Description"":{""Text"":""This week and the next:\nThe next two weeks we will look at Software architecture.\nThe main subjects are:\n- What is software architecture?\n- The process of developing a software architecture.\n- How to document software architecture.\nPreparation:\nWatch this video \""Make Architecture Matter\"" with Martin Fowler: Link to Video on YouTube.\nRead the short article by Martin Fowler which is referenced in the video.Link: http://martinfowler.com/ieeeSoftware/whoNeedsArchitect.pdf\nWe will use .NET Application Architecture Guide, 2nd Edition as an introduction, it can be downloaded from here.\nRead chapter 1, 2 and 3 (only p. 19-21) and chapter 4 of .Net Application Architecture Guide (See reading guide below)."",""Html"":""<h2>This week and the next:</h2>\n<p>The&#160;next two weeks&#160;we will look at Software architecture.</p>\n<p>The main subjects are:</p>\n<p>- What is software architecture?</p>\n<p>- The process of developing a software architecture.</p>\n<p>- How to document software architecture.</p>\n<h2>Preparation:</h2>\n<p>Watch this video &quot;Make Architecture Matter&quot; with Martin Fowler:&#160;<a rel=\""noopener\"" target=\""_blank\"" href=\""https://www.youtube.com/watch?v=DngAZyWMGR0\"">Link</a>&#160;to Video on YouTube.</p>\n<p>Read the short article by Martin Fowler which is referenced in the video.<br/>Link:&#160;<a rel=\""noopener\"" target=\""_blank\"" href=\""http://martinfowler.com/ieeeSoftware/whoNeedsArchitect.pdf\"">http://martinfowler.com/ieeeSoftware/whoNeedsArchitect.pdf</a></p>\n<p>We will use&#160;<strong>.NET&#160;Application Architecture Guide, 2nd Edition</strong>&#160;as an introduction, it can be downloaded from&#160;<a rel=\""noopener\"" target=\""_blank\"" href=\""https://brightspace.au.dk/d2l/common/dialogs/quickLink/quickLink.d2l?ou=27083&amp;type=coursefile&amp;fileId=csfiles%2fhome_dir%2fApplication_Architecture_Guide_v2.pdf\"">here</a>.</p>\n<p>Read chapter 1, 2 and 3 (only p. 19-21) and chapter 4 of .Net Application Architecture Guide (See reading guide below).</p>""}},{""ModuleId"":19714,""Title"":""Week 4.2 | Software Architecture - The tool box"",""Modules"":[],""Topics"":[],""LastModifiedDate"":""2021-11-17T14:46:02.827Z"",""Description"":{""Text"":""Preparation\nRead the rest of chapter 3 of the Microsoft Application Architecture Guide, p. 21-35.\nFinish the exercise from last time, and prepare/execute the next steps in VideoFlix exercise, as described at the last lecture.\nOptional background material about Architecting\nOptional: Watch this video presentation by Simon Brown: The Frustrated Architect (tip: you can select the video in 1.5x speed above the embedded view if you want to, it is quite long!) The slides are attached here:\nSimonBrown-TheFrustratedArchitect-slides.pdf"",""Html"":""<h3>Preparation</h3>\n<p>Read the rest of chapter 3 of the Microsoft Application Architecture Guide, p. 21-35.</p>\n<p>Finish the exercise from last time, and prepare/execute the next steps in VideoFlix exercise, as described at the last lecture.</p>\n<h3>Optional background material about Architecting</h3>\n<p>Optional: Watch this video presentation by Simon Brown:&#160;<a rel=\""noopener\"" href=\""https://www.infoq.com/presentations/The-Frustrated-Architect\"" target=\""_blank\"">The Frustrated Architect</a>&#160;(tip: you can select the video in 1.5x speed above the embedded view if you want to, it is quite long!) The slides are attached here:</p>\n<p><a rel=\""noopener\"" href=\""https://brightspace.au.dk//content/enforced/27083-LR2597/csfiles/home_dir/SimonBrown-TheFrustratedArchitect-slides.pdf?_&amp;d2lSessionVal=9JuJiCQdrrwKs25jQ5zPcfidC&amp;ou=27083\"" target=\""_blank\"">SimonBrown-TheFrustratedArchitect-slides.pdf</a></p>""}}]}";


            Dictionary<int, List<string>> LecturesWithItems = parser.ParseModuleTableOfContents(rawtoc2);

            foreach (var VARIABLE in LecturesWithItems)
            {
                foreach (var item in VARIABLE.Value)
                {
                    Console.WriteLine("-----item:      ");
                    Console.WriteLine(item);
                }
            }



        }
    }
}
