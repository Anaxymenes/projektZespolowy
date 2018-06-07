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

        public Picture Add(PostAdd postAdd, Post post) {
            if (postAdd.Picture == null || postAdd.Picture == "")
                return null;
            Picture picture = new Picture (){ Path = postAdd.Picture, PostId = post.Id };
            return _pictureRepository.Add(picture);
        }

        public bool AddPictures(PostAdd postAdd, Post post) {
            throw new NotImplementedException();
        }

        //public bool AddPictures(PostAdd postAdd, Post post) {
        //    if (postAdd.Pictures == null || postAdd.Pictures.Count == 0)
        //        return true;
        //    List<Picture> pictureList = new List<Picture>();
        //    foreach (var picture in postAdd.Pictures)
        //        pictureList.Add(new Picture { Path = picture, PostId = post.Id });
        //    return _pictureRepository.AddAll(pictureList);
        //}
    }
}
