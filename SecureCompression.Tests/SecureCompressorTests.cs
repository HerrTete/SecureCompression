using SecureCompression;

namespace SecureCompression.Tests;

public class SecureCompressorTests
{
    [SetUp]
    public void Setup()
    {
        var testfile1 = File.Create("testfile1.txt");
        var testfile2 = File.Create("testfile2.txt");
    }

    [Test]
    public void CompressFilesTest()
    {
        var compressor = new SecureCompressor();
        var filesToCompress = new List<string> { "testfile1.txt", "testfile2.txt" };
        var destinationPath = "CompressedFiles.zip";
        var encryptionKey = Guid.NewGuid().ToString();

        Assert.DoesNotThrow(() => compressor.CompressFiles(filesToCompress, destinationPath, encryptionKey));
    }
}