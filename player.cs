using System;

namespace asciiadventure {
    class Player : MovingGameObject {
        public Player(int row, int col, Screen screen, string name) : base(row, col, "@", screen) {
            Name = name;
        }
        public string Name {
            get;
            protected set;
        }
        public override Boolean IsPassable(){
            return true;
        }

        public String Action(int deltaRow, int deltaCol){
            int newRow = Row + deltaRow;
            int newCol = Col + deltaCol;
            if (!Screen.IsInBounds(newRow, newCol)){
                return "nope";
            }
            GameObject other = Screen[newRow, newCol];
            if (other == null){
                return "negative";
            }
            // TODO: Interact with the object
            if (other is Boom)
            {
                other.Delete();
                return "Boom collected!";
            }
            if (other is Treasure){
                other.Delete();
                return "Yay, we got the treasure!";
            }
            if(other is NextFloor)
            {
                return "Move to next floor";
            }
            if (other is PreviousFloor)
                return "Move to previous floor";
            return "ouch";
        }

        
    }
}