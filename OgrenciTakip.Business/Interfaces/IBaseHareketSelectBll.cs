using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Business.Interfaces
{
    public interface IBaseHareketSelectBll<TEntity>
    {
        IEnumerable<BaseHareketEntity> List(Expression<Func<TEntity, bool>> filter);
    }
}