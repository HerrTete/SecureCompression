using SecureCompression;

namespace SecureCompression.Tests;

public class SecureCompressorTests
{
    private string testDirectory = AppDomain.CurrentDomain.BaseDirectory;
    private List<string> _inputFiles = new List<string>
    {
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"testfile1.txt"),
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"testfile2.txt"),
    };

    [SetUp]
    public void Setup()
    {
        foreach (var file in _inputFiles)
        {
            if (!File.Exists(file))
            {
                File.WriteAllText(file, "This is a test file for SecureCompressor unit tests.");
            }
        }
    }

    [Test]
    public void RoundtripTest()
    {
        var workingDir = Path.GetTempPath();
        var inputFiles = new List<string>
        {
            Path.Combine(workingDir,"input","testfile1.txt"),
            Path.Combine(workingDir,"input","testfile2.txt"),
        };
        var compressor = new SecureCompressor();
        var compressedFile = Path.Combine(workingDir, "output", "CompressedFiles.zip");
        var encryptionKey = Guid.NewGuid().ToString();

        Assert.DoesNotThrow(() => compressor.CompressFiles(inputFiles, compressedFile, encryptionKey));
        Assert.DoesNotThrow(() => compressor.DecompressFiles(compressedFile, Path.Combine(workingDir, "output","decompressed"), encryptionKey));
    }
}