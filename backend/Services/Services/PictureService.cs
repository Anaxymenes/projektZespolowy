using Data.DTO;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Services
{
    public class PictureService : IPictureService {
        private readonly IPictureRepository _pictureRepository;

        public PictureService(IPictureRepository pictureRepository) {
            _pictureRepository = pictureRepository;
        }

        public IEnumerable<PictureDTO> GetByPost(int postId) {
            List<PictureDTO> resultList = new List<PictureDTO>();
            var results =  _pictureRepository.GetByPost(postId);
            foreach(var obj in results) {
                resultList.Add(new PictureDTO() {
                    Id = obj.Id,
                    Path = obj.Path
                });
            }
            return resultList;
        }
    }
}
