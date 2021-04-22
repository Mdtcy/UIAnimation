// using UnityEngine;
// using System.Collections.Generic;
//
// // todo 有点问题，暂时弃用
// namespace Lean.Transition.Method
// {
//     ///
//     [HelpURL(LeanTransition.HelpUrlPrefix + "LeanGameObjectToggleActive")]
//     [AddComponentMenu(LeanTransition.MethodsMenuPrefix +
//                       "GameObject/GameObject.ToggleActive" +
//                       LeanTransition.MethodsMenuSuffix +
//                       "(LeanGameObjectToggleActive)")]
//     public class LeanGameObjectToggleActive : LeanMethodWithStateAndTarget
//     {
//         public override System.Type GetTargetType()
//         {
//             return typeof(GameObject);
//         }
//
//         public override void Register()
//         {
//             PreviousState = Register(GetAliasedTarget(Data.Target), Data.Active, Data.Duration);
//         }
//
//         public static LeanState Register(GameObject target, bool active, float duration)
//         {
//             var state = LeanTransition.SpawnWithTarget(State.Pool, target);
//
//             state.Active = active;
//
//             return LeanTransition.Register(state, duration);
//         }
//
//         [System.Serializable]
//         public class State : LeanStateWithTarget<GameObject>
//         {
//             [Tooltip("The Init state.")]
//             public bool Active;
//
//             public override int CanFill
//             {
//                 get { return Target != null && Target.activeSelf != Active ? 1 : 0; }
//             }
//
//             public override void FillWithTarget()
//             {
//                 Active = Target.activeSelf;
//             }
//
//             public override void UpdateWithTarget(float progress)
//             {
//                 if (progress == 1.0f)
//                 {
//                     Target.SetActive(!Target.activeSelf);
//                 }
//             }
//
//             public static Stack<State> Pool = new Stack<State>();
//
//             public override void Despawn()
//             {
//                 Pool.Push(this);
//             }
//         }
//
//         public State Data;
//     }
// }
//
// namespace Lean.Transition
// {
//     public static partial class LeanExtensions
//     {
//         public static GameObject ToggleActiveTransition(this GameObject target, bool active, float duration)
//         {
//             Method.LeanGameObjectSetActive.Register(target, active, duration);
//
//             return target;
//         }
//     }
// }