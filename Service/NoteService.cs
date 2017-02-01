using DAL.Entities;
using Model;
using Model.Common;
using Repository.Common;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class NoteService : INoteService
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<INote> _repository;

        public NoteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = _unitOfWork.NoteRepository;
        }

        public async Task<INote> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<List<INote>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }   

        public void Update(INote entity)
        {
            _repository.Update(entity);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        public async Task SaveChangesAsync()
        {
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
