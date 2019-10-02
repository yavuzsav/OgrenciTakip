using System;
using System.Linq.Expressions;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.UI.Win.Functions
{
    public class FilterFunctions
    {
        public static Expression<Func<TEntity, bool>> Filter<TEntity>(bool aktifKartlariGoster)
            where TEntity : BaseEntityDurum
        {
            return x => x.Durum == aktifKartlariGoster;
        }

        public static Expression<Func<TEntity, bool>> Filter<TEntity>(long id)
            where TEntity : BaseEntity
        {
            return x => x.Id == id;
        }
    }
}