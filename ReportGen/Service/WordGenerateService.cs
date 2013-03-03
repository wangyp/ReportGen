using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ReportGen.Model;
using WordDocumentGenerator.Library;

namespace ReportGen.Service
{
    class WordGenerateService
    {
        
        /// <summary>
        /// Generates the document using sample doc generator.
        /// </summary>
        private static void GenerateDocumentUsingSampleDocGenerator()
        {
            // Test document generation from template("Test_Template - 1.docx")
            DocumentGenerationInfo generationInfo = GetDocumentGenerationInfo("SampleDocumentGenerator", "1.0", GetReportData(),
                                                    "Test_Template - 1.docx", false);

            WordReportGenerator sampleDocumentGenerator = new WordReportGenerator(generationInfo);
            byte[] result = result = sampleDocumentGenerator.GenerateDocument();
            WriteOutputToFile("Test_Template1_Out.docx", "Test_Template - 1.docx", result);
        }

        private static ReportData GetReportData()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the document generation info.
        /// </summary>
        /// <param name="docType">Type of the doc.</param>
        /// <param name="docVersion">The doc version.</param>
        /// <param name="dataContext">The data context.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="useDataBoundControls">if set to <c>true</c> [use data bound controls].</param>
        /// <returns></returns>
        private static DocumentGenerationInfo GetDocumentGenerationInfo(string docType, string docVersion, object dataContext, string fileName, bool useDataBoundControls)
        {
            DocumentGenerationInfo generationInfo = new DocumentGenerationInfo();
            generationInfo.Metadata = new DocumentMetadata() { DocumentType = docType, DocumentVersion = docVersion };
            generationInfo.DataContext = dataContext;
            generationInfo.TemplateData = File.ReadAllBytes(Path.Combine("Sample Templates", fileName));
            generationInfo.IsDataBoundControls = useDataBoundControls;

            return generationInfo;
        }


        /// <summary>
        /// Writes the output to file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="templateName">Name of the template.</param>
        /// <param name="fileContents">The file contents.</param>
        private static void WriteOutputToFile(string fileName, string templateName, byte[] fileContents)
        {
            ConsoleColor consoleColor = Console.ForegroundColor;

            if (fileContents != null)
            {
                File.WriteAllBytes(Path.Combine("Sample Templates", fileName), fileContents);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(string.Format("Generation succeeded for template({0}) --> {1}", templateName, fileName));
                Console.WriteLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(string.Format("Generation failed for template({0}) --> {1}", templateName, fileName));
            }

            Console.ForegroundColor = consoleColor;
        }

    }
}
