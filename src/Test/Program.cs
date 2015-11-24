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
using Test.Models.iWorld.CtxBr;
using Test.Models.Integra;

namespace Test
{
   
    class Program
    {
        static void Main(string[] args)
        {
            //WriteiWorldFile();
            WriteIntegraFile();

            Console.ReadLine();


        }

        public static void WriteiWorldFile()
        {
            IFlatFileEngineFactory<ILayoutDescriptor<IFixedFieldSettingsContainer>, IFixedFieldSettingsContainer> fileEngineFactory;

            var ctxBrRecords = GetCtxBrRecords();
            string fileName = @"C:\Repos\Medway\FlatFile\src\Test\iWorld1.txt";
            using (TextWriter writer = new StreamWriter(fileName))
            {
                //C_CTFX_260815_062132
                writer.WriteLine("C_CTFX_260815_062132".PadRight(151, ' '));
                //writer.Flush();

                fileEngineFactory = new FixedLengthFileEngineFactory();
                var flatFileEngine = fileEngineFactory.GetEngine<CtxBrRecord>();

                flatFileEngine.Write<CtxBrRecord>(writer, ctxBrRecords);


            }

            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                fileEngineFactory = new FixedLengthFileEngineFactory();
                var flatFileEngine1 = fileEngineFactory.GetEngine<CtxBrRecord>(hasHeader: true);

                var records = flatFileEngine1.Read<CtxBrRecord>(fileStream).ToArray();
            }

        }

        public static void WriteIntegraFile()
        {
            IFlatFileEngineFactory<ILayoutDescriptor<IFixedFieldSettingsContainer>, IFixedFieldSettingsContainer> fileEngineFactory;

            var records = GetTotalsRecords();
            string fileName = @"C:\Repos\Medway\FlatFile\src\Test\Integra.txt";

            using (TextWriter writer = new StreamWriter(fileName))
            {

                fileEngineFactory = new FixedLengthFileEngineFactory();
                var flatFileEngine = fileEngineFactory.GetEngine<FundTotalRecord>();

                flatFileEngine.Write<FundTotalRecord>(writer, records);


            }

            using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                fileEngineFactory = new FixedLengthFileEngineFactory();
                var flatFileEngine1 = fileEngineFactory.GetEngine<FundTotalRecord>();

                var recordsRead = flatFileEngine1.Read<FundTotalRecord>(fileStream).ToArray();
            }

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

        private static List<FundTotalRecord> GetTotalsRecords()
        {
            List<FundTotalRecord> list = new List<FundTotalRecord>();

            //201505    20150810X8000B8000000000        01 Council Tax exGBC                                                  -00107336.58
            //201505    20150810X5400B8000000000        07 Housing Rents                                                      -00017091.55
            //201505    201508104R54250003000000        15 First Sundry Debtor                                                -00004081.18
            //201505    20150810X8002B8000000000        02 Council Tax exRUMCC                                                -00058876.10
            //201505    20150810X0310B5000000000        Daily Cash Total 20150810                                             000454587.60


            FundTotalRecord rec = new FundTotalRecord();
            rec.Year = "2015";
            rec.JournalPeriod = "05";
            rec.JournalDate = DateTime.Parse("10 Aug 2015");
            rec.GeneralLedgerCode = "X8000B8000000000";
            rec.FundIndicator = "01";
            rec.ServiceNameDescription = "Council Tax exGBC";
            rec.TotalNetAmount = 7336.58;
          
           
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
