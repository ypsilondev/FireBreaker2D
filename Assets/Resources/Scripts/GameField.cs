using System.Collections.Generic;
using Unity.Mathematics;

namespace Resources.Scripts
{
    public class GameField
    {
        private readonly FieldType _fieldType;
        private Stack<FireEngine> _fireEngines;

        public GameField(FieldType fieldType)
        { 
            _fieldType = fieldType;
            
            _fireEngines = new Stack<FireEngine>();
        }
        
        
        
        
        
    }
}