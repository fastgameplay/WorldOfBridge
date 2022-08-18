public class RoadFactory
{
    private MapGenerator context;
    public RoadFactory(MapGenerator _context)
    {
        context = _context;
    }
    public Road Gap(float startPos){
        Road rd = new Road();
        rd.Length = context.WorldSettings.GapLength;
        rd.Width = 1;
        rd.Type = RoadType.Gap;
        rd.StartPos = startPos;
        return rd;

    }
    public Road Start()
    {
        Road rd = new Road();
        rd.Length = context.WorldSettings.StartLength;
        rd.Type = RoadType.Start;
        rd.StartPos = context.WorldSettings.StartPos;
        return rd;

    }
    public Road Road(float startPos){
        Road rd = new Road();
        rd.Length = context.WorldSettings.Length;
        rd.Width = context.WorldSettings.Width;
        rd.Type = RoadType.Road;
        rd.StartPos = startPos;
        //TODO : Change To RandomBiome;
        rd.Biome = BiomeType.Forest;
        return rd;
    }
    public Road Finish(float startPos)
    {
        Road rd = new Road();
        rd.Length = context.WorldSettings.GapLength;
        rd.Width = context.WorldSettings.Width;
        rd.Type = RoadType.Finish;
        rd.StartPos = startPos;
        return rd;
    }
}
