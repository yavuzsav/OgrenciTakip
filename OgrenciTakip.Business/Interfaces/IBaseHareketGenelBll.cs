using System.Collections.Generic;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Business.Interfaces
{
    public interface IBaseHareketGenelBll
    {
        bool Insert(IList<BaseHareketEntity> entities);

        bool Update(IList<BaseHareketEntity> entities);

        bool Delete(IList<BaseHareketEntity> entities);
    }
}