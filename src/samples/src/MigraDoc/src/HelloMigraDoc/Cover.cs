// MigraDoc - Creating Documents on the Fly
// See the LICENSE file in the solution root for more information.

using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Quality;

namespace HelloMigraDoc
{
    public class Cover
    {
        /// <summary>
        /// Defines the cover page.
        /// </summary>
        public static void DefineCover(Document document)
        {
            var section = document.AddSection();

            var paragraph = section.AddParagraph();
            paragraph.Format.SpaceAfter = "3cm";

            var imagePath = IOUtility.GetAssetsPath("migradoc/images/MigraDoc-landscape.png")!;
            var image = section.AddImage(imagePath);
            image.Width = "10cm";

            paragraph = section.AddParagraph("A sample document that demonstrates the\ncapabilities of ");
            paragraph.AddFormattedText("MigraDoc", TextFormat.Bold);
            paragraph.Format.Font.Size = 16;
            paragraph.Format.Font.Color = Colors.DarkRed;
            paragraph.Format.SpaceBefore = "8cm";
            paragraph.Format.SpaceAfter = "3cm";

            paragraph = section.AddParagraph("Rendering date: ");
            paragraph.AddDateField();

#if true
            section.AddParagraph($"Version: {PdfSharp.Internal.SemVersionInformation.Version}");
            section.AddParagraph($"Date: {PdfSharp.Internal.SemVersionInformation.CommitDate}");
            section.AddParagraph($"Branch: {PdfSharp.Internal.SemVersionInformation.BranchName}");
            section.AddParagraph($"Build: {PdfSharp.Capabilities.Build.BuildName}");
            section.AddParagraph($"Framework: {PdfSharp.Capabilities.Build.Framework}");
#else
            // Old code from PDFsharp 6.x.
            section.AddParagraph($"Version: {MigraDocRenderingBuildInformation.GitSemVer}");
            section.AddParagraph($"Branch: {MigraDocRenderingBuildInformation.BranchName}");
            section.AddParagraph($"Assembly: {MigraDocRenderingBuildInformation.AssemblyTitle}");

            paragraph = section.AddParagraph("Platform: ");
            var platform = MigraDocRenderingBuildInformation.TargetPlatform;
            if (String.IsNullOrEmpty(platform))
                paragraph.AddFormattedText("(none)", TextFormat.Italic);
            else
                paragraph.AddText(platform);
#endif
        }
    }
}
