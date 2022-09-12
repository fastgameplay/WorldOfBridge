public class RoadFactory
{
    private bool isFirstRoad;
    private MapGenerator context;
    public RoadFactory(MapGenerator _context)
    {
        context = _context;
        isFirstRoad = false;
    }
    public RoadStruct Gap(float startPos){
        RoadStruct rd = new RoadStruct();
        rd.Length = context.WorldSettings.GapLength;
        rd.Width = 1;
        rd.Type = RoadType.Gap;
        rd.StartPos = startPos;
        return rd;

    }
    public RoadStruct Start()
    {
        RoadStruct rd = new RoadStruct();
        rd.Length = context.WorldSettings.StartLength;
        rd.Type = RoadType.Start;
        rd.Width = 5; //HardCoded
        rd.StartPos = context.WorldSettings.StartPos;
        return rd;

    }
    public RoadStruct Road(float startPos){
        RoadStruct rd = new RoadStruct();
        rd.Length = context.WorldSettings.Length;
        rd.Width = context.WorldSettings.Width;
        rd.Type = RoadType.Road;
        rd.StartPos = startPos;
        if (isFirstRoad) rd.Width = 5; //HardCoded
        return rd;
    }
    public RoadStruct Finish(float startPos)
    {
        RoadStruct rd = new RoadStruct();
        rd.Length = context.WorldSettings.GapLength;
        rd.Width = context.WorldSettings.Width;
        rd.Type = RoadType.Finish;
        rd.StartPos = startPos;
        return rd;
    }
}
