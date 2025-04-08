namespace AltaHyperCasual.Data
{
    public class Constants
    {
        private static Constants _instance;
        public static Constants Instance => _instance ??= new Constants();

        public const string TAG_TREE_COLLISION = "Tree";
        public const string TAG_PLAYER_SHOOTPOS = "ShootPos";
        
        public const float MIN_PLAYER_SIZE = 0.1f;
        public const float TREE_FALL_DURATION = 3f;
        public const float TREE_BURN_DURATION = 3f;
        public const float TREE_INACTIVE_DURATION = 3f;
    }
}
