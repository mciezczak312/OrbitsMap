using UOM.CoursePlanner.Validator;

Console.WriteLine("==== Orbits Map Validator ====");
Console.Write("map file name: ");
var mapFileName = Console.ReadLine();

var mapParser = new MapParser();
var universeMap = await mapParser.ParseMapFileAsync(mapFileName);
var checkSum = mapParser.CalculateMapChecksum(universeMap);
Console.WriteLine($"Total number of direct and indirect orbit: {checkSum}");
