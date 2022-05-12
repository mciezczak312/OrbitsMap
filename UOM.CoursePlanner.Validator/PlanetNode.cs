namespace UOM.CoursePlanner.Validator;

public class PlanetNode
{
    public string Name { get; set; }

    public PlanetNode Parent;

    public List<PlanetNode> Childern = new();

    public void AddChild(PlanetNode child)
    {
        this.Childern.Add(child);
        child.Parent = this;
    }

    public int DepthLevel => this.Parent == null ? 0 : this.Parent.DepthLevel+1;
}