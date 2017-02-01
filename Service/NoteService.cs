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
            var temp = await _repository.GetByIdAsync(id);
            return AutoMapper.Mapper.Map<INote>(temp);
        }

        public async Task<List<INote>> GetAllAsync()
        {
            /*var temp = await _repository.GetAllAsync();
            return new List<INote>(AutoMapper.Mapper.Map<List<INote>>(temp));*/

            return await _repository.GetAllAsync();
        }   

        public void Update(INote entity)
        {
            var temp = AutoMapper.Mapper.Map<NoteEntity>(entity);
            //_repository.Update(temp);
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
