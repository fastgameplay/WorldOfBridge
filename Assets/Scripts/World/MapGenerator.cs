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
        roadMap[0] = roadFactory.Road(0);
        roadMap[1] = roadFactory.Gap(roadMap[0].EndPos);

        for (int i = 2; i < Size * 2; i+= 2){
            roadMap[i] = roadFactory.Road(roadMap[i - 1].EndPos);
            roadMap[i+1] = roadFactory.Road(roadMap[i].EndPos);
        }
        roadMap[roadMap.Length] = roadFactory.Finish(roadMap[roadMap.Length-1].EndPos);
        return roadMap;
    }
}
