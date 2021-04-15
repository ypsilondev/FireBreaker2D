using Unity.Mathematics;

namespace Resources.Scripts
{
    public class ForestField : GameField
    {

        private readonly ForestState _state;
        
        public ForestField(ForestState state) : base(FieldType.Forest)
        {
            _state = state;
        }


        public ForestState GetState()
        {
            return _state;
        }
        
    }
}