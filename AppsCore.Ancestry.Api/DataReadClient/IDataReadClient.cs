using System.Collections.Generic;

namespace AppsCore.Ancestry.Api.DataReadClient
{
    public interface IDataReadClient<TModel>
    {
        List<TModel> ReadJsonData(string filePrefix);
    }
}
