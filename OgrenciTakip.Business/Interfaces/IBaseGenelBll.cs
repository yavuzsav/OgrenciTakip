using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Business.Interfaces
{
    public interface IBaseGenelBll
    {
        bool Insert(BaseEntity entity);

        bool Update(BaseEntity oldEntity, BaseEntity currentEntity);

        string YeniKodVer();
    }
}