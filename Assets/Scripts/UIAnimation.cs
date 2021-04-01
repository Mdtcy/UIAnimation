using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 /// <summary>
    /// UI动画抽象类
    /// </summary>
    public abstract class UIAnimation : MonoBehaviour
    {
        /// <summary>
        /// 是否正在运行
        /// </summary>
        public abstract bool IsRunning { get; }

        /// <summary>
        /// 开始播放动画
        /// </summary>
        /// <param name="host"></param>
        /// <returns></returns>
        public abstract void StartAnimation(MonoBehaviour host, UnityAction onComplete = null);

        /// <summary>
        /// 停止播放动画
        /// </summary>
        /// <param name="onComplete"></param>
        public abstract void StopAnimation(UnityAction onComplete = null);

    }