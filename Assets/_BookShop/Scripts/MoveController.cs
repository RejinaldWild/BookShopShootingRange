using UnityEngine;

namespace _BookShop.Scripts
{
   public class MoveController
   {
      private readonly InputController _input;
      private readonly Player _player;
      private Vector3 _delta;

      
      public MoveController(InputController input, Player player)
      {
         _input = input;
         _player = player;
      }

      public void Update()
      {
         _delta = _input.GetPosition();
      }

      public void FixedUpdate()
      {
         _player.Move(_delta);
      }
   }
}
