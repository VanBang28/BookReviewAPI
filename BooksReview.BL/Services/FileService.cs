using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using BooksReview.BL.Interfaces;
using BooksReview.Common.Models;
using BooksReview.Common.Models.DTO;
using BooksReview.DL.Interfaces;
using System.IO;
using System.Net;
using static System.Net.WebRequestMethods;

namespace BooksReview.BL.Services
{
    public class FileService : IFileService
    {
        private IFileDL _fileDL;
        private readonly Cloudinary _cloudinary;
        public FileService(IFileDL fileDL, Cloudinary cloudinary)
        {
            _fileDL = fileDL;
            _cloudinary = cloudinary;
        }

        public ServiceResult Insert(FileModel fileModel)
        {
            bool res = true;
            var listImageDelete = new List<Guid>();
            var listImageinsert = new List<Image>();

            //// lấy các ảnh hiện có 
            List<Image> listImage = _fileDL.GetFileByObjectId(fileModel.ObjectId);

            if (listImage.Count > fileModel.Images.Count)
            {
                listImage.ForEach(image =>
                {
                    if (fileModel.Images.Where(x => x == image.image_id).Count() == 0)
                    {
                        listImageDelete.Add(image.image_id);
                    }
                });
            }

            if (listImageDelete.Count > 0)
            {
                //// xóa tỏng db
                res = _fileDL.DeleteFile(listImageDelete);
                // xóa trên cloud
                var uploadResult = _cloudinary.DeleteResources(listImageDelete.Select(x => x.ToString()).ToArray());
            }

            var uploadParamsList = new List<ImageUploadParams>();
            foreach (var file in fileModel.Files)
            {
                var newGuid = Guid.NewGuid();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.FileName, file.OpenReadStream()),
                    PublicId = newGuid.ToString(),
                };
                var uploadResult = _cloudinary.Upload(uploadParams);
                listImageinsert.Add(new Image()
                {
                    image_id = newGuid,
                    object_id = fileModel.ObjectId,
                    image_link = uploadResult.Uri.AbsoluteUri,
                    image_name = file.FileName
                });
            }

            if (listImageinsert.Count > 0)
            {
                //// thêm vào đb
                res = _fileDL.Insert(listImageinsert);
            }

            if (res) return new ServiceResult(res);

            return new ServiceResult("Lỗi insert ảnh");
        }
    }
}
