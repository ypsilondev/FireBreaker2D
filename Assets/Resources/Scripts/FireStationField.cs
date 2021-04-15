namespace Resources.Scripts
{
    public class FireStationField : GameField
    {

        private Player _player;
        
        public FireStationField(Player player) : base(FieldType.FireStation)
        {
            _player = player;
        }

        public Player GetPlayer()
        {
            return _player;
        }
        
    }
}