using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workly.Api.Cloudinary
{
    public static class UploadToCloudinary
    {
        public static CloudinaryDotNet.Cloudinary cloudinary;

        public const string CLOUD_NAME = "dcrllmnai";
        public const string API_KEY = "581332317551619";
        public const string API_SECRET = "Jm_ZH12L6l2RURuM37zqmjwGwBo";
        public static string UploadImageToCloudinary(this string Image)
        {
            Account account = new Account(CLOUD_NAME, API_KEY, API_SECRET);
            cloudinary = new CloudinaryDotNet.Cloudinary(account);
            try
            {
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(Image)
                };
                //new image path on cloudinary
                var urlOnCloudinary = cloudinary.UploadAsync(uploadParams).Result.Uri;
                return urlOnCloudinary.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
    }
}
