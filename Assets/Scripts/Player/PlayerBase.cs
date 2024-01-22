using UnityEngine;

namespace TatlTestTask.Player
{
    
    [CreateAssetMenu(menuName = "Game/Player/" + nameof(PlayerBase), fileName = nameof(PlayerBase))]
    public class PlayerBase : ScriptableObject
    {
        [field: SerializeField]
        public PlayerView playerViewPrefab;

        [field: SerializeField]
        public PlayerParametersSerializable playerParameters;
    }
}