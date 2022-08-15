public class MapGenerator{
    public WorldSettingsScriptable WorldSettings { get {return worldSettings; } }

    private WorldSettingsScriptable worldSettings;
    private RoadFactory roadFactory;
    
    public MapGenerator(WorldSettingsScriptable _worldSettings){
        worldSettings = _worldSettings;
        roadFactory = new RoadFactory(this);
    }

    public Road[] GenerateMap(int Size){
        Road[] roadMap = new Road[Size*2+1];
        //first two road parts
        roadMap[0] = roadFactory.Start();
        roadMap[0].Width = 5;
        roadMap[1] = roadFactory.Road(roadMap[0].EndPos);
        roadMap[1].Width = 5;
        //middle road parts
        for (int i = 2; i < Size * 2; i+= 2){
            roadMap[i] = roadFactory.Gap(roadMap[i - 1].EndPos);
            roadMap[i+1] = roadFactory.Road(roadMap[i].EndPos);
        }
        //FinishRoadPart
        roadMap[Size * 2] = roadFactory.Finish(roadMap[Size * 2 - 1].EndPos);

        //fillup map
        for (int i = 0; i < roadMap.Length; i++){
            if (roadMap[i].Type == RoadType.Gap){
                roadMap[i].nextWidth = roadMap[i + 1].Width;
                roadMap[i].Width = roadMap[i - 1].Width; //Scale to previous road part
                continue;
            }
            if(roadMap[i].Type == RoadType.Finish){
                roadMap[i].Width = roadMap[i - 1].Width;
            }
        }
        return roadMap;
    }
}
