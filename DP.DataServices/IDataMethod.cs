using DP.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DP.DataServices
{
    public interface IDataMethod<T, T2>
    {
        Result<T> Save(T instance);
        Result<T> Edit(T instance);
        Result<T> Delete(int instanceId);
        Result<T2> SelectAll();
        Result<T> SelectOne(int instanceId);
    }
}
