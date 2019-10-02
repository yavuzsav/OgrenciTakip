using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using YavuzSav.DataAccess.Interfaces;
using YavuzSav.OgrenciTakip.Business.Functions;
using YavuzSav.OgrenciTakip.Business.Interfaces;
using YavuzSav.OgrenciTakip.Common.Enums;
using YavuzSav.OgrenciTakip.Common.Functions;
using YavuzSav.OgrenciTakip.Common.Message;
using YavuzSav.OgrenciTakip.Model.Attributes;
using YavuzSav.OgrenciTakip.Model.Entities.Base;

namespace YavuzSav.OgrenciTakip.Business.Base
{
    public class BaseBll<TEntity, TContext> : IBaseBll
        where TEntity : BaseEntity
        where TContext : DbContext
    {
        private readonly Control _ctrl;
        private IUnitOfWork<TEntity> _unitOfWork;

        private bool Validation(IslemTuru islemTuru, BaseEntity oldEntity, BaseEntity currentEntity, Expression<Func<TEntity, bool>> filter)
        {
            var errorControl = GetValidationErrorControl();

            if (errorControl == null) return true;
            _ctrl.Controls[errorControl].Focus();
            return false;

            string GetValidationErrorControl()
            {
                string MukerrerKod()//aynı koddan iki kere girildiğinde
                {
                    foreach (var property in typeof(TEntity).GetPropertyAttributesFromType<Kod>())
                    {
                        if (property.Attribute == null) continue;

                        if ((islemTuru == IslemTuru.EntityInsert || oldEntity.Kod == currentEntity.Kod) && islemTuru == IslemTuru.EntityUpdate) continue;

                        if (_unitOfWork.Rep.Count(filter) < 1) continue;

                        Messages.MukerrerKayitHataMesaji(property.Attribute.Descriptoin);

                        return property.Attribute.ControlName;
                    }

                    return null;
                }

                string HataliGiris()
                {
                    foreach (var property in typeof(TEntity).GetPropertyAttributesFromType<ZorunluAlan>())
                    {
                        if (property.Attribute == null) continue;
                        var value = property.Property.GetValue(currentEntity);

                        if (property.Property.PropertyType == typeof(long))
                            if ((long)value == 0) value = null;

                        if (!string.IsNullOrEmpty(value?.ToString())) continue;

                        Messages.HataliVeriMesaji(property.Attribute.Descriptoin);

                        return property.Attribute.ControlName;
                    }

                    return null;
                }

                return HataliGiris() ?? MukerrerKod();
            }
        }

        protected BaseBll()
        {
        }

        protected BaseBll(Control ctrl)
        {
            _ctrl = ctrl;
        }

        protected TResult BaseSingle<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector)
        {
            GeneralFunctions.CreateUnitOfWork<TEntity, TContext>(ref _unitOfWork);
            return _unitOfWork.Rep.Find(filter, selector);
        }

        protected IQueryable<TResult> BaseList<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector)
        {
            GeneralFunctions.CreateUnitOfWork<TEntity, TContext>(ref _unitOfWork);
            return _unitOfWork.Rep.Select(filter, selector);
        }

        protected bool BaseInsert(BaseEntity entity, Expression<Func<TEntity, bool>> filter)
        {
            GeneralFunctions.CreateUnitOfWork<TEntity, TContext>(ref _unitOfWork);
            if (!Validation(IslemTuru.EntityInsert, null, entity, filter)) return false;
            _unitOfWork.Rep.Insert(entity.EntityConvert<TEntity>());
            return _unitOfWork.Save();
        }

        protected bool BaseUpdate(BaseEntity oldEntity, BaseEntity currentEntity, Expression<Func<TEntity, bool>> filter)
        {
            GeneralFunctions.CreateUnitOfWork<TEntity, TContext>(ref _unitOfWork);
            if (!Validation(IslemTuru.EntityUpdate, oldEntity, currentEntity, filter)) return false;
            var degisenAlanlar = oldEntity.DegisenAlanlariGetir(currentEntity);

            if (degisenAlanlar.Count == 0) return true;

            _unitOfWork.Rep.Update(currentEntity.EntityConvert<TEntity>(), degisenAlanlar);
            return _unitOfWork.Save();
        }

        protected bool BaseDelete(BaseEntity entity, KartTuru kartTuru, bool mesajVer = true)
        {
            GeneralFunctions.CreateUnitOfWork<TEntity, TContext>(ref _unitOfWork);

            if (mesajVer)
                if (Messages.SilMesaj(kartTuru.ToName()) != DialogResult.Yes) return false;
            _unitOfWork.Rep.Delete(entity.EntityConvert<TEntity>());
            return _unitOfWork.Save();
        }

        protected string BaseYeniKodVer(KartTuru kartTuru, Expression<Func<TEntity, string>> filter, Expression<Func<TEntity, bool>> where = null)
        {
            GeneralFunctions.CreateUnitOfWork<TEntity, TContext>(ref _unitOfWork);
            return _unitOfWork.Rep.YeniKodVer(kartTuru, filter, where);
        }

        #region Dispose

        public void Dispose()
        {
            _ctrl?.Dispose();
            _unitOfWork?.Dispose();
        }

        #endregion Dispose
    }
}