using Data.DBModel;
using Data.DTO;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class PictureService : IPictureService {
        private readonly IPictureRepository _pictureRepository;

        public PictureService(IPictureRepository pictureRepository) {
            this._pictureRepository = pictureRepository;
        }

        public bool AddPictures(PostAdd postAdd, Post post) {
            if (postAdd.Pictures == null || postAdd.Pictures.Count == 0)
                return true;
            List<Picture> pictureList = new List<Picture>();
            foreach (var picture in postAdd.Pictures)
                pictureList.Add(new Picture { Path = picture, PostId = post.Id });
            return _pictureRepository.AddAll(pictureList);
        }
    }
}
