using FlatFile.FixedLength.Implementation;
using FlatFile.Delimited.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using FlatFile.Core;
using FlatFile.FixedLength;
using FlatFile.FixedLength.Attributes;
using System.Text;
using System.Linq;

namespace Test
{
   
    class Program
    {
        static void Main(string[] args)
        {
            IFlatFileEngineFactory<ILayoutDescriptor<IFixedFieldSettingsContainer>, IFixedFieldSettingsContainer> fileEngineFactory;
            var sampleRecords = GetRecords();

            var ctxBrRecords = GetCtxBrRecords();
            //var factory = new FixedLengthFileEngineFactory();
            //using (var stream = new MemoryStream())
            //using (TextWriter writer = new StreamWriter(stream))
            //{
            //    //writer.WriteLine("header here..");
            //   // writer.Flush();
            //    fileEngineFactory = new FixedLengthFileEngineFactory();
            //    var flatFileEngine = fileEngineFactory.GetEngine<SampleRecord>();

            //    flatFileEngine.Write<SampleRecord>(writer, sampleRecords);

            //    var fileStream = new FileStream(@"C:\Repos\Medway\FlatFile\src\Test\file2.txt", FileMode.Create, FileAccess.Write);
            //    stream.WriteTo(fileStream);
            //    //writer.Write()

            //    var records = flatFileEngine.Read<SampleRecord>(stream).ToArray();
            //}

           // using (var stream = new MemoryStream())
            using (TextWriter writer = new StreamWriter(@"C:\Repos\Medway\FlatFile\src\Test\file6.txt"))
            {
                //C_CTFX_260815_062132
                writer.WriteLine("C_CTFX_260815_062132".PadRight(151,' '));
                //writer.Flush();


                fileEngineFactory = new FixedLengthFileEngineFactory();
                var flatFileEngine = fileEngineFactory.GetEngine<CtxBrRecord>();

                flatFileEngine.Write<CtxBrRecord>(writer, ctxBrRecords);

                //var fileStream = new FileStream(@"C:\Repos\Medway\FlatFile\src\Test\file2.txt", FileMode.Create, FileAccess.Write);
                //stream.WriteTo(fileStream);
                //writer.Write()

                //var records = flatFileEngine.Read<SampleRecord>(stream).ToArray();
            }

            //string[] lines = { "First line", "Second line", "Third line" };
            //// WriteAllLines creates a file, writes a collection of strings to the file,
            //// and then closes the file.  You do NOT need to call Flush() or Close().
            //File.WriteAllLines(@"C:\testfile.txt", lines);

            //string[] readlines = System.IO.File.ReadAllLines(@"C:\testfile.txt");
            //string text = System.IO.File.ReadAllText(@"C:\Repos\Medway\FlatFile\src\Test\file5.txt");


            //using (StreamWriter file = new StreamWriter(@"C:\testfile1.txt"))
            //{
            //    foreach (string line in lines)
            //    {
            //        // If the line doesn't contain the word 'Second', write the line to the file.
            //        if (!line.Contains("Second"))
            //        {
            //            file.WriteLine(line);
            //        }
            //    }
            //}

            //string text1= File.ReadAllText(@"C:\testfile1.txt");

            Console.ReadLine();


        }

        private static  List<CtxBrRecord> GetCtxBrRecords()
        {
            List<CtxBrRecord> list = new List<CtxBrRecord>();
            //2000433192     2  51-0000000075.420126-AUG-2015                    SJ102936/SJ1      SJ1                                SJ102936/SJ1                  
            CtxBrRecord rec = new CtxBrRecord();
            rec.AccountNo = "2000433192";
            rec.AccountCheckDigit = "2";
            rec.ReceivingMethod = 67;
            rec.Amount = -0000000075.42;
            rec.FundReference = "01";
            rec.DateReceivedAtSource = DateTime.Parse("26 Aug 2015");
            rec.UniqueSourceSystemReference = "SJ102936/SJ1";
            rec.SourceSystemCode = "SJ1";
            rec.OriginatorsReference = rec.UniqueSourceSystemReference;
            list.Add(rec);

            return list;

            
        }

        public static List<SampleRecord> GetRecords()
        {
            List<SampleRecord> list = new List<SampleRecord>();

            list.Add(new SampleRecord { Id = 2111111, Description = "this is 1", NullableInt = 100 });
            list.Add(new SampleRecord { Id = 2, Description = "this is 2" });

            return list;


        }
    }
}
