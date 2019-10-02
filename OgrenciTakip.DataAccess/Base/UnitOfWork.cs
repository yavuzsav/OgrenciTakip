using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using YavuzSav.DataAccess.Interfaces;
using YavuzSav.OgrenciTakip.Common.Message;

namespace YavuzSav.DataAccess.Base
{
    public class UnitOfWork<T> : IUnitOfWork<T>
        where T : class
    {
        #region Variables

        private readonly DbContext _context;

        #endregion Variables

        public UnitOfWork(DbContext context)
        {
            if (context == null) return;
            _context = context;
        }

        public IRepository<T> Rep => new Repository<T>(_context);

        public bool Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var sqlEx = (SqlException)ex.InnerException?.InnerException;
                if (sqlEx == null)
                {
                    Messages.HataMesaji(ex.Message);
                    return false;
                }

                switch (sqlEx.Number)
                {
                    case 208:
                        Messages.HataMesaji("İşlem yapmak istediğiniz Tablo Veritabanında bulunamadı.");
                        break;

                    case 547:
                        Messages.HataMesaji("Seçilen kartın işlem görmüş hareketleri var kart silinemez.");
                        break;

                    case 2601:
                    case 2627:
                        Messages.HataMesaji("Girmiş olduğunuz Id daha önce kullanılmıştır");
                        break;

                    case 4060:
                        Messages.HataMesaji("İşlem yapmak istediğiniz Veritabanı sunucuda bulunamadı.");
                        break;

                    case 18456:
                        Messages.HataMesaji("Server'a bağlanılmak istenilen kullanıcı adı veya şifre hatalıdır.");
                        break;

                    default:
                        Messages.HataMesaji(sqlEx.Message);
                        break;
                }
                return false;
            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
                return false;
            }

            return true;
        }

        #region Dispose

        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion Dispose
    }
}