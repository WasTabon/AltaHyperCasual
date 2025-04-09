using System;
using UnityEngine;

namespace AltaHyperCasual.Code.WinController
{
    public interface IWin
    {
        event Action OnWin;
        event Action OnLose;
        void Initialize(Transform playerTransform, Transform finishTransform);
        void CheckWin();
    }
}
