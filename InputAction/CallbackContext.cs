using System;
using UnityEngine;

namespace InputAction
{
    public class CallbackContext
    {
        internal bool performed;

        internal Vector3 ReadValue<T>()
        {
            throw new NotImplementedException();
        }
    }
}