/**
 * @author BoLuo
 * @email [ tktetb@163.com ]
 * @create date 13:38:16
 * @modify date 13:38:16
 * @desc [将一个GameObject activeSelf的值设置为相反的值]
 */

#pragma warning disable 0649
using UnityEngine;

namespace NewLife.UI.TriggerAction
{
    /// <summary>
    /// 将一个GameObject activeSelf的值设置为相反的值
    /// </summary>
    public class ToggleGameObjectActive : ActionBase
    {
        #region FIELDS

        // GameObject
        [SerializeField]
        private GameObject gameObject;

        #endregion

        #region PROPERTIES

        #endregion

        #region PUBLIC METHODS

        /// <inheritdoc />
        public override void Execute()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }

        #endregion

        #region PROTECTED METHODS

        #endregion

        #region PRIVATE METHODS

        #endregion

        #region STATIC METHODS

        #endregion


    }
}

#pragma warning restore 0649