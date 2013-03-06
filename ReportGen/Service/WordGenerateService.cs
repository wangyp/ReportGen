using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ReportGen.Model;
using ReportGen.Service.Generator;
using WordDocumentGenerator.Library;

namespace ReportGen.Service
{
    public class WordGenerateService
    {
        public const string SUBSCRIBESUMMARY = "SubscribeSummary";

        private static string TemplatePath = @"d:\GitProject\GitHub\ReportGen\ReportGen\Template\";
        private static string OutputPath = @"d:\GitProject\GitHub\ReportGen\ReportGen\out\";


        /// <summary>
        /// Generates the document using sample doc generator.
        /// </summary>
        public static void Generate(string template, DocumentGenerationInfo generationInfo, string outputFileName)
        {

            WordReportGenerator sampleDocumentGenerator = GetGenerator(template, generationInfo);
            byte[] result = sampleDocumentGenerator.GenerateDocument();
            WriteOutputToFile(outputFileName, result);
        }

        /// <summary>
        /// Generates the document using sample doc generator.
        /// </summary>
        public static void Generate(string template, ReportData data, string outputFileName)
        {
            var info = GetDocumentGenerationInfo(data, template + ".docx");
            Generate(template, info, outputFileName);
        }


#region Private
        private static WordReportGenerator GetGenerator(string name, DocumentGenerationInfo generationInfo)
        {
            return WordReportGenerator.Create(name, generationInfo);
        }

        private static ReportData GetReportData(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the document generation info.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        /// <param name="templateFileName">Name of the file.</param>
        /// <returns></returns>
        private static DocumentGenerationInfo GetDocumentGenerationInfo(object dataContext, string templateFileName)
        {
            DocumentGenerationInfo generationInfo = new DocumentGenerationInfo();
            generationInfo.Metadata = new DocumentMetadata() { DocumentType = "SampleDocumentGenerator", DocumentVersion = "1.0" };
            generationInfo.DataContext = dataContext;
            generationInfo.TemplateData = File.ReadAllBytes(Path.Combine(TemplatePath, templateFileName));
            generationInfo.IsDataBoundControls = false;

            return generationInfo;
        }


        /// <summary>
        /// Writes the output to file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileContents">The file contents.</param>
        private static void WriteOutputToFile(string fileName, byte[] fileContents)
        {
            ConsoleColor consoleColor = Console.ForegroundColor;

            if (fileContents != null)
            {
                File.WriteAllBytes(Path.Combine(OutputPath, fileName), fileContents);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(string.Format("Generation succeeded for ({0}) ",  fileName));
                Console.WriteLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(string.Format("Generation failed for ({0})", fileName));
            }

            Console.ForegroundColor = consoleColor;
        }
#endregion
    }
}
