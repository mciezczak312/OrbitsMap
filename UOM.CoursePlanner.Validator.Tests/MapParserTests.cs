using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace UOM.CoursePlanner.Validator.Tests;

public class MapParserTests
{
    [Fact]
    public async Task Should_CorrectlyParseOrbitsMap()
    {
        var fileNameSmall = "input-small.txt";
        var sut = new MapParser();

        var universeMap = sut.ParseMapFileAsync(fileNameSmall);

        universeMap.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_CorrectlyCalculateChecksum()
    {
        var fileNameSmall = "input-small.txt";
        var sut = new MapParser();

        var universeMap = await sut.ParseMapFileAsync(fileNameSmall);
        var checksum = sut.CalculateMapChecksum(universeMap);

        checksum.Should().Be(42);
    }
}