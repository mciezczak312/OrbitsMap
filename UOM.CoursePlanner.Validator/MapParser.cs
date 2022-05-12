using System.Text;

namespace UOM.CoursePlanner.Validator;

public class MapParser
{
    public async Task<Dictionary<string, PlanetNode>> ParseMapFileAsync(string fileName)
    {
        var orbitsMapData = await File.ReadAllLinesAsync(fileName, Encoding.UTF8);
        var universeMap = new Dictionary<string, PlanetNode>();

        foreach (var mapEntry in orbitsMapData)
        {
            var (parentPlanetName, childPlanetName, _) = mapEntry.Split(')');
            var parentPlanet = universeMap.GetOrAdd(parentPlanetName, () => new PlanetNode() { Name = parentPlanetName });
            var childPlanet = universeMap.GetOrAdd(childPlanetName, () => new PlanetNode() { Name = childPlanetName });
            parentPlanet.AddChild(childPlanet);
        }
        
        return universeMap;
    }

    public long CalculateMapChecksum(Dictionary<string, PlanetNode> universeMap)
    {
        return universeMap.Values.Select(x => x.DepthLevel).Sum();
    }
}